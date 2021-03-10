namespace NoahWilson_GOL
{
    partial class UniverseDialog
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
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.xVal = new System.Windows.Forms.Label();
            this.yVal = new System.Windows.Forms.Label();
            this.UniverseXtxt = new System.Windows.Forms.TextBox();
            this.UniverseYtxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptButton.Location = new System.Drawing.Point(12, 91);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(93, 91);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // xVal
            // 
            this.xVal.AutoSize = true;
            this.xVal.Location = new System.Drawing.Point(8, 12);
            this.xVal.Name = "xVal";
            this.xVal.Size = new System.Drawing.Size(44, 13);
            this.xVal.TabIndex = 2;
            this.xVal.Text = "X Value";
            // 
            // yVal
            // 
            this.yVal.AutoSize = true;
            this.yVal.Location = new System.Drawing.Point(8, 53);
            this.yVal.Name = "yVal";
            this.yVal.Size = new System.Drawing.Size(44, 13);
            this.yVal.TabIndex = 3;
            this.yVal.Text = "Y Value";
            // 
            // UniverseXtxt
            // 
            this.UniverseXtxt.Location = new System.Drawing.Point(59, 12);
            this.UniverseXtxt.Name = "UniverseXtxt";
            this.UniverseXtxt.Size = new System.Drawing.Size(100, 20);
            this.UniverseXtxt.TabIndex = 4;
            // 
            // UniverseYtxt
            // 
            this.UniverseYtxt.Location = new System.Drawing.Point(58, 50);
            this.UniverseYtxt.Name = "UniverseYtxt";
            this.UniverseYtxt.Size = new System.Drawing.Size(100, 20);
            this.UniverseYtxt.TabIndex = 5;
            // 
            // UniverseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 126);
            this.Controls.Add(this.UniverseYtxt);
            this.Controls.Add(this.UniverseXtxt);
            this.Controls.Add(this.yVal);
            this.Controls.Add(this.xVal);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AcceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UniverseDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Universe Size";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UniverseDialog_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label xVal;
        private System.Windows.Forms.Label yVal;
        private System.Windows.Forms.TextBox UniverseXtxt;
        private System.Windows.Forms.TextBox UniverseYtxt;
    }
}