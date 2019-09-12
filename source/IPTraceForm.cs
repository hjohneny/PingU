using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetUtils;
using System.Net;
using System.Net.Sockets;

namespace NetPinger
{
	public partial class IPTraceForm : Form
	{

		private const int FIXED_COLUMNS_COUNT = 3;
		private IPRouteTracer _tracer;

		public string Target
		{
			get { return _tbTarget.Text; }
			set { _tbTarget.Text = value; }
		}

		public IPTraceForm()
		{
			InitializeComponent();

			_tracer = new IPRouteTracer(null, (int)_spnTimeout.Value, (int)_spnRetries.Value, (int)_spnPingsPerHop.Value, (int)_spnBufferSize.Value);

			_tracer.OnTraceStarted += new IPRouteTracer.StartTraceDelegate(_tracer_OnTraceStart);
			_tracer.OnTraceCompleted += new IPRouteTracer.TraceCompletedDelegate(_tracer_OnTraceCompleted);
			_tracer.OnHopSuccess += new IPRouteTracer.HopDelegate(_tracer_OnHopSuccess);
			_tracer.OnHopPing += new IPRouteTracer.HopDelegate(_tracer_OnHopPing);
			_tracer.OnHopFail += new IPRouteTracer.HopFailDelegate(_tracer_OnHopFail);

			AddColumn();
		}

		private ListViewItem FindListViewItem(IPRouteHop hop)
		{
			foreach (ListViewItem item in _lvRouteList.Items)
			{
				if (item.Tag == hop)
					return item;
			}

			return null;
		}

		private void EnableSettings(bool enable)
		{
			_tbTarget.Enabled = _spnTimeout.Enabled = _spnRetries.Enabled = _spnPingsPerHop.Enabled = _spnBufferSize.Enabled = enable;

			_btnTrace.Text = enable ? "&Trace" : "&Stop";
		}

		private void AddColumn()
		{
			ColumnHeader header = new ColumnHeader();
			header.Text = (_lvRouteList.Columns.Count + 1 - FIXED_COLUMNS_COUNT).ToString();
			header.DisplayIndex = _lvRouteList.Columns.Count;
			header.Width = 55;
			header.TextAlign = HorizontalAlignment.Right;

			_lvRouteList.Columns.Add(header);
		}

		private void _tracer_OnTraceStart(IPRouteTracer tracer)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new IPRouteTracer.StartTraceDelegate(_tracer_OnTraceStart), tracer);
				return;
			}

			foreach (ListViewItem item in _lvRouteList.Items)
				((IPRouteHop)item.Tag).OnHostNameAvailable -= hop_OnHostNameAvailable;

			_lvRouteList.Items.Clear();
			EnableSettings(false);
			_btnAddHost.Enabled = false;
		}

		void _tracer_OnTraceCompleted(IPRouteTracer tracer, IPRouteTracer.TraceStatus status)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new IPRouteTracer.TraceCompletedDelegate(_tracer_OnTraceCompleted), tracer, status);
				return;
			}

			EnableSettings(true);

			_lStatus.Text = "Status: Trace to [" + tracer.Target + "] " + IPRouteTracer.TraceStatusNames[(int)status] + "!";
		}

		private void _tracer_OnHopSuccess(IPRouteTracer tracer, IPRouteHop hop)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new IPRouteTracer.HopDelegate(_tracer_OnHopSuccess), tracer, hop);
				return;
			}

			ListViewItem item = new ListViewItem(hop.Hop.ToString());
			item.Tag = hop;

			item.SubItems.Add(hop.Address.ToString());
			item.SubItems.Add("");

			_lvRouteList.Items.Add(item);

			hop.OnHostNameAvailable += new IPRouteHop.HostNameAvailableDelegate(hop_OnHostNameAvailable);
			item.SubItems[2].Text = hop.HostName;

			_lStatus.Text = "Status: Hop " + hop.Hop + " [" + hop.Address + "] successful!";
		}

		void hop_OnHostNameAvailable(IPRouteHop hop)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new IPRouteHop.HostNameAvailableDelegate(hop_OnHostNameAvailable), hop);
				return;
			}

			ListViewItem item = FindListViewItem(hop);
			if (item != null)
				item.SubItems[2].Text = hop.HostName;
		}

		private void _tracer_OnHopPing(IPRouteTracer tracer, IPRouteHop hop)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new IPRouteTracer.HopDelegate(_tracer_OnHopPing), tracer, hop);
				return;
			}

			ListViewItem item = FindListViewItem(hop);

			long respTime = hop.ResponseTimes[hop.PingsCompleted - 1];
			item.SubItems.Add(respTime < 0 ? "*" : respTime.ToString() + " ms");
		}

		void _tracer_OnHopFail(IPRouteTracer tracer, int hop, int retry, IPAddress address, System.Net.NetworkInformation.IPStatus status)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new IPRouteTracer.HopFailDelegate(_tracer_OnHopFail), tracer, hop, retry, address, status);
				return;
			}

			_lStatus.Text = "Status: Hop " + hop + " failed! Response from [" + address + "]: \"" + status.ToString() + "\". Retry: " + retry + ".";
		}

		private void _btnTrace_Click(object sender, EventArgs e)
		{
			if (_tracer.Active)
			{
				_tracer.Stop(false);
				return;
			}

			try
			{
				IPHostEntry entry = Dns.GetHostEntry(_tbTarget.Text);

				if (entry.AddressList.Length > 1)
				{
					ChooseIPForm dlg = new ChooseIPForm();
					if (dlg.ShowDialog(this, entry.AddressList) == DialogResult.OK)
						_tracer.Target = dlg.SelectedIPAddress;
				}
				else
					_tracer.Target = entry.AddressList[0];

				_tracer.Start();
			}
			catch (SocketException)
			{
				MessageBox.Show(this, "Cannot resolve host name!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch
			{
				MessageBox.Show(this, "Cannot parse host name or IP address!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void _spnTimeout_ValueChanged(object sender, EventArgs e) { _tracer.Timeout = (int)_spnTimeout.Value; }

		private void _spnBufferSize_ValueChanged(object sender, EventArgs e) { _tracer.PingBufferSize = (int)_spnBufferSize.Value; }

		private void _spnPingsPerHop_ValueChanged(object sender, EventArgs e)
		{
			_tracer.PingsPerHop = (int)_spnPingsPerHop.Value;

			int columns = _tracer.PingsPerHop + FIXED_COLUMNS_COUNT;

			for (int i = _lvRouteList.Columns.Count - 1; i >= columns; i--)
				_lvRouteList.Columns.RemoveAt(i);

			for (int i = _lvRouteList.Columns.Count; i < columns; i++)
				AddColumn();
		}

		private void _spnRetries_ValueChanged(object sender, EventArgs e) { _tracer.HopRetries = (int)_spnRetries.Value; }

		private void _btnAddHost_Click(object sender, EventArgs e)
		{
			IPRouteHop host = (IPRouteHop)_lvRouteList.SelectedItems[0].Tag;
			HostPinger pinger = new HostPinger(host.HostName, host.Address);

			((PingForm)Owner).AddNewHost(pinger);
		}

		private void _lvRouteList_SelectedIndexChanged(object sender, EventArgs e)
		{
			_btnAddHost.Enabled = _lvRouteList.SelectedItems.Count != 0;
		}

		private void _lvRouteList_DoubleClick(object sender, EventArgs e) { _btnAddHost_Click(sender, e); }

		private void IPTraceForm_FormClosing(object sender, FormClosingEventArgs e) { _tracer.Stop(true); }

        private void IPTraceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
