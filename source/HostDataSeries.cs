
/*
 * 
 * 
 * contact: hjohneny99@gmail.com (Kirik)
 * 
 *	- Redistributions of source code must retain the above copyright notice,
 *	  this list of conditions and the following disclaimer. 
 * 
 *	- Redistributions in binary form must reproduce the above copyright notice,
 *	  this list of conditions and the following disclaimer in the documentation
 *	  and/or other materials provided with the distribution.
 * 
 *  - The names of contributors may not be used to endorse or promote products
 *    derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 *
 */


using LiveGraph;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Xml;
using NetUtils;

namespace NetPinger
{

	#region SeriesDataSources

	public enum SeriesDataSources
	{
		ReceivedPacketsPercent,
		LostPacketsPercent,
		ConsecutiveLostPackets,
		ReceivedPacketsRecent,
		ReceivedPacketsRecentPercent,
		LostPacketsRecent,
		LostPacketsRecentPercent,
		CurrentResponseTime,
		AverageResponseTime,
		HostAvailabilityPercent
	}

	#endregion

	#region DataSeriesNameParser

	public class DataSeriesNameParser
	{

		#region Data Sources Names

		static public readonly string[] SERIES_DATA_SOURCE_NAMES =
		{
			"Received Packets Percent",
			"Lost Packets Percent",
			"Consecutive Lost Packets",
			"Received Packets Recent",
			"Received Packets Recent Percent",
			"Lost Packets Recent",
			"Lost Packets Recent Percent",
			"Current Response Time",
			"Average Response Time",
			"Host Availability Percent"
		};

		#endregion

		#region Place Holders

		private static string HOST_NAME_PLACEHOLDER = "%hostname%";
		private static string IP_ADDR_PLACEHOLDER = "%ip%";
		private static string SERIES_SOURCE_PLACEHOLDER = "%series%";

		#endregion

		#region Default Pattern

		private static string DEFAULT_NAME_PATTERN = "%hostname% [%ip%] - %series%";

		#endregion

		#region SeriesNamePattern

		private string _seriesNamePattern;

		public string SeriesNamePattern
		{
			get { return _seriesNamePattern; }
			set
			{
				_seriesNamePattern = value;
				_series.Name = Parse(_seriesNamePattern);
			}
		}

		#endregion

		#region SeriesName

		public string SeriesName { get { return Parse(_seriesNamePattern); } }

		#endregion

		#region Source

		private SeriesDataSources _dataSource;

		public SeriesDataSources Source { get { return _dataSource; } }

		public string SourceName { get { return SERIES_DATA_SOURCE_NAMES[(int)_dataSource]; } }

		#endregion

		#region Series

		private DataSeries _series;

		public DataSeries Series { get { return _series; } }

		#endregion

		private HostPinger _host;

		private void _host_OnHostNameChanged(HostPinger host) { _series.Name = Parse(_seriesNamePattern); }

		#region Constructors

		public DataSeriesNameParser(string namePattern, DataSeries series, HostPinger host, SeriesDataSources dataSource)
		{
			_series = series;
			_host = host;
			_dataSource = dataSource;

			_seriesNamePattern = namePattern;
			_series.Name = Parse(_seriesNamePattern);

			_host.OnHostNameChanged += new OnHostNameChangedDelegate(_host_OnHostNameChanged);
		}

		public DataSeriesNameParser(DataSeries series, HostPinger host, SeriesDataSources dataSource) : this(DEFAULT_NAME_PATTERN, series, host, dataSource) { }

		#endregion

		public override string ToString() { return SeriesName; }

		private string Parse(string name)
		{
			return name.Replace(HOST_NAME_PLACEHOLDER, _host.HostName).
				Replace(IP_ADDR_PLACEHOLDER, _host.HostIP.ToString()).
				Replace(SERIES_SOURCE_PLACEHOLDER, SERIES_DATA_SOURCE_NAMES[(int)_dataSource]);
		}

	}

