using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace NetPinger
{
	static class Program
	{

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				Application.Run(new PingForm());
			}
			catch { Application.Exit(); }
		}

		public static string GetAppFilePath(string file)
		{
			return Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetPinger"), file);
		}
	}
}