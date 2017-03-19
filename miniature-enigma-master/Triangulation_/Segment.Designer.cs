namespace Triangulation_
{
    partial class Segment
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
            this.newSegPictureBox = new System.Windows.Forms.PictureBox();
            this.newSegPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.newSegPictureBox)).BeginInit();
            this.newSegPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // newSegPictureBox
            // 
            this.newSegPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newSegPictureBox.Location = new System.Drawing.Point(0, 0);
            this.newSegPictureBox.Name = "newSegPictureBox";
            this.newSegPictureBox.Size = new System.Drawing.Size(1000, 800);
            this.newSegPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.newSegPictureBox.TabIndex = 0;
            this.newSegPictureBox.TabStop = false;
            // 
            // newSegPanel
            // 
            this.newSegPanel.AutoScroll = true;
            this.newSegPanel.Controls.Add(this.newSegPictureBox);
            this.newSegPanel.Location = new System.Drawing.Point(12, 12);
            this.newSegPanel.Name = "newSegPanel";
            this.newSegPanel.Size = new System.Drawing.Size(882, 586);
            this.newSegPanel.TabIndex = 1;
            // 
            // Segment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(906, 610);
            this.Controls.Add(this.newSegPanel);
            this.Name = "Segment";
            this.Text = "Увеличенный выбранный сегмент";
            ((System.ComponentModel.ISupportInitialize)(this.newSegPictureBox)).EndInit();
            this.newSegPanel.ResumeLayout(false);
            this.newSegPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox newSegPictureBox;
        private System.Windows.Forms.Panel newSegPanel;
    }
}