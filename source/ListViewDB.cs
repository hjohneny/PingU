using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NetPinger
{
	public class ListViewDB : ListView
	{
		public ListViewDB()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
		}
	}
}
