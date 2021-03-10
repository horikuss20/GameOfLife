namespace NoahWilson_GOL
{
    partial class UniverseTypeDialog
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
            this.FiniteButton = new System.Windows.Forms.Button();
            this.ToroidalButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FiniteButton
            // 
            this.FiniteButton.Location = new System.Drawing.Point(77, 27);
            this.FiniteButton.Name = "FiniteButton";
            this.FiniteButton.Size = new System.Drawing.Size(75, 23);
            this.FiniteButton.TabIndex = 0;
            this.FiniteButton.Text = "Finite";
            this.FiniteButton.UseVisualStyleBackColor = true;
            this.FiniteButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ToroidalButton
            // 
            this.ToroidalButton.Location = new System.Drawing.Point(77, 68);
            this.ToroidalButton.Name = "ToroidalButton";
            this.ToroidalButton.Size = new System.Drawing.Size(75, 23);
            this.ToroidalButton.TabIndex = 1;
            this.ToroidalButton.Text = "Toroidal";
            this.ToroidalButton.UseVisualStyleBackColor = true;
            this.ToroidalButton.Click += new System.EventHandler(this.ToroidalButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(77, 112);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // UniverseTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(247, 169);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ToroidalButton);
            this.Controls.Add(this.FiniteButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UniverseTypeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Universe Type";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FiniteButton;
        private System.Windows.Forms.Button ToroidalButton;
        private System.Windows.Forms.Button CancelButton;
    }
}