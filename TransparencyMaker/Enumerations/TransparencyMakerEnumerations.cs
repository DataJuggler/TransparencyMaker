
namespace TransparencyMaker.Enumerations
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

    #region ButtonTypeEnum : int
    /// <summary>
    /// This enumeration is for the type of button a control represents
    /// </summary>
    public enum ButtonTypeEnum : int
    {
        Close = 0,
        Save = 1,
        SaveAs = 2,
        Analyze = 3, 
        Apply = 4, 
        Reset = 5,
        ColorPicker = 6,
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
        Equals = 3
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
        DrawLine = 10
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

}
