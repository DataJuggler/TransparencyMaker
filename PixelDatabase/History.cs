

#region using statements

using System;
using System.Collections.Generic;

#endregion

namespace DataJuggler.PixelDatabase
{

    #region class History
    /// <summary>
    /// This class is used to keep track of history.
    /// </summary>
    public class History
    {
        
        #region Private Variables
        private List<PixelInformation> changedPixels;
        private Guid id;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'History' object.
        /// </summary>
        public History(Guid id)
        {
            // Create a new collection of 'PixelInformation' objects.
            this.ChangedPixels = new List<PixelInformation>();

            // Set the Id
            this.Id = id;
        }
        #endregion
        
        #region Properties
            
            #region ChangedPixels
            /// <summary>
            /// This property gets or sets the value for 'ChangedPixels'.
            /// </summary>
            public List<PixelInformation> ChangedPixels
            {
                get { return changedPixels; }
                set { changedPixels = value; }
            }
            #endregion
            
            #region HasChangedPixels
            /// <summary>
            /// This property returns true if this object has a 'ChangedPixels'.
            /// </summary>
            public bool HasChangedPixels
            {
                get
                {
                    // initial value
                    bool hasChangedPixels = (this.ChangedPixels != null);
                    
                    // return value
                    return hasChangedPixels;
                }
            }
            #endregion
            
            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            public Guid Id
            {
                get { return id; }
                set { id = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
