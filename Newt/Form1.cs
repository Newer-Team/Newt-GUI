using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Newt.ObjectClasses;

namespace Newt
{
    public partial class Newt_MainWindow : Form
    {
        int Mode = 0;

        private Bitmap TilesetWorkBitmap
        {
            get
            {
                return _TilesetWorkBitmap;
            }
            set
            {
                _TilesetWorkBitmap = value;
                this.PictureBox_TilePickerCanvas.Image = _TilesetWorkBitmap;
            }
        }

        Bitmap _TilesetWorkBitmap;
        Bitmap TilesetChangesBitmap = new Bitmap(256, 768);
        Bitmap TilesetFormatsBitmap = new Bitmap(256, 768);
        Bitmap TilesetRandomizationBitmap = new Bitmap(256, 768);

        private readonly ImageList ObjectImages = new ImageList();

        bool ShowChanges = false;
        bool ShowFormats = false;
        bool ShowRandomization = false;
        bool AdjustCanvas = false;

        public Newt_MainWindow(string TilesetFileName)
        {
            InitializeComponent();

            this.CenterToScreen();

            TilesetWorkBitmap = new Bitmap(256, 768);

            if (TilesetFileName != "")
            {
                if (!File.Exists(TilesetFileName))
                {
                    MessageBox.Show("This file doesn't exist.");
                }
                else
                    OpenTileset(TilesetFileName);
            }

            this.Click += PictureBox_TilePicker_ClickAway;
            this.Newt_MenuStrip.Click += PictureBox_TilePicker_SuperClickAway;
            this.Panel_ObjectCanvas.Click += PictureBox_TilePicker_SuperClickAway;
            this.Panel_ObjectCanvasWrapper.Click += PictureBox_TilePicker_SuperClickAway;
            this.Panel_ObjectPicker.Click += PictureBox_TilePicker_SuperClickAway;

            DefaultCanvasSize = new Size(Panel_ObjectCanvasScrollWrapper.Width - 10, Panel_ObjectCanvasScrollWrapper.Height - 10);
            ComboBox_RandomizationGroups.Items.Add("None");
            ListBox_CollisionFlags.Items.AddRange(Globals.BehaviourFlags);
            ComboBox_CollisionSubTypes.Items.AddRange(Globals.TileSubtypes);
            ComboBox_PipeDoorType.Items.AddRange(Globals.PipeDoorType);
            PopulateListBox(ListBox_PipeDoorParams, 32, Globals.PipeDoorParams);
            RawTileCollisionDataEditor.ValueChanged += ByteArrayEditor_Collision_ValueChanged;
            PictureBox_TilePicker_SuperClickAway(this, null);

            ObjectImages.ColorDepth = ColorDepth.Depth32Bit;
            ObjectImages.ImageSize = new Size(100, 50);
            ObjectBeingEdited = Globals.EditedTileset.Objects[0];
            ListView_Objects.SmallImageList = ObjectImages;
            DrawObjectsFromTileset(Globals.EditedTileset, true);

            Globals.EditedTileset.GenerateObjectHash();
        }

