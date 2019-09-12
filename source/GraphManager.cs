using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using LiveGraph;
using System.IO;
using System.Windows.Forms;

namespace NetPinger
{

	public class GraphManager
	{

		private static string GRAPHS_COLLECTION_FILE = "graphs.cfg";

		private static string XML_ELEMENT_NAME_COLLECTION = "collection";

		private static string XML_ELEMENT_NAME_GRAPHS = "graphs";

		private static string XML_ELEMENT_NAME_NAME = "name";

		private XmlDocument _graphStorage = new XmlDocument();

		private XmlNode _rootElement = null;

		private Dictionary<string, XmlNode> _graphCollections = new Dictionary<string, XmlNode>();

		public Dictionary<string, XmlNode>.KeyCollection Graphs { get { return _graphCollections.Keys; } }

		private Dictionary<string, DataSeries> _regSeries = new Dictionary<string, DataSeries>();

		private Dictionary<DataSeries, string> _regSeriesIDs = new Dictionary<DataSeries, string>();

		public bool IsError { get { return _rootElement == null; } }

		public GraphManager()
		{
			try
			{
				_graphStorage.Load(Program.GetAppFilePath(GRAPHS_COLLECTION_FILE));
				_rootElement = _graphStorage.ChildNodes[_graphStorage.ChildNodes.Count - 1];

				foreach (XmlNode n in _rootElement.ChildNodes)
					_graphCollections.Add(n.Attributes[XML_ELEMENT_NAME_NAME].InnerText, n);
			}
			catch (FileNotFoundException)
			{
				_rootElement = _graphStorage.CreateElement(XML_ELEMENT_NAME_COLLECTION);
				_graphStorage.AppendChild(_graphStorage.CreateXmlDeclaration("1.0", "utf-8", "yes"));
				_graphStorage.AppendChild(_rootElement);
				_graphStorage.Save(Program.GetAppFilePath(GRAPHS_COLLECTION_FILE));
			}
			catch (Exception ex)
			{
				if (Options.Instance.ShowErrorMessages)
					MessageBox.Show(ex.Message, "Error Opening Graph Settings File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void RegisterSeries(HostDataSeries series)
		{
			string prefix = series.Host.ID.ToString() + ":";

			lock (_regSeries)
			{
				foreach (DataSeriesNameParser s in series.SeriesNames)
				{
					string id = prefix + (int)s.Source;
					_regSeries.Add(id, s.Series);
					_regSeriesIDs.Add(s.Series, id);
				}
			}
		}

		public void UnregisterSeries(HostDataSeries series)
		{
			string prefix = series.Host.ID.ToString() + ":";

			lock (_regSeries)
			{
				foreach (DataSeriesNameParser s in series.SeriesNames)
				{
					string id = prefix + (int)s.Source;
					_regSeries.Remove(id);
					_regSeriesIDs.Remove(s.Series);
				}
			}
		}

		private DataSeries SeriesLookup(string id) { return _regSeries.ContainsKey(id) ? _regSeries[id] : null; }

		private string SeriesIDLookup(DataSeries series) { return _regSeriesIDs.ContainsKey(series) ? _regSeriesIDs[series] : null; }

		public void LoadGraphCollection(string name, GraphControl control)
		{
			if (_graphCollections.ContainsKey(name))
				control.LoadFromXml(_graphCollections[name], new DataSeriesView.SeriesLookupDelegate(SeriesLookup));
		}

		public void AddGraphCollection(string name, GraphControl state)
		{
			RemoveGraphCollectionHelper(name);

			XmlAttribute nameAtt = _graphStorage.CreateAttribute(XML_ELEMENT_NAME_NAME);
			nameAtt.Value = name;

			XmlElement node = _graphStorage.CreateElement(XML_ELEMENT_NAME_GRAPHS);
			node.Attributes.Append(nameAtt);

			state.SaveToXml(_graphStorage, node, new DataSeriesView.SeriesIDLookupDelegate(SeriesIDLookup));
			_rootElement.AppendChild(node);

			_graphCollections.Add(name, node);

			Save();
		}

		public void RemoveGraphCollection(string name)
		{
			RemoveGraphCollectionHelper(name);
			Save();
		}

		public delegate void GraphCollectionUpdate();

		public event GraphCollectionUpdate OnGraphCollectionUpdate;

		private void RaiseOnGraphCollectionUpdate()
		{
			if (OnGraphCollectionUpdate != null)
				OnGraphCollectionUpdate();
		}

		private void RemoveGraphCollectionHelper(string name)
		{
			if (_graphCollections.ContainsKey(name))
			{
				_rootElement.RemoveChild(_graphCollections[name]);
				_graphCollections.Remove(name);
			}
		}

		private void Save()
		{
			_graphStorage.Save(Program.GetAppFilePath(GRAPHS_COLLECTION_FILE));
			RaiseOnGraphCollectionUpdate();
		}

	}

}
