

#region using statements

using TransparencyMaker;
using TransparencyMaker.Enumerations;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using DataJuggler.PixelDatabase.Net;

#endregion

namespace TransparencyMaker.Controls
{

    #region class DialogControl
    /// <summary>
    /// This control is used to capture a user's response in a more graphical way than a MessageBox DialogResult.
    /// </summary>
    public partial class DialogControl : UserControl
    {
        
        #region Private Variables
        private UserResponseEnum userResponse;
        private PromptTypeEnum promptType;
        private Layer layer;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DialogControl' object.
        /// </summary>
        public DialogControl()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Events
            
            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region CancelButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CancelButton' is clicked.
            /// </summary>
            private void CancelButton_Click(object sender, EventArgs e)
            {
                // set the user response  
                this.UserResponse = UserResponseEnum.Cancelled;

                // Close this form
                Close();
            }
            #endregion
            
            #region NoButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'NoButton' is clicked.
            /// </summary>
            private void NoButton_Click(object sender, EventArgs e)
            {
                // Set the return value
                this.UserResponse = UserResponseEnum.Cancelled;

                // Close the parent form
                Close();
            }
            #endregion
            
            #region SaveButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'SaveButton' is clicked.
            /// </summary>
            private void SaveButton_Click(object sender, EventArgs e)
            {
                
            }
            #endregion
            
            #region YesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'YesButton' is clicked.
            /// </summary>
            private void YesButton_Click(object sender, EventArgs e)
            {
                // Set the return value
                this.UserResponse = UserResponseEnum.Confirmed;

                // Close the parent form
                Close();
            }
            #endregion
            
        #endregion

        #region Methods

            #region Close()
            /// <summary>
            /// This method Close
            /// </summary>
            public void Close()
            {
                // If the ParentDialogControlForm object exists
                if (this.HasParentDialogControlForm)
                {
                    // Set the value
                    this.ParentDialogControlForm.UserResponse = this.UserResponse;

                    // Close the parent form
                    this.ParentDialogControlForm.Close();
                }
            }
            #endregion
            
            #region Setup(PromptTypeEnum promptType, string message, Layer layer = null)
            /// <summary>
            /// This method Setup
            /// </summary>
            public void Setup(PromptTypeEnum promptType, string message, Layer layer = null)
            {   
                // Setup the control
                this.PromptType = promptType;
                this.MessageLabel.Text = message;
                this.Layer = layer;

                // enable the controls
                UIEnable();
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {
                // Show or hide
                this.YesButton.Visible = (PromptType == PromptTypeEnum.YesNo);
                this.NoButton.Visible = (PromptType == PromptTypeEnum.YesNo);
                this.SaveButton.Visible = (PromptType == PromptTypeEnum.SaveLayer);
                this.CancelButton.Visible = (PromptType == PromptTypeEnum.SaveLayer);
                this.TextBox.Visible = (PromptType == PromptTypeEnum.SaveLayer);

                // if the value for HasLayer is true
                if (HasLayer)
                {
                    // Setup the control
                    this.TextBox.Text = Layer.Name;
                    this.TextBox.SelectAll();
                    this.TextBox.Focus();
                }
            }
            #endregion
            
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
            
            #region HasParentDialogControlForm
            /// <summary>
            /// This property returns true if this object has a 'ParentDialogControlForm'.
            /// </summary>
            public bool HasParentDialogControlForm
            {
                get
                {
                    // initial value
                    bool hasParentDialogControlForm = (this.ParentDialogControlForm != null);
                    
                    // return value
                    return hasParentDialogControlForm;
                }
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
            
            #region ParentDialogControlForm
            /// <summary>
            /// This read only returns the ParentForm cast as a DialogControlForm.
            /// </summary>
            public DialogControlForm ParentDialogControlForm
            {
                get
                {
                    // initial value
                    DialogControlForm parentDialogControlForm = this.ParentForm as DialogControlForm;

                    // return value
                    return parentDialogControlForm;
                }
            }
            #endregion

            #region PromptType
            /// <summary>
            /// This property gets or sets the value for 'PromptType'.
            /// </summary>
            public PromptTypeEnum PromptType
            {
                get { return promptType; }
                set { promptType = value; }
            }
            #endregion
            
            #region UserResponse
            /// <summary>
            /// This property gets or sets the value for 'UserResponse'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public UserResponseEnum UserResponse
            {
                get { return userResponse; }
                set { userResponse = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
