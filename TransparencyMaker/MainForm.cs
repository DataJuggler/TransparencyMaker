

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
using TransparencyMaker.Enumerations;
using TransparencyMaker.Objects;
using TransparencyMaker.Util;

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
        private List<PixelInformation> lastUpdate;
        private Color lineColor;
        private bool lineColorSet;
        private DirectBitmap directBitmap;
        private bool initialized;
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

                        // if not in ColorPickerMode
                        if (!this.ColorPickerMode)
                        {
                            // Hide the control
                            this.PixelInfo.Visible = false;
                        }
                        
                        // required
                        break;

                    case 7:

                          // Parse and apply the current query
                        ApplyQuery();

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
                int x = 0;
                int y = 0;

                // If the value for the property this.ColorPickerMode is true
                if (this.ColorPickerMode)
                {
                    // get the mouse event args
                    MouseEventArgs mouseEventArgs = e as MouseEventArgs;
                
                    // If the mouseEventArgs object exists
                    if (mouseEventArgs != null)
                    {
                        // Get the x & y
                        x = mouseEventArgs.X;
                        y = mouseEventArgs.Y;

                        // Handle the PixelInfo
                        HandlePixelInfo(x, y);
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
                if (ColorPickerMode)
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
            
            #region StartButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'StartButton' is clicked.
            /// </summary>
            private void StartButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of an 'OpenFileDialog' object.
                OpenFileDialog fileDialog = new OpenFileDialog();

                // Create the DefaultExtension if for Png's
                fileDialog.DefaultExt = ".png";
                fileDialog.Filter = "image files (*.png,*.jpg)|*.png;*.jpg";

                // Show to the user
                DialogResult result = fileDialog.ShowDialog();

                // if the fileName is set
                this.ImagePath = fileDialog.FileName;

                // Load the PixelDatabase
                LoadPixelDatabase();

                // Show the ListBox
                UIEnable();
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

            #region AdjustColor(Color previousColor, PixelQuery pixelQuery)
            /// <summary>
            /// This method returns the Adjusted Color
            /// </summary>
            public Color AdjustColor(Color previousColor, PixelQuery pixelQuery)
            {
                // initial value
                Color color = previousColor;

                // locals
                int adjustedValue = 0;
                int adjustedValue2 = 0;
                int adjustedValue3 = 0;
                
                // If the pixelQuery object exists
                if (NullHelper.Exists(pixelQuery))
                {
                    switch (pixelQuery.ColorToAdjust)
                    {
                        case RGBColor.Red:

                            // if there is an AssignToColor
                            if (pixelQuery.HasAssignToColor)
                            {
                                // Set Red Equals Blue
                                if (pixelQuery.AssignToColor == RGBColor.Blue)
                                {
                                    // Create the new color
                                    color = Color.FromArgb(previousColor.B, previousColor.G, previousColor.B);
                                }
                                else if (pixelQuery.AssignToColor == RGBColor.Green)
                                {
                                    // Create the new color
                                    color = Color.FromArgb(previousColor.G, previousColor.G, previousColor.B);
                                }
                            }
                            else
                            {
                                // get the adjust color (guarunteed to be in range)
                                adjustedValue = AdjustValue(previousColor.R, pixelQuery.Adjustment);

                                // Create the adjusted color
                                color = Color.FromArgb(adjustedValue, previousColor.G, previousColor.B);
                            }

                            // required
                            break;

                        case RGBColor.Green:

                            // if there is an AssignToColor
                            if (pixelQuery.HasAssignToColor)
                            {
                                // Set Red Equals Blue
                                if (pixelQuery.AssignToColor == RGBColor.Blue)
                                {
                                    // Create the new color
                                    color = Color.FromArgb(previousColor.R, previousColor.B, previousColor.B);
                                }
                                else if (pixelQuery.AssignToColor == RGBColor.Red)
                                {
                                    // Create the new color
                                    color = Color.FromArgb(previousColor.R, previousColor.R, previousColor.B);
                                }
                            }
                            else
                            {
                                // get the adjust color (guarunteed to be in range)
                                adjustedValue = AdjustValue(previousColor.G, pixelQuery.Adjustment);

                                // Create the adjusted color
                                color = Color.FromArgb(previousColor.R, adjustedValue, previousColor.B);
                            }

                            // required
                            break;

                        case RGBColor.Blue:

                            // if there is an AssignToColor
                            if (pixelQuery.HasAssignToColor)
                            {
                                // Set Red Equals Blue
                                if (pixelQuery.AssignToColor == RGBColor.Green)
                                {
                                    // Create the new color
                                    color = Color.FromArgb(previousColor.R, previousColor.G, previousColor.G);
                                }
                                else if (pixelQuery.AssignToColor == RGBColor.Red)
                                {
                                    // Create the new color
                                    color = Color.FromArgb(previousColor.R, previousColor.G, previousColor.R);
                                }
                            }
                            else
                            {
                                // get the adjust color (guarunteed to be in range)
                                adjustedValue = AdjustValue(previousColor.B, pixelQuery.Adjustment);

                                // Create the adjusted color
                                color = Color.FromArgb(previousColor.R, previousColor.G, adjustedValue);
                            }

                            // required
                            break;

                        case RGBColor.GreenRed:

                            // get the adjust color (guarunteed to be in range)
                            adjustedValue = AdjustValue(previousColor.R, pixelQuery.Adjustment);
                            adjustedValue2 = AdjustValue(previousColor.G, pixelQuery.Adjustment);
                                                
                            // Create the adjusted color
                            color = Color.FromArgb(adjustedValue, adjustedValue2, previousColor.B);

                            // required
                            break;

                            case RGBColor.BlueRed:

                            // get the adjust color (guarunteed to be in range)
                            adjustedValue = AdjustValue(previousColor.R, pixelQuery.Adjustment);
                            adjustedValue2 = AdjustValue(previousColor.B, pixelQuery.Adjustment);
                                                
                            // Create the adjusted color
                            color = Color.FromArgb(adjustedValue, previousColor.G , adjustedValue2);

                            // required
                            break;

                        case RGBColor.BlueGreen:

                            // get the adjust color (guarunteed to be in range)
                            adjustedValue = AdjustValue(previousColor.G, pixelQuery.Adjustment);
                            adjustedValue2 = AdjustValue(previousColor.B, pixelQuery.Adjustment);
                                                
                            // Create the adjusted color
                            color = Color.FromArgb(previousColor.R, adjustedValue , adjustedValue2);

                            // required
                            break;

                        case RGBColor.All:

                            // get the adjust color (guarunteed to be in range)
                            adjustedValue = AdjustValue(previousColor.R, pixelQuery.Adjustment);
                            adjustedValue2 = AdjustValue(previousColor.G, pixelQuery.Adjustment);
                            adjustedValue3 = AdjustValue(previousColor.B, pixelQuery.Adjustment);

                            // Create the adjusted color
                            color = Color.FromArgb(adjustedValue, adjustedValue2, adjustedValue3);

                            // required
                            break;

                    } 
                }
                
                // return value
                return color;
            }
            #endregion
            
            #region AdjustValue(int originalValue, int adjustment)
            /// <summary>
            /// This method returns the Value
            /// </summary>
            public int AdjustValue(int originalValue, int adjustment)
            {
                // Set the return value (adjustment may be negative)
                int adjustValue = originalValue + adjustment;

                // if too low
                if (adjustValue < 0)
                {
                    // cannot be lower than zero
                    adjustValue = 0;
                }

                 // if too high
                if (adjustValue > 255)
                {
                    // cannot be higher than 255
                    adjustValue = 255;
                }
                
                // return value
                return adjustValue;
            }
            #endregion
            
            #region ApplyCriteria(List<PixelInformation> pixels, PixelQuery pixelQuery)
            /// <summary>
            /// This method returns a list of Criteria
            /// </summary>
            public List<PixelInformation> ApplyCriteria(List<PixelInformation> pixels, PixelQuery pixelQuery)
            {
                // if the pixels exist and the pixelQuery exists and is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(pixelQuery)) && (pixelQuery.IsValid))
                {
                    // iterate the criteria in the pixelQuery
                    foreach (PixelCriteria criteria in pixelQuery.Criteria)
                    {
                        switch (criteria.PixelType)
                        {
                            case PixelTypeEnum.Red:

                                // Handle Red Pixels
                                pixels = HandleRedPixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.Green:

                                // Handle Green Pixels
                                pixels = HandleGreenPixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.Blue:

                                // Handle Blue Pixels
                                pixels = HandleBluePixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.Total:

                                // Handle Total Pixels
                                pixels = HandleTotalPixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.X:

                                // Handle X Pixels
                                pixels = HandleXPixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.Y:

                                // Handle X Pixels
                                pixels = HandleYPixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.BlueGreen:

                                // Handle BlueGreen Pixels
                                pixels = HandleBlueGreenPixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.BlueRed:

                                // Handle BlueGreen Pixels
                                pixels = HandleBlueRedPixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.GreenRed:

                                // Handle BlueGreen Pixels
                                pixels = HandleGreenRedPixels(pixels, criteria);

                                // required
                                break;

                            case PixelTypeEnum.LastUpdate:

                                // We are using the same pixels as the last query
                                pixels = LastUpdate;

                                // required
                                break;
                        }
                    }
                }
                
                
                // return value
                return pixels;
            }
            #endregion
            
            #region ApplyQuery()
            /// <summary>
            /// This method Apply Query
            /// </summary>
            public void ApplyQuery()
            {
                // Set the queryText
                string queryText = this.QueryTextBox.Text;

                // locals
                int alpha = 0;
                List<PixelInformation> pixels = this.PixelDatabase.Pixels;
                Graphics graphics = Canvas.CreateGraphics();
                Guid historyId = Guid.NewGuid();
                Color previousColor;

                // if the queryText exists
                if (TextHelper.Exists(queryText))
                {
                    // Parse the PixelQuery
                    PixelQuery pixelQuery = PixelQueryParser.ParsePixelQuery(queryText);

                    // if this is a valid query
                    if (pixelQuery.IsValid)
                    {
                        // Set the alpha value based upon the ActionType
                        alpha = SetAlpha(pixelQuery.ActionType, pixelQuery);

                        // if SetBackColor is the action type, and there is exactly 1 Criteria object
                        if ((pixelQuery.ActionType == ActionTypeEnum.SetBackColor) && (pixelQuery.HasCriteria) && (pixelQuery.Criteria.Count == 1))
                        {
                            // If RemoveBackColor is true
                            if (pixelQuery.Criteria[0].RemoveBackColor)
                            {
                                // Restore the background image
                                this.MainPanel.BackgroundImage = Properties.Resources.Gray_Slate_Small;

                                 // Set the BackColor
                                this.MainPanel.BackColor = Color.Transparent;
                            }
                            else
                            {
                                // remove the background image
                                this.MainPanel.BackgroundImage = null;

                                // Set the BackColor
                                this.MainPanel.BackColor = pixelQuery.Criteria[0].BackColor;
                            }
                        }
                        if (pixelQuery.ActionType == ActionTypeEnum.HideFrom)
                        {
                            // Handle hiding pixels from the selected directions until 
                            // the match color is found
                            HandleHideFrom(pixelQuery);
                        }
                        else if (pixelQuery.ActionType == ActionTypeEnum.Update)
                        {
                             // Find the pixels that match the Criteria given
                            pixels = ApplyCriteria(pixels, pixelQuery);

                            // if there are one or more pixels
                            if (ListHelper.HasOneOrMoreItems(pixels))
                            {
                                // Store the LastUpdate
                                this.LastUpdate = pixels;

                                Graph.Maximum = pixels.Count;
                                Graph.Minimum = 0;
                                Graph.Value = 0;
                                Graph.Visible = true;

                                // Get the color
                                Color color = pixelQuery.Color;

                                // Update the pixels
                                foreach (PixelInformation pixel in pixels)
                                {
                                    // get the prevoiusColor
                                    previousColor = this.DirectBitmap.GetPixel(pixel.X, pixel.Y);

                                    // if adjust color is true
                                    if (pixelQuery.AdjustColor)
                                    {
                                        // Adjust the color
                                        color = AdjustColor(previousColor, pixelQuery);
                                    }
                                    else if (pixelQuery.SwapColors)
                                    {
                                        // Swap two colors
                                        color = SwapColor(previousColor, pixelQuery);
                                    }

                                    // Set the pixel
                                    this.DirectBitmap.SetPixel(pixel.X, pixel.Y, color, historyId, previousColor);

                                    // Increment the value for Graph
                                    Graph.Value++;
                                }

                                // Hide the Graph
                                Graph.Visible = false;
                            }
                            else
                            {
                                // Show a message as a test (failure)
                                MessageBoxHelper.ShowMessage("No pixels could be found matching your search criteria", "No Pixels Were Found");
                            }
                        }
                        // if we are drawing
                        else if (pixelQuery.ActionType >= ActionTypeEnum.DrawLine)
                        {
                            // if there are one or more criteria items
                            if (ListHelper.HasOneOrMoreItems(pixelQuery.Criteria))
                            {
                                // get the first criteria
                                PixelCriteria criteria = pixelQuery.Criteria[0];

                                // if we are drawing a single line
                                if (criteria.RepeatType == RepeatTypeEnum.NoRepeat)
                                {
                                    // Draw the line
                                    DrawLine(criteria, alpha, this.DirectBitmap.Bitmap, historyId);
                                }
                                else
                                {
                                    // Draw repeating lines
                                    DrawRepeatingLines(criteria, alpha, this.DirectBitmap.Bitmap, historyId);
                                }
                            }
                        }
                        else
                        {
                            // Hide or Show

                            // Find the pixels that match the Criteria given
                            pixels = ApplyCriteria(pixels, pixelQuery);

                            // if we have pixels to apply the criteria to
                            if (ListHelper.HasOneOrMoreItems(pixels))
                            {
                                this.Graph.Maximum = pixels.Count;
                                this.Graph.Value = 0;
                                this.Graph.Visible = true;

                                // Refresh everything
                                this.Refresh();
                                Application.DoEvents();

                                // Iterate the collection of PixelInformation objects
                                foreach (PixelInformation pixel in pixels)
                                {
                                    // Get the color
                                    Color color = Color.FromArgb(alpha, pixel.Color);

                                    // Set the pixel
                                    this.DirectBitmap.SetPixel(pixel.X, pixel.Y, color, historyId, pixel.Color);

                                    // Update the Pixels so the database stays updated
                                    pixel.Color = color;

                                    // if we have not reached the end of the graph
                                    if (this.Graph.Maximum < (this.Graph.Value + 1))
                                    {
                                        // Increment the value for Graph
                                        this.Graph.Value++;
                                    }
                                }
                            }
                        }

                        // Set the background image
                        this.Canvas.BackgroundImage = this.DirectBitmap.Bitmap;

                        // Hide the Graph
                        this.Graph.Visible = false;

                        // Refresh everything
                        this.Refresh();
                        Application.DoEvents();
                    }
                }
            }
            #endregion

            #region CloseFile(bool resetOnly = false)
            /// <summary>
            /// This method Close File
            /// </summary>
            public void CloseFile(bool resetOnly = false)
            {
                // To Do: Prompt for changes

                // Reset the LineColor to use in case any lines are drawn.
                // This is the only place this can be changed
                lineColor = Color.Transparent;

                // Reset the value for LineColorSet
                LineColorSet = false;

                // Close the current file
                this.ImagePath = "";
                this.Canvas.BackgroundImage = null;

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
            
            #region DrawLine(PixelCriteria pixelCriteria, int alpha, Bitmap bitmap, Guid historyId, bool replaceColors = true)
            /// <summary>
            /// This method Draws a Line based upon the pixelCriteria
            /// </summary>
            public void DrawLine(PixelCriteria pixelCriteria, int alpha, Bitmap bitmap, Guid historyId, bool replaceColors = true)
            {
                // This is a little cumberson, but what this is doing is drawing a line with a replacement color 
                // (a color not in the source image). Next the pixels that match the replacement color are 
                // replaced with a transparent pixel. This has to be done since Pen object does not support full opacity.

                // if the LineColor has not been set
                if (!this.LineColorSet)
                {
                    // Find a color not in the image
                    this.LineColor = SetLineColor();
                }

                // Create a pen
                Pen pen = new Pen(LineColor, pixelCriteria.Thickness);

                // Create a graphics object
                Graphics graphics = Graphics.FromImage(bitmap);

                // Draw a line
                graphics.DrawLine(pen, pixelCriteria.StartPoint, pixelCriteria.EndPoint);

                // Update the Canvas
                this.Canvas.BackgroundImage = bitmap;

                // if replaceColors is true
                if (replaceColors)
                {
                    // Reload the PixelDatabase
                    PixelDatabase pixelDatabase = LoadPixelDatabaseEx(bitmap);

                    // Now get the pixels that are equal to the lineColor
                    List<PixelInformation> pixels = pixelDatabase.Pixels.Where(x => x.Color == LineColor).ToList();

                    // if one or more pixels were founds
                    if (ListHelper.HasOneOrMoreItems(pixels))
                    {
                        // iterate the pixels
                        foreach (PixelInformation pixel in pixels)
                        {
                            // attempt to find the source pixel
                            PixelInformation source = this.PixelDatabase.Pixels.FirstOrDefault(x => x.X == pixel.X && x.Y == pixel.Y);

                            // if the source pixel exists
                            if (NullHelper.Exists(source))
                            {
                                // Create a transparent color
                                Color transparent = Color.FromArgb(alpha, source.Color);

                                // Set the pixels
                                pixel.Color = transparent;

                                // Set the color
                                this.DirectBitmap.SetPixel(pixel.X, pixel.Y, transparent, historyId, source.Color);

                                // Update the color of the source
                                source.Color = transparent;
                            }
                        }

                        // force Repaint
                        this.Canvas.Invalidate();
                    }
                }
            }
            #endregion
            
            #region DrawRepeatingLines(PixelCriteria pixelCriteria, int alpha, Bitmap bitmap, Guid historyId)
            /// <summary>, 
            /// This method Draw Repeating Lines
            /// </summary>
            public void DrawRepeatingLines(PixelCriteria pixelCriteria, int alpha, Bitmap bitmap, Guid historyId)
            {
                // verify both objects exist                
                if (NullHelper.Exists(pixelCriteria, bitmap))
                {
                    // iterate the Reps
                    for (int x = 0; x < pixelCriteria.Repititions; x++)
                    {
                        // the first line does not have to be adjusted
                        if (x > 0)
                        {
                            // Move the Start and End Points before the next line is drawn
                            pixelCriteria = MoveLine(pixelCriteria);
                        }

                        // if this is the lastPixel
                        if (x == (pixelCriteria.Repititions - 1))
                        {
                            // Draw the line and replace the LineColor with a transparency. This only has to be done once.
                            DrawLine(pixelCriteria, alpha, bitmap, historyId, true);
                        }
                        else
                        {
                            // Draw the line, but do not replace the colors
                            DrawLine(pixelCriteria, alpha, bitmap, historyId, false);
                        }
                    }
                }
            }
            #endregion
            
            #region HandleBluePixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleBluePixels(List<PixelInformation> pixels, PixelCriteria criteria)
            {
                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(criteria)))
                {
                    switch (criteria.ComparisonType)
                    {   
                        case ComparisonTypeEnum.LessThan:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Blue <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Between:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Blue >= criteria.MinValue && x.Blue <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.GreaterThan:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Blue >= criteria.MinValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Equals:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Blue == criteria.TargetValue).ToList();

                            // required
                            break;
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion

            #region HandleBlueGreenPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleBlueGreenPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            {
                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(criteria)))
                {
                    switch (criteria.ComparisonType)
                    {   
                        case ComparisonTypeEnum.LessThan:

                            // Set the pixels
                            pixels = pixels.Where(x => x.BlueGreen <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Between:

                            // Set the pixels
                            pixels = pixels.Where(x => x.BlueGreen >= criteria.MinValue && x.BlueGreen <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.GreaterThan:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.BlueGreen >= criteria.MinValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Equals:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.BlueGreen == criteria.TargetValue).ToList();

                            // required
                            break;
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion

            #region HandleBlueRedPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleBlueRedPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            {
                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(criteria)))
                {
                    switch (criteria.ComparisonType)
                    {   
                        case ComparisonTypeEnum.LessThan:

                            // Set the pixels
                            pixels = pixels.Where(x => x.BlueRed <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Between:

                            // Set the pixels
                            pixels = pixels.Where(x => x.BlueRed >= criteria.MinValue && x.BlueRed <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.GreaterThan:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.BlueRed >= criteria.MinValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Equals:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.BlueRed == criteria.TargetValue).ToList();

                            // required
                            break;
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion

            #region HandleGreenPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleGreenPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            {
                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(criteria)))
                {
                    switch (criteria.ComparisonType)
                    {   
                        case ComparisonTypeEnum.LessThan:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Green <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Between:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Green >= criteria.MinValue && x.Green <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.GreaterThan:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Green >= criteria.MinValue).ToList();

                            // required
                            break;
                        
                         case ComparisonTypeEnum.Equals:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Green == criteria.TargetValue).ToList();

                            // required
                            break;
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion

            #region HandleGreenRedPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleGreenRedPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            {
                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(criteria)))
                {
                    switch (criteria.ComparisonType)
                    {   
                        case ComparisonTypeEnum.LessThan:

                            // Set the pixels
                            pixels = pixels.Where(x => x.GreenRed <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Between:

                            // Set the pixels
                            pixels = pixels.Where(x => x.GreenRed >= criteria.MinValue && x.GreenRed <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.GreaterThan:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.GreenRed >= criteria.MinValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Equals:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.GreenRed == criteria.TargetValue).ToList();

                            // required
                            break;
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion
            
            #region HandleHideFrom(PixelQuery pixelQuery)
            /// <summary>
            /// This method Handle Hide From
            /// </summary>
            public void HandleHideFrom(PixelQuery pixelQuery)
            {
                // If the pixelQuery object exists
                if (NullHelper.Exists(pixelQuery))
                {
                    // breakpoint only
                    pixelQuery = null;
                }
            }
            #endregion
            
            #region HandlePixelInfo(int x, int y)
            /// <summary>
            /// This method Handle Pixel Info
            /// </summary>
            public void HandlePixelInfo(int x, int y)
            {  
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
                PixelInformation pixel = new PixelInformation();

                // set the information on the pixel
                pixel.Color = color;
                pixel.X = x;
                pixel.Y = y;

                // Handle the display top in case the mouse is too far down
                int displayY = originalY;

                // if the height is too far down
                if (displayY > (canvasHeight - PixelInfo.Height - TitleBarHeight))
                {
                    // Move up a control's length
                    displayY = displayY - PixelInfo.Height - TitleBarHeight;
                }

                // Display the PixelInfo
                this.PixelInfo.DisplayPixel(pixel);
                this.PixelInfo.Left = LeftMarginPanel.Width + originalX + 32;
                this.PixelInfo.Top = TitleBarHeight + displayY;
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
            #endregion
            
            #region HandleRedPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleRedPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            {
                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(criteria)))
                {
                    switch (criteria.ComparisonType)
                    {   
                        case ComparisonTypeEnum.LessThan:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Red <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Between:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Red >= criteria.MinValue && x.Red <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.GreaterThan:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Red >= criteria.MinValue).ToList();

                            // required
                            break;

                         case ComparisonTypeEnum.Equals:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Red == criteria.TargetValue).ToList();

                            // required
                            break;
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion

            #region HandleTotalPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleTotalPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            {
                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(criteria)))
                {
                    switch (criteria.ComparisonType)
                    {   
                        case ComparisonTypeEnum.LessThan:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Total <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Between:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Total >= criteria.MinValue && x.Total <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.GreaterThan:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Total >= criteria.MinValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Equals:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Total == criteria.TargetValue).ToList();

                            // required
                            break;
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion

            #region HandleXPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleXPixels(List<PixelInformation> sourcePixels, PixelCriteria criteria)
            {
                // initial value
                List<PixelInformation> pixels = new List<PixelInformation>();

                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(sourcePixels)) && (NullHelper.Exists(criteria)))
                {
                    // Iterate the collection of PixelInformation objects
                    foreach (PixelInformation pixel in sourcePixels)
                    {  
                        switch (criteria.ComparisonType)
                        {   
                            case ComparisonTypeEnum.LessThan:
                                   
                                // if this point.X is less than the MaxValue of the criteria
                                if (pixel.X <= criteria.MaxValue)
                                {  
                                    // Add this pixel
                                    pixels.Add(pixel);
                                }
                                        
                                // required
                                break;

                            case ComparisonTypeEnum.Between:

                                // if this point.X is in range of the Min and Max values
                                if ((pixel.X >= criteria.MinValue) && (pixel.X <= criteria.MaxValue))
                                {  
                                    // Add this pixel
                                    pixels.Add(pixel);
                                }

                                // required
                                break;

                            case ComparisonTypeEnum.GreaterThan:

                                // if this point.X is less than the MaxValue of the criteria
                                if (pixel.X >= criteria.MinValue)
                                {  
                                    // Add this pixel
                                    pixels.Add(pixel);
                                }

                                // required
                                break;
                        }  
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion

            #region HandleYPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given
            /// </summary>
            public List<PixelInformation> HandleYPixels(List<PixelInformation> sourcePixels, PixelCriteria criteria)
            {
                // initial value
                List<PixelInformation> pixels = new List<PixelInformation>();

                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(sourcePixels)) && (NullHelper.Exists(criteria)))
                {
                    // Iterate the collection of PixelInformation objects
                    foreach (PixelInformation pixel in sourcePixels)
                    {  
                        switch (criteria.ComparisonType)
                        {   
                            case ComparisonTypeEnum.LessThan:
                                   
                                // if this point.Y is less than the MaxValue of the criteria
                                if (pixel.Y <= criteria.MaxValue)
                                {  
                                    // Add this pixel
                                    pixels.Add(pixel);
                                }
                                        
                                // required
                                break;

                            case ComparisonTypeEnum.Between:

                                // if this point.Y is in range of the Min and Max values
                                if ((pixel.Y >= criteria.MinValue) && (pixel.Y <= criteria.MaxValue))
                                {  
                                    // Add this pixel
                                    pixels.Add(pixel);
                                }

                                // required
                                break;

                            case ComparisonTypeEnum.GreaterThan:

                                // if this point.Y is less than the MaxValue of the criteria
                                if (pixel.Y >= criteria.MinValue)
                                {  
                                    // Add this pixel
                                    pixels.Add(pixel);
                                }

                                // required
                                break;
                        }  
                    }
                }
                
                // return value
                return pixels;
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

                // Create a Bitmap from the Source image
                Bitmap source = new Bitmap(this.Canvas.BackgroundImage);

                // Code To Lockbits
                BitmapData bitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);
                IntPtr pointer = bitmapData.Scan0;
                int size = Math.Abs(bitmapData.Stride) * source.Height;
                byte[] pixels = new byte[size];
                Marshal.Copy(pointer, pixels, 0, size);

                // End Code To Lockbits
                // Marshal.Copy(pixels,0,pointer, size);
                source.UnlockBits(bitmapData);

                // test only
                int length = pixels.Length;

                // Set the Max for the grid, minus 10 just for comfort
                this.Graph.Maximum = source.Width * source.Height + 1000;

                // Create a new instance of a 'PixelDatabase' object.
                this.PixelDatabase = new PixelDatabase();

                // locals
                Color color = Color.FromArgb(0, 0, 0);
                int red = 0;
                int green = 0;
                int blue = 0;
                int alpha = 0;

                // variables to hold height and width
                int width = source.Width;
                int height = source.Height;
                int x = -1;
                int y = 0;
                
                // Iterating the pixel array, every 4th byte is a new pixel, much faster than GetPixel
                for (int a = 0; a < pixels.Length; a = a + 4)
                {
                     // increment the value for x
                    x++;

                    // every new column
                    if (x >= width)
                    {
                        // reset x
                        x = 0;

                        // Increment the value for y
                        y++;
                    }      

                    // Increment the value
                    this.Graph.Value++;

                    // get the values for r, g, and blue
                    blue = pixels[a];
                    green = pixels[a + 1];
                    red = pixels[a + 2];
                    alpha = pixels[a + 3];
                    
                    // create a color
                    color = Color.FromArgb(alpha, red, green, blue);

                    // Add this point
                    PixelInformation pixelInformation = this.PixelDatabase.AddPixel(color, x, y);
                }

                // Create a DirectBitmap
                this.DirectBitmap = new DirectBitmap(source.Width, source.Height);

                // Now we must copy over the Pixels from the PixelDatabase to the DirectBitmap
                if ((this.HasPixelDatabase) && (ListHelper.HasOneOrMoreItems(this.PixelDatabase.Pixels)))
                {
                    // iterate the pixels
                    foreach (PixelInformation pixel in this.PixelDatabase.Pixels)
                    {
                        // Set the pixel at this spot
                        DirectBitmap.SetPixel(pixel.X, pixel.Y, pixel.Color);
                    }
                }

                // Set to False
                this.Analyzing = false;

                // Set the value for the property 'ImageLoaded' to true
                this.ImageLoaded = true;

                // Set the LineColor (finds a color not in the image)
                this.LineColor = SetLineColor();

                // Enable controls now that we are done analyzing
                UIEnable();
            }
            #endregion

            #region LoadPixelDatabaseEx(Bitmap bitmap)
            /// <summary>
            /// This method Loads the Pixel Database, but unlike the LoadPixelDatabase method, this object does
            /// not override the actual PixelDatabase
            /// </summary>
            public PixelDatabase LoadPixelDatabaseEx(Bitmap source)
            {
                // initial value
                PixelDatabase pixelDatabase = new PixelDatabase();

                // if the bitmap object exists
                if (source != null)
                {
                    // Set to true
                    this.Analyzing = true;

                    // Reset the Graph
                    this.Graph.Visible = true;
                    this.Graph.Value = 0;

                    // Enable or disable controls
                    UIEnable();

                    // Code To Lockbits
                    BitmapData bitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);
                    IntPtr pointer = bitmapData.Scan0;
                    int size = Math.Abs(bitmapData.Stride) * source.Height;
                    byte[] pixels = new byte[size];
                    Marshal.Copy(pointer, pixels, 0, size);

                    // End Code To Lockbits
                    // Marshal.Copy(pixels,0,pointer, size);
                    source.UnlockBits(bitmapData);

                    // test only
                    int length = pixels.Length;

                    // Set the Max for the grid, minus 10 just for comfort
                    this.Graph.Maximum = source.Width * source.Height + 1000;

                    // locals
                    Color color = Color.FromArgb(0, 0, 0);
                    int red = 0;
                    int green = 0;
                    int blue = 0;
                    int alpha = 0;

                    // variables to hold height and width
                    int width = source.Width;
                    int height = source.Height;
                    int x = -1;
                    int y = 0;
                
                    // Iterating the pixel array, every 4th byte is a new pixel, much faster than GetPixel
                    for (int a = 0; a < pixels.Length; a = a + 4)
                    {
                         // increment the value for x
                        x++;

                        // every new column
                        if (x >= width)
                        {
                            // reset x
                            x = 0;

                            // Increment the value for y
                            y++;
                        }      

                        // Increment the value
                        this.Graph.Value++;

                        // get the values for r, g, and blue
                        blue = pixels[a];
                        green = pixels[a + 1];
                        red = pixels[a + 2];
                        alpha = pixels[a + 3];

                        // create a coor
                        color = Color.FromArgb(alpha, red, green, blue);

                        // Add this pixel
                        PixelInformation pixelInformation = pixelDatabase.AddPixel(color, x, y);
                    }

                    // Set to False
                    this.Analyzing = false;

                    // Restore the UI
                    UIEnable();
                }

                // reutrn value
                return pixelDatabase;
            }
            #endregion
            
            #region MoveLine(PixelCriteria pixelCriteria)
            /// <summary>
            /// This method returns the Line
            /// </summary>
            public PixelCriteria MoveLine(PixelCriteria pixelCriteria)
            {
                // ensure the PixelCriteria exists
                if (NullHelper.Exists(pixelCriteria))
                {
                    // determine the action by the repeat type                    
                    switch (pixelCriteria.RepeatType)
                    {
                        case RepeatTypeEnum.Left:

                            // Adjust the StartPoint
                            pixelCriteria.StartPoint = new Point(pixelCriteria.StartPoint.X - pixelCriteria.Distance, pixelCriteria.StartPoint.Y);

                            // Adjust the EndPoint
                            pixelCriteria.EndPoint = new Point(pixelCriteria.EndPoint.X - pixelCriteria.Distance, pixelCriteria.EndPoint.Y);

                            // required
                            break;

                        case RepeatTypeEnum.Down:

                            // Adjust the StartPoint
                            pixelCriteria.StartPoint = new Point(pixelCriteria.StartPoint.X, pixelCriteria.StartPoint.Y + pixelCriteria.Distance);

                            // Adjust the EndPoint
                            pixelCriteria.EndPoint = new Point(pixelCriteria.EndPoint.X, pixelCriteria.EndPoint.Y + pixelCriteria.Distance);

                            // required
                            break;

                        case RepeatTypeEnum.Up:

                            // Adjust the StartPoint
                            pixelCriteria.StartPoint = new Point(pixelCriteria.StartPoint.X, pixelCriteria.StartPoint.Y - pixelCriteria.Distance);

                            // Adjust the EndPoint
                            pixelCriteria.EndPoint = new Point(pixelCriteria.EndPoint.X, pixelCriteria.EndPoint.Y - pixelCriteria.Distance);

                            // required
                            break;

                        case RepeatTypeEnum.Right:

                            // Adjust the StartPoint
                            pixelCriteria.StartPoint = new Point(pixelCriteria.StartPoint.X + pixelCriteria.Distance, pixelCriteria.StartPoint.Y);

                            // Adjust the EndPoint
                            pixelCriteria.EndPoint = new Point(pixelCriteria.EndPoint.X + pixelCriteria.Distance, pixelCriteria.EndPoint.Y);

                            // required
                            break;
                    }
                }
                
                // return value
                return pixelCriteria;
            }
            #endregion
            
            #region Reset()
            /// <summary>
            /// This method Reset
            /// </summary>
            public void Reset()
            { 
                // get a copy of the imagePath
                string imagePath = this.ImagePath;

                // Close the file
                CloseFile(true);

                // Set the ImagePath again (this reloads the image from disk and set the Canvas.BackgroundImage)
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
            
            #region SetAlpha(ActionTypeEnum actionType, PixelQuery pixelQuery = null)
            /// <summary>
            /// This method returns the Alpha
            /// </summary>
            public int SetAlpha(ActionTypeEnum actionType, PixelQuery pixelQuery = null)
            {
                // initial value
                int alpha = 0;

                // if ShowPixels than this changes
               if (actionType == ActionTypeEnum.ShowPixels)
                {
                    // set the alpha to 255
                    alpha = 255;
                }
                else if (actionType == ActionTypeEnum.Update)
                {
                    // If the pixelQuery object exists
                    if (NullHelper.Exists(pixelQuery))
                    {
                        // set the return value
                        alpha = pixelQuery.Alpha;
                    }
                    else
                    {
                        // Set to 255
                        alpha = 255;
                    }
                }
                
                // return value
                return alpha;
            }
            #endregion
            
            #region SetLineColor()
            /// <summary>
            /// This method returns the Line Color
            /// </summary>
            public Color SetLineColor()
            {
                // initial value
                Color lineColor = Color.Transparent;

                // If the PixelDatabase object exists
                if (this.HasPixelDatabase)
                {
                    // locals
                    List<PixelInformation> pixels = null;

                    // iterate red up to 255
                    for (int red = 0; red < 255; red++)
                    {
                        // iterate green up to 255
                        for (int green = 0; green < 255; green++)
                        {
                            // iterate blue up to 255
                            for (int blue = 0; blue < 255; blue++)
                            {
                                // attempt to get a list of pixels with this value
                                pixels = this.PixelDatabase.Pixels.Where(x => x.Red == red && x.Green == green && x.Blue == blue).ToList();

                                // if no pixels were found matching this color combination
                                if (!ListHelper.HasOneOrMoreItems(pixels))
                                {
                                    // set the return value
                                    lineColor = Color.FromArgb(red, green, blue);

                                    // Set to true
                                    LineColorSet = true;

                                    // break out of the loop
                                    break;
                                }
                            }

                            // if the line color has been set
                            if (LineColorSet)
                            {
                                 // break out of this loop also
                                 break;
                            }
                        }

                        // if the line color has been set
                        if (LineColorSet)
                        {
                            // break out of this loop also
                            break;
                        }
                    }
                }
                
                // return value
                return lineColor;
            }
            #endregion
            
            #region SwapColor(Color previousColor, PixelQuery pixelQuery)
            /// <summary>
            /// This method returns the Color
            /// </summary>
            public Color SwapColor(Color previousColor, PixelQuery pixelQuery)
            {
                // initial value
                Color color = previousColor;

                // If the pixelQuery object exists
                if (NullHelper.Exists(pixelQuery))                
                {
                    switch (pixelQuery.SwapType)
                    {
                        case SwapTypeEnum.BlueToGreen:

                            // create the new color
                            color = Color.FromArgb(previousColor.R, previousColor.B, previousColor.G);

                            // required
                            break;

                        case SwapTypeEnum.RedToBlue:

                            // create the new color
                            color = Color.FromArgb(previousColor.B, previousColor.G, previousColor.R);

                            // required
                            break;

                        case SwapTypeEnum.RedToGreen:

                            // create the new color
                            color = Color.FromArgb(previousColor.G, previousColor.R, previousColor.B);

                            // required
                            break;
                    }
                }
                
                // return value
                return color;
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
                this.ButtonPanel.Visible = this.HasImagePath;
                this.BottomMarginPanel.Visible = !this.HasImagePath;
                this.GraphPanel.Visible = this.Analyzing;
                this.Graph.Visible = this.Analyzing;

                // Handle the buttons
                this.CloseFileButton.Visible = ((this.ImageLoaded) && (!this.Analyzing));
                this.SaveButton.Visible = ((this.ImageLoaded) && (!this.Analyzing));
                this.SaveAsButton.Visible = ((this.ImageLoaded) && (!this.Analyzing));
                this.ResetButton.Visible = ((this.ImageLoaded) && (!this.Analyzing));
                this.ColorPickerButton.Visible = ((this.ImageLoaded) && (!this.Analyzing));
                this.UndoChangesButton.Visible = ((this.ImageLoaded) && (!this.Analyzing));
                
                // Show the QueryPanel if we are done analyzing the Pixel Database has any pixels
                this.QueryPanel.Visible = ((!this.Analyzing) && (this.HasPixelDatabase) && (this.PixelDatabase.HasOneOrMorePixels));

                // Refresh Everything
                this.Refresh();
                Application.DoEvents();
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
                get { return directBitmap; }
                set { directBitmap = value; }
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
            
            #region HasUpdates
            /// <summary>
            /// This property returns true if this object has an 'Updates'.
            /// </summary>
            public bool HasUpdates
            {
                get
                {
                    // initial value
                    bool hasUpdates = (this.LastUpdate != null);
                    
                    // return value
                    return hasUpdates;
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
                    if ((TextHelper.Exists(value)) && (File.Exists(value)))
                    {
                        // Load the Canvas
                        this.Canvas.BackgroundImage = Image.FromFile(value);
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

            #region LastUpdate
            /// <summary>
            /// This property gets or sets the value for 'LastUpdate'.
            /// </summary>
            public List<PixelInformation> LastUpdate
            {
                get { return lastUpdate; }
                set { lastUpdate = value; }
            }
            #endregion
            
            #region LineColor
            /// <summary>
            /// This property gets or sets the value for 'LineColor'.
            /// This value is the color the line is originally drawn.
            /// This is a color that is determined to not be in the image.
            /// </summary>
            public Color LineColor
            {
                get { return lineColor; }
                set 
                {  
                    // you can only change the value once
                    lineColor = value;
                }
            }
            #endregion
            
            #region LineColorSet
            /// <summary>
            /// This property gets or sets the value for 'LineColorSet'.
            /// </summary>
            public bool LineColorSet
            {
                get { return lineColorSet; }
                set { lineColorSet = value; }
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
