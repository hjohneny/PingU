namespace NetPinger
{
	partial class IPTraceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPTraceForm));
            this.label1 = new System.Windows.Forms.Label();
            this._tbTarget = new System.Windows.Forms.TextBox();
            this._btnTrace = new System.Windows.Forms.Button();
            this._spnTimeout = new System.Windows.Forms.NumericUpDown();
            this._spnBufferSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._spnRetries = new System.Windows.Forms.NumericUpDown();
            this._spnPingsPerHop = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._btnAddHost = new System.Windows.Forms.Button();
            this._lStatus = new System.Windows.Forms.Label();
            this._lvRouteList = new NetPinger.ListViewDB();
            this._colHop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this._spnTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnRetries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnPingsPerHop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trace Tar&get:";
            // 
            // _tbTarget
            // 
            this._tbTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbTarget.Location = new System.Drawing.Point(90, 13);
            this._tbTarget.Name = "_tbTarget";
            this._tbTarget.Size = new System.Drawing.Size(338, 20);
            this._tbTarget.TabIndex = 1;
            // 
            // _btnTrace
            // 
            this._btnTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnTrace.Location = new System.Drawing.Point(434, 12);
            this._btnTrace.Name = "_btnTrace";
            this._btnTrace.Size = new System.Drawing.Size(75, 23);
            this._btnTrace.TabIndex = 10;
            this._btnTrace.Text = "&Trace";
            this._btnTrace.UseVisualStyleBackColor = true;
            this._btnTrace.Click += new System.EventHandler(this._btnTrace_Click);
            // 
            // _spnTimeout
            // 
            this._spnTimeout.Location = new System.Drawing.Point(90, 40);
            this._spnTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._spnTimeout.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._spnTimeout.Name = "_spnTimeout";
            this._spnTimeout.Size = new System.Drawing.Size(90, 20);
            this._spnTimeout.TabIndex = 3;
            this._spnTimeout.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this._spnTimeout.ValueChanged += new System.EventHandler(this._spnTimeout_ValueChanged);
            // 
            // _spnBufferSize
            // 
            this._spnBufferSize.Location = new System.Drawing.Point(90, 66);
            this._spnBufferSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this._spnBufferSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spnBufferSize.Name = "_spnBufferSize";
            this._spnBufferSize.Size = new System.Drawing.Size(90, 20);
            this._spnBufferSize.TabIndex = 5;
            this._spnBufferSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this._spnBufferSize.ValueChanged += new System.EventHandler(this._spnBufferSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "&Buffer Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ti&meout:";
            // 
            // _spnRetries
            // 
            this._spnRetries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._spnRetries.Location = new System.Drawing.Point(338, 66);
            this._spnRetries.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._spnRetries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spnRetries.Name = "_spnRetries";
            this._spnRetries.Size = new System.Drawing.Size(90, 20);
            this._spnRetries.TabIndex = 9;
            this._spnRetries.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._spnRetries.ValueChanged += new System.EventHandler(this._spnRetries_ValueChanged);
            // 
            // _spnPingsPerHop
            // 
            this._spnPingsPerHop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._spnPingsPerHop.Location = new System.Drawing.Point(338, 40);
            this._spnPingsPerHop.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this._spnPingsPerHop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spnPingsPerHop.Name = "_spnPingsPerHop";
            this._spnPingsPerHop.Size = new System.Drawing.Size(90, 20);
            this._spnPingsPerHop.TabIndex = 7;
            this._spnPingsPerHop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spnPingsPerHop.ValueChanged += new System.EventHandler(this._spnPingsPerHop_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Pings Per Hop:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "&Retries Per Hop:";
            // 
            // _btnAddHost
            // 
            this._btnAddHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddHost.Enabled = false;
            this._btnAddHost.Location = new System.Drawing.Point(391, 406);
            this._btnAddHost.Name = "_btnAddHost";
            this._btnAddHost.Size = new System.Drawing.Size(118, 23);
            this._btnAddHost.TabIndex = 12;
            this._btnAddHost.Text = "&Add To Host List...";
            this._btnAddHost.UseVisualStyleBackColor = true;
            this._btnAddHost.Click += new System.EventHandler(this._btnAddHost_Click);
            // 
            // _lStatus
            // 
            this._lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lStatus.AutoSize = true;
            this._lStatus.Location = new System.Drawing.Point(10, 411);
            this._lStatus.Name = "_lStatus";
            this._lStatus.Size = new System.Drawing.Size(140, 13);
            this._lStatus.TabIndex = 13;
            this._lStatus.Text = "Status: Trace is not running!";
            // 
            // _lvRouteList
            // 
            this._lvRouteList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lvRouteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colHop,
            this._colAddress,
            this._colHostName});
            this._lvRouteList.FullRowSelect = true;
            this._lvRouteList.GridLines = true;
            this._lvRouteList.HideSelection = false;
            this._lvRouteList.Location = new System.Drawing.Point(13, 92);
            this._lvRouteList.MultiSelect = false;
            this._lvRouteList.Name = "_lvRouteList";
            this._lvRouteList.Size = new System.Drawing.Size(496, 308);
            this._lvRouteList.TabIndex = 11;
            this._lvRouteList.UseCompatibleStateImageBehavior = false;
            this._lvRouteList.View = System.Windows.Forms.View.Details;
            this._lvRouteList.SelectedIndexChanged += new System.EventHandler(this._lvRouteList_SelectedIndexChanged);
            this._lvRouteList.DoubleClick += new System.EventHandler(this._lvRouteList_DoubleClick);
            // 
            // _colHop
            // 
            this._colHop.Text = "#";
            this._colHop.Width = 32;
            // 
            // _colAddress
            // 
            this._colAddress.Text = "IP Address";
            this._colAddress.Width = 120;
            // 
            // _colHostName
            // 
            this._colHostName.Text = "HostName";
            this._colHostName.Width = 150;
            // 
            // IPTraceForm
            // 
            this.AcceptButton = this._btnTrace;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 441);
            this.Controls.Add(this._lStatus);
            this.Controls.Add(this._btnAddHost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._spnRetries);
            this.Controls.Add(this._spnPingsPerHop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._spnBufferSize);
            this.Controls.Add(this._spnTimeout);
            this.Controls.Add(this._lvRouteList);
            this.Controls.Add(this._btnTrace);
            this.Controls.Add(this._tbTarget);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPTraceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trace Route";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IPTraceForm_FormClosing);
            this.Load += new System.EventHandler(this.IPTraceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._spnTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnRetries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnPingsPerHop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _tbTarget;
		private System.Windows.Forms.Button _btnTrace;
		private ListViewDB _lvRouteList;
		private System.Windows.Forms.NumericUpDown _spnTimeout;
		private System.Windows.Forms.NumericUpDown _spnBufferSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown _spnRetries;
		private System.Windows.Forms.NumericUpDown _spnPingsPerHop;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button _btnAddHost;
		private System.Windows.Forms.ColumnHeader _colHop;
		private System.Windows.Forms.ColumnHeader _colAddress;
		private System.Windows.Forms.ColumnHeader _colHostName;
		private System.Windows.Forms.Label _lStatus;
	}
}