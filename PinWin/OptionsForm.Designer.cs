namespace PinWin
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.butCancel = new System.Windows.Forms.Button();
            this.butSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panHotKey = new System.Windows.Forms.Panel();
            this.butHotKey = new System.Windows.Forms.Button();
            this.txtHotKey = new System.Windows.Forms.TextBox();
            this.chkHotKey = new System.Windows.Forms.CheckBox();
            this.numLimit = new System.Windows.Forms.NumericUpDown();
            this.chkTruncateTitle = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panHotKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimit)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(287, 170);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(85, 25);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butSubmit
            // 
            this.butSubmit.Location = new System.Drawing.Point(196, 170);
            this.butSubmit.Name = "butSubmit";
            this.butSubmit.Size = new System.Drawing.Size(85, 25);
            this.butSubmit.TabIndex = 1;
            this.butSubmit.Text = "OK";
            this.butSubmit.UseVisualStyleBackColor = true;
            this.butSubmit.Click += new System.EventHandler(this.butSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panHotKey);
            this.groupBox1.Controls.Add(this.chkHotKey);
            this.groupBox1.Controls.Add(this.numLimit);
            this.groupBox1.Controls.Add(this.chkTruncateTitle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // panHotKey
            // 
            this.panHotKey.Controls.Add(this.butHotKey);
            this.panHotKey.Controls.Add(this.txtHotKey);
            this.panHotKey.Location = new System.Drawing.Point(151, 45);
            this.panHotKey.Name = "panHotKey";
            this.panHotKey.Size = new System.Drawing.Size(203, 25);
            this.panHotKey.TabIndex = 5;
            // 
            // butHotKey
            // 
            this.butHotKey.Location = new System.Drawing.Point(128, 1);
            this.butHotKey.Name = "butHotKey";
            this.butHotKey.Size = new System.Drawing.Size(75, 23);
            this.butHotKey.TabIndex = 4;
            this.butHotKey.Text = "Change";
            this.butHotKey.UseVisualStyleBackColor = true;
            this.butHotKey.Click += new System.EventHandler(this.butHotKey_Click);
            // 
            // txtHotKey
            // 
            this.txtHotKey.Location = new System.Drawing.Point(0, 3);
            this.txtHotKey.Name = "txtHotKey";
            this.txtHotKey.ReadOnly = true;
            this.txtHotKey.Size = new System.Drawing.Size(122, 20);
            this.txtHotKey.TabIndex = 2;
            // 
            // chkHotKey
            // 
            this.chkHotKey.AutoSize = true;
            this.chkHotKey.Location = new System.Drawing.Point(6, 50);
            this.chkHotKey.Name = "chkHotKey";
            this.chkHotKey.Size = new System.Drawing.Size(123, 17);
            this.chkHotKey.TabIndex = 3;
            this.chkHotKey.Text = "Use a global hot key";
            this.chkHotKey.UseVisualStyleBackColor = true;
            this.chkHotKey.CheckedChanged += new System.EventHandler(this.chkHotKey_CheckedChanged);
            // 
            // numLimit
            // 
            this.numLimit.Location = new System.Drawing.Point(151, 19);
            this.numLimit.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numLimit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLimit.Name = "numLimit";
            this.numLimit.Size = new System.Drawing.Size(90, 20);
            this.numLimit.TabIndex = 1;
            this.numLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLimit.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chkTruncateTitle
            // 
            this.chkTruncateTitle.AutoSize = true;
            this.chkTruncateTitle.Location = new System.Drawing.Point(6, 20);
            this.chkTruncateTitle.Name = "chkTruncateTitle";
            this.chkTruncateTitle.Size = new System.Drawing.Size(132, 17);
            this.chkTruncateTitle.TabIndex = 0;
            this.chkTruncateTitle.Text = "Truncate window titles";
            this.chkTruncateTitle.UseVisualStyleBackColor = true;
            this.chkTruncateTitle.CheckedChanged += new System.EventHandler(this.chkTruncateTitle_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkUpdates);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application";
            // 
            // chkUpdates
            // 
            this.chkUpdates.AutoSize = true;
            this.chkUpdates.Location = new System.Drawing.Point(6, 19);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Size = new System.Drawing.Size(195, 17);
            this.chkUpdates.TabIndex = 1;
            this.chkUpdates.Text = "Always check for updates at startup";
            this.chkUpdates.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.butSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(384, 206);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butSubmit);
            this.Controls.Add(this.butCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "PinWin - Options";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panHotKey.ResumeLayout(false);
            this.panHotKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkTruncateTitle;
        private System.Windows.Forms.Panel panHotKey;
        private System.Windows.Forms.Button butHotKey;
        private System.Windows.Forms.TextBox txtHotKey;
        private System.Windows.Forms.CheckBox chkHotKey;
        private System.Windows.Forms.NumericUpDown numLimit;
        private System.Windows.Forms.CheckBox chkUpdates;
    }
}