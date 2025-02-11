namespace MandelbrotApp
{
    partial class ColormapForm
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
            this.Pick1Button = new System.Windows.Forms.Button();
            this.colormapPictureBox = new System.Windows.Forms.PictureBox();
            this.saveLoadButton = new System.Windows.Forms.Button();
            this.Pick2Button = new System.Windows.Forms.Button();
            this.Pick4Button = new System.Windows.Forms.Button();
            this.Pick5Button = new System.Windows.Forms.Button();
            this.Pick3Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.colormapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Pick1Button
            // 
            this.Pick1Button.Location = new System.Drawing.Point(12, 118);
            this.Pick1Button.Name = "Pick1Button";
            this.Pick1Button.Size = new System.Drawing.Size(32, 32);
            this.Pick1Button.TabIndex = 0;
            this.Pick1Button.UseVisualStyleBackColor = true;
            this.Pick1Button.Click += new System.EventHandler(this.Pick1Button_Click);
            // 
            // colormapPictureBox
            // 
            this.colormapPictureBox.Location = new System.Drawing.Point(12, 12);
            this.colormapPictureBox.Name = "colormapPictureBox";
            this.colormapPictureBox.Size = new System.Drawing.Size(767, 100);
            this.colormapPictureBox.TabIndex = 5;
            this.colormapPictureBox.TabStop = false;
            // 
            // saveLoadButton
            // 
            this.saveLoadButton.Location = new System.Drawing.Point(649, 156);
            this.saveLoadButton.Name = "saveLoadButton";
            this.saveLoadButton.Size = new System.Drawing.Size(130, 23);
            this.saveLoadButton.TabIndex = 6;
            this.saveLoadButton.Text = "Save And Load";
            this.saveLoadButton.UseVisualStyleBackColor = true;
            this.saveLoadButton.Click += new System.EventHandler(this.saveLoadButton_Click);
            // 
            // Pick2Button
            // 
            this.Pick2Button.Location = new System.Drawing.Point(182, 118);
            this.Pick2Button.Name = "Pick2Button";
            this.Pick2Button.Size = new System.Drawing.Size(32, 32);
            this.Pick2Button.TabIndex = 7;
            this.Pick2Button.UseVisualStyleBackColor = true;
            this.Pick2Button.Click += new System.EventHandler(this.Pick2Button_Click);
            // 
            // Pick4Button
            // 
            this.Pick4Button.Location = new System.Drawing.Point(490, 118);
            this.Pick4Button.Name = "Pick4Button";
            this.Pick4Button.Size = new System.Drawing.Size(32, 32);
            this.Pick4Button.TabIndex = 8;
            this.Pick4Button.UseVisualStyleBackColor = true;
            this.Pick4Button.Click += new System.EventHandler(this.Pick4Button_Click);
            // 
            // Pick5Button
            // 
            this.Pick5Button.Location = new System.Drawing.Point(649, 118);
            this.Pick5Button.Name = "Pick5Button";
            this.Pick5Button.Size = new System.Drawing.Size(32, 32);
            this.Pick5Button.TabIndex = 9;
            this.Pick5Button.UseVisualStyleBackColor = true;
            this.Pick5Button.Click += new System.EventHandler(this.Pick5Button_Click);
            // 
            // Pick3Button
            // 
            this.Pick3Button.BackColor = System.Drawing.Color.Transparent;
            this.Pick3Button.ForeColor = System.Drawing.Color.Black;
            this.Pick3Button.Location = new System.Drawing.Point(328, 118);
            this.Pick3Button.Name = "Pick3Button";
            this.Pick3Button.Size = new System.Drawing.Size(32, 32);
            this.Pick3Button.TabIndex = 10;
            this.Pick3Button.UseVisualStyleBackColor = false;
            this.Pick3Button.Click += new System.EventHandler(this.Pick3Button_Click);
            // 
            // ColormapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 188);
            this.Controls.Add(this.Pick3Button);
            this.Controls.Add(this.Pick5Button);
            this.Controls.Add(this.Pick4Button);
            this.Controls.Add(this.Pick2Button);
            this.Controls.Add(this.saveLoadButton);
            this.Controls.Add(this.colormapPictureBox);
            this.Controls.Add(this.Pick1Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ColormapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColormapForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColormapForm_FormClosing);
            this.Load += new System.EventHandler(this.ColormapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colormapPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Pick1Button;
        private System.Windows.Forms.PictureBox colormapPictureBox;
        private System.Windows.Forms.Button saveLoadButton;
        private System.Windows.Forms.Button Pick2Button;
        private System.Windows.Forms.Button Pick4Button;
        private System.Windows.Forms.Button Pick5Button;
        private System.Windows.Forms.Button Pick3Button;
    }
}