using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Coolsoft.NetPinger
{
	public partial class HostID : Form
	{
		public HostID()
		{
			InitializeComponent();
		}

		public void SetHostID(string id)
		{
			_txtHostID.Text = id;
		}

		private void _btnCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(_txtHostID.Text);
		}
	}
}