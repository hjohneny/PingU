using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Coolsoft.NetPinger
{
	public partial class ProxyOptions : Form
	{
		public ProxyOptions()
		{
			InitializeComponent();
		}

		private void _txtProxyPort_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar))
				e.Handled = true;
		}

		private void _chkUseProxy_CheckedChanged(object sender, EventArgs e)
		{
			_lblProxyAddress.Enabled = _lblProxyPort.Enabled =
				_txtProxyAddress.Enabled = _txtProxyPort.Enabled = _chkUseProxy.Checked;
		}

		public string ProxyAddress
		{
			get { return _txtProxyAddress.Text; }
			set { _txtProxyAddress.Text = value; }
		}

		public int ProxyPort
		{
			get
			{
				int port;
				int.TryParse(_txtProxyPort.Text, out port);
				return port;
			}

			set { _txtProxyPort.Text = value.ToString(); }
		}

		public bool UseProxy
		{
			get { return _chkUseProxy.Checked; }
			set { _chkUseProxy.Checked = value; }
		}

		private bool _cancel = false;

		private void ProxyOptions_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_cancel || !_chkUseProxy.Checked ||
				(e.CloseReason != CloseReason.UserClosing && e.CloseReason != CloseReason.None))
				return;

			if (!Uri.CheckSchemeName(_txtProxyAddress.Text))
			{
				IPAddress addr;
				if (!IPAddress.TryParse(_txtProxyAddress.Text, out addr))
				{
					MessageBox.Show(this, "Wrong proxy address format", "Error!",
						MessageBoxButtons.OK, MessageBoxIcon.Error);

					e.Cancel = true;
					return;
				}
			}

			int port;
			int.TryParse(_txtProxyPort.Text, out port);

			if (port <= 0 || port > 65535)
			{
				MessageBox.Show(this, "Wrong proxy port", "Error!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				e.Cancel = true;
			}
		}

		private void _btnCancel_Click(object sender, EventArgs e)
		{
			_cancel = true;
		}
	}
}