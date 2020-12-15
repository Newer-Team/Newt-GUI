using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.Serialization.Json;
using System.Text;
using Python.Runtime;
using System.Threading;

namespace Newt.ObjectClasses
{
    public class Tile
    {
        public int Number { get; set; }
        public int ID { get; set; }
        public bool FlipX { get; set; }
        public bool FlipY { get; set; }
        public byte[] Collision { get; set; }
        public Bitmap TileBitmap { get; set; }

        public Tile()
        {
            Number = -1;
            ID = -1;
            FlipX = false;
            FlipY = false;
            Collision = new byte[0];
            TileBitmap = new Bitmap(16, 16);
        }

        public Tile(int _Number, int _ID, bool _FlipX, bool _FlipY, byte[] _Collision, Bitmap _Bitmap)
        {
            ID = _ID;
            Number = _Number;
            FlipX = _FlipX;
            FlipY = _FlipY;
            Collision = _Collision;
            TileBitmap = _Bitmap;
        }

        public Tile Clone()
        {
            return new Tile(Number, ID, FlipX, FlipY, Collision, (Bitmap)TileBitmap.Clone());
        }
    }

    public class Object
    {
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public List<List<int>> Tiles { get; set; }
        public Bitmap PreviewBitmap { get; set; }

        public Object()
        {
            ID = -1;
            Width = -1;
            Height = -1;
            Name = "Object";
            Tiles = new List<List<int>>();
            PreviewBitmap = new Bitmap(16, 16);
        }

        public Object(int _ID, int _Width, int _Height, string _Name, List<List<int>> _Tiles, Bitmap _PreviewBitmap)
        {
            ID = _ID;
            Width = _Width;
            Height = _Height;
            Tiles = _Tiles;
            Name = _Name;
            PreviewBitmap = _PreviewBitmap;
        }

        public void RedrawPreview(Tileset ParentTileset)
        {
            this.PreviewBitmap = new Bitmap(16 * (Width == 0 ? 1 : Width), 16 * (Height == 0 ? 1 : Height));
            Rectangle DestRect = new Rectangle(0, 0, 16, 16);

            using (Graphics g = Graphics.FromImage(PreviewBitmap))
            {
                for (int r = 0; r < Tiles.Count; r++)
                    for (int t = 0; t < Tiles[r].Count; t++)
                    {
                        int TileID = Tiles[r][t];

                        if (TileID >= 0)
                            g.DrawImage(ParentTileset.Tiles[TileID].TileBitmap, new Rectangle(new Point(16 * t, 16 * r), new Size(16, 16)), DestRect, GraphicsUnit.Pixel);
                    }
            }
        }
    }

    public class Tileset
    {
        public Bitmap MainPNG { get; set; }
        public List<Tile> Tiles { get; set; }
        public List<int> TextureFormats { get; set; }
        public List<List<int>> RandomizationGroups { get; set; }
        public List<string> Textures { get; set; }
        public List<Object> Objects { get; set; }
        public int Version { get; set; }
        private string ObjectHash { get; set; }
        public string Filename { get; set; }

        public Tileset()
        {
            this.MainPNG = new Bitmap(256, 768);

            Tiles = new List<Tile>();
            TextureFormats = new List<int>();
            Objects = new List<Object>();

            for (int i = 0; i < 765; i++)
            {
                Tiles.Add(new Tile(i, i, false, false, new byte[4] { 0, 0, 0, 0 }, new Bitmap(16, 16)));
                TextureFormats.Add(1);
            }

            for (int i = 0; i < 256; i++)
            {
                Objects.Add(new Object(i, 0, 0, "Object " + i, new List<List<int>>(), new Bitmap(16, 16)));
            }

            RandomizationGroups = new List<List<int>>();
            Textures = new List<string>() { "texture1.nsbtx", "texture2.nsbtx", "texture3.nsbtx" };
            Version = 1;
            Filename = "";
        }

        public Tileset(List<Tile> _Tiles, List<int> _TextureFormats, List<List<int>> _RandomizationGroups, List<string> _Textures, List<Object> _Objects, int _Version)
        {
            Tiles = _Tiles;
            TextureFormats = _TextureFormats;
            RandomizationGroups = _RandomizationGroups;
            Textures = _Textures;
            Version = _Version;
            Objects = _Objects;

            ObjectHash = Helpers.GetObjectHash(this);
        }

