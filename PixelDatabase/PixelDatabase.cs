

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using DataJuggler.PixelDatabase.Enumerations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.PixelDatabase
{

    #region class PixelDatabase
    /// <summary>
    /// This class represents a collection of PixelInformation objects
    /// </summary>
    public class PixelDatabase
    {

        #region Private Variables
        private List<PixelInformation> pixels;
        private DirectBitmap directBitmap;
        private MaskManager maskManager;
        private List<PixelInformation> lastUpdate;
        private bool abort;
        private Color lineColor;
        private bool lineColorSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a PixelDatabase object
        /// </summary>
        public PixelDatabase()
        {
            // Create a new collection of 'PixelInformation' objects.
            this.Pixels = new List<PixelInformation>();
        }
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

                            case PixelTypeEnum.Alpha:

                                // Handle Alpha Pixels
                                pixels = HandleAlphaPixels(pixels, criteria);

                                // required
                                break;
                        }
                    }
                }
                
                // return value
                return pixels;
            }
            #endregion

            #region AddPixel(Color color, int x, int y)
            /// <summary>
            /// method returns the Pixel
            /// </summary>
            public PixelInformation AddPixel(Color color, int x, int y)
            {  
                // Create a pixe
                PixelInformation pixel = new PixelInformation();

                // Set the color
                pixel.Color = color;

                // Set the values for x and y
                pixel.X = x;
                pixel.Y = y;

                /// The Index is set before the count increments when this item is added
                pixel.Index = this.Pixels.Count;

                // Add this pixel
                this.Pixels.Add(pixel);

                // return value
                return pixel;
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

            #region ApplyQuery(string queryText)
            /// <summary>
            /// This method parses and applies the queryText passed in.
            /// </summary>
            /// <param name="queryText"></param>
            public void ApplyQuery(string queryText, StatusUpdate status)
            {
                // locals
                int alpha = 0;
                List<PixelInformation> pixels = this.Pixels;
                Bitmap bmp = new Bitmap(200, 100);
                Graphics g = Graphics.FromImage(bmp);
                Guid historyId = Guid.NewGuid();
                Color color;
                bool checkForMask = false;

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
                            // this is TransparencyMaker specific

                            // If RemoveBackColor is true
                            if (pixelQuery.Criteria[0].RemoveBackColor)
                            {
                                // remove the back color
                                status("RemoveBackColor", 0);
                            }
                            else
                            {
                                // Send a message
                                string message = "SetBackColor" + pixelQuery.Criteria[0].BackColor.Name;

                                // Set the back color
                                status(message, 0);
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
                            // if Clear All
                            if ((HasMaskManager) && (pixelQuery.HasMask) && (pixelQuery.Mask.HasAction) && (pixelQuery.Mask.Action == MaskActionEnum.ClearAll))
                            {
                                // Recreate the MaskManager
                                this.MaskManager = new MaskManager();
                            }

                            // Find the pixels that match the Criteria given
                            pixels = ApplyCriteria(pixels, pixelQuery);

                            // if there are one or more pixels
                            if (ListHelper.HasOneOrMoreItems(pixels))
                            {
                                // Store the LastUpdate
                                this.LastUpdate = pixels;

                                // Get the color
                                color = pixelQuery.Color;

                                // If the value for the property pixelQuery.HasMask is true
                                if (pixelQuery.HasMask)
                                {
                                    // Handle the mask in the Pixel database
                                    HandleMask(pixels, pixelQuery.Mask, status);
                                }
                                else
                                {
                                    // If there are one or more Masks
                                    checkForMask = ListHelper.HasOneOrMoreItems(MaskManager.Masks);

                                    // Apply these pixels
                                    ApplyPixels(pixels, pixelQuery, status);

                                    // if the value for checkForMask is true
                                    if (checkForMask)
                                    {
                                        foreach (Mask mask in MaskManager.Masks)      
                                        {
                                            // Apply the pixels
                                            ApplyPixels(mask.Pixels, pixelQuery, status, true);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                
                                status("No pixels could be found matching your search criteria", 0);
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
                                    DrawLine(criteria, alpha, this.DirectBitmap.Bitmap, historyId, status);
                                }
                                else
                                {
                                    // Draw repeating lines
                                    DrawRepeatingLines(criteria, alpha, this.DirectBitmap.Bitmap, historyId, status);
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
                                // Refresh everything
                                // this.Refresh();
                                // Application.DoEvents();

                                // Iterate the collection of PixelInformation objects
                                foreach (PixelInformation pixel in pixels)
                                {
                                    // Get the color
                                    color = Color.FromArgb(alpha, pixel.Color);

                                    // Set the pixel
                                    this.DirectBitmap.SetPixel(pixel.X, pixel.Y, color, historyId, pixel.Color);

                                    // Update the Pixels so the database stays updated
                                    pixel.Color = color;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region ApplyPixels(List<PixelInformation> pixels, PixelQuery pixelQuery, StatusUpdate status, bool isMask = false)
            /// <summary>
            /// This method Apply Pixels
            /// </summary>
            public void ApplyPixels(List<PixelInformation> pixels, PixelQuery pixelQuery, StatusUpdate status, bool isMask = false)
            {
                // locals
                Color previousColor;
                Color color = Color.Empty;
                Guid historyId = Guid.NewGuid();
                int count = 0;
                
                // Update the pixels
                foreach (PixelInformation pixel in pixels)
                {  
                    // get the prevoiusColor
                    previousColor = this.DirectBitmap.GetPixel(pixel.X, pixel.Y);

                    // Get the color
                    color = pixel.Color;

                    // if this pixel is not part of any active masks
                    if ((pixelQuery.AdjustColor) || (pixelQuery.SwapColors) || (pixelQuery.SetColor))
                    {
                        // if this is not a mask, masks get set as is
                        if (!isMask)
                        {
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
                            else if (pixelQuery.SetColor)
                            {
                                // Set the color from here
                                color = pixelQuery.Color;
                            }
                        }

                        // Increment the value for count
                        count++;

                        // refresh every 500,000 in case this is a long query
                        if (count % 500000 == 0)
                        {
                            // if abort is true
                            if (Abort)
                            {
                                // Show the user a message
                                status("Operation Aborted.", 0);

                                // break out of the loop
                                break;
                            }
                            else
                            {
                                // Update the pixels affected by the query
                                status("Updated " + String.Format("{0:n0}", count) + " of " +  String.Format("{0:n0}", pixels.Count), count);    
                            }
                        }
                    }

                    // Set the pixel
                    this.DirectBitmap.SetPixel(pixel.X, pixel.Y, color, historyId, previousColor);
                }

                // Update the pixels affected by the query
                status("Updated " + String.Format("{0:n0}", count) + " pixels.", count);

                // Reset
                Abort = false;
            }
            #endregion

            #region DrawLine(PixelCriteria pixelCriteria, int alpha, Bitmap bitmap, Guid historyId, StatusUpdate status, bool replaceColors = true)
            /// <summary>
            /// This method Draws a Line based upon the pixelCriteria
            /// </summary>
            public void DrawLine(PixelCriteria pixelCriteria, int alpha, Bitmap bitmap, Guid historyId, StatusUpdate status, bool replaceColors = true)
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

                // if replaceColors is true
                if (replaceColors)
                {
                    // Reload the PixelDatabase
                    PixelDatabase pixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(bitmap, null);

                    // Now get the pixels that are equal to the lineColor
                    List<PixelInformation> pixels = pixelDatabase.Pixels.Where(x => x.Color == LineColor).ToList();

                    // if one or more pixels were founds
                    if (ListHelper.HasOneOrMoreItems(pixels))
                    {
                        // iterate the pixels
                        foreach (PixelInformation pixel in pixels)
                        {
                            // attempt to find the source pixel
                            PixelInformation source = this.Pixels.FirstOrDefault(x => x.X == pixel.X && x.Y == pixel.Y);

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
                    }
                }
            }
            #endregion
            
            #region DrawRectangle()
            /// <summary>
            /// This method Draw Rectangle
            /// </summary>
            /// <param name="point1">The top left corner of the rectangle</param>
            /// <param name="point2">The bottom right</param>
            public void DrawRectangle(Point point1, Point point2)
            {
                if ((point1 != Point.Empty) && (point2 != Point.Empty))
                {
                    // get the color to draw in
                    Color yellow = Color.Yellow;

                    // draw top line
                    for (int x = point1.X; x < point2.X; x++)
                    {
                        // Draw the line
                        DirectBitmap.SetPixel(x, point1.Y, yellow);  
                    }

                    // draw left line

                    // draw left line
                    for (int y = point1.Y; y < point2.Y; y++)
                    {
                        // Draw the line
                        DirectBitmap.SetPixel(point1.X, y, yellow);  
                    }

                    // draw bottom line
                    for (int x = point1.X; x < point2.X; x++)
                    {
                        // Draw the line
                        DirectBitmap.SetPixel(x, point2.Y, yellow);  
                    }

                    // draw right line
                    for (int y = point1.Y; y < point2.Y; y++)
                    {
                        // Draw the line
                        DirectBitmap.SetPixel(point2.X, y, yellow);  
                    }
                }
            }
            #endregion
            
            #region DrawRepeatingLines(PixelCriteria pixelCriteria, int alpha, Bitmap bitmap, Guid historyId, StatusUpdate status)
            /// <summary>, 
            /// This method Draw Repeating Lines
            /// </summary>
            public void DrawRepeatingLines(PixelCriteria pixelCriteria, int alpha, Bitmap bitmap, Guid historyId, StatusUpdate status)
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
                            DrawLine(pixelCriteria, alpha, bitmap, historyId, status, true);
                        }
                        else
                        {
                            // Draw the line, but do not replace the colors
                            DrawLine(pixelCriteria, alpha, bitmap, historyId, status, false);
                        }
                    }
                }
            }
            #endregion

            #region HandleAlphaPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            /// <summary>
            /// This method returns a list of pixels that match the criteria given based upon Alpha values
            /// </summary>
            public List<PixelInformation> HandleAlphaPixels(List<PixelInformation> pixels, PixelCriteria criteria)
            {
                // verify everything is valid
                if ((ListHelper.HasOneOrMoreItems(pixels)) && (NullHelper.Exists(criteria)))
                {
                    switch (criteria.ComparisonType)
                    {   
                        case ComparisonTypeEnum.LessThan:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Alpha <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Between:

                            // Set the pixels
                            pixels = pixels.Where(x => x.Alpha >= criteria.MinValue && x.Alpha <= criteria.MaxValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.GreaterThan:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Alpha >= criteria.MinValue).ToList();

                            // required
                            break;

                        case ComparisonTypeEnum.Equals:

                            // Get the pixels greater than the mixValue
                            pixels = pixels.Where(x => x.Alpha == criteria.TargetValue).ToList();

                            // required
                            break;
                    }
                }
                
                // return value
                return pixels;
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
            
            #region HandleMask(List<PixelInformation> pixels, Mask mask, StatusUpdate status)
            /// <summary>
            /// This method returns the Mask
            /// </summary>
            public void HandleMask(List<PixelInformation> pixels, Mask mask, StatusUpdate status)
            {
                // If the MaskManager and Mask both exist, and the mask is valid
                if ((this.HasMaskManager) && (MaskManager.HasMasks) && (NullHelper.Exists(mask)) && (mask.HasAction) && (mask.HasName))
                { 
                    // if Replace or Clear
                    if ((mask.Action == MaskActionEnum.Replace) || (mask.Action == MaskActionEnum.Clear))
                    {
                        // Find the existing Mask
                        Mask existingMask = MaskManager.Masks.FirstOrDefault(x => x.Name == mask.Name);

                        // if this already mask exists
                        if (NullHelper.Exists(existingMask))
                        {
                            // Remove this Mask
                            MaskManager.Masks.Remove(existingMask);

                            // Show the user something happened
                            status(Environment.NewLine + "Mask " + mask.Name + " Removed", 0);
                        }
                    }

                     // if this is an add or a name
                    if ((mask.Action == MaskActionEnum.Add) || (mask.Action == MaskActionEnum.Replace))
                    {
                        // Set the Pixels
                        mask.Pixels = pixels;

                        // Add this Mask
                        MaskManager.Masks.Add(mask);

                        // Show the TextBox
                        status("Mask " + mask.Name + " Created With " + String.Format("{0:n0}", pixels.Count) + " Pixels", 0);
                    }
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

                // locals
                List<PixelInformation> pixels = null;

                if (ListHelper.HasOneOrMoreItems(pixels))
                {
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
                                pixels = this.Pixels.Where(x => x.Red == red && x.Green == green && x.Blue == blue).ToList();

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
            
            #region HasLastUpdate
            /// <summary>
            /// This property returns true if this object has a 'LastUpdate'.
            /// </summary>
            public bool HasLastUpdate
            {
                get
                {
                    // initial value
                    bool hasLastUpdate = (this.LastUpdate != null);
                    
                    // return value
                    return hasLastUpdate;
                }
            }
            #endregion
            
            #region HasMaskManager
            /// <summary>
            /// This property returns true if this object has a 'MaskManager'.
            /// </summary>
            public bool HasMaskManager
            {
                get
                {
                    // initial value
                    bool hasMaskManager = (this.MaskManager != null);
                    
                    // return value
                    return hasMaskManager;
                }
            }
            #endregion
            
            #region HasOneOrMorePixels
            /// <summary>
            /// This property returns true if this object has one or more 'Pixels'.
            /// </summary>
            public bool HasOneOrMorePixels
            {
                get
                {
                    // initial value
                    bool hasOneOrMorePixels = ((this.HasPixels) && (this.Pixels.Count > 0));
                    
                    // return value
                    return hasOneOrMorePixels;
                }
            }
            #endregion

            #region HasPixels
            /// <summary>
            /// This property returns true if this object has a 'Pixels'.
            /// </summary>
            public bool HasPixels
            {
                get
                {
                    // initial value
                    bool hasPixels = (this.Pixels != null);
                    
                    // return value
                    return hasPixels;
                }
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
            /// </summary>
            public Color LineColor
            {
                get { return lineColor; }
                set { lineColor = value; }
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
            
            #region MaskManager
            /// <summary>
            /// This property gets or sets the value for 'MaskManager'.
            /// </summary>
            public MaskManager MaskManager
            {
                get { return maskManager; }
                set { maskManager = value; }
            }
            #endregion
            
            #region Pixels
            /// <summary>
            /// This property gets or sets the value for 'Pixels'.
            /// </summary>
            public List<PixelInformation> Pixels
            {
                get { return pixels; }
                set { pixels = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
