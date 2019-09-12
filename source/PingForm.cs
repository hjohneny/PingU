/*
 * 
 * 
 * contact: hjohneny99@gmail.com
 * 
 * 
 *  - The names of contributors may not be used to endorse or promote products
 *    derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;
using System.Threading;
using NetUtils;

namespace NetPinger
{
	public partial class PingForm : Form
	{

		#region Private Attributes

		private Hashtable _table = new Hashtable();

		private List<HostPinger> _hosts = new List<HostPinger>();

		private Dictionary<HostPinger, HostDataSeries> _dataSeries = new Dictionary<HostPinger, HostDataSeries>();

		//private GraphManager _graphManager = new GraphManager();

		private HostPinger _selectedPinger = null;

		private bool _hostListChanged = false;

		#endregion

		#region Constructor

		public PingForm()
		{
			InitializeComponent();

			LoadSettings();
		}

		private void PingForm_Load(object sender, EventArgs e)
		{
			try
			{
				XmlDocument config = new XmlDocument();
				config.Load(Program.GetAppFilePath("hosts.cfg"));
				XmlNode hostsNode = config["pinger"];
				foreach (XmlNode node in hostsNode.ChildNodes)
					ThreadPool.QueueUserWorkItem(new WaitCallback(AddLoadedHost), node);

				WindowState = FormWindowState.Normal;
				Visible = false;
			}
			catch
			{
				if (Options.Instance.ShowErrorMessages)
					MessageBox.Show("Error ocurred while loading the config file.", "Error!",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddLoadedHost(object hostNode)
		{
			try
			{
				HostPinger hp = new HostPinger((XmlNode)hostNode);
				hp.Logger = DefaultLogger.Instance;
				hp.OnPing += new OnPingDelegate(OnHostPing);
				hp.OnStopPinging += new OnHostPingerCommandDelegate(hp_OnStopPinging);
				hp.OnStartPinging += new OnHostPingerCommandDelegate(hp_OnStartPinging);

				HostDataSeries series = new HostDataSeries(this, hp);
				series.LoadSettings((XmlNode)hostNode);

				lock (_hosts)
				{
					_hosts.Add(hp);
					_dataSeries.Add(hp, series);
				//	_graphManager.RegisterSeries(series);
				}

				if (Options.Instance.StartPingingOnProgramStart)
					hp.Start();
			}
			catch (Exception ex)
			{
				if (Options.Instance.ShowErrorMessages)
					MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Settings

		private void LoadSettings()
		{
			if (!Options.Instance.UseDefaultColumnsWidths)
			{
				foreach (ColumnHeader col in _lvHosts.Columns)
					col.Width = Options.Instance.GetColumnWidth(col.Index);
			}

			if (!Options.Instance.UseDefaultPosition)
				Location = new Point(Options.Instance.WindowPositionX, Options.Instance.WindowPositionY);

			if (!Options.Instance.UseDefaultSize)
			{
				Width = Options.Instance.WindowsWidth;
				Height = Options.Instance.WindowsHeight;
			}
		}

		private void SaveSettings()
		{
			foreach (ColumnHeader col in _lvHosts.Columns)
				Options.Instance.SetColumnWidth(col.Index, col.Width);

			Options.Instance.WindowPositionX = Location.X;
			Options.Instance.WindowPositionY = Location.Y;

			if (WindowState == FormWindowState.Normal)
			{
				Options.Instance.WindowsWidth = Width;
				Options.Instance.WindowsHeight = Height;
			}
		}

		#endregion

		#region Notification Icon

		public static void NotifyMessage(HostPinger host, string message)
		{
			if (Application.OpenForms.Count > 0)
			{
				PingForm frm = ((PingForm)Application.OpenForms[0]);
				if (frm != null)
					frm._notifyIcon.ShowBalloonTip(10000, host.HostName + "(" + host.HostIP.ToString() + ")",
						message, ToolTipIcon.Info);
			}
		}

		#endregion

		#region String Formating

		string DurationToString(TimeSpan duration)
		{
			StringBuilder builder = new StringBuilder();
			if (duration.Days > 0)
			{
				builder.Append(duration.Days);
				builder.Append(duration.Days > 1 ? " days " : " day ");
			}

			builder.AppendFormat("{0:d2} : {1:d2} : {2:d2}", duration.Hours, duration.Minutes, duration.Seconds);

			return builder.ToString();
		}

		string PercentToString(float percent)
		{
			return String.Format("{0:P}", percent / 100);
		}

		#endregion

		#region Host Pinger Events

		void hp_OnStopPinging(HostPinger host)
		{
			if (InvokeRequired)
			{
				Invoke(new OnPingDelegate(OnHostPing), new object[] { host });
				return;
			}

			lock (_table)
			{
				ListViewItem item = (ListViewItem)_table[host.ID];
				if (item != null)
				{
					item.BackColor = Color.White;
					item.ForeColor = Color.Black;

					if (_selectedPinger == host)
					{
						_tbStartHost.Enabled = true;
						_tbRemoveHost.Enabled = true;
						_tbStopHost.Enabled = false;
					}
				}
			}
		}

		void hp_OnStartPinging(HostPinger host)
		{
			if (InvokeRequired)
			{
				Invoke(new OnPingDelegate(OnHostPing), new object[] { host });
				return;
			}

			lock (_table)
			{
				if ((ListViewItem)_table[host.ID] != null && _selectedPinger == host)
				{
					_tbStartHost.Enabled = false;
					_tbRemoveHost.Enabled = false;
					_tbStopHost.Enabled = true;
				}
			}
		}

		void OnHostPing(HostPinger host)
		{
			if (InvokeRequired)
			{
				Invoke(new OnPingDelegate(OnHostPing), new object[] { host });
				return;
			}

			lock (_table)
			{
				ListViewItem item = (ListViewItem)_table[host.ID];
				if (item != null)
				{
					item.SubItems[0].Text = host.HostIP.ToString();
					item.SubItems[1].Text = host.HostName;
					item.SubItems[2].Text = host.HostDescription;

					item.SubItems[3].Text = host.StatusName;

					item.SubItems[4].Text = host.SentPackets.ToString();

					item.SubItems[5].Text = host.ReceivedPackets.ToString();
					item.SubItems[6].Text = PercentToString(host.ReceivedPacketsPercent);

					item.SubItems[7].Text = host.LostPackets.ToString();
					item.SubItems[8].Text = PercentToString(host.LostPacketsPercent);

					item.SubItems[9].Text = host.LastPacketLost ? "Yes" : "No";

					item.SubItems[10].Text = host.ConsecutivePacketsLost.ToString();
					item.SubItems[11].Text = host.MaxConsecutivePacketsLost.ToString();

					item.SubItems[12].Text = host.RecentlyReceivedPackets.ToString();
					item.SubItems[13].Text = PercentToString(host.RecentlyReceivedPacketsPercent);

					item.SubItems[14].Text = host.RecentlyLostPackets.ToString();
					item.SubItems[15].Text = PercentToString(host.RecentlyLostPacketsPercent);

					item.SubItems[16].Text = host.CurrentResponseTime.ToString();
					item.SubItems[17].Text = host.AverageResponseTime.ToString("F");

					item.SubItems[18].Text = host.MinResponseTime.ToString();
					item.SubItems[19].Text = host.MaxResponseTime.ToString();

					item.SubItems[20].Text = DurationToString(host.CurrentStatusDuration);

					item.SubItems[21].Text = DurationToString(host.GetStatusDuration(HostStatus.Alive));
					item.SubItems[22].Text = DurationToString(host.GetStatusDuration(HostStatus.Dead));
					item.SubItems[23].Text = DurationToString(host.GetStatusDuration(HostStatus.DnsError));
					item.SubItems[24].Text = DurationToString(host.GetStatusDuration(HostStatus.Unknown));

					item.SubItems[25].Text = PercentToString(host.HostAvailability);

					item.SubItems[26].Text = DurationToString(host.TotalTestDuration);
					item.SubItems[27].Text = DurationToString(host.CurrentTestDuration);
				}
				else
				{
					item = new ListViewItem(new string[] 
					{ 
						host.HostIP.ToString(), host.HostName, host.HostDescription,
						host.StatusName,
						host.SentPackets.ToString(),
						host.ReceivedPackets.ToString(), PercentToString(host.ReceivedPacketsPercent),
						host.LostPackets.ToString(), PercentToString(host.LostPacketsPercent),
						host.LastPacketLost ? "Yes" : "No",
						host.ConsecutivePacketsLost.ToString(), host.MaxConsecutivePacketsLost.ToString(),
						host.RecentlyReceivedPackets.ToString(), PercentToString(host.RecentlyReceivedPacketsPercent),
						host.RecentlyLostPackets.ToString(), PercentToString(host.RecentlyLostPacketsPercent),
						host.CurrentResponseTime.ToString(), host.AverageResponseTime.ToString("F"),
						host.MinResponseTime.ToString(), host.MaxResponseTime.ToString(),
						DurationToString(host.CurrentStatusDuration),
						DurationToString(host.GetStatusDuration(HostStatus.Alive)),
						DurationToString(host.GetStatusDuration(HostStatus.Dead)),
						DurationToString(host.GetStatusDuration(HostStatus.DnsError)),
						DurationToString(host.GetStatusDuration(HostStatus.Unknown)),
						PercentToString(host.HostAvailability),
						DurationToString(host.TotalTestDuration),
						DurationToString(host.CurrentTestDuration)
					});

					_table.Add(host.ID, item);
					item.Tag = host;
					_lvHosts.Items.Insert(0, item);
				}

				switch (host.Status)
				{
					case HostStatus.Dead:
						item.BackColor = Color.Red;
						item.ForeColor = Color.White;
						break;

					case HostStatus.DnsError:
						item.BackColor = Color.OrangeRed;
						item.ForeColor = Color.White;
						break;

					case HostStatus.Alive:
						item.BackColor = Color.LightGreen;
						item.ForeColor = Color.Black;
						break;

					case HostStatus.Unknown:
						item.BackColor = Color.Yellow;
						item.ForeColor = Color.Black;
						break;
				}

				if (host == _selectedPinger)
				{
					_tbStartHost.Enabled = !_selectedPinger.IsRunning;
					_tbRemoveHost.Enabled = !_selectedPinger.IsRunning;
					_tbStopHost.Enabled = _selectedPinger.IsRunning;
				}
			}
		}

		#endregion

		#region Hosts List View Event Handlers

		private void _lvHosts_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ContextMenu menu = new ContextMenu();

				menu.MenuItems.Add(new MenuItem("Add New Host...", new EventHandler(_tbAddNewHost_Click)));

				if (_selectedPinger != null)
				{
					menu.MenuItems.Add(new MenuItem("Host Options...", new EventHandler(_tbHostOptions_Click)));
					menu.MenuItems.Add(new MenuItem("Data Series Options...", new EventHandler(_tbDataSeriesOptions_Click)));
					menu.MenuItems.Add(new MenuItem("Clear Statistics", new EventHandler(_tbClearStatistics_Click)));
					if (_selectedPinger.IsRunning)
						menu.MenuItems.Add(new MenuItem("Stop Ping", new EventHandler(_tbStopHost_Click)));
					else
					{
						menu.MenuItems.Add(new MenuItem("Start Ping", new EventHandler(_tbStartHost_Click)));
						menu.MenuItems.Add(new MenuItem("Remove Host", new EventHandler(_tbRemoveHost_Click)));
					}
				}

				menu.Show(this, e.Location);
			}
		}

		private void _lvHosts_DoubleClick(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
				_tbHostOptions_Click(sender, e);
		}

		private void _lvHosts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_lvHosts.SelectedItems != null && _lvHosts.SelectedItems.Count > 0)
				_selectedPinger = (HostPinger)_lvHosts.SelectedItems[0].Tag;
			else
				_selectedPinger = null;

			_tbStartHost.Enabled = _selectedPinger != null && !_selectedPinger.IsRunning;
			_tbRemoveHost.Enabled = _selectedPinger != null && !_selectedPinger.IsRunning;
			_tbStopHost.Enabled = _selectedPinger != null && _selectedPinger.IsRunning;

			_tbClearStatistics.Enabled = _selectedPinger != null;
			_tbHostOptions.Enabled = _selectedPinger != null;
			_tbDataSeriesOptions.Enabled = _selectedPinger != null;
		}

		#endregion

		#region Notification Area Icon Event Handlers

		private FormWindowState _oldState = FormWindowState.Normal;

		private void _notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				Visible = true;
				WindowState = _oldState;
			}
			else
			{
				WindowState = FormWindowState.Minimized;
				Visible = false;
			}
		}

		private void _notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (WindowState != FormWindowState.Minimized)
					Activate();
			}
		}


		private void _nimRestore_Click(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Maximized)
				WindowState = FormWindowState.Normal;
			else
			{
				Visible = true;
				WindowState = _oldState;
			}
		}

		private void _nimMaximize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Maximized;
			Visible = true;
		}

		private void _nimMinimize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void _nimExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion

		#region AddNewHost

		public void AddNewHost(HostPinger host)
		{
			HostOptions dlg = new HostOptions();
			if (dlg.ShowDialog(this, host) == DialogResult.OK)
			{
				bool exists = false;
				lock (_hosts)
				{
					foreach (HostPinger hp in _hosts)
					{
						if (hp.HostIP != null && hp.HostIP == dlg.Host.HostIP)
						{
							exists = true;
							break;
						}
					}
				}

				if (exists)
				{
					MessageBox.Show("Host already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				dlg.Host.Logger = DefaultLogger.Instance;
				dlg.Host.OnPing += new OnPingDelegate(OnHostPing);
				dlg.Host.OnStopPinging += new OnHostPingerCommandDelegate(hp_OnStopPinging);
				dlg.Host.OnStartPinging += new OnHostPingerCommandDelegate(hp_OnStartPinging);

				lock (_hosts)
				{
					_hosts.Add(dlg.Host);

					HostDataSeries series = new HostDataSeries(this, dlg.Host);
					_dataSeries.Add(dlg.Host, series);
				//	_graphManager.RegisterSeries(series);
				}

				_hostListChanged = true;

				if (MessageBox.Show("Start pinging of the host?", "Start", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					dlg.Host.Start();
			}
		}

		#endregion

		#region Toolbar Event Handlers

		private void _tbStartAll_Click(object sender, EventArgs e)
		{
			lock (_hosts)
			{
				foreach (HostPinger hp in _hosts)
					hp.Start();
			}
		}

		private void _tbStopAll_Click(object sender, EventArgs e)
		{
			lock (_hosts)
			{
				foreach (HostPinger hp in _hosts)
					hp.Stop();
			}
		}

		private void _tbStartHost_Click(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
				_selectedPinger.Start();
		}

		private void _tbStopHost_Click(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
				_selectedPinger.Stop();
		}

		private void _tbAddNewHost_Click(object sender, EventArgs e) { AddNewHost(null); }

		private void _tbHostOptions_Click(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
			{
				HostOptions dlg = new HostOptions();
				dlg.ShowDialog(this, _selectedPinger);
			}
		}

		private void _tbDataSeriesOptions_Click(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
			{
				EditDataSeriesForm dlg = new EditDataSeriesForm();
				dlg.Series = _dataSeries[_selectedPinger];

				dlg.ShowDialog(this);
			}
		}

		private void _tbRemoveHost_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Remove host from list?", "Remove host",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			if (_selectedPinger != null && !_selectedPinger.IsRunning)
			{
				lock (_table)
				{
					lock (_hosts)
					{
						_hosts.Remove(_selectedPinger);

					//	_graphManager.UnregisterSeries(_dataSeries[_selectedPinger]);
						_dataSeries.Remove(_selectedPinger);
					}

					_selectedPinger.OnPing -= new OnPingDelegate(OnHostPing);
					_selectedPinger.OnStopPinging -= new OnHostPingerCommandDelegate(hp_OnStopPinging);
					_selectedPinger.OnStartPinging -= new OnHostPingerCommandDelegate(hp_OnStartPinging);

					ListViewItem hi = (ListViewItem)_table[_selectedPinger.ID];
					_table.Remove(_selectedPinger.ID);
					_lvHosts.Items.Remove(hi);

					_hostListChanged = true;
				}
			}
		}

		private void _tbAbout_Click(object sender, EventArgs e)
		{
			AboutForm dlg = new AboutForm();
			dlg.ShowDialog(this);
		}

		private void _tbClearStatistics_Click(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
			{
				bool clear = false;

				if (Options.Instance.ClearTimeStatistics)
					clear = true;
				else
				{
					DialogResult dr = MessageBox.Show("Clear time statistics as well?", "Time Statistics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (dr == DialogResult.No)
						return;

					clear = dr == DialogResult.Yes;
				}

				_selectedPinger.ClearStatistics(clear);
			}
		}

		private void _tbClearAllStatistics_Click(object sender, EventArgs e)
		{
			bool clear = false;
			if (Options.Instance.ClearTimeStatistics)
				clear = true;
			else
			{
				DialogResult dr = MessageBox.Show("Clear time statistics as well?", "Time Statistics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dr == DialogResult.No)
					return;

				clear = dr == DialogResult.Yes;
			}

			lock (_hosts)
			{
				foreach (HostPinger hp in _hosts)
					hp.ClearStatistics(clear);
			}
		}

		private void _tbIPScan_Click(object sender, EventArgs e)
		{
			IPScanForm form = new IPScanForm();
			form.ShowDialog(this);
		}

		private void _tbTraceroute_Click(object sender, EventArgs e)
		{
			IPTraceForm form = new IPTraceForm();
			form.ShowDialog(this);
		}

        //Uncomment to enable the graph function
		/*private void _tbGraphs_Click(object sender, EventArgs e)
		*{
		*	GraphForm graphForm = new GraphForm(_graphManager);
        *
		*	graphForm.Series = _dataSeries.Values;
		*	graphForm.Show(this);
		*}
        * 
        */

		private void _tbOptions_Click(object sender, EventArgs e)
		{
			ProgramOptions dlg = new ProgramOptions();

			for (int i = Options.NUMBER_OF_COLUMNS - 1; i >= 0; i--)
				dlg.SelectedColumns.SetItemChecked(i, Options.Instance.GetComlumnVisability(i));

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				for (int i = Options.NUMBER_OF_COLUMNS - 1; i >= 0; i--)
				{
					bool old = Options.Instance.GetComlumnVisability(i);

					Options.Instance.SetColumnVisability(i, dlg.SelectedColumns.GetItemChecked(i));

					if (!old)
						_lvHosts.Columns[i].Width = Options.Instance.GetColumnWidth(i);

					if (!Options.Instance.GetComlumnVisability(i))
						_lvHosts.Columns[i].Width = 0;
				}

				Options.Instance.StartWithWindows = dlg.StartWithWindows;
				Options.Instance.StartPingingOnProgramStart = dlg.StartPingingOnProgramStart;
				Options.Instance.ShowErrorMessages = dlg.ShowErrorMessages;
				Options.Instance.ClearTimeStatistics = dlg.ClearTimeStatistics;
			}
		}

		private void _tbSave_Click(object sender, EventArgs e)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.CloseOutput = true;
			settings.Indent = true;

			try
			{
				XmlWriter writer = XmlWriter.Create(Program.GetAppFilePath("hosts.cfg"), settings);

				try
				{
					writer.WriteStartElement("pinger");

					lock (_hosts)
					{
						foreach (HostPinger hp in _hosts)
							hp.Save(writer, new HostPinger.AdditionalSettingsSave(_dataSeries[hp].SaveSettings));
					}

					writer.WriteEndElement();

					_hostListChanged = false;
				}
				finally
				{
					writer.Close();
				}
			}
			catch
			{
				MessageBox.Show("An error ocurred while saving host list!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Form Event Handlers

		private void PingForm_SizeChanged(object sender, EventArgs e)
		{
			if (WindowState != FormWindowState.Minimized)
				_oldState = WindowState;

			Visible = WindowState != FormWindowState.Minimized;
		}

		private void PingForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_hostListChanged)
			{
				DialogResult dr = MessageBox.Show("Host list has been changed. Do you want to save changes?", "Save Changes?",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (dr == DialogResult.Cancel)
				{
					e.Cancel = true;
					return;
				}

				if (dr == DialogResult.Yes)
					_tbSave_Click(sender, e);
			}

			SaveSettings();
		}

        #endregion

      //  private void ToolStripLabel1_Click(object sender, EventArgs e)
        //{

       //}
    }
}