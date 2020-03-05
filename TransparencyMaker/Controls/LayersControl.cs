

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
using DataJuggler.PixelDatabase.Net;
using DataJuggler.Core.UltimateHelper;
using TransparencyMaker.Enumerations;

#endregion

namespace TransparencyMaker.Controls
{

    #region class LayersControl
    /// <summary>
    /// This control will display layers and designate which layer is being updated.
    /// </summary>
    public partial class LayersControl : UserControl
    {
        
        #region Private Variables
        private Layer selectedLayer;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'LayersControl' object.
        /// </summary>
        public LayersControl()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Events

            #region AddButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AddButton' is clicked.
            /// </summary>
            private void AddButton_Click(object sender, EventArgs e)
            {
                // If the value for the property HasPixelDatabase and HasLayers is true
                if ((HasPixelDatabase) && (PixelDatabase.HasLayers))
                {
                    // create the layer
                    Layer layer = new Layer();

                    // Set the name
                    layer.Name = "Layer" + (PixelDatabase.Layers.Count).ToString();
                    layer.Pixels = new List<PixelInformation>();
                    layer.Visible = true;
                    layer.Selected = true;

                    // iterate the layers
                    foreach (Layer existingLayer in PixelDatabase.Layers)
                    {
                        // there can be only one (Highlander ?)
                        existingLayer.Selected = false;
                    }

                    // display this layer
                    PixelDatabase.Layers.Add(layer);

                    // Display the Layers
                    DisplayLayers();
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

            #region DeleteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DeleteButton' is clicked.
            /// </summary>
            private void DeleteButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of a 'DialogControlForm' object.
                DialogControlForm form = new DialogControlForm();

                // set a message
                string message = "Are you sure you wish to delete the layer named '" + SelectedLayer.Name + "'?";

                // Get user confirmation
                form.Setup(PromptTypeEnum.YesNo, message, "Confirm Delete");

                // Show the form
                form.ShowDialog();

                // if yes
                if (form.UserResponse == UserResponseEnum.Confirmed)
                {
                    // Find the TrueIndex
                    int trueIndex = FindLayerIndex(SelectedLayer);

                    // if trueIndex
                    if (trueIndex >= 0)
                    {
                        // remove this layer
                        PixelDatabase.Layers.RemoveAt(trueIndex);

                         // erase
                        this.SelectedLayer = null;
                    }
                   
                    // Display again
                    DisplayLayers();
                }

                // Enable the controls now that nothing is selected
                UIEnable();
            }
            #endregion
            
            #region DeleteButton_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Delete Button _ Enabled Changed
            /// </summary>
            private void DeleteButton_EnabledChanged(object sender, EventArgs e)
            {
                // if the value for Enabled is true
                if (Enabled)
                {
                    // use red button
                    DeleteButton.BackgroundImage = Properties.Resources.DeleteButtonX;
                }
                else
                {
                    // use red button
                    DeleteButton.BackgroundImage = Properties.Resources.DeleteButtonXGray;
                }
            }
            #endregion
            
            #region EditButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'EditButton' is clicked.
            /// </summary>
            private void EditButton_Click(object sender, EventArgs e)
            {
                
            }
            #endregion
            
            #region EditButton_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Edit Button _ Enabled Changed
            /// </summary>
            private void EditButton_EnabledChanged(object sender, EventArgs e)
            {
                // if the value for Enabled is true
                if (Enabled)
                {
                    // Use Yellow
                    EditButton.BackgroundImage = Properties.Resources.Pencil_Transparent;
                }
                else
                {   
                    // Use Gray
                    EditButton.BackgroundImage = Properties.Resources.Pencil_TransparentGray;
                }
            }
            #endregion
            
            #region FlattenButtoon_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'FlattenButtoon' is clicked.
            /// </summary>
            private void FlattenButtoon_Click(object sender, EventArgs e)
            {
                // to do: Flatten
            }
            #endregion
            
            #region FlattenButtoon_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Flatten Buttoon _ Enabled Changed
            /// </summary>
            private void FlattenButtoon_EnabledChanged(object sender, EventArgs e)
            {
                 // if the value for Enabled is true
                if (Enabled)
                {
                    // Use Pancake texture
                    FlattenButtoon.BackgroundImage = Properties.Resources.SmallPancake;
                }
                else
                {   
                    // Use Gray Pancake texture
                    FlattenButtoon.BackgroundImage = Properties.Resources.SmallPancakeGray;
                }
            }
            #endregion
            
            #region LayerClicked(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Layer Clicked
            /// </summary>
            private void LayerClicked(object sender, EventArgs e)
            {
                // If the value for the property .HasPixelDatabase is true
                if ((HasPixelDatabase) && (PixelDatabase.HasLayers))
                {
                    // cast the sender a Label
                    LayerLabel label = sender as LayerLabel;

                    // If the label object exists
                    if (NullHelper.Exists(label))
                    {
                        // If the value for the property label.HasLayer is true
                        if ((label.HasLayer) && ((label.Index >= 0) && (label.Index < PixelDatabase.Layers.Count)))
                        {
                            // iterate the layers
                            foreach (Layer layer in PixelDatabase.Layers)
                            {
                                // remove all selections
                                layer.Selected = false;
                            }

                            // Select this item
                            PixelDatabase.Layers[label.Index].Selected = true;

                            // Set the SelectedLayer
                            SelectedLayer = PixelDatabase.Layers[label.Index];

                            // Display Layers
                            DisplayLayers();

                            // Enable or disable controls
                            UIEnable();
                        }
                    }
                }
            }
            #endregion
            
            #region MoveDownButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'MoveDownButton' is clicked.
            /// </summary>
            private void MoveDownButton_Click(object sender, EventArgs e)
            {
                // if the PixelDatabase.Layers and SelectedLayer both exist
                if ((HasPixelDatabase) && (PixelDatabase.HasLayers) && (HasSelectedLayer))
                {
                    // find the index
                    int trueIndex = FindLayerIndex(SelectedLayer);

                    // if in range
                    if (trueIndex >= 0)
                    {
                        // Remove at the index    
                        PixelDatabase.Layers.RemoveAt(trueIndex);

                        // Insert at the SelectedLayer Index + 1 moves it down
                        PixelDatabase.Layers.Insert(trueIndex + 1, SelectedLayer);

                        // Display layers
                        DisplayLayers();
                    }
                }
            }
            #endregion
            
            #region MoveDownButton_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Move Down Button _ Enabled Changed
            /// </summary>
            private void MoveDownButton_EnabledChanged(object sender, EventArgs e)
            {
                // if the value for Enabled is true
                if (Enabled)
                {
                    // Use Blue
                    MoveDownButton.BackgroundImage = Properties.Resources.BlueArrowDown;
                }
                else
                {
                    // Use Gray
                    MoveDownButton.BackgroundImage = Properties.Resources.BlueArrowUpGray;
                }
            }
            #endregion
            
            #region MoveUpButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'MoveUpButton' is clicked.
            /// </summary>
            private void MoveUpButton_Click(object sender, EventArgs e)
            {
                // if the PixelDatabase.Layers and SelectedLayer both exist
                if ((HasPixelDatabase) && (PixelDatabase.HasLayers) && (HasSelectedLayer))
                {
                    // find the index
                    int trueIndex = FindLayerIndex(SelectedLayer);

                    // if in range
                    if (trueIndex > 0)
                    {
                        // Remove at the index    
                        PixelDatabase.Layers.RemoveAt(trueIndex);

                        // Insert at the SelectedLayer Index + 1 moves it down
                        PixelDatabase.Layers.Insert(trueIndex - 1, SelectedLayer);

                        // Display layers
                        DisplayLayers();
                    }
                }
            }
            #endregion
            
            #region MoveUpButton_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Move Up Button _ Enabled Changed
            /// </summary>
            private void MoveUpButton_EnabledChanged(object sender, EventArgs e)
            {
                // if the value for Enabled is true
                if (Enabled)
                {
                    // Use Blue
                    MoveUpButton.BackgroundImage = Properties.Resources.BlueArrorUp;                    
                }
                else
                {
                    // Use Gray
                    MoveUpButton.BackgroundImage = Properties.Resources.BlueArrowUpGray;
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region DisplayLayers()
            /// <summary>
            /// This method Display Layers
            /// </summary>
            public void DisplayLayers()
            { 
                try
                { 
                    // Clear the controls
                    LayersPanel.Controls.Clear();

                    // if there are one or more layers
                    if ((HasPixelDatabase) && (ListHelper.HasOneOrMoreItems(PixelDatabase.Layers)))
                    {
                        // reverse the list
                        List<Layer> layers = PixelDatabase.Layers;

                        // Iterate the collection of Layer objects
                        for (int x = layers.Count - 1; x >= 0; x--)
                        { 
                            // get the current layer
                            Layer layer = layers[x];

                            // create a new label and set properties
                            LayerLabel label = new LayerLabel();
                            label.Layer = layer;
                            label.Name = layer.Name;
                            label.Text = layer.Name;
                            label.Dock = DockStyle.Top;
                            label.Font = new Font("Verdana", 12);
                            label.ForeColor = Color.White;
                            label.MouseEnter += this.Button_Enter;
                            label.MouseLeave += this.Button_Leave;
                            label.Click += LayerClicked;
                            label.Index = x;

                            // if selected
                            if (layer.Selected)
                            {
                                // selected
                                label.BackColor = Color.RoyalBlue;
                            }
                            else
                            {
                                // no backcolor
                                label.BackColor = Color.Transparent;
                            }

                            // Add this control
                            LayersPanel.Controls.Add(label);
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only for now
                    DebugHelper.WriteDebugError("DisplayLayers", "LayersControl", error);
                }
            }

        #endregion

            #region FindLayerIndex(Layer layer)
            /// <summary>
            /// This method Find Layer Index
            /// </summary>
            public int FindLayerIndex(Layer layer)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // If the value for the property .HasPixelDatabase is true
                if ((NullHelper.Exists(layer)) && (HasPixelDatabase) && (PixelDatabase.HasLayers))
                {
                    // iterate the layers
                    foreach (Layer tempLayer in PixelDatabase.Layers)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if this name is the correct one
                        if (layer.Name == tempLayer.Name)
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return index;
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method returns the Enable
            /// </summary>
            public void UIEnable()
            {
                // local
                bool hasLayer = HasSelectedLayer;

                // enable buttons
                DeleteButton.Enabled = hasLayer;
                EditButton.Enabled = hasLayer;
                int trueIndex = -1;

                // if the value for hasLayer is true
                if ((HasPixelDatabase) && (ListHelper.HasXOrMoreItems(PixelDatabase.Layers, 2)) && (hasLayer)))
                {
                    // get the true index
                    trueIndex = FindLayerIndex(SelectedLayer);

                    // move up (move up means subtract from the index)
                    MoveUpButton.Enabled = (trueIndex > 0);

                    // move down (move down means add to the index
                    MoveDownButton.Enabled = (trueIndex < PixelDatabase.Layers.Count);

                    // Enable the Flatten button if there are two or more layers
                    FlattenButtoon.Enabled = (PixelDatabase.Layers.Count > 1);
                }
                else
                {
                    // there has to be 2 or more layers to Move Up / Move Down or Flatten.
                    MoveUpButton.Enabled = false;
                    MoveDownButton.Enabled = false;
                    FlattenButtoon.Enabled = false;
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasParentMainForm
            /// <summary>
            /// This property returns true if this object has a 'ParentMainForm'.
            /// </summary>
            public bool HasParentMainForm
            {
                get
                {
                    // initial value
                    bool hasParentMainForm = (this.ParentMainForm != null);
                    
                    // return value
                    return hasParentMainForm;
                }
            }
            #endregion
            
            #region HasPixelDatabase
            /// <summary>
            /// This property returns true if this object has a 'PixelDatabase'.
            /// </summary>
            public bool HasPixelDatabase
            {
                get
                {
                    // initial value
                    bool hasPixelDatabase = (this.PixelDatabase != null);
                    
                    // return value
                    return hasPixelDatabase;
                }
            }
            #endregion
            
            #region HasSelectedLayer
            /// <summary>
            /// This property returns true if this object has a 'SelectedLayer'.
            /// </summary>
            public bool HasSelectedLayer
            {
                get
                {
                    // initial value
                    bool hasSelectedLayer = (this.SelectedLayer != null);
                    
                    // return value
                    return hasSelectedLayer;
                }
            }
            #endregion
            
            #region ParentMainForm
            /// <summary>
            /// This read only property returns the value for 'ParentMainForm'.
            /// </summary>
            public MainForm ParentMainForm
            {
                get
                {
                    // initial value
                    MainForm mainForm = this.ParentForm as MainForm;
                    
                    // return value
                    return mainForm;
                }
            }
            #endregion
            
            #region PixelDatabase
            /// <summary>
            /// This property gets or sets the value for 'PixelDatabase'.
            /// </summary>
            public PixelDatabase PixelDatabase
            {
                get
                {
                    // initial value
                    PixelDatabase pixelDatabase = null;
                    
                    // if the value for HasParentMainForm is true
                    if (HasParentMainForm)
                    {
                        // set the return value
                        pixelDatabase = ParentMainForm.PixelDatabase;
                    }
                    
                    // return value
                    return pixelDatabase;
                }
            }
        #endregion

            #region SelectedLayer
            /// <summary>
            /// This property gets or sets the value for 'SelectedLayer'.
            /// </summary>
            
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public Layer SelectedLayer
            {
                get { return selectedLayer; }
                set { selectedLayer = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
