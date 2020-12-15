using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Newt
{
    public class ImageIndexer
    {
        private readonly List<Box> boxes;
        private readonly Dictionary<Color, int> freqTable;
        public Color[] palette;

        public ImageIndexer(Bitmap b, int xx, int yy)
        {
            int paletteCount = 4;

            freqTable = new Dictionary<Color, int>();
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                {
                    Color c = b.GetPixel(x + xx, y + yy);
                    if (c.A < 128)

                        continue;
                    c = Color.FromArgb(c.R, c.G, c.B);

                    if (freqTable.ContainsKey(c))
                        freqTable[c]++;
                    else
                        freqTable[c] = 1;
                }

            Box startBox = ShrinkBox(new Box(0, 0, 0, 255, 255, 255));
            boxes = new List<Box>();
            boxes.Add(startBox);

            while (boxes.Count < paletteCount)
            {
                Box bo = GetDominantBox();
                if (bo == null)
                    break;

                Split(bo);
            }

            palette = new Color[4];

            for (int i = 0; i < paletteCount; i++)
            {
                if (i >= boxes.Count)
                    palette[i] = boxes[0].Center();
                else
                    palette[i] = boxes[i].Center();
            }
        }


        private void Split(Box b)
        {
            byte dim = b.DominantDimensionNum(); 
            List<Byteint> values = new List<Byteint>();
            int total = 0;
            foreach (Color c in freqTable.Keys)
                if (b.Inside(c))
                {
                    values.Add(new Byteint(ColorDim(c, dim), freqTable[c]));
                    total += freqTable[c];
                }
            values.Sort();

            if (values.Count == 0)
                Console.Out.WriteLine("iijiji");

            byte m = Median(values, total);
            if (m == values[0].b)
                m++;

            Box nb = new Box(b);
            nb.SetDimMax(dim, (byte)(m - 1));
            b.SetDimMin(dim, m);
            boxes.Add(ShrinkBox(nb));
            boxes.Remove(b);
            boxes.Add(ShrinkBox(b));
        }

        private byte Median(List<Byteint> values, int total)
        {
            int acum = 0;
            foreach (Byteint val in values)
            {
                acum += val.i;
                if (acum * 2 > total)
                    return val.b;
            }

            return 0;
        }

        private class Byteint : IComparable
        {
            public byte b;
            public int i;
            public Byteint(byte b, int i)
            {
                this.b = b;
                this.i = i;
            }

            public int CompareTo(object obj)
            {
                Byteint bi = obj as Byteint;
                return b.CompareTo(bi.b);
            }

            public static bool operator <(Byteint a, Byteint b)
            {
                return a.b < b.b;
            }
            public static bool operator >(Byteint a, Byteint b)
            {
                return a.b > b.b;
            }
        }

        private byte ColorDim(Color c, byte d)
        {
            if (d == 0) return c.R;
            if (d == 1) return c.G;
            return c.B;
        }

        private Box GetDominantBox()
        {
            Box best = null;
            int bestDim = 0;

            foreach (Box b in boxes)
            {
                int dim = b.DominantDimension();
                if ((dim > bestDim || best == null) && b.CanSplit(freqTable))
                {
                    bestDim = dim;
                    best = b;
                }
            }
            return best;
        }

        private Box ShrinkBox(Box b)
        {
            Box r = null;
            foreach (Color c in freqTable.Keys)
                if (b.Inside(c))
                {
                    if (r == null)
                        r = new Box(c.R, c.G, c.B, c.R, c.G, c.B);
                    else
                        r.Expand(c);
                }

            if (r == null)
                return new Box(b);

            return r;
        }

        public static float ColorDifference(Color a, Color b)
        {
            if (a.A != b.A) return ushort.MaxValue;

            int res = 0;
            res += (a.R - b.R) * (a.R - b.R) / 40;
            res += (a.G - b.G) * (a.G - b.G) / 40;
            res += (a.B - b.B) * (a.B - b.B) / 40;

            if (res > float.MaxValue)
                return float.MaxValue;

            return (ushort)res;
        }

        public static float ColorDifferenceWithoutAlpha(Color a, Color b)
        {
            int res = 0;
            res += (a.R - b.R) * (a.R - b.R) / 40;
            res += (a.G - b.G) * (a.G - b.G) / 40;
            res += (a.B - b.B) * (a.B - b.B) / 40;

            if (res > float.MaxValue)
                return float.MaxValue;

            return (ushort)res;
        }

        private class Box
        {
            public byte r1, r2, g1, g2, b1, b2;
            public Box(byte r1, byte g1, byte b1, byte r2, byte g2, byte b2)
            {
                this.r1 = r1;
                this.g1 = g1;
                this.b1 = b1;
                this.r2 = r2;
                this.g2 = g2;
                this.b2 = b2;
            }

            public Box(Box b)
            {
                this.r1 = b.r1;
                this.g1 = b.g1;
                this.b1 = b.b1;
                this.r2 = b.r2;
                this.g2 = b.g2;
                this.b2 = b.b2;
            }

            public bool Inside(Color c)
            {
                return
                    r1 <= c.R && r2 >= c.R &&
                    g1 <= c.G && g2 >= c.G &&
                    b1 <= c.B && b2 >= c.B;
            }

            public void Expand(Color c)
            {
                if (r1 > c.R) r1 = c.R;
                if (r2 < c.R) r2 = c.R;
                if (g1 > c.G) g1 = c.G;
                if (g2 < c.G) g2 = c.G;
                if (b1 > c.B) b1 = c.B;
                if (b2 < c.B) b2 = c.B;
            }

            public int DominantDimension()
            {
                int res = -1;
                if (r2 - r1 > res) res = r2 - r1;
                if (g2 - g1 > res) res = g2 - g1;
                if (b2 - b1 > res) res = b2 - b1;

                return res;
            }

            public byte DominantDimensionNum()
            {
                int d = DominantDimension();
                if (d == r2 - r1) return 0;
                if (d == g2 - g1) return 1;
                return 2;
            }

            public bool IsColorIn(Color c, int dim)
            {
                if (dim == 0)
                    return c.R >= r1 && c.R <= r2;
                if (dim == 1)
                    return c.G >= g1 && c.G <= g2;
                return c.B >= b1 && c.B <= b2;
            }

            public void SetDimMin(byte d, byte a)
            {
                if (d == 0)
                    r1 = a;
                else if (d == 1)
                    g1 = a;
                else
                    b1 = a;
            }
            public void SetDimMax(byte d, byte a)
            {
                if (d == 0)
                    r2 = a;
                else if (d == 1)
                    g2 = a;
                else
                    b2 = a;
            }

            public bool CanSplit(Dictionary<Color, int> freqTable)
            {
                if (r1 == r2 && g1 == g2 && b1 == b2) return false;

                int count = 0;
                foreach (Color c in freqTable.Keys)
                {
                    if (Inside(c))
                        count++;

                    if (count <= 2)
                        return true;
                }
                return false;
            }

            public Color Center()
            {
                return Color.FromArgb((r1 + r2) / 2, (g1 + g2) / 2, (b1 + b2) / 2);
            }

            public override string ToString()
            {
                return "(" + r1 + "-" + r2 + "," + g1 + "-" + g2 + "," + b1 + "-" + b2 + ")";
            }
        }
    }
}
