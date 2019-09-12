using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetPinger
{
	public partial class CreateSeriesGroupForm : Form
	{

		public string GroupName { get { return _txtGroupName.Text; } }

		public CreateSeriesGroupForm()
		{
			InitializeComponent();
		}

	}
}
