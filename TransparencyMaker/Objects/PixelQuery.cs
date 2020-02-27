

#region using statements

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Core.UltimateHelper;
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
        private bool adjustColor;
        private bool swapColors;
        private SwapTypeEnum swapType;
        private int adjustment;
        private Mask mask;
        private bool setMaskColor;
        private string setMaskcolorName;
        private RGBColor colorToAdjust;
        private RGBColor assignToColor;
        private string queryText;
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
            
            #region AdjustColor
            /// <summary>
            /// This property gets or sets the value for 'AdjustColor'.
            /// </summary>
            public bool AdjustColor
            {
                get { return adjustColor; }
                set { adjustColor = value; }
            }
            #endregion
            
            #region Adjustment
            /// <summary>
            /// This property gets or sets the value for 'Adjustment'.
            /// </summary>
            public int Adjustment
            {
                get { return adjustment; }
                set { adjustment = value; }
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
            
            #region AssignToColor
            /// <summary>
            /// This property gets or sets the value for 'AssignToColor'.
            /// </summary>
            public RGBColor AssignToColor
            {
                get { return assignToColor; }
                set { assignToColor = value; }
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
            
            #region ColorToAdjust
            /// <summary>
            /// This property gets or sets the value for 'ColorToAdjust'.
            /// </summary>
            public RGBColor ColorToAdjust
            {
                get { return colorToAdjust; }
                set { colorToAdjust = value; }
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
            
            #region HasAssignToColor
            /// <summary>
            /// This property returns true if this object has an 'AssignToColor'.
            /// </summary>
            public bool HasAssignToColor
            {
                get
                {
                    // initial value
                    bool hasAssignToColor = (this.AssignToColor != RGBColor.NotSet);
                    
                    // return value
                    return hasAssignToColor;
                }
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
            
            #region HasMask
            /// <summary>
            /// This property returns true if this object has a 'Mask'.
            /// </summary>
            public bool HasMask
            {
                get
                {
                    // initial value
                    bool hasMask = (this.Mask != null);
                    
                    // return value
                    return hasMask;
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
                    bool isValid = (this.ActionType != ActionTypeEnum.Unknown);

                    // if we not have any criteria
                    if ((isValid) && (!ListHelper.HasOneOrMoreItems(Criteria)))
                    {
                        // create default pixel criteria
                        PixelCriteria pixelCriteria = new PixelCriteria();

                        // Set the Properties on the criteria
                        pixelCriteria.ComparisonType = ComparisonTypeEnum.GreaterThan;
                        pixelCriteria.PixelType = PixelTypeEnum.Total;
                        pixelCriteria.TargetValue = 0;

                        // Create Default Criteria
                        Criteria = new List<PixelCriteria>();
                        Criteria.Add(pixelCriteria);
                    }

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

            #region Mask
            /// <summary>
            /// This property gets or sets the value for 'Mask'.
            /// </summary>
            public Mask Mask
            {
                get { return mask; }
                set { mask = value; }
            }
            #endregion
            
            #region QueryText
            /// <summary>
            /// This property gets or sets the value for 'QueryText'.
            /// </summary>
            public string QueryText
            {
                get { return queryText; }
                set { queryText = value; }
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
           
            #region SetMaskColor
            /// <summary>
            /// This property gets or sets the value for 'SetMaskColor'.
            /// </summary>
            public bool SetMaskColor
            {
                get { return setMaskColor; }
                set { setMaskColor = value; }
            }
            #endregion
            
            #region SetMaskcolorName
            /// <summary>
            /// This property gets or sets the value for 'SetMaskcolorName'.
            /// </summary>
            public string SetMaskcolorName
            {
                get { return setMaskcolorName; }
                set { setMaskcolorName = value; }
            }
            #endregion
            
            #region SwapColors
            /// <summary>
            /// This property gets or sets the value for 'SwapColors'.
            /// </summary>
            public bool SwapColors
            {
                get { return swapColors; }
                set { swapColors = value; }
            }
            #endregion
            
            #region SwapType
            /// <summary>
            /// This property gets or sets the value for 'SwapType'.
            /// </summary>
            public SwapTypeEnum SwapType
            {
                get { return swapType; }
                set { swapType = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
