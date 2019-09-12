namespace Coolsoft.NetPinger
{
	partial class HostID
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
			this._txtHostID = new System.Windows.Forms.TextBox();
			this._btnClose = new System.Windows.Forms.Button();
			this._btnCopy = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Host ID:";
			// 
			// _txtHostID
			// 
			this._txtHostID.Location = new System.Drawing.Point(13, 30);
			this._txtHostID.Name = "_txtHostID";
			this._txtHostID.ReadOnly = true;
			this._txtHostID.Size = new System.Drawing.Size(259, 20);
			this._txtHostID.TabIndex = 1;
			// 
			// _btnClose
			// 
			this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnClose.Location = new System.Drawing.Point(197, 56);
			this._btnClose.Name = "_btnClose";
			this._btnClose.Size = new System.Drawing.Size(75, 23);
			this._btnClose.TabIndex = 3;
			this._btnClose.Text = "&Close";
			this._btnClose.UseVisualStyleBackColor = true;
			// 
			// _btnCopy
			// 
			this._btnCopy.Location = new System.Drawing.Point(116, 56);
			this._btnCopy.Name = "_btnCopy";
			this._btnCopy.Size = new System.Drawing.Size(75, 23);
			this._btnCopy.TabIndex = 2;
			this._btnCopy.Text = "Co&py";
			this._btnCopy.UseVisualStyleBackColor = true;
			this._btnCopy.Click += new System.EventHandler(this._btnCopy_Click);
			// 
			// HostID
			// 
			this.AcceptButton = this._btnClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 91);
			this.Controls.Add(this._btnCopy);
			this.Controls.Add(this._btnClose);
			this.Controls.Add(this._txtHostID);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HostID";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Host ID";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _txtHostID;
		private System.Windows.Forms.Button _btnClose;
		private System.Windows.Forms.Button _btnCopy;
	}
}