	#endregion

	#region HostDataSeries

	public class HostDataSeries
	{

		#region Data Series

		private DataSeries _receivedPacketsPercent;
		public DataSeries ReceivedPacketsPercent { get { return _receivedPacketsPercent; } }

		private DataSeries _lostPacketsPercent;
		public DataSeries LostPacketsPercent { get { return _lostPacketsPercent; } }

		private DataSeries _consecutiveLostPackets;
		public DataSeries ConsecutiveLostPackets { get { return _consecutiveLostPackets; } }

		private DataSeries _receivedPacketsRecent;
		public DataSeries ReceivedPacketsRecent { get { return _receivedPacketsRecent; } }

		private DataSeries _receivedPacketsRecentPercent;
		public DataSeries ReceivedPacketsRecentPercent { get { return _receivedPacketsRecentPercent; } }

		private DataSeries _lostPacketsRecent;
		public DataSeries LostPacketsRecent { get { return _lostPacketsRecent; } }

		private DataSeries _lostPacketsRecentPercent;
		public DataSeries LostPacketsRecentPercent { get { return _lostPacketsRecentPercent; } }

		private DataSeries _currentResponseTime;
		public DataSeries CurrentResponseTime { get { return _currentResponseTime; } }

		private DataSeries _averageResponseTime;
		public DataSeries AverageResponseTime { get { return _averageResponseTime; } }

		private DataSeries _hostAvailabilityPercent;
		public DataSeries HostAvailabilityPercent { get { return _hostAvailabilityPercent; } }

		#endregion

		#region Host

		private HostPinger _host;

		public HostPinger Host { get { return _host; } }

		#endregion

		#region SeriesNames

		private List<DataSeriesNameParser> _seriesNames = new List<DataSeriesNameParser>();

		public List<DataSeriesNameParser> SeriesNames
		{
			get { return _seriesNames; }
		}

		#endregion

		#region Constructor

		public HostDataSeries(Control syncControl, HostPinger host)
		{
			_syncControl = syncControl;

			_host = host;

			_receivedPacketsPercent = new DataSeries("", "%");
			_lostPacketsPercent = new DataSeries("", "%");
			_consecutiveLostPackets = new DataSeries("", "pkg");
			_receivedPacketsRecent = new DataSeries("", "pkg");
			_receivedPacketsRecentPercent = new DataSeries("", "%");
			_lostPacketsRecent = new DataSeries("", "pkg");
			_lostPacketsRecentPercent = new DataSeries("", "%");
			_currentResponseTime = new DataSeries("", "ms");
			_averageResponseTime = new DataSeries("", "ms");
			_hostAvailabilityPercent = new DataSeries("", "%");

			_seriesNames.Add(new DataSeriesNameParser(_receivedPacketsPercent, _host, SeriesDataSources.ReceivedPacketsPercent));
			_seriesNames.Add(new DataSeriesNameParser(_lostPacketsPercent, _host, SeriesDataSources.LostPacketsPercent));
			_seriesNames.Add(new DataSeriesNameParser(_consecutiveLostPackets, _host, SeriesDataSources.ConsecutiveLostPackets));
			_seriesNames.Add(new DataSeriesNameParser(_receivedPacketsRecent, _host, SeriesDataSources.ReceivedPacketsRecent));
			_seriesNames.Add(new DataSeriesNameParser(_receivedPacketsRecentPercent, _host, SeriesDataSources.ReceivedPacketsRecentPercent));
			_seriesNames.Add(new DataSeriesNameParser(_lostPacketsRecent, _host, SeriesDataSources.LostPacketsRecent));
			_seriesNames.Add(new DataSeriesNameParser(_lostPacketsRecentPercent, _host, SeriesDataSources.LostPacketsRecentPercent));
			_seriesNames.Add(new DataSeriesNameParser(_currentResponseTime, _host, SeriesDataSources.CurrentResponseTime));
			_seriesNames.Add(new DataSeriesNameParser(_averageResponseTime, _host, SeriesDataSources.AverageResponseTime));
			_seriesNames.Add(new DataSeriesNameParser(_hostAvailabilityPercent, _host, SeriesDataSources.HostAvailabilityPercent));

			_host.OnPing += new OnPingDelegate(_host_OnPing);
		}

