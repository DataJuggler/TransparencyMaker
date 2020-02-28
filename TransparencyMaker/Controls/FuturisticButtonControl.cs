

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransparencyMaker.Delegates;
using TransparencyMaker.Enumerations;

#endregion

namespace TransparencyMaker.Controls
{

    #region class FuturisticButtonControl
    /// <summary>
    ///  This class is used to display an image as a button with Text and a border,
    ///  with options for selection or not.
    /// </summary>
    public partial class FuturisticButtonControl : UserControl
    {
        
        #region Private Variables
        private ButtonTypeEnum buttonType;
        private int borderSize;
        private int buttonNumber;
        private ButtonClickHandler clickHandler;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FuturisticButtonControl' object.
        /// </summary>
        public FuturisticButtonControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events
            
            #region Button_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'Button' is clicked.
            /// </summary>
            private void Button_Click(object sender, EventArgs e)
            {
                // If the ClickHandler object exists
                if (this.HasClickHandler)
                {
                    // Call the delegate
                    this.ClickHandler(this.ButtonNumber, this.TitleLabel.Text);
                }
            }
            #endregion
            
            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                this.Cursor = Cursors.Hand;  
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                this.Cursor = Cursors.Default;
            }
            #endregion

            #region TitleLabel_ForeColorChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Title Label _ Fore Color Changed
            /// </summary>
            private void TitleLabel_ForeColorChanged(object sender, EventArgs e)
            {
                this.Refresh();
                this.TitleLabel.Refresh();
                Application.DoEvents();
            }
            #endregion
            
        #endregion

        #region Methods            
            
            #region DisplayBorder()
            /// <summary>
            /// This method Display Border
            /// </summary>
            public void DisplayBorder()
            {
                this.LeftMarginPanel.Width = this.BorderSize;
                this.RightMarginPanel.Width = this.BorderSize;
                this.TopMarginPanel.Height = this.BorderSize;
                this.BottomMarginPanel.Height = this.BorderSize;
            }
            #endregion
            
            #region DisplayButton()
            /// <summary>
            /// This method Display Button
            /// </summary>
            public void DisplayButton()
            {
                switch (this.ButtonType)
                {
                    case ButtonTypeEnum.Close:

                        // Set the text
                        this.TitleLabel.Text = "Close File";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.Close_Button_2;

                        // required
                        break;

                    case ButtonTypeEnum.Save:

                        // Set the text
                        this.TitleLabel.Text = "Save";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.Save_Button;

                         // required
                        break;

                    case ButtonTypeEnum.SaveAs:

                        // Set the text
                        this.TitleLabel.Text = "Save As";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.Save_As_Button;

                        // required
                        break;

                     case ButtonTypeEnum.Analyze:

                        // Set the text
                        this.TitleLabel.Text = "Analyze";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.Analyze_File;

                        // required
                        break;

                    case ButtonTypeEnum.Apply:

                        // Set the text
                        this.TitleLabel.Text = "Apply";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.Background_Changer;

                        // required
                        break;

                    case ButtonTypeEnum.Reset:

                        // Set the text
                        this.TitleLabel.Text = "Reset";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.Reset_Button;
                        
                        // required
                        break;

                    case ButtonTypeEnum.ColorPicker:

                        // Set the text
                        this.TitleLabel.Text = "Color Picker";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.Color_Picker;

                        // required
                        break;

                    case ButtonTypeEnum.Undo:

                        // Set the text
                        this.TitleLabel.Text = "Undo Changes";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.Undo_Changes;

                        // required
                        break;

                    case ButtonTypeEnum.Abort:

                        // Set the text
                        this.TitleLabel.Text = "Abort";
                        
                        // Set the image
                        this.Image.BackgroundImage = Properties.Resources.AbortButton;

                         // required
                        break;
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Start off with no border
                this.BorderSize = 0;
            }
            #endregion
            
        #endregion

        #region Properties

            #region BorderSize
            /// <summary>
            /// This property gets or sets the value for 'BorderSize'.
            /// </summary>
            public int BorderSize
            {
                get { return borderSize; }
                set 
                { 
                    borderSize = value; 

                    // Display the border (size the panels)
                    DisplayBorder();
                }
            }
            #endregion
            
            #region ButtonNumber
            /// <summary>
            /// This property gets or sets the value for 'ButtonNumber'.
            /// </summary>
            public int ButtonNumber
            {
                get { return buttonNumber; }
                set { buttonNumber = value; }
            }
            #endregion
            
            #region ButtonType
            /// <summary>
            /// This property gets or sets the value for 'ButtonType'.
            /// </summary>
            public ButtonTypeEnum ButtonType
            {
                get { return buttonType; }
                set 
                { 
                    // set the value
                    buttonType = value; 

                    // display the image
                    DisplayButton();

                    // Refresh everything
                    this.Refresh();
                }
            }
        #endregion

            #region ClickHandler
            /// <summary>
            /// This property gets or sets the value for 'ClickHandler'.
            /// </summary>
            public ButtonClickHandler ClickHandler
            {
                get { return clickHandler; }
                set { clickHandler = value; }
            }
            #endregion
            
            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
        #endregion

            #region HasClickHandler
            /// <summary>
            /// This property returns true if this object has a 'ClickHandler'.
            /// </summary>
            public bool HasClickHandler
            {
                get
                {
                    // initial value
                    bool hasClickHandler = (this.ClickHandler != null);
                    
                    // return value
                    return hasClickHandler;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
