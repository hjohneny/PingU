namespace Coolsoft.NetPinger
{
	partial class ProxyOptions
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._txtProxyAddress = new System.Windows.Forms.TextBox();
			this._txtProxyPort = new System.Windows.Forms.TextBox();
			this._lblProxyAddress = new System.Windows.Forms.Label();
			this._lblProxyPort = new System.Windows.Forms.Label();
			this._chkUseProxy = new System.Windows.Forms.CheckBox();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _txtProxyAddress
			// 
			this._txtProxyAddress.Enabled = false;
			this._txtProxyAddress.Location = new System.Drawing.Point(94, 12);
			this._txtProxyAddress.Name = "_txtProxyAddress";
			this._txtProxyAddress.Size = new System.Drawing.Size(179, 20);
			this._txtProxyAddress.TabIndex = 1;
			// 
			// _txtProxyPort
			// 
			this._txtProxyPort.Enabled = false;
			this._txtProxyPort.Location = new System.Drawing.Point(94, 39);
			this._txtProxyPort.MaxLength = 5;
			this._txtProxyPort.Name = "_txtProxyPort";
			this._txtProxyPort.Size = new System.Drawing.Size(179, 20);
			this._txtProxyPort.TabIndex = 3;
			this._txtProxyPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtProxyPort_KeyPress);
			// 
			// _lblProxyAddress
			// 
			this._lblProxyAddress.AutoSize = true;
			this._lblProxyAddress.Enabled = false;
			this._lblProxyAddress.Location = new System.Drawing.Point(12, 16);
			this._lblProxyAddress.Name = "_lblProxyAddress";
			this._lblProxyAddress.Size = new System.Drawing.Size(76, 13);
			this._lblProxyAddress.TabIndex = 0;
			this._lblProxyAddress.Text = "Proxy &address:";
			// 
			// _lblProxyPort
			// 
			this._lblProxyPort.AutoSize = true;
			this._lblProxyPort.Enabled = false;
			this._lblProxyPort.Location = new System.Drawing.Point(12, 43);
			this._lblProxyPort.Name = "_lblProxyPort";
			this._lblProxyPort.Size = new System.Drawing.Size(57, 13);
			this._lblProxyPort.TabIndex = 2;
			this._lblProxyPort.Text = "Proxy &port:";
			// 
			// _chkUseProxy
			// 
			this._chkUseProxy.AutoSize = true;
			this._chkUseProxy.Location = new System.Drawing.Point(94, 66);
			this._chkUseProxy.Name = "_chkUseProxy";
			this._chkUseProxy.Size = new System.Drawing.Size(105, 17);
			this._chkUseProxy.TabIndex = 4;
			this._chkUseProxy.Text = "&Use proxy server";
			this._chkUseProxy.UseVisualStyleBackColor = true;
			this._chkUseProxy.CheckedChanged += new System.EventHandler(this._chkUseProxy_CheckedChanged);
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(198, 99);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 6;
			this._btnCancel.Text = "&Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
			// 
			// _btnOK
			// 
			this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOK.Location = new System.Drawing.Point(117, 99);
			this._btnOK.Name = "_btnOK";
			this._btnOK.Size = new System.Drawing.Size(75, 23);
			this._btnOK.TabIndex = 5;
			this._btnOK.Text = "&OK";
			this._btnOK.UseVisualStyleBackColor = true;
			// 
			// ProxyOptions
			// 
			this.AcceptButton = this._btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(285, 134);
			this.Controls.Add(this._btnOK);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._chkUseProxy);
			this.Controls.Add(this._lblProxyPort);
			this.Controls.Add(this._lblProxyAddress);
			this.Controls.Add(this._txtProxyPort);
			this.Controls.Add(this._txtProxyAddress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProxyOptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Proxy Options";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProxyOptions_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _txtProxyAddress;
		private System.Windows.Forms.TextBox _txtProxyPort;
		private System.Windows.Forms.Label _lblProxyAddress;
		private System.Windows.Forms.Label _lblProxyPort;
		private System.Windows.Forms.CheckBox _chkUseProxy;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOK;
	}
}