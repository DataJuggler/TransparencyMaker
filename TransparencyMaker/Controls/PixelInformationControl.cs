

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransparencyMaker.Objects;

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
            
        #endregion

    }
    #endregion

}
