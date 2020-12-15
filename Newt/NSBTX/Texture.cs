using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

using Newt.ImageQuant;

namespace Newt
{
    public class PalettedImage
    {
        public byte[] Indices;
        public liq_palette Palette;

        public PalettedImage(byte[] _Indices, liq_palette _Palette)
        {
            Indices = _Indices;
            Palette = _Palette;
        }
    }

    public class EncodedImage
    {
        public byte[] Texture;
        public byte[] Texture2;
        public UInt16[] Palette;

        public EncodedImage(byte[] _Texture, UInt16[] _Palette, byte[] _Texture2 = null)
        {
            Texture = _Texture;
            Texture2 = _Texture2;
            Palette = _Palette;
        }
    }

    public static class Images
    {
        public unsafe static Bitmap QuantizeImage(Bitmap Image, int Colors)
        {
            byte[] BitmapArray = MakeBitmapArray(Image);

            var attr = Liq.liq_attr_create();
            Liq.liq_set_max_colors(attr, Colors);
            Liq.liq_set_min_posterization(attr, 2);

            var LiqImage = Liq.liq_image_create_rgba(attr, BitmapArray, Image.Width, Image.Height, 0);
            var LiqQuantized = Liq.liq_quantize_image(attr, LiqImage);

            byte[] Texture = new byte[Image.Width * Image.Height];
            Liq.liq_write_remapped_image(LiqQuantized, LiqImage, Texture, (UIntPtr)(Image.Width * Image.Height));
            liq_palette LiqPalette = (liq_palette)Marshal.PtrToStructure(Liq.liq_get_palette(LiqQuantized), typeof(liq_palette));

            Bitmap BMP;

            fixed (byte* p = Texture)
            {
                IntPtr ptr = (IntPtr)p;
                BMP = new Bitmap(Image.Width, Image.Height, Image.Width, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ptr);
            }

            System.Drawing.Imaging.ColorPalette pal = BMP.Palette;

            for (int i = 0; i < BMP.Palette.Entries.Count(); i++)
            {
                pal.Entries[i] = Color.FromArgb(LiqPalette.Entries[i].A, LiqPalette.Entries[i].R, LiqPalette.Entries[i].G, LiqPalette.Entries[i].B);
            }

            BMP.Palette = pal;
            return BMP;
        }

        public static PalettedImage CreatePalettedImage(Bitmap Image, int Format)
        {
            byte[] BitmapArray = MakeBitmapArray(Image);

            var attr = Liq.liq_attr_create();
            Liq.liq_set_max_colors(attr, GetColorNum(Format));
            Liq.liq_set_min_posterization(attr, 2);

            var LiqImage = Liq.liq_image_create_rgba(attr, BitmapArray, Image.Width, Image.Height, 0);
            var LiqQuantized = Liq.liq_quantize_image(attr, LiqImage);

            byte[] Texture = new byte[Image.Width * Image.Height];
            Liq.liq_write_remapped_image(LiqQuantized, LiqImage, Texture, (UIntPtr)(Image.Width * Image.Height));
            liq_palette LiqPalette = (liq_palette)Marshal.PtrToStructure(Liq.liq_get_palette(LiqQuantized), typeof(liq_palette));

            return new PalettedImage(Texture, LiqPalette);
        }

        public static byte[] MakeBitmapArray(Bitmap Image)
        {
            byte[] BitmapArray = new byte[Image.Width * Image.Height * 4];

            for (int y = 0; y < Image.Height; y++)
                for (int x = 0; x < Image.Width; x++)
                {
                    Color Col = Image.GetPixel(x, y);

                    BitmapArray[(y * Image.Width + x) * 4 + 0] = Col.R;
                    BitmapArray[(y * Image.Width + x) * 4 + 1] = Col.G;
                    BitmapArray[(y * Image.Width + x) * 4 + 2] = Col.B;
                    BitmapArray[(y * Image.Width + x) * 4 + 3] = Col.A;
                }

            return BitmapArray;
        }


        #region Image Encoding
        public static EncodedImage EncodeImage(PalettedImage Image, int TexType)
        {
            switch (TexType)
            {
                case 1: return EncodeImage_A3I5(Image);
                case 2: return EncodeImage_I2(Image);
                case 3: return EncodeImage_I4(Image);
                case 4: return EncodeImage_I8(Image);
                case 6: return EncodeImage_A5I3(Image);
                default: return null;
            }
        }

