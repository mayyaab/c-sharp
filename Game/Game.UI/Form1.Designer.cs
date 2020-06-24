namespace Game.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PlaceBalls = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceBalls)).BeginInit();
            this.SuspendLayout();
            // 
            // PlaceBalls
            // 
            this.PlaceBalls.Image = ((System.Drawing.Image)(resources.GetObject("PlaceBalls.Image")));
            this.PlaceBalls.Location = new System.Drawing.Point(646, 12);
            this.PlaceBalls.Name = "PlaceBalls";
            this.PlaceBalls.Size = new System.Drawing.Size(199, 65);
            this.PlaceBalls.TabIndex = 0;
            this.PlaceBalls.TabStop = false;
            this.PlaceBalls.Click += new System.EventHandler(this.PlaceBalls_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 649);
            this.Controls.Add(this.PlaceBalls);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_PaintLines);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PlaceBalls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PlaceBalls;
    }
}

