

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace TransparencyMaker.Objects
{

    #region class Mask
    /// <summary>
    /// A Mask is used to designate pixels that will not be affect as you apply Update queries (for now).
    /// Each Pixel can contain one or more masks, and if any masks have On they are considered active.
    /// A Mask is also used in the PixelQuery object to store the information about the mask, so it can
    /// be applied to pixels.
    /// </summary>
    public class Mask
    {
        
        #region Private Variables
        private string name;
        private bool disabled;
        #endregion

        #region Mask(string name, disabled = false)
        /// <summary>
        /// Create a new instance of a Mask object
        /// </summary>
        /// <param name="name"></param>
        public Mask(string name, bool disabled = false)
        {
            // store the value for name
            Name = name;
            Disabled = disabled;
        }
        #endregion

        #region Properties
        
            #region Disabled
            /// <summary>
            /// This property gets or sets the value for 'Disabled'.
            /// </summary>
            public bool Disabled
            {
                get { return disabled; }
                set { disabled = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
