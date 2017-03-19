using System;
using System.Drawing;


namespace Triangulation_
{
    public struct Square
    {
        public int x;
        public int y;
        public int side;
        public Color color;
        public bool is_processed;
        public Square(int kx, int ky, int s)
        {
            x = kx;
            y = ky;
            side = s;
            color = Color.Black;
            is_processed = false;
        }
    }
    public struct Triangle
    {
        public int koordX1;
        public int koordX2;
        public int koordX3;
        public int koordY1;
        public int koordY2;
        public int koordY3;
        public Triangle(int kx1, int kx2, int kx3, int ky1, int ky2, int ky3)
        {
            koordX1 = kx1;
            koordX2 = kx2;
            koordX3 = kx3;
            koordY1 = ky1;
            koordY2 = ky2;
            koordY3 = ky3;
        }
    }
    public struct ShortCut
    {
        public int koordX1;
        public int koordX2;
        public int koordY1;
        public int koordY2;

        public ShortCut(int x1, int x2, int y1, int y2)
        {
            koordX1 = x1;
            koordX2 = x2;
            koordY1 = y1;
            koordY2 = y2;
        }
    }
    public struct Pivot
    {
        public int koordX;
        public int koordY;
        public Color color;
        public Pivot(int x, int y, Color col)
        {
            koordX = x;
            koordY = y;
            color = col;
        }
        public override String ToString()
        {
            return "{" + koordX + "; " + koordY + "}";
        }
    }

}
