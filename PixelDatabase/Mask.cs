

#region using statements

using DataJuggler.PixelDatabase.Enumerations;
using System;
using System.Collections.Generic;

#endregion

namespace DataJuggler.PixelDatabase
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
        private List<PixelInformation> pixels;
        private MaskActionEnum action;
        #endregion

        #region Parameterized Constructor(string name, disabled = false)
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
        
            #region Action
            /// <summary>
            /// This property gets or sets the value for 'Action'.
            /// </summary>
            public MaskActionEnum Action
            {
                get { return action; }
                set { action = value; }
            }
            #endregion
            
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
            
            #region HasAction
            /// <summary>
            /// This property returns true if this object has an 'Action'.
            /// </summary>
            public bool HasAction
            {
                get
                {
                    // initial value
                    bool hasAction = (this.Action != MaskActionEnum.NoAction);
                    
                    // return value
                    return hasAction;
                }
            }
            #endregion
            
            #region HasName
            /// <summary>
            /// This property returns true if the 'Name' exists.
            /// </summary>
            public bool HasName
            {
                get
                {
                    // initial value
                    bool hasName = (!String.IsNullOrEmpty(this.Name));
                    
                    // return value
                    return hasName;
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
