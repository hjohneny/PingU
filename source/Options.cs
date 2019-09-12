
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
using System.Text;
using Microsoft.Win32;
using System.Drawing;
using System.IO;

namespace NetPinger
{

	#region ColumnWidth

	class ColumnWidth
	{

		#region Visible

		private bool _visible = true;

		public bool Visible
		{
			get { return _visible; }
			set { _visible = value; }
		}

		#endregion

		#region Width

		private int _width = 100;

		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}

		#endregion

		#region Constructors

		public ColumnWidth(bool visible, int width)
		{
			_visible = visible;
			_width = width;
		}

		public ColumnWidth() { }

		#endregion

	}

	#endregion

	#region Options

	class Options
	{

		#region Registry Names

		public static readonly string RKN_WINDOWS_RUN = @"Software\Microsoft\Windows\CurrentVersion\Run";
		public static readonly string RKN_NETPINGER = @"Software\NetPinger";

		public static readonly string RVN_STAR_WITH_WINDOWS = "PingU.exe";

		public static readonly string RVN_SHOW_ERROR_MESSAGES = "ShowErrorMessages";
		public static readonly string RVN_CLEAR_TIMES = "ClearTimes";
		public static readonly string RVN_START_PINGING = "StartPinging";

		public static readonly string RVN_WINDOW_WIDTH = "WindowWidth";
		public static readonly string RVN_WINDOW_HEIGHT = "WindowHeight";

		public static readonly string RVN_WINDOW_POS_X = "WindowPosX";
		public static readonly string RVN_WINDOW_POS_Y = "WindowPosY";

		public static readonly string RVN_COLUMNS_WIDTHS = "ColumnsWidths";

		#endregion

		#region Instance

		private static object _syncInstance = new object();

		private static Options _instance;

		public static Options Instance
		{
			get
			{
				lock (_syncInstance)
				{
					if (_instance == null)
						_instance = new Options();
				}

				return _instance;
			}
		}

		#endregion

		#region StartWithWindows

		private bool _startWithWindows;

		public bool StartWithWindows
		{
			get { return _startWithWindows; }
			set
			{
				if (value != _startWithWindows)
				{
					RegistryKey runKey = Registry.CurrentUser.OpenSubKey(RKN_WINDOWS_RUN, true);

					if (value)
					{
						string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
							AppDomain.CurrentDomain.FriendlyName);
						runKey.SetValue(RVN_STAR_WITH_WINDOWS, path, RegistryValueKind.String);
					}
					else
						runKey.DeleteValue(RVN_STAR_WITH_WINDOWS);

					runKey.Close();

					_startWithWindows = value;
				}
			}
		}

		#endregion

		#region ShowErrorMessages

		private bool _showErrorMessages;

		public bool ShowErrorMessages
		{
			get { return _showErrorMessages; }
			set
			{
				if (value != _showErrorMessages)
				{
					WriteBoolToRegistry(RVN_SHOW_ERROR_MESSAGES, value);
					_showErrorMessages = value;
				}
			}
		}

		#endregion

		#region ClearTimeStatistics

		private bool _clearTimeStatistics;

		public bool ClearTimeStatistics
		{
			get { return _clearTimeStatistics; }
			set
			{
				if (value != _clearTimeStatistics)
				{
					WriteBoolToRegistry(RVN_CLEAR_TIMES, value);
					_clearTimeStatistics = value;
				}
			}
		}


		#endregion

		#region StartPingingOnProgramStart

		private bool _startPingingOnProgramStart;

		public bool StartPingingOnProgramStart
		{
			get { return _startPingingOnProgramStart; }
			set
			{
				if (_startPingingOnProgramStart != value)
				{
					WriteBoolToRegistry(RVN_START_PINGING, value);
					_startPingingOnProgramStart = value;
				}
			}
		}

		#endregion

		#region WindowSize

		#region Width

		private int _windowsWidth;

		public int WindowsWidth
		{
			get { return _windowsWidth; }
			set
			{
				if (value != _windowsWidth)
				{
					WriteIntToRegistry(RVN_WINDOW_WIDTH, value);
					_windowsWidth = value;
				}
			}
		}


		#endregion

		#region Height

		private int _windowsHeight;

		public int WindowsHeight
		{
			get { return _windowsHeight; }
			set
			{
				if (value != _windowsHeight)
				{
					WriteIntToRegistry(RVN_WINDOW_HEIGHT, value);
					_windowsHeight = value;
				}
			}
		}

		#endregion

		#region UseDefaultSize

		public bool UseDefaultSize
		{
			get { return _windowsHeight == -1 || _windowsWidth == -1; }
		}

		#endregion

		#endregion

		#region WindowPosition

		#region X

		private int _windowPositionX;

		public int WindowPositionX
		{
			get { return _windowPositionX; }
			set
			{
				if (value != _windowPositionX)
				{
					WriteIntToRegistry(RVN_WINDOW_POS_X, value);
					_windowPositionX = value;
				}
			}
		}

		#endregion

		#region Y

		private int _windowPositionY;

		public int WindowPositionY
		{
			get { return _windowPositionY; }
			set
			{
				if (value != _windowPositionY)
				{
					WriteIntToRegistry(RVN_WINDOW_POS_Y, value);
					_windowPositionY = value;
				}
			}
		}

		#endregion

		#region UseDefaultPosition

		public bool UseDefaultPosition
		{
			get { return _windowPositionX == -1 || _windowPositionY == -1; }
		}

		#endregion

		#endregion

		#region ComlumsWidths

		public static readonly int NUMBER_OF_COLUMNS = 28;

		private ColumnWidth[] _columns = new ColumnWidth[NUMBER_OF_COLUMNS];

		public int GetColumnWidth(int column)
		{
			return _columns[column].Visible == true ? _columns[column].Width : 0;
		}

		public int GetSavedColumnWidth(int column)
		{
			return _columns[column].Width;
		}

		public bool GetComlumnVisability(int column)
		{
			return _columns[column].Visible;
		}

		public void SetColumnWidth(int column, int width)
		{
			if (_columns[column].Width != width)
			{
				if (width < 1)
					_columns[column].Visible = false;
				else
				{
					_columns[column].Visible = true;
					_columns[column].Width = width;
				}

				WriteColumnsWidthsToRegistry();
			}
		}

		public void SetColumnVisability(int column, bool visible)
		{
			if (_columns[column].Visible != visible)
			{
				_columns[column].Visible = visible;

				WriteColumnsWidthsToRegistry();
			}
		}

		#region UseDefaultColumnsWidths

		private bool _useDefaultColumnsWidths = false;

		public bool UseDefaultColumnsWidths
		{
			get { return _useDefaultColumnsWidths; }
		}

		#endregion

		#endregion

		#region Constructor And Destructor

		public Options()
		{
			for (int i = NUMBER_OF_COLUMNS - 1; i >= 0; i--)
				_columns[i] = new ColumnWidth();

			RegistryKey runKey = Registry.CurrentUser.OpenSubKey(RKN_WINDOWS_RUN);
			_startWithWindows = runKey.GetValue(RVN_STAR_WITH_WINDOWS) != null;
			runKey.Close();

			_key = Registry.CurrentUser.OpenSubKey(RKN_NETPINGER, true);
			if (_key == null)
				_key = Registry.CurrentUser.CreateSubKey(RKN_NETPINGER);

			_showErrorMessages = ReadBoolFromRegistry(RVN_SHOW_ERROR_MESSAGES);
			_clearTimeStatistics = ReadBoolFromRegistry(RVN_CLEAR_TIMES);
			_startPingingOnProgramStart = ReadBoolFromRegistry(RVN_START_PINGING);

			ReadIntFromRegistry(out _windowsWidth, RVN_WINDOW_WIDTH, -1);
			ReadIntFromRegistry(out _windowsHeight, RVN_WINDOW_HEIGHT, -1);

			ReadIntFromRegistry(out _windowPositionX, RVN_WINDOW_POS_X, -1);
			ReadIntFromRegistry(out _windowPositionY, RVN_WINDOW_POS_Y, -1);

			ReadColumnsWidthsFromRegistry();
		}

		~Options()
		{
			_key.Close();
		}

		#endregion

		#region Registry Methods

		RegistryKey _key = null;

		private bool ReadBoolFromRegistry(string valueName)
		{
			object val = _key.GetValue(valueName);
			return !(val == null || (int)val == 0);
		}

		private void ReadIntFromRegistry(out int value, string valueName, int defaultValue)
		{
			object v = _key.GetValue(valueName);
			value = v != null ? (int)v : defaultValue;
		}

		private void WriteBoolToRegistry(string valueName, bool value)
		{
			WriteIntToRegistry(valueName, value ? 1 : 0);
		}

		private void WriteIntToRegistry(string valueName, int value)
		{
			_key.SetValue(valueName, value, RegistryValueKind.DWord);
		}

		private void ReadColumnsWidthsFromRegistry()
		{
			object v = _key.GetValue(RVN_COLUMNS_WIDTHS);
			if (v == null)
			{
				_useDefaultColumnsWidths = true;
				return;
			}

			byte[] data = (byte[])v;
			for (int i = 0, j = 0; i < data.Length; j++)
			{
				_columns[j].Visible = data[i++] != 0;
				_columns[j].Width = BitConverter.ToInt32(data, i);
				i += sizeof(int);
			}
		}

		private void WriteColumnsWidthsToRegistry()
		{
			byte[] data = new byte[NUMBER_OF_COLUMNS * (sizeof(byte) + sizeof(int))];
			int dataIndex = 0;

			foreach (ColumnWidth cw in _columns)
			{
				data[dataIndex++] = cw.Visible ? (byte)1 : (byte)0;
				BitConverter.GetBytes(cw.Width).CopyTo(data, dataIndex);
				dataIndex += sizeof(int);
			}

			_key.SetValue(RVN_COLUMNS_WIDTHS, data, RegistryValueKind.Binary);
		}

		#endregion

	}

	#endregion

}
