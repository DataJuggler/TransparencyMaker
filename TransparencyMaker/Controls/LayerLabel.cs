using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataJuggler.PixelDatabase.Net;

namespace TransparencyMaker.Controls
{
    public class LayerLabel : Label
    {

        #region Private Variables
        private Layer layer;
        private int index;
        #endregion

        #region Properties

            #region HasLayer
            /// <summary>
            /// This property returns true if this object has a 'Layer'.
            /// </summary>
            public bool HasLayer
            {
                get
                {
                    // initial value
                    bool hasLayer = (this.Layer != null);
                    
                    // return value
                    return hasLayer;
                }
            }
            #endregion
            
            #region Index
            /// <summary>
            /// This property gets or sets the value for 'Index'.
            /// </summary>
            public int Index
            {
                get { return index; }
                set { index = value; }
            }
            #endregion
            
            #region Layer
            /// <summary>
            /// This property gets or sets the value for 'Layer'.
            /// </summary>
            public Layer Layer
            {
                get { return layer; }
                set { layer = value; }
            }
            #endregion
            
        #endregion

    }
}
