namespace LiveGraph
{
	partial class AddGraphDlg
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
			this.label1 = new System.Windows.Forms.Label();
			this._txtGraphName = new System.Windows.Forms.TextBox();
			this._spnResolution = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this._chkShowTime = new System.Windows.Forms.CheckBox();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._spnResolution)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Graph &Name:";
			// 
			// _txtGraphName
			// 
			this._txtGraphName.Location = new System.Drawing.Point(88, 12);
			this._txtGraphName.Name = "_txtGraphName";
			this._txtGraphName.Size = new System.Drawing.Size(165, 20);
			this._txtGraphName.TabIndex = 1;
			// 
			// _spnResolution
			// 
			this._spnResolution.Location = new System.Drawing.Point(88, 39);
			this._spnResolution.Maximum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this._spnResolution.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this._spnResolution.Name = "_spnResolution";
			this._spnResolution.Size = new System.Drawing.Size(165, 20);
			this._spnResolution.TabIndex = 3;
			this._spnResolution.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "&Resolution:";
			// 
			// _chkShowTime
			// 
			this._chkShowTime.AutoSize = true;
			this._chkShowTime.Location = new System.Drawing.Point(88, 66);
			this._chkShowTime.Name = "_chkShowTime";
			this._chkShowTime.Size = new System.Drawing.Size(113, 17);
			this._chkShowTime.TabIndex = 4;
			this._chkShowTime.Text = "&Show Time Labels";
			this._chkShowTime.UseVisualStyleBackColor = true;
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(178, 116);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 6;
			this._btnCancel.Text = "&Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOK
			// 
			this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOK.Location = new System.Drawing.Point(97, 116);
			this._btnOK.Name = "_btnOK";
			this._btnOK.Size = new System.Drawing.Size(75, 23);
			this._btnOK.TabIndex = 5;
			this._btnOK.Text = "&OK";
			this._btnOK.UseVisualStyleBackColor = true;
			// 
			// AddGraphDlg
			// 
			this.AcceptButton = this._btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(265, 151);
			this.ControlBox = false;
			this.Controls.Add(this._btnOK);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._chkShowTime);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._spnResolution);
			this.Controls.Add(this._txtGraphName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AddGraphDlg";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Graph";
			((System.ComponentModel.ISupportInitialize)(this._spnResolution)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _txtGraphName;
		private System.Windows.Forms.NumericUpDown _spnResolution;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox _chkShowTime;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOK;
	}
}