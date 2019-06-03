

#region using statements

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransparencyMaker.Enumerations;

#endregion

namespace TransparencyMaker.Objects
{

    #region class PixelQuery
    /// <summary>
    /// This class contains a set of one or more PixelCriterias.
    /// </summary>
    public class PixelQuery
    {

        #region Private Variables
        private ActionTypeEnum actionType;
        private List<PixelCriteria> criteria;
        private Directions directions;
        private int red;
        private int green;
        private int blue;
        private int alpha;
        private Color color;
        private bool colorSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a PixelQuery object
        /// </summary>
        public PixelQuery()
        {
            // Create a new instance of a 'Directions' object.
            this.Directions = new Directions();
        }
        #endregion

        #region Properties

            #region ActionType
            /// <summary>
            /// This property gets or sets the value for 'ActionType'.
            /// </summary>
            public ActionTypeEnum ActionType
            {
                get { return actionType; }
                set { actionType = value; }
            }
            #endregion
            
            #region Alpha
            /// <summary>
            /// This property gets or sets the value for 'Alpha'.
            /// </summary>
            public int Alpha
            {
                get { return alpha; }
                set { alpha = value; }
            }
            #endregion
            
            #region Blue
            /// <summary>
            /// This property gets or sets the value for 'Blue'.
            /// </summary>
            public int Blue
            {
                get { return blue; }
                set { blue = value; }
            }
            #endregion
            
            #region Color
            /// <summary>
            /// This property gets or sets the value for 'Color'.
            /// </summary>
            public Color Color
            {
                get { return color; }
                set 
                {
                    // set the value
                    color = value;

                    // Set the value for the property 'ColorSet' to true
                    colorSet = true;
                }
            }
            #endregion
            
            #region ColorSet
            /// <summary>
            /// This property gets or sets the value for 'ColorSet'.
            /// </summary>
            public bool ColorSet
            {
                get { return colorSet; }
                set { colorSet = value; }
            }
            #endregion
            
            #region Criteria
            /// <summary>
            /// This property gets or sets the value for 'Criteria'.
            /// </summary>
            public List<PixelCriteria> Criteria
            {
                get { return criteria; }
                set { criteria = value; }
            }
            #endregion
            
            #region Directions
            /// <summary>
            /// This property gets or sets the value for 'Directions'.
            /// </summary>
            public Directions Directions
            {
                get { return directions; }
                set { directions = value; }
            }
            #endregion
            
            #region Green
            /// <summary>
            /// This property gets or sets the value for 'Green'.
            /// </summary>
            public int Green
            {
                get { return green; }
                set { green = value; }
            }
            #endregion
            
            #region HasCriteria
            /// <summary>
            /// This property returns true if this object has a 'Criteria'.
            /// </summary>
            public bool HasCriteria
            {
                get
                {
                    // initial value
                    bool hasCriteria = (this.Criteria != null);
                    
                    // return value
                    return hasCriteria;
                }
            }
            #endregion
            
            #region HasDirections
            /// <summary>
            /// This property returns true if this object has a 'Directions'.
            /// </summary>
            public bool HasDirections
            {
                get
                {
                    // initial value
                    bool hasDirections = (this.Directions != null);
                    
                    // return value
                    return hasDirections;
                }
            }
            #endregion
            
            #region IsValid
            /// <summary>
            /// This read only property returns the value for 'IsValid'.
            /// </summary>
            public bool IsValid
            {
                get
                {
                    // initial value
                    bool isValid = ((this.ActionType != ActionTypeEnum.Unknown) && (this.HasCriteria) && (this.Criteria.Count > 0));

                    // adding a test for UpdateQueries
                
                    // if currently valid
                    if ((isValid) && (actionType == ActionTypeEnum.Update))
                    {  
                        // if any of the values are out of range
                        if ((red < 0) || (green < 0) || (blue < 0) || (alpha < 0) || (red > 255) || (green > 255) || (blue > 255) || (alpha > 255))
                        {
                            // set to false
                            isValid = false;
                        }
                    }

                    // if this is a Hide From query
                    if (this.ActionType == ActionTypeEnum.HideFrom)
                    {
                        // if the Directions object exists and the Directions object is not Empty
                        isValid = ((HasDirections) && (!this.Directions.Empty));

                        // if the value for isValid is true
                        if (isValid)
                        {  
                            // if the Color has been set
                            isValid = this.ColorSet;
                        }
                    }
                    
                    // return value
                    return isValid;
                }
            }
            #endregion

            #region Red
            /// <summary>
            /// This property gets or sets the value for 'Red'.
            /// </summary>
            public int Red
            {
                get { return red; }
                set { red = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
