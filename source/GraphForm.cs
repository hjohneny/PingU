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
	public partial class GraphForm : Form
	{

		private Dictionary<HostPinger, HostDataSeries>.ValueCollection _series = null;

		public Dictionary<HostPinger, HostDataSeries>.ValueCollection Series
		{
			get { return _series; }
			set { _series = value; }
		}

		private GraphManager _graphManager;

		public GraphForm(GraphManager graphManager)
		{
			_graphManager = graphManager;

			InitializeComponent();

			if (_graphManager.IsError)
			{
				_cbGraph.Text = "An error occured while opening settings file!";
				_btnLoad.Enabled = _btnSave.Enabled = _btnRemove.Enabled = _cbGraph.Enabled = false;
			}
			else
			{
				foreach (string g in _graphManager.Graphs)
					_cbGraph.Items.Add(g);

				_graphManager.OnGraphCollectionUpdate += new GraphManager.GraphCollectionUpdate(_graphManager_OnGraphCollectionUpdate);
			}
		}

		void _graphManager_OnGraphCollectionUpdate()
		{
			_cbGraph.Items.Clear();

			foreach (string g in _graphManager.Graphs)
				_cbGraph.Items.Add(g);
		}

		private void _gcGraphs_OnAddView(LiveGraph.GraphControl control, LiveGraph.Graph graph)
		{
			AddDataSeriesForm dlg = new AddDataSeriesForm();
			dlg.Series = _series;

			if (dlg.ShowDialog(this) == DialogResult.OK)
				graph.AddView(dlg.SelectedSeries, dlg.Color);
		}

		private void _btnLoad_Click(object sender, EventArgs e)
		{
			_graphManager.LoadGraphCollection(_cbGraph.Text, _gcGraphs);
		}

		private void _btnSave_Click(object sender, EventArgs e)
		{
			_graphManager.AddGraphCollection(_cbGraph.Text, _gcGraphs);
		}

		private void _btnRemove_Click(object sender, EventArgs e)
		{
			_graphManager.RemoveGraphCollection(_cbGraph.Text);
		}

	}
}
