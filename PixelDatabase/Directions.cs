#region using statements


#endregion

namespace DataJuggler.PixelDatabase
{

    #region class Directions
    /// <summary>
    /// This class is used to keep track of the directions.
    /// </summary>
    public class Directions
    {

        #region Private Variables
        private bool bottom;
        private bool left;
        private bool right;
        private bool top;
        #endregion

        #region Properties

            #region All
            /// <summary>
            /// This read only property returns the value for 'All'.
            /// </summary>
            public bool All
            {
                get
                {
                    // initial value
                    bool all = ((Left) && (Right) && (Top) && (Bottom));
                    
                    // return value
                    return all;
                }
            }
            #endregion
            
            #region Bottom
            /// <summary>
            /// This property gets or sets the value for 'Bottom'.
            /// </summary>
            public bool Bottom
            {
                get { return bottom; }
                set { bottom = value; }
            }
            #endregion
            
            #region Empty
            /// <summary>
            /// This read only property returns true if none of the directions are selected.
            /// </summary>
            public bool Empty
            {
                get
                {
                    // initial value
                    bool empty = ((!Left) && (!Right) && (!Top) && (!Bottom));

                    // initial value
                    
                    
                    // return value
                    return empty;
                }
            }
            #endregion
            
            #region Left
            /// <summary>
            /// This property gets or sets the value for 'Left'.
            /// </summary>
            public bool Left
            {
                get { return left; }
                set { left = value; }
            }
            #endregion
            
            #region Right
            /// <summary>
            /// This property gets or sets the value for 'Right'.
            /// </summary>
            public bool Right
            {
                get { return right; }
                set { right = value; }
            }
            #endregion
            
            #region Top
            /// <summary>
            /// This property gets or sets the value for 'Top'.
            /// </summary>
            public bool Top
            {
                get { return top; }
                set { top = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
