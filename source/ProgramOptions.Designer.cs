namespace NetPinger
{
	partial class ProgramOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramOptions));
            this._clColumns = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this._cbShowErrorMessages = new System.Windows.Forms.CheckBox();
            this._cbClearTimes = new System.Windows.Forms.CheckBox();
            this._cbStartPinging = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _clColumns
            // 
            this._clColumns.CheckOnClick = true;
            this._clColumns.FormattingEnabled = true;
            this._clColumns.Items.AddRange(new object[] {
            "IP Address",
            "Name",
            "Description",
            "Status",
            "Sent Packets",
            "Received Packets",
            "Received Packets %",
            "Lost Packets",
            "Lost Packets %",
            "Last Packet Lost",
            "Consecutive Packets Lost",
            "Max Consecutive Packet Lost",
            "Received Packets (Recent)",
            "Received Packets % (Recent)",
            "Lost Packets (Recent)",
            "Lost Packets % (Recent)",
            "Current Response Time",
            "Average Response Time",
            "Min Response Time",
            "Max Response Time",
            "Current Status Duration",
            "Alive Status Duration",
            "Dead Status Duration",
            "DNS Error Status Duration",
            "Unknown Status Duration",
            "Host Availability",
            "Total Test Duration",
            "Current Test Duration"});
            this._clColumns.Location = new System.Drawing.Point(12, 25);
            this._clColumns.Name = "_clColumns";
            this._clColumns.Size = new System.Drawing.Size(210, 139);
            this._clColumns.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Display Columns:";
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(344, 141);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(255, 141);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 5;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _cbStartWithWindows
            // 
            this._cbStartWithWindows.AutoSize = true;
            this._cbStartWithWindows.Location = new System.Drawing.Point(229, 25);
            this._cbStartWithWindows.Name = "_cbStartWithWindows";
            this._cbStartWithWindows.Size = new System.Drawing.Size(117, 17);
            this._cbStartWithWindows.TabIndex = 1;
            this._cbStartWithWindows.Text = "Start with &Windows";
            this._cbStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // _cbShowErrorMessages
            // 
            this._cbShowErrorMessages.AutoSize = true;
            this._cbShowErrorMessages.Location = new System.Drawing.Point(229, 49);
            this._cbShowErrorMessages.Name = "_cbShowErrorMessages";
            this._cbShowErrorMessages.Size = new System.Drawing.Size(129, 17);
            this._cbShowErrorMessages.TabIndex = 2;
            this._cbShowErrorMessages.Text = "Show &Error Messages";
            this._cbShowErrorMessages.UseVisualStyleBackColor = true;
            // 
            // _cbClearTimes
            // 
            this._cbClearTimes.AutoSize = true;
            this._cbClearTimes.Location = new System.Drawing.Point(229, 73);
            this._cbClearTimes.Name = "_cbClearTimes";
            this._cbClearTimes.Size = new System.Drawing.Size(133, 17);
            this._cbClearTimes.TabIndex = 3;
            this._cbClearTimes.Text = "&Clear Times By Default";
            this._cbClearTimes.UseVisualStyleBackColor = true;
            // 
            // _cbStartPinging
            // 
            this._cbStartPinging.AutoSize = true;
            this._cbStartPinging.Location = new System.Drawing.Point(229, 97);
            this._cbStartPinging.Name = "_cbStartPinging";
            this._cbStartPinging.Size = new System.Drawing.Size(190, 17);
            this._cbStartPinging.TabIndex = 4;
            this._cbStartPinging.Text = "&Start Pinging When Program Starts";
            this._cbStartPinging.UseVisualStyleBackColor = true;
            // 
            // ProgramOptions
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(431, 185);
            this.Controls.Add(this._cbStartPinging);
            this.Controls.Add(this._cbClearTimes);
            this.Controls.Add(this._cbShowErrorMessages);
            this.Controls.Add(this._cbStartWithWindows);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._clColumns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox _clColumns;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.CheckBox _cbStartWithWindows;
		private System.Windows.Forms.CheckBox _cbShowErrorMessages;
		private System.Windows.Forms.CheckBox _cbClearTimes;
		private System.Windows.Forms.CheckBox _cbStartPinging;
	}
}