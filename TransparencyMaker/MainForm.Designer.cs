

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
        private System.Windows.Forms.Panel QueryPanel;
        private Controls.FuturisticButtonControl ApplyButton;
        private System.Windows.Forms.Panel GraphPanel;
        private System.Windows.Forms.ProgressBar Graph;
        private System.Windows.Forms.Panel Margin1;
        private System.Windows.Forms.TextBox QueryTextBox;
        private System.Windows.Forms.Panel Margin5;
        private Controls.FuturisticButtonControl ResetButton;
        private System.Windows.Forms.Panel Margin4;
        private Controls.FuturisticButtonControl SaveAsButton;
        private System.Windows.Forms.Panel Margin3;
        private Controls.FuturisticButtonControl SaveButton;
        private System.Windows.Forms.Panel Margin2;
        private Controls.FuturisticButtonControl CloseFileButton;
        private Controls.FuturisticButtonControl UndoChangesButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.BottomMarginPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
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
            this.QueryPanel = new System.Windows.Forms.Panel();
            this.QueryTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new TransparencyMaker.Controls.FuturisticButtonControl();
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.Graph = new System.Windows.Forms.ProgressBar();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.YouTubeButton = new System.Windows.Forms.PictureBox();
            this.PixelInfo = new TransparencyMaker.Controls.PixelInformationControl();
            this.Separator2 = new System.Windows.Forms.Panel();
            this.Separator1 = new System.Windows.Forms.Panel();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.PictureBox();
            this.ButtonPanel.SuspendLayout();
            this.QueryPanel.SuspendLayout();
            this.GraphPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YouTubeButton)).BeginInit();
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
            this.ButtonPanel.Controls.Add(this.QueryPanel);
            this.ButtonPanel.Controls.Add(this.GraphPanel);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(32, 554);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(1652, 160);
            this.ButtonPanel.TabIndex = 7;
            this.ButtonPanel.Visible = false;
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
            this.ColorPickerButton.Location = new System.Drawing.Point(736, 12);
            this.ColorPickerButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ColorPickerButton.Name = "ColorPickerButton";
            this.ColorPickerButton.Size = new System.Drawing.Size(128, 148);
            this.ColorPickerButton.TabIndex = 63;
            this.ColorPickerButton.Visible = false;
            // 
            // Margin6
            // 
            this.Margin6.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin6.Location = new System.Drawing.Point(720, 12);
            this.Margin6.Name = "Margin6";
            this.Margin6.Size = new System.Drawing.Size(16, 148);
            this.Margin6.TabIndex = 62;
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
            this.UndoChangesButton.Location = new System.Drawing.Point(592, 12);
            this.UndoChangesButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.UndoChangesButton.Name = "UndoChangesButton";
            this.UndoChangesButton.Size = new System.Drawing.Size(128, 148);
            this.UndoChangesButton.TabIndex = 61;
            this.UndoChangesButton.Visible = false;
            // 
            // Margin5
            // 
            this.Margin5.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin5.Location = new System.Drawing.Point(576, 12);
            this.Margin5.Name = "Margin5";
            this.Margin5.Size = new System.Drawing.Size(16, 148);
            this.Margin5.TabIndex = 60;
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
            this.ResetButton.Location = new System.Drawing.Point(448, 12);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(128, 148);
            this.ResetButton.TabIndex = 59;
            this.ResetButton.Visible = false;
            // 
            // Margin4
            // 
            this.Margin4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin4.Location = new System.Drawing.Point(432, 12);
            this.Margin4.Name = "Margin4";
            this.Margin4.Size = new System.Drawing.Size(16, 148);
            this.Margin4.TabIndex = 57;
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
            this.SaveAsButton.Location = new System.Drawing.Point(304, 12);
            this.SaveAsButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(128, 148);
            this.SaveAsButton.TabIndex = 56;
            this.SaveAsButton.Visible = false;
            // 
            // Margin3
            // 
            this.Margin3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin3.Location = new System.Drawing.Point(288, 12);
            this.Margin3.Name = "Margin3";
            this.Margin3.Size = new System.Drawing.Size(16, 148);
            this.Margin3.TabIndex = 53;
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
            this.SaveButton.Location = new System.Drawing.Point(160, 12);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(128, 148);
            this.SaveButton.TabIndex = 52;
            this.SaveButton.Visible = false;
            // 
            // Margin2
            // 
            this.Margin2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin2.Location = new System.Drawing.Point(144, 12);
            this.Margin2.Name = "Margin2";
            this.Margin2.Size = new System.Drawing.Size(16, 148);
            this.Margin2.TabIndex = 48;
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
            this.CloseFileButton.Location = new System.Drawing.Point(16, 12);
            this.CloseFileButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CloseFileButton.Name = "CloseFileButton";
            this.CloseFileButton.Size = new System.Drawing.Size(128, 148);
            this.CloseFileButton.TabIndex = 47;
            this.CloseFileButton.Visible = false;
            // 
            // Margin1
            // 
            this.Margin1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Margin1.Location = new System.Drawing.Point(0, 12);
            this.Margin1.Name = "Margin1";
            this.Margin1.Size = new System.Drawing.Size(16, 148);
            this.Margin1.TabIndex = 26;
            // 
            // QueryPanel
            // 
            this.QueryPanel.Controls.Add(this.QueryTextBox);
            this.QueryPanel.Controls.Add(this.ApplyButton);
            this.QueryPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.QueryPanel.Location = new System.Drawing.Point(1012, 12);
            this.QueryPanel.Name = "QueryPanel";
            this.QueryPanel.Size = new System.Drawing.Size(640, 148);
            this.QueryPanel.TabIndex = 21;
            // 
            // QueryTextBox
            // 
            this.QueryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryTextBox.Location = new System.Drawing.Point(128, 0);
            this.QueryTextBox.Multiline = true;
            this.QueryTextBox.Name = "QueryTextBox";
            this.QueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QueryTextBox.Size = new System.Drawing.Size(512, 148);
            this.QueryTextBox.TabIndex = 21;
            this.QueryTextBox.Text = "Hide Pixels Where";
            this.QueryTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryTextBox_KeyDown);
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
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(128, 148);
            this.ApplyButton.TabIndex = 20;
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
            this.MainPanel.Controls.Add(this.YouTubeButton);
            this.MainPanel.Controls.Add(this.PixelInfo);
            this.MainPanel.Controls.Add(this.Separator2);
            this.MainPanel.Controls.Add(this.Separator1);
            this.MainPanel.Controls.Add(this.Canvas);
            this.MainPanel.Controls.Add(this.StartButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(32, 32);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1652, 522);
            this.MainPanel.TabIndex = 8;
            // 
            // YouTubeButton
            // 
            this.YouTubeButton.BackgroundImage = global::TransparencyMaker.Properties.Resources.YouTube;
            this.YouTubeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YouTubeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.YouTubeButton.Location = new System.Drawing.Point(1492, 0);
            this.YouTubeButton.MaximumSize = new System.Drawing.Size(160, 80);
            this.YouTubeButton.Name = "YouTubeButton";
            this.YouTubeButton.Size = new System.Drawing.Size(160, 80);
            this.YouTubeButton.TabIndex = 13;
            this.YouTubeButton.TabStop = false;
            this.YouTubeButton.Click += new System.EventHandler(this.YouTubeButton_Click);
            this.YouTubeButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.YouTubeButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // PixelInfo
            // 
            this.PixelInfo.BackColor = System.Drawing.Color.LightYellow;
            this.PixelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PixelInfo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixelInfo.Location = new System.Drawing.Point(208, 142);
            this.PixelInfo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.PixelInfo.Name = "PixelInfo";
            this.PixelInfo.Size = new System.Drawing.Size(300, 160);
            this.PixelInfo.TabIndex = 0;
            this.PixelInfo.Visible = false;
            // 
            // Separator2
            // 
            this.Separator2.BackColor = System.Drawing.Color.Transparent;
            this.Separator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Separator2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Separator2.Location = new System.Drawing.Point(736, 0);
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(16, 522);
            this.Separator2.TabIndex = 12;
            // 
            // Separator1
            // 
            this.Separator1.BackColor = System.Drawing.Color.Transparent;
            this.Separator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Separator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Separator1.Location = new System.Drawing.Point(720, 0);
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(16, 522);
            this.Separator1.TabIndex = 10;
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.Transparent;
            this.Canvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Left;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(720, 522);
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
            this.Text = "Transparency Maker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ButtonPanel.ResumeLayout(false);
            this.QueryPanel.ResumeLayout(false);
            this.QueryPanel.PerformLayout();
            this.GraphPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YouTubeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartButton)).EndInit();
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private Controls.FuturisticButtonControl ColorPickerButton;
        private System.Windows.Forms.Panel Margin6;
        private System.Windows.Forms.PictureBox YouTubeButton;
    }
    #endregion

}
