

#region using statements


#endregion

namespace TransparencyMaker
{

    #region class MainForm
    /// <summary>
    /// This is the designer for the MainForm
    /// </summary>
    partial class MainForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Panel BottomMarginPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.PictureBox StartButton;
        private System.Windows.Forms.Panel Separator2;
        private System.Windows.Forms.Panel Separator1;
        private System.Windows.Forms.Panel GraphPanel;
        private System.Windows.Forms.ProgressBar Graph;
        private Controls.PixelInformationControl PixelInfo;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.BottomMarginPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.IconBottomPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.PictureBox();
            this.IconTopPanel = new System.Windows.Forms.Panel();
            this.RectangleButton = new System.Windows.Forms.PictureBox();
            this.Margin7 = new System.Windows.Forms.Panel();
            this.ColorPickerButton = new TransparencyMaker.Controls.FuturisticButtonControl();
            this.Margin6 = new System.Windows.Forms.Panel();
            this.UndoChangesButton = new TransparencyMaker.Controls.FuturisticButtonControl();
            this.Margin5 = new System.Windows.Forms.Panel();
            this.ResetButton = new TransparencyMaker.Controls.FuturisticButtonControl();
            this.Margin4 = new System.Windows.Forms.Panel();
            this.SaveAsButton = new TransparencyMaker.Controls.FuturisticButtonControl();
            this.Margin3 = new System.Windows.Forms.Panel();
            this.SaveButton = new TransparencyMaker.Controls.FuturisticButtonControl();
            this.Margin2 = new System.Windows.Forms.Panel();
            this.CloseFileButton = new TransparencyMaker.Controls.FuturisticButtonControl();
            this.Margin1 = new System.Windows.Forms.Panel();
            this.ButtonMarginPanel = new System.Windows.Forms.Panel();
            this.YouTubePanel = new System.Windows.Forms.Panel();
            this.YouTubeButton = new System.Windows.Forms.PictureBox();
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.Graph = new System.Windows.Forms.ProgressBar();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.PixelInfo = new TransparencyMaker.Controls.PixelInformationControl();
            this.QueryPanel = new System.Windows.Forms.Panel();
            this.QueryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MessagesTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new TransparencyMaker.Controls.FuturisticButtonControl();
            this.Separator2 = new System.Windows.Forms.Panel();
            this.Separator1 = new System.Windows.Forms.Panel();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.PictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonPanel.SuspendLayout();
            this.IconBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateButton)).BeginInit();
            this.IconTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RectangleButton)).BeginInit();
            this.YouTubePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YouTubeButton)).BeginInit();
            this.GraphPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.QueryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartButton)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftMarginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(32, 746);
            this.LeftMarginPanel.TabIndex = 2;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightMarginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(1684, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(32, 746);
            this.RightMarginPanel.TabIndex = 3;
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopMarginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(32, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(1652, 32);
            this.TopMarginPanel.TabIndex = 4;
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(32, 714);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(1652, 32);
            this.BottomMarginPanel.TabIndex = 5;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonPanel.Controls.Add(this.IconBottomPanel);
            this.ButtonPanel.Controls.Add(this.IconTopPanel);
            this.ButtonPanel.Controls.Add(this.Margin7);
            this.ButtonPanel.Controls.Add(this.ColorPickerButton);
            this.ButtonPanel.Controls.Add(this.Margin6);
            this.ButtonPanel.Controls.Add(this.UndoChangesButton);
            this.ButtonPanel.Controls.Add(this.Margin5);
            this.ButtonPanel.Controls.Add(this.ResetButton);
            this.ButtonPanel.Controls.Add(this.Margin4);
            this.ButtonPanel.Controls.Add(this.SaveAsButton);
            this.ButtonPanel.Controls.Add(this.Margin3);
            this.ButtonPanel.Controls.Add(this.SaveButton);
            this.ButtonPanel.Controls.Add(this.Margin2);
            this.ButtonPanel.Controls.Add(this.CloseFileButton);
            this.ButtonPanel.Controls.Add(this.Margin1);
            this.ButtonPanel.Controls.Add(this.ButtonMarginPanel);
            this.ButtonPanel.Controls.Add(this.YouTubePanel);
            this.ButtonPanel.Controls.Add(this.GraphPanel);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(32, 582);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(1652, 132);
            this.ButtonPanel.TabIndex = 7;
            this.ButtonPanel.Visible = false;
            // 
            // IconBottomPanel
            // 
            this.IconBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.IconBottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IconBottomPanel.Controls.Add(this.pictureBox1);
            this.IconBottomPanel.Controls.Add(this.panel1);
            this.IconBottomPanel.Controls.Add(this.UpdateButton);
            this.IconBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.IconBottomPanel.Location = new System.Drawing.Point(688, 84);
            this.IconBottomPanel.Name = "IconBottomPanel";
            this.IconBottomPanel.Size = new System.Drawing.Size(836, 48);
            this.IconBottomPanel.TabIndex = 82;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(60, 0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(48, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            this.ToolTip.SetToolTip(this.pictureBox1, "Update Mode");
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(48, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(12, 48);
            this.panel1.TabIndex = 82;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.UpdateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpdateButton.BackgroundImage")));
            this.UpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.UpdateButton.Location = new System.Drawing.Point(0, 0);
            this.UpdateButton.MaximumSize = new System.Drawing.Size(48, 48);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(48, 48);
            this.UpdateButton.TabIndex = 81;
            this.UpdateButton.TabStop = false;
            this.ToolTip.SetToolTip(this.UpdateButton, "Update Mode");
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            this.UpdateButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.UpdateButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // IconTopPanel
            // 
            this.IconTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.IconTopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IconTopPanel.Controls.Add(this.RectangleButton);
            this.IconTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.IconTopPanel.Location = new System.Drawing.Point(688, 28);
            this.IconTopPanel.Name = "IconTopPanel";
            this.IconTopPanel.Size = new System.Drawing.Size(836, 48);
            this.IconTopPanel.TabIndex = 81;
            // 
            // RectangleButton
            // 
            this.RectangleButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.RectangleButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.Rectanble;
            this.RectangleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RectangleButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.RectangleButton.Location = new System.Drawing.Point(0, 0);
            this.RectangleButton.MaximumSize = new System.Drawing.Size(48, 48);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(48, 48);
            this.RectangleButton.TabIndex = 81;
            this.RectangleButton.TabStop = false;
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            this.RectangleButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.RectangleButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Margin7
            // 
            this.Margin7.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin7.Location = new System.Drawing.Point(672, 28);
            this.Margin7.Name = "Margin7";
            this.Margin7.Size = new System.Drawing.Size(16, 104);
            this.Margin7.TabIndex = 79;
            // 
            // ColorPickerButton
            // 
            this.ColorPickerButton.BackColor = System.Drawing.Color.Transparent;
            this.ColorPickerButton.BorderSize = 0;
            this.ColorPickerButton.ButtonNumber = 6;
            this.ColorPickerButton.ButtonType = TransparencyMaker.Enumerations.ButtonTypeEnum.ColorPicker;
            this.ColorPickerButton.ClickHandler = null;
            this.ColorPickerButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ColorPickerButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorPickerButton.Location = new System.Drawing.Point(576, 28);
            this.ColorPickerButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ColorPickerButton.Name = "ColorPickerButton";
            this.ColorPickerButton.Size = new System.Drawing.Size(96, 104);
            this.ColorPickerButton.TabIndex = 78;
            this.ColorPickerButton.Visible = false;
            this.ColorPickerButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ColorPickerButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Margin6
            // 
            this.Margin6.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin6.Location = new System.Drawing.Point(560, 28);
            this.Margin6.Name = "Margin6";
            this.Margin6.Size = new System.Drawing.Size(16, 104);
            this.Margin6.TabIndex = 77;
            // 
            // UndoChangesButton
            // 
            this.UndoChangesButton.BackColor = System.Drawing.Color.Transparent;
            this.UndoChangesButton.BorderSize = 0;
            this.UndoChangesButton.ButtonNumber = 5;
            this.UndoChangesButton.ButtonType = TransparencyMaker.Enumerations.ButtonTypeEnum.Undo;
            this.UndoChangesButton.ClickHandler = null;
            this.UndoChangesButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.UndoChangesButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoChangesButton.Location = new System.Drawing.Point(464, 28);
            this.UndoChangesButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.UndoChangesButton.Name = "UndoChangesButton";
            this.UndoChangesButton.Size = new System.Drawing.Size(96, 104);
            this.UndoChangesButton.TabIndex = 76;
            this.UndoChangesButton.Visible = false;
            this.UndoChangesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.UndoChangesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Margin5
            // 
            this.Margin5.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin5.Location = new System.Drawing.Point(448, 28);
            this.Margin5.Name = "Margin5";
            this.Margin5.Size = new System.Drawing.Size(16, 104);
            this.Margin5.TabIndex = 75;
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.Transparent;
            this.ResetButton.BorderSize = 0;
            this.ResetButton.ButtonNumber = 4;
            this.ResetButton.ButtonType = TransparencyMaker.Enumerations.ButtonTypeEnum.Reset;
            this.ResetButton.ClickHandler = null;
            this.ResetButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResetButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(352, 28);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(96, 104);
            this.ResetButton.TabIndex = 74;
            this.ResetButton.Visible = false;
            this.ResetButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ResetButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Margin4
            // 
            this.Margin4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin4.Location = new System.Drawing.Point(336, 28);
            this.Margin4.Name = "Margin4";
            this.Margin4.Size = new System.Drawing.Size(16, 104);
            this.Margin4.TabIndex = 73;
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveAsButton.BorderSize = 0;
            this.SaveAsButton.ButtonNumber = 3;
            this.SaveAsButton.ButtonType = TransparencyMaker.Enumerations.ButtonTypeEnum.SaveAs;
            this.SaveAsButton.ClickHandler = null;
            this.SaveAsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SaveAsButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAsButton.Location = new System.Drawing.Point(240, 28);
            this.SaveAsButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(96, 104);
            this.SaveAsButton.TabIndex = 72;
            this.SaveAsButton.Visible = false;
            this.SaveAsButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.SaveAsButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Margin3
            // 
            this.Margin3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin3.Location = new System.Drawing.Point(224, 28);
            this.Margin3.Name = "Margin3";
            this.Margin3.Size = new System.Drawing.Size(16, 104);
            this.Margin3.TabIndex = 71;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.BorderSize = 0;
            this.SaveButton.ButtonNumber = 2;
            this.SaveButton.ButtonType = TransparencyMaker.Enumerations.ButtonTypeEnum.Save;
            this.SaveButton.ClickHandler = null;
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SaveButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(128, 28);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 104);
            this.SaveButton.TabIndex = 70;
            this.SaveButton.Visible = false;
            this.SaveButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Margin2
            // 
            this.Margin2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin2.Location = new System.Drawing.Point(112, 28);
            this.Margin2.Name = "Margin2";
            this.Margin2.Size = new System.Drawing.Size(16, 104);
            this.Margin2.TabIndex = 69;
            // 
            // CloseFileButton
            // 
            this.CloseFileButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseFileButton.BorderSize = 0;
            this.CloseFileButton.ButtonNumber = 1;
            this.CloseFileButton.ButtonType = TransparencyMaker.Enumerations.ButtonTypeEnum.Close;
            this.CloseFileButton.ClickHandler = null;
            this.CloseFileButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CloseFileButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseFileButton.Location = new System.Drawing.Point(16, 28);
            this.CloseFileButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CloseFileButton.Name = "CloseFileButton";
            this.CloseFileButton.Size = new System.Drawing.Size(96, 104);
            this.CloseFileButton.TabIndex = 68;
            this.CloseFileButton.Visible = false;
            this.CloseFileButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CloseFileButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Margin1
            // 
            this.Margin1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin1.Location = new System.Drawing.Point(0, 28);
            this.Margin1.Name = "Margin1";
            this.Margin1.Size = new System.Drawing.Size(16, 104);
            this.Margin1.TabIndex = 67;
            // 
            // ButtonMarginPanel
            // 
            this.ButtonMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMarginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonMarginPanel.Location = new System.Drawing.Point(0, 12);
            this.ButtonMarginPanel.Name = "ButtonMarginPanel";
            this.ButtonMarginPanel.Size = new System.Drawing.Size(1524, 16);
            this.ButtonMarginPanel.TabIndex = 66;
            // 
            // YouTubePanel
            // 
            this.YouTubePanel.Controls.Add(this.YouTubeButton);
            this.YouTubePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.YouTubePanel.Location = new System.Drawing.Point(1524, 12);
            this.YouTubePanel.Name = "YouTubePanel";
            this.YouTubePanel.Size = new System.Drawing.Size(128, 120);
            this.YouTubePanel.TabIndex = 65;
            // 
            // YouTubeButton
            // 
            this.YouTubeButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.YouTube;
            this.YouTubeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YouTubeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YouTubeButton.Location = new System.Drawing.Point(0, 56);
            this.YouTubeButton.MaximumSize = new System.Drawing.Size(160, 80);
            this.YouTubeButton.Name = "YouTubeButton";
            this.YouTubeButton.Size = new System.Drawing.Size(128, 64);
            this.YouTubeButton.TabIndex = 65;
            this.YouTubeButton.TabStop = false;
            this.YouTubeButton.Click += new System.EventHandler(this.YouTubeButton_Click);
            this.YouTubeButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.YouTubeButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // GraphPanel
            // 
            this.GraphPanel.Controls.Add(this.Graph);
            this.GraphPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GraphPanel.Location = new System.Drawing.Point(0, 0);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(1652, 12);
            this.GraphPanel.TabIndex = 20;
            // 
            // Graph
            // 
            this.Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph.Location = new System.Drawing.Point(0, 0);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(1652, 12);
            this.Graph.TabIndex = 1;
            this.Graph.Visible = false;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Black;
            this.MainPanel.BackgroundImage = global::TransparencyMaker.Properties.Resources.Gray_Slate_Small;
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainPanel.Controls.Add(this.PixelInfo);
            this.MainPanel.Controls.Add(this.QueryPanel);
            this.MainPanel.Controls.Add(this.Separator2);
            this.MainPanel.Controls.Add(this.Separator1);
            this.MainPanel.Controls.Add(this.Canvas);
            this.MainPanel.Controls.Add(this.StartButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(32, 32);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1652, 550);
            this.MainPanel.TabIndex = 8;
            // 
            // PixelInfo
            // 
            this.PixelInfo.BackColor = System.Drawing.Color.LightYellow;
            this.PixelInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PixelInfo.BackgroundImage")));
            this.PixelInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PixelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PixelInfo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixelInfo.Location = new System.Drawing.Point(208, 142);
            this.PixelInfo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.PixelInfo.Name = "PixelInfo";
            this.PixelInfo.Pixel = null;
            this.PixelInfo.Size = new System.Drawing.Size(338, 236);
            this.PixelInfo.TabIndex = 0;
            this.PixelInfo.Visible = false;
            // 
            // QueryPanel
            // 
            this.QueryPanel.Controls.Add(this.QueryTextBox);
            this.QueryPanel.Controls.Add(this.label1);
            this.QueryPanel.Controls.Add(this.MessagesTextBox);
            this.QueryPanel.Controls.Add(this.ApplyButton);
            this.QueryPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.QueryPanel.Location = new System.Drawing.Point(1172, 0);
            this.QueryPanel.MaximumSize = new System.Drawing.Size(480, 0);
            this.QueryPanel.Name = "QueryPanel";
            this.QueryPanel.Size = new System.Drawing.Size(480, 550);
            this.QueryPanel.TabIndex = 22;
            this.QueryPanel.Visible = false;
            // 
            // QueryTextBox
            // 
            this.QueryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryTextBox.Location = new System.Drawing.Point(96, 0);
            this.QueryTextBox.Multiline = true;
            this.QueryTextBox.Name = "QueryTextBox";
            this.QueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QueryTextBox.Size = new System.Drawing.Size(384, 384);
            this.QueryTextBox.TabIndex = 24;
            this.QueryTextBox.Text = "Hide Pixels Where";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(96, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 46);
            this.label1.TabIndex = 23;
            this.label1.Text = "Messages:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // MessagesTextBox
            // 
            this.MessagesTextBox.BackColor = System.Drawing.Color.Black;
            this.MessagesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessagesTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MessagesTextBox.ForeColor = System.Drawing.Color.GhostWhite;
            this.MessagesTextBox.Location = new System.Drawing.Point(96, 430);
            this.MessagesTextBox.Multiline = true;
            this.MessagesTextBox.Name = "MessagesTextBox";
            this.MessagesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessagesTextBox.Size = new System.Drawing.Size(384, 120);
            this.MessagesTextBox.TabIndex = 22;
            this.MessagesTextBox.Text = "Ready";
            // 
            // ApplyButton
            // 
            this.ApplyButton.BackColor = System.Drawing.Color.Black;
            this.ApplyButton.BorderSize = 0;
            this.ApplyButton.ButtonNumber = 7;
            this.ApplyButton.ButtonType = TransparencyMaker.Enumerations.ButtonTypeEnum.Apply;
            this.ApplyButton.ClickHandler = null;
            this.ApplyButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ApplyButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.Location = new System.Drawing.Point(0, 0);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ApplyButton.MaximumSize = new System.Drawing.Size(96, 96);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(96, 96);
            this.ApplyButton.TabIndex = 20;
            this.ApplyButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ApplyButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Separator2
            // 
            this.Separator2.BackColor = System.Drawing.Color.Transparent;
            this.Separator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Separator2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Separator2.Location = new System.Drawing.Point(736, 0);
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(16, 550);
            this.Separator2.TabIndex = 12;
            // 
            // Separator1
            // 
            this.Separator1.BackColor = System.Drawing.Color.Transparent;
            this.Separator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Separator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Separator1.Location = new System.Drawing.Point(720, 0);
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(16, 550);
            this.Separator1.TabIndex = 10;
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.Transparent;
            this.Canvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Left;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(720, 550);
            this.Canvas.TabIndex = 8;
            this.Canvas.TabStop = false;
            this.Canvas.Visible = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            this.Canvas.MouseEnter += new System.EventHandler(this.Canvas_MouseEnter);
            this.Canvas.MouseLeave += new System.EventHandler(this.Canvas_MouseLeave);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Transparent;
            this.StartButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.Start_Button_New;
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartButton.Location = new System.Drawing.Point(255, 212);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(701, 258);
            this.StartButton.TabIndex = 2;
            this.StartButton.TabStop = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            this.StartButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.StartButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::TransparencyMaker.Properties.Resources.Dark_Slate_Small;
            this.ClientSize = new System.Drawing.Size(1716, 746);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Transparency Maker 2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ButtonPanel.ResumeLayout(false);
            this.IconBottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateButton)).EndInit();
            this.IconTopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RectangleButton)).EndInit();
            this.YouTubePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YouTubeButton)).EndInit();
            this.GraphPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.QueryPanel.ResumeLayout(false);
            this.QueryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartButton)).EndInit();
            this.ResumeLayout(false);

            }
        #endregion

        #endregion
        private System.Windows.Forms.Panel YouTubePanel;
        private System.Windows.Forms.PictureBox YouTubeButton;
        private System.Windows.Forms.Panel QueryPanel;
        private Controls.FuturisticButtonControl ApplyButton;
        private Controls.FuturisticButtonControl ColorPickerButton;
        private System.Windows.Forms.Panel Margin6;
        private Controls.FuturisticButtonControl UndoChangesButton;
        private System.Windows.Forms.Panel Margin5;
        private Controls.FuturisticButtonControl ResetButton;
        private System.Windows.Forms.Panel Margin4;
        private Controls.FuturisticButtonControl SaveAsButton;
        private System.Windows.Forms.Panel Margin3;
        private Controls.FuturisticButtonControl SaveButton;
        private System.Windows.Forms.Panel Margin2;
        private Controls.FuturisticButtonControl CloseFileButton;
        private System.Windows.Forms.Panel Margin1;
        private System.Windows.Forms.Panel ButtonMarginPanel;
        private System.Windows.Forms.TextBox QueryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MessagesTextBox;
        private System.Windows.Forms.Panel Margin7;
        private System.Windows.Forms.Panel IconTopPanel;
        private System.Windows.Forms.PictureBox RectangleButton;
        private System.Windows.Forms.Panel IconBottomPanel;
        private System.Windows.Forms.PictureBox UpdateButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
    #endregion

}
