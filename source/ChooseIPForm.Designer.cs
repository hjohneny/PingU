namespace NetPinger
{
	partial class ChooseIPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseIPForm));
            this.label1 = new System.Windows.Forms.Label();
            this._lbIPAdresses = new System.Windows.Forms.ListBox();
            this._btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Multiple IP address has been detected for specified host name. Please choose one:" +
    "";
            // 
            // _lbIPAdresses
            // 
            this._lbIPAdresses.FormattingEnabled = true;
            this._lbIPAdresses.Location = new System.Drawing.Point(13, 46);
            this._lbIPAdresses.Name = "_lbIPAdresses";
            this._lbIPAdresses.Size = new System.Drawing.Size(203, 173);
            this._lbIPAdresses.TabIndex = 1;
            this._lbIPAdresses.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._lbIPAdresses_MouseDoubleClick);
            // 
            // _btnSelect
            // 
            this._btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnSelect.Location = new System.Drawing.Point(141, 227);
            this._btnSelect.Name = "_btnSelect";
            this._btnSelect.Size = new System.Drawing.Size(75, 23);
            this._btnSelect.TabIndex = 2;
            this._btnSelect.Text = "&Select";
            this._btnSelect.UseVisualStyleBackColor = true;
            // 
            // ChooseIPForm
            // 
            this.AcceptButton = this._btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 262);
            this.Controls.Add(this._btnSelect);
            this.Controls.Add(this._lbIPAdresses);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseIPForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose IP Address";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox _lbIPAdresses;
		private System.Windows.Forms.Button _btnSelect;
	}
}