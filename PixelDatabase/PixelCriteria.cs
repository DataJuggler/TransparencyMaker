

#region using statements

using System.Drawing;
using DataJuggler.PixelDatabase.Enumerations;

#endregion

namespace DataJuggler.PixelDatabase
{

    #region class PixelCriteria
    /// <summary>
    /// This class is used to contain 1 set of instructions to find pixels that match this criteria
    /// </summary>
    public class PixelCriteria
    {

        #region Private Variables
        private PixelTypeEnum pixelType;
        private ComparisonTypeEnum comparisonType;
        private int minValue;
        private int maxValue;
        private int targetValue;
        private Point startPoint;
        private Point endPoint;
        private int thickness;
        private RepeatTypeEnum repeatType;
        private int repititions;
        private int distance;
        private Color backColor;
        private bool removeBackColor;
        #endregion

        #region Properties
        
            #region BackColor
            /// <summary>
            /// This property gets or sets the value for 'BackColor'.
            /// </summary>
            public Color BackColor
            {
                get { return backColor; }
                set { backColor = value; }
            }
            #endregion
            
            #region ComparisonType
            /// <summary>
            /// This property gets or sets the value for 'ComparisonType'.
            /// </summary>
            public ComparisonTypeEnum ComparisonType
            {
                get { return comparisonType; }
                set { comparisonType = value; }
            }
            #endregion
            
            #region Distance
            /// <summary>
            /// This property gets or sets the value for 'Distance'.
            /// This property is the amount the Draw Line method should move during each repitition.
            /// </summary>
            public int Distance
            {
                get { return distance; }
                set { distance = value; }
            }
            #endregion
            
            #region EndPoint
            /// <summary>
            /// This property gets or sets the value for 'EndPoint'.
            /// </summary>
            public Point EndPoint
            {
                get { return endPoint; }
                set { endPoint = value; }
            }
            #endregion
            
            #region MaxValue
            /// <summary>
            /// This property gets or sets the value for 'MaxValue'.
            /// </summary>
            public int MaxValue
            {
                get { return maxValue; }
                set { maxValue = value; }
            }
            #endregion
            
            #region MinValue
            /// <summary>
            /// This property gets or sets the value for 'MinValue'.
            /// </summary>
            public int MinValue
            {
                get { return minValue; }
                set { minValue = value; }
            }
            #endregion
            
            #region PixelType
            /// <summary>
            /// This property gets or sets the value for 'PixelType'.
            /// </summary>
            public PixelTypeEnum PixelType
            {
                get { return pixelType; }
                set { pixelType = value; }
            }
            #endregion

            #region RemoveBackColor
            /// <summary>
            /// This property gets or sets the value for 'RemoveBackColor'.
            /// </summary>
            public bool RemoveBackColor
            {
                get { return removeBackColor; }
                set { removeBackColor = value; }
            }
            #endregion
            
            #region RepeatType
            /// <summary>
            /// This property gets or sets the value for 'RepeatType'.
            /// </summary>
            public RepeatTypeEnum RepeatType
            {
                get { return repeatType; }
                set { repeatType = value; }
            }
            #endregion
            
            #region Repititions
            /// <summary>
            /// This property gets or sets the value for 'Repititions'.
            /// </summary>
            public int Repititions
            {
                get { return repititions; }
                set { repititions = value; }
            }
            #endregion
            
            #region StartPoint
            /// <summary>
            /// This property gets or sets the value for 'StartPoint'.
            /// </summary>
            public Point StartPoint
            {
                get { return startPoint; }
                set { startPoint = value; }
            }
            #endregion
            
            #region TargetValue
            /// <summary>
            /// This property gets or sets the value for 'TargetValue'.
            /// This is used for do a ComparisonType of Equals
            /// </summary>
            public int TargetValue
            {
                get { return targetValue; }
                set { targetValue = value; }
            }
            #endregion
            
            #region Thickness
            /// <summary>
            /// This property gets or sets the value for 'Thickness'.
            /// </summary>
            public int Thickness
            {
                get { return thickness; }
                set { thickness = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