        private void Newt_MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globals.EditedTileset.IsDirty())
            {
                DialogResult DR = MessageBox.Show("Tileset was changed. Perhaps you'd like to save it before you quit?", "Quitting...", MessageBoxButtons.YesNoCancel);

                if (DR == DialogResult.Cancel)
                    e.Cancel = true;

                if (DR == DialogResult.Yes)
                {
                    Menu_Save_Click(this, null);
                }
            }
        }


        private void OpenTileset(string Filename)
        {
            try
            {
                Globals.EditedTileset.LoadInByFilename(Filename);
                DrawCanvasFromTileset(Globals.EditedTileset);
                DrawChangesFromTileset(Globals.EditedTileset);
                DrawFormatsFromTileset(Globals.EditedTileset);
                DrawRandomizationFromTileset(Globals.EditedTileset);
                DrawObjectsFromTileset(Globals.EditedTileset);
                ObjectBeingEdited = Globals.EditedTileset.Objects[0];

                ComboBox_RandomizationGroups.Items.Clear();
                ComboBox_RandomizationGroups.Items.Add("None");

                for (int i = 0; i < Globals.EditedTileset.RandomizationGroups.Count; i++)
                    ComboBox_RandomizationGroups.Items.Add(i + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void DrawCanvasFromTileset(Tileset Tileset)
        {
            try
            {
                TilesetWorkBitmap = new Bitmap(256, 768);

                int i = 0;
                foreach (Tile Tile in Tileset.Tiles)
                {
                    if (Tile.ID > 765)
                        return;

                    using (Graphics g = Graphics.FromImage(TilesetWorkBitmap))
                    {
                        g.DrawImage(Tile.TileBitmap, Helpers.GetRectangleForTileID(i), new Rectangle(new Point(0, 0), new Size(16, 16)), GraphicsUnit.Pixel);
                    }

                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void DrawChangesFromTileset(Tileset Tileset)
        {
            Brush TransculentPurple = new SolidBrush(Color.FromArgb(127, 255, 0, 255));
            TilesetChangesBitmap = new Bitmap(256, 768);

            for (int i = 0; i < 765; i++)
            {
                if (Tileset.Tiles[i].ID != i | Tileset.Tiles[i].FlipX | Tileset.Tiles[i].FlipY)
                {
                    Rectangle Rect = Helpers.GetRectangleForTileID(i);

                    using (Graphics g = Graphics.FromImage(TilesetChangesBitmap))
                    {
                        g.FillRectangle(TransculentPurple, Rect);
                    }
                }
            }
        }

        private void DrawFormatsFromTileset(Tileset Tileset)
        {
            Brush White = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
            TilesetFormatsBitmap = new Bitmap(256, 768);

            for (int i = 0; i < 765; i++)
            {
                Rectangle Rect = Helpers.GetRectangleForTileID(i);

                using (Graphics g = Graphics.FromImage(TilesetFormatsBitmap))
                {
                    Brush TransculentColor = null;
                    switch (Globals.EditedTileset.TextureFormats[i])
                    {
                        case 1: TransculentColor = new SolidBrush(Color.FromArgb(96, 255, 0, 255)); break;
                        case 2: TransculentColor = new SolidBrush(Color.FromArgb(96, 255, 0, 0)); break;
                        case 3: TransculentColor = new SolidBrush(Color.FromArgb(96, 0, 0, 255)); break;
                        case 4: TransculentColor = new SolidBrush(Color.FromArgb(96, 0, 255, 0)); break;
                        case 5: TransculentColor = new SolidBrush(Color.FromArgb(96, 0, 0, 0)); break;
                        case 6: TransculentColor = new SolidBrush(Color.FromArgb(96, 255, 255, 0)); break;
                        case 7: TransculentColor = new SolidBrush(Color.FromArgb(96, 0, 255, 255)); break;
                        default: TransculentColor = new SolidBrush(Color.FromArgb(96, 255, 0, 255)); break;
                    }

                    g.FillRectangle(TransculentColor, Rect);
                    g.DrawString((Tileset.TextureFormats[i]).ToString(), new Font("Arial", 12.25F, FontStyle.Bold), White, Rect.X, Rect.Y);
                }
            }
        }

        private void DrawRandomizationFromTileset(Tileset Tileset)
        {
            Brush TransculentPurple = new SolidBrush(Color.FromArgb(96, 255, 0, 255));
            Brush TransculentWhite = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
            TilesetRandomizationBitmap = new Bitmap(256, 768);

            int i = 0;

            foreach (List<int> Group in Tileset.RandomizationGroups)
            {
                i++;

                foreach (int Tile in Group)
                {
                    using (Graphics g = Graphics.FromImage(TilesetRandomizationBitmap))
                    {
                        Rectangle Rect = Helpers.GetRectangleForTileID(Tile);
                        g.FillRectangle(TransculentPurple, Rect);
                        g.DrawString(i.ToString(), new Font("Arial", 12.25F, FontStyle.Bold), TransculentWhite, Rect.X, Rect.Y);
                    }
                }
            }
        }

        private void DrawObjectsFromTileset(Tileset Tileset, bool FirstRun = false)
        {
            try
            {
                ListView_Objects.BeginUpdate();

                for (int i = 0; i < 256; i++)
                {
                    Bitmap ObjectBitmap = new Bitmap(100, 50);
                    string ObjName = "Object " + i;

                    if (Tileset.Objects.Count() <= i)
                    {
                        using (Graphics g = Graphics.FromImage(ObjectBitmap))
                        {
                            g.FillRectangle(new SolidBrush(Color.Red), 0, 0, 100, 50);
                            g.DrawString(i.ToString(), new Font("Arial", 12.25F, FontStyle.Bold), new SolidBrush(Color.White), 0, 0);
                        }

                        if (FirstRun)
                            ObjectImages.Images.Add(ObjectBitmap);
                        else
                            ObjectImages.Images[i] = ObjectBitmap;
                    }
                    else
                    {
                        if (Tileset.Objects[i].Tiles.Count != 0)
                        {
                            using (Graphics g = Graphics.FromImage(ObjectBitmap))
                            {
                                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                                g.DrawImage(Tileset.Objects[i].PreviewBitmap, new Point(0, 0));
                            }

                            ObjName = Globals.EditedTileset.Objects[i].Name;

                            if (FirstRun)
                                ObjectImages.Images.Add(ObjectBitmap);
                            else
                                ObjectImages.Images[i] = ObjectBitmap;
                        }
                        else
                        {
                            using (Graphics g = Graphics.FromImage(ObjectBitmap))
                            {
                                g.FillRectangle(new SolidBrush(Color.Red), 0, 0, 100, 50);
                                g.DrawString(i.ToString(), new Font("Arial", 12.25F, FontStyle.Bold), new SolidBrush(Color.White), 0, 0);
                            }

                            if (FirstRun)
                                ObjectImages.Images.Add(ObjectBitmap);
                            else
                                ObjectImages.Images[i] = ObjectBitmap;
                        }
                    }

                    if (FirstRun)
                        ListView_Objects.Items.Add(new ListViewItem { ImageIndex = i, Text = ObjName });
                    else
                    {
                        ListView_Objects.Items[i].ImageIndex = i;
                        ListView_Objects.Items[i].Text = ObjName;
                    }
                }

                ListView_Objects.Items[0].Selected = true;
                ListView_Objects_Click(this, null);

                ListView_Objects.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Newt_MainWindow_Resize(object sender, EventArgs e)
        {
            DefaultCanvasSize = new Size(Panel_ObjectCanvasScrollWrapper.Width - 10, Panel_ObjectCanvasScrollWrapper.Height - 10);
            RedrawObjectCanvasForZoom();

            Panel_Buttons.Location = new Point(Panel_Buttons.Location.X, Panel_TilePicker.Bottom + 5);
            Panel_EditFormats.Location = Panel_Buttons.Location;
            Panel_EditTilemapButtons.Location = Panel_Buttons.Location;
            Panel_Randomization.Location = Panel_Buttons.Location;
        }

        #region File Menu

        private void Menu_Open_Click(object sender, EventArgs e)
        {
            try
            {
                if (Globals.EditedTileset.IsDirty())
                {
                    DialogResult DR = MessageBox.Show("Tileset was changed. Perhaps you'd like to save it before you load another?", "Unsaved changes", MessageBoxButtons.YesNoCancel);

                    if (DR == DialogResult.Cancel)
                        return;

                    if (DR == DialogResult.Yes)
                    {
                        Menu_Save_Click(this, null);
                    }
                }

                OpenFileDialog Dialog = new OpenFileDialog { Filter = "Newer Super Mario Land Tilesets (*.zmt)|*.zmt|All files(*.*)|*.*" };
                Dialog.ShowDialog();

                if (Dialog.FileName == "")
                    return;

                OpenTileset(Dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Menu_LoadPNG_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Dialog = new OpenFileDialog { Filter = "Portable Network Graphics (*.png)|*.png|All files(*.*)|*.*" };
                Dialog.ShowDialog();

                if (Dialog.FileName == "")
                    return;

                Bitmap NewImage = new Bitmap(Dialog.FileName);

                if (NewImage.Width != 256 && NewImage.Height != 768)
                {
                    MessageBox.Show("Improper dimensions. Should be 256x768");
                    return;
                }

                Globals.EditedTileset.ReloadTileGraphics(NewImage);
                DrawCanvasFromTileset(Globals.EditedTileset);

                foreach (Newt.ObjectClasses.Object o in Globals.EditedTileset.Objects)
                    o.RedrawPreview(Globals.EditedTileset);

                DrawObjectsFromTileset(Globals.EditedTileset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Menu_Create_Click(object sender, EventArgs e)
        {
            try
            {
                if (Globals.EditedTileset.IsDirty())
                {
                    DialogResult DR = MessageBox.Show("Tileset was changed. Perhaps you'd like to save it before you load another?", "Unsaved changes", MessageBoxButtons.YesNoCancel);

                    if (DR == DialogResult.Cancel)
                        return;

                    if (DR == DialogResult.Yes)
                    {
                        Menu_Save_Click(this, null);
                    }
                }

                Globals.EditedTileset = new Tileset();
                DrawCanvasFromTileset(Globals.EditedTileset);
                DrawChangesFromTileset(Globals.EditedTileset);
                DrawFormatsFromTileset(Globals.EditedTileset);
                DrawRandomizationFromTileset(Globals.EditedTileset);
                DrawObjectsFromTileset(Globals.EditedTileset);

                Globals.EditedTileset.GenerateObjectHash();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Menu_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Save_Click(object sender, EventArgs e)
        {
            if (Globals.EditedTileset.Filename == "")
            {
                Menu_SaveAs_Click(this, null);
                return;
            }
            else
            {
                try
                {
                    Globals.EditedTileset.Save(Globals.EditedTileset.Filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                Globals.EditedTileset.GenerateObjectHash();
            }
        }

        private void Menu_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog SF = new SaveFileDialog { Filter = "Newer Super Mario Land Tilesets (*.zmt)|*.zmt|All files(*.*)|*.*" };
            SF.ShowDialog();

            if (SF.FileName != "")
            {
                try
                {
                    Globals.EditedTileset.Save(SF.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                Globals.EditedTileset.Filename = SF.FileName;
                Globals.EditedTileset.GenerateObjectHash();
            }
        }

        private void ExportPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SF = new SaveFileDialog { Filter = "Portable Network Graphics (*.png)|*.png" };
            SF.ShowDialog();

            if (SF.FileName != "")
            {
                try
                {
                    Globals.EditedTileset.MainPNG.Save(SF.FileName, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        #endregion

        #region Actions Menu
        private void Menu_ClearFlipping_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Are you sure?", "Clearing tilemap changes...", MessageBoxButtons.YesNo);

            if (DR == DialogResult.No)
                return;

            try
            {
                foreach (Tile Tile in Globals.EditedTileset.Tiles)
                {
                    if (Tile.FlipX || Tile.FlipY || Tile.ID != Tile.Number)
                    {
                        Tile.ID = Tile.Number;
                        Tile.FlipX = false;
                        Tile.FlipY = false;
                    }
                }

                Globals.EditedTileset.ReloadTileGraphics(Globals.EditedTileset.MainPNG);
                DrawCanvasFromTileset(Globals.EditedTileset);
                DrawChangesFromTileset(Globals.EditedTileset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Menu_ToggleChangesOverlay_Click(object sender, EventArgs e)
        {
            DrawChangesFromTileset(Globals.EditedTileset);
            ShowChanges = !ShowChanges;
            PictureBox_TilePickerCanvas.Invalidate(true);
        }

        private void Menu_ClearRandom_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Are you sure?", "Clearing randomization...", MessageBoxButtons.YesNo);

            if (DR == DialogResult.No)
                return;

            try
            {
                Globals.EditedTileset.RandomizationGroups = new List<List<int>>();
                DrawRandomizationFromTileset(Globals.EditedTileset);
                PictureBox_TilePickerCanvas.Invalidate(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Menu_SetTilesToDefaultFormat_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Are you sure?", "Clearing formats...", MessageBoxButtons.YesNo);

            if (DR == DialogResult.No)
                return;

            try
            {
                for (int i = 0; i < 765; i++)
                    Globals.EditedTileset.TextureFormats[i] = 5;

                DrawFormatsFromTileset(Globals.EditedTileset);
                PictureBox_TilePickerCanvas.Invalidate(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Menu_ClearCollision_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Are you sure?", "Clearing collision...", MessageBoxButtons.YesNo);

            if (DR == DialogResult.No)
                return;

            try
            {
                foreach (Tile Tile in Globals.EditedTileset.Tiles)
                    Tile.Collision = new byte[] { 0, 0, 0, 0 };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void Menu_ClearObjects_Click(object sender, EventArgs e)
        {
            Globals.EditedTileset.Objects.Clear();
            for (int i = 0; i < 256; i++)
            {
                Globals.EditedTileset.Objects.Add(new ObjectClasses.Object(i, 0, 0, "Object " + i, new List<List<int>>(), new Bitmap(16, 16)));
            }

            DrawObjectsFromTileset(Globals.EditedTileset);
        }


        private void Menu_AdjustCanvasToSelected_Click(object sender, EventArgs e)
        {
            AdjustCanvas = !AdjustCanvas;
        }

        #endregion

        #region About Menu

        private void Menu_About_Click(object sender, EventArgs e)
        {
            About AboutDialog = new About();
            AboutDialog.ShowDialog();
        }

        #endregion

        #region Object Canvas

        Point ObjectCanvasMouseHover = new Point(0, 0);
        bool ObjectCanvasMouseHovered = false;
        bool CanvasDataUpdateFlag = false;
        Size DefaultCanvasSize = new Size(0, 0);
        int ObjectCanvasTileSize = 16;

        #region Object Picker

        ListViewItem ObjectNameBeingEdited = null;
        TextBox ObjectNameTextbox = null;
        ObjectClasses.Object ObjectBeingEdited = null;
        int ZoomPreview = 2;

        private void ListView_Objects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView_Objects.MouseDoubleClick -= ListView_Objects_MouseDoubleClick;

            ObjectNameBeingEdited = ListView_Objects.SelectedItems[0];

            ObjectNameTextbox = new TextBox
            {
                Size = new Size(130, 51),
                Multiline = true,
                Location = new Point(104, (e.Location.Y / 50) * 50),
                Text = ObjectNameBeingEdited.Text
            };

            ObjectNameTextbox.KeyUp += Box_KeyUp;
            ListView_Objects.Controls.Add(ObjectNameTextbox);
            ObjectNameTextbox.Focus();
        }

        private void StopEditingObjectName()
        {
            ObjectNameBeingEdited.Text = ObjectNameTextbox.Text;

            if (string.IsNullOrWhiteSpace(ObjectNameTextbox.Text))
                ObjectNameBeingEdited.Text = "Object " + ObjectNameBeingEdited.ImageIndex;

            ObjectBeingEdited.Name = ObjectNameBeingEdited.Text;
            ListView_Objects.Controls.Remove(ObjectNameTextbox);
            ListView_Objects.MouseDoubleClick += ListView_Objects_MouseDoubleClick;
            ObjectNameBeingEdited = null;
        }

        private void Box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StopEditingObjectName();
            }
        }

        private void ListView_Objects_Click(object sender, EventArgs e)
        {
            int SelectedID = 0;

            if (ObjectNameBeingEdited != null)
                StopEditingObjectName();

            if (ListView_Objects.SelectedIndices.Count != 0)
                SelectedID = ListView_Objects.SelectedIndices[0];

            if (SelectedID < Globals.EditedTileset.Objects.Count)
                ObjectBeingEdited = Globals.EditedTileset.Objects[SelectedID];
            else
                ObjectBeingEdited = new ObjectClasses.Object(SelectedID, 1, 1, "Object " + SelectedID, new List<List<int>>() { new List<int>() }, new Bitmap(16, 16));

            CanvasDataUpdateFlag = true;

            NumUpDown_ObjectCanvas_Height.Value = (int)ObjectBeingEdited.Height == 0 ? 1 : (int)ObjectBeingEdited.Height;
            NumUpDown_ObjectCanvas_Width.Value = (int)ObjectBeingEdited.Width == 0 ? 1 : (int)ObjectBeingEdited.Width;

            PictureBox_ObjectCanvas.Image = ObjectBeingEdited.PreviewBitmap;

            CanvasDataUpdateFlag = false;

            NumUpDown_ObjectCanvas_ValueChanged(this, null);
            RedrawLargeZoomPreview();
            RedrawObjectCanvasForZoom();
        }

        private void NumUpDown_Zoom_ValueChanged(object sender, EventArgs e)
        {
            ZoomPreview = (int)NumUpDown_Zoom.Value;
            RedrawLargeZoomPreview();
        }

        private void RedrawLargeZoomPreview()
        {
            if (ObjectBeingEdited == null)
                return;

            Bitmap ZoomedPreview = new Bitmap(ObjectBeingEdited.PreviewBitmap.Width * ZoomPreview, ObjectBeingEdited.PreviewBitmap.Height * ZoomPreview);

            using (Graphics g = Graphics.FromImage(ZoomedPreview))
            {
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(ObjectBeingEdited.PreviewBitmap, 0, 0, ObjectBeingEdited.PreviewBitmap.Width * ZoomPreview, ObjectBeingEdited.PreviewBitmap.Height * ZoomPreview);
            }

            PictureBox_LargePreview.Image = ZoomedPreview;
            PictureBox_LargePreview.Height = PictureBox_LargePreview.Image.Height;
            PictureBox_LargePreview.Width = PictureBox_LargePreview.Image.Width;
        }

        #endregion

        private void NumericUpDown_ObjectCanvasZoom_ValueChanged(object sender, EventArgs e)
        {
            ObjectCanvasTileSize = (int)NumericUpDown_ObjectCanvasZoom.Value * 16;
            RedrawObjectCanvasForZoom();
        }

        private void RedrawObjectCanvasForZoom()
        {
            int Width = ObjectCanvasTileSize * (int)NumUpDown_ObjectCanvas_Width.Value;
            int Height = ObjectCanvasTileSize * (int)NumUpDown_ObjectCanvas_Height.Value;

            Bitmap ZoomedBitmap = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(ZoomedBitmap))
            {
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(PictureBox_ObjectCanvas.Image, 0, 0, Width, Height);
            }

            PictureBox_ObjectCanvas.Image = ZoomedBitmap;
            PictureBox_ObjectCanvas.Height = (ObjectCanvasTileSize * (int)NumUpDown_ObjectCanvas_Height.Value) + 1;
            PictureBox_ObjectCanvas.Width = (ObjectCanvasTileSize * (int)NumUpDown_ObjectCanvas_Width.Value) + 1;

            if (DefaultCanvasSize.Height < PictureBox_ObjectCanvas.Image.Height)
                Panel_ObjectCanvas.Height = PictureBox_ObjectCanvas.Image.Height;
            else
                Panel_ObjectCanvas.Height = DefaultCanvasSize.Height;

            if (DefaultCanvasSize.Width < PictureBox_ObjectCanvas.Image.Width)
                Panel_ObjectCanvas.Width = PictureBox_ObjectCanvas.Image.Width;
            else
                Panel_ObjectCanvas.Width = DefaultCanvasSize.Width;

            PictureBox_ObjectCanvas.Left = (this.Panel_ObjectCanvas.Width - Width) / 2;
            PictureBox_ObjectCanvas.Top = (this.Panel_ObjectCanvas.Height - Height) / 2;
        }

        private void NumUpDown_ObjectCanvas_ValueChanged(object sender, EventArgs e)
        {
            if (CanvasDataUpdateFlag)
                return;

            int OldWidth = ObjectBeingEdited.Width;
            ObjectBeingEdited.Width = (int)NumUpDown_ObjectCanvas_Width.Value;

            if (OldWidth > ObjectBeingEdited.Width)
                foreach (List<int> Row in ObjectBeingEdited.Tiles)
                    Row.RemoveRange(ObjectBeingEdited.Width, OldWidth - ObjectBeingEdited.Width);
            else if (OldWidth < ObjectBeingEdited.Width)
                foreach (List<int> Row in ObjectBeingEdited.Tiles)
                    for (int i = 0; i < ObjectBeingEdited.Width - OldWidth; i++)
                        Row.Add(-1);

            int OldHeight = ObjectBeingEdited.Height;
            ObjectBeingEdited.Height = (int)NumUpDown_ObjectCanvas_Height.Value;

            if (OldHeight > ObjectBeingEdited.Height)
                ObjectBeingEdited.Tiles.RemoveRange(ObjectBeingEdited.Height, OldHeight - ObjectBeingEdited.Height);
            else if (OldHeight < ObjectBeingEdited.Height)
                for (int i = OldHeight; i < ObjectBeingEdited.Height; i++)
                {
                    ObjectBeingEdited.Tiles.Add(new List<int>());

                    for (int j = 0; j < ObjectBeingEdited.Width; j++)
                        ObjectBeingEdited.Tiles[i].Add(-1);
                }

            ObjectBeingEdited.RedrawPreview(Globals.EditedTileset);
            ObjectImages.Images[ObjectBeingEdited.ID] = new Bitmap(100, 50);
            ObjectImages.Images[ObjectBeingEdited.ID] = ObjectBeingEdited.PreviewBitmap;
            PictureBox_ObjectCanvas.Image = ObjectBeingEdited.PreviewBitmap;

            RedrawLargeZoomPreview();
            RedrawObjectCanvasForZoom();

            ListView_Objects.Invalidate(true);
            PictureBox_ObjectCanvas.Invalidate(true);
        }

        private void PictureBox_ObjectCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Gainsboro, 0, 0, PictureBox_ObjectCanvas.Width, PictureBox_ObjectCanvas.Height);

            for (int x = ObjectCanvasTileSize; x < PictureBox_ObjectCanvas.Width; x += ObjectCanvasTileSize)
                e.Graphics.DrawLine(Pens.Gainsboro, x, 0, x, PictureBox_ObjectCanvas.Height);
            for (int y = ObjectCanvasTileSize; y < PictureBox_ObjectCanvas.Height; y += ObjectCanvasTileSize)
                e.Graphics.DrawLine(Pens.Gainsboro, 0, y, PictureBox_ObjectCanvas.Width, y);

            if (ObjectCanvasMouseHovered)
            {
                Rectangle Position = Helpers.GetRectangleForPos(ObjectCanvasMouseHover.X, ObjectCanvasMouseHover.Y, PictureBox_ObjectCanvas.Width / ObjectCanvasTileSize, PictureBox_ObjectCanvas.Height / ObjectCanvasTileSize, ObjectCanvasTileSize);
                Brush TransculentBlue = new SolidBrush(Color.FromArgb(64, 0, 0, 255));
                e.Graphics.FillRectangle(TransculentBlue, Position);

                if (TilePickerSelected)
                {
                    int Width = (ObjectCanvasTileSize / 16) * SelectedTilePickerBitmapPreview.Width;
                    int Height = (ObjectCanvasTileSize / 16) * SelectedTilePickerBitmapPreview.Height;

                    e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    e.Graphics.DrawImage(SelectedTilePickerBitmapPreview, Position.X, Position.Y, Width, Height);
                }
            }
        }

        private void PictureBox_ObjectCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                ObjectCanvasMouseHover = e.Location;
                ObjectCanvasMouseHovered = true;
                PictureBox_ObjectCanvas.Invalidate(true);

                if (TilePickerSelected == false)
                {
                    Rectangle Position = Helpers.GetRectangleForPos(ObjectCanvasMouseHover.X, ObjectCanvasMouseHover.Y, PictureBox_ObjectCanvas.Width / ObjectCanvasTileSize, PictureBox_ObjectCanvas.Height / ObjectCanvasTileSize, ObjectCanvasTileSize);

                    int StartRow = Position.X / ObjectCanvasTileSize;
                    int StartColumn = Position.Y / ObjectCanvasTileSize;

                    TilePickedOnCanvas = ObjectBeingEdited.Tiles[StartColumn][StartRow];
                    PictureBox_TilePickerCanvas.Invalidate(true);
                }
            }
            catch (Exception)
            {

            }
        }

        private void PictureBox_ObjectCanvas_MouseLeave(object sender, EventArgs e)
        {
            ObjectCanvasMouseHovered = false;
            TilePickedOnCanvas = -1;
            PictureBox_TilePickerCanvas.Invalidate(true);
            PictureBox_ObjectCanvas.Invalidate(true);
        }

        private void PictureBox_ObjectCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (TilePickerSelected == false || SelectedTiles.Count == 0 || ObjectBeingEdited == null)
                return;

            try
            {
                if (ObjectBeingEdited.Tiles.Count == 0)
                {
                    ObjectBeingEdited.Tiles.Add(new List<int>() { -1 });
                    ObjectBeingEdited.Width = 1;
                    ObjectBeingEdited.Height = 1;

                    ObjectBeingEdited.RedrawPreview(Globals.EditedTileset);
                    ObjectImages.Images[ObjectBeingEdited.ID] = new Bitmap(100, 50);

                    ListView_Objects.Invalidate(true);
                    PictureBox_ObjectCanvas.Invalidate(true);
                    RedrawLargeZoomPreview();
                    RedrawObjectCanvasForZoom();
                }

                Rectangle Position = Helpers.GetRectangleForPos(ObjectCanvasMouseHover.X, ObjectCanvasMouseHover.Y, PictureBox_ObjectCanvas.Width / 16, PictureBox_ObjectCanvas.Height / 16);

                int StartRow = Position.X / ObjectCanvasTileSize;
                int StartColumn = Position.Y / ObjectCanvasTileSize;

                for (int i = 0; i < SelectedTiles.Count; i++)
                    for (int j = 0; j < SelectedTiles[i].Count; j++)
                    {
                        if ((StartColumn + i < ObjectBeingEdited.Height) && (StartRow + j < ObjectBeingEdited.Width))
                            ObjectBeingEdited.Tiles[StartColumn + i][StartRow + j] = SelectedTiles[i][j].Number;
                    }

                ObjectBeingEdited.RedrawPreview(Globals.EditedTileset);
                ObjectImages.Images[ObjectBeingEdited.ID] = new Bitmap(ObjectCanvasTileSize * ObjectBeingEdited.Width, ObjectCanvasTileSize * ObjectBeingEdited.Height);
                ObjectImages.Images[ObjectBeingEdited.ID] = ObjectBeingEdited.PreviewBitmap;
                PictureBox_ObjectCanvas.Image = ObjectBeingEdited.PreviewBitmap;

                ListView_Objects.Invalidate(true);
                PictureBox_ObjectCanvas.Invalidate(true);
                RedrawLargeZoomPreview();
                RedrawObjectCanvasForZoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }

        }

        private void Button_ClearSelectedObject_Click(object sender, EventArgs e)
        {
            CanvasDataUpdateFlag = true;
            NumUpDown_ObjectCanvas_Height.Value = 1;
            NumUpDown_ObjectCanvas_Width.Value = 1;
            PictureBox_ObjectCanvas.Height = 17;
            PictureBox_ObjectCanvas.Width = 17;
            CanvasDataUpdateFlag = false;

            ObjectBeingEdited.Name = "Object " + ObjectBeingEdited.ID;
            ObjectBeingEdited.Tiles = new List<List<int>>();
            ObjectBeingEdited.Width = 0;
            ObjectBeingEdited.Height = 0;

            ObjectBeingEdited.RedrawPreview(Globals.EditedTileset);
            ObjectImages.Images[ObjectBeingEdited.ID] = new Bitmap(100, 50);
            ListView_Objects.Items[ObjectBeingEdited.ID].Text = ObjectBeingEdited.Name;
            PictureBox_ObjectCanvas.Image = new Bitmap(16, 16);

            Bitmap ObjectBitmap = new Bitmap(100, 50);

            using (Graphics g = Graphics.FromImage(ObjectBitmap))
            {
                g.FillRectangle(new SolidBrush(Color.Red), 0, 0, 100, 50);
                g.DrawString(ObjectBeingEdited.ID.ToString(), new Font("Arial", 12.25F, FontStyle.Bold), new SolidBrush(Color.White), 0, 0);
            }

            ObjectImages.Images[ObjectBeingEdited.ID] = ObjectBitmap;

            ListView_Objects.Invalidate(true);
            PictureBox_ObjectCanvas.Invalidate(true);
            RedrawLargeZoomPreview();
        }

        #region Object Preview
        Point OldPosition = new Point(0, 0);
        Size OldSize = new Size(0, 0);

        private void Label_LargePreview_Preview_DoubleClick(object sender, EventArgs e)
        {
            OldPosition = Panel_LargePreviewWrapper.Location;
            OldSize = Panel_LargePreviewWrapper.Size;

            Form PreviewForm = new Form
            {
                Size = Panel_LargePreviewWrapper.Size,
                FormBorderStyle = FormBorderStyle.SizableToolWindow
            };

            PreviewForm.Controls.Add(Panel_LargePreviewWrapper);

            Panel_LargePreviewWrapper.Location = new Point(0, 0);
            Label_LargePreview_Zoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NumUpDown_Zoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_LargePreview_Preview.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Panel_LargePreviewWrapper.Dock = DockStyle.Fill;

            PreviewForm.FormClosed += PreviewForm_FormClosed;
            PreviewForm.Show();
        }

        private void PreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Panel_LargePreviewWrapper.Dock = DockStyle.None;

            this.Controls.Add(Panel_LargePreviewWrapper);
            Panel_LargePreviewWrapper.Location = OldPosition;
            Panel_LargePreviewWrapper.Size = OldSize;

            Panel_LargePreviewWrapper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Label_LargePreview_Zoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NumUpDown_Zoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Label_LargePreview_Preview.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        }
        #endregion

        #endregion

        #region Tile Picker 

        Point TilePickerMouseHover = new Point(0, 0);
        Point TilePickerSelectedCoordsStart = new Point(0, 0);
        Size TilePickerSelectedSize = new Size(16, 16);
        Bitmap SelectedTilePickerBitmapPreview = null;
        List<List<Tile>> SelectedTiles = new List<List<Tile>>();
        int TilePickedOnCanvas = -1;

        bool TilePickerMouseHovered = false;
        bool TilePickerSelected = false;
        bool TilePickerMouseDown = false;

        bool IsCopying = false;
        bool IsPasting = false;
        bool IsClearing = false;
        bool IsXFlipping = false;
        bool IsYFlipping = false;
        bool SuppressMouseDown = false;

        private void Button_EditTilemap_Click(object sender, EventArgs e)
        {
            Button_ClearSelectedObject.Enabled = false;
            Panel_Buttons.Visible = false;
            Panel_EditTilemapButtons.Visible = true;
            Panel_ObjectCanvasWrapper.Enabled = false;
            Panel_ObjectPicker.Enabled = false;
            Panel_CollisionEditor.Enabled = false;

            PictureBox_TilePicker_SuperClickAway(this, null);

            Button_Copy_Click(this, null);
            Mode = 1;
        }

        private void Button_EditFormats_Click(object sender, EventArgs e)
        {
            Button_ClearSelectedObject.Enabled = false;
            Panel_Buttons.Visible = false;
            Panel_EditFormats.Visible = true;
            Panel_ObjectCanvasWrapper.Enabled = false;
            Panel_ObjectPicker.Enabled = false;
            Panel_CollisionEditor.Enabled = false;
            DrawFormatsFromTileset(Globals.EditedTileset);
            ShowFormats = true;

            PictureBox_TilePicker_SuperClickAway(this, null);

            PictureBox_TilePickerCanvas.Invalidate(true);
            Mode = 2;
        }

        private void Button_EditRandomization_Click(object sender, EventArgs e)
        {
            Button_ClearSelectedObject.Enabled = false;
            DrawRandomizationFromTileset(Globals.EditedTileset);
            Panel_Buttons.Visible = false;
            Panel_Randomization.Visible = true;
            Panel_ObjectCanvasWrapper.Enabled = false;
            Panel_ObjectPicker.Enabled = false;
            Panel_CollisionEditor.Enabled = false;
            ShowRandomization = true;

            PictureBox_TilePicker_SuperClickAway(this, null);

            PictureBox_TilePickerCanvas.Invalidate(true);
            Mode = 3;

            ComboBox_RandomizationGroups.SelectedIndex = 0;
        }

        private void PictureBox_TilePickerCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            TilePickerMouseHover = e.Location;
            TilePickerMouseHovered = true;

            if (TilePickerMouseDown && !TilePickerSelected)
            {
                Point TilePickerCoordsEnd = Helpers.GetEndCoordsForPos(TilePickerMouseHover.X,
                                                       TilePickerMouseHover.Y,
                                                       PictureBox_TilePickerCanvas.Width / 16,
                                                       PictureBox_TilePickerCanvas.Height / 16);

                if (TilePickerCoordsEnd.X < TilePickerSelectedCoordsStart.X + 16)
                    TilePickerCoordsEnd.X = TilePickerSelectedCoordsStart.X + 16;

                if (TilePickerCoordsEnd.Y < TilePickerSelectedCoordsStart.Y + 16)
                    TilePickerCoordsEnd.Y = TilePickerSelectedCoordsStart.Y + 16;

                TilePickerSelectedSize = new Size((TilePickerCoordsEnd.X - TilePickerSelectedCoordsStart.X),
                                                  (TilePickerCoordsEnd.Y - TilePickerSelectedCoordsStart.Y));
            }

            PictureBox_TilePickerCanvas.Invalidate(true);
        }

        private void PictureBox_TilePickerCanvas_MouseLeave(object sender, EventArgs e)
        {
            TilePickerMouseHovered = false;
            PictureBox_TilePickerCanvas.Invalidate(true);
        }

        private void PictureBox_TilePickerCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox_TilePicker_ClickAway(this, null);

                return;
            }

            if (!IsPasting)
            {
                SelectedTiles.Clear();

                for (int i = 0; i < TilePickerSelectedSize.Height; i += 16)
                {
                    List<Tile> Row = new List<Tile>();
                    SelectedTiles.Add(Row);

                    for (int j = 0; j < TilePickerSelectedSize.Width; j += 16)
                    {
                        int TileID = Helpers.GetTileIDForPos(TilePickerSelectedCoordsStart.X + j, TilePickerSelectedCoordsStart.Y + i);

                        if (TileID <= 764)
                            Row.Add(Globals.EditedTileset.Tiles[TileID].Clone());
                    }
                }
            }

            switch (Mode)
            {
                #region Object Canvas Mode
                case 0:
                    {
                        if (TilePickerMouseDown)
                        {
                            SelectedTilePickerBitmapPreview = new Bitmap(TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);

                            using (Graphics g = Graphics.FromImage(SelectedTilePickerBitmapPreview))
                            {
                                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                                ColorMatrix Matrix = new ColorMatrix { Matrix33 = 0.5F };
                                ImageAttributes Attributes = new ImageAttributes();
                                Attributes.SetColorMatrix(Matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                                g.DrawImage(TilesetWorkBitmap,
                                            new Rectangle(0, 0, SelectedTilePickerBitmapPreview.Width, SelectedTilePickerBitmapPreview.Height),
                                            TilePickerSelectedCoordsStart.X,
                                            TilePickerSelectedCoordsStart.Y,
                                            TilePickerSelectedSize.Width,
                                            TilePickerSelectedSize.Height, GraphicsUnit.Pixel, Attributes);
                            }

                            RawTileCollisionDataEditor.SetTilesTo(SelectedTiles);
                            SetCollisionEditorData();

                            Panel_CollisionEditor.Enabled = true;
                            TilePickerSelected = true;

                            if (AdjustCanvas)
                            {
                                int NewHeight = TilePickerSelectedSize.Height / 16;
                                int NewWidth = TilePickerSelectedSize.Width / 16;

                                if (NewHeight > NumUpDown_ObjectCanvas_Height.Maximum)
                                    NewHeight = (int)NumUpDown_ObjectCanvas_Height.Maximum;

                                if (NewWidth > NumUpDown_ObjectCanvas_Width.Maximum)
                                    NewWidth = (int)NumUpDown_ObjectCanvas_Width.Maximum;

                                if (NumUpDown_ObjectCanvas_Height.Value < NewHeight)
                                    NumUpDown_ObjectCanvas_Height.Value = NewHeight;

                                if (NumUpDown_ObjectCanvas_Width.Value < NewWidth)
                                    NumUpDown_ObjectCanvas_Width.Value = NewWidth;
                            }

                            PictureBox_TilePickerCanvas.Invalidate(true);
                        }
                        break;
                    }
                #endregion

                #region Tilemap Edit Mode
                case 1:
                    {
                        #region CopyPaste
                        if (IsCopying && !IsPasting)  // Copy
                        {
                            SelectedTilePickerBitmapPreview = new Bitmap(TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);

                            using (Graphics g = Graphics.FromImage(SelectedTilePickerBitmapPreview))
                            {
                                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                                ColorMatrix Matrix = new ColorMatrix { Matrix33 = 0.75F };
                                ImageAttributes Attributes = new ImageAttributes();
                                Attributes.SetColorMatrix(Matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                                g.DrawImage(TilesetWorkBitmap,
                                            new Rectangle(0, 0, SelectedTilePickerBitmapPreview.Width, SelectedTilePickerBitmapPreview.Height),
                                            TilePickerSelectedCoordsStart.X,
                                            TilePickerSelectedCoordsStart.Y,
                                            TilePickerSelectedSize.Width,
                                            TilePickerSelectedSize.Height,
                                            GraphicsUnit.Pixel,
                                            Attributes);

                            }

                            IsPasting = true;
                            TilePickerMouseDown = true;
                            TilePickerSelected = true;
                            SuppressMouseDown = true;
                            PictureBox_TilePickerCanvas.Invalidate(true);
                        }
                        else if (IsCopying && IsPasting)  //Paste
                        {
                            Rectangle HoverRectangle = Helpers.GetRectangleForPos(TilePickerMouseHover.X,
                                                       TilePickerMouseHover.Y,
                                                       PictureBox_TilePickerCanvas.Width / 16,
                                                       PictureBox_TilePickerCanvas.Height / 16);

                            using (Graphics g = Graphics.FromImage(TilesetWorkBitmap))
                            {
                                ColorMatrix Matrix = new ColorMatrix { Matrix33 = 2F };
                                ImageAttributes Attributes = new ImageAttributes();
                                Attributes.SetColorMatrix(Matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                                Rectangle DestRect = new Rectangle(HoverRectangle.X, HoverRectangle.Y, TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);
                                Brush Brush = new SolidBrush(PictureBox_TilePickerCanvas.BackColor);
                                g.FillRectangle(Brush, DestRect);
                                g.DrawImage(SelectedTilePickerBitmapPreview,
                                            DestRect,
                                            0,
                                            0,
                                            TilePickerSelectedSize.Width,
                                            TilePickerSelectedSize.Height,
                                            GraphicsUnit.Pixel,
                                            Attributes);

                            }


                            for (int i = 0; i < TilePickerSelectedSize.Height; i += 16)
                            {
                                for (int j = 0; j < TilePickerSelectedSize.Width; j += 16)
                                {
                                    int TileNumber = Helpers.GetTileIDForPos(HoverRectangle.X + j, HoverRectangle.Y + i);

                                    if (TileNumber == -1)
                                        continue;

                                    Globals.EditedTileset.Tiles[TileNumber] = SelectedTiles[i / 16][j / 16];
                                    Globals.EditedTileset.Tiles[TileNumber].Number = TileNumber;
                                }
                            }

                            IsPasting = false;
                            SuppressMouseDown = false;
                            PictureBox_TilePicker_ClickAway(this, null);
                        }
                        #endregion

                        #region Flipping
                        else if (IsXFlipping | IsYFlipping)
                        {
                            if (TilePickerMouseDown)
                            {
                                Bitmap ToFlip = new Bitmap(TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);
                                Rectangle SrcRect = new Rectangle(0, 0, TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);
                                Rectangle DestRect = new Rectangle(TilePickerSelectedCoordsStart.X, TilePickerSelectedCoordsStart.Y, TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);

                                using (Graphics g = Graphics.FromImage(ToFlip))
                                {
                                    g.DrawImage(TilesetWorkBitmap,
                                                SrcRect,
                                                DestRect,
                                                GraphicsUnit.Pixel);

                                }

                                if (IsXFlipping)
                                {
                                    ToFlip.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                    foreach (List<Tile> Row in SelectedTiles)
                                        Row.Reverse();
                                }

                                if (IsYFlipping)
                                {
                                    ToFlip.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    SelectedTiles.Reverse();
                                }

                                using (Graphics g = Graphics.FromImage(TilesetWorkBitmap))
                                {
                                    Brush Brush = new SolidBrush(PictureBox_TilePickerCanvas.BackColor);
                                    g.FillRectangle(Brush, DestRect);
                                    g.DrawImage(ToFlip,
                                                DestRect,
                                                new Rectangle(0, 0, TilePickerSelectedSize.Width, TilePickerSelectedSize.Height),
                                                GraphicsUnit.Pixel);

                                }

                                for (int i = 0; i < TilePickerSelectedSize.Height; i += 16)
                                {
                                    for (int j = 0; j < TilePickerSelectedSize.Width; j += 16)
                                    {
                                        int TileID = Helpers.GetTileIDForPos(TilePickerSelectedCoordsStart.X + j, TilePickerSelectedCoordsStart.Y + i);
                                        Globals.EditedTileset.Tiles[TileID].ID = SelectedTiles[i / 16][j / 16].ID;
                                        Globals.EditedTileset.Tiles[TileID].TileBitmap = (Bitmap)SelectedTiles[i / 16][j / 16].TileBitmap.Clone();

                                        if (IsXFlipping)
                                        {
                                            Globals.EditedTileset.Tiles[TileID].FlipX = !Globals.EditedTileset.Tiles[TileID].FlipX;
                                            Globals.EditedTileset.Tiles[TileID].TileBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                        }

                                        if (IsYFlipping)
                                        {
                                            Globals.EditedTileset.Tiles[TileID].FlipY = !Globals.EditedTileset.Tiles[TileID].FlipY;
                                            Globals.EditedTileset.Tiles[TileID].TileBitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                        }
                                    }
                                }

                                TilePickerSelectedSize = new Size(16, 16);
                                TilePickerMouseDown = false;
                                TilePickerSelected = false;
                            }
                        }
                        #endregion

                        #region Clearing
                        else if (IsClearing)
                        {
                            if (TilePickerMouseDown)
                            {
                                Bitmap Clean = new Bitmap(TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);
                                Rectangle DestRect = new Rectangle(TilePickerSelectedCoordsStart.X, TilePickerSelectedCoordsStart.Y, TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);
                                Rectangle SrcRect = new Rectangle(0, 0, TilePickerSelectedSize.Width, TilePickerSelectedSize.Height);

                                using (Graphics g = Graphics.FromImage(Clean))
                                {
                                    g.DrawImage(Globals.EditedTileset.MainPNG,
                                                SrcRect,
                                                DestRect,
                                                GraphicsUnit.Pixel);

                                }

                                using (Graphics g = Graphics.FromImage(TilesetWorkBitmap))
                                {
                                    Brush Brush = new SolidBrush(PictureBox_TilePickerCanvas.BackColor);
                                    g.FillRectangle(Brush, DestRect);
                                    g.DrawImage(Clean,
                                                DestRect,
                                                SrcRect,
                                                GraphicsUnit.Pixel);

                                }

                                for (int i = 0; i < TilePickerSelectedSize.Height; i += 16)
                                {
                                    for (int j = 0; j < TilePickerSelectedSize.Width; j += 16)
                                    {
                                        int TileID = Helpers.GetTileIDForPos(TilePickerSelectedCoordsStart.X + j, TilePickerSelectedCoordsStart.Y + i);
                                        Globals.EditedTileset.Tiles[TileID].FlipX = false;
                                        Globals.EditedTileset.Tiles[TileID].FlipY = false;
                                        Globals.EditedTileset.Tiles[TileID].ID = TileID;
                                        Globals.EditedTileset.Tiles[TileID].TileBitmap = new Bitmap(16, 16);

                                        Rectangle CleanTileBitmapRect = Helpers.GetRectangleForTileID(TileID);

                                        using (Graphics g = Graphics.FromImage(Globals.EditedTileset.Tiles[TileID].TileBitmap))
                                        {
                                            g.DrawImage(Globals.EditedTileset.MainPNG,
                                                        new Rectangle(0, 0, 16, 16),
                                                        CleanTileBitmapRect,
                                                        GraphicsUnit.Pixel);

                                        }
                                    }
                                }
                            }

                            TilePickerSelectedSize = new Size(16, 16);
                            TilePickerMouseDown = false;
                            TilePickerSelected = false;
                        }
                        #endregion

                        DrawChangesFromTileset(Globals.EditedTileset);
                        break;
                    }
                #endregion

                #region Format Edit
                case 2:
                    {
                        if (TilePickerMouseDown)
                        {
                            for (int i = 0; i < TilePickerSelectedSize.Height; i += 16)
                            {
                                for (int j = 0; j < TilePickerSelectedSize.Width; j += 16)
                                {
                                    int TileID = Helpers.GetTileIDForPos(TilePickerSelectedCoordsStart.X + j, TilePickerSelectedCoordsStart.Y + i);
                                    Globals.EditedTileset.TextureFormats[TileID] = Convert.ToInt32(ComboBox_FormatTypes.Text.Substring(0, 1));
                                }
                            }

                            DrawFormatsFromTileset(Globals.EditedTileset);
                            TilePickerSelectedSize = new Size(16, 16);
                            TilePickerMouseDown = false;
                            TilePickerSelected = false;
                            PictureBox_TilePickerCanvas.Invalidate(true);
                        }
                        break;
                    }
                #endregion

                #region Randomization Edit
                case 3:
                    {
                        if (TilePickerMouseDown)
                        {
                            if (ComboBox_RandomizationGroups.Text == "")
                            {
                                TilePickerSelectedSize = new Size(16, 16);
                                TilePickerMouseDown = false;
                                TilePickerSelected = false;
                                PictureBox_TilePickerCanvas.Invalidate(true);
                                return;
                            }

                            for (int i = 0; i < TilePickerSelectedSize.Height; i += 16)
                            {
                                for (int j = 0; j < TilePickerSelectedSize.Width; j += 16)
                                {
                                    int TileID = Helpers.GetTileIDForPos(TilePickerSelectedCoordsStart.X + j, TilePickerSelectedCoordsStart.Y + i);

                                    foreach (List<int> RandoGroup in Globals.EditedTileset.RandomizationGroups)
                                        foreach (int Tile in RandoGroup)
                                        {
                                            if (Tile == TileID)
                                            {
                                                RandoGroup.Remove(Tile);
                                                break;
                                            }
                                        }

                                    if (ComboBox_RandomizationGroups.Text != "None")
                                        Globals.EditedTileset.RandomizationGroups[Convert.ToInt32(ComboBox_RandomizationGroups.Text) - 1].Add(TileID);
                                }
                            }

                            DrawRandomizationFromTileset(Globals.EditedTileset);
                            TilePickerSelectedSize = new Size(16, 16);
                            TilePickerMouseDown = false;
                            TilePickerSelected = false;
                            PictureBox_TilePickerCanvas.Invalidate(true);
                        }
                        break;
                    }
                    #endregion
            }
        }

        private void PictureBox_TilePickerCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (ShowChanges)
                e.Graphics.DrawImage(TilesetChangesBitmap, new Rectangle(0, 0, TilesetWorkBitmap.Width, TilesetWorkBitmap.Height));

            if (ShowFormats)
                e.Graphics.DrawImage(TilesetFormatsBitmap, new Rectangle(0, 0, TilesetWorkBitmap.Width, TilesetWorkBitmap.Height));

            if (ShowRandomization)
                e.Graphics.DrawImage(TilesetRandomizationBitmap, new Rectangle(0, 0, TilesetWorkBitmap.Width, TilesetWorkBitmap.Height));

            Brush TransculentBlue = new SolidBrush(Color.FromArgb(127, 0, 0, 255));
            Brush TransculentCyan = new SolidBrush(Color.FromArgb(127, 0, 255, 255));
            Brush TransculentRed = new SolidBrush(Color.FromArgb(127, 255, 0, 0));

            if (TilePickedOnCanvas != -1)
            {
                Rectangle HoverRectangle = Helpers.GetRectangleForTileID(TilePickedOnCanvas);
                e.Graphics.FillRectangle(TransculentCyan, HoverRectangle);
            }

            if (TilePickerMouseHovered && !TilePickerMouseDown && !IsPasting)
            {
                Rectangle HoverRectangle = Helpers.GetRectangleForPos(TilePickerMouseHover.X,
                                                                      TilePickerMouseHover.Y,
                                                                      PictureBox_TilePickerCanvas.Width / 16,
                                                                      PictureBox_TilePickerCanvas.Height / 16);


                e.Graphics.FillRectangle(TransculentBlue, HoverRectangle);
            }
            else if (TilePickerMouseDown && !IsPasting)
            {
                Rectangle HoverRectangle = Helpers.GetRectangleForPos(TilePickerSelectedCoordsStart.X,
                                                                      TilePickerSelectedCoordsStart.Y,
                                                                      PictureBox_TilePickerCanvas.Width / 16,
                                                                      PictureBox_TilePickerCanvas.Height / 16);

                HoverRectangle.Width = TilePickerSelectedSize.Width;
                HoverRectangle.Height = TilePickerSelectedSize.Height;



                e.Graphics.FillRectangle(TransculentBlue, HoverRectangle);
            }
            else if (IsPasting)
            {
                Rectangle HoverRectangle = Helpers.GetRectangleForPos(TilePickerMouseHover.X,
                                                                      TilePickerMouseHover.Y,
                                                                      PictureBox_TilePickerCanvas.Width / 16,
                                                                      PictureBox_TilePickerCanvas.Height / 16);

                HoverRectangle.Width = TilePickerSelectedSize.Width;
                HoverRectangle.Height = TilePickerSelectedSize.Height;

                e.Graphics.DrawImage(SelectedTilePickerBitmapPreview, new Point(HoverRectangle.X, HoverRectangle.Y));
                e.Graphics.FillRectangle(TransculentRed, HoverRectangle);
            }
        }

        private void PictureBox_TilePickerCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (SuppressMouseDown)
                return;

            if (e.Button == MouseButtons.Right)
            {
                PictureBox_TilePicker_SuperClickAway(this, null);
                return;
            }

            if (TilePickerSelected)
            {
                PictureBox_TilePicker_ClickAway(this, null);
            }

            TilePickerMouseDown = true;
            TilePickerSelectedCoordsStart = Helpers.GetStartCoordsForPos(e.X,
                                                                         e.Y,
                                                                         PictureBox_TilePickerCanvas.Width / 16,
                                                                         PictureBox_TilePickerCanvas.Height / 16);

            PictureBox_TilePickerCanvas.Invalidate(true);

        }

        private void PictureBox_TilePicker_ClickAway(object sender, EventArgs e)
        {
            TilePickerSelectedSize = new Size(16, 16);
            TilePickerMouseDown = false;
            TilePickerSelected = false;
            TilePickerSelectedSize = new Size(16, 16);
            TilePickerSelectedCoordsStart = new Point(0, 0);
            IsPasting = false;
            SuppressMouseDown = false;

            SelectedTiles = new List<List<Tile>>();
            SelectedTilePickerBitmapPreview = new Bitmap(16, 16);
            PictureBox_TilePickerCanvas.Invalidate(true);
        }

        private void PictureBox_TilePicker_SuperClickAway(object sender, EventArgs e)
        {
            TilePickerSelectedSize = new Size(16, 16);
            TilePickerMouseDown = false;
            TilePickerSelected = false;
            TilePickerSelectedSize = new Size(16, 16);
            TilePickerSelectedCoordsStart = new Point(0, 0);
            IsPasting = false;
            SuppressMouseDown = false;

            SelectedTiles = new List<List<Tile>>();
            SelectedTilePickerBitmapPreview = new Bitmap(16, 16);
            PictureBox_TilePickerCanvas.Invalidate(true);

            Panel_CollisionEditor.Enabled = false;
            RawTileCollisionDataEditor.SetTilesTo(new List<List<Tile>>());
            SetCollisionEditorData();
        }

        #endregion

        #region Edit Tile Map Mode Buttons

        private void Button_Back_Click(object sender, EventArgs e)
        {
            PictureBox_TilePicker_ClickAway(this, null);

            Panel_Buttons.Visible = true;
            Panel_EditTilemapButtons.Visible = false;
            Panel_ObjectCanvasWrapper.Enabled = true;
            Panel_ObjectPicker.Enabled = true;
            Panel_CollisionEditor.Enabled = true;
            Button_ClearSelectedObject.Enabled = true;

            IsCopying = false;
            IsXFlipping = false;
            IsYFlipping = false;
            IsClearing = false;
            Button_Copy.FlatStyle = FlatStyle.Standard;
            Button_XFlip.FlatStyle = FlatStyle.Standard;
            Button_YFlip.FlatStyle = FlatStyle.Standard;
            Button_Clear.FlatStyle = FlatStyle.Standard;

            PictureBox_TilePicker_SuperClickAway(this, null);

            foreach (Newt.ObjectClasses.Object o in Globals.EditedTileset.Objects)
                o.RedrawPreview(Globals.EditedTileset);

            DrawObjectsFromTileset(Globals.EditedTileset);

            Mode = 0;
        }

        private void Button_Copy_Click(object sender, EventArgs e)
        {
            PictureBox_TilePicker_ClickAway(this, null);

            IsClearing = false;
            IsCopying = false;
            IsYFlipping = false;
            IsPasting = false;
            Button_Clear.FlatStyle = FlatStyle.Standard;
            Button_XFlip.FlatStyle = FlatStyle.Standard;
            Button_YFlip.FlatStyle = FlatStyle.Standard;

            Button_Copy.FlatStyle = FlatStyle.Popup;
            IsCopying = true;
        }

        private void Button_XFlip_Click(object sender, EventArgs e)
        {
            PictureBox_TilePicker_ClickAway(this, null);

            IsClearing = false;
            IsCopying = false;
            IsYFlipping = false;
            IsPasting = false;
            Button_Clear.FlatStyle = FlatStyle.Standard;
            Button_Copy.FlatStyle = FlatStyle.Standard;
            Button_YFlip.FlatStyle = FlatStyle.Standard;

            Button_XFlip.FlatStyle = FlatStyle.Popup;
            IsXFlipping = true;
        }

        private void Button_YFlip_Click(object sender, EventArgs e)
        {
            PictureBox_TilePicker_ClickAway(this, null);

            IsClearing = false;
            IsCopying = false;
            IsXFlipping = false;
            IsPasting = false;
            Button_Clear.FlatStyle = FlatStyle.Standard;
            Button_Copy.FlatStyle = FlatStyle.Standard;
            Button_XFlip.FlatStyle = FlatStyle.Standard;

            Button_YFlip.FlatStyle = FlatStyle.Popup;
            IsYFlipping = true;
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            PictureBox_TilePicker_ClickAway(this, null);

            IsYFlipping = false;
            IsCopying = false;
            IsXFlipping = false;
            IsPasting = false;
            Button_XFlip.FlatStyle = FlatStyle.Standard;
            Button_Copy.FlatStyle = FlatStyle.Standard;
            Button_YFlip.FlatStyle = FlatStyle.Standard;

            Button_Clear.FlatStyle = FlatStyle.Popup;
            IsClearing = true;
        }

        #endregion

        #region Edit Formats Mode Buttons

        private void Button_Formats_Back_Click(object sender, EventArgs e)
        {
            Button_ClearSelectedObject.Enabled = true;
            Panel_Buttons.Visible = true;
            Panel_EditTilemapButtons.Visible = false;
            Panel_ObjectCanvasWrapper.Enabled = true;
            Panel_ObjectPicker.Enabled = true;
            Panel_CollisionEditor.Enabled = true;
            Panel_EditFormats.Visible = false;
            ShowFormats = false;

            PictureBox_TilePicker_SuperClickAway(this, null);

            PictureBox_TilePickerCanvas.Invalidate(true);
            Mode = 0;
        }

        #endregion

        #region Randomization Buttons
        private void Button_Randomization_Back_Click(object sender, EventArgs e)
        {
            Button_ClearSelectedObject.Enabled = true;
            Panel_Buttons.Visible = true;
            Panel_EditTilemapButtons.Visible = false;
            Panel_ObjectCanvasWrapper.Enabled = true;
            Panel_ObjectPicker.Enabled = true;
            Panel_CollisionEditor.Enabled = true;
            Panel_Randomization.Visible = false;
            ShowRandomization = false;
            PictureBox_TilePicker_SuperClickAway(this, null);

            PictureBox_TilePickerCanvas.Invalidate(true);
            Mode = 0;
        }

        private void Button_AddRandoGroup_Click(object sender, EventArgs e)
        {
            int Value = 1;

            if (ComboBox_RandomizationGroups.Items.Count != 0)
                Value = (int)ComboBox_RandomizationGroups.Items[ComboBox_RandomizationGroups.Items.Count - 1];

            ComboBox_RandomizationGroups.Items.Add(Value + 1);
            Globals.EditedTileset.RandomizationGroups.Add(new List<int>());

            ComboBox_RandomizationGroups.SelectedIndex = Value;
        }

        private void Button_RemoveRandoGroup_Click(object sender, EventArgs e)
        {
            if (ComboBox_RandomizationGroups.Text == "None")
                return;

            int Value = Convert.ToInt32(ComboBox_RandomizationGroups.Text);
            Globals.EditedTileset.RandomizationGroups.RemoveAt(Value - 1);

            ComboBox_RandomizationGroups.Items.Clear();
            ComboBox_RandomizationGroups.Items.Add("None");
            for (int i = 0; i < Globals.EditedTileset.RandomizationGroups.Count; i++)
                ComboBox_RandomizationGroups.Items.Add(i + 1);

            ComboBox_RandomizationGroups.SelectedIndex = ComboBox_RandomizationGroups.Items.Count - 1;

            DrawRandomizationFromTileset(Globals.EditedTileset);
            PictureBox_TilePickerCanvas.Invalidate(true);
        }
        #endregion

        #region CollisionEditor

        uint CurrentFlags;
        int CurrentSubType;
        int CurrentParam;
        Globals.ParamTypes CurrentParamType = Globals.ParamTypes.DummyUnsetParams;
        int DataUpdateFlag = 0;

        private void Panel_CollisionEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                PictureBox_TilePicker_SuperClickAway(this, e);
        }

        private void SetCollisionEditorData()
        {
            UInt32 Data = BitConverter.ToUInt32(RawTileCollisionDataEditor.Data, 0);

            CurrentFlags = ((Data & 0xFFFF0000) >> 16) | ((Data & 0xF00) << 8);
            CurrentSubType = (int)(Data & 0xF000) >> 12;
            CurrentParam = (int)Data & 0xFF;

            DataUpdateFlag++;

            for (int i = 0; i < 20; i++)
            {
                ListBox_CollisionFlags.SetItemChecked(i, (CurrentFlags & (1 << i)) != 0);
            }

            ComboBox_CollisionSubTypes.SelectedIndex = CurrentSubType;
            UpdateParamTypeAndData();

            DataUpdateFlag--;
        }

        private void PopulateListBox(ListBox ListBox, int MaxID, string[] List)
        {
            ListBox.BeginUpdate();
            ListBox.Items.Clear();

            for (int i = 0; i < MaxID; i++)
                ListBox.Items.Add(string.Format("Unknown", i));

            foreach (string Item in List)
            {
                int Where = Item.IndexOf('=');

                int ID;
                if (Item.StartsWith("0x"))
                    ID = int.Parse(Item.Substring(2, Where - 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                else
                    ID = int.Parse(Item.Substring(0, Where));

                string Text = Item.Substring(Where + 1);

                ListBox.Items[ID] = Text;
            }

            ListBox.EndUpdate();
        }

        private void UpdateParamTypeAndData()
        {
            List<Globals.ParamTypes> ParamTypes = EffectiveParamTypes(CurrentFlags, CurrentSubType);
            UseParamType(ParamTypes[0]);

            RefreshParamData();

            if (ParamTypes.Count == 1)
            {
                string TypeName = GetNameForParamType(ParamTypes[0]);
                Label_CollisionEditor_Parameters.Text = string.Format("Params: ({0})", TypeName);

            }
            else
            {
                string[] TypeNames = new string[ParamTypes.Count];

                for (int i = 0; i < ParamTypes.Count; i++)
                    TypeNames[i] = GetNameForParamType(ParamTypes[i]);

                Label_CollisionEditor_Parameters.Text = string.Format("Conflict: ({0})", string.Join(", ", TypeNames));
            }
        }

        private void UseParamType(Globals.ParamTypes Type)
        {
            if (Type != CurrentParamType)
            {
                DataUpdateFlag++;
                CurrentParamType = Type;

                ListBox_NormalTileParams.Visible = false;
                PipeDoorParamsPanel.Visible = false;
                PartialBlockParamsPanel.Visible = false;

                if (Type == Globals.ParamTypes.PipeDoorParams)
                    PipeDoorParamsPanel.Visible = true;
                else if (Type == Globals.ParamTypes.PartialBlockParams)
                    PartialBlockParamsPanel.Visible = true;
                else
                {
                    ListBox_NormalTileParams.Visible = true;
                    PopulateListBox(ListBox_NormalTileParams, 0x100, GetListForParamType(Type));
                }

                DataUpdateFlag--;

            }
        }

        private void RefreshParamData()
        {
            DataUpdateFlag++;

            if (CurrentParamType == Globals.ParamTypes.PipeDoorParams)
            {
                ComboBox_PipeDoorType.SelectedIndex = CurrentParam >> 5;
                ListBox_PipeDoorParams.SelectedIndex = CurrentParam & 0x1F;

            }
            else if (CurrentParamType == Globals.ParamTypes.PartialBlockParams)
            {
                CheckBox_PartialBlock_TopLeft.Checked = ((CurrentParam & 1) != 0);
                CheckBox_PartialBlock_TopRight.Checked = ((CurrentParam & 2) != 0);
                CheckBox_PartialBlock_BottomLeft.Checked = ((CurrentParam & 4) != 0);
                CheckBox_PartialBlock_BottomRight.Checked = ((CurrentParam & 8) != 0);

            }
            else
            {
                ListBox_NormalTileParams.SelectedIndex = CurrentParam;
            }

            DataUpdateFlag--;
        }

        private string[] GetListForParamType(Globals.ParamTypes Type)
        {
            switch (Type)
            {
                case Globals.ParamTypes.GenericTileParams: return Globals.GenericTileParams;
                case Globals.ParamTypes.CoinParams: return Globals.CoinParams;
                case Globals.ParamTypes.QuestionBlockParams: return Globals.QuestionBlockParams;
                case Globals.ParamTypes.BrickBlockParams: return Globals.BrickBlockParams;
                case Globals.ParamTypes.ExplodableBlockParams: return Globals.ExplodableBlockParams;
                case Globals.ParamTypes.HarmfulTileParams: return Globals.HarmfulTileParams;
                case Globals.ParamTypes.ConveyorParams: return Globals.ConveyorParams;
                case Globals.ParamTypes.DonutLiftParams: return Globals.DonutLiftParams;
                case Globals.ParamTypes.FenceParams: return Globals.FenceParams;
                case Globals.ParamTypes.SlopeParams: return Globals.SlopeParams;
                case Globals.ParamTypes.PipeDoorParams: return Globals.PipeDoorParams;
            }

            return new string[0];
        }

        private string GetNameForParamType(Globals.ParamTypes Type)
        {
            switch (Type)
            {
                case Globals.ParamTypes.GenericTileParams: return "Generic Tile";
                case Globals.ParamTypes.CoinParams: return "Coin";
                case Globals.ParamTypes.QuestionBlockParams: return "Question Block";
                case Globals.ParamTypes.BrickBlockParams: return "Brick Block";
                case Globals.ParamTypes.ExplodableBlockParams: return "Explodable";
                case Globals.ParamTypes.HarmfulTileParams: return "Harmful";
                case Globals.ParamTypes.ConveyorParams: return "Conveyor Belt";
                case Globals.ParamTypes.DonutLiftParams: return "Donut Lift";
                case Globals.ParamTypes.FenceParams: return "Climbable";
                case Globals.ParamTypes.SlopeParams: return "Slope";
                case Globals.ParamTypes.PipeDoorParams: return "Entrance";
                case Globals.ParamTypes.PartialBlockParams: return "Partial Block";
            }

            return "";
        }

        private void UpdateHexEditor()
        {
            RawTileCollisionDataEditor.SetArrayTo(BitConverter.GetBytes(((CurrentFlags & 0xFFFF) << 16) |
                                                                       ((CurrentFlags & 0xF0000) >> 8) |
                                                                        (uint)(CurrentSubType << 12) |
                                                                        (uint)CurrentParam));
        }

        private Globals.ParamTypes EffectiveParamType(uint Flag, int SubType)
        {
            List<Globals.ParamTypes> Types = EffectiveParamTypes(Flag, SubType);
            return Types[0];
        }

        private List<Globals.ParamTypes> EffectiveParamTypes(uint Flag, int SubType)
        {
            List<Globals.ParamTypes> Output = new List<Globals.ParamTypes>();

            if ((Flag & 2) != 0)
                Output.Add(Globals.ParamTypes.CoinParams);
            if ((Flag & 4) != 0)
                Output.Add(Globals.ParamTypes.QuestionBlockParams);
            if ((Flag & 8) != 0)
                Output.Add(Globals.ParamTypes.ExplodableBlockParams);
            if ((Flag & 0x10) != 0)
                Output.Add(Globals.ParamTypes.BrickBlockParams);
            if ((Flag & (0x20 | 0x40)) != 0)
                Output.Add(Globals.ParamTypes.SlopeParams);
            if ((Flag & 0x100) != 0)
                Output.Add(Globals.ParamTypes.PipeDoorParams);
            if ((Flag & 0x400) != 0)
                Output.Add(Globals.ParamTypes.FenceParams);
            if ((Flag & 0x800) != 0)
                Output.Add(Globals.ParamTypes.PartialBlockParams);
            if ((Flag & 0x1000) != 0)
                Output.Add(Globals.ParamTypes.HarmfulTileParams);
            if ((Flag & 0x20000) != 0)
                Output.Add(Globals.ParamTypes.DonutLiftParams);

            if (SubType == 4 || SubType == 5)
                Output.Add(Globals.ParamTypes.ConveyorParams);

            if (Output.Count == 0)
                Output.Add(Globals.ParamTypes.GenericTileParams);

            return Output;
        }

        private void ListBox_CollisionFlags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (DataUpdateFlag > 0)
                return;

            uint Mask = 1U << e.Index;

            if (e.NewValue == CheckState.Checked)
                CurrentFlags |= Mask;
            else
                CurrentFlags &= ~Mask;

            UpdateParamTypeAndData();
            UpdateHexEditor();
        }

        private void ComboBox_CollisionSubTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataUpdateFlag > 0)
                return;

            CurrentSubType = ComboBox_CollisionSubTypes.SelectedIndex;
            UpdateParamTypeAndData();
            UpdateHexEditor();
        }

        private void ByteArrayEditor_Collision_ValueChanged()
        {
            SetCollisionEditorData();
        }

        private void ListBox_NormalTileParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataUpdateFlag > 0)
                return;

            CurrentParam = ListBox_NormalTileParams.SelectedIndex;
            UpdateParamTypeAndData();
            UpdateHexEditor();
        }

        private void CheckBox_PartialBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (DataUpdateFlag > 0)
                return;

            CurrentParam =
                ((CheckBox_PartialBlock_TopLeft.Checked) ? 1 : 0) |
                ((CheckBox_PartialBlock_TopRight.Checked) ? 2 : 0) |
                ((CheckBox_PartialBlock_BottomLeft.Checked) ? 4 : 0) |
                ((CheckBox_PartialBlock_BottomRight.Checked) ? 8 : 0);

            UpdateParamTypeAndData();
            UpdateHexEditor();
        }

        private void ComboBox_PipeDoorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataUpdateFlag > 0)
                return;

            CurrentParam &= 0x1F;
            CurrentParam |= (ComboBox_PipeDoorType.SelectedIndex << 5);
            UpdateParamTypeAndData();
            UpdateHexEditor();
        }

        private void ListBox_PipeDoorParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataUpdateFlag > 0)
                return;

            CurrentParam &= 0xE0;
            CurrentParam |= ListBox_PipeDoorParams.SelectedIndex;
            UpdateParamTypeAndData();
            UpdateHexEditor();
        }

        #endregion
    }
}