        public static EncodedImage EncodeImage_A3I5(PalettedImage Image)
        {
            List<byte> Texture = new List<byte>();

            foreach (byte b in Image.Indices)
            {
                int IDX = Convert.ToInt32(b);
                int a = Image.Palette.Entries[IDX].A;

                Texture.Add((byte)(IDX | (a > 240 ? 0xE0 : ((a + 15) & 0xE0))   ));
            }

            return new EncodedImage(Texture.ToArray(), EncodePalette(Image.Palette));
        }

        public static EncodedImage EncodeImage_I2(PalettedImage Image)
        {
            List<byte> Texture = new List<byte>();

            for (int i = 0; i < Image.Indices.Count() / 4; i += 4)
            {
                int v1 = Image.Indices[i + 0];
                int v2 = Image.Indices[i + 1];
                int v3 = Image.Indices[i + 2];
                int v4 = Image.Indices[i + 3];

                Texture.Add((byte)(v4 << 6 | v3 << 4 | v2 << 2 | v1));
            };

            return new EncodedImage(Texture.ToArray(), EncodePalette(Image.Palette));
        }


        public static EncodedImage EncodeImage_I4(PalettedImage Image)
        {
            List<byte> Texture = new List<byte>();

            for (int i = 0; i < Image.Indices.Count() / 2; i += 2)
            {
                int v1 = Image.Indices[i + 0];
                int v2 = Image.Indices[i + 1];

                Texture.Add((byte)(v2 << 4 | v1));
            };

            return new EncodedImage(Texture.ToArray(), EncodePalette(Image.Palette));
        }

        public static EncodedImage EncodeImage_I8(PalettedImage Image)
        {
            return new EncodedImage(Image.Indices, EncodePalette(Image.Palette));
        }

        public static EncodedImage EncodeImage_A5I3(PalettedImage Image)
        {
            List<byte> Texture = new List<byte>();

            foreach (byte b in Image.Indices)
            {
                int IDX = Convert.ToInt32(b);
                int a = Image.Palette.Entries[IDX].A;

                Texture.Add((byte)(IDX | (a > 252 ? 0xF8 : ((a + 3) & 0xF8))));
            }

            return new EncodedImage(Texture.ToArray(), EncodePalette(Image.Palette));
        }

        public static EncodedImage EncodeImage_RGB555(Bitmap Image)
        {
            byte[] Texture = new byte[Image.Width * Image.Height * 2];

            for (int y = 0; y < Image.Height; y++)
                for (int x = 0; x < Image.Width; x++)
                {
                    Color Col = Image.GetPixel(x, y);

                    int Packed = Pack255(Col.R, Col.G, Col.B, Col.A);

                    Texture[(x + y * Image.Width) * 2] = (byte)(Packed & 0xFF);
                    Texture[(x + y * Image.Width) * 2 + 1] = (byte)(Packed >> 8);
                }

            return new EncodedImage(Texture, new UInt16[0]);
        }

        public static EncodedImage Encode_Tex4x4(Bitmap Image, int MaximumNumberofPalettes)
        {
            int tx = Image.Width / 4;
            int ty = Image.Height / 4;
            Color[][] Palettes = new Color[tx * ty][];
            int[] PaletteCounts = new int[tx * ty];
            int[,] PaletteNumbers = new int[tx, ty];

            int PaletteNumber = 0;
            for (int x = 0; x < tx; x++)
                for (int y = 0; y < ty; y++)
                {
                    ImageIndexer Indexer = new ImageIndexer(Image, x * 4, y * 4);
                    Palettes[PaletteNumber] = Indexer.palette;
                    PaletteNumbers[x, y] = PaletteNumber;
                    PaletteCounts[PaletteNumber] = 1;
                    PaletteNumber++;
                }

            int Current = 0;

            Color[] FinalPalette = new Color[MaximumNumberofPalettes * 4];
            int[] NewPaletteNumbers = new int[Palettes.Length];
            for (int i = 0; i < Palettes.Length; i++)
            {
                if (PaletteCounts[i] != 0)
                {
                    NewPaletteNumbers[i] = Current;
                    Array.Copy(Palettes[i], 0, FinalPalette, Current * 4, 4);
                    Current++;
                }
            }

            List<byte> Data1List = new List<byte>();
            List<byte> Data2List = new List<byte>();

            for (int y = 0; y < ty; y++)
                for (int x = 0; x < tx; x++)
                {
                    bool HasTransparentPixels = false;
                    for (int yy = 0; yy < 4; yy++)
                        for (int xx = 0; xx < 4; xx++)
                        {
                            Color Colorl = Image.GetPixel(x * 4 + xx, y * 4 + yy);
                            if (Colorl.A < 128)
                                HasTransparentPixels = true;
                        }

                    for (int yy = 0; yy < 4; yy++)
                    {
                        byte FinalByte = 0;
                        byte Pow = 1;

                        for (int xx = 0; xx < 4; xx++)
                        {
                            Color Colorl = Image.GetPixel(x * 4 + xx, y * 4 + yy);
                            byte Color;

                            if (Colorl.A < 128)
                                Color = 3;
                            else
                            {
                                if (!HasTransparentPixels)
                                    Color = (byte)GetClosestColor(Colorl, Palettes[PaletteNumbers[x, y]]);
                                else
                                    Color = (byte)GetClosestColorWithAlpha(Colorl, Palettes[PaletteNumbers[x, y]]);

                                if (Color == 3)
                                    Color = 2;
                            }

                            FinalByte |= (byte)(Pow * Color);
                            Pow *= 4;
                        }
                        Data1List.Add(FinalByte);
                    }

                    UInt16 Data = (UInt16)(NewPaletteNumbers[PaletteNumbers[x, y]] * 2);
                    if (!HasTransparentPixels)
                        Data |= 2 << 14;

                    byte[] P = BitConverter.GetBytes((UInt16)Data);
                    Data2List.Add(P[0]);
                    Data2List.Add(P[1]);
                }

            return new EncodedImage(Data1List.ToArray(), EncodePalette(FinalPalette), Data2List.ToArray());
        }

