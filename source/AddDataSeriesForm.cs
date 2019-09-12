using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetUtils;

namespace NetPinger
{
	public partial class AddDataSeriesForm : Form
	{
		private Dictionary<HostPinger, HostDataSeries>.ValueCollection _series = null;

		public Dictionary<HostPinger, HostDataSeries>.ValueCollection Series
		{
			get { return _series; }
			set
			{
				_series = value;

				_cmbHost.Items.Clear();
				_cmbSeries.Items.Clear();

				if (_series != null)
				{
					foreach (HostDataSeries s in _series)
						_cmbHost.Items.Add(s);
				}

				if (_cmbHost.Items.Count > 0)
					_cmbHost.SelectedIndex = 0;
			}
		}

		public LiveGraph.DataSeries SelectedSeries
		{
			get { return _cmbSeries.SelectedItem != null ? ((DataSeriesNameParser)_cmbSeries.SelectedItem).Series : null; }
		}

		public Color Color { get { return _pnlColor.BackColor; } }

		public AddDataSeriesForm()
		{
			InitializeComponent();
		}

		private void _cmbHost_SelectedIndexChanged(object sender, EventArgs e)
		{
			_cmbSeries.Items.Clear();

			if (_cmbHost.SelectedItem != null)
			{
				HostDataSeries host = (HostDataSeries)_cmbHost.SelectedItem;
				foreach (DataSeriesNameParser s in host.SeriesNames)
					_cmbSeries.Items.Add(s);
			}

			if (_cmbSeries.Items.Count > 0)
				_cmbSeries.SelectedIndex = 0;
		}

		private void _btnChooseColor_Click(object sender, EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			dlg.Color = _pnlColor.BackColor;

			if (dlg.ShowDialog(this) == DialogResult.OK)
				_pnlColor.BackColor = dlg.Color;
		}

	}
}
