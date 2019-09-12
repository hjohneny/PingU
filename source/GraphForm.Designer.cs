namespace NetPinger
{
	partial class GraphForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphForm));
            this._cbGraph = new System.Windows.Forms.ComboBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._gcGraphs = new LiveGraph.GraphControl();
            this._btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _cbGraph
            // 
            this._cbGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cbGraph.FormattingEnabled = true;
            this._cbGraph.Location = new System.Drawing.Point(87, 518);
            this._cbGraph.Name = "_cbGraph";
            this._cbGraph.Size = new System.Drawing.Size(275, 21);
            this._cbGraph.TabIndex = 2;
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(449, 516);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "&Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnRemove
            // 
            this._btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRemove.Location = new System.Drawing.Point(530, 516);
            this._btnRemove.Name = "_btnRemove";
            this._btnRemove.Size = new System.Drawing.Size(75, 23);
            this._btnRemove.TabIndex = 5;
            this._btnRemove.Text = "&Remove";
            this._btnRemove.UseVisualStyleBackColor = true;
            this._btnRemove.Click += new System.EventHandler(this._btnRemove_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User &Graphs:";
            // 
            // _gcGraphs
            // 
            this._gcGraphs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gcGraphs.Location = new System.Drawing.Point(0, 0);
            this._gcGraphs.Name = "_gcGraphs";
            this._gcGraphs.Size = new System.Drawing.Size(617, 512);
            this._gcGraphs.TabIndex = 0;
            this._gcGraphs.OnAddView += new LiveGraph.GraphControl.AddViewDelegate(this._gcGraphs_OnAddView);
            // 
            // _btnLoad
            // 
            this._btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnLoad.Location = new System.Drawing.Point(368, 516);
            this._btnLoad.Name = "_btnLoad";
            this._btnLoad.Size = new System.Drawing.Size(75, 23);
            this._btnLoad.TabIndex = 3;
            this._btnLoad.Text = "&Load";
            this._btnLoad.UseVisualStyleBackColor = true;
            this._btnLoad.Click += new System.EventHandler(this._btnLoad_Click);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 551);
            this.Controls.Add(this._btnLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnRemove);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._cbGraph);
            this.Controls.Add(this._gcGraphs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GraphForm";
            this.Text = "PingNet Graph";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private LiveGraph.GraphControl _gcGraphs;
		private System.Windows.Forms.ComboBox _cbGraph;
		private System.Windows.Forms.Button _btnSave;
		private System.Windows.Forms.Button _btnRemove;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _btnLoad;
	}
}