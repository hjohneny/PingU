
/*
 * 
 * Code by Mladen Jankovic.
 * 
 * contact: kataklinger@gmail[dot]com
 *
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Resources;
using System.Reflection;

namespace LiveGraph
{

	#region ViewGroup

	public class ViewGroup
	{

		#region MinMax

		#region GlobalMin

		private float _globalMin;

		public float GlobalMin { get { return _globalMin; } }

		#endregion

		#region GlobalMax

		private float _globalMax;

		public float GlobalMax { get { return _globalMax; } }

		#endregion

		#region Update

		private void series_OnMinChanged(DataSeries series) { UpdateGlobalMin(); }

		private void series_OnMaxChanged(DataSeries series) { UpdateGlobalMax(); }

		private void UpdateGlobalMin()
		{
			_globalMin = float.MaxValue;
			foreach (DataSeriesView v in _views)
			{
				if (_globalMin > v.Series.Min)
					_globalMin = v.Series.Min;
			}
		}

		private void UpdateGlobalMax()
		{
			_globalMax = float.MinValue;
			foreach (DataSeriesView v in _views)
			{
				if (_globalMax < v.Series.Max)
					_globalMax = v.Series.Max;
			}
		}

		#endregion

		#endregion

		#region Name

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		#endregion

		#region Views

		private List<DataSeriesView> _views = new List<DataSeriesView>();

		public void Attach(DataSeriesView view)
		{
			_views.Add(view);

			view.Series.OnMinChanged += new DataSeries.MinMaxChangedDelegate(series_OnMinChanged);
			view.Series.OnMaxChanged += new DataSeries.MinMaxChangedDelegate(series_OnMaxChanged);

			UpdateGlobalMin();
			UpdateGlobalMax();
		}

		public void Detach(DataSeriesView view)
		{
			_views.Remove(view);

			view.Series.OnMinChanged -= series_OnMinChanged;
			view.Series.OnMaxChanged -= series_OnMaxChanged;

			UpdateGlobalMin();
			UpdateGlobalMax();

			if (_views.Count == 0)
				RaiseOnEmptyGroup();
		}

		#endregion

		#region OnEmptyGroup

		public delegate void EmptyGroupDelegate(ViewGroup group);

		public event EmptyGroupDelegate OnEmptyGroup;

		private void RaiseOnEmptyGroup()
		{
			if (OnEmptyGroup != null)
				OnEmptyGroup(this);
		}

		#endregion

		#region Constructor

		public ViewGroup(string name) { _name = name; }

		#endregion

	}

	#endregion

	#region DataSeriesView

	public class DataSeriesView
	{

		#region Container

		private Graph _container = null;

		public Graph Container
		{
			get { return _container; }
			set { _container = value; }
		}

		#endregion

		#region Series

		private DataSeries _series = null;

		public DataSeries Series
		{
			get { return _series; }
		}

		#endregion

		#region LineColor

		private Color _lineColor = Color.Black;

		public Color LineColor
		{
			get { return _lineColor; }
			set
			{
				_lineColor = value;
				RaiseOnViewChanged();
			}
		}

		#endregion

		#region Hidden

		private bool _hidden = false;

		public bool Hidden
		{
			get { return _hidden; }
			set
			{
				_hidden = value;
				RaiseOnViewChanged();
			}
		}

		#endregion

		#region Group

		private ViewGroup _group = null;

		public ViewGroup Group
		{
			get { return _group; }

			set
			{
				if (_group != value)
				{
					if (_group != null)
						_group.Detach(this);

					_group = value;

					if (_group != null)
						_group.Attach(this);

					RaiseOnViewChanged();
				}
			}
		}

		public float GroupMin { get { return _group != null ? _group.GlobalMin : _series.Min; } }

		public float GroupMax { get { return _group != null ? _group.GlobalMax : _series.Max; } }

		#endregion

		#region PlotPoint

		public struct PlotPoint
		{

			public enum Type
			{
				Valid,
				Unavailable,
				NaN,
				NegInf,
				PosInf
			};

			public int _x;

			public int _y;

			public float _realValue;

			public Type _type;

			public PlotPoint(int x, int y, float realValue, Type type)
			{
				_x = x;
				_y = y;
				_realValue = realValue;
				_type = type;
			}

			public static Type GetType(float y)
			{
				if (float.IsNaN(y)) return Type.NaN;
				if (float.IsNegativeInfinity(y)) return Type.NegInf;
				if (float.IsPositiveInfinity(y)) return Type.PosInf;

				return Type.Valid;
			}

		}

		private LinkedList<PlotPoint> _currentPoints = new LinkedList<PlotPoint>();

		public LinkedList<PlotPoint> CurrentPoints { get { return _currentPoints; } }

		public void UpdateCurrentPoints(int x, int y, int height, long resolution, long timeLength, long endTimeStamp)
		{
			_currentPoints.Clear();

			float diff = GroupMax - GroupMin;
			float min = GroupMin;

			long beginTimeStamp = endTimeStamp - timeLength;

			for (LinkedListNode<DataSeries.DataPoint> current = _series.DataPoints.Last; current != null; current = current.Previous)
			{
				DataSeries.DataPoint point = current.Value;

				if (point.TimeStamp < beginTimeStamp)
					break;

				if (point.TimeStamp <= endTimeStamp)
				{
					int px = x + (int)((point.TimeStamp - endTimeStamp + timeLength) / resolution);

					if (!point.Available)
						_currentPoints.AddFirst(new PlotPoint(px, 0, 0, PlotPoint.Type.Unavailable));
					else
					{
						float v = height * (1 - (point.Value - min) / diff);
						int py = point.Available ? y + (int)v : 0;

						_currentPoints.AddFirst(new PlotPoint(px, py, point.Value, PlotPoint.GetType(v)));
					}
				}
			}
		}

		#endregion

		#region OnViewChanged

		public delegate void ViewChangeDelegate(DataSeriesView view);

		public event ViewChangeDelegate OnViewChanged;

		public void RaiseOnViewChanged()
		{
			if (OnViewChanged != null)
				OnViewChanged(this);
		}

		#endregion

		#region Constructors

		public DataSeriesView(Graph container, DataSeries series, Color lineColor)
		{
			_container = container;
			_series = series;
			_lineColor = lineColor;
			_hidden = false;
		}

		#endregion

		#region XML

		private static string XML_ELEMENT_NAME_SERIES = "series";

		private static string XML_ELEMENT_NAME_COLOR = "color";

		private static string XML_ELEMENT_NAME_HIDDEN = "hidden";

		private static string XML_ELEMENT_NAME_GROUP = "group";

		public delegate DataSeries SeriesLookupDelegate(string id);

		public delegate string SeriesIDLookupDelegate(DataSeries series);

		public delegate ViewGroup ViewGroupLookupDelegate(string name);

		public DataSeriesView(Graph graph, XmlNode node, SeriesLookupDelegate seriesLookup, ViewGroupLookupDelegate viewLookup)
		{
			_container = graph;

			if (node[XML_ELEMENT_NAME_SERIES] != null)
				_series = seriesLookup(node[XML_ELEMENT_NAME_SERIES].InnerText);

			if (node[XML_ELEMENT_NAME_COLOR] != null)
				_lineColor = Color.FromArgb(int.Parse(node[XML_ELEMENT_NAME_COLOR].InnerText, System.Globalization.NumberStyles.HexNumber));

			if (node[XML_ELEMENT_NAME_HIDDEN] != null)
				_hidden = bool.Parse(node[XML_ELEMENT_NAME_HIDDEN].InnerText);

			if (node[XML_ELEMENT_NAME_GROUP] != null)
				Group = viewLookup(node[XML_ELEMENT_NAME_GROUP].InnerText);
		}

		public void Save(XmlDocument document, XmlNode node, DataSeriesView.SeriesIDLookupDelegate seriesIDLookup)
		{
			XmlNode n = null;

			n = document.CreateElement(XML_ELEMENT_NAME_SERIES);
			n.InnerText = seriesIDLookup(_series);
			node.AppendChild(n);

			n = document.CreateElement(XML_ELEMENT_NAME_COLOR);
			n.InnerText = _lineColor.ToArgb().ToString("X");
			node.AppendChild(n);

			n = document.CreateElement(XML_ELEMENT_NAME_HIDDEN);
			n.InnerText = _hidden.ToString();
			node.AppendChild(n);

			if (_group != null)
			{
				n = document.CreateElement(XML_ELEMENT_NAME_GROUP);
				n.InnerText = _group.Name;
				node.AppendChild(n);
			}
		}

		#endregion

	}

	#endregion

	#region Graph

	public class Graph
	{

		#region Size

		private Size _size;

		public Size Size
		{
			get { return _size; }
			set { _size = value; }
		}

		#endregion

		#region Position

		private Point _position;

		public Point Position
		{
			get { return _position; }
			set { _position = value; }
		}

		#endregion

		#region Name

		private string _name = string.Empty;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		#endregion

		#region Resolution

		private long _resolution = 1000 * TimeSpan.TicksPerMillisecond;

		public long Resolution
		{
			get { return _resolution; }
			set
			{
				_resolution = value;
				RaiseOnResolutionChanged();
			}
		}

		public delegate void ResolutionChangedDelegate(Graph graph);

		public event ResolutionChangedDelegate OnResolutionChanged;

		private void RaiseOnResolutionChanged()
		{
			if (OnResolutionChanged != null)
				OnResolutionChanged(this);
		}

		#endregion

		#region LastTimeStamp

		private long _lastVisibleTimeStamp = DateTime.Now.Ticks;

		public long LastVisibleTimeStamp
		{
			get { return _lastVisibleTimeStamp; }
		}

		private bool _trackUpdates = true;

		#endregion

		#region ShowTimeLabels

		private bool _showTimeLabels = false;

		public bool ShowTimeLabels
		{
			get { return _showTimeLabels; }
			set
			{
				_showTimeLabels = value;
				RaiseOnShowTimeLabels();
			}
		}

		public delegate void ShowTimeLabelsDelegate(Graph graph);

		public event ShowTimeLabelsDelegate OnShowTimeLabels;

		private void RaiseOnShowTimeLabels()
		{
			if (OnShowTimeLabels != null)
				OnShowTimeLabels(this);
		}

		#endregion

		#region Views

		private LinkedList<DataSeriesView> _views = new LinkedList<DataSeriesView>();

		public LinkedList<DataSeriesView> Views { get { return _views; } }

		public void AddView(DataSeries series, Color lineColor) { AddViewHelper(new DataSeriesView(this, series, lineColor)); }

		private void AddViewHelper(DataSeriesView view)
		{
			view.OnViewChanged += new DataSeriesView.ViewChangeDelegate(view_OnViewChanged);

			view.Series.OnAddPoint += new DataSeries.AddDataPointDelegate(series_OnAddPoint);
			view.Series.OnNameChanged += new DataSeries.NameChangedDelegate(series_OnChange);
			view.Series.OnUnitNameChanged += new DataSeries.UnitNameChangedDelegate(series_OnChange);
			view.Series.OnGroupChanged += new DataSeries.GroupChangedDelegate(series_OnChange);

			_views.AddLast(view);
			RaiseOnAddView(view);
		}

		public delegate void AddViewDelegate(Graph graph, DataSeriesView view);

		public event AddViewDelegate OnAddView;

		private void RaiseOnAddView(DataSeriesView view)
		{
			if (OnAddView != null)
				OnAddView(this, view);
		}

		private void series_OnAddPoint(DataSeries series, long timeStamp)
		{
			if (_trackUpdates && _lastVisibleTimeStamp < timeStamp)
				_lastVisibleTimeStamp = timeStamp;

			RaiseOnAddPoint(series);
		}

		public delegate void SeriesChangedDelegate(Graph graph, DataSeries series);

		public event SeriesChangedDelegate OnSeriesChanged;

		public void RaiseOnSeriesChanged(DataSeries series)
		{
			if (OnSeriesChanged != null)
				OnSeriesChanged(this, series);
		}

		void series_OnChange(DataSeries series) { RaiseOnSeriesChanged(series); }

		public delegate void ViewChangeDelegate(Graph graph, DataSeriesView view);

		public event ViewChangeDelegate OnViewChanged;

		private void RaiseOnViewChange(DataSeriesView view)
		{
			if (OnViewChanged != null)
				OnViewChanged(this, view);
		}

		private void view_OnViewChanged(DataSeriesView view) { RaiseOnViewChange(view); }

		public delegate void AddPointDelegate(Graph graph, DataSeries series);

		public event AddPointDelegate OnAddPoint;

		private void RaiseOnAddPoint(DataSeries series)
		{
			if (OnAddPoint != null)
				OnAddPoint(this, series);
		}

		public void RemoveView(DataSeries series)
		{
			foreach (DataSeriesView v in _views)
			{
				if (v.Series == series)
				{
					_views.Remove(v);
					v.OnViewChanged -= view_OnViewChanged;

					v.Series.OnAddPoint -= series_OnAddPoint;
					v.Series.OnNameChanged -= series_OnChange;
					v.Series.OnUnitNameChanged -= series_OnChange;
					v.Series.OnGroupChanged -= series_OnChange;

					RaiseOnRemoveView(v);
					break;
				}
			}
		}

		public delegate void RemoveViewDelegate(Graph graph, DataSeriesView view);

		public event RemoveViewDelegate OnRemoveView;

		private void RaiseOnRemoveView(DataSeriesView view)
		{
			if (OnRemoveView != null)
				OnRemoveView(this, view);
		}

		#endregion

		#region Groups

		private List<ViewGroup> _groups = new List<ViewGroup>();

		public List<ViewGroup> Groups { get { return _groups; } }

		public ViewGroup CreateNewGroup(string name, DataSeriesView initialView)
		{
			ViewGroup group = new ViewGroup(name);

			if (initialView != null)
				initialView.Group = group;

			group.OnEmptyGroup += new ViewGroup.EmptyGroupDelegate(group_OnEmptyGroup);
			_groups.Add(group);

			return group;
		}

		void group_OnEmptyGroup(ViewGroup group)
		{
			group.OnEmptyGroup -= group_OnEmptyGroup;
			_groups.Remove(group);
		}

		#endregion

		#region Drawing

		#region GDI Objects

		private static readonly Pen BLACK_PEN = new Pen(Color.Black, 1);
		private static readonly Brush BLACK_BRUSH = new SolidBrush(Color.Black);
		private static readonly Pen TIME_LABEL_PEN = new Pen(new HatchBrush(HatchStyle.Horizontal, Color.Green, Color.Transparent), 2);
		private static readonly Brush TIME_LABEL_BRUSH = new SolidBrush(Color.Green);
		private static readonly Font FONT = new Font("Arial", 8);
		private static readonly Image MAGNIFY_ICON = Resources.magnify;

		#endregion

		#region Border Sizes

		private const int VER_BORDER = 10;
		private const int HOR_BORDER_TOP = 25;
		private const int HOR_BORDER_BOTTOM = 30;
		private const int SCROLL_BAR_HEIGHT = 15;

		#endregion

		#region Time Spans

		private const int MIN_TIME_LABEL_SPAN = 100;
		private static long[] TICK_PER_MEASURE_OF_TIME =
		{
			TimeSpan.TicksPerMillisecond, 100 * TimeSpan.TicksPerMillisecond, 500 * TimeSpan.TicksPerMillisecond,
			TimeSpan.TicksPerSecond, 2 * TimeSpan.TicksPerSecond, 5 * TimeSpan.TicksPerSecond, 10 * TimeSpan.TicksPerSecond, 15 * TimeSpan.TicksPerSecond, 30 * TimeSpan.TicksPerSecond,
			TimeSpan.TicksPerMinute, 2 * TimeSpan.TicksPerMinute, 5 * TimeSpan.TicksPerMinute, 10 * TimeSpan.TicksPerMinute, 15 * TimeSpan.TicksPerMinute, 30 * TimeSpan.TicksPerMinute,
			TimeSpan.TicksPerHour, 2 * TimeSpan.TicksPerHour, 4 * TimeSpan.TicksPerHour, 8 * TimeSpan.TicksPerHour, 12 * TimeSpan.TicksPerHour,
			TimeSpan.TicksPerDay
		};

		#endregion

		public Rectangle MagnifyIconRect
		{
			get
			{
				return new Rectangle(_position.X + _size.Width - VER_BORDER - MAGNIFY_ICON.Width, _position.Y + HOR_BORDER_TOP - MAGNIFY_ICON.Height - 2,
					MAGNIFY_ICON.Width, MAGNIFY_ICON.Height);
			}
		}

		public Rectangle ScrollFrame
		{
			get
			{
				return new Rectangle(_position.X + VER_BORDER, _position.Y + _size.Height - HOR_BORDER_BOTTOM - SCROLL_BAR_HEIGHT,
					_size.Width - 2 * VER_BORDER, SCROLL_BAR_HEIGHT);
			}
		}

		public Rectangle ScrollBox
		{
			get
			{
				int plotAreaWidth = _size.Width - 2 * VER_BORDER;

				long len = TotalGraphLength;
				if (len <= plotAreaWidth * _resolution)
					return new Rectangle(0, 0, 0, 0);

				int scrollBoxWidth = (int)((plotAreaWidth * plotAreaWidth * _resolution) / len);
				if (scrollBoxWidth < SCROLL_BAR_HEIGHT)
					scrollBoxWidth = SCROLL_BAR_HEIGHT;

				long pp = len / (plotAreaWidth - scrollBoxWidth);

				int pos = (int)((_lastVisibleTimeStamp - GraphBegining) / pp);

				return new Rectangle(_position.X + VER_BORDER + pos, _position.Y + _size.Height - HOR_BORDER_BOTTOM - SCROLL_BAR_HEIGHT + 2,
					scrollBoxWidth, SCROLL_BAR_HEIGHT - 4);
			}
		}

		public void Scroll(int pos)
		{
			int plotAreaWidth = _size.Width - 2 * VER_BORDER;
			long len = TotalGraphLength;
			int scrollBoxWidth = (int)((plotAreaWidth * plotAreaWidth * _resolution) / len);
			if (scrollBoxWidth < SCROLL_BAR_HEIGHT)
				scrollBoxWidth = SCROLL_BAR_HEIGHT;

			long pp = len / (plotAreaWidth - scrollBoxWidth);
			_lastVisibleTimeStamp = GraphBegining + (pos - VER_BORDER) * pp;

			_trackUpdates = _lastVisibleTimeStamp > (len - plotAreaWidth * _resolution / 2) + GraphBegining;
		}

		public void Draw(Graphics output)
		{
			Rectangle plotArea = DrawFrame(output);
			PlotSeries(output, plotArea);
		}

		private Rectangle DrawFrame(Graphics output)
		{

			Rectangle plotFrame = new Rectangle(_position.X + VER_BORDER, _position.Y + HOR_BORDER_TOP,
				_size.Width - 2 * VER_BORDER, _size.Height - (HOR_BORDER_TOP + HOR_BORDER_BOTTOM + SCROLL_BAR_HEIGHT));

			Rectangle scrollFrame = ScrollFrame;

			output.FillRectangle(BLACK_BRUSH, ScrollBox);

			Rectangle magnifyRect = MagnifyIconRect;

			int textHeight = (int)output.MeasureString(" ", FONT).Height;

			Point unitPos = new Point(plotFrame.X, plotFrame.Y - textHeight - 2);
			Point maxPos = new Point(plotFrame.X, (int)(plotFrame.Y + textHeight + 2));
			Point minPos = new Point(plotFrame.X, (int)(plotFrame.Y + plotFrame.Height - textHeight - 2));

			output.DrawLine(BLACK_PEN, new Point(maxPos.X - 2, maxPos.Y), new Point(maxPos.X + 2, maxPos.Y));
			output.DrawLine(BLACK_PEN, new Point(minPos.X - 2, minPos.Y), new Point(minPos.X + 2, minPos.Y));

			output.DrawRectangle(BLACK_PEN, plotFrame);
			output.DrawRectangle(BLACK_PEN, scrollFrame);

			output.DrawImage(MAGNIFY_ICON, magnifyRect);

			string res = "[" + _name + "] " + (_resolution / TimeSpan.TicksPerMillisecond).ToString() + "ms : 1px";
			output.DrawString(res, FONT, BLACK_BRUSH, new Point(magnifyRect.X - (int)output.MeasureString(res, FONT).Width - 2, plotFrame.Y - textHeight - 2));

			foreach (DataSeriesView v in _views)
			{
				if (v.Hidden)
					continue;

				Brush brush = new SolidBrush(v.LineColor);

				string unitName = "[" + v.Series.UnitName + "] ";
				output.DrawString(unitName, FONT, brush, unitPos);
				unitPos.X += (int)output.MeasureString(unitName, FONT).Width;

				string maxValue = "[" + v.GroupMax.ToString("F02") + "]";
				output.DrawString(maxValue, FONT, brush, maxPos.X, maxPos.Y - textHeight - 2);
				maxPos.X += (int)output.MeasureString(maxValue, FONT).Width;

				string minValue = "[" + v.GroupMin.ToString("F02") + "]";
				output.DrawString(minValue, FONT, brush, minPos);
				minPos.X += (int)output.MeasureString(minValue, FONT).Width;
			}

			if (_showTimeLabels)
			{
				long timeLength = _resolution * plotFrame.Width;

				long minSpan = MIN_TIME_LABEL_SPAN * _resolution;

				long visibleBegining = _lastVisibleTimeStamp - timeLength;
				long graphBegining = GraphBegining;

				if (graphBegining > 0)
				{
					foreach (long measureOfTime in TICK_PER_MEASURE_OF_TIME)
					{
						if (measureOfTime >= minSpan)
						{
							for (long time = ((visibleBegining / measureOfTime) + 1) * measureOfTime; time < _lastVisibleTimeStamp; time += measureOfTime)
							{
								int x = plotFrame.X + (int)((time - visibleBegining) / _resolution);

								output.DrawLine(TIME_LABEL_PEN, new Point(x, maxPos.Y), new Point(x, minPos.Y));
								DateTime timeStamp = new DateTime(time);
								string timeStampStr = timeStamp.ToString("yyyy-MM-dd\nhh:mm:ss.ms");

								int w = (int)output.MeasureString(timeStampStr, FONT).Width / 2;
								output.DrawString(timeStampStr, FONT, TIME_LABEL_BRUSH, new Point(x - w, scrollFrame.Bottom));
							}

							break;
						}
					}
				}
			}


			return new Rectangle(plotFrame.X, maxPos.Y, plotFrame.Width, minPos.Y - maxPos.Y);
		}

		private void PlotSeries(Graphics output, Rectangle plotArea)
		{
			long timeLength = _resolution * plotArea.Width;

			foreach (DataSeriesView v in _views)
			{
				if (v.Hidden)
					continue;

				v.UpdateCurrentPoints(plotArea.X, plotArea.Y, plotArea.Height, _resolution, timeLength, _lastVisibleTimeStamp);

				Brush brush = new SolidBrush(v.LineColor);

				Point? last = null;
				foreach (DataSeriesView.PlotPoint p in v.CurrentPoints)
				{
					if (p._type == DataSeriesView.PlotPoint.Type.Unavailable || p._type == DataSeriesView.PlotPoint.Type.NaN)
					{
						output.FillEllipse(brush, p._x - 2, plotArea.Y + plotArea.Height / 2 - 2, 4, 4);
						last = null;
					}
					else if (p._type == DataSeriesView.PlotPoint.Type.NegInf)
					{
						DrawTriangle(output, brush, p._x, plotArea.Y + plotArea.Height, 5, -1);
						last = null;
					}
					else if (p._type == DataSeriesView.PlotPoint.Type.PosInf)
					{
						DrawTriangle(output, brush, p._x, plotArea.Y, 5, 1);
						last = null;
					}
					else
					{
						Point current = new Point(p._x, p._y);
						output.FillRectangle(brush, current.X - 2, current.Y - 2, 4, 4);

						if (last.HasValue)
							output.DrawLine(new Pen(v.LineColor, 1), last.Value, current);
						last = current;
					}
				}
			}
		}

		private void DrawTriangle(Graphics output, Brush brush, int x, int y, int size, int up)
		{
			int y1 = y + up * size;
			int y2 = y - up * size;

			Point[] points = { new Point(x - size, y1), new Point(x + size, y1), new Point(x, y2) };
			output.FillPolygon(brush, points);
		}

		#endregion

		#region Graph Length

		private long TotalGraphLength
		{
			get
			{
				long len = 0;
				foreach (DataSeriesView v in _views)
				{
					if (!v.Hidden && v.Series.Length > len)
						len = v.Series.Length;
				}

				return len;
			}
		}

		private long GraphBegining
		{
			get
			{
				if (_views.Count < 1)
					return -1;

				long begining = long.MaxValue;
				foreach (DataSeriesView v in _views)
				{
					if (!v.Hidden && begining > v.Series.Begining)
						begining = v.Series.Begining;
				}

				return begining;
			}
		}

		#endregion

		#region Constructors

		public Graph(string name, long resolution, bool showTimeLabels)
		{
			_name = name;
			_resolution = resolution;
			_showTimeLabels = showTimeLabels;
		}

		public Graph(string name, bool showTimeLabels) : this(name, TimeSpan.TicksPerSecond, showTimeLabels) { }

		public Graph(string name) : this(name, TimeSpan.TicksPerSecond, true) { }

		#endregion

		#region XML

		private static string XML_ELEMENT_NAME_NAME = "name";

		private static string XML_ELEMENT_NAME_RESOLUTION = "resolution";

		private static string XML_ELEMENT_NAME_TIME_LABELS = "timelabels";

		private static string XML_ELEMENT_NAME_VIEWS = "views";

		private static string XML_ELEMENT_NAME_VIEW = "view";

		public Graph(XmlNode node, DataSeriesView.SeriesLookupDelegate seriesLookup)
		{
			if (node[XML_ELEMENT_NAME_NAME] != null)
				_name = node[XML_ELEMENT_NAME_NAME].InnerText;

			if (node[XML_ELEMENT_NAME_RESOLUTION] != null)
				_resolution = int.Parse(node[XML_ELEMENT_NAME_RESOLUTION].InnerText) * TimeSpan.TicksPerMillisecond;

			if (node[XML_ELEMENT_NAME_TIME_LABELS] != null)
				_showTimeLabels = bool.Parse(node[XML_ELEMENT_NAME_TIME_LABELS].InnerText);

			if (node[XML_ELEMENT_NAME_VIEWS] != null)
			{
				foreach (XmlNode n in node[XML_ELEMENT_NAME_VIEWS])
					AddViewHelper(new DataSeriesView(this, n, seriesLookup, new DataSeriesView.ViewGroupLookupDelegate(ViewGroupLookup)));
			}
		}

		private ViewGroup ViewGroupLookup(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				foreach (ViewGroup g in _groups)
				{
					if (g.Name == name)
						return g;
				}

				return CreateNewGroup(name, null);
			}

			return null;
		}

		public void Save(XmlDocument document, XmlNode node, DataSeriesView.SeriesIDLookupDelegate seriesIDLookup)
		{
			XmlNode n = null;

			n = document.CreateElement(XML_ELEMENT_NAME_NAME);
			n.InnerText = _name;
			node.AppendChild(n);

			n = document.CreateElement(XML_ELEMENT_NAME_RESOLUTION);
			n.InnerText = (_resolution / TimeSpan.TicksPerMillisecond).ToString();
			node.AppendChild(n);

			n = document.CreateElement(XML_ELEMENT_NAME_TIME_LABELS);
			n.InnerText = _showTimeLabels.ToString();
			node.AppendChild(n);

			n = document.CreateElement(XML_ELEMENT_NAME_VIEWS);

			foreach (DataSeriesView v in _views)
			{
				XmlNode vn = document.CreateElement(XML_ELEMENT_NAME_VIEW);
				v.Save(document, vn, seriesIDLookup);
				n.AppendChild(vn);
			}

			node.AppendChild(n);
		}

		#endregion

	}

	#endregion

}