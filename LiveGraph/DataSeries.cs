
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

namespace LiveGraph
{

	#region DataSeries

	public class DataSeries
	{

		#region Name

		private string _name = string.Empty;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaiseOnNameChanged();
			}
		}

		#endregion

		#region UnitName

		private string _unitName = string.Empty;

		public string UnitName
		{
			get { return _unitName; }
			set
			{
				_unitName = value;
				RaiseOnNameChanged();
			}
		}

		#endregion

		#region Depth

		private int _depth = 0;

		public int Depth
		{
			get { return _depth; }
			set { _depth = value; }
		}

		#endregion

		#region Events

		public delegate void NameChangedDelegate(DataSeries series);

		public event NameChangedDelegate OnNameChanged;

		private void RaiseOnNameChanged()
		{
			if (OnNameChanged != null)
				OnNameChanged(this);
		}

		public delegate void UnitNameChangedDelegate(DataSeries series);

		public event UnitNameChangedDelegate OnUnitNameChanged;

		private void RaiseOnUnitNameChanged()
		{
			if (OnUnitNameChanged != null)
				OnUnitNameChanged(this);
		}

		public delegate void AddDataPointDelegate(DataSeries series, long timeStamp);

		public event AddDataPointDelegate OnAddPoint;

		private void RaiseOnAddPoint(long timeStamp)
		{
			if (OnAddPoint != null)
				OnAddPoint(this, timeStamp);
		}

		public delegate void MinMaxChangedDelegate(DataSeries series);

		public event MinMaxChangedDelegate OnMinChanged;

		private void RaiseOnMinChanged()
		{
			if (OnMinChanged != null)
				OnMinChanged(this);
		}

		public event MinMaxChangedDelegate OnMaxChanged;

		private void RaiseOnMaxChanged()
		{
			if (OnMaxChanged != null)
				OnMaxChanged(this);
		}

		public delegate void GroupChangedDelegate(DataSeries series);

		public event GroupChangedDelegate OnGroupChanged;

		private void RaiseOnGroupChanged()
		{
			if (OnGroupChanged != null)
				OnGroupChanged(this);
		}

		#endregion

		#region DataPoints

		#region DataPoint

		public class DataPoint
		{

			private float _value;

			public float Value { get { return _value; } }

			private long _timeStamp;

			public long TimeStamp{ get { return _timeStamp; } }

			private bool _available;

			public bool Available { get { return _available; } }

			public DataPoint(float value, long timeStamp)
			{
				_value = value;
				_timeStamp = timeStamp;
				_available = true;
			}

			public DataPoint(long timeStamp)
			{
				_timeStamp = timeStamp;
				_available = false;
			}

		}

		#endregion

		private LinkedList<DataPoint> _dataPoints = new LinkedList<DataPoint>();

		public LinkedList<DataPoint> DataPoints { get { return _dataPoints; } }

		public void AddPoint(float value, long timeStamp) { AddPoint(new DataPoint(value, timeStamp)); }

		public void AddPoint(long timeStamp) { AddPoint(new DataPoint(timeStamp)); }

		private void AddPoint(DataPoint point)
		{
			if (_syncControl != null && _syncControl.InvokeRequired)
				_syncControl.Invoke(new AddPointDelegate(AddPoint));

			bool completeUpdate = false;
			if (Depth > 0 && _dataPoints.Count >= Depth)
			{
				completeUpdate = _dataPoints.First.Value.Value == _min || _dataPoints.First.Value.Value == _max;
				_dataPoints.RemoveFirst();
			}

			_dataPoints.AddLast(point);

			if (completeUpdate)
				Update();
			else if (point.Available)
				Update(point.Value);

			RaiseOnAddPoint(point.TimeStamp);
		}

		#endregion

		#region MinMax

		#region Min

		private float _min;

		public float Min { get { return _min; } }

		#endregion

		#region Max

		private float _max;

		public float Max { get { return _max; } }

		#endregion

		#region Update

		private void Update()
		{
			if (_dataPoints.Count > 0)
				_min = _max = _dataPoints.First.Value.Value;

			foreach (DataPoint point in _dataPoints)
			{
				if (point.Value < _min)
					_min = point.Value;
				if (point.Value > _max)
					_max = point.Value;
			}

			RaiseOnMinChanged();
			RaiseOnMaxChanged();
		}

		private void Update(float point)
		{
			if (_dataPoints.Count == 1 || point < _min)
			{
				_min = point;
				RaiseOnMinChanged();
			}

			if (_dataPoints.Count == 1 || point > _max)
			{
				_max = point;
				RaiseOnMaxChanged();
			}
		}

		#endregion

		#endregion

		public long Length
		{
			get { return _dataPoints.Count > 0 ? _dataPoints.Last.Value.TimeStamp - _dataPoints.First.Value.TimeStamp : 0; }
		}

		public long Begining
		{
			get { return _dataPoints.Count > 0 ? _dataPoints.First.Value.TimeStamp : -1; }
		}

		#region WinForms Synchronization

		private Control _syncControl;

		private delegate void AddPointDelegate(DataPoint point);

		#endregion

		#region Constructors

		public DataSeries(Control syncControl, string name, string unitName, int depth)
		{
			_name = name;
			_unitName = unitName;
			_depth = depth;

			_syncControl = syncControl;
		}

		public DataSeries(Control syncControl, string name, string unitName) : this(syncControl, name, unitName, 0) { }

		public DataSeries(string name, string unitName, int depth) : this(null, name, unitName, depth) { }

		public DataSeries(string name, string unitName) : this(null, name, unitName, 0) { }

		#endregion

	}

	#endregion

}