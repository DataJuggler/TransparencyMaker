
namespace DataJuggler.PixelDatabase.Enumerations
{

    #region ActionTypeEnum : int
    /// <summary>
    /// Does this PixelQuery Show or Hide pixels?
    /// </summary>
    public enum ActionTypeEnum : int
    {
        Unknown = 0,
        HidePixels = 1,
        ShowPixels = 2,
        DrawLine = 3,
        SetBackColor = 4,
        Update = 5,
        HideFrom = 6,
        Undo = 7
    }
    #endregion

    #region ComparisonTypeEnum : int
    /// <summary>
    /// This is the type of comparison a PixelCriteria will set
    /// </summary>
    public enum ComparisonTypeEnum : int
    {
        NoComparison = -1,
        Unknown = 0,
        LessThan = -1,
        GreaterThan = 1,
        Between = 2,
        Equals = 3,
        In = 4
    }
    #endregion

    #region MaskActionEnum
    /// <summary>
    /// MaskActionEnum is used by PixelQuery to turn masks on or off.
    /// Any pixel with Mask = true will not be affected during an update.
    /// </summary>
    public enum MaskActionEnum : int
    {
        ClearAll = -2,
        Clear = -1,
        NoAction = 0,
        Add = 1,
        Replace = 2
    }
    #endregion

    #region PixelTypeEnum : int
    /// <summary>
    /// This is the type of pixel a PixelCriteria will apply to.
    /// </summary>
    public enum PixelTypeEnum : int
    {
        Unknown = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        Total = 4,
        BlueGreen = 5,
        BlueRed = 6,
        GreenRed = 7,
        X = 8,
        Y = 9,
        DrawLine = 10,
        LastUpdate = 11,
        Alpha = 12
    }
    #endregion

    #region RepeatTypeEnum : int
    /// <summary>
    /// This is the type of repeat that is used when drawing a line
    /// </summary>
    public enum RepeatTypeEnum : int
    {
        NoRepeat = 0,
        Down = 1,
        Left = 2,
        Right = 3,
        Up = 4
    }
    #endregion

    #region RGBColor : int
    /// <summary>
    /// This enumeration is used to select Red, Green or Blue.
    /// </summary>
    public enum RGBColor : int
    {
        NotSet = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        GreenRed = 4,
        BlueRed = 5,
        BlueGreen = 6,
        All = 7
    }
    #endregion

    #region SwapTypeEnum : int
    /// <summary>
    /// The SwapType is used to designate which colors
    /// are being swapped when the SwapColors is true.
    /// </summary>
    public enum SwapTypeEnum : int
    {
        Unknown = 0,
        RedToGreen = 1,
        RedToBlue = 2,
        BlueToGreen = 3
    }
    #endregion

}
