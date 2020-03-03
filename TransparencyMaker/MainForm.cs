

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DataJuggler.PixelDatabase.Net;
using DataJuggler.PixelDatabase.Net.Enumerations;

#endregion

namespace TransparencyMaker
{

    #region class MainForm
    /// <summary>
    /// This is the main form for this application
    /// </summary>
    public partial class MainForm : Form
    {

        #region Private Variables
        private string imagePath;
        private PixelDatabase pixelDatabase;
        private bool analyzing;
        private bool colorPickerMode;
        private bool imageLoaded;
        private bool updating;
        private bool initialized;
        private bool rectangleMode;
        private bool abort;
        private Point point1;
        private Point point2;
        private const int TitleBarHeight = 29;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Events

            #region ButtonClickHandler(int buttonNumber, string buttonName)
            /// <summary>
            /// method returns the Click Handler
            /// </summary>
            public void ButtonClickHandler(int buttonNumber, string buttonName)
            {
                // Hide this
                PixelInfo.Visible = false;

                // Determine the action by the buttonNumber
                switch (buttonNumber)
                {
                    case 1:

                        // Close the current file
                        CloseFile();

                        // required
                        break;

                    case 2:

                        // Save the current file
                        Save();

                        // required
                        break;

                    case 3:

                        // Save the current file
                        SaveAs();

                        // required
                        break;

                    case 4:

                        // Reset Image
                        Reset();

                        // required
                        break;

                    case 5:

                        // Undo the last change
                        UndoChanges();

                        // required
                        break;

                    case 6:

                        // Set ColorPickerMode true or false
                        this.ColorPickerMode = !this.ColorPickerMode;

                        // We can't be in both at the same time
                        this.RectangleMode = !ColorPickerMode;

                        // if not in ColorPickerMode
                        if (this.ColorPickerMode)
                        {
                            // it is on
                            MessagesLabel.Text = "Color Picker Mode On";

                            // Hide the control
                            this.PixelInfo.Visible = false;
                        }
                        else 
                        {
                            // it is on
                            MessagesLabel.Text = "Color Picker Mode Off";

                            // Hide the control
                            this.PixelInfo.Visible = false;
                        }
                        
                        // required
                        break;

                    case 7:

                        // Parse and apply the current query
                        PixelDatabase.ApplyQuery(QueryTextBox.Text,  this.StatusUpdate);

                        // Set the Bitmap now that is has been updated
                        Canvas.BackgroundImage = PixelDatabase.DirectBitmap.Bitmap;

                        // required
                        break;

                    case 8:

                        // Parse and apply the current query
                        this.Abort = true;

                        // Refresh everything
                        Refresh();
                        Application.DoEvents();

                        // required
                        break;
                }
            }
            #endregion

            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                this.Cursor = Cursors.Hand;  
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                this.Cursor = Cursors.Default;
            }
            #endregion
            
            #region Canvas_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'Canvas' is clicked.
            /// </summary>
            private void Canvas_Click(object sender, EventArgs e)
            {  
                // locals
                int x;
                int y;

                // If the value for the property this.ColorPickerMode is true or RectangleMode is true
                if ((ColorPickerMode) || (RectangleMode))
                {
                    // get the mouse event args
                    MouseEventArgs mouseEventArgs = e as MouseEventArgs;
                
                    // If the mouseEventArgs object exists
                    if (mouseEventArgs != null)
                    {
                        // Get the x & y
                        x = mouseEventArgs.X;
                        y = mouseEventArgs.Y;

                        if (ColorPickerMode)
                        {
                            // Handle the PixelInfo
                            HandlePixelInfo(x, y);
                        }
                        else if (RectangleMode)
                        {   
                            // set the pixel
                            PixelInformation pixel = null;

                            if (Point1 == Point.Empty)
                            {
                                // Get the scaled Pixel
                                pixel = HandlePixelInfo(x, y);

                                // Create Point1
                                Point1 = new Point(pixel.X, pixel.Y);
                            }
                            else if (Point2 == Point.Empty)
                            {
                                // Get the scaled Pixel
                                pixel = HandlePixelInfo(x, y);

                                // Create Point1
                                Point2 = new Point(pixel.X, pixel.Y);

                                // Draw a rectangle
                                PixelDatabase.DrawRectangle(Point1, Point2);
                            }
                        }
                    }
                }
            }
            #endregion

