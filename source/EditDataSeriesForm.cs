using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetPinger
{
	public partial class EditDataSeriesForm : Form
	{
		HostDataSeries _series = null;

		public HostDataSeries Series
		{
			set
			{
				_series = value;
				FillList();
			}
		}

		private void FillList()
		{
			_cmbSeries.Items.Clear();

			foreach (DataSeriesNameParser s in _series.SeriesNames)
				_cmbSeries.Items.Add(s);

			if (_cmbSeries.Items.Count > 0)
				_cmbSeries.SelectedIndex = 0;
		}

		public EditDataSeriesForm()
		{
			InitializeComponent();

			_spnDepth.Maximum = int.MaxValue;
		}

		private void _cmbHost_SelectedIndexChanged(object sender, EventArgs e) { FillList(); }

		private void _cmbSeries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_cmbSeries.SelectedItem != null)
			{
				DataSeriesNameParser item = ((DataSeriesNameParser)_cmbSeries.SelectedItem);

				_txtName.Text = item.SeriesNamePattern;
				_spnDepth.Value = item.Series.Depth;
			}
		}

		private void _btnSet_Click(object sender, EventArgs e)
		{
			if (_cmbSeries.SelectedItem != null)
			{
				DataSeriesNameParser item = ((DataSeriesNameParser)_cmbSeries.SelectedItem);

				item.SeriesNamePattern = _txtName.Text;
				item.Series.Depth = (int)_spnDepth.Value;

				int index = _cmbSeries.SelectedIndex;
				FillList();
				_cmbSeries.SelectedIndex = index;
			}
		}
	}
}
