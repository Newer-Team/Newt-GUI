using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newt.ObjectClasses;

namespace Newt
{
    public partial class RawTileCollisionDataEditor : UserControl
    {
        public bool DataChangeFlag = false;
        public byte[] Data;
        public string ShownData;
        public List<List<Tile>> Tiles = new List<List<Tile>>();

        public delegate void ValueWasChanged();
        public event ValueWasChanged ValueChanged;

        public RawTileCollisionDataEditor()
        {
            InitializeComponent();
        }

        public void SetTilesTo(List<List<Tile>> _Tiles)
        {
            Tiles = _Tiles;

            byte[] ColliderData = new byte[4];

            if (Tiles.Count != 0)
                ColliderData = Tiles[0][0].Collision;

            bool ColliderDataAllTheSame = true;

            foreach (List<Tile> Row in Tiles)
            {
                foreach (Tile Tile in Row)
                {
                    if (!Tile.Collision.SequenceEqual(ColliderData))
                        ColliderDataAllTheSame = false;
                }
            }

            if (ColliderDataAllTheSame)
                SetArrayTo(ColliderData);
        }

        public void SetArrayTo(byte[] Data)
        {
            if (Data == null)
            {
                InputBox.Enabled = false;
                return;
            }

            DataChangeFlag = true;

            this.Data = Data;
            InputBox.Text = "";
            ShownData = "";

            for (int i = 0; i < Data.Length; i++)
            {
                InputBox.Text += this.Data[i].ToString("X2") + " ";
                ShownData += "[0-9a-f] *[0-9a-f] *";
            }

            ShownData = "^ *" + ShownData + "$";

            InputBox.Enabled = true;
            InputBox.BackColor = SystemColors.Window;
            DataChangeFlag = false;

            InputBox_TextChanged(this, null);
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            if (Data == null || DataChangeFlag)
                return;

            if (System.Text.RegularExpressions.Regex.IsMatch(InputBox.Text,
                                                             ShownData, 
                                                             System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                string Parsed = InputBox.Text.Replace(" ", "");

                for (int i = 0; i < Data.Length; i++)
                {
                    Data[i] = byte.Parse(Parsed.Substring(i * 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                }

                InputBox.BackColor = SystemColors.Window;

                foreach (List<Tile> Row in Tiles)
                {
                    foreach (Tile Tile in Row)
                    {
                        Tile GlobalTile = Globals.EditedTileset.Tiles.Find(x => x.Number == Tile.Number);
                        GlobalTile.Collision = Data;
                        ValueChanged();
                    }
                }
            }
            else
            {
                InputBox.BackColor = Color.Coral;
            }
        }
    }
}
