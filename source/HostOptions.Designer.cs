namespace NetPinger
{
	partial class HostOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostOptions));
            this.label1 = new System.Windows.Forms.Label();
            this._spTtl = new System.Windows.Forms.NumericUpDown();
            this._chkbDontFragent = new System.Windows.Forms.CheckBox();
            this._spBufferSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._spPingsBeforeDeath = new System.Windows.Forms.NumericUpDown();
            this._spInterval = new System.Windows.Forms.NumericUpDown();
            this._spTimeout = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._tbHostName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._btnResolve = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this._tbHostIp = new System.Windows.Forms.TextBox();
            this._spDnsInterval = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this._spRecentDepth = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this._tbDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._spTtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spPingsBeforeDeath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spDnsInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spRecentDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "TT&L:";
            // 
            // _spTtl
            // 
            this._spTtl.Location = new System.Drawing.Point(133, 282);
            this._spTtl.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this._spTtl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spTtl.Name = "_spTtl";
            this._spTtl.Size = new System.Drawing.Size(98, 20);
            this._spTtl.TabIndex = 20;
            this._spTtl.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            // 
            // _chkbDontFragent
            // 
            this._chkbDontFragent.AutoSize = true;
            this._chkbDontFragent.Location = new System.Drawing.Point(133, 308);
            this._chkbDontFragent.Name = "_chkbDontFragent";
            this._chkbDontFragent.Size = new System.Drawing.Size(98, 17);
            this._chkbDontFragent.TabIndex = 21;
            this._chkbDontFragent.Text = "Don\'t Fra&gment";
            this._chkbDontFragent.UseVisualStyleBackColor = true;
            // 
            // _spBufferSize
            // 
            this._spBufferSize.Location = new System.Drawing.Point(133, 256);
            this._spBufferSize.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this._spBufferSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spBufferSize.Name = "_spBufferSize";
            this._spBufferSize.Size = new System.Drawing.Size(98, 20);
            this._spBufferSize.TabIndex = 18;
            this._spBufferSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "&Buffer Size:";
            // 
            // _spPingsBeforeDeath
            // 
            this._spPingsBeforeDeath.Location = new System.Drawing.Point(133, 230);
            this._spPingsBeforeDeath.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._spPingsBeforeDeath.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spPingsBeforeDeath.Name = "_spPingsBeforeDeath";
            this._spPingsBeforeDeath.Size = new System.Drawing.Size(98, 20);
            this._spPingsBeforeDeath.TabIndex = 16;
            this._spPingsBeforeDeath.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // _spInterval
            // 
            this._spInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._spInterval.Location = new System.Drawing.Point(133, 152);
            this._spInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._spInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._spInterval.Name = "_spInterval";
            this._spInterval.Size = new System.Drawing.Size(98, 20);
            this._spInterval.TabIndex = 10;
            this._spInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // _spTimeout
            // 
            this._spTimeout.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._spTimeout.Location = new System.Drawing.Point(133, 126);
            this._spTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._spTimeout.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._spTimeout.Name = "_spTimeout";
            this._spTimeout.Size = new System.Drawing.Size(98, 20);
            this._spTimeout.TabIndex = 8;
            this._spTimeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "&Pings Before Death:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Inter&val:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "&Timeout:";
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(156, 331);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 23;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.Location = new System.Drawing.Point(75, 331);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 22;
            this._btnOk.Text = "&OK";
            this._btnOk.UseVisualStyleBackColor = true;
            // 
            // _tbHostName
            // 
            this._tbHostName.Location = new System.Drawing.Point(133, 12);
            this._tbHostName.Name = "_tbHostName";
            this._tbHostName.Size = new System.Drawing.Size(98, 20);
            this._tbHostName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Host &Name:";
            // 
            // _btnResolve
            // 
            this._btnResolve.Location = new System.Drawing.Point(156, 38);
            this._btnResolve.Name = "_btnResolve";
            this._btnResolve.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._btnResolve.Size = new System.Drawing.Size(75, 23);
            this._btnResolve.TabIndex = 2;
            this._btnResolve.Text = "&Check IP";
            this._btnResolve.UseVisualStyleBackColor = true;
            this._btnResolve.Click += new System.EventHandler(this._btnResolve_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Host &IP:";
            // 
            // _tbHostIp
            // 
            this._tbHostIp.Location = new System.Drawing.Point(133, 74);
            this._tbHostIp.Name = "_tbHostIp";
            this._tbHostIp.Size = new System.Drawing.Size(98, 20);
            this._tbHostIp.TabIndex = 4;
            // 
            // _spDnsInterval
            // 
            this._spDnsInterval.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._spDnsInterval.Location = new System.Drawing.Point(133, 178);
            this._spDnsInterval.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this._spDnsInterval.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._spDnsInterval.Name = "_spDnsInterval";
            this._spDnsInterval.Size = new System.Drawing.Size(98, 20);
            this._spDnsInterval.TabIndex = 12;
            this._spDnsInterval.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "DNS &Query Interval:";
            // 
            // _spRecentDepth
            // 
            this._spRecentDepth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._spRecentDepth.Location = new System.Drawing.Point(133, 204);
            this._spRecentDepth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._spRecentDepth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._spRecentDepth.Name = "_spRecentDepth";
            this._spRecentDepth.Size = new System.Drawing.Size(98, 20);
            this._spRecentDepth.TabIndex = 14;
            this._spRecentDepth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Recent &History Depth:";
            // 
            // _tbDescription
            // 
            this._tbDescription.Location = new System.Drawing.Point(133, 100);
            this._tbDescription.Name = "_tbDescription";
            this._tbDescription.Size = new System.Drawing.Size(98, 20);
            this._tbDescription.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "&Description:";
            // 
            // HostOptions
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(254, 373);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._tbDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._spRecentDepth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._spDnsInterval);
            this.Controls.Add(this._tbHostIp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._btnResolve);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._tbHostName);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._spTimeout);
            this.Controls.Add(this._spInterval);
            this.Controls.Add(this._spPingsBeforeDeath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._spBufferSize);
            this.Controls.Add(this._chkbDontFragent);
            this.Controls.Add(this._spTtl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HostOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Host Options";
            this.Load += new System.EventHandler(this.HostOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this._spTtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spPingsBeforeDeath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spDnsInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spRecentDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown _spTtl;
		private System.Windows.Forms.CheckBox _chkbDontFragent;
		private System.Windows.Forms.NumericUpDown _spBufferSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown _spPingsBeforeDeath;
		private System.Windows.Forms.NumericUpDown _spInterval;
		private System.Windows.Forms.NumericUpDown _spTimeout;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.TextBox _tbHostName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button _btnResolve;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox _tbHostIp;
		private System.Windows.Forms.NumericUpDown _spDnsInterval;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown _spRecentDepth;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox _tbDescription;
		private System.Windows.Forms.Label label10;
	}
}