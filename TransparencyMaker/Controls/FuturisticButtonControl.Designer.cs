

#region using statements


#endregion

namespace TransparencyMaker.Controls
{

    #region class FuturisticButtonControl
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class FuturisticButtonControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Panel BottomMarginPanel;
        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox Image;
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
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
            #endregion
            
            #region InitializeComponent()
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.BottomMarginPanel = new System.Windows.Forms.Panel();
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.TopMarginPanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(256, 4);
            this.TopMarginPanel.TabIndex = 0;
            this.TopMarginPanel.MouseEnter += new System.EventHandler(this.Button_Enter);
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(0, 252);
            this.BottomMarginPanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(256, 4);
            this.BottomMarginPanel.TabIndex = 2;
            this.BottomMarginPanel.MouseEnter += new System.EventHandler(this.Button_Enter);
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 4);
            this.LeftMarginPanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(4, 248);
            this.LeftMarginPanel.TabIndex = 3;
            this.LeftMarginPanel.MouseEnter += new System.EventHandler(this.Button_Enter);
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(252, 4);
            this.RightMarginPanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(4, 248);
            this.RightMarginPanel.TabIndex = 4;
            this.RightMarginPanel.MouseEnter += new System.EventHandler(this.Button_Enter);
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TitleLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.TitleLabel.Location = new System.Drawing.Point(4, 228);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(248, 24);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "Button Text";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleLabel.ForeColorChanged += new System.EventHandler(this.TitleLabel_ForeColorChanged);
            this.TitleLabel.Click += new System.EventHandler(this.Button_Click);
            this.TitleLabel.MouseEnter += new System.EventHandler(this.Button_Enter);
            // 
            // Image
            // 
            this.Image.BackColor = System.Drawing.Color.Transparent;
            this.Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image.ErrorImage = null;
            this.Image.InitialImage = null;
            this.Image.Location = new System.Drawing.Point(4, 4);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(248, 224);
            this.Image.TabIndex = 7;
            this.Image.TabStop = false;
            this.Image.Click += new System.EventHandler(this.Button_Click);
            this.Image.MouseEnter += new System.EventHandler(this.Button_Enter);
            // 
            // FuturisticButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Image);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FuturisticButtonControl";
            this.Size = new System.Drawing.Size(256, 256);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
