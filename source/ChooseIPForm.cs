using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace NetPinger
{
	public partial class ChooseIPForm : Form
	{
		public ChooseIPForm()
		{
			InitializeComponent();
		}

		public IPAddress SelectedIPAddress
		{
			get { return _lbIPAdresses.SelectedItem != null ? (IPAddress)_lbIPAdresses.SelectedItem : null; }
		}

		public DialogResult ShowDialog(Form parent, IPAddress[] addresses)
		{
			foreach (IPAddress a in addresses)
				_lbIPAdresses.Items.Add(a);

			_lbIPAdresses.SelectedIndex = 0;

			return ShowDialog(parent);
		}

		private void _lbIPAdresses_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (_lbIPAdresses.SelectedItem != null && e.Y < _lbIPAdresses.ItemHeight * _lbIPAdresses.Items.Count)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