        public static UInt16[] EncodePalette(liq_palette Palette)
        {
            List<UInt16> EncodedPalette = new List<UInt16>();

            foreach (liq_color Entry in Palette.Entries)
            {
                EncodedPalette.Add(Pack255(Entry.R, Entry.G, Entry.B, Entry.A));
            }

            UInt16[] Array = EncodedPalette.ToArray();

            while (Array.Length % 4 != 0)
                Array = (UInt16[])Array.Append((UInt16)0);


            return Array;
        }

        public static UInt16[] EncodePalette(Color[] Palette)
        {
            List<UInt16> EncodedPalette = new List<UInt16>();

            foreach (Color Entry in Palette)
            {
                EncodedPalette.Add(Pack255(Entry.R, Entry.G, Entry.B, Entry.A));
            }

            UInt16[] Array = EncodedPalette.ToArray();

            while (Array.Length % 4 != 0)
                Array = (UInt16[])Array.Append((UInt16)0);

            return Array;
        }

        public static UInt16 Pack(int R, int G, int B, int A)
        {
            UInt16 Value = 0;

            Value |= (UInt16)(R & 0x1F);
            Value |= (UInt16)((G & 0x1F) << 5);
            Value |= (UInt16)((B & 0x1F) << 10);
            Value |= (UInt16)((A & 1) << 15);

            return Value;
        }

        public static UInt16 Pack255(int R, int G, int B, int A = 255)
        {
            return Pack(((R + 4) << 2) / 33,
                        ((G + 4) << 2) / 33,
                        ((B + 4) << 2) / 33,
                        A < 128 ? 0 : 1);
        }

        public static int GetClosestColor(Color c, Color[] Pal)
        {
            int bestInd = 0;
            float bestDif = ImageIndexer.ColorDifferenceWithoutAlpha(Pal[0], c);

            for (int i = 0; i < Pal.Length; i++)
            {
                float d = ImageIndexer.ColorDifferenceWithoutAlpha(Pal[i], c);
                if (d < bestDif)
                {
                    bestDif = d;
                    bestInd = i;
                }
            }

            return bestInd;
        }

        public static int GetClosestColorWithAlpha(Color c, Color[] pal)
        {
            int bestInd = 0;
            float bestDif = ImageIndexer.ColorDifference(pal[0], c);

            for (int i = 0; i < pal.Length; i++)
            {
                float d = ImageIndexer.ColorDifference(pal[i], c);
                if (d < bestDif)
                {
                    bestDif = d;
                    bestInd = i;
                }
            }

            return bestInd;
        }

        #endregion

        private static int GetBitsPerPixel(int TexType)
        {
            switch (TexType)
            {
                case 1: return 8;
                case 2: return 2;
                case 3: return 4;
                case 4: return 8;
                case 5: return 2;
                case 6: return 8;
                case 7: return 16;
                default: return 0;
            }
        }

        private static int GetColorNum(int TexType)
        {
            switch (TexType)
            {
                case 1: return 32;
                case 2: return 4;
                case 3: return 16;
                case 4: return 256;
                case 5: return 0;
                case 6: return 8;
                default: return 0;
            }
        }
    }
}


