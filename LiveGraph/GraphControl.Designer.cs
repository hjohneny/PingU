namespace LiveGraph
{
	partial class GraphControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this._panelContainer = new System.Windows.Forms.SplitContainer();
			this._graphPanel = new LiveGraph.GraphControl.GraphPanel();
			this._seriesLabelsPanel = new System.Windows.Forms.FlowLayoutPanel();
			this._addGraphLabel = new System.Windows.Forms.LinkLabel();
			this._tipPointValue = new System.Windows.Forms.ToolTip(this.components);
			this._panelContainer.Panel1.SuspendLayout();
			this._panelContainer.Panel2.SuspendLayout();
			this._panelContainer.SuspendLayout();
			this._seriesLabelsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _panelContainer
			// 
			this._panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this._panelContainer.Location = new System.Drawing.Point(0, 0);
			this._panelContainer.Name = "_panelContainer";
			this._panelContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// _panelContainer.Panel1
			// 
			this._panelContainer.Panel1.Controls.Add(this._graphPanel);
			// 
			// _panelContainer.Panel2
			// 
			this._panelContainer.Panel2.Controls.Add(this._seriesLabelsPanel);
			this._panelContainer.Size = new System.Drawing.Size(521, 309);
			this._panelContainer.SplitterDistance = 249;
			this._panelContainer.TabIndex = 0;
			// 
			// _graphPanel
			// 
			this._graphPanel.BackColor = System.Drawing.Color.White;
			this._graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._graphPanel.Location = new System.Drawing.Point(0, 0);
			this._graphPanel.Name = "_graphPanel";
			this._graphPanel.Size = new System.Drawing.Size(521, 249);
			this._graphPanel.TabIndex = 1;
			this._graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
			this._graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this._graphPanel_MouseMove);
			this._graphPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this._graphPanel_MouseClick);
			this._graphPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this._graphPanel_MouseDown);
			this._graphPanel.Resize += new System.EventHandler(this.graphPanel_Resize);
			this._graphPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this._graphPanel_MouseUp);
			// 
			// _seriesLabelsPanel
			// 
			this._seriesLabelsPanel.AutoScroll = true;
			this._seriesLabelsPanel.Controls.Add(this._addGraphLabel);
			this._seriesLabelsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._seriesLabelsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this._seriesLabelsPanel.Location = new System.Drawing.Point(0, 0);
			this._seriesLabelsPanel.Name = "_seriesLabelsPanel";
			this._seriesLabelsPanel.Size = new System.Drawing.Size(521, 56);
			this._seriesLabelsPanel.TabIndex = 0;
			// 
			// _addGraphLabel
			// 
			this._addGraphLabel.ActiveLinkColor = System.Drawing.Color.Black;
			this._addGraphLabel.AutoSize = true;
			this._addGraphLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this._addGraphLabel.LinkColor = System.Drawing.Color.Black;
			this._addGraphLabel.Location = new System.Drawing.Point(3, 0);
			this._addGraphLabel.Name = "_addGraphLabel";
			this._addGraphLabel.Size = new System.Drawing.Size(67, 13);
			this._addGraphLabel.TabIndex = 0;
			this._addGraphLabel.TabStop = true;
			this._addGraphLabel.Text = "Add Graph...";
			this._addGraphLabel.VisitedLinkColor = System.Drawing.Color.Black;
			this._addGraphLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._addGraphLabel_LinkClicked);
			// 
			// GraphControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._panelContainer);
			this.Name = "GraphControl";
			this.Size = new System.Drawing.Size(521, 309);
			this._panelContainer.Panel1.ResumeLayout(false);
			this._panelContainer.Panel2.ResumeLayout(false);
			this._panelContainer.ResumeLayout(false);
			this._seriesLabelsPanel.ResumeLayout(false);
			this._seriesLabelsPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer _panelContainer;
		private GraphControl.GraphPanel _graphPanel;
		private System.Windows.Forms.FlowLayoutPanel _seriesLabelsPanel;
		private System.Windows.Forms.LinkLabel _addGraphLabel;
		private System.Windows.Forms.ToolTip _tipPointValue;
	}
}