		#endregion

		#region Load and Save

		public static string XML_DATA_SETTINGS_NODE = "data";

		public static string XML_SERIES_NODE = "series";

		public static string XML_ELEMENT_SERIES_SOURCE = "source";

		public static string XML_ELEMENT_SERIES_NAME_PATTERN = "name";

		public static string XML_ELEMENT_SERIES_DEPTH = "depth";

		public void LoadSettings(XmlNode hostNode)
		{
			XmlNode series = hostNode[XML_DATA_SETTINGS_NODE];
			if (series != null)
			{
				foreach (XmlNode node in series.ChildNodes)
				{
					DataSeriesNameParser s = FindSeries((SeriesDataSources)int.Parse(node.Attributes[XML_ELEMENT_SERIES_SOURCE].InnerText));

					if (node[XML_ELEMENT_SERIES_NAME_PATTERN] != null)
						s.SeriesNamePattern = node[XML_ELEMENT_SERIES_NAME_PATTERN].InnerText;

					if (node[XML_ELEMENT_SERIES_DEPTH] != null)
						s.Series.Depth = int.Parse(node[XML_ELEMENT_SERIES_DEPTH].InnerText);
				}
			}
		}

		public void SaveSettings(XmlWriter writer)
		{
			writer.WriteStartElement(XML_DATA_SETTINGS_NODE);

			foreach (DataSeriesNameParser s in _seriesNames)
			{
				writer.WriteStartElement(XML_SERIES_NODE);
				writer.WriteAttributeString(XML_ELEMENT_SERIES_SOURCE, ((int)s.Source).ToString());

				writer.WriteElementString(XML_ELEMENT_SERIES_NAME_PATTERN, s.SeriesNamePattern);
				writer.WriteElementString(XML_ELEMENT_SERIES_DEPTH, s.Series.Depth.ToString());

				writer.WriteEndElement();
			}

			writer.WriteEndElement();
		}

		private DataSeriesNameParser FindSeries(SeriesDataSources source)
		{
			foreach (DataSeriesNameParser s in _seriesNames)
			{
				if (s.Source == source)
					return s;
			}

			return null;
		}

		#endregion

		public override string ToString() { return _host.HostName + " [" + _host.HostIP + "]"; }

		#region Ping Event Handler

		private Control _syncControl;

		private void _host_OnPing(HostPinger host)
		{
			if (_syncControl.InvokeRequired)
				_syncControl.Invoke(new OnPingDelegate(_host_OnPingSync), host);
		}

		private void _host_OnPingSync(HostPinger host)
		{
			long now = DateTime.Now.Ticks;

			_receivedPacketsPercent.AddPoint(host.ReceivedPacketsPercent, now);
			_lostPacketsPercent.AddPoint(host.LostPacketsPercent, now);

			_consecutiveLostPackets.AddPoint(host.ConsecutivePacketsLost, now);

			_receivedPacketsRecent.AddPoint(host.RecentlyReceivedPackets, now);
			_receivedPacketsRecentPercent.AddPoint(host.RecentlyReceivedPacketsPercent, now);

			_lostPacketsRecent.AddPoint(host.RecentlyLostPackets, now);
			_lostPacketsRecentPercent.AddPoint(host.RecentlyLostPacketsPercent, now);

			if (!_host.LastPacketLost)
				_currentResponseTime.AddPoint(host.CurrentResponseTime, now);
			else
				_currentResponseTime.AddPoint(now);
			_averageResponseTime.AddPoint(host.AverageResponseTime, now);

			_hostAvailabilityPercent.AddPoint(host.HostAvailability, now);
		}

		#endregion

	}

	#endregion

}
