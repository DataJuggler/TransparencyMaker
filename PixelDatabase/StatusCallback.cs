using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataJuggler.PixelDatabase
{

    # region delegate StatusUpdate(string message, int pixelsCompleted)
    /// <summary>
    /// The StatusUpdate is used to send feedback back from an operation
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pixelsCompleted"></param>
    public delegate void StatusUpdate(string message, int pixelsCompleted);
    #endregion

}
