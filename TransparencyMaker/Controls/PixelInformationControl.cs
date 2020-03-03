

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Windows.Forms;
using DataJuggler.PixelDatabase.Net;

#endregion

namespace TransparencyMaker.Controls
{

    #region class PixelInformationControl
    /// <summary>
    /// This control is used to display information about a pixel as you place the mouse over
    /// a point.
    /// </summary>
    public partial class PixelInformationControl : UserControl
    {

        #region Private Variables
        private PixelInformation pixel;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'PixelInformationControl' object.
        /// </summary>
        public PixelInformationControl()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Events

            #region AlphaImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AlphaImage' is clicked.
            /// </summary>
            private void AlphaImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("Alpha");
            }
            #endregion
            
            #region AlphaLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AlphaLabel' is clicked.
            /// </summary>
            private void AlphaLabel_Click(object sender, EventArgs e)
            {
                 // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send the red value
                    SendMessage(Pixel.Alpha.ToString());
                }
            }
            #endregion
            
            #region BetweenButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'BetweenButton' is clicked.
            /// </summary>
            private void BetweenButton_Click(object sender, EventArgs e)
            {
                // send Between  to the query text box
                SendMessage("Between");
            }
            #endregion
            
            #region BlueImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'BlueImage' is clicked.
            /// </summary>
            private void BlueImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("Blue");
            }
            #endregion
            
            #region BlueLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'BlueLabel' is clicked.
            /// </summary>
            private void BlueLabel_Click(object sender, EventArgs e)
            {
                // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send the red value
                    SendMessage(Pixel.Red.ToString());
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
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region CyanImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CyanImage' is clicked.
            /// </summary>
            private void CyanImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("BlueGreen");
            }
            #endregion
            
            #region CyanLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CyanLabel' is clicked.
            /// </summary>
            private void CyanLabel_Click(object sender, EventArgs e)
            {
                 // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send the red value
                    SendMessage(Pixel.BlueGreen.ToString());
                }
            }
            #endregion
            
            #region EqualButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'EqualButton' is clicked.
            /// </summary>
            private void EqualButton_Click(object sender, EventArgs e)
            {
                // send = to the query text box
                SendMessage("=");
            }
            #endregion
            
            #region GreaterThanButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'GreaterThanButton' is clicked.
            /// </summary>
            private void GreaterThanButton_Click(object sender, EventArgs e)
            {
                // send > to the query text box
                SendMessage(">");
            }
            #endregion
            
            #region GreenImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'GreenImage' is clicked.
            /// </summary>
            private void GreenImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("Green");
            }
            #endregion
            
            #region GreenLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'GreenLabel' is clicked.
            /// </summary>
            private void GreenLabel_Click(object sender, EventArgs e)
            {
                // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send the red value
                    SendMessage(Pixel.Green.ToString());
                }
            }
            #endregion
            
            #region InLastUpdateButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'InLastUpdateButton' is clicked.
            /// </summary>
            private void InLastUpdateButton_Click(object sender, EventArgs e)
            {
                // send Pixels In LastUpdate to the query text box
                SendMessage("Pixels In LastUpdate");
            }
            #endregion
            
            #region LessThanButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'LessThanButton' is clicked.
            /// </summary>
            private void LessThanButton_Click(object sender, EventArgs e)
            {
                // send < to the query text box
                SendMessage("<");
            }
            #endregion
            
            #region PurpleImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'PurpleImage' is clicked.
            /// </summary>
            private void PurpleImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("BlueRed");
            }
            #endregion
            
            #region PurpleLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'PurpleLabel' is clicked.
            /// </summary>
            private void PurpleLabel_Click(object sender, EventArgs e)
            {
                // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send the red value
                    SendMessage(Pixel.BlueRed.ToString());
                }
            }
            #endregion
            
            #region RedImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RedImage' is clicked.
            /// </summary>
            private void RedImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("Red");
            }
            #endregion
            
            #region RedLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RedLabel' is clicked.
            /// </summary>
            private void RedLabel_Click(object sender, EventArgs e)
            {
                // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send the red value
                    SendMessage(Pixel.Red.ToString());
                }
            }
            #endregion
            
            #region SumImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'SumImage' is clicked.
            /// </summary>
            private void SumImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("Total");
            }
            #endregion
            
            #region SumLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'SumLabel' is clicked.
            /// </summary>
            private void SumLabel_Click(object sender, EventArgs e)
            {
                // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send the red value
                    SendMessage(Pixel.Total.ToString());
                }
            }
            #endregion
            
            #region XImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'XImage' is clicked.
            /// </summary>
            private void XImage_Click(object sender, EventArgs e)
            { 
                // Send a message to the parent
                SendMessage("X");
            }
            #endregion
            
            #region XLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'XLabel' is clicked.
            /// </summary>
            private void XLabel_Click(object sender, EventArgs e)
            {
                // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send a message to the parent
                    SendMessage(Pixel.X.ToString());
                }
            }
            #endregion
            
            #region YellowImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'YellowImage' is clicked.
            /// </summary>
            private void YellowImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("GreenRed");
            }
            #endregion
            
            #region YellowLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'YellowLabel' is clicked.
            /// </summary>
            private void YellowLabel_Click(object sender, EventArgs e)
            {
                 // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send the red value
                    SendMessage(Pixel.GreenRed.ToString());
                }
            }
            #endregion
            
            #region YImage_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'YImage' is clicked.
            /// </summary>
            private void YImage_Click(object sender, EventArgs e)
            {
                // Send a message to the parent
                SendMessage("Y");
            }
            #endregion
            
            #region YLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'YLabel' is clicked.
            /// </summary>
            private void YLabel_Click(object sender, EventArgs e)
            {
                // if the value for HasPixel is true
                if (HasPixel)
                {
                    // Send a message to the parent
                    SendMessage(Pixel.Y.ToString());
                }
            }
            #endregion
            
        #endregion

        #region Methods            

            #region DisplayPixel(PixelInformation pixel)
            /// <summary>
            /// This method Display Pixel
            /// </summary>
            public void DisplayPixel(PixelInformation pixel)
            {
                // locals
                int red = 0;
                int green = 0;
                int blue = 0;
                int alpha = 0;
                int x = 0;
                int y = 0;
                int greenRed = 0;
                int blueGreen = 0;
                int blueRed = 0;
                int total = 0;

                // store the arg
                this.Pixel = pixel;

                // If the pixel object exists
                if (NullHelper.Exists(pixel))
                {
                    // set the values
                    red = pixel.Red;
                    green = pixel.Green;
                    blue = pixel.Blue;
                    alpha = pixel.Alpha;
                    greenRed = pixel.GreenRed;
                    blueGreen = pixel.BlueGreen;
                    blueRed = pixel.BlueRed;
                    total = pixel.Total;
                    x = pixel.X;
                    y = pixel.Y;
                }

                // display the values
                this.RedLabel.Text = red.ToString();
                this.GreenLabel.Text = green.ToString();
                this.BlueLabel.Text = blue.ToString();
                this.AlphaLabel.Text = alpha.ToString();
                this.YellowLabel.Text = greenRed.ToString();
                this.CyanLabel.Text = blueGreen.ToString();
                this.PurpleLabel.Text = blueRed.ToString();
                this.SumLabel.Text = total.ToString();
                this.XLabel.Text = x.ToString();
                this.YLabel.Text = y.ToString();

                // Update the UI
                this.Refresh();
                Application.DoEvents();
            }
            #endregion

            #region SendMessage(string text)
            /// <summary>
            /// This method returns the Message
            /// </summary>
            public void SendMessage(string text)
            {
                // if the ParentHost exists
                if (HasParentHost)
                {
                    // Add to the text of the query string
                    ParentHost.AppendQueryText(text);
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasParentHost
            /// <summary>
            /// This property returns true if this object has a 'ParentHost'.
            /// </summary>
            public bool HasParentHost
            {
                get
                {
                    // initial value
                    bool hasParentHost = (this.ParentHost != null);
                    
                    // return value
                    return hasParentHost;
                }
            }
            #endregion
            
            #region HasPixel
            /// <summary>
            /// This property returns true if this object has a 'Pixel'.
            /// </summary>
            public bool HasPixel
            {
                get
                {
                    // initial value
                    bool hasPixel = (this.Pixel != null);
                    
                    // return value
                    return hasPixel;
                }
            }
            #endregion
            
            #region ParentHost
            /// <summary>
            /// This read only property returns the value for 'ParentHost'.
            /// </summary>
            public MainForm ParentHost
            {
                get
                {
                    // set the return value
                    MainForm parentHost = this.ParentForm as MainForm;
                    
                    // return value
                    return parentHost;
                }
            }
            #endregion
            
            #region Pixel
            /// <summary>
            /// This property gets or sets the value for 'Pixel'.
            /// </summary>
            public PixelInformation Pixel
            {
                get { return pixel; }
                set { pixel = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
