

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

#endregion

namespace DataJuggler.PixelDatabase
{

    #region class PixelDatabaseLoader
    /// <summary>
    /// This class is used to load PixelDatabases and their DirectBitmaps
    /// </summary>
    public class PixelDatabaseLoader
    {

        #region Methods

            #region LoadPixelDatabase(Image original, StatusUpdate updateCallback)
            /// <summary>
            /// This method is used to load a PixelDatabase and its DirectBitmap object.
            /// </summary>
            /// <param name="bitmap"></param>
            /// <returns></returns>
            public static PixelDatabase LoadPixelDatabase(Image original, StatusUpdate updateCallback)
            {
                // initial valule
                PixelDatabase pixelDatabase = null;

                try
                {
                    // if we have an image
                    if (NullHelper.Exists(original))
                    { 
                        // create a new bitmap
                        using (Bitmap source = new Bitmap(original))
                        {
                            // Code To Lockbits
                            BitmapData bitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);
                            IntPtr pointer = bitmapData.Scan0;
                            int size = Math.Abs(bitmapData.Stride) * source.Height;
                            byte[] pixels = new byte[size];
                            Marshal.Copy(pointer, pixels, 0, size);

                            // End Code To Lockbits

                            // Marshal.Copy(pixels,0,pointer, size);
                            source.UnlockBits(bitmapData);

                            // Create a new instance of a 'PixelDatabase' object.
                            pixelDatabase = new PixelDatabase();

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
                            int max = 0;

                            // if the UpdateCallback exists
                            if (NullHelper.Exists(updateCallback))
                            {
                                // Set the value for max
                                max = height * width + 1000;    

                                // Set the graph max
                                updateCallback("SetGraphMax", max);
                            }

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

                                // get the values for r, g, and blue
                                blue = pixels[a];
                                green = pixels[a + 1];
                                red = pixels[a + 2];
                                alpha = pixels[a + 3];
                    
                                // create a color
                                color = Color.FromArgb(alpha, red, green, blue);

                                // Add this pixel
                                PixelInformation pixelInformation = pixelDatabase.AddPixel(color, x, y);

                                //// refresh every 100,000
                                //if (a % 100000 == 0)
                                //{
                                //    // Set the updateCallback
                                //    updateCallback("Read " + String.Format("{0:n0}", a / 4) + " pixels of " + String.Format("{0:n0}", max / 4), a / 4);
                                //}
                            }

                            // Create a DirectBitmap
                            pixelDatabase.DirectBitmap = new DirectBitmap(source.Width, source.Height);
                        }

                        // Now we must copy over the Pixels from the PixelDatabase to the DirectBitmap
                        if ((NullHelper.Exists(pixelDatabase)) && (ListHelper.HasOneOrMoreItems(pixelDatabase.Pixels)))
                        {
                            // iterate the pixels
                            foreach (PixelInformation pixel in pixelDatabase.Pixels)
                            {
                                // Set the pixel at this spot
                                pixelDatabase.DirectBitmap.SetPixel(pixel.X, pixel.Y, pixel.Color);
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // write to console for now
                    DebugHelper.WriteDebugError("LoadPixelDatabase", "PixelDatabaseLoader", error);
                }
                finally
                {
                    
                }

                // return value
                return pixelDatabase;
            }
            #endregion

        #endregion

    }
    #endregion

}
