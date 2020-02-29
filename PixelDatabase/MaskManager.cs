

#region using statements

using DataJuggler.Core.UltimateHelper;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace DataJuggler.PixelDatabase
{

    #region class MaskManager
    /// <summary>
    /// This class is used to keep track of pixels that have been assigned to a Mask.
    /// </summary>
    public class MaskManager
    {
        
        #region Private Variables
        private List<Mask> masks;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MaskManager' object.
        /// </summary>
        public MaskManager()
        {
            // Create a new list
            Masks = new List<Mask>();
        }
        #endregion
        
        #region Methods
            
            #region IsPixelInMask(int x, int y)
            /// <summary>
            /// This method Is Pixel In Mask
            /// </summary>
            public bool IsPixelInMask(int x, int y)
            {
                // initial value
                bool isPixelInMask = false;
                bool outerLoopBreak = false;
                
                // if the value for HasMasks is true
                if (HasMasks)
                {
                    // Iterate the collection of Mask objects
                    foreach (Mask mask in Masks)
                    {
                        // if we found a pixel in this mask
                        if (outerLoopBreak)
                        {
                            // break out of loop
                            break;
                        }
                        
                        // If the value for the property mask.HasPixels is true
                        if ((mask.HasPixels) && (!mask.Disabled))
                        {
                            // Attempt to find this pixel
                            PixelInformation pixel = mask.Pixels.FirstOrDefault(a => a.X == x && a.Y == y);
                            
                            // if the pixel was found
                            if (NullHelper.Exists(pixel)) 
                            {
                                // Set the return value
                                isPixelInMask = true;
                                
                                // Set this to true in case there is more than one mask
                                outerLoopBreak = true;
                                
                                // break out of the loop
                                break;
                            }
                        }
                    }
                }
                
                // return value
                return isPixelInMask;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region HasMasks
            /// <summary>
            /// This property returns true if this object has a 'Masks'.
            /// </summary>
            public bool HasMasks
            {
                get
                {
                    // initial value
                    bool hasMasks = (this.Masks != null);
                    
                    // return value
                    return hasMasks;
                }
            }
            #endregion
            
            #region Masks
            /// <summary>
            /// This property gets or sets the value for 'Masks'.
            /// </summary>
            public List<Mask> Masks
            {
                get { return masks; }
                set { masks = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
