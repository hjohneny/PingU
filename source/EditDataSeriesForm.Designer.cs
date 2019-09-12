namespace NetPinger
{
	partial class EditDataSeriesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDataSeriesForm));
            this.label2 = new System.Windows.Forms.Label();
            this._cmbSeries = new System.Windows.Forms.ComboBox();
            this._txtName = new System.Windows.Forms.TextBox();
            this._btnSet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._btnClose = new System.Windows.Forms.Button();
            this._spnDepth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._spnDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Source:";
            // 
            // _cmbSeries
            // 
            this._cmbSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbSeries.FormattingEnabled = true;
            this._cmbSeries.Location = new System.Drawing.Point(62, 9);
            this._cmbSeries.Name = "_cmbSeries";
            this._cmbSeries.Size = new System.Drawing.Size(462, 21);
            this._cmbSeries.TabIndex = 3;
            this._cmbSeries.SelectedIndexChanged += new System.EventHandler(this._cmbSeries_SelectedIndexChanged);
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(62, 37);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(462, 20);
            this._txtName.TabIndex = 5;
            // 
            // _btnSet
            // 
            this._btnSet.Location = new System.Drawing.Point(449, 106);
            this._btnSet.Name = "_btnSet";
            this._btnSet.Size = new System.Drawing.Size(75, 23);
            this._btnSet.TabIndex = 8;
            this._btnSet.Text = "&Set";
            this._btnSet.UseVisualStyleBackColor = true;
            this._btnSet.Click += new System.EventHandler(this._btnSet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Name:";
            // 
            // _btnClose
            // 
            this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnClose.Location = new System.Drawing.Point(449, 151);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 23);
            this._btnClose.TabIndex = 9;
            this._btnClose.Text = "&Close";
            this._btnClose.UseVisualStyleBackColor = true;
            // 
            // _spnDepth
            // 
            this._spnDepth.Location = new System.Drawing.Point(62, 106);
            this._spnDepth.Name = "_spnDepth";
            this._spnDepth.Size = new System.Drawing.Size(120, 20);
            this._spnDepth.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(454, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "%hostname% - name of the host, %ip% - IP addres of the host, %source% - name of d" +
    "ata source";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Variables that can be used in name template:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "&History:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "(0 indicates that history depth is infinite)";
            // 
            // EditDataSeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnClose;
            this.ClientSize = new System.Drawing.Size(536, 186);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._spnDepth);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._btnSet);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cmbSeries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDataSeriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Data Series";
            ((System.ComponentModel.ISupportInitialize)(this._spnDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox _cmbSeries;
		private System.Windows.Forms.TextBox _txtName;
		private System.Windows.Forms.Button _btnSet;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button _btnClose;
		private System.Windows.Forms.NumericUpDown _spnDepth;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
	}
}