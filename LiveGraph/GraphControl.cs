
/*
 * 
 * Code by Mladen Jankovic.
 * 
 * contact: kataklinger@gmail[dot]com
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml;

namespace LiveGraph
{

	public partial class GraphControl : UserControl
	{

		#region GraphPanel

		private class GraphPanel : Panel
		{
			public GraphPanel() : base() { SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true); }
		}

		#endregion

		#region Constructors

		public GraphControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Graphs

		private List<Graph> _graphs = new List<Graph>();

		public Graph AddGraph(string name) { return AddGraph(name, TimeSpan.TicksPerSecond, true); }

		public Graph AddGraph(string name, bool showTimeLables) { return AddGraph(name, TimeSpan.TicksPerSecond, showTimeLables); }

		public Graph AddGraph(string name, long resolution, bool showTimeLables)
		{
			Graph graph = new Graph(name, resolution, showTimeLables);
			AddGraph(graph);

			return graph;
		}

		private void AddGraph(Graph graph)
		{
			_graphs.Add(graph);

			GraphControls graphControls = new GraphControls(this, graph);
			_graphControls.Add(graph, graphControls);
			graphControls.Attach();

			foreach (DataSeriesView v in graph.Views)
				graphControls.AddViewLabel(v);

			graph.OnAddPoint += new Graph.AddPointDelegate(graph_OnAddPoint);
			graph.OnSeriesChanged += new Graph.SeriesChangedDelegate(graph_OnSeriesChanged);

			graph.OnAddView += new Graph.AddViewDelegate(graph_OnAddView);
			graph.OnRemoveView += new Graph.RemoveViewDelegate(graph_OnRemoveView);
			graph.OnViewChanged += new Graph.ViewChangeDelegate(graph_OnViewChanged);

			graph.OnResolutionChanged += new Graph.ResolutionChangedDelegate(graph_OnGraphChange);
			graph.OnShowTimeLabels += new Graph.ShowTimeLabelsDelegate(graph_OnGraphChange);

			CalculateSizeAndPositions();
		}

		public void RemoveGraph(Graph graph)
		{
			RemoveGraphHelper(graph);

			_graphs.Remove(graph);
			CalculateSizeAndPositions();
			_graphPanel.Invalidate();
		}

		public void RemoveAllGraphs()
		{
			foreach (Graph g in _graphs)
				RemoveGraphHelper(g);

			_graphs.Clear();
			CalculateSizeAndPositions();
			_graphPanel.Invalidate();
		}

		public void RemoveGraphHelper(Graph graph)
		{
			GraphControls controls = _graphControls[graph];
			controls.Detach();

			graph.OnAddPoint -= graph_OnAddPoint;

			graph.OnAddView -= graph_OnAddView;
			graph.OnRemoveView -= graph_OnRemoveView;

			graph.OnResolutionChanged -= graph_OnGraphChange;
			graph.OnShowTimeLabels -= graph_OnGraphChange;

			_graphControls.Remove(graph);
		}

		#region OnAddView

		public delegate void AddViewDelegate(GraphControl control, Graph graph);

		public event AddViewDelegate OnAddView;

		private void RaiseOnAddView(Graph graph)
		{
			if (OnAddView != null)
				OnAddView(this, graph);
		}

		#endregion

		Dictionary<Graph, GraphControls> _graphControls = new Dictionary<Graph, GraphControls>();

		#region GraphControls

		private class GraphControls
		{
			#region Members

			GraphControl _control;
			FlowLayoutPanel _graphControlsPanel;
			Graph _graph;

			#endregion

			#region Contructors

			public GraphControls(GraphControl control, Graph graph)
			{
				_control = control;
				_graph = graph;

				_graphControlsPanel = new FlowLayoutPanel();
				_graphControlsPanel.FlowDirection = FlowDirection.LeftToRight;
				_graphControlsPanel.Dock = DockStyle.Fill;
				_graphControlsPanel.AutoSize = true;

				FillGraphControlsPanel();
			}

			#endregion

			#region Mange Controls

			public void Attach()
			{
				_control._seriesLabelsPanel.Controls.Add(_graphControlsPanel);
			}

			public void Detach()
			{
				_control._seriesLabelsPanel.Controls.Remove(_graphControlsPanel);

				foreach (Control c in _graphControlsPanel.Controls)
				{
					if (c.Tag is DataSeriesView)
						c.Click -= viewLabel_Click;
					else if (c is LinkLabel)
						c.Click -= graphLabel_Click;
				}
			}

			public void MoveUp()
			{
				int index = _control._seriesLabelsPanel.Controls.IndexOf(_graphControlsPanel) - 1;
				if (index > 0)
					_control._seriesLabelsPanel.Controls.SetChildIndex(_graphControlsPanel, index);
			}

			public void MoveDown()
			{
				int index = _control._seriesLabelsPanel.Controls.IndexOf(_graphControlsPanel) + 1;
				if (index < _control._seriesLabelsPanel.Controls.Count)
					_control._seriesLabelsPanel.Controls.SetChildIndex(_graphControlsPanel, index);
			}

			#endregion

			#region Manage View Labels

			public void UpdateSeriesNames(DataSeries series)
			{
				foreach (Control c in _graphControlsPanel.Controls)
				{
					if (c is LinkLabel && c.Tag is DataSeriesView)
					{
						if (series == ((DataSeriesView)c.Tag).Series)
							((LinkLabel)c).Text = "\u2588\u2588 " + series.Name;
					}
				}
			}

			public LinkLabel AddViewLabel(DataSeriesView view)
			{
				LinkLabel label = CreateLinkLabel("\u2588\u2588 " + view.Series.Name, view.LineColor);
				label.Tag = view;
				label.Click += new EventHandler(viewLabel_Click);

				_graphControlsPanel.Controls.Add(label);

				return label;
			}

			public void RemoveViewLabel(DataSeriesView view)
			{
				foreach (Control c in _graphControlsPanel.Controls)
				{
					if (c.Tag == view)
					{
						c.Click -= viewLabel_Click;
						_graphControlsPanel.Controls.Remove(c);
					}
				}
			}

			private void FillViewLabels()
			{
				foreach (DataSeriesView v in _graph.Views)
					AddViewLabel(v);
			}

			#endregion

			#region View Actions Handlers

			void viewLabel_Click(object sender, EventArgs e)
			{
				Control c = (Control)sender;
				DataSeriesView v = (DataSeriesView)c.Tag;

				ContextMenu menu = new ContextMenu();
				menu.Tag = c;

				MenuItem[] groups = new MenuItem[v.Container.Groups.Count + 2];
				string verb = v.Group == null ? "Add" : "Move";

				int index = 0;
				foreach (ViewGroup g in v.Container.Groups)
				{
					if (g != v.Group)
					{
						MenuItem item = new MenuItem(verb + " To " + g.Name, new EventHandler(series_OnAddToGroup));
						item.Tag = g;

						groups[index++] = item;
					}
				}

				groups[index++] = new MenuItem("-");
				groups[index++] = new MenuItem(verb + " To New Group...", new EventHandler(series_OnCreateGroup));

				if (v.Group != null)
					groups[index++] = new MenuItem("Remove From " + v.Group.Name, new EventHandler(series_OnRemoveFromGroup));

				menu.MenuItems.Add(new MenuItem("Grouping", groups));
				menu.MenuItems.Add(new MenuItem("Change Color...", new EventHandler(view_OnChangeColor)));

				MenuItem hidden = new MenuItem("Hidden", new EventHandler(view_OnHide));
				hidden.Checked = v.Hidden;
				menu.MenuItems.Add(hidden);

				menu.MenuItems.Add(new MenuItem("Remove", new EventHandler(view_OnRemove)));

				menu.Show(c, new Point(0, c.Size.Height));
			}

			private void series_OnAddToGroup(object sender, EventArgs e)
			{
				LinkLabel label = (LinkLabel)((MenuItem)((MenuItem)sender).Parent).Parent.Tag;
				((DataSeriesView)label.Tag).Group = (ViewGroup)((MenuItem)sender).Tag;
			}

			private void series_OnCreateGroup(object sender, EventArgs e)
			{
				LinkLabel label = (LinkLabel)((MenuItem)((MenuItem)sender).Parent).Parent.Tag;
				DataSeriesView view = (DataSeriesView)label.Tag;

				CreateSeriesGroupForm dlg = new CreateSeriesGroupForm();
				if (dlg.ShowDialog() == DialogResult.OK)
					view.Container.CreateNewGroup(dlg.GroupName, view);
			}

			private void series_OnRemoveFromGroup(object sender, EventArgs e)
			{
				LinkLabel label = (LinkLabel)((MenuItem)((MenuItem)sender).Parent).Parent.Tag;
				((DataSeriesView)label.Tag).Group = null;
			}

			private void view_OnChangeColor(object sender, EventArgs e)
			{
				LinkLabel label = (LinkLabel)((MenuItem)sender).Parent.Tag;
				DataSeriesView view = (DataSeriesView)label.Tag;

				ColorDialog dlg = new ColorDialog();

				dlg.Color = view.LineColor;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					view.LineColor = dlg.Color;
					SetLinkLabelColor(label, dlg.Color);
				}
			}

			private void view_OnRemove(object sender, EventArgs e)
			{
				LinkLabel label = (LinkLabel)((MenuItem)sender).Parent.Tag;
				DataSeriesView view = (DataSeriesView)label.Tag;

				_graph.RemoveView(view.Series);
			}

			private void view_OnHide(object sender, EventArgs e)
			{
				LinkLabel label = (LinkLabel)((MenuItem)sender).Parent.Tag;
				DataSeriesView view = (DataSeriesView)label.Tag;

				view.Hidden = !((MenuItem)sender).Checked;
			}

			#endregion

			#region Graph Controls Handlers

			private enum GraphControlActions
			{
				ChangeName,
				AddView,
				ToggleTimeLabels,
				MoveUp,
				MoveDown,
				Remove
			};

			void graphLabel_Click(object sender, EventArgs e)
			{
				Control c = (Control)sender;
				GraphControlActions a = (GraphControlActions)c.Tag;

				switch (a)
				{
					case GraphControlActions.ChangeName:
						AddGraphDlg dlg = new AddGraphDlg();
						dlg.Text = "Change Graph Settings";
						dlg.GraphName = _graph.Name;
						dlg.Resolution = _graph.Resolution;
						dlg.ShowTimeLabels = _graph.ShowTimeLabels;

						if (dlg.ShowDialog() == DialogResult.OK)
						{
							_graph.Name = dlg.GraphName;
							_graph.Resolution = dlg.Resolution * TimeSpan.TicksPerMillisecond;
							_graph.ShowTimeLabels = dlg.ShowTimeLabels;

							((LinkLabel)c).Text = dlg.GraphName;
						}

						break;

					case GraphControlActions.AddView:
						_control.RaiseOnAddView(_graph);
						break;

					case GraphControlActions.ToggleTimeLabels:
						_graph.ShowTimeLabels = !_graph.ShowTimeLabels;
						break;

					case GraphControlActions.MoveUp:
						_control.MoveGraphUp(_graph);
						break;

					case GraphControlActions.MoveDown:
						_control.MoveGraphDown(_graph);
						break;

					case GraphControlActions.Remove:
						if (MessageBox.Show(_control._seriesLabelsPanel.Parent, "Are you sure that you want to remove this graph?", "Remove Graph?",
							MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							_control.RemoveGraph(_graph);
						break;
				}
			}

			#endregion

			private void SetLinkLabelColor(LinkLabel label, Color color)
			{
				label.VisitedLinkColor = label.ActiveLinkColor = label.LinkColor = color;
			}

			#region Add Graph Controls Methods

			private void FillGraphControlsPanel()
			{
				AddGraphControl(_graph.Name, GraphControlActions.ChangeName);

				AddGraphLabel("(");
				AddGraphControl("\u253c", GraphControlActions.AddView);
				AddGraphControl("\u2502", GraphControlActions.ToggleTimeLabels);
				AddGraphControl("\u25b2", GraphControlActions.MoveUp);
				AddGraphControl("\u25bc", GraphControlActions.MoveDown);
				AddGraphControl("\u2500", GraphControlActions.Remove);
				AddGraphLabel(")");
			}

			private void AddGraphControl(string text, GraphControlActions action)
			{
				LinkLabel label = CreateLinkLabel(text, Color.Black);
				label.Tag = action;
				label.Click += new EventHandler(graphLabel_Click);

				_graphControlsPanel.Controls.Add(label);
			}

			private void AddGraphLabel(string text)
			{
				Label label = CreateLabel(text, Color.Black);
				_graphControlsPanel.Controls.Add(label);
			}

			#endregion

			#region Create Label Methods

			private LinkLabel CreateLinkLabel(string text, Color color)
			{
				LinkLabel label = new LinkLabel();
				label.AutoSize = true;
				label.Text = text;

				label.LinkBehavior = LinkBehavior.HoverUnderline;
				SetLinkLabelColor(label, color);

				return label;
			}

			private Label CreateLabel(string text, Color color)
			{
				Label label = new Label();
				label.AutoSize = true;
				label.Text = text;
				label.ForeColor = color;

				return label;
			}

			#endregion

		}

		#endregion

		#endregion

		#region Graph Positioning

		public void MoveGraphUp(Graph graph)
		{
			int index = _graphs.IndexOf(graph);

			if (index > 0)
			{
				_graphControls[graph].MoveUp();

				_graphs.RemoveAt(index);
				_graphs.Insert(index - 1, graph);

				CalculateSizeAndPositions();
			}
		}

		public void MoveGraphDown(Graph graph)
		{
			int index = _graphs.IndexOf(graph);

			if (index < _graphs.Count - 1)
			{
				_graphControls[graph].MoveDown();

				_graphs.RemoveAt(index);
				_graphs.Insert(index + 1, graph);

				CalculateSizeAndPositions();
			}
		}

		private void CalculateSizeAndPositions()
		{
			if (_graphs.Count <= 0)
				return;

			int height = _graphPanel.Size.Height / _graphs.Count;

			Point pos = new Point(0, 0);
			foreach (Graph g in _graphs)
			{
				g.Position = pos;
				g.Size = new Size(_graphPanel.Width, height);

				pos.Y += height;
			}

			_graphPanel.Invalidate();
		}

		#endregion

		private void _addGraphLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			AddGraphDlg dlg = new AddGraphDlg();
			if (dlg.ShowDialog() == DialogResult.OK)
				AddGraph(dlg.GraphName, dlg.Resolution * TimeSpan.TicksPerMillisecond, dlg.ShowTimeLabels);
		}

		#region Graph Event Handlers

		void graph_OnAddPoint(Graph graph, DataSeries series) { _graphPanel.Invalidate(); }

		void graph_OnSeriesChanged(Graph graph, DataSeries series)
		{
			_graphControls[graph].UpdateSeriesNames(series);
			_graphPanel.Invalidate();
		}

		void graph_OnAddView(Graph graph, DataSeriesView view)
		{
			_graphControls[graph].AddViewLabel(view);
			_graphPanel.Invalidate();
		}

		void graph_OnRemoveView(Graph graph, DataSeriesView view)
		{
			_graphControls[graph].RemoveViewLabel(view);
			_graphPanel.Invalidate();
		}

		void graph_OnViewChanged(Graph graph, DataSeriesView view) { _graphPanel.Invalidate(); }

		void graph_OnGraphChange(Graph graph) { _graphPanel.Invalidate(); }

		#endregion

		#region GUI Event Handlers

		private void graphPanel_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

			foreach (Graph g in _graphs)
				g.Draw(e.Graphics);
		}

		private void graphPanel_Resize(object sender, EventArgs e) { CalculateSizeAndPositions(); }

		#region Mouse Event Handler

		#region Resolution Settings

		private NumericUpDown _currentResolution = null;

		void _currentResolution_ValueChanged(object sender, EventArgs e)
		{
			((Graph)_currentResolution.Tag).Resolution = (long)_currentResolution.Value * TimeSpan.TicksPerMillisecond;
		}

		private void _graphPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (_currentResolution != null)
				{
					_graphPanel.Controls.Remove(_currentResolution);
					_currentResolution.ValueChanged -= _currentResolution_ValueChanged;

					_currentResolution = null;
				}

				foreach (Graph g in _graphs)
				{
					Rectangle magnifyIcon = g.MagnifyIconRect;
					if (magnifyIcon.Contains(e.Location))
					{
						_currentResolution = new NumericUpDown();
						_currentResolution.Tag = g;

						_currentResolution.Minimum = 1;
						_currentResolution.Maximum = TimeSpan.TicksPerHour / TimeSpan.TicksPerMillisecond;

						_currentResolution.Value = g.Resolution / TimeSpan.TicksPerMillisecond;

						_currentResolution.Size = new Size(75, 18);
						_currentResolution.Location = new Point(magnifyIcon.X - _currentResolution.Size.Width - 1, magnifyIcon.Y - 2);

						_currentResolution.ValueChanged += new EventHandler(_currentResolution_ValueChanged);

						_graphPanel.Controls.Add(_currentResolution);
					}
				}
			}
		}

		#endregion

		#region Graph Scrolling

		private Graph _scrollGraph = null;
		private Point _scrollGrab;

		private void _graphPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				foreach (Graph g in _graphs)
				{
					Rectangle scrollBox = g.ScrollBox;

					if (scrollBox.Contains(e.Location))
					{
						_scrollGraph = g;
						_scrollGrab = new Point(e.X - scrollBox.X, e.Y - scrollBox.Y);
					}
				}
			}
		}

		private void _graphPanel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				_scrollGraph = null;
		}

		private bool _activateTooltip = true;

		private void _graphPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (_scrollGraph != null)
			{
				Rectangle frame = _scrollGraph.ScrollFrame;
				int pos = e.X - _scrollGrab.X;

				if (pos >= frame.Left && (pos + _scrollGraph.ScrollBox.Width) <= frame.Right)
				{
					_scrollGraph.Scroll(pos);
					_graphPanel.Invalidate();
				}
			}

			foreach (Graph g in _graphs)
			{
				foreach (DataSeriesView v in g.Views)
				{
					foreach (DataSeriesView.PlotPoint p in v.CurrentPoints)
					{
						Rectangle r = new Rectangle(p._x - 2, p._y - 2, 4, 4);
						if (r.Contains(e.Location))
						{
							if (_activateTooltip)
							{
								_activateTooltip = false;
								_tipPointValue.Show(p._realValue.ToString("F02") + " " + v.Series.UnitName, this, e.X + 16, e.Y + 16);
							}
							return;
						}
					}
				}
			}

			if (!_activateTooltip)
			{
				_tipPointValue.Hide(this);
				_activateTooltip = true;
			}
		}

		#endregion

		#endregion

		#endregion

		private static string XML_ELEMENT_NAME_GRAPH = "graph";

		public void LoadFromXml(XmlNode node, DataSeriesView.SeriesLookupDelegate seriesLookup)
		{
			RemoveAllGraphs();

			foreach (XmlNode n in node.ChildNodes)
				AddGraph(new Graph(n, seriesLookup));
		}

		public void SaveToXml(XmlDocument document, XmlNode node, DataSeriesView.SeriesIDLookupDelegate seriesIDLookup)
		{
			foreach (Graph graph in _graphs)
			{
				XmlNode graphNode = document.CreateElement(XML_ELEMENT_NAME_GRAPH);

				graph.Save(document, graphNode, seriesIDLookup);
				node.AppendChild(graphNode);

			}
		}

	}

}
