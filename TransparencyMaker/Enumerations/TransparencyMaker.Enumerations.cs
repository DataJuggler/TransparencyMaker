
namespace TransparencyMaker.Enumerations
{ 

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
        Undo = 7,
        Abort = 8
    }
    #endregion

    #region PromptTypeEnum : int
    /// <summary>
    /// This enum is used by the Dialog Control
    /// </summary>
    public enum PromptTypeEnum : int
    {
        YesNo = 0,
        SaveLayer = 1
    }
    #endregion

    #region UserResponseEnum
    /// <summary>
    /// This enumeration is for the types of responses a user can have from the DialogControl. 
    /// </summary>
    public enum UserResponseEnum : int
    {
        NoResponse = 0,
        Confirmed = 1,
        Cancelled = -1,
        Saved = 2
    }
    #endregion

}
