using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Linq;

namespace Newt
{
    public static class Helpers
    {
        public static int GetTileIDForPos(float X, float Y)
        {
            if (X > 256)
                return -1;

            if (Y > 768)
                return -1;

            if (X == 0)
                return (int)(Y / 16) * 16;

            if (Y == 0)
                return (int)(X / 16);

            int TileID = (int)((X / 16) + ((Y / 16) * 16));

            if (TileID > 764)
                return TileID = 764;

            return TileID;
        }

        public static Rectangle GetRectangleForTileID(int ID, int XSize = 16, int YSize = 16)
        {
            int Row = ID / YSize;
            int Column = ID % XSize;

            int Y = Row * YSize;
            int X = Column * XSize;

            return new Rectangle(new Point(X, Y), new Size(16, 16));
        }

        public static Rectangle GetRectangleForPos(float X, float Y, int XTiles = 16, int YTiles = 16, int Tilesize = 16)
        {
            int RetX = (int)(X / Tilesize);

            if (RetX >= XTiles)
                RetX = XTiles - 1;

            if (RetX < 0)
                RetX = 0;

            int RetY = (int)(Y / Tilesize);

            if (RetY >= YTiles)
                RetY = YTiles - 1;

            if (YTiles < 0)
                RetY = 0;

            return new Rectangle(new Point(RetX * Tilesize, RetY * Tilesize), new Size(Tilesize, Tilesize));
        }

        public static Point GetStartCoordsForPos(float X, float Y, int XTiles = 16, int YTiles = 16)
        {
            int RetX = (int)(X / 16);

            if (RetX >= XTiles)
                RetX = XTiles - 1;

            if (RetX < 0)
                RetX = 0;

            int RetY = (int)(Y / 16);

            if (RetY >= YTiles)
                RetY = YTiles - 1;

            if (YTiles < 0)
                YTiles = 0;

            return new Point(RetX * 16, RetY * 16);
        }

        public static Point GetEndCoordsForPos(float X, float Y, int XTiles = 16, int YTiles = 16)
        {
            int RetX = (int)(X / 16);

            if (RetX >= XTiles)
                RetX = XTiles - 1;

            if (RetX < 0)
                RetX = 0;

            int RetY = (int)(Y / 16);

            if (RetY >= YTiles)
                RetY = YTiles - 1;

            if (YTiles < 0)
                YTiles = 0;

            return new Point(RetX * 16 + 16, RetY * 16 + 16);
        }

        public static Image ChangeImageOpacity(Image Original, float Opacity)
        {
            Bitmap BMP = new Bitmap(Original.Width, Original.Height);

            using (Graphics G = Graphics.FromImage(BMP))
            {
                ColorMatrix Matrix = new ColorMatrix();
                Matrix.Matrix33 = Opacity;
                ImageAttributes Attributes = new ImageAttributes();
                Attributes.SetColorMatrix(Matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                G.DrawImage(Original, new Rectangle(0, 0, BMP.Width, BMP.Height), 0, 0, Original.Width, Original.Height, GraphicsUnit.Pixel, Attributes);
            }
            return BMP;
        }

        public static string GetObjectHash(this object Object)
        {
            var Serializer = new DataContractSerializer(Object.GetType());

            using (var MS = new MemoryStream())
            {
                Serializer.WriteObject(MS, Object);
                string Serial = Encoding.Default.GetString(MS.ToArray());
                return HashAString(Serial);
            }
        }

        public static string HashAString(string Input)
        {
            using (SHA1Managed SHA1 = new SHA1Managed())
            {
                var Hash = SHA1.ComputeHash(Encoding.UTF8.GetBytes(Input));
                return Convert.ToBase64String(Hash);
            }
        }
    }
}