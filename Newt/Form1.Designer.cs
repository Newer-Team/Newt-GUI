namespace Newt
{
    partial class Newt_MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Newt_MainWindow));
            this.Newt_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_LoadPNG = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Actions = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ClearObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ClearCollision = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ClearFlipping = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ClearRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_SetTilesToDefaultFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ToggleChangesOverlay = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_AdjustCanvasToSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_About = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureBox_TilePickerCanvas = new System.Windows.Forms.PictureBox();
            this.Panel_ObjectPicker = new System.Windows.Forms.Panel();
            this.ListView_Objects = new System.Windows.Forms.ListView();
            this.Column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Panel_ObjectCanvas = new System.Windows.Forms.Panel();
            this.PictureBox_ObjectCanvas = new System.Windows.Forms.PictureBox();
            this.NumUpDown_ObjectCanvas_Width = new System.Windows.Forms.NumericUpDown();
            this.NumUpDown_ObjectCanvas_Height = new System.Windows.Forms.NumericUpDown();
            this.Label_ObjectCavas_Width = new System.Windows.Forms.Label();
            this.Label_ObjectCanvas_Height = new System.Windows.Forms.Label();
            this.Panel_ObjectCanvasWrapper = new System.Windows.Forms.Panel();
            this.Panel_CanvasControls = new System.Windows.Forms.Panel();
            this.Label_ObjectCanvasZoom = new System.Windows.Forms.Label();
            this.NumericUpDown_ObjectCanvasZoom = new System.Windows.Forms.NumericUpDown();
            this.Panel_ObjectCanvasScrollWrapper = new System.Windows.Forms.Panel();
            this.Panel_CollisionEditor = new System.Windows.Forms.Panel();
            this.PartialBlockParamsPanel = new System.Windows.Forms.Panel();
            this.CheckBox_PartialBlock_BottomRight = new System.Windows.Forms.CheckBox();
            this.CheckBox_PartialBlock_BottomLeft = new System.Windows.Forms.CheckBox();
            this.CheckBox_PartialBlock_TopRight = new System.Windows.Forms.CheckBox();
            this.CheckBox_PartialBlock_TopLeft = new System.Windows.Forms.CheckBox();
            this.PipeDoorParamsPanel = new System.Windows.Forms.Panel();
            this.ListBox_PipeDoorParams = new System.Windows.Forms.ListBox();
            this.ComboBox_PipeDoorType = new System.Windows.Forms.ComboBox();
            this.ListBox_NormalTileParams = new System.Windows.Forms.ListBox();
            this.Label_CollisionEditorRawData = new System.Windows.Forms.Label();
            this.ComboBox_CollisionSubTypes = new System.Windows.Forms.ComboBox();
            this.ListBox_CollisionFlags = new System.Windows.Forms.CheckedListBox();
            this.Label_CollisionEditor_SubType = new System.Windows.Forms.Label();
            this.Label_CollisionEditor_Parameters = new System.Windows.Forms.Label();
            this.ComboBox_CollisionEditor_SubType = new System.Windows.Forms.ComboBox();
            this.Label_CollisionEditor_Flags = new System.Windows.Forms.Label();
            this.Button_EditTilemap = new System.Windows.Forms.Button();
            this.Panel_Buttons = new System.Windows.Forms.Panel();
            this.Button_EditFormats = new System.Windows.Forms.Button();
            this.Button_EditRandomization = new System.Windows.Forms.Button();
            this.Panel_TilePicker = new System.Windows.Forms.Panel();
            this.Label_NoGo = new System.Windows.Forms.Label();
            this.Panel_EditTilemapButtons = new System.Windows.Forms.Panel();
            this.Button_Back = new System.Windows.Forms.Button();
            this.Button_Clear = new System.Windows.Forms.Button();
            this.Button_YFlip = new System.Windows.Forms.Button();
            this.Button_XFlip = new System.Windows.Forms.Button();
            this.Button_Copy = new System.Windows.Forms.Button();
            this.Panel_EditFormats = new System.Windows.Forms.Panel();
            this.Label_FormatType = new System.Windows.Forms.Label();
            this.ComboBox_FormatTypes = new System.Windows.Forms.ComboBox();
            this.Button_Formats_Back = new System.Windows.Forms.Button();
            this.Panel_Randomization = new System.Windows.Forms.Panel();
            this.Label_PlaceInGroup = new System.Windows.Forms.Label();
            this.ComboBox_RandomizationGroups = new System.Windows.Forms.ComboBox();
            this.Button_RemoveRandoGroup = new System.Windows.Forms.Button();
            this.Button_AddRandoGroup = new System.Windows.Forms.Button();
            this.Button_Randomization_Back = new System.Windows.Forms.Button();
            this.Label_LargePreview_Preview = new System.Windows.Forms.Label();
            this.Label_LargePreview_Zoom = new System.Windows.Forms.Label();
            this.NumUpDown_Zoom = new System.Windows.Forms.NumericUpDown();
            this.Panel_LargePreview = new System.Windows.Forms.Panel();
            this.PictureBox_LargePreview = new System.Windows.Forms.PictureBox();
            this.Panel_LargePreviewWrapper = new System.Windows.Forms.Panel();
            this.Button_ClearSelectedObject = new System.Windows.Forms.Button();
            this.RawTileCollisionDataEditor = new Newt.RawTileCollisionDataEditor();
            this.Newt_MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_TilePickerCanvas)).BeginInit();
            this.Panel_ObjectPicker.SuspendLayout();
            this.Panel_ObjectCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_ObjectCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_ObjectCanvas_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_ObjectCanvas_Height)).BeginInit();
            this.Panel_ObjectCanvasWrapper.SuspendLayout();
            this.Panel_CanvasControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_ObjectCanvasZoom)).BeginInit();
            this.Panel_ObjectCanvasScrollWrapper.SuspendLayout();
            this.Panel_CollisionEditor.SuspendLayout();
            this.PartialBlockParamsPanel.SuspendLayout();
            this.PipeDoorParamsPanel.SuspendLayout();
            this.Panel_Buttons.SuspendLayout();
            this.Panel_TilePicker.SuspendLayout();
            this.Panel_EditTilemapButtons.SuspendLayout();
            this.Panel_EditFormats.SuspendLayout();
            this.Panel_Randomization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Zoom)).BeginInit();
            this.Panel_LargePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_LargePreview)).BeginInit();
            this.Panel_LargePreviewWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // Newt_MenuStrip
            // 
            this.Newt_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Actions,
            this.Menu_About});
            this.Newt_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.Newt_MenuStrip.Name = "Newt_MenuStrip";
            this.Newt_MenuStrip.Size = new System.Drawing.Size(1084, 24);
            this.Newt_MenuStrip.TabIndex = 0;
            this.Newt_MenuStrip.Text = "menuStrip1";
            // 
            // Menu_File
            // 
            this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Open,
            this.Menu_Save,
            this.Menu_SaveAs,
            this.Menu_Create,
            this.Menu_LoadPNG,
            this.exportPNGToolStripMenuItem,
            this.Menu_Quit});
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(37, 20);
            this.Menu_File.Text = "File";
            // 
            // Menu_Open
            // 
            this.Menu_Open.Name = "Menu_Open";
            this.Menu_Open.Size = new System.Drawing.Size(180, 22);
            this.Menu_Open.Text = "Open...";
            this.Menu_Open.Click += new System.EventHandler(this.Menu_Open_Click);
            // 
            // Menu_Save
            // 
            this.Menu_Save.Name = "Menu_Save";
            this.Menu_Save.Size = new System.Drawing.Size(180, 22);
            this.Menu_Save.Text = "Save";
            this.Menu_Save.Click += new System.EventHandler(this.Menu_Save_Click);
            // 
            // Menu_SaveAs
            // 
            this.Menu_SaveAs.Name = "Menu_SaveAs";
            this.Menu_SaveAs.Size = new System.Drawing.Size(180, 22);
            this.Menu_SaveAs.Text = "Save as...";
            this.Menu_SaveAs.Click += new System.EventHandler(this.Menu_SaveAs_Click);
            // 
            // Menu_Create
            // 
            this.Menu_Create.Name = "Menu_Create";
            this.Menu_Create.Size = new System.Drawing.Size(180, 22);
            this.Menu_Create.Text = "Create new tileset";
            this.Menu_Create.Click += new System.EventHandler(this.Menu_Create_Click);
            // 
            // Menu_LoadPNG
            // 
            this.Menu_LoadPNG.Name = "Menu_LoadPNG";
            this.Menu_LoadPNG.Size = new System.Drawing.Size(180, 22);
            this.Menu_LoadPNG.Text = "Load PNG";
            this.Menu_LoadPNG.Click += new System.EventHandler(this.Menu_LoadPNG_Click);
            // 
            // exportPNGToolStripMenuItem
            // 
            this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
            this.exportPNGToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportPNGToolStripMenuItem.Text = "Export PNG";
            this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.ExportPNGToolStripMenuItem_Click);
            // 
            // Menu_Quit
            // 
            this.Menu_Quit.Name = "Menu_Quit";
            this.Menu_Quit.Size = new System.Drawing.Size(180, 22);
            this.Menu_Quit.Text = "Exit";
            this.Menu_Quit.Click += new System.EventHandler(this.Menu_Quit_Click);
            // 
            // Menu_Actions
            // 
            this.Menu_Actions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_ClearObjects,
            this.Menu_ClearCollision,
            this.Menu_ClearFlipping,
            this.Menu_ClearRandom,
            this.Menu_SetTilesToDefaultFormat,
            this.Menu_ToggleChangesOverlay,
            this.Menu_AdjustCanvasToSelected});
            this.Menu_Actions.Name = "Menu_Actions";
            this.Menu_Actions.Size = new System.Drawing.Size(59, 20);
            this.Menu_Actions.Text = "Actions";
            // 
            // Menu_ClearObjects
            // 
            this.Menu_ClearObjects.Name = "Menu_ClearObjects";
            this.Menu_ClearObjects.Size = new System.Drawing.Size(265, 22);
            this.Menu_ClearObjects.Text = "Clear all objects";
            this.Menu_ClearObjects.Click += new System.EventHandler(this.Menu_ClearObjects_Click);
            // 
            // Menu_ClearCollision
            // 
            this.Menu_ClearCollision.Name = "Menu_ClearCollision";
            this.Menu_ClearCollision.Size = new System.Drawing.Size(265, 22);
            this.Menu_ClearCollision.Text = "Clear all collision";
            this.Menu_ClearCollision.Click += new System.EventHandler(this.Menu_ClearCollision_Click);
            // 
            // Menu_ClearFlipping
            // 
            this.Menu_ClearFlipping.Name = "Menu_ClearFlipping";
            this.Menu_ClearFlipping.Size = new System.Drawing.Size(265, 22);
            this.Menu_ClearFlipping.Text = "Clear all tilemap changes";
            this.Menu_ClearFlipping.Click += new System.EventHandler(this.Menu_ClearFlipping_Click);
            // 
            // Menu_ClearRandom
            // 
            this.Menu_ClearRandom.Name = "Menu_ClearRandom";
            this.Menu_ClearRandom.Size = new System.Drawing.Size(265, 22);
            this.Menu_ClearRandom.Text = "Clear all randomization";
            this.Menu_ClearRandom.Click += new System.EventHandler(this.Menu_ClearRandom_Click);
            // 
            // Menu_SetTilesToDefaultFormat
            // 
            this.Menu_SetTilesToDefaultFormat.Name = "Menu_SetTilesToDefaultFormat";
            this.Menu_SetTilesToDefaultFormat.Size = new System.Drawing.Size(265, 22);
            this.Menu_SetTilesToDefaultFormat.Text = "Set all tiles to default format";
            this.Menu_SetTilesToDefaultFormat.Click += new System.EventHandler(this.Menu_SetTilesToDefaultFormat_Click);
            // 
            // Menu_ToggleChangesOverlay
            // 
            this.Menu_ToggleChangesOverlay.CheckOnClick = true;
            this.Menu_ToggleChangesOverlay.Name = "Menu_ToggleChangesOverlay";
            this.Menu_ToggleChangesOverlay.Size = new System.Drawing.Size(265, 22);
            this.Menu_ToggleChangesOverlay.Text = "Toggle changes overlay";
            this.Menu_ToggleChangesOverlay.Click += new System.EventHandler(this.Menu_ToggleChangesOverlay_Click);
            // 
            // Menu_AdjustCanvasToSelected
            // 
            this.Menu_AdjustCanvasToSelected.CheckOnClick = true;
            this.Menu_AdjustCanvasToSelected.Name = "Menu_AdjustCanvasToSelected";
            this.Menu_AdjustCanvasToSelected.Size = new System.Drawing.Size(265, 22);
            this.Menu_AdjustCanvasToSelected.Text = "Adjust object canvas size to selected";
            this.Menu_AdjustCanvasToSelected.Click += new System.EventHandler(this.Menu_AdjustCanvasToSelected_Click);
            // 
            // Menu_About
            // 
            this.Menu_About.Name = "Menu_About";
            this.Menu_About.Size = new System.Drawing.Size(52, 20);
            this.Menu_About.Text = "About";
            this.Menu_About.Click += new System.EventHandler(this.Menu_About_Click);
            // 
            // PictureBox_TilePickerCanvas
            // 
            this.PictureBox_TilePickerCanvas.BackColor = System.Drawing.Color.LightGray;
            this.PictureBox_TilePickerCanvas.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_TilePickerCanvas.Name = "PictureBox_TilePickerCanvas";
            this.PictureBox_TilePickerCanvas.Size = new System.Drawing.Size(256, 768);
            this.PictureBox_TilePickerCanvas.TabIndex = 2;
            this.PictureBox_TilePickerCanvas.TabStop = false;
            this.PictureBox_TilePickerCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_TilePickerCanvas_Paint);
            this.PictureBox_TilePickerCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_TilePickerCanvas_MouseDown);
            this.PictureBox_TilePickerCanvas.MouseLeave += new System.EventHandler(this.PictureBox_TilePickerCanvas_MouseLeave);
            this.PictureBox_TilePickerCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_TilePickerCanvas_MouseMove);
            this.PictureBox_TilePickerCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_TilePickerCanvas_MouseUp);
            // 
            // Panel_ObjectPicker
            // 
            this.Panel_ObjectPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ObjectPicker.AutoScroll = true;
            this.Panel_ObjectPicker.Controls.Add(this.ListView_Objects);
            this.Panel_ObjectPicker.Location = new System.Drawing.Point(830, 27);
            this.Panel_ObjectPicker.Name = "Panel_ObjectPicker";
            this.Panel_ObjectPicker.Size = new System.Drawing.Size(254, 611);
            this.Panel_ObjectPicker.TabIndex = 3;
            // 
            // ListView_Objects
            // 
            this.ListView_Objects.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView_Objects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column1});
            this.ListView_Objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_Objects.FullRowSelect = true;
            this.ListView_Objects.GridLines = true;
            this.ListView_Objects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListView_Objects.HideSelection = false;
            this.ListView_Objects.Location = new System.Drawing.Point(0, 0);
            this.ListView_Objects.MultiSelect = false;
            this.ListView_Objects.Name = "ListView_Objects";
            this.ListView_Objects.Size = new System.Drawing.Size(254, 611);
            this.ListView_Objects.TabIndex = 0;
            this.ListView_Objects.TileSize = new System.Drawing.Size(245, 64);
            this.ListView_Objects.UseCompatibleStateImageBehavior = false;
            this.ListView_Objects.View = System.Windows.Forms.View.Details;
            this.ListView_Objects.Click += new System.EventHandler(this.ListView_Objects_Click);
            this.ListView_Objects.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_Objects_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.Width = 234;
            // 
            // Panel_ObjectCanvas
            // 
            this.Panel_ObjectCanvas.BackColor = System.Drawing.Color.White;
            this.Panel_ObjectCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ObjectCanvas.Controls.Add(this.PictureBox_ObjectCanvas);
            this.Panel_ObjectCanvas.Location = new System.Drawing.Point(6, 8);
            this.Panel_ObjectCanvas.Name = "Panel_ObjectCanvas";
            this.Panel_ObjectCanvas.Size = new System.Drawing.Size(529, 432);
            this.Panel_ObjectCanvas.TabIndex = 4;
            // 
            // PictureBox_ObjectCanvas
            // 
            this.PictureBox_ObjectCanvas.Location = new System.Drawing.Point(261, 191);
            this.PictureBox_ObjectCanvas.Name = "PictureBox_ObjectCanvas";
            this.PictureBox_ObjectCanvas.Size = new System.Drawing.Size(16, 16);
            this.PictureBox_ObjectCanvas.TabIndex = 0;
            this.PictureBox_ObjectCanvas.TabStop = false;
            this.PictureBox_ObjectCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_ObjectCanvas_Paint);
            this.PictureBox_ObjectCanvas.MouseLeave += new System.EventHandler(this.PictureBox_ObjectCanvas_MouseLeave);
            this.PictureBox_ObjectCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_ObjectCanvas_MouseMove);
            this.PictureBox_ObjectCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_ObjectCanvas_MouseUp);
            // 
            // NumUpDown_ObjectCanvas_Width
            // 
            this.NumUpDown_ObjectCanvas_Width.Location = new System.Drawing.Point(52, 7);
            this.NumUpDown_ObjectCanvas_Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDown_ObjectCanvas_Width.Name = "NumUpDown_ObjectCanvas_Width";
            this.NumUpDown_ObjectCanvas_Width.Size = new System.Drawing.Size(47, 20);
            this.NumUpDown_ObjectCanvas_Width.TabIndex = 1;
            this.NumUpDown_ObjectCanvas_Width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDown_ObjectCanvas_Width.ValueChanged += new System.EventHandler(this.NumUpDown_ObjectCanvas_ValueChanged);
            // 
            // NumUpDown_ObjectCanvas_Height
            // 
            this.NumUpDown_ObjectCanvas_Height.Location = new System.Drawing.Point(169, 7);
            this.NumUpDown_ObjectCanvas_Height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDown_ObjectCanvas_Height.Name = "NumUpDown_ObjectCanvas_Height";
            this.NumUpDown_ObjectCanvas_Height.Size = new System.Drawing.Size(47, 20);
            this.NumUpDown_ObjectCanvas_Height.TabIndex = 5;
            this.NumUpDown_ObjectCanvas_Height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDown_ObjectCanvas_Height.ValueChanged += new System.EventHandler(this.NumUpDown_ObjectCanvas_ValueChanged);
            // 
            // Label_ObjectCavas_Width
            // 
            this.Label_ObjectCavas_Width.Location = new System.Drawing.Point(8, 9);
            this.Label_ObjectCavas_Width.Name = "Label_ObjectCavas_Width";
            this.Label_ObjectCavas_Width.Size = new System.Drawing.Size(38, 13);
            this.Label_ObjectCavas_Width.TabIndex = 6;
            this.Label_ObjectCavas_Width.Text = "Width:";
            // 
            // Label_ObjectCanvas_Height
            // 
            this.Label_ObjectCanvas_Height.AutoSize = true;
            this.Label_ObjectCanvas_Height.Location = new System.Drawing.Point(122, 9);
            this.Label_ObjectCanvas_Height.Name = "Label_ObjectCanvas_Height";
            this.Label_ObjectCanvas_Height.Size = new System.Drawing.Size(41, 13);
            this.Label_ObjectCanvas_Height.TabIndex = 7;
            this.Label_ObjectCanvas_Height.Text = "Height:";
            // 
            // Panel_ObjectCanvasWrapper
            // 
            this.Panel_ObjectCanvasWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ObjectCanvasWrapper.AutoScroll = true;
            this.Panel_ObjectCanvasWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ObjectCanvasWrapper.Controls.Add(this.Panel_CanvasControls);
            this.Panel_ObjectCanvasWrapper.Controls.Add(this.Panel_ObjectCanvasScrollWrapper);
            this.Panel_ObjectCanvasWrapper.Location = new System.Drawing.Point(277, 27);
            this.Panel_ObjectCanvasWrapper.Name = "Panel_ObjectCanvasWrapper";
            this.Panel_ObjectCanvasWrapper.Size = new System.Drawing.Size(547, 485);
            this.Panel_ObjectCanvasWrapper.TabIndex = 8;
            // 
            // Panel_CanvasControls
            // 
            this.Panel_CanvasControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Panel_CanvasControls.Controls.Add(this.Label_ObjectCanvasZoom);
            this.Panel_CanvasControls.Controls.Add(this.Label_ObjectCavas_Width);
            this.Panel_CanvasControls.Controls.Add(this.NumericUpDown_ObjectCanvasZoom);
            this.Panel_CanvasControls.Controls.Add(this.NumUpDown_ObjectCanvas_Width);
            this.Panel_CanvasControls.Controls.Add(this.Label_ObjectCanvas_Height);
            this.Panel_CanvasControls.Controls.Add(this.NumUpDown_ObjectCanvas_Height);
            this.Panel_CanvasControls.Location = new System.Drawing.Point(118, 449);
            this.Panel_CanvasControls.Name = "Panel_CanvasControls";
            this.Panel_CanvasControls.Size = new System.Drawing.Size(331, 33);
            this.Panel_CanvasControls.TabIndex = 26;
            // 
            // Label_ObjectCanvasZoom
            // 
            this.Label_ObjectCanvasZoom.AutoSize = true;
            this.Label_ObjectCanvasZoom.Location = new System.Drawing.Point(232, 9);
            this.Label_ObjectCanvasZoom.Name = "Label_ObjectCanvasZoom";
            this.Label_ObjectCanvasZoom.Size = new System.Drawing.Size(37, 13);
            this.Label_ObjectCanvasZoom.TabIndex = 25;
            this.Label_ObjectCanvasZoom.Text = "Zoom:";
            // 
            // NumericUpDown_ObjectCanvasZoom
            // 
            this.NumericUpDown_ObjectCanvasZoom.Location = new System.Drawing.Point(275, 7);
            this.NumericUpDown_ObjectCanvasZoom.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericUpDown_ObjectCanvasZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_ObjectCanvasZoom.Name = "NumericUpDown_ObjectCanvasZoom";
            this.NumericUpDown_ObjectCanvasZoom.Size = new System.Drawing.Size(47, 20);
            this.NumericUpDown_ObjectCanvasZoom.TabIndex = 24;
            this.NumericUpDown_ObjectCanvasZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_ObjectCanvasZoom.ValueChanged += new System.EventHandler(this.NumericUpDown_ObjectCanvasZoom_ValueChanged);
            // 
            // Panel_ObjectCanvasScrollWrapper
            // 
            this.Panel_ObjectCanvasScrollWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ObjectCanvasScrollWrapper.AutoScroll = true;
            this.Panel_ObjectCanvasScrollWrapper.BackColor = System.Drawing.Color.Transparent;
            this.Panel_ObjectCanvasScrollWrapper.Controls.Add(this.Panel_ObjectCanvas);
            this.Panel_ObjectCanvasScrollWrapper.Location = new System.Drawing.Point(2, 0);
            this.Panel_ObjectCanvasScrollWrapper.Name = "Panel_ObjectCanvasScrollWrapper";
            this.Panel_ObjectCanvasScrollWrapper.Size = new System.Drawing.Size(540, 448);
            this.Panel_ObjectCanvasScrollWrapper.TabIndex = 1;
            // 
            // Panel_CollisionEditor
            // 
            this.Panel_CollisionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_CollisionEditor.AutoScroll = true;
            this.Panel_CollisionEditor.AutoScrollMinSize = new System.Drawing.Size(400, 220);
            this.Panel_CollisionEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_CollisionEditor.Controls.Add(this.PartialBlockParamsPanel);
            this.Panel_CollisionEditor.Controls.Add(this.PipeDoorParamsPanel);
            this.Panel_CollisionEditor.Controls.Add(this.ListBox_NormalTileParams);
            this.Panel_CollisionEditor.Controls.Add(this.Label_CollisionEditorRawData);
            this.Panel_CollisionEditor.Controls.Add(this.ComboBox_CollisionSubTypes);
            this.Panel_CollisionEditor.Controls.Add(this.ListBox_CollisionFlags);
            this.Panel_CollisionEditor.Controls.Add(this.RawTileCollisionDataEditor);
            this.Panel_CollisionEditor.Controls.Add(this.Label_CollisionEditor_SubType);
            this.Panel_CollisionEditor.Controls.Add(this.Label_CollisionEditor_Parameters);
            this.Panel_CollisionEditor.Controls.Add(this.ComboBox_CollisionEditor_SubType);
            this.Panel_CollisionEditor.Controls.Add(this.Label_CollisionEditor_Flags);
            this.Panel_CollisionEditor.Enabled = false;
            this.Panel_CollisionEditor.Location = new System.Drawing.Point(277, 518);
            this.Panel_CollisionEditor.Name = "Panel_CollisionEditor";
            this.Panel_CollisionEditor.Size = new System.Drawing.Size(547, 373);
            this.Panel_CollisionEditor.TabIndex = 9;
            this.Panel_CollisionEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_CollisionEditor_MouseDown);
            // 
            // PartialBlockParamsPanel
            // 
            this.PartialBlockParamsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PartialBlockParamsPanel.Controls.Add(this.CheckBox_PartialBlock_BottomRight);
            this.PartialBlockParamsPanel.Controls.Add(this.CheckBox_PartialBlock_BottomLeft);
            this.PartialBlockParamsPanel.Controls.Add(this.CheckBox_PartialBlock_TopRight);
            this.PartialBlockParamsPanel.Controls.Add(this.CheckBox_PartialBlock_TopLeft);
            this.PartialBlockParamsPanel.Location = new System.Drawing.Point(179, 69);
            this.PartialBlockParamsPanel.Name = "PartialBlockParamsPanel";
            this.PartialBlockParamsPanel.Size = new System.Drawing.Size(366, 316);
            this.PartialBlockParamsPanel.TabIndex = 7;
            this.PartialBlockParamsPanel.Visible = false;
            // 
            // CheckBox_PartialBlock_BottomRight
            // 
            this.CheckBox_PartialBlock_BottomRight.AutoSize = true;
            this.CheckBox_PartialBlock_BottomRight.Location = new System.Drawing.Point(24, 23);
            this.CheckBox_PartialBlock_BottomRight.Name = "CheckBox_PartialBlock_BottomRight";
            this.CheckBox_PartialBlock_BottomRight.Size = new System.Drawing.Size(15, 14);
            this.CheckBox_PartialBlock_BottomRight.TabIndex = 4;
            this.CheckBox_PartialBlock_BottomRight.UseVisualStyleBackColor = true;
            this.CheckBox_PartialBlock_BottomRight.CheckedChanged += new System.EventHandler(this.CheckBox_PartialBlock_CheckedChanged);
            // 
            // CheckBox_PartialBlock_BottomLeft
            // 
            this.CheckBox_PartialBlock_BottomLeft.AutoSize = true;
            this.CheckBox_PartialBlock_BottomLeft.Location = new System.Drawing.Point(3, 23);
            this.CheckBox_PartialBlock_BottomLeft.Name = "CheckBox_PartialBlock_BottomLeft";
            this.CheckBox_PartialBlock_BottomLeft.Size = new System.Drawing.Size(15, 14);
            this.CheckBox_PartialBlock_BottomLeft.TabIndex = 3;
            this.CheckBox_PartialBlock_BottomLeft.UseVisualStyleBackColor = true;
            this.CheckBox_PartialBlock_BottomLeft.CheckedChanged += new System.EventHandler(this.CheckBox_PartialBlock_CheckedChanged);
            // 
            // CheckBox_PartialBlock_TopRight
            // 
            this.CheckBox_PartialBlock_TopRight.AutoSize = true;
            this.CheckBox_PartialBlock_TopRight.Location = new System.Drawing.Point(24, 3);
            this.CheckBox_PartialBlock_TopRight.Name = "CheckBox_PartialBlock_TopRight";
            this.CheckBox_PartialBlock_TopRight.Size = new System.Drawing.Size(15, 14);
            this.CheckBox_PartialBlock_TopRight.TabIndex = 2;
            this.CheckBox_PartialBlock_TopRight.UseVisualStyleBackColor = true;
            this.CheckBox_PartialBlock_TopRight.CheckedChanged += new System.EventHandler(this.CheckBox_PartialBlock_CheckedChanged);
            // 
            // CheckBox_PartialBlock_TopLeft
            // 
            this.CheckBox_PartialBlock_TopLeft.AutoSize = true;
            this.CheckBox_PartialBlock_TopLeft.Location = new System.Drawing.Point(3, 3);
            this.CheckBox_PartialBlock_TopLeft.Name = "CheckBox_PartialBlock_TopLeft";
            this.CheckBox_PartialBlock_TopLeft.Size = new System.Drawing.Size(15, 14);
            this.CheckBox_PartialBlock_TopLeft.TabIndex = 1;
            this.CheckBox_PartialBlock_TopLeft.UseVisualStyleBackColor = true;
            this.CheckBox_PartialBlock_TopLeft.CheckedChanged += new System.EventHandler(this.CheckBox_PartialBlock_CheckedChanged);
            // 
            // PipeDoorParamsPanel
            // 
            this.PipeDoorParamsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PipeDoorParamsPanel.Controls.Add(this.ListBox_PipeDoorParams);
            this.PipeDoorParamsPanel.Controls.Add(this.ComboBox_PipeDoorType);
            this.PipeDoorParamsPanel.Location = new System.Drawing.Point(179, 69);
            this.PipeDoorParamsPanel.Name = "PipeDoorParamsPanel";
            this.PipeDoorParamsPanel.Size = new System.Drawing.Size(365, 319);
            this.PipeDoorParamsPanel.TabIndex = 20;
            this.PipeDoorParamsPanel.Visible = false;
            // 
            // ListBox_PipeDoorParams
            // 
            this.ListBox_PipeDoorParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_PipeDoorParams.FormattingEnabled = true;
            this.ListBox_PipeDoorParams.IntegralHeight = false;
            this.ListBox_PipeDoorParams.Location = new System.Drawing.Point(0, 56);
            this.ListBox_PipeDoorParams.Name = "ListBox_PipeDoorParams";
            this.ListBox_PipeDoorParams.Size = new System.Drawing.Size(574, 236);
            this.ListBox_PipeDoorParams.TabIndex = 1;
            this.ListBox_PipeDoorParams.SelectedIndexChanged += new System.EventHandler(this.ListBox_PipeDoorParams_SelectedIndexChanged);
            // 
            // ComboBox_PipeDoorType
            // 
            this.ComboBox_PipeDoorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_PipeDoorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_PipeDoorType.FormattingEnabled = true;
            this.ComboBox_PipeDoorType.Location = new System.Drawing.Point(0, 0);
            this.ComboBox_PipeDoorType.Name = "ComboBox_PipeDoorType";
            this.ComboBox_PipeDoorType.Size = new System.Drawing.Size(364, 21);
            this.ComboBox_PipeDoorType.TabIndex = 0;
            this.ComboBox_PipeDoorType.SelectedIndexChanged += new System.EventHandler(this.ComboBox_PipeDoorType_SelectedIndexChanged);
            // 
            // ListBox_NormalTileParams
            // 
            this.ListBox_NormalTileParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_NormalTileParams.FormattingEnabled = true;
            this.ListBox_NormalTileParams.Location = new System.Drawing.Point(179, 69);
            this.ListBox_NormalTileParams.Name = "ListBox_NormalTileParams";
            this.ListBox_NormalTileParams.Size = new System.Drawing.Size(365, 290);
            this.ListBox_NormalTileParams.TabIndex = 19;
            this.ListBox_NormalTileParams.SelectedIndexChanged += new System.EventHandler(this.ListBox_NormalTileParams_SelectedIndexChanged);
            // 
            // Label_CollisionEditorRawData
            // 
            this.Label_CollisionEditorRawData.AutoSize = true;
            this.Label_CollisionEditorRawData.Location = new System.Drawing.Point(3, 10);
            this.Label_CollisionEditorRawData.Name = "Label_CollisionEditorRawData";
            this.Label_CollisionEditorRawData.Size = new System.Drawing.Size(58, 13);
            this.Label_CollisionEditorRawData.TabIndex = 18;
            this.Label_CollisionEditorRawData.Text = "Raw Data:";
            // 
            // ComboBox_CollisionSubTypes
            // 
            this.ComboBox_CollisionSubTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_CollisionSubTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_CollisionSubTypes.FormattingEnabled = true;
            this.ComboBox_CollisionSubTypes.Location = new System.Drawing.Point(179, 26);
            this.ComboBox_CollisionSubTypes.Name = "ComboBox_CollisionSubTypes";
            this.ComboBox_CollisionSubTypes.Size = new System.Drawing.Size(364, 21);
            this.ComboBox_CollisionSubTypes.TabIndex = 17;
            this.ComboBox_CollisionSubTypes.SelectedIndexChanged += new System.EventHandler(this.ComboBox_CollisionSubTypes_SelectedIndexChanged);
            // 
            // ListBox_CollisionFlags
            // 
            this.ListBox_CollisionFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBox_CollisionFlags.CheckOnClick = true;
            this.ListBox_CollisionFlags.FormattingEnabled = true;
            this.ListBox_CollisionFlags.IntegralHeight = false;
            this.ListBox_CollisionFlags.Location = new System.Drawing.Point(6, 69);
            this.ListBox_CollisionFlags.Name = "ListBox_CollisionFlags";
            this.ListBox_CollisionFlags.Size = new System.Drawing.Size(167, 319);
            this.ListBox_CollisionFlags.TabIndex = 16;
            this.ListBox_CollisionFlags.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListBox_CollisionFlags_ItemCheck);
            // 
            // Label_CollisionEditor_SubType
            // 
            this.Label_CollisionEditor_SubType.AutoSize = true;
            this.Label_CollisionEditor_SubType.Location = new System.Drawing.Point(176, 10);
            this.Label_CollisionEditor_SubType.Name = "Label_CollisionEditor_SubType";
            this.Label_CollisionEditor_SubType.Size = new System.Drawing.Size(49, 13);
            this.Label_CollisionEditor_SubType.TabIndex = 11;
            this.Label_CollisionEditor_SubType.Text = "Subtype:";
            // 
            // Label_CollisionEditor_Parameters
            // 
            this.Label_CollisionEditor_Parameters.AutoSize = true;
            this.Label_CollisionEditor_Parameters.Location = new System.Drawing.Point(176, 53);
            this.Label_CollisionEditor_Parameters.Name = "Label_CollisionEditor_Parameters";
            this.Label_CollisionEditor_Parameters.Size = new System.Drawing.Size(45, 13);
            this.Label_CollisionEditor_Parameters.TabIndex = 14;
            this.Label_CollisionEditor_Parameters.Text = "Params:";
            // 
            // ComboBox_CollisionEditor_SubType
            // 
            this.ComboBox_CollisionEditor_SubType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_CollisionEditor_SubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_CollisionEditor_SubType.FormattingEnabled = true;
            this.ComboBox_CollisionEditor_SubType.Location = new System.Drawing.Point(179, 26);
            this.ComboBox_CollisionEditor_SubType.Name = "ComboBox_CollisionEditor_SubType";
            this.ComboBox_CollisionEditor_SubType.Size = new System.Drawing.Size(111, 21);
            this.ComboBox_CollisionEditor_SubType.TabIndex = 13;
            // 
            // Label_CollisionEditor_Flags
            // 
            this.Label_CollisionEditor_Flags.AutoSize = true;
            this.Label_CollisionEditor_Flags.Location = new System.Drawing.Point(3, 53);
            this.Label_CollisionEditor_Flags.Name = "Label_CollisionEditor_Flags";
            this.Label_CollisionEditor_Flags.Size = new System.Drawing.Size(35, 13);
            this.Label_CollisionEditor_Flags.TabIndex = 12;
            this.Label_CollisionEditor_Flags.Text = "Flags:";
            // 
            // Button_EditTilemap
            // 
            this.Button_EditTilemap.Location = new System.Drawing.Point(3, 7);
            this.Button_EditTilemap.Name = "Button_EditTilemap";
            this.Button_EditTilemap.Size = new System.Drawing.Size(250, 23);
            this.Button_EditTilemap.TabIndex = 10;
            this.Button_EditTilemap.Text = "Edit tilemap";
            this.Button_EditTilemap.UseVisualStyleBackColor = true;
            this.Button_EditTilemap.Click += new System.EventHandler(this.Button_EditTilemap_Click);
            // 
            // Panel_Buttons
            // 
            this.Panel_Buttons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_Buttons.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Buttons.Controls.Add(this.Button_EditFormats);
            this.Panel_Buttons.Controls.Add(this.Button_EditRandomization);
            this.Panel_Buttons.Controls.Add(this.Button_EditTilemap);
            this.Panel_Buttons.Location = new System.Drawing.Point(12, 801);
            this.Panel_Buttons.Name = "Panel_Buttons";
            this.Panel_Buttons.Size = new System.Drawing.Size(256, 90);
            this.Panel_Buttons.TabIndex = 11;
            // 
            // Button_EditFormats
            // 
            this.Button_EditFormats.Location = new System.Drawing.Point(3, 61);
            this.Button_EditFormats.Name = "Button_EditFormats";
            this.Button_EditFormats.Size = new System.Drawing.Size(250, 23);
            this.Button_EditFormats.TabIndex = 12;
            this.Button_EditFormats.Text = "Edit formats";
            this.Button_EditFormats.UseVisualStyleBackColor = true;
            this.Button_EditFormats.Click += new System.EventHandler(this.Button_EditFormats_Click);
            // 
            // Button_EditRandomization
            // 
            this.Button_EditRandomization.Location = new System.Drawing.Point(3, 34);
            this.Button_EditRandomization.Name = "Button_EditRandomization";
            this.Button_EditRandomization.Size = new System.Drawing.Size(250, 23);
            this.Button_EditRandomization.TabIndex = 11;
            this.Button_EditRandomization.Text = "Edit randomization";
            this.Button_EditRandomization.UseVisualStyleBackColor = true;
            this.Button_EditRandomization.Click += new System.EventHandler(this.Button_EditRandomization_Click);
            // 
            // Panel_TilePicker
            // 
            this.Panel_TilePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_TilePicker.AutoScroll = true;
            this.Panel_TilePicker.BackColor = System.Drawing.Color.Transparent;
            this.Panel_TilePicker.Controls.Add(this.Label_NoGo);
            this.Panel_TilePicker.Controls.Add(this.PictureBox_TilePickerCanvas);
            this.Panel_TilePicker.Location = new System.Drawing.Point(12, 27);
            this.Panel_TilePicker.MaximumSize = new System.Drawing.Size(256, 768);
            this.Panel_TilePicker.Name = "Panel_TilePicker";
            this.Panel_TilePicker.Size = new System.Drawing.Size(256, 768);
            this.Panel_TilePicker.TabIndex = 12;
            // 
            // Label_NoGo
            // 
            this.Label_NoGo.BackColor = System.Drawing.Color.Red;
            this.Label_NoGo.Location = new System.Drawing.Point(208, 752);
            this.Label_NoGo.Name = "Label_NoGo";
            this.Label_NoGo.Size = new System.Drawing.Size(48, 16);
            this.Label_NoGo.TabIndex = 18;
            // 
            // Panel_EditTilemapButtons
            // 
            this.Panel_EditTilemapButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_EditTilemapButtons.Controls.Add(this.Button_Back);
            this.Panel_EditTilemapButtons.Controls.Add(this.Button_Clear);
            this.Panel_EditTilemapButtons.Controls.Add(this.Button_YFlip);
            this.Panel_EditTilemapButtons.Controls.Add(this.Button_XFlip);
            this.Panel_EditTilemapButtons.Controls.Add(this.Button_Copy);
            this.Panel_EditTilemapButtons.Location = new System.Drawing.Point(12, 801);
            this.Panel_EditTilemapButtons.Name = "Panel_EditTilemapButtons";
            this.Panel_EditTilemapButtons.Size = new System.Drawing.Size(256, 90);
            this.Panel_EditTilemapButtons.TabIndex = 13;
            this.Panel_EditTilemapButtons.Visible = false;
            // 
            // Button_Back
            // 
            this.Button_Back.Location = new System.Drawing.Point(3, 62);
            this.Button_Back.Name = "Button_Back";
            this.Button_Back.Size = new System.Drawing.Size(250, 23);
            this.Button_Back.TabIndex = 14;
            this.Button_Back.Text = "Back";
            this.Button_Back.UseVisualStyleBackColor = true;
            this.Button_Back.Click += new System.EventHandler(this.Button_Back_Click);
            // 
            // Button_Clear
            // 
            this.Button_Clear.Location = new System.Drawing.Point(3, 35);
            this.Button_Clear.Name = "Button_Clear";
            this.Button_Clear.Size = new System.Drawing.Size(250, 23);
            this.Button_Clear.TabIndex = 13;
            this.Button_Clear.Text = "Clear mode";
            this.Button_Clear.UseVisualStyleBackColor = true;
            this.Button_Clear.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // Button_YFlip
            // 
            this.Button_YFlip.Location = new System.Drawing.Point(178, 7);
            this.Button_YFlip.Name = "Button_YFlip";
            this.Button_YFlip.Size = new System.Drawing.Size(75, 25);
            this.Button_YFlip.TabIndex = 12;
            this.Button_YFlip.Text = "Y Flip Mode";
            this.Button_YFlip.UseVisualStyleBackColor = true;
            this.Button_YFlip.Click += new System.EventHandler(this.Button_YFlip_Click);
            // 
            // Button_XFlip
            // 
            this.Button_XFlip.Location = new System.Drawing.Point(91, 7);
            this.Button_XFlip.Name = "Button_XFlip";
            this.Button_XFlip.Size = new System.Drawing.Size(75, 25);
            this.Button_XFlip.TabIndex = 11;
            this.Button_XFlip.Text = "X Flip Mode";
            this.Button_XFlip.UseVisualStyleBackColor = true;
            this.Button_XFlip.Click += new System.EventHandler(this.Button_XFlip_Click);
            // 
            // Button_Copy
            // 
            this.Button_Copy.Location = new System.Drawing.Point(3, 7);
            this.Button_Copy.Name = "Button_Copy";
            this.Button_Copy.Size = new System.Drawing.Size(75, 25);
            this.Button_Copy.TabIndex = 10;
            this.Button_Copy.Text = "Copy mode";
            this.Button_Copy.UseVisualStyleBackColor = true;
            this.Button_Copy.Click += new System.EventHandler(this.Button_Copy_Click);
            // 
            // Panel_EditFormats
            // 
            this.Panel_EditFormats.Controls.Add(this.Label_FormatType);
            this.Panel_EditFormats.Controls.Add(this.ComboBox_FormatTypes);
            this.Panel_EditFormats.Controls.Add(this.Button_Formats_Back);
            this.Panel_EditFormats.Location = new System.Drawing.Point(12, 801);
            this.Panel_EditFormats.Name = "Panel_EditFormats";
            this.Panel_EditFormats.Size = new System.Drawing.Size(256, 90);
            this.Panel_EditFormats.TabIndex = 15;
            this.Panel_EditFormats.Visible = false;
            // 
            // Label_FormatType
            // 
            this.Label_FormatType.AutoSize = true;
            this.Label_FormatType.Location = new System.Drawing.Point(3, 19);
            this.Label_FormatType.Name = "Label_FormatType";
            this.Label_FormatType.Size = new System.Drawing.Size(63, 13);
            this.Label_FormatType.TabIndex = 15;
            this.Label_FormatType.Text = "Type to set:";
            // 
            // ComboBox_FormatTypes
            // 
            this.ComboBox_FormatTypes.FormattingEnabled = true;
            this.ComboBox_FormatTypes.Items.AddRange(new object[] {
            "1: A315 (Large, translucency, favors color variety)",
            "2: I2 (Smallest, 4 colors)",
            "3: I4 (Medium, 16 colors)",
            "4: I8 (Large, 256 colors)",
            "5: NOT IMPLEMENTED Compressed (Default, best)",
            "6: A513 (Large, translucency, favors alpha)",
            "7: Direct 16-bit (Largest, best quality)"});
            this.ComboBox_FormatTypes.Location = new System.Drawing.Point(6, 34);
            this.ComboBox_FormatTypes.Name = "ComboBox_FormatTypes";
            this.ComboBox_FormatTypes.Size = new System.Drawing.Size(247, 21);
            this.ComboBox_FormatTypes.TabIndex = 15;
            this.ComboBox_FormatTypes.Text = "1: A315 (Large, translucency, favors color variety)";
            // 
            // Button_Formats_Back
            // 
            this.Button_Formats_Back.Location = new System.Drawing.Point(3, 62);
            this.Button_Formats_Back.Name = "Button_Formats_Back";
            this.Button_Formats_Back.Size = new System.Drawing.Size(250, 23);
            this.Button_Formats_Back.TabIndex = 14;
            this.Button_Formats_Back.Text = "Back";
            this.Button_Formats_Back.UseVisualStyleBackColor = true;
            this.Button_Formats_Back.Click += new System.EventHandler(this.Button_Formats_Back_Click);
            // 
            // Panel_Randomization
            // 
            this.Panel_Randomization.BackColor = System.Drawing.SystemColors.Control;
            this.Panel_Randomization.Controls.Add(this.Label_PlaceInGroup);
            this.Panel_Randomization.Controls.Add(this.ComboBox_RandomizationGroups);
            this.Panel_Randomization.Controls.Add(this.Button_RemoveRandoGroup);
            this.Panel_Randomization.Controls.Add(this.Button_AddRandoGroup);
            this.Panel_Randomization.Controls.Add(this.Button_Randomization_Back);
            this.Panel_Randomization.Location = new System.Drawing.Point(12, 801);
            this.Panel_Randomization.Name = "Panel_Randomization";
            this.Panel_Randomization.Size = new System.Drawing.Size(256, 90);
            this.Panel_Randomization.TabIndex = 16;
            this.Panel_Randomization.Visible = false;
            // 
            // Label_PlaceInGroup
            // 
            this.Label_PlaceInGroup.AutoSize = true;
            this.Label_PlaceInGroup.Location = new System.Drawing.Point(88, 13);
            this.Label_PlaceInGroup.Name = "Label_PlaceInGroup";
            this.Label_PlaceInGroup.Size = new System.Drawing.Size(78, 13);
            this.Label_PlaceInGroup.TabIndex = 15;
            this.Label_PlaceInGroup.Text = "Place in group:";
            // 
            // ComboBox_RandomizationGroups
            // 
            this.ComboBox_RandomizationGroups.FormattingEnabled = true;
            this.ComboBox_RandomizationGroups.Location = new System.Drawing.Point(92, 34);
            this.ComboBox_RandomizationGroups.Name = "ComboBox_RandomizationGroups";
            this.ComboBox_RandomizationGroups.Size = new System.Drawing.Size(72, 21);
            this.ComboBox_RandomizationGroups.TabIndex = 16;
            // 
            // Button_RemoveRandoGroup
            // 
            this.Button_RemoveRandoGroup.Location = new System.Drawing.Point(170, 3);
            this.Button_RemoveRandoGroup.Name = "Button_RemoveRandoGroup";
            this.Button_RemoveRandoGroup.Size = new System.Drawing.Size(83, 53);
            this.Button_RemoveRandoGroup.TabIndex = 16;
            this.Button_RemoveRandoGroup.Text = "Remove";
            this.Button_RemoveRandoGroup.UseVisualStyleBackColor = true;
            this.Button_RemoveRandoGroup.Click += new System.EventHandler(this.Button_RemoveRandoGroup_Click);
            // 
            // Button_AddRandoGroup
            // 
            this.Button_AddRandoGroup.Location = new System.Drawing.Point(3, 3);
            this.Button_AddRandoGroup.Name = "Button_AddRandoGroup";
            this.Button_AddRandoGroup.Size = new System.Drawing.Size(83, 53);
            this.Button_AddRandoGroup.TabIndex = 15;
            this.Button_AddRandoGroup.Text = "Add";
            this.Button_AddRandoGroup.UseVisualStyleBackColor = true;
            this.Button_AddRandoGroup.Click += new System.EventHandler(this.Button_AddRandoGroup_Click);
            // 
            // Button_Randomization_Back
            // 
            this.Button_Randomization_Back.Location = new System.Drawing.Point(3, 62);
            this.Button_Randomization_Back.Name = "Button_Randomization_Back";
            this.Button_Randomization_Back.Size = new System.Drawing.Size(250, 23);
            this.Button_Randomization_Back.TabIndex = 14;
            this.Button_Randomization_Back.Text = "Back";
            this.Button_Randomization_Back.UseVisualStyleBackColor = true;
            this.Button_Randomization_Back.Click += new System.EventHandler(this.Button_Randomization_Back_Click);
            // 
            // Label_LargePreview_Preview
            // 
            this.Label_LargePreview_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_LargePreview_Preview.AutoSize = true;
            this.Label_LargePreview_Preview.Location = new System.Drawing.Point(3, 4);
            this.Label_LargePreview_Preview.Name = "Label_LargePreview_Preview";
            this.Label_LargePreview_Preview.Size = new System.Drawing.Size(48, 13);
            this.Label_LargePreview_Preview.TabIndex = 21;
            this.Label_LargePreview_Preview.Text = "Preview:";
            this.Label_LargePreview_Preview.DoubleClick += new System.EventHandler(this.Label_LargePreview_Preview_DoubleClick);
            // 
            // Label_LargePreview_Zoom
            // 
            this.Label_LargePreview_Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_LargePreview_Zoom.AutoSize = true;
            this.Label_LargePreview_Zoom.Location = new System.Drawing.Point(164, 4);
            this.Label_LargePreview_Zoom.Name = "Label_LargePreview_Zoom";
            this.Label_LargePreview_Zoom.Size = new System.Drawing.Size(37, 13);
            this.Label_LargePreview_Zoom.TabIndex = 22;
            this.Label_LargePreview_Zoom.Text = "Zoom:";
            // 
            // NumUpDown_Zoom
            // 
            this.NumUpDown_Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NumUpDown_Zoom.Location = new System.Drawing.Point(207, 2);
            this.NumUpDown_Zoom.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumUpDown_Zoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDown_Zoom.Name = "NumUpDown_Zoom";
            this.NumUpDown_Zoom.Size = new System.Drawing.Size(47, 20);
            this.NumUpDown_Zoom.TabIndex = 8;
            this.NumUpDown_Zoom.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumUpDown_Zoom.ValueChanged += new System.EventHandler(this.NumUpDown_Zoom_ValueChanged);
            // 
            // Panel_LargePreview
            // 
            this.Panel_LargePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_LargePreview.AutoScroll = true;
            this.Panel_LargePreview.Controls.Add(this.PictureBox_LargePreview);
            this.Panel_LargePreview.Location = new System.Drawing.Point(6, 22);
            this.Panel_LargePreview.Name = "Panel_LargePreview";
            this.Panel_LargePreview.Size = new System.Drawing.Size(244, 193);
            this.Panel_LargePreview.TabIndex = 23;
            // 
            // PictureBox_LargePreview
            // 
            this.PictureBox_LargePreview.Location = new System.Drawing.Point(3, 3);
            this.PictureBox_LargePreview.Name = "PictureBox_LargePreview";
            this.PictureBox_LargePreview.Size = new System.Drawing.Size(100, 50);
            this.PictureBox_LargePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_LargePreview.TabIndex = 0;
            this.PictureBox_LargePreview.TabStop = false;
            // 
            // Panel_LargePreviewWrapper
            // 
            this.Panel_LargePreviewWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_LargePreviewWrapper.Controls.Add(this.Panel_LargePreview);
            this.Panel_LargePreviewWrapper.Controls.Add(this.Label_LargePreview_Zoom);
            this.Panel_LargePreviewWrapper.Controls.Add(this.Label_LargePreview_Preview);
            this.Panel_LargePreviewWrapper.Controls.Add(this.NumUpDown_Zoom);
            this.Panel_LargePreviewWrapper.Location = new System.Drawing.Point(831, 671);
            this.Panel_LargePreviewWrapper.Name = "Panel_LargePreviewWrapper";
            this.Panel_LargePreviewWrapper.Size = new System.Drawing.Size(253, 218);
            this.Panel_LargePreviewWrapper.TabIndex = 1;
            // 
            // Button_ClearSelectedObject
            // 
            this.Button_ClearSelectedObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_ClearSelectedObject.Location = new System.Drawing.Point(830, 642);
            this.Button_ClearSelectedObject.Name = "Button_ClearSelectedObject";
            this.Button_ClearSelectedObject.Size = new System.Drawing.Size(254, 25);
            this.Button_ClearSelectedObject.TabIndex = 17;
            this.Button_ClearSelectedObject.Text = "Clear selected";
            this.Button_ClearSelectedObject.UseVisualStyleBackColor = true;
            this.Button_ClearSelectedObject.Click += new System.EventHandler(this.Button_ClearSelectedObject_Click);
            // 
            // RawTileCollisionDataEditor
            // 
            this.RawTileCollisionDataEditor.Location = new System.Drawing.Point(6, 25);
            this.RawTileCollisionDataEditor.MaximumSize = new System.Drawing.Size(9000, 22);
            this.RawTileCollisionDataEditor.Name = "RawTileCollisionDataEditor";
            this.RawTileCollisionDataEditor.Size = new System.Drawing.Size(167, 22);
            this.RawTileCollisionDataEditor.TabIndex = 15;
            // 
            // Newt_MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 895);
            this.Controls.Add(this.Button_ClearSelectedObject);
            this.Controls.Add(this.Panel_Randomization);
            this.Controls.Add(this.Panel_LargePreviewWrapper);
            this.Controls.Add(this.Panel_EditFormats);
            this.Controls.Add(this.Panel_EditTilemapButtons);
            this.Controls.Add(this.Panel_TilePicker);
            this.Controls.Add(this.Panel_Buttons);
            this.Controls.Add(this.Panel_CollisionEditor);
            this.Controls.Add(this.Panel_ObjectCanvasWrapper);
            this.Controls.Add(this.Panel_ObjectPicker);
            this.Controls.Add(this.Newt_MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Newt_MenuStrip;
            this.Name = "Newt_MainWindow";
            this.Text = "Newt Tileset Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Newt_MainWindow_FormClosing);
            this.Resize += new System.EventHandler(this.Newt_MainWindow_Resize);
            this.Newt_MenuStrip.ResumeLayout(false);
            this.Newt_MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_TilePickerCanvas)).EndInit();
            this.Panel_ObjectPicker.ResumeLayout(false);
            this.Panel_ObjectCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_ObjectCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_ObjectCanvas_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_ObjectCanvas_Height)).EndInit();
            this.Panel_ObjectCanvasWrapper.ResumeLayout(false);
            this.Panel_CanvasControls.ResumeLayout(false);
            this.Panel_CanvasControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_ObjectCanvasZoom)).EndInit();
            this.Panel_ObjectCanvasScrollWrapper.ResumeLayout(false);
            this.Panel_CollisionEditor.ResumeLayout(false);
            this.Panel_CollisionEditor.PerformLayout();
            this.PartialBlockParamsPanel.ResumeLayout(false);
            this.PartialBlockParamsPanel.PerformLayout();
            this.PipeDoorParamsPanel.ResumeLayout(false);
            this.Panel_Buttons.ResumeLayout(false);
            this.Panel_TilePicker.ResumeLayout(false);
            this.Panel_EditTilemapButtons.ResumeLayout(false);
            this.Panel_EditFormats.ResumeLayout(false);
            this.Panel_EditFormats.PerformLayout();
            this.Panel_Randomization.ResumeLayout(false);
            this.Panel_Randomization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Zoom)).EndInit();
            this.Panel_LargePreview.ResumeLayout(false);
            this.Panel_LargePreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_LargePreview)).EndInit();
            this.Panel_LargePreviewWrapper.ResumeLayout(false);
            this.Panel_LargePreviewWrapper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Newt_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_Open;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem Menu_Create;
        private System.Windows.Forms.ToolStripMenuItem Menu_Actions;
        private System.Windows.Forms.ToolStripMenuItem Menu_ClearObjects;
        private System.Windows.Forms.ToolStripMenuItem Menu_ClearCollision;
        private System.Windows.Forms.ToolStripMenuItem Menu_ClearFlipping;
        private System.Windows.Forms.ToolStripMenuItem Menu_ClearRandom;
        private System.Windows.Forms.ToolStripMenuItem Menu_SetTilesToDefaultFormat;
        private System.Windows.Forms.ToolStripMenuItem Menu_About;
        private System.Windows.Forms.PictureBox PictureBox_TilePickerCanvas;
        private System.Windows.Forms.Panel Panel_ObjectPicker;
        private System.Windows.Forms.Panel Panel_ObjectCanvas;
        private System.Windows.Forms.PictureBox PictureBox_ObjectCanvas;
        private System.Windows.Forms.NumericUpDown NumUpDown_ObjectCanvas_Width;
        private System.Windows.Forms.NumericUpDown NumUpDown_ObjectCanvas_Height;
        private System.Windows.Forms.Label Label_ObjectCavas_Width;
        private System.Windows.Forms.Label Label_ObjectCanvas_Height;
        private System.Windows.Forms.Panel Panel_ObjectCanvasWrapper;
        private System.Windows.Forms.Panel Panel_CollisionEditor;
        private System.Windows.Forms.Label Label_CollisionEditor_SubType;
        private System.Windows.Forms.ComboBox ComboBox_CollisionEditor_SubType;
        private System.Windows.Forms.Label Label_CollisionEditor_Flags;
        private System.Windows.Forms.Label Label_CollisionEditor_Parameters;
        private System.Windows.Forms.Button Button_EditTilemap;
        private System.Windows.Forms.Panel Panel_Buttons;
        private System.Windows.Forms.Button Button_EditFormats;
        private System.Windows.Forms.Button Button_EditRandomization;
        private System.Windows.Forms.ToolStripMenuItem Menu_LoadPNG;
        private System.Windows.Forms.Panel Panel_TilePicker;
        private System.Windows.Forms.Panel Panel_EditTilemapButtons;
        private System.Windows.Forms.Button Button_YFlip;
        private System.Windows.Forms.Button Button_XFlip;
        private System.Windows.Forms.Button Button_Copy;
        private System.Windows.Forms.Button Button_Clear;
        private System.Windows.Forms.Button Button_Back;
        private System.Windows.Forms.Label Label_NoGo;
        private System.Windows.Forms.ToolStripMenuItem Menu_ToggleChangesOverlay;
        private System.Windows.Forms.Panel Panel_EditFormats;
        private System.Windows.Forms.Button Button_Formats_Back;
        private System.Windows.Forms.Label Label_FormatType;
        private System.Windows.Forms.ComboBox ComboBox_FormatTypes;
        private System.Windows.Forms.Panel Panel_Randomization;
        private System.Windows.Forms.Button Button_Randomization_Back;
        private System.Windows.Forms.Button Button_AddRandoGroup;
        private System.Windows.Forms.ComboBox ComboBox_RandomizationGroups;
        private System.Windows.Forms.Button Button_RemoveRandoGroup;
        private System.Windows.Forms.Label Label_PlaceInGroup;
        private System.Windows.Forms.CheckedListBox ListBox_CollisionFlags;
        private System.Windows.Forms.Label Label_CollisionEditorRawData;
        private System.Windows.Forms.ComboBox ComboBox_CollisionSubTypes;
        private System.Windows.Forms.Panel PartialBlockParamsPanel;
        private System.Windows.Forms.CheckBox CheckBox_PartialBlock_BottomRight;
        private System.Windows.Forms.CheckBox CheckBox_PartialBlock_BottomLeft;
        private System.Windows.Forms.CheckBox CheckBox_PartialBlock_TopRight;
        private System.Windows.Forms.CheckBox CheckBox_PartialBlock_TopLeft;
        private System.Windows.Forms.Panel PipeDoorParamsPanel;
        private System.Windows.Forms.ListBox ListBox_PipeDoorParams;
        private System.Windows.Forms.ComboBox ComboBox_PipeDoorType;
        private System.Windows.Forms.ListBox ListBox_NormalTileParams;
        private Newt.RawTileCollisionDataEditor RawTileCollisionDataEditor;
        private System.Windows.Forms.ListView ListView_Objects;
        private System.Windows.Forms.ColumnHeader Column1;
        private System.Windows.Forms.NumericUpDown NumUpDown_Zoom;
        private System.Windows.Forms.Label Label_LargePreview_Zoom;
        private System.Windows.Forms.Label Label_LargePreview_Preview;
        private System.Windows.Forms.Panel Panel_LargePreview;
        private System.Windows.Forms.PictureBox PictureBox_LargePreview;
        private System.Windows.Forms.Panel Panel_LargePreviewWrapper;
        private System.Windows.Forms.Button Button_ClearSelectedObject;
        private System.Windows.Forms.ToolStripMenuItem Menu_Quit;
        private System.Windows.Forms.ToolStripMenuItem Menu_AdjustCanvasToSelected;
        private System.Windows.Forms.Label Label_ObjectCanvasZoom;
        private System.Windows.Forms.NumericUpDown NumericUpDown_ObjectCanvasZoom;
        private System.Windows.Forms.Panel Panel_ObjectCanvasScrollWrapper;
        private System.Windows.Forms.Panel Panel_CanvasControls;
        private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
    }
}

