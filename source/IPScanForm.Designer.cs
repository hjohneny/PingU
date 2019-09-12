namespace NetPinger
{
	partial class IPScanForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPScanForm));
            this._splMaster = new System.Windows.Forms.SplitContainer();
            this._lRangeEnd = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._cbContinuousScan = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._spnPingsPerScan = new System.Windows.Forms.NumericUpDown();
            this._spnConcurrentPings = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._cbDontFragment = new System.Windows.Forms.CheckBox();
            this._spnBufferSize = new System.Windows.Forms.NumericUpDown();
            this._spnTTL = new System.Windows.Forms.NumericUpDown();
            this._spnTimeout = new System.Windows.Forms.NumericUpDown();
            this._lRangeSep = new System.Windows.Forms.Label();
            this._tbRangeEnd = new System.Windows.Forms.TextBox();
            this._tbRangeStart = new System.Windows.Forms.TextBox();
            this._cmbRangeType = new System.Windows.Forms.ComboBox();
            this._btnStartStop = new System.Windows.Forms.Button();
            this._prgScanProgress = new NetPinger.ProgressBarEx();
            this._btnAddHost = new System.Windows.Forms.Button();
            this._btnTrace = new System.Windows.Forms.Button();
            this._lbLog = new System.Windows.Forms.ListBox();
            this._lvAliveHosts = new NetPinger.ListViewDB();
            this._colQuality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colIPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colAvgResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colLosses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._ilQuality = new System.Windows.Forms.ImageList(this.components);
            this._ttQuality = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._splMaster)).BeginInit();
            this._splMaster.Panel1.SuspendLayout();
            this._splMaster.Panel2.SuspendLayout();
            this._splMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._spnPingsPerScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnConcurrentPings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnTTL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // _splMaster
            // 
            this._splMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splMaster.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splMaster.IsSplitterFixed = true;
            this._splMaster.Location = new System.Drawing.Point(0, 0);
            this._splMaster.Name = "_splMaster";
            this._splMaster.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splMaster.Panel1
            // 
            this._splMaster.Panel1.Controls.Add(this._lRangeEnd);
            this._splMaster.Panel1.Controls.Add(this.label9);
            this._splMaster.Panel1.Controls.Add(this.label8);
            this._splMaster.Panel1.Controls.Add(this._cbContinuousScan);
            this._splMaster.Panel1.Controls.Add(this.label7);
            this._splMaster.Panel1.Controls.Add(this.label6);
            this._splMaster.Panel1.Controls.Add(this._spnPingsPerScan);
            this._splMaster.Panel1.Controls.Add(this._spnConcurrentPings);
            this._splMaster.Panel1.Controls.Add(this.label5);
            this._splMaster.Panel1.Controls.Add(this.label4);
            this._splMaster.Panel1.Controls.Add(this.label3);
            this._splMaster.Panel1.Controls.Add(this._cbDontFragment);
            this._splMaster.Panel1.Controls.Add(this._spnBufferSize);
            this._splMaster.Panel1.Controls.Add(this._spnTTL);
            this._splMaster.Panel1.Controls.Add(this._spnTimeout);
            this._splMaster.Panel1.Controls.Add(this._lRangeSep);
            this._splMaster.Panel1.Controls.Add(this._tbRangeEnd);
            this._splMaster.Panel1.Controls.Add(this._tbRangeStart);
            this._splMaster.Panel1.Controls.Add(this._cmbRangeType);
            this._splMaster.Panel1.Controls.Add(this._btnStartStop);
            // 
            // _splMaster.Panel2
            // 
            this._splMaster.Panel2.Controls.Add(this._prgScanProgress);
            this._splMaster.Panel2.Controls.Add(this._btnAddHost);
            this._splMaster.Panel2.Controls.Add(this._btnTrace);
            this._splMaster.Panel2.Controls.Add(this._lbLog);
            this._splMaster.Panel2.Controls.Add(this._lvAliveHosts);
            this._splMaster.Size = new System.Drawing.Size(470, 462);
            this._splMaster.SplitterDistance = 160;
            this._splMaster.TabIndex = 0;
            // 
            // _lRangeEnd
            // 
            this._lRangeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lRangeEnd.AutoSize = true;
            this._lRangeEnd.Location = new System.Drawing.Point(230, 13);
            this._lRangeEnd.Name = "_lRangeEnd";
            this._lRangeEnd.Size = new System.Drawing.Size(64, 13);
            this._lRangeEnd.TabIndex = 4;
            this._lRangeEnd.Text = "Range &End:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(85, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "&Range Start:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "T&ype:";
            // 
            // _cbContinuousScan
            // 
            this._cbContinuousScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cbContinuousScan.AutoSize = true;
            this._cbContinuousScan.Location = new System.Drawing.Point(299, 109);
            this._cbContinuousScan.Name = "_cbContinuousScan";
            this._cbContinuousScan.Size = new System.Drawing.Size(107, 17);
            this._cbContinuousScan.TabIndex = 17;
            this._cbContinuousScan.Text = "Co&ntinuous Scan";
            this._cbContinuousScan.UseVisualStyleBackColor = true;
            this._cbContinuousScan.CheckedChanged += new System.EventHandler(this._cbContinuousScan_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "&Pings Per Scan Pass:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "&Concurrent Pings:";
            // 
            // _spnPingsPerScan
            // 
            this._spnPingsPerScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._spnPingsPerScan.Location = new System.Drawing.Point(299, 83);
            this._spnPingsPerScan.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this._spnPingsPerScan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spnPingsPerScan.Name = "_spnPingsPerScan";
            this._spnPingsPerScan.Size = new System.Drawing.Size(64, 20);
            this._spnPingsPerScan.TabIndex = 16;
            this._spnPingsPerScan.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._spnPingsPerScan.ValueChanged += new System.EventHandler(this._spnPingsPerScan_ValueChanged);
            // 
            // _spnConcurrentPings
            // 
            this._spnConcurrentPings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._spnConcurrentPings.Location = new System.Drawing.Point(299, 57);
            this._spnConcurrentPings.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this._spnConcurrentPings.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spnConcurrentPings.Name = "_spnConcurrentPings";
            this._spnConcurrentPings.Size = new System.Drawing.Size(64, 20);
            this._spnConcurrentPings.TabIndex = 14;
            this._spnConcurrentPings.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this._spnConcurrentPings.ValueChanged += new System.EventHandler(this._spnConcurrentPings_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "&Buffer Size:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "TT&L:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "&Timeout:";
            // 
            // _cbDontFragment
            // 
            this._cbDontFragment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cbDontFragment.AutoSize = true;
            this._cbDontFragment.Location = new System.Drawing.Point(88, 135);
            this._cbDontFragment.Name = "_cbDontFragment";
            this._cbDontFragment.Size = new System.Drawing.Size(98, 17);
            this._cbDontFragment.TabIndex = 12;
            this._cbDontFragment.Text = "&Don\'t Fragment";
            this._cbDontFragment.UseVisualStyleBackColor = true;
            this._cbDontFragment.CheckedChanged += new System.EventHandler(this._cbDontFragment_CheckedChanged);
            // 
            // _spnBufferSize
            // 
            this._spnBufferSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._spnBufferSize.Location = new System.Drawing.Point(88, 109);
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
            this._spnBufferSize.Size = new System.Drawing.Size(64, 20);
            this._spnBufferSize.TabIndex = 11;
            this._spnBufferSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this._spnBufferSize.ValueChanged += new System.EventHandler(this._spnBufferSize_ValueChanged);
            // 
            // _spnTTL
            // 
            this._spnTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._spnTTL.Location = new System.Drawing.Point(88, 83);
            this._spnTTL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._spnTTL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._spnTTL.Name = "_spnTTL";
            this._spnTTL.Size = new System.Drawing.Size(64, 20);
            this._spnTTL.TabIndex = 9;
            this._spnTTL.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this._spnTTL.ValueChanged += new System.EventHandler(this._spnTTL_ValueChanged);
            // 
            // _spnTimeout
            // 
            this._spnTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._spnTimeout.Location = new System.Drawing.Point(88, 57);
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
            this._spnTimeout.Size = new System.Drawing.Size(64, 20);
            this._spnTimeout.TabIndex = 7;
            this._spnTimeout.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this._spnTimeout.ValueChanged += new System.EventHandler(this._spnTimeout_ValueChanged);
            // 
            // _lRangeSep
            // 
            this._lRangeSep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lRangeSep.AutoSize = true;
            this._lRangeSep.Location = new System.Drawing.Point(220, 33);
            this._lRangeSep.Name = "_lRangeSep";
            this._lRangeSep.Size = new System.Drawing.Size(10, 13);
            this._lRangeSep.TabIndex = 19;
            this._lRangeSep.Text = "-";
            // 
            // _tbRangeEnd
            // 
            this._tbRangeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._tbRangeEnd.Location = new System.Drawing.Point(233, 29);
            this._tbRangeEnd.Name = "_tbRangeEnd";
            this._tbRangeEnd.Size = new System.Drawing.Size(130, 20);
            this._tbRangeEnd.TabIndex = 5;
            // 
            // _tbRangeStart
            // 
            this._tbRangeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._tbRangeStart.Location = new System.Drawing.Point(87, 29);
            this._tbRangeStart.Name = "_tbRangeStart";
            this._tbRangeStart.Size = new System.Drawing.Size(130, 20);
            this._tbRangeStart.TabIndex = 3;
            // 
            // _cmbRangeType
            // 
            this._cmbRangeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cmbRangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRangeType.FormattingEnabled = true;
            this._cmbRangeType.Items.AddRange(new object[] {
            "Range",
            "Subnet"});
            this._cmbRangeType.Location = new System.Drawing.Point(12, 29);
            this._cmbRangeType.Name = "_cmbRangeType";
            this._cmbRangeType.Size = new System.Drawing.Size(69, 21);
            this._cmbRangeType.TabIndex = 1;
            this._cmbRangeType.SelectedIndexChanged += new System.EventHandler(this._cmbRangeType_SelectedIndexChanged);
            // 
            // _btnStartStop
            // 
            this._btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnStartStop.Location = new System.Drawing.Point(369, 28);
            this._btnStartStop.Name = "_btnStartStop";
            this._btnStartStop.Size = new System.Drawing.Size(89, 23);
            this._btnStartStop.TabIndex = 18;
            this._btnStartStop.Text = "&Start";
            this._btnStartStop.UseVisualStyleBackColor = true;
            this._btnStartStop.Click += new System.EventHandler(this._btnStartStop_Click);
            // 
            // _prgScanProgress
            // 
            this._prgScanProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._prgScanProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._prgScanProgress.Location = new System.Drawing.Point(12, 164);
            this._prgScanProgress.Name = "_prgScanProgress";
            this._prgScanProgress.Size = new System.Drawing.Size(215, 23);
            this._prgScanProgress.TabIndex = 5;
            this._prgScanProgress.Text = "Scanner is not running!";
            this._prgScanProgress.TextColor = System.Drawing.Color.Navy;
            // 
            // _btnAddHost
            // 
            this._btnAddHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddHost.Enabled = false;
            this._btnAddHost.Location = new System.Drawing.Point(233, 164);
            this._btnAddHost.Name = "_btnAddHost";
            this._btnAddHost.Size = new System.Drawing.Size(111, 23);
            this._btnAddHost.TabIndex = 1;
            this._btnAddHost.Text = "&Add To Host List...";
            this._btnAddHost.UseVisualStyleBackColor = true;
            this._btnAddHost.Click += new System.EventHandler(this._btnAddHost_Click);
            // 
            // _btnTrace
            // 
            this._btnTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnTrace.Enabled = false;
            this._btnTrace.Location = new System.Drawing.Point(350, 164);
            this._btnTrace.Name = "_btnTrace";
            this._btnTrace.Size = new System.Drawing.Size(108, 23);
            this._btnTrace.TabIndex = 2;
            this._btnTrace.Text = "Trace R&oute...";
            this._btnTrace.UseVisualStyleBackColor = true;
            this._btnTrace.Click += new System.EventHandler(this._btnTrace_Click);
            // 
            // _lbLog
            // 
            this._lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lbLog.FormattingEnabled = true;
            this._lbLog.Location = new System.Drawing.Point(13, 193);
            this._lbLog.Name = "_lbLog";
            this._lbLog.Size = new System.Drawing.Size(445, 95);
            this._lbLog.TabIndex = 3;
            // 
            // _lvAliveHosts
            // 
            this._lvAliveHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lvAliveHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colQuality,
            this._colIPAddress,
            this._colAvgResponseTime,
            this._colLosses,
            this._colHostName});
            this._lvAliveHosts.FullRowSelect = true;
            this._lvAliveHosts.GridLines = true;
            this._lvAliveHosts.HideSelection = false;
            this._lvAliveHosts.Location = new System.Drawing.Point(12, 3);
            this._lvAliveHosts.MultiSelect = false;
            this._lvAliveHosts.Name = "_lvAliveHosts";
            this._lvAliveHosts.Size = new System.Drawing.Size(446, 155);
            this._lvAliveHosts.SmallImageList = this._ilQuality;
            this._lvAliveHosts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._lvAliveHosts.TabIndex = 0;
            this._lvAliveHosts.UseCompatibleStateImageBehavior = false;
            this._lvAliveHosts.View = System.Windows.Forms.View.Details;
            this._lvAliveHosts.SelectedIndexChanged += new System.EventHandler(this._lvAliveHosts_SelectedIndexChanged);
            this._lvAliveHosts.DoubleClick += new System.EventHandler(this._lvAliveHosts_DoubleClick);
            this._lvAliveHosts.MouseMove += new System.Windows.Forms.MouseEventHandler(this._lvAliveHosts_MouseMove);
            // 
            // _colQuality
            // 
            this._colQuality.Text = "Q";
            this._colQuality.Width = 20;
            // 
            // _colIPAddress
            // 
            this._colIPAddress.Text = "IP Address";
            this._colIPAddress.Width = 92;
            // 
            // _colAvgResponseTime
            // 
            this._colAvgResponseTime.Text = "Avg. Resp. Time";
            this._colAvgResponseTime.Width = 91;
            // 
            // _colLosses
            // 
            this._colLosses.Text = "Losses";
            this._colLosses.Width = 56;
            // 
            // _colHostName
            // 
            this._colHostName.Text = "Host Name (double click to start ping)";
            this._colHostName.Width = 205;
            // 
            // _ilQuality
            // 
            this._ilQuality.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_ilQuality.ImageStream")));
            this._ilQuality.TransparentColor = System.Drawing.Color.Transparent;
            this._ilQuality.Images.SetKeyName(0, "0");
            this._ilQuality.Images.SetKeyName(1, "1");
            this._ilQuality.Images.SetKeyName(2, "2");
            this._ilQuality.Images.SetKeyName(3, "3");
            this._ilQuality.Images.SetKeyName(4, "4");
            this._ilQuality.Images.SetKeyName(5, "5");
            this._ilQuality.Images.SetKeyName(6, "6");
            // 
            // IPScanForm
            // 
            this.AcceptButton = this._btnStartStop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 462);
            this.Controls.Add(this._splMaster);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPScanForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scan IP Address Range";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IPScanForm_FormClosing);
            this._splMaster.Panel1.ResumeLayout(false);
            this._splMaster.Panel1.PerformLayout();
            this._splMaster.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splMaster)).EndInit();
            this._splMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._spnPingsPerScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnConcurrentPings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnTTL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spnTimeout)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer _splMaster;
		private System.Windows.Forms.ListBox _lbLog;
		private ListViewDB _lvAliveHosts;
		private System.Windows.Forms.ColumnHeader _colQuality;
		private System.Windows.Forms.ColumnHeader _colIPAddress;
		private System.Windows.Forms.ColumnHeader _colAvgResponseTime;
		private System.Windows.Forms.Button _btnAddHost;
		private System.Windows.Forms.Button _btnTrace;
		private System.Windows.Forms.Button _btnStartStop;
		private System.Windows.Forms.Label _lRangeSep;
		private System.Windows.Forms.TextBox _tbRangeEnd;
		private System.Windows.Forms.TextBox _tbRangeStart;
		private System.Windows.Forms.ComboBox _cmbRangeType;
		private System.Windows.Forms.NumericUpDown _spnBufferSize;
		private System.Windows.Forms.NumericUpDown _spnTTL;
		private System.Windows.Forms.NumericUpDown _spnTimeout;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox _cbDontFragment;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown _spnPingsPerScan;
		private System.Windows.Forms.NumericUpDown _spnConcurrentPings;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox _cbContinuousScan;
		private System.Windows.Forms.Label _lRangeEnd;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ImageList _ilQuality;
		private ProgressBarEx _prgScanProgress;
		private System.Windows.Forms.ColumnHeader _colLosses;
		private System.Windows.Forms.ColumnHeader _colHostName;
		private System.Windows.Forms.ToolTip _ttQuality;
	}
}