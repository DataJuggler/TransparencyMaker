namespace TransparencyMaker.Controls
{
    partial class LayersControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LeftMargin = new TransparencyMaker.Controls.PanelExtender();
            this.TopMargin = new TransparencyMaker.Controls.PanelExtender();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.BottomMargin = new TransparencyMaker.Controls.PanelExtender();
            this.ButtonPanel = new TransparencyMaker.Controls.PanelExtender();
            this.FlattenButtoon = new System.Windows.Forms.Button();
            this.Seperator4 = new TransparencyMaker.Controls.PanelExtender();
            this.EditButton = new System.Windows.Forms.Button();
            this.Sepeartor4 = new TransparencyMaker.Controls.PanelExtender();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.Seperator3 = new TransparencyMaker.Controls.PanelExtender();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.Seperator2 = new TransparencyMaker.Controls.PanelExtender();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.Seperator = new TransparencyMaker.Controls.PanelExtender();
            this.AddButton = new System.Windows.Forms.Button();
            this.LayersPanel = new TransparencyMaker.Controls.PanelExtender();
            this.BackgroundLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonPanel.SuspendLayout();
            this.LayersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftMargin
            // 
            this.LeftMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMargin.Location = new System.Drawing.Point(0, 0);
            this.LeftMargin.Name = "LeftMargin";
            this.LeftMargin.Size = new System.Drawing.Size(8, 206);
            this.LeftMargin.TabIndex = 1;
            // 
            // TopMargin
            // 
            this.TopMargin.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMargin.Location = new System.Drawing.Point(8, 0);
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Size = new System.Drawing.Size(228, 8);
            this.TopMargin.TabIndex = 2;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(8, 8);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(228, 23);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Layer Name";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMargin.Location = new System.Drawing.Point(8, 198);
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Size = new System.Drawing.Size(228, 8);
            this.BottomMargin.TabIndex = 6;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.FlattenButtoon);
            this.ButtonPanel.Controls.Add(this.Seperator4);
            this.ButtonPanel.Controls.Add(this.EditButton);
            this.ButtonPanel.Controls.Add(this.Sepeartor4);
            this.ButtonPanel.Controls.Add(this.MoveDownButton);
            this.ButtonPanel.Controls.Add(this.Seperator3);
            this.ButtonPanel.Controls.Add(this.MoveUpButton);
            this.ButtonPanel.Controls.Add(this.Seperator2);
            this.ButtonPanel.Controls.Add(this.DeleteButton);
            this.ButtonPanel.Controls.Add(this.Seperator);
            this.ButtonPanel.Controls.Add(this.AddButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(8, 166);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(228, 32);
            this.ButtonPanel.TabIndex = 7;
            // 
            // FlattenButtoon
            // 
            this.FlattenButtoon.BackgroundImage = global::TransparencyMaker.Properties.Resources.SmallPancakeGray;
            this.FlattenButtoon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FlattenButtoon.Dock = System.Windows.Forms.DockStyle.Left;
            this.FlattenButtoon.Enabled = false;
            this.FlattenButtoon.FlatAppearance.BorderSize = 0;
            this.FlattenButtoon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FlattenButtoon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FlattenButtoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlattenButtoon.Location = new System.Drawing.Point(182, 0);
            this.FlattenButtoon.Name = "FlattenButtoon";
            this.FlattenButtoon.Size = new System.Drawing.Size(32, 32);
            this.FlattenButtoon.TabIndex = 11;
            this.ToolTip.SetToolTip(this.FlattenButtoon, "Flatten all layers.");
            this.FlattenButtoon.UseVisualStyleBackColor = true;
            this.FlattenButtoon.EnabledChanged += new System.EventHandler(this.FlattenButtoon_EnabledChanged);
            this.FlattenButtoon.Click += new System.EventHandler(this.FlattenButtoon_Click);
            this.FlattenButtoon.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.FlattenButtoon.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Seperator4
            // 
            this.Seperator4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Seperator4.Location = new System.Drawing.Point(174, 0);
            this.Seperator4.Name = "Seperator4";
            this.Seperator4.Size = new System.Drawing.Size(8, 32);
            this.Seperator4.TabIndex = 10;
            // 
            // EditButton
            // 
            this.EditButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.Pencil_TransparentGray;
            this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.EditButton.Enabled = false;
            this.EditButton.FlatAppearance.BorderSize = 0;
            this.EditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Location = new System.Drawing.Point(142, 0);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(32, 32);
            this.EditButton.TabIndex = 9;
            this.ToolTip.SetToolTip(this.EditButton, "Edit the name of the selected layer.");
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.EnabledChanged += new System.EventHandler(this.EditButton_EnabledChanged);
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            this.EditButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.EditButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Sepeartor4
            // 
            this.Sepeartor4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sepeartor4.Location = new System.Drawing.Point(140, 0);
            this.Sepeartor4.Name = "Sepeartor4";
            this.Sepeartor4.Size = new System.Drawing.Size(2, 32);
            this.Sepeartor4.TabIndex = 8;
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.BlueArrowDownGray;
            this.MoveDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveDownButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.MoveDownButton.Enabled = false;
            this.MoveDownButton.FlatAppearance.BorderSize = 0;
            this.MoveDownButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MoveDownButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MoveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveDownButton.Location = new System.Drawing.Point(108, 0);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(32, 32);
            this.MoveDownButton.TabIndex = 7;
            this.ToolTip.SetToolTip(this.MoveDownButton, "Move the selected layer down.");
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.EnabledChanged += new System.EventHandler(this.MoveDownButton_EnabledChanged);
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            this.MoveDownButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.MoveDownButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Seperator3
            // 
            this.Seperator3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Seperator3.Location = new System.Drawing.Point(106, 0);
            this.Seperator3.Name = "Seperator3";
            this.Seperator3.Size = new System.Drawing.Size(2, 32);
            this.Seperator3.TabIndex = 6;
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.BlueArrowUpGray;
            this.MoveUpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveUpButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.MoveUpButton.Enabled = false;
            this.MoveUpButton.FlatAppearance.BorderSize = 0;
            this.MoveUpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MoveUpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MoveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveUpButton.Location = new System.Drawing.Point(74, 0);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(32, 32);
            this.MoveUpButton.TabIndex = 5;
            this.ToolTip.SetToolTip(this.MoveUpButton, "Move the selected layer up.");
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.EnabledChanged += new System.EventHandler(this.MoveUpButton_EnabledChanged);
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            this.MoveUpButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.MoveUpButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Seperator2
            // 
            this.Seperator2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Seperator2.Location = new System.Drawing.Point(72, 0);
            this.Seperator2.Name = "Seperator2";
            this.Seperator2.Size = new System.Drawing.Size(2, 32);
            this.Seperator2.TabIndex = 4;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.DeleteButtonXGray;
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Location = new System.Drawing.Point(40, 0);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(32, 32);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.EnabledChanged += new System.EventHandler(this.DeleteButton_EnabledChanged);
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.DeleteButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.DeleteButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Seperator
            // 
            this.Seperator.Dock = System.Windows.Forms.DockStyle.Left;
            this.Seperator.Location = new System.Drawing.Point(32, 0);
            this.Seperator.Name = "Seperator";
            this.Seperator.Size = new System.Drawing.Size(8, 32);
            this.Seperator.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.Add_Button_Small;
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(32, 32);
            this.AddButton.TabIndex = 0;
            this.ToolTip.SetToolTip(this.AddButton, "Add a new layer.");
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            this.AddButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.AddButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // LayersPanel
            // 
            this.LayersPanel.Controls.Add(this.BackgroundLabel);
            this.LayersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayersPanel.Location = new System.Drawing.Point(8, 31);
            this.LayersPanel.Name = "LayersPanel";
            this.LayersPanel.Size = new System.Drawing.Size(228, 135);
            this.LayersPanel.TabIndex = 9;
            this.ToolTip.SetToolTip(this.LayersPanel, "Delete the selected layer.");
            // 
            // BackgroundLabel
            // 
            this.BackgroundLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BackgroundLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackgroundLabel.ForeColor = System.Drawing.Color.White;
            this.BackgroundLabel.Location = new System.Drawing.Point(0, 0);
            this.BackgroundLabel.Name = "BackgroundLabel";
            this.BackgroundLabel.Size = new System.Drawing.Size(228, 23);
            this.BackgroundLabel.TabIndex = 5;
            this.BackgroundLabel.Text = "Background";
            this.BackgroundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LayersControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LayersPanel);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.BottomMargin);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TopMargin);
            this.Controls.Add(this.LeftMargin);
            this.Name = "LayersControl";
            this.Size = new System.Drawing.Size(236, 206);
            this.ButtonPanel.ResumeLayout(false);
            this.LayersPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private PanelExtender LeftMargin;
        private PanelExtender TopMargin;
        private System.Windows.Forms.Label TitleLabel;
        private PanelExtender BottomMargin;
        private PanelExtender ButtonPanel;
        private PanelExtender Seperator;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button MoveDownButton;
        private PanelExtender Seperator3;
        private PanelExtender Seperator2;
        private System.Windows.Forms.Button EditButton;
        private PanelExtender Sepeartor4;
        private PanelExtender LayersPanel;
        private System.Windows.Forms.Label BackgroundLabel;
        private System.Windows.Forms.Button FlattenButtoon;
        private PanelExtender Seperator4;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}
