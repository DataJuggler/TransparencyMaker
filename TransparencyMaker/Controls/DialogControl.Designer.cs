

#region using statements


#endregion

namespace TransparencyMaker.Controls
{

    #region class DialogControl
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class DialogControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private TransparencyMaker.Controls.PanelExtender LeftMarginPanel;
        private TransparencyMaker.Controls.PanelExtender RightMarginPanel;
        private TransparencyMaker.Controls.PanelExtender TopMarginPanel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
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
            this.MessageLabel = new System.Windows.Forms.Label();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.TopMarginPanel = new TransparencyMaker.Controls.PanelExtender();
            this.RightMarginPanel = new TransparencyMaker.Controls.PanelExtender();
            this.LeftMarginPanel = new TransparencyMaker.Controls.PanelExtender();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageLabel.ForeColor = System.Drawing.Color.White;
            this.MessageLabel.Location = new System.Drawing.Point(16, 16);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(502, 34);
            this.MessageLabel.TabIndex = 4;
            this.MessageLabel.Text = "Are you sure you wish to delete the selected layer?";
            // 
            // YesButton
            // 
            this.YesButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.BlackButton;
            this.YesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YesButton.FlatAppearance.BorderSize = 0;
            this.YesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.YesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.YesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesButton.ForeColor = System.Drawing.Color.White;
            this.YesButton.Location = new System.Drawing.Point(232, 120);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(96, 40);
            this.YesButton.TabIndex = 97;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            this.YesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.YesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // NoButton
            // 
            this.NoButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.BlackButton;
            this.NoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NoButton.FlatAppearance.BorderSize = 0;
            this.NoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoButton.ForeColor = System.Drawing.Color.White;
            this.NoButton.Location = new System.Drawing.Point(343, 120);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(96, 40);
            this.NoButton.TabIndex = 98;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            this.NoButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.NoButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(80, 64);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(360, 32);
            this.TextBox.TabIndex = 99;
            // 
            // SaveButton
            // 
            this.SaveButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.BlackButton;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(232, 120);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 40);
            this.SaveButton.TabIndex = 100;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // CancelButton
            // 
            this.CancelButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.BlackButton;
            this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(343, 120);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(96, 40);
            this.CancelButton.TabIndex = 101;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.CancelButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CancelButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(16, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(502, 16);
            this.TopMarginPanel.TabIndex = 2;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(518, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 184);
            this.RightMarginPanel.TabIndex = 1;
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(16, 184);
            this.LeftMarginPanel.TabIndex = 0;
            // 
            // DialogControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::TransparencyMaker.Properties.Resources.Blue_Wall_Very_Small;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.Controls.Add(this.SaveButton);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DialogControl";
            this.Size = new System.Drawing.Size(534, 184);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