            #region Canvas_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Canvas _ Mouse Enter
            /// </summary>
            private void Canvas_MouseEnter(object sender, EventArgs e)
            {
                // if the value for ColorPickerMode is true
                if ((ColorPickerMode) || (RectangleMode))
                {
                    // Change the cursor to a hand
                    this.Cursor = Cursors.Hand;
                }
            }
            #endregion
            
            #region Canvas_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Canvas _ Mouse Leave
            /// </summary>
            private void Canvas_MouseLeave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                this.Cursor = Cursors.Default;
            }
            #endregion
            
            #region MainForm_Activated(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Main Formis Activated
            /// </summary>
            private void MainForm_Activated(object sender, EventArgs e)
            {
                // if not Initialized yet
                if (!this.Initialized)
                {
                    // Perform initializations for this object
                    Init();        
                }
            }
            #endregion
            
            #region MainForm_Resize(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Main Form is Resized
            /// </summary>
            private void MainForm_Resize(object sender, EventArgs e)
            {
                // set the width of the Canvas
                this.Canvas.Width = (int) ((double) this.MainPanel.Width * .6);  
            }
            #endregion
            
            #region QueryPanel_Resize(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Query Panel _ Resize
            /// </summary>
            private void QueryPanel_Resize(object sender, EventArgs e)
            {
                // Resize to top half not used for now
                QueryTopMargin.Height = QueryPanel.Height / 2;
            }
            #endregion
            
            #region QueryTextBox_KeyDown(object sender, KeyEventArgs e)
            /// <summary>
            /// event is fired when Query Text Box _ Key Down
            /// </summary>
            private void QueryTextBox_KeyDown(object sender, KeyEventArgs e)
            {
                // if the control key is being held down
                if (e.Control)
                {
                    if (e.KeyCode == Keys.S)
                    {
                        // Change the text
                        this.QueryTextBox.Text = "Show Pixels Where";
                    }
                    else if (e.KeyCode == Keys.H)
                    {
                        // Change the text
                        this.QueryTextBox.Text = "Hide Pixels Where";
                    }
                }
            }
            #endregion
            
            #region RectangleButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RectangleButton' is clicked.
            /// </summary>
            private void RectangleButton_Click(object sender, EventArgs e)
            {
                // Turn Rectangle Mode On
                RectangleMode = !RectangleMode;

                // We can't be in both modes at the same time
                ColorPickerMode = !RectangleMode;

                // if the value for RectangleMode is true
                if (RectangleMode)
                {
                    // reset the points
                    point1 = Point.Empty;
                    point2 = Point.Empty;

                    // it is on
                    MessagesLabel.Text = "Rectangle Mode On";
                }
                else
                {   
                    // It is off
                    MessagesLabel.Text = "Rectangle Mode Off";
                }
            }
            #endregion
            
            #region StartButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'StartButton' is clicked.
            /// </summary>
            private void StartButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of an 'OpenFileDialog' object.
                OpenFileDialog fileDialog = new OpenFileDialog();

                // Create the DefaultExtension if for Png's
                fileDialog.DefaultExt = ".png;.jpg;";
                fileDialog.Filter = "image files (*.png,*.jpg)|*.png;*.jpg";

                // Show to the user
                DialogResult result = fileDialog.ShowDialog();

                // if the fileName is set
                this.ImagePath = fileDialog.FileName;

                // Load the PixelDatabase
                LoadPixelDatabase();
            }
            #endregion
            
            #region UpdateButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'UpdateButton' is clicked.
            /// </summary>
            private void UpdateButton_Click(object sender, EventArgs e)
            {
                // Change the text
                QueryTextBox.Text = "Update" + Environment.NewLine + "Set ";

                // Set Focus
                QueryTextBox.Focus();
            }
            #endregion
            
            #region YouTubeButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'YouTubeButton' is clicked.
            /// </summary>
            private void YouTubeButton_Click(object sender, EventArgs e)
            {
                // open to Transparency Maker PlayList
                System.Diagnostics.Process.Start("https://www.youtube.com/playlist?list=PLKrW5tXCPiX2PxrLPszDzlcEZwQG-Qb8r");
            }
            #endregion
            
        #endregion

        #region Methods
            
            #region AppendQueryText(string text)
            /// <summary>
            /// This method returns the Query Text
            /// </summary>
            public void AppendQueryText(string text)
            {
                // Append the text sent plus a space
                this.QueryTextBox.Text += text + " ";
            }
            #endregion
                        
            #region CloseFile(bool resetOnly = false)
            /// <summary>
            /// This method Close File
            /// </summary>
            public void CloseFile(bool resetOnly = false)
            {
                // To Do: Prompt for changes

                // Close the current file
                this.ImagePath = "";
                this.Canvas.BackgroundImage = null;

                // destory the PixelDatabase
                PixelDatabase = null;

                // Not loaded
                this.ImageLoaded = false;

                // if the value for resetOnly is false
                if (!resetOnly)
                {
                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion

            #region HandlePixelInfo(int x, int y)
            /// <summary>
            /// This method Handle Pixel Info
            /// </summary>
            public PixelInformation HandlePixelInfo(int x, int y)
            {  
                // local
                PixelInformation pixel = null;

                // for debugging only
                int originalX = x;
                int originalY = y;

                // Get the current image
                Image image = this.Canvas.BackgroundImage;
                Bitmap bitmap = new Bitmap(image);

                // x & y must now be scaled
                double canvasWidth = this.Canvas.Width;
                double canvasHeight = this.Canvas.Height;
                double bitmapWidth = bitmap.Width;
                double bitmapHeight = bitmap.Height;

                // get the xScale and the yScale
                double scaleX = bitmapWidth / canvasWidth;
                double scaleY = bitmapHeight / canvasHeight;
                double doubleX = (double) x;
                double doubleY = (double) y;

                // reset the values
                x = (int) (doubleX * scaleX);
                y = (int) (doubleY * scaleY);

                // ensure x is in range
                if (x < 0)
                {
                    // reset x
                    x = 0;
                }

                // ensure x is in range
                if (x >= bitmap.Width)
                {
                    // reset x
                    x = bitmap.Width -1;
                }

                // ensure y is in range
                if (y < 0)
                {
                    // reset y
                    y = 0;
                }

                // ensure y is in range
                if (y >= bitmap.Height)
                {
                    // reset y
                    y = bitmap.Height - 1;
                }

                // get the information about this pixel
                Color color = bitmap.GetPixel(x, y);

                // Create a new instance of a 'PixelInformation' object.
                pixel = new PixelInformation();

                // set the information on the pixel
                pixel.Color = color;
                pixel.X = x;
                pixel.Y = y;

                if (ColorPickerMode)
                {
                    // Handle the display top in case the mouse is too far down
                    int displayY = originalY;
                    int displayX = LeftMarginPanel.Width + originalX + 32;

                    // if the height is too far down
                    if ((displayY + 60) > (canvasHeight - PixelInfo.Height - TitleBarHeight))
                    {
                        // Move up a control's length
                        displayY = displayY - 60 - PixelInfo.Height;
                    }

                    // if the width is too far right
                    if ((displayX) > (canvasWidth + PixelInfo.Width))
                    {
                        // Move left 
                        displayX = displayX - 60 - PixelInfo.Width;
                    }

                    // Display the PixelInfo
                    this.PixelInfo.DisplayPixel(pixel);
                    this.PixelInfo.Left = displayX;
                    this.PixelInfo.Top = displayY;
                    this.PixelInfo.Visible = true;
                    this.PixelInfo.Refresh();

                    // if draw line is set
                    if (this.QueryTextBox.Text.ToLower().Contains("draw line"))
                    {
                        // add to the current text
                        string text = this.QueryTextBox.Text + " " + x + "  " + y + " ";

                        // Remove the new line character out of the beginning
                        text = text.Replace(Environment.NewLine + " ", Environment.NewLine);

                        // Update the text
                        this.QueryTextBox.Text = text;

                        // Set the Selection Start
                        this.QueryTextBox.SelectionStart = text.Length - 1;
                    }
                }

                // return value
                return pixel;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Center the StartButton
                this.StartButton.Left = (this.MainPanel.Width - this.StartButton.Width) / 2;
                this.StartButton.Top = (this.MainPanel.Height - this.StartButton.Height) / 2;                

                // Setup the Click Handlers
                this.CloseFileButton.ClickHandler = this.ButtonClickHandler;
                this.SaveButton.ClickHandler = this.ButtonClickHandler;
                this.SaveAsButton.ClickHandler = this.ButtonClickHandler;
                this.ApplyButton.ClickHandler = this.ButtonClickHandler;
                this.ResetButton.ClickHandler = this.ButtonClickHandler;
                this.UndoChangesButton.ClickHandler = this.ButtonClickHandler;
                this.ColorPickerButton.ClickHandler = this.ButtonClickHandler;
                this.AbortButton.ClickHandler = this.ButtonClickHandler;

                // only fire once
                this.Initialized = true;
            }
            #endregion

            #region LoadPixelDatabase()
            /// <summary>
            /// This method Loads the Pixel Database
            /// </summary>
            public void LoadPixelDatabase()
            {
                // if we do not have a BackgroundImage yet
                if (this.Canvas.BackgroundImage == null)
                {
                    // to do: Show message

                    // bail
                    return;
                }

                // Set to true
                this.Analyzing = true;

                // Reset the Graph
                this.Graph.Visible = true;
                this.Graph.Value = 0;

                // Enable or disable controls
                UIEnable();

                // Load the PixelDatabase
                this.PixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(this.Canvas.BackgroundImage, StatusUpdate);

                // Set to False
                this.Analyzing = false;

                // Set the value for the property 'ImageLoaded' to true
                this.ImageLoaded = true;

                // Enable controls now that we are done analyzing
                UIEnable();
            }
            #endregion
            
            #region Reset()
            /// <summary>
            /// This method Reset
            /// </summary>
            public void Reset()
            { 
                // Abort is n
                Abort = false;

                // get a copy of the imagePath
                string imagePath = this.ImagePath;

                // Close the file
                CloseFile(true);

                // Set the ImagePath again (this reloads the image from disk and sets the Canvas.BackgroundImage)
                this.ImagePath = imagePath;

                // Reload the PixelDatabase
                LoadPixelDatabase();

                // Handle the UI
                UIEnable();
            }
            #endregion
            
            #region Save()
            /// <summary>
            /// This method Save
            /// </summary>
            public void Save()
            {
                // Get the background image
                Image image = this.Canvas.BackgroundImage;

                // Create a new instance of a 'Bitmap' object.
                Bitmap bitmap = new Bitmap(image);

                // Create the fileInfo
                FileInfo fileInfo = new FileInfo(this.ImagePath);

                // iif this file is a jpg
                if (fileInfo.Extension == ".jpg")
                {
                    // Call Save As since this is a .jpg and it must be converted to a .png
                    SaveAs();
                }

                // Save the bitmap
                bitmap.Save(this.ImagePath);
            }
            #endregion
            
            #region SaveAs()
            /// <summary>
            /// This method Save As
            /// </summary>
            public void SaveAs()
            {
                // Get the background image
                Image image = this.Canvas.BackgroundImage;

                // Create a new instance of a 'Bitmap' object.
                Bitmap bitmap = new Bitmap(image);

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "*.png|*.png";
                DialogResult result = dialog.ShowDialog();

                // Save the bitmap
                bitmap.Save(dialog.FileName);
            }
            #endregion
            
            #region StatusUpdate(string message, int pixelsUpdated)
            /// <summary>
            /// This method returns the Update
            /// </summary>
            public void StatusUpdate(string message, int pixelsUpdated)
            {
                if (message == "SetGraphMax")
                {
                    // Set the Max for the Graph
                    this.Graph.Maximum = pixelsUpdated;
                }
                else if (message == "")
                {
                    // Restore the background image
                    this.MainPanel.BackgroundImage = Properties.Resources.Gray_Slate_Small;

                        // Set the BackColor
                    this.MainPanel.BackColor = Color.Transparent;
                }
                else if (message.StartsWith("SetBackColor"))
                {
                    // get the index
                    int index = message.IndexOf("|");

                    // if index was found
                    if (index >= 0)
                    {
                        // Restore the background image
                        this.MainPanel.BackgroundImage = null;

                        // get the colorName
                        string colorName = message.Substring(index + 1);

                        // Set the BackColor
                        this.MainPanel.BackColor = Color.FromName(colorName);
                    }  
                }
                else
                {
                    // Set the message
                    MessagesLabel.Text = message;

                    // if in range
                    if (pixelsUpdated <= Graph.Maximum)
                    {
                        // Set the message
                        Graph.Value = pixelsUpdated;
                    }
                }

                // Refresh everything
                Refresh();
                Application.DoEvents();
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {
                this.StartButton.Visible = !this.HasImagePath;
                this.Canvas.Visible = this.HasImagePath;
                this.BottomMarginPanel.Visible = !this.HasImagePath;                
                this.QueryPanel.Visible = HasImagePath;
                this.GraphPanel.Visible = this.Analyzing;
                this.Graph.Visible = this.Analyzing;
                this.ButtonPanel.Visible = HasImagePath;
                
                // local
                bool isFileOpen =  ((this.ImageLoaded) && (!this.Analyzing));

                // Handle the buttons
                this.CloseFileButton.Visible = isFileOpen;
                this.SaveButton.Visible = isFileOpen;
                this.SaveAsButton.Visible = isFileOpen;
                this.ResetButton.Visible = isFileOpen;
                this.ColorPickerButton.Visible = isFileOpen;
                this.UndoChangesButton.Visible = isFileOpen;
                this.IconTopPanel.Visible = isFileOpen;
                this.IconBottomPanel.Visible = isFileOpen;
                
                // Show the QueryPanel if we are done analyzing the Pixel Database has any pixels
                this.QueryPanel.Visible = ((!this.Analyzing) && (this.HasPixelDatabase) && (this.PixelDatabase.HasOneOrMorePixels));

                if (isFileOpen)
                {
                    // remove the background image while a file is open
                    this.MainPanel.BackgroundImage = null;
                }
                else
                {
                    // remove the background image while a file is open
                    this.MainPanel.BackgroundImage = Properties.Resources.Gray_Slate_Small;
                }
            }
            #endregion
            
            #region UndoChanges()
            /// <summary>
            /// This method Undo Changes
            /// </summary>
            public void UndoChanges()
            {  
                // Attempt to undo any changes
                this.DirectBitmap.UndoChanges();

                // Refresh everything
                this.Refresh();
                Application.DoEvents();
            }
            #endregion
            
        #endregion

        #region Properties

            #region Abort
            /// <summary>
            /// This property gets or sets the value for 'Abort'.
            /// </summary>
            public bool Abort
            {
                get { return abort; }
                set { abort = value; }
            }
            #endregion
            
            #region Analyzing
            /// <summary>
            /// This property gets or sets the value for 'Analyzing'.
            /// </summary>
            public bool Analyzing
            {
                get { return analyzing; }
                set { analyzing = value;}
            }
            #endregion

            #region ColorPickerMode
            /// <summary>
            /// This property gets or sets the value for 'ColorPickerMode'.
            /// </summary>
            public bool ColorPickerMode
            {
                get { return colorPickerMode; }
                set { colorPickerMode = value; }
            }
            #endregion
            
            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
            #endregion
            
            #region DirectBitmap
            /// <summary>
            /// This property gets or sets the value for 'DirectBitmap'.
            /// </summary>
            public DirectBitmap DirectBitmap
            {
                get 
                { 
                    // initial value
                    DirectBitmap directBitmap = null;

                    // if the value for HasPixelDatabase is true
                    if (HasPixelDatabase)
                    {
                        // set the return value
                        directBitmap = PixelDatabase.DirectBitmap;
                    }

                    // return value
                    return directBitmap;
                }
            }
            #endregion
            
            #region HasDirectBitmap
            /// <summary>
            /// This property returns true if this object has a 'DirectBitmap'.
            /// </summary>
            public bool HasDirectBitmap
            {
                get
                {
                    // initial value
                    bool hasDirectBitmap = (this.DirectBitmap != null);
                    
                    // return value
                    return hasDirectBitmap;
                }
            }
            #endregion
            
            #region HasImagePath
            /// <summary>
            /// This property returns true if the 'ImagePath' exists.
            /// </summary>
            public bool HasImagePath
            {
                get
                {
                    // initial value
                    bool hasImagePath = (!String.IsNullOrEmpty(this.ImagePath));
                    
                    // return value
                    return hasImagePath;
                }
            }
            #endregion
            
            #region HasPixelDatabase
            /// <summary>
            /// This property returns true if this object has a 'PixelDatabase'.
            /// </summary>
            public bool HasPixelDatabase
            {
                get
                {
                    // initial value
                    bool hasPixelDatabase = (this.PixelDatabase != null);
                    
                    // return value
                    return hasPixelDatabase;
                }
            }
            #endregion
            
            #region ImageLoaded
            /// <summary>
            /// This property gets or sets the value for 'ImageLoaded'.
            /// </summary>
            public bool ImageLoaded
            {
                get { return imageLoaded; }
                set { imageLoaded = value; }
            }
            #endregion
            
            #region ImagePath
            /// <summary>
            /// This property gets or sets the value for 'ImagePath'.
            /// </summary>
            public string ImagePath
            {
                get { return imagePath; }
                set 
                { 
                    // set the imagePath
                    imagePath = value; 

                    // if the file exists
                    if ((TextHelper.Exists(imagePath)) && (File.Exists(imagePath)))
                    {
                        // local
                        Image image = Image.FromFile(imagePath);

                        // Load the Canvas
                        this.Canvas.BackgroundImage = image;
                    }
                }
            }
            #endregion

            #region Initialized
            /// <summary>
            /// This property gets or sets the value for 'Initialized'.
            /// </summary>
            public bool Initialized
            {
                get { return initialized; }
                set { initialized = value; }
            }
            #endregion

            #region PixelDatabase
            /// <summary>
            /// This property gets or sets the value for 'PixelDatabase'.
            /// </summary>
            public PixelDatabase PixelDatabase
            {
                get { return pixelDatabase; }
                set { pixelDatabase = value; }
            }
        #endregion
                        
            #region Point1
            /// <summary>
            /// This property gets or sets the value for 'Point1'.
            /// </summary>
            public Point Point1
            {
                get { return point1; }
                set { point1 = value; }
            }
            #endregion
            
            #region Point2
            /// <summary>
            /// This property gets or sets the value for 'Point2'.
            /// </summary>
            public Point Point2
            {
                get { return point2; }
                set { point2 = value; }
            }
            #endregion
            
            #region RectangleMode
            /// <summary>
            /// This property gets or sets the value for 'RectangleMode'.
            /// </summary>
            public bool RectangleMode
            {
                get { return rectangleMode; }
                set { rectangleMode = value; }
            }
            #endregion
            
            #region Updating
            /// <summary>
            /// This property gets or sets the value for 'Updating'.
            /// </summary>
            public bool Updating
            {
                get { return updating; }
                set { updating = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}