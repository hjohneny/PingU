namespace NetPinger
{
	partial class AddDataSeriesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDataSeriesForm));
            this.label1 = new System.Windows.Forms.Label();
            this._cmbHost = new System.Windows.Forms.ComboBox();
            this._cmbSeries = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._pnlColor = new System.Windows.Forms.Panel();
            this._btnChooseColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Host:";
            // 
            // _cmbHost
            // 
            this._cmbHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbHost.FormattingEnabled = true;
            this._cmbHost.Location = new System.Drawing.Point(62, 12);
            this._cmbHost.Name = "_cmbHost";
            this._cmbHost.Size = new System.Drawing.Size(462, 21);
            this._cmbHost.TabIndex = 1;
            this._cmbHost.SelectedIndexChanged += new System.EventHandler(this._cmbHost_SelectedIndexChanged);
            // 
            // _cmbSeries
            // 
            this._cmbSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbSeries.FormattingEnabled = true;
            this._cmbSeries.Location = new System.Drawing.Point(62, 39);
            this._cmbSeries.Name = "_cmbSeries";
            this._cmbSeries.Size = new System.Drawing.Size(462, 21);
            this._cmbSeries.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Source:";
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(449, 107);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(368, 107);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 5;
            this._btnOK.Text = "&OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _pnlColor
            // 
            this._pnlColor.BackColor = System.Drawing.Color.Black;
            this._pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlColor.Location = new System.Drawing.Point(62, 67);
            this._pnlColor.Name = "_pnlColor";
            this._pnlColor.Size = new System.Drawing.Size(380, 21);
            this._pnlColor.TabIndex = 8;
            // 
            // _btnChooseColor
            // 
            this._btnChooseColor.Location = new System.Drawing.Point(449, 67);
            this._btnChooseColor.Name = "_btnChooseColor";
            this._btnChooseColor.Size = new System.Drawing.Size(75, 23);
            this._btnChooseColor.TabIndex = 4;
            this._btnChooseColor.Text = "&Choose...";
            this._btnChooseColor.UseVisualStyleBackColor = true;
            this._btnChooseColor.Click += new System.EventHandler(this._btnChooseColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Color:";
            // 
            // AddDataSeriesForm
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 142);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._btnChooseColor);
            this.Controls.Add(this._pnlColor);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cmbSeries);
            this.Controls.Add(this._cmbHost);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDataSeriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Data Series View";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _cmbHost;
		private System.Windows.Forms.ComboBox _cmbSeries;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.Panel _pnlColor;
		private System.Windows.Forms.Button _btnChooseColor;
		private System.Windows.Forms.Label label3;
	}
}