        public void GenerateObjectHash()
        {
            ObjectHash = Helpers.GetObjectHash(this);
        }

        public bool IsDirty()
        {
            string NewHash = Helpers.GetObjectHash(this);
            return !String.Equals(NewHash, ObjectHash);
        }

        public void LoadInByFilename(string _Filename)
        {
            try
            {
                using (var ZippedTileset = File.OpenRead(_Filename))
                {
                    using (var ZipFile = new ZipArchive(ZippedTileset, ZipArchiveMode.Read))
                    {
                        ZipArchiveEntry PNG = ZipFile.GetEntry("texture.png");
                        ZipArchiveEntry JSON = ZipFile.GetEntry("meta.json");
                        ZipArchiveEntry Collisions = ZipFile.GetEntry("collisions.chk");
                        ZipArchiveEntry Objects = ZipFile.GetEntry("objects.unt");
                        ZipArchiveEntry ObjectsHeader = ZipFile.GetEntry("objects.unthd");

                        this.MainPNG = new Bitmap(PNG.Open());

                        #region Loading in the tiles

                        byte[] CollisionArr = null;

                        using (var BR = new BinaryReader(Collisions.Open()))
                            CollisionArr = BR.ReadBytes((int)Collisions.Length);

                        var Serializer = new DataContractJsonSerializer(typeof(JSONClass));
                        JSONClass JSONObject = (JSONClass)Serializer.ReadObject(JSON.Open());

                        int i = 0;
                        this.Tiles = new List<Tile>();

                        foreach (object[] TileO in JSONObject.tiles)
                        {
                            int TileID = Convert.ToInt32(TileO[0]);
                            bool FlipX = Convert.ToBoolean(TileO[1]);
                            bool FlipY = Convert.ToBoolean(TileO[2]);
                            byte[] CollisionData = new Byte[4];
                            Array.Copy(CollisionArr, i * 4, CollisionData, 0, 4);

                            Bitmap TileBitmap = new Bitmap(16, 16);

                            Graphics g = Graphics.FromImage(TileBitmap);
                            g.DrawImage(this.MainPNG, new Rectangle(new Point(0, 0), new Size(16, 16)), Helpers.GetRectangleForTileID(TileID), GraphicsUnit.Pixel);

                            if (FlipX)
                                TileBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

                            if (FlipY)
                                TileBitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            this.Tiles.Add(new Tile(i, TileID, FlipX, FlipY, CollisionData, TileBitmap));

                            i++;
                        }

                        #endregion

                        #region Loading in the Randomization Groups

                        this.RandomizationGroups = new List<List<int>>();

                        foreach (int[] RandomizationGroup in JSONObject.randomization_groups)
                        {
                            List<int> RandomizationGroupO = new List<int>();

                            foreach (object TileID in RandomizationGroup)
                                RandomizationGroupO.Add(Convert.ToInt32(TileID));

                            RandomizationGroups.Add(RandomizationGroupO);
                        }

                        #endregion

                        #region Loading in the Texture Formats
                        this.TextureFormats = new List<int>();

                        foreach (int Format in JSONObject.texture_formats)
                            this.TextureFormats.Add(Format);

                        #endregion

                        #region Loading in the Texture Names

                        this.Textures = new List<string>();
                        foreach (string TexName in JSONObject.textures)
                            this.Textures.Add(TexName);

                        #endregion

                        #region Loading in the Objects

                        byte[] ObjHeader = null;
                        byte[] ObjectsData = null;

                        using (var BR = new BinaryReader(Objects.Open()))
                            ObjectsData = BR.ReadBytes((int)Objects.Length);

                        using (var BR = new BinaryReader(ObjectsHeader.Open()))
                            ObjHeader = BR.ReadBytes((int)ObjectsHeader.Length);

                        this.Objects = new List<Object>();

                        for (int o = 0; o < 256; o++)
                        {
                            this.Objects.Add(new Object(o, 0, 0, "Object " + i, new List<List<int>>(), new Bitmap(16, 16)));
                        }

                        for (int f = 0; f < ObjHeader.Length; f += 4)
                        {
                            List<List<int>> Tiles = new List<List<int>>();
                            UInt16 Offset = BitConverter.ToUInt16(ObjHeader, f);
                            Byte TestWidth = 0;
                            Byte Width = 1;
                            Byte Height = 0;

                            UInt16 TestOffset = Offset;

                            while (ObjectsData[TestOffset] != 255)
                            {
                                if (ObjectsData[TestOffset] == 0)
                                {
                                    TestOffset += 3;
                                    TestWidth++;
                                }

                                else if (ObjectsData[TestOffset] == 254)
                                {
                                    if (TestWidth > Width)
                                        Width = TestWidth;

                                    TestWidth = 0;
                                    TestOffset += 1;
                                    Height++;
                                }
                            }

                            for (int c = 0; c < Height; c++)
                                Tiles.Add(new List<int>());

                            for (int r = 0; r < Width; r++)
                                for (int c = 0; c < Height; c++)
                                    Tiles[c].Add(0);

                            int Row = 0;
                            int Column = 0;
                            bool Pa2 = false;

                            while (ObjectsData[Offset] != 255)
                            {
                                if (ObjectsData[Offset] == 0)
                                {
                                    UInt16 Tile = BitConverter.ToUInt16(ObjectsData, Offset + 1);

                                    if (Tile >= 1024)
                                        Pa2 = true;

                                    Tiles[Row][Column] = Tile;
                                    Column++;
                                    Offset += 3;
                                }
                                else if (ObjectsData[Offset] == 254)
                                {
                                    Row++;
                                    Column = 0;
                                    Offset += 1;
                                }
                            }

                            Bitmap PreviewBitmap = new Bitmap(16 * (Width == 0 ? 1 : Width), 16 * (Height == 0 ? 1 : Height));

                            using (Graphics g = Graphics.FromImage(PreviewBitmap))
                            {
                                for (int r = 0; r < Tiles.Count; r++)
                                    for (int t = 0; t < Tiles[r].Count; t++)
                                    {
                                        int TileID = Tiles[r][t] - (Pa2 ? 1024 : 256);

                                        Tiles[r][t] = TileID;

                                        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                                        if (TileID >= 0)
                                            g.DrawImage(this.Tiles[TileID].TileBitmap, new Rectangle(new Point(16 * t, 16 * r), new Size(16, 16)), new Rectangle(0, 0, 16, 16), GraphicsUnit.Pixel);
                                    }
                            }

                            string ObjectName = "Object " + f / 4;

                            if (JSONObject.object_names.Count() > (f / 4))
                                if (JSONObject.object_names[f / 4] != null)
                                    ObjectName = JSONObject.object_names[f / 4];

                            Object o = new Object(f / 4, Width, Height, ObjectName, Tiles, PreviewBitmap);
                            this.Objects[f / 4] = o;
                        }

                        #endregion

                        ObjectHash = Helpers.GetObjectHash(this);
                        Filename = _Filename;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tileset: " + ex.Message + " " + ex.StackTrace);
                return;
            }
        }

        public void ReloadTileGraphics(Bitmap Image)
        {
            this.MainPNG = Image;

            foreach (Tile Tile in this.Tiles)
            {
                Tile.TileBitmap = new Bitmap(16, 16);

                using (Graphics g = Graphics.FromImage(Tile.TileBitmap))
                {
                    g.DrawImage(Image, new Rectangle(new Point(0, 0), new Size(16, 16)), Helpers.GetRectangleForTileID(Tile.ID), GraphicsUnit.Pixel);

                    if (Tile.FlipX)
                        Tile.TileBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    if (Tile.FlipY)
                        Tile.TileBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
            }
        }

        public void Save(string Filename)
        {
            SaveForm SF = new SaveForm("...");
            SF.Show();

            string JSONString = null;
            List<byte> UNTArray = null;
            List<byte> UNTHDArray = null;
            byte[] CollisionsArray = null;

            Thread JSONCreation = new Thread(() =>
            {
                JSONString = CreateJSON();
            });
            JSONCreation.Start();

            Thread UNTCreation = new Thread(() =>
            {
                MakeUNTs(out UNTArray, out UNTHDArray);
            });
            UNTCreation.Start();

            Thread CollisionCreation = new Thread(() =>
            {
                CollisionsArray = MakeCollisions();
            });
            CollisionCreation.Start();

            SF.SetMessage("Creating NSBTXes...");

            List<byte[]> NSBTXes = CreateNSBTXes(SF);

            using (var NewZippedTileset = File.Create(Filename))
            {
                using (var ZipFile = new ZipArchive(NewZippedTileset, ZipArchiveMode.Create))
                {
                    SF.SetMessage("Saving NSBTX 1...");

                    ZipArchiveEntry Tex0File = ZipFile.CreateEntry(Textures[0]);

                    using (BinaryWriter Wr = new BinaryWriter(Tex0File.Open()))
                    {
                        Wr.Write(NSBTXes[0]);
                    }

                    SF.SetMessage("Saving NSBTX 2...");

                    ZipArchiveEntry Tex1File = ZipFile.CreateEntry(Textures[1]);

                    using (BinaryWriter Wr = new BinaryWriter(Tex1File.Open()))
                    {
                        Wr.Write(NSBTXes[1]);
                    }

                    SF.SetMessage("Saving NSBTX 3...");

                    ZipArchiveEntry Tex2File = ZipFile.CreateEntry(Textures[2]);

                    using (BinaryWriter Wr = new BinaryWriter(Tex2File.Open()))
                    {
                        Wr.Write(NSBTXes[1]);
                    }

                    SF.SetMessage("Saving Texture...");

                    ZipArchiveEntry ImageFile = ZipFile.CreateEntry("texture.png");

                    using (MemoryStream ms = new MemoryStream())
                    {
                        this.MainPNG.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                        using (BinaryWriter Wr = new BinaryWriter(ImageFile.Open()))
                        {
                            byte[] PNG = ms.GetBuffer();
                            Wr.Write(PNG);
                        }
                    }

                    CollisionCreation.Join();

                    SF.SetMessage("Saving collision...");

                    ZipArchiveEntry CollisionsFile = ZipFile.CreateEntry("collisions.chk");

                    using (BinaryWriter Wr = new BinaryWriter(CollisionsFile.Open()))
                    {
                        Wr.Write(CollisionsArray);
                    }

                    UNTCreation.Join();

                    SF.SetMessage("Saving Objects...");

                    ZipArchiveEntry UNTFile = ZipFile.CreateEntry("objects.unt");

                    using (BinaryWriter Wr = new BinaryWriter(UNTFile.Open()))
                    {
                        Wr.Write(UNTArray.ToArray<byte>());
                    }

                    SF.SetMessage("Saving Object Headers...");

                    ZipArchiveEntry UNTHDFile = ZipFile.CreateEntry("objects.unthd");

                    using (BinaryWriter Wr = new BinaryWriter(UNTHDFile.Open()))
                    {
                        Wr.Write(UNTHDArray.ToArray<byte>());
                    }

                    JSONCreation.Join();

                    SF.SetMessage("Saving JSON...");

                    ZipArchiveEntry JSONFile = ZipFile.CreateEntry("meta.json");

                    using (StreamWriter Wr = new StreamWriter(JSONFile.Open()))
                    {
                        Wr.Write(JSONString);
                    }
                }
            }

            SF.Close();
        }

        private List<byte[]> CreateNSBTXes(SaveForm SF)
        {
            List<byte[]> NSBTXes = new List<byte[]>();

            using (Py.GIL())
            {
                dynamic TexturePy = Python.Runtime.Py.Import("ndspy.texture");

                using (PyScope scope = Py.CreateScope())
                {
                    scope.Exec("import ndspy.texture");

                    for (int j = 0; j < 3; j++)
                    {
                        scope.Exec("nsbtx = ndspy.texture.NSBTX()");

                        for (int i = 0 + (255 * j); i < 255 + (255 * j); i++)
                        {
                            SF.SetMessage("Encoding Tile " + (i + 1) + " (Format: " + TextureFormats[i] + ")");

                            Console.WriteLine("Tex " + i);
                            Bitmap TileBitmap = new Bitmap(16, 16);
                            Graphics g = Graphics.FromImage(TileBitmap);
                            g.DrawImage(this.MainPNG, new Rectangle(new Point(0, 0), new Size(16, 16)), Helpers.GetRectangleForTileID(i), GraphicsUnit.Pixel);

                            EncodedImage Enc = null;

                            if (TextureFormats[i] == 7)
                                Enc = Images.EncodeImage_RGB555(TileBitmap);
                            else if (TextureFormats[i] == 5)
                                Enc = Images.Encode_Tex4x4(TileBitmap, 16);
                            else
                            {
                                PalettedImage p = Images.CreatePalettedImage(TileBitmap, this.TextureFormats[i]);
                                Enc = Images.EncodeImage(p, TextureFormats[i]);
                            }

                            string Name = "Tile " + i.ToString();
                            dynamic Tex = TexturePy.Texture.fromFlags(0, 0, true, true, false, false, TileBitmap.Width, TileBitmap.Height,
                                                                      this.TextureFormats[i], false, 0, 0x80010040, Enc.Texture, Enc.Texture2);
                            dynamic Pal = TexturePy.Palette.fromColors(0, 0, 0, Enc.Palette);

                            scope.Set("Name", Name.ToPython());
                            scope.Set("Tex", Tex);
                            scope.Set("Pal", Pal);
                            scope.Exec("nsbtx.textures.append((Name,Tex))");
                            scope.Exec("nsbtx.palettes.append((Name,Pal))");
                        }

                        scope.Exec("nsbtxf = nsbtx.save()");
                        NSBTXes.Add(scope.Get<byte[]>("nsbtxf"));

                    }
                }
            }

            return NSBTXes;
        }

        private string CreateJSON()
        {
            JSONClass JSON = new JSONClass();

            string[] ObjectNamesArray = new string[Objects.Count];

            for (int i = 0; i < Objects.Count; i++)
                ObjectNamesArray[i] = this.Objects[i].Name;

            int[][] RandomizationGroupsArray = new int[RandomizationGroups.Count][];

            for (int i = 0; i < RandomizationGroups.Count; i++)
            {
                int[] Group = RandomizationGroups[i].ToArray();
                RandomizationGroupsArray[i] = Group;
            }

            object[][] TilesArray = new object[765][];

            for (int i = 0; i < 765; i++)
                TilesArray[i] = new object[3] { Tiles[i].ID, Tiles[i].FlipX, Tiles[i].FlipY };

            JSON.object_names = ObjectNamesArray;
            JSON.randomization_groups = RandomizationGroupsArray;
            JSON.tiles = TilesArray;
            JSON.textures = Textures.ToArray();
            JSON.version = Version;
            JSON.texture_formats = TextureFormats.ToArray();

            var Serializer = new DataContractJsonSerializer(typeof(JSONClass));
            string JSONString = "";

            using (var MS = new MemoryStream())
            {
                Serializer.WriteObject(MS, JSON);
                JSONString = Encoding.Default.GetString(MS.ToArray());
            }

            return JSONString;
        }

        private void MakeUNTs(out List<byte> UNTArray, out List<byte> UNTHDArray)
        {
            UNTArray = new List<byte>();
            UNTHDArray = new List<byte>();

            UInt16 Ptr = 0;

            foreach (Object o in Objects)
            {
                byte[] P = BitConverter.GetBytes((UInt16)Ptr);
                UNTHDArray.Add(P[0]);
                UNTHDArray.Add(P[1]);
                UNTHDArray.Add((byte)o.Width);
                UNTHDArray.Add((byte)o.Height);

                foreach (List<int> Row in o.Tiles)
                {
                    foreach (int Tile in Row)
                    {
                        UNTArray.Add((byte)0);

                        byte[] T = BitConverter.GetBytes((UInt16)Tile + 256);
                        UNTArray.Add(T[0]);
                        UNTArray.Add(T[1]);

                        Ptr += 3;
                    }

                    UNTArray.Add((byte)254);
                    Ptr += 1;
                }

                UNTArray.Add((byte)255);
                Ptr += 1;
            }
        }

        private byte[] MakeCollisions()
        {
            byte[] CollisionsArray = new byte[768 * 4];

            for (int i = 0; i < 765; i++)
            {
                CollisionsArray[(i * 4) + 0] = Tiles[i].Collision[0];
                CollisionsArray[(i * 4) + 1] = Tiles[i].Collision[1];
                CollisionsArray[(i * 4) + 2] = Tiles[i].Collision[2];
                CollisionsArray[(i * 4) + 3] = Tiles[i].Collision[3];
            }

            return CollisionsArray;
        }
    }
}