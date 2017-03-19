using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangulation_
{
    public partial class Triangulation_Form : Form
    {
        private static Image origImage;
        private int delta = 0;
        private int bright = 0;
        private static int end_click_x;
        private static int end_click_y;
        private static Bitmap imageForTriangulation;
        private static Bitmap segment_bmp;

        private int koordinateXinImage = 0;
        private int koordinateYinImage = 0;

        public Triangulation_Form()
        {
            InitializeComponent();
            
            originalPictureBox.MouseMove += new MouseEventHandler(originalPictureBox_MouseMove);
            originalPictureBox.MouseUp += new MouseEventHandler(originalPictureBox_MouseUp);
            originalPictureBox.MouseDown += new MouseEventHandler(originalPictureBox_MouseDown);
            Controls.Add(originalPictureBox);           
        }

        public List<Triangle> triangles = new List<Triangle>();
        private List<ShortCut> listOfShortCuts = new List<ShortCut>();
        public List<Pivot> points = new List<Pivot>();

        public void originalPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            koordinateXinImage = e.X;
            koordinateYinImage = e.Y;
        }
        public void originalPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            end_click_x = e.X;
            end_click_y = e.Y;
            redraw(end_click_x, end_click_y);
            pointPictureBox.Image = originalPictureBox.Image;
            originalPictureBox.Image = origImage;
        }
        public void originalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = null;
                Bitmap newImage = new Bitmap(origImage);
                g = Graphics.FromImage(newImage);
                g.DrawRectangle(new Pen(Color.Black), koordinateXinImage, koordinateYinImage, e.X - koordinateXinImage, e.Y - koordinateYinImage);
                g = null;
                originalPictureBox.Image = newImage;//придумать обновление исходного image, но только каждый раз с 1 прямоугольником (новым)
                originalPictureBox.Refresh();
                originalPictureBox.Update();
            }
        }
        public void redraw(int x, int y)
        {
            if (originalPictureBox.Image != null)
            {
                clean(false);

                originalPictureBox.Update();
                originalPictureBox.Invalidate();

                Bitmap newImage;
                int wdt = x - koordinateXinImage;
                int hgt = y - koordinateYinImage;

                Bitmap oldImage = new Bitmap(originalPictureBox.Image);
                Bitmap original = new Bitmap(origImage);

                int up_point = 1;
                if ((x == koordinateXinImage) && (y == koordinateYinImage))
                {
                    up_point = 0;
                    MessageBox.Show("Не удалось выбрать сегмент.\nПопробуйте снова.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!antiAliasСheckBox.Checked)
                    {
                        //int side = (wdt > hgt && koordinateXinImage+Math.Abs(wdt) < originalPictureBox.Width && koordinateYinImage + Math.Abs(hgt) < originalPictureBox.Height) ? wdt : hgt;
                        int side = wdt < hgt  ? wdt : hgt;
                        Square sq = new Square(koordinateXinImage, koordinateYinImage, side);
                        newImage = cut(original, sq);
                        Bitmap zoomed_area = zoom(newImage, (int)zoomCoeff.Value);
                        draw_area(segmentPictureBox, zoomed_area, false);
                        newImage = zoomed_area;
                    }
                    else
                    {
                        newImage = new Bitmap(((int)zoomCoeff.Value) * Math.Abs(wdt), ((int)zoomCoeff.Value) * Math.Abs(hgt));
                        using (Graphics g1 = Graphics.FromImage(newImage))
                        {
                            if ((x < koordinateXinImage) && (y < koordinateYinImage))
                            {
                                g1.DrawImage(original, new Rectangle(0, 0, newImage.Width, newImage.Height), new Rectangle(x, y, koordinateXinImage - x, koordinateYinImage - y), GraphicsUnit.Pixel);
                            }
                            else
                            {
                                if ((x >= koordinateXinImage) && (y >= koordinateYinImage))
                                    g1.DrawImage(original, new Rectangle(0, 0, newImage.Width, newImage.Height), new Rectangle(koordinateXinImage, koordinateYinImage, wdt, hgt), GraphicsUnit.Pixel);
                                else
                                {
                                    if ((x >= koordinateXinImage) && (y < koordinateYinImage))
                                        g1.DrawImage(original, new Rectangle(0, 0, newImage.Width, newImage.Height), new Rectangle(koordinateXinImage, y, wdt, koordinateYinImage - y), GraphicsUnit.Pixel);
                                    else
                                    {
                                        if ((x < koordinateXinImage) && (y >= koordinateYinImage))
                                            g1.DrawImage(original, new Rectangle(0, 0, newImage.Width, newImage.Height), new Rectangle(x, koordinateYinImage, koordinateXinImage - x, hgt), GraphicsUnit.Pixel);
                                    }
                                }
                            }
                        }
                        segmentPictureBox.Image = newImage;
                        //Segment seg = new Segment(newImage);
                        //seg.ShowDialog();
                    }
                    segment_bmp = newImage;
                    imageForTriangulation = new Bitmap(segmentPictureBox.Image);
                    //pointPictureBox.Image = init_pictureBox(pointPictureBox);
                    redPictureBox.Image = init_pictureBox(redPictureBox);
                    greenPictureBox.Image = init_pictureBox(greenPictureBox);
                    oldImage.Dispose();
                }

                //Segment seg = new Segment(newImage);
                //seg.ShowDialog();
            }
        }


        public static List<Point> convexHull(List<Pivot> pivots)
        {
            List<Point> points = new List<Point>();
            foreach (Pivot pivot in pivots)
            {
                Point new_point = new Point(pivot.koordX, pivot.koordY);
                points.Add(new_point);
            }

            List<Point> hull = new List<Point>();

            // get leftmost point
            Point vPointOnHull = points.Where(p => p.X == points.Min(min => min.X)).First();

            Point vEndpoint;
            do
            {
                hull.Add(vPointOnHull);
                vEndpoint = points[0];

                for (int i = 1; i < points.Count; i++)
                {
                    if ((vPointOnHull == vEndpoint) || (orientation(vPointOnHull, vEndpoint, points[i]) == -1))
                        vEndpoint = points[i];
                }
                vPointOnHull = vEndpoint;
            }
            while (vEndpoint != hull[0]);

            return hull;
        }
        private static int orientation(Point p1, Point p2, Point p)
        {
            // Determinant
            int Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);

            if (Orin > 0)
                return -1; //          (* Orientaion is to the left-hand side  *)
            if (Orin < 0)
                return 1; // (* Orientaion is to the right-hand side *)

            return 0; //  (* Orientaion is neutral aka collinear  *)
        }

        private void open_image()
        {
            openFileDialog.InitialDirectory = "Desktop";
            openFileDialog.Filter = "Изображение (JPEG) (*.jpg)|*.jpg|Изображение (BMP) (*.bmp)|*.bmp|Изображение (PNG) (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image checkImage = Image.FromFile(openFileDialog.FileName);
                origImage = checkImage;
                originalPictureBox.Image = origImage;
                segmentPictureBox.Image = null;
                pointPictureBox.Image = null;
                trianglePictureBox.Image = null;
                resultPictureBox.Image = null;
                redPictureBox.Image = null;
                greenPictureBox.Image = null;
                bluePictureBox.Image = null;
                brightnessTextBox.Text = "Введите значения яркостей";
                limitTextBox.Text = "Введите диапазон";
                triangles.Clear();
                listOfShortCuts.Clear();
                points.Clear();
            }
            else
                MessageBox.Show("Не удалось загрузить файл.\nПопробуйте снова.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private Bitmap get_image()
        {
            if (originalPictureBox.Image != null)
            {
                Bitmap img = new Bitmap(originalPictureBox.Image);
                return img;
            }
            else
            {
                MessageBox.Show("Изображение не загружено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Color square_color(Bitmap picture, int x, int y, int side)
        {
            int red = 0, green = 0, blue = 0;
            int i = 0, j = 0;
            int counter = 0;
            for (i = x; i < (x + side) && i < picture.Width; i++)
            {
                for (j = y; j < (y + side) && j < picture.Height; j++)
                {
                    red += picture.GetPixel(i, j).R;
                    green += picture.GetPixel(i, j).G;
                    blue += picture.GetPixel(i, j).B;
                    counter++;
                }
            }
            if (counter != 0)
            {
                red /= counter;
                green /= counter;
                blue /= counter;
            }
           return Color.FromArgb(red, green, blue);
        }
        public Color average_color(Color c1, Color c2, Color c3, Color c4)
        {
            int red = 0, green = 0, blue = 0;
            red = (c1.R + c2.R + c3.R + c4.R) / 4;
            green = (c1.G + c2.G + c3.G + c4.G) / 4;
            blue = (c1.B + c2.B + c3.B + c4.B) / 4;
            
            return Color.FromArgb(red, green, blue);
        }
        public float color_to_brightness(Color col)
        {
            return (11 * col.B + 30 * col.R + 59 * col.G) / 100;
        }
        public Color brightness_to_color(int br, Color col)
        {
            float x = (float)br / (float)255;
            int r = (int)(x * col.R);
            int g = (int)(x * col.G);
            int b = (int)(x * col.B);
            return Color.FromArgb(r, g, b);
        }
        public Color brightness_to_average_br(int br)
        {
            return Color.FromArgb(br, br, br);
        }
        public Color red_color(Color c1)
        {
            int red = c1.R;
            return Color.FromArgb(red, 0, 0);
        }
        public Color green_color(Color c1)
        {
            int green = c1.G;
            return Color.FromArgb(0, green, 0);
        }
        public Color blue_color(Color c1)
        {
            int blue = c1.B;
            return Color.FromArgb(0, 0, blue);
        }

        private Square get_area(MouseEventArgs e)
        {
            Square sq = new Square();
            int x = e.X / delta;
            int y = e.Y / delta;
            sq.x = delta*x;
            sq.y = delta*y;
            sq.side = delta;

            return sq;
        }
        private Bitmap cut(Bitmap picture, Square sq)
        {
            Bitmap res = new Bitmap(sq.side, sq.side);
            for (int j = 0; j < sq.side; j++)
            {
                for (int i = 0; i < sq.side; i++)
                {
                    res.SetPixel(i, j, picture.GetPixel(sq.x + i, sq.y + j));
                }
            }

            return res;
        }
        private Bitmap zoom(Bitmap picture, int coeff)
        {
            Bitmap res = new Bitmap(picture.Width*coeff, picture.Height*coeff);
           // Console.WriteLine("Received bitmap {" + picture.Width + ", " + picture.Height + "}");
           // Console.WriteLine("Constructed bitmap {" + res.Width + ", " + res.Height + "}");
            for (int j = 0; j < res.Height - coeff; j+=coeff)
            {
                for (int i = 0; i < res.Width - coeff; i+=coeff)
                {
                  //  Console.WriteLine("j=" + j + ", i=" + i);
                  //  Console.WriteLine();
                    for (int k = j; k < coeff + j; k++)
                    {
                        for (int l = i; l < coeff+ i; l++)
                        {
                          //  Console.WriteLine( "k=" + k + ", l=" + l);
                            res.SetPixel(l, k, picture.GetPixel(i/coeff, j/coeff));
                        }
                    }
                   // Console.WriteLine("************");
                }
            }

            return res;
        }        

        public List<Square> make_squares(Bitmap picture)
        {
            delta = (int)fragmentationLimit.Value;
            bright = (int)brightnessLimit.Value;
            int l = 1;
            //первоначальный массив точек-квадратов
            List<Square> squares = new List<Square>();
            for (int j = 0; j < picture.Height; j++)
            {
                for (int i = 0; i < picture.Width; i ++)
                {
                    Square square = new Square();
                    square.x = i;
                    square.y = j;
                    square.side = 1;
                    square.color = picture.GetPixel(i, j);
                    square.is_processed = false;
                    squares.Add(square);
                }
            }

            List<Square> processed = new List<Square>();
            int side_size = 1;
            while(side_size < picture.Width/2)
            {
                side_size *= 2;
               // Console.Write("\nСторона: " + side_size + ";");
                List<Square> new_squares = new List<Square>();
                List<Square> seen = new List<Square>();

                for (int i = 0; i + 1 < squares.Count; i++)
                {
                    bool merge = false;
                    Square sq1 = squares[i], sq2 = squares[i + 1];
                    sq1.is_processed = true;
                    if (sq2.x == (sq1.x + sq1.side) && sq2.y == sq1.y && sq2.is_processed == false)
                    {
                        float br1 = color_to_brightness(sq1.color);
                        float br2 = color_to_brightness(sq2.color);
                        if (Math.Abs(br1 - br2) >= bright)
                        {
                            seen.Add(sq1);
                            continue;
                        }

                        for (int j = i + 1; j + 1 < squares.Count && squares[j].y <= sq1.y+sq1.side; j++)
                        {
                            Square sq3 = squares[j], sq4 = squares[j + 1];

                            if (sq1.x == sq3.x && sq3.y == sq1.y + sq1.side && sq3.is_processed == false)
                            {
                                if (sq4.x == sq1.x + sq1.side && sq4.y == sq1.y + sq1.side && sq4.is_processed == false)
                                {
                                    float br3 = color_to_brightness(sq3.color);
                                    float br4 = color_to_brightness(sq4.color);
                                    if (Math.Abs(br1 - br3) >= bright)
                                    {
                                        if (Math.Abs(br1 - br4) >= bright)
                                        {
                                            break;
                                        }
                                    } 

                                   // float average_br = (br1 + br2 + br3 + br4) / 4;
                                   // if (br1 < bright)
                                    //{
                                        //тогда слепляй квадратики в большой:
                                        merge = true;
                                        Square new_sq = new Square();
                                        new_sq.x = sq1.x;
                                        new_sq.y = sq1.y;
                                        new_sq.side = side_size;
                                        new_sq.color = average_color(sq1.color, sq2.color, sq3.color, sq4.color);
                                        new_sq.is_processed = false;
                                        new_squares.Add(new_sq);

                                        sq2.is_processed = true;
                                        sq3.is_processed = true;
                                        sq4.is_processed = true;
                                        i++;
                                        break;
                                   // }
                                }
                            }
                        }
                        if (!merge)
                        {
                            seen.Add(sq1);
                        }
                    } else
                    {
                        seen.Add(sq1);
                    }
                }
                //скидываем мелкие обработанные (необъединенные)
                processed.AddRange(seen);
                //переходим к обработке более крупных квадратов
                squares = new_squares;                      
                if (new_squares.Count == 0)
                {
                    break;
                }
                l++;
            }
            //добавляем в 
            processed.AddRange(squares);
            // brightnessTextBox.Text = "Кв. " + (processed.Count).ToString();
            return processed;
        }
        private Bitmap draw_squares(Bitmap picture, List<Square> s)
        {
            Bitmap result = (Bitmap)picture;
            Point center = center_of_bitmap(picture);
            Point origin = origin_of_segment(center, picture);

            foreach (Square sq in s)
            {
                for (int j = sq.y; j < sq.side+sq.y && j < picture.Height; j++)
                {
                    for (int i = sq.x; i < sq.side+sq.x && i < picture.Width; i ++)
                    {
                        result.SetPixel(i, j, sq.color);
                    }
                }
            }
            return result;
        }   
        private void sim_image(Bitmap picture)
        {
            if (picture != null)
            {
               List<Square> squares = make_squares(picture);
               bluePictureBox.Image = draw_squares(picture, squares);
            }
        }

        private Bitmap process_area_col(List<int> br, Bitmap area)
        {
             Bitmap res = new Bitmap(area);
             for (int y = 0; y < area.Height - 1; y++)
             {
                 for (int x = 0; x < area.Width - 1; x++)
                 {
                     Color col = area.GetPixel(x, y);
                     int brt = (int)color_to_brightness(col);
                   
                     for (int i = 0; i < br.Count; i++)
                     { 
                         if (brt < br[i] && i > 0)
                         {
                             int av_br = (br[i - 1] + br[i]) / 2;
                             res.SetPixel(x, y, brightness_to_color(av_br, col));
                             break;
                         }
                         else
                        {
                            res.SetPixel(x, y, Color.White);
                        }
                     }
                 }
             }

             return res;
         }
        private Bitmap process_area_br(List<int> br, Bitmap area)
        {
            Bitmap res = new Bitmap(area);
            for (int y = 0; y < area.Height - 1; y++)
            {
                for (int x = 0; x < area.Width - 1; x++)
                {
                    Color col = area.GetPixel(x, y);
                    int brt = (int)color_to_brightness(col);

                    for (int i = 0; i < br.Count; i++)
                    {
                        if (brt < br[i])
                        {
                            int av_br = (br[i - 1] + br[i]) / 2;
                            res.SetPixel(x, y, Color.FromArgb(av_br, av_br, av_br));
                            break;
                        }
                    }
                }
            }

            return res;
        }

        private Point center_of_bitmap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                Point center = new Point(bitmap.Width / 2, bitmap.Height / 2);
                return center;
            }
            return new Point(0, 0);
        }
        private Point origin_of_segment(Point center, Bitmap segment)
        {
            if (segment != null)
            {
                Point origin = new Point(center.X - segment.Width / 2, center.Y - segment.Height / 2);
            return origin;
            }
            return new Point(0, 0);
        }

        private void draw_area(PictureBox box, Bitmap area, bool draw_background)
        {
            Bitmap picture = new Bitmap(box.Width, box.Height);
            if (draw_background)
            {
                //Bitmap picture = (Bitmap)box.Image;
                for (int y = 0; y < picture.Height - 1; y++)
                 {
                     for (int x = 0; x < picture.Width - 1; x++)
                     {
                         picture.SetPixel(x, y, Color.White);
                     }
                 }
            }

            for (int j = 0; j < area.Height - 1 ; j++)
            {
                for (int i = 0; i < area.Width - 1; i++)
                {
                    if (i >= 0 && i < picture.Width && j >= 0 && j < picture.Height)
                    {
                        picture.SetPixel(i, j, area.GetPixel(i, j));
                    }
                }
            }
            box.Image = picture;
        }
        private void draw_areas(PictureBox box_col, PictureBox box_br, PictureBox box_R, PictureBox box_G, PictureBox box_B, Bitmap area_col, Bitmap area_br)
        {
            Bitmap picture_col = new Bitmap(box_col.Width, box_col.Height);
            Bitmap picture_br = new Bitmap(box_col.Width, box_col.Height);
            Bitmap picture_R = new Bitmap(box_col.Width, box_col.Height);
            Bitmap picture_G = new Bitmap(box_col.Width, box_col.Height);
            Bitmap picture_B = new Bitmap(box_col.Width, box_col.Height);
            //Bitmap picture = (Bitmap)box.Image;
            for (int y = 0; y < picture_col.Height - 1; y++)
            {
                for (int x = 0; x < picture_col.Width - 1; x++)
                {
                    picture_col.SetPixel(x, y, Color.White);
                    picture_br.SetPixel(x, y, Color.White);
                    picture_R.SetPixel(x, y, Color.White);
                    picture_G.SetPixel(x, y, Color.White);
                    picture_B.SetPixel(x, y, Color.White);
                }
            }

            Point center = center_of_bitmap(picture_col);
            Point origin = origin_of_segment(center, segment_bmp);

            for (int j = origin.Y; j < segment_bmp.Height - 1 + origin.Y; j++)
            {
                for (int i = origin.X; i < segment_bmp.Width - 1 + origin.X; i++)
                {
                    if (i >= 0 && i < area_col.Width && j >= 0 && j < area_col.Height)
                    { 
                        picture_col.SetPixel(i, j, area_col.GetPixel(i, j));
                        picture_br.SetPixel(i, j, area_br.GetPixel(i, j));
                        picture_R.SetPixel(i, j, red_color(area_col.GetPixel(i, j)));
                        picture_G.SetPixel(i, j, green_color(area_col.GetPixel(i, j)));
                        picture_B.SetPixel(i, j, blue_color(area_col.GetPixel(i, j)));
                    }
                }
            }

            box_col.Image = picture_col;
            box_br.Image = picture_br;
            box_R.Image = picture_R;
            box_G.Image = picture_G;
            box_B.Image = picture_B;
        }

            
        public ShortCut twoPointsInLeft(ref List<Pivot> points)
        {
            int maxX1, maxX2, maxY1, maxY2;
            maxX1 = points[0].koordX; maxX2 = points[1].koordX; maxY1 = points[0].koordY; maxY2 = points[1].koordY;

            for (int i = 1; i < points.Count; i++)
            {
                if (((Math.Pow(points[i].koordX, 2) + Math.Pow(points[i].koordY, 2)) < (Math.Pow(maxX1, 2) + Math.Pow(maxY1, 2)))&&((points[i].koordY != maxY2) && (points[i].koordX != maxX2)))                
                {
                    maxX1 = points[i].koordX;
                    maxY1 = points[i].koordY;
                }
            }

            for (int i = 1; i < points.Count; i++)
            {
                if (((Math.Pow(points[i].koordX, 2) + Math.Pow(points[i].koordY, 2)) < (Math.Pow(maxX2, 2) + Math.Pow(maxY2, 2))) && ((points[i].koordY != maxY1) && (points[i].koordX != maxX1)))
                {
                    maxX2 = points[i].koordX;
                    maxY2 = points[i].koordY;
                }
            }

            ShortCut ShortCutInLeft = new ShortCut(maxX1, maxX2, maxY1, maxY2);
            return ShortCutInLeft;
        }
        public void triangulation(ref Bitmap newImage, ref List<ShortCut> ListShortCuts, ref List<Pivot> points, int maxX1, int maxY1, int maxX2, int maxY2, ref List<Triangle> Triangles, int alpha)
        {
            ListShortCuts.Add(new ShortCut(maxX1, maxX2, maxY1, maxY2));
            double min = 2.0;

            int Check = 0;
            int x = 0;

            for (int i = 0; i < points.Count; i++)
            {
                if ((alpha != 0) && (clockwise(maxX1, maxY1, maxX2, maxY2, points[i].koordX, points[i].koordY) == alpha))
                    continue;

                double fs = Math.Pow(maxX1 - maxX2, 2) + Math.Pow(maxY1 - maxY2, 2);
                double fm = Math.Pow(maxX1 - points[i].koordX, 2) + Math.Pow(maxY1 - points[i].koordY, 2);
                double ms = Math.Pow(points[i].koordX - maxX2, 2) + Math.Pow(points[i].koordY - maxY2, 2);
                double curr = (-fs + fm + ms) / (2 * Math.Sqrt(fm * ms));

                if (curr < min)
                {
                    min = curr;
                    Check = 1;
                    x = i;
                }
            }

            if (Check == 1)
            {
                Pen blackPen = new Pen(Color.Black, 1);
                Graphics line = Graphics.FromImage(newImage);
                int ShortCutExist1 = 0;
                int ShortCutExist2 = 0;
                line.DrawLine(blackPen, maxX1, maxY1, maxX2, maxY2);

                for (int j = 0; j < ListShortCuts.Count; j++)
                {
                    if (((ListShortCuts[j].koordX1 == maxX1) && (ListShortCuts[j].koordY1 == maxY1) && (ListShortCuts[j].koordX2 == points[x].koordX) && (ListShortCuts[j].koordY2 == points[x].koordY)) || ((ListShortCuts[j].koordX2 == maxX1) && (ListShortCuts[j].koordY2 == maxY1) && (ListShortCuts[j].koordX1 == points[x].koordX) && (ListShortCuts[j].koordY1 == points[x].koordY)))
                        ShortCutExist1 = 1;                    
                }

                if (ShortCutExist1 != 1)
                    line.DrawLine(blackPen, maxX1, maxY1, points[x].koordX, points[x].koordY);                

                for (int j = 0; j < ListShortCuts.Count; j++)
                {
                    if (((ListShortCuts[j].koordX1 == maxX2) && (ListShortCuts[j].koordY1 == maxY2) && (ListShortCuts[j].koordX2 == points[x].koordX) && (ListShortCuts[j].koordY2 == points[x].koordY)) || ((ListShortCuts[j].koordX2 == maxX2) && (ListShortCuts[j].koordY2 == maxY2) && (ListShortCuts[j].koordX1 == points[x].koordX) && (ListShortCuts[j].koordY1 == points[x].koordY)))
                        ShortCutExist2 = 1;
                }

                if (ShortCutExist2 != 1)
                    line.DrawLine(blackPen, maxX2, maxY2, points[x].koordX, points[x].koordY);

                Triangles.Add(new Triangle(maxX1, maxX2, points[x].koordX, maxY1, maxY2, points[x].koordY));

                if (ShortCutExist2 != 1)
                    triangulation(ref newImage, ref ListShortCuts, ref points, maxX2, maxY2, points[x].koordX, points[x].koordY, ref Triangles, (clockwise(maxX1, maxY1, maxX2, maxY2, points[x].koordX, points[x].koordY)));

                if (ShortCutExist1 != 1)
                    triangulation(ref newImage, ref ListShortCuts, ref points, points[x].koordX, points[x].koordY, maxX1, maxY1, ref Triangles, (clockwise(maxX1, maxY1, maxX2, maxY2, points[x].koordX, points[x].koordY)));
            }
            else
                return;
        }
        public int triangle_area(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return ((x2 - x1) * (y3 - y1)) - ((y2 - y1) * (x3 - x1));
        }
        public int clockwise(int x1, int y1, int x2, int y2, int x3, int y3)//тройка чисел по часовой стрелке
        {
            if ((triangle_area(x1, y1, x2, y2, x3, y3)) < 0)
                return 1;
            else
                if ((triangle_area(x1, y1, x2, y2, x3, y3)) > 0)
                    return -1;
            return 0;
        }       
        public void deletingTriangles(ref List<Triangle> Triangles)
        {
            for (int i = 0; i < Triangles.Count - 1; i++)
                for (int j = i + 1; j < Triangles.Count; j++)
                {
                    if (((Triangles[i].koordX1 == Triangles[j].koordX1) && (Triangles[i].koordY1 == Triangles[j].koordY1)) || ((Triangles[i].koordX1 == Triangles[j].koordX2) && (Triangles[i].koordY1 == Triangles[j].koordY2)) || ((Triangles[i].koordX1 == Triangles[j].koordX3) && (Triangles[i].koordY1 == Triangles[j].koordY3)))
                    {
                        if (((Triangles[i].koordX2 == Triangles[j].koordX1) && (Triangles[i].koordY2 == Triangles[j].koordY1)) || ((Triangles[i].koordX2 == Triangles[j].koordX2) && (Triangles[i].koordY2 == Triangles[j].koordY2)) || ((Triangles[i].koordX2 == Triangles[j].koordX3) && (Triangles[i].koordY2 == Triangles[j].koordY3)))
                        {
                            if (((Triangles[i].koordX3 == Triangles[j].koordX1) && (Triangles[i].koordY3 == Triangles[j].koordY1)) || ((Triangles[i].koordX3 == Triangles[j].koordX2) && (Triangles[i].koordY3 == Triangles[j].koordY2)) || ((Triangles[i].koordX3 == Triangles[j].koordX3) && (Triangles[i].koordY3 == Triangles[j].koordY3)))
                            {
                                //если совпали треугольники по вершинам, то удалить один из них, и изменить индексы
                                Triangles.RemoveAt(j);//треугольник удален - общее число уменьшилось
                                j--;
                            }
                        }
                    }
                }
        }

        private List<int> create_brightness_limits(TextBox textbox)
        {
            List<int> brightnesses = new List<int>();
            brightnesses.Add(0);
            
            string set = textbox.Lines[0];
            string[] input = set.Split(' ');

            foreach (string str in input)
            {
                int x = 0;
                if (Int32.TryParse(str, out x))
                {
                    brightnesses.Add(x);
                }
            }
            brightnesses.Add(255);
            
            //удалить элементы, превышающие значение 255
            for (int k = 0; k < brightnesses.Count; k++)
            {
                if (brightnesses[k] > 255)
                {
                    brightnesses.Remove(brightnesses[k]);
                }
            }

            brightnesses.Sort();
            //удалить повторы
            List<int> brghts = brightnesses.Distinct().ToList();

            for (int i = 0; i < brghts.Count; i++)
            { 
                Console.WriteLine(brghts[i] + " ");
            }
            return brghts;
        }
        private List<int> create_limit(TextBox textbox)
        {
            List<int> brightnesses = new List<int>();

            string set = textbox.Lines[0];
            string[] input = set.Split(' ');

            foreach (string str in input)
            {
                int x = 0;
                if (Int32.TryParse(str, out x))
                {
                    brightnesses.Add(x);
                }
            }

            //удалить элементы, превышающие значение 255
            for (int k = 0; k < brightnesses.Count; k++)
            {
                if (brightnesses[k] > 255)
                {
                    brightnesses.Remove(brightnesses[k]);
                }
            }

            brightnesses.Sort();
            //удалить повторы
            List<int> brghts = brightnesses.Distinct().ToList();
            if (brghts.Count > 0 && brghts.Count < 2)
            {
                brghts.Add(255);
            }
            else if (brghts.Count == 0 && brghts.Count < 2)
            {
                brghts.Add(0);
                brghts.Add(255);
            }

            Console.WriteLine("\nДиапазон: ");
            for (int i = 0; i < brghts.Count; i++)
            {
                Console.WriteLine(brghts[i] + " ");
            }
            return brghts;
        }
        

        private Image init_pictureBox(PictureBox box)
        {
            Bitmap bimp = new Bitmap(box.Width, box.Height);
            for (int y = 0; y < bimp.Height - 1; y++)
            {
                for (int x = 0; x < bimp.Width - 1; x++)
                {
                    bimp.SetPixel(x, y, Color.White);
                }
            }
           return bimp;
        }        
        private void switch_pictureboxes()
        {
            if (bluePictureBox.Image != null || resultPictureBox.Image != null)
            {
                redPictureBox.Image = init_pictureBox(redPictureBox);
                greenPictureBox.Image = null;
                bluePictureBox.Image = null;
                trianglePictureBox.Image = null;
                resultPictureBox.Image = null;
            }
        }

        private Pivot converter(Pivot p)
        {
            Pivot res = p;
            res.koordX = p.koordX/(int)zoomCoeff.Value + koordinateXinImage;
            res.koordY = p.koordY/(int)zoomCoeff.Value + koordinateYinImage;
            Console.WriteLine("Coord in original image: {" + res.koordX + "; " + res.koordY + "}");
            return res;
        }
  
        private void draw_custom_pivot(Bitmap segment, Bitmap add_segment, Pivot p)
        {
            int zc = (int)zoomCoeff.Value;
            int origin_x = (p.koordX - koordinateXinImage)*zc;
            int origin_y = (p.koordY - koordinateYinImage)*zc;

            for (int j = origin_y; j <= origin_y+zc && j < segment.Height ; j++)
            {
                for (int i = origin_x; i <= origin_x+zc && i < segment.Width; i++)
                {
                    segment.SetPixel(i, j, Color.LimeGreen);
                    add_segment.SetPixel(i, j, Color.Black);
                }
            }
        }

        private void triangulate(PictureBox triangle_box)
        {
            if (originalPictureBox.Image == null)
                MessageBox.Show("Изображение не загружено.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (redPictureBox.Image == null || points.Count == 0)
                MessageBox.Show("Прежде чем производить триангуляцию, необходимо найти (установить) опорные точки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ShortCut StartCut = twoPointsInLeft(ref points);
                List<ShortCut> ListShortCuts = new List<ShortCut>();
                Bitmap newImage;
                if (triangle_box.Image != null)
                    newImage = (Bitmap)(triangle_box.Image);
                else 
                    newImage = new Bitmap(triangle_box.Width, triangle_box.Height);
//--------------------------------------------------------------------------------------
                triangles.Clear();
//--------------------------------------------------------------------------------------
                triangulation(ref newImage, ref ListShortCuts, ref points, StartCut.koordX1, StartCut.koordY1, StartCut.koordX2, StartCut.koordY2, ref triangles, 0);
                listOfShortCuts = ListShortCuts;
                triangle_box.Image = newImage;
                deletingTriangles(ref triangles);
                for (int i = 0; i < ListShortCuts.Count; i++)
                {
                    ListShortCuts.RemoveAt(i);
                }
            }
        }
        private void paint(PictureBox res_box)
        {
            if (originalPictureBox.Image == null)
                MessageBox.Show("Изображение не загружено.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Bitmap newimg = new Bitmap(imageForTriangulation.Width, imageForTriangulation.Height);
                Graphics graphics = Graphics.FromImage(newimg);
                GraphicsPath GP = new GraphicsPath();
                Point[] Path = new Point[3];
                Bitmap thirdPicture = new Bitmap((Image)imageForTriangulation, imageForTriangulation.Width, imageForTriangulation.Height);

                for (int i = 0; i < triangles.Count; i++)
                {
                    Path[0] = new Point(triangles[i].koordX1, triangles[i].koordY1);
                    Path[1] = new Point(triangles[i].koordX2, triangles[i].koordY2);
                    Path[2] = new Point(triangles[i].koordX3, triangles[i].koordY3);

                    GP.StartFigure();
                    GP.AddLine(Path[0], Path[1]);
                    GP.AddLine(Path[2], Path[1]);
                    GP.AddLine(Path[0], Path[2]);
                    GP.CloseFigure();

                    using (var pgb = new PathGradientBrush(GP))
                    {
                        int averageR = (thirdPicture.GetPixel(triangles[i].koordX1, triangles[i].koordY1).R + thirdPicture.GetPixel(triangles[i].koordX2, triangles[i].koordY2).R + thirdPicture.GetPixel(triangles[i].koordX3, triangles[i].koordY3).R) / 3;
                        int averageG = (thirdPicture.GetPixel(triangles[i].koordX1, triangles[i].koordY1).G + thirdPicture.GetPixel(triangles[i].koordX2, triangles[i].koordY2).G + thirdPicture.GetPixel(triangles[i].koordX3, triangles[i].koordY3).G) / 3;
                        int averageB = (thirdPicture.GetPixel(triangles[i].koordX1, triangles[i].koordY1).B + thirdPicture.GetPixel(triangles[i].koordX2, triangles[i].koordY2).B + thirdPicture.GetPixel(triangles[i].koordX3, triangles[i].koordY3).B) / 3;
                        Color centerCol = Color.FromArgb((byte)averageR, (byte)averageG, (byte)averageB);

                        pgb.CenterPoint = new Point((triangles[i].koordX1 + triangles[i].koordX2 + triangles[i].koordX3) / 3, (triangles[i].koordY1 + triangles[i].koordY2 + triangles[i].koordY3) / 3);
                        pgb.CenterColor = thirdPicture.GetPixel((int)pgb.CenterPoint.X, (int)pgb.CenterPoint.Y);

                        pgb.SurroundColors = new Color[3] { thirdPicture.GetPixel(triangles[i].koordX1, triangles[i].koordY1), thirdPicture.GetPixel(triangles[i].koordX2, triangles[i].koordY2), thirdPicture.GetPixel(triangles[i].koordX3, triangles[i].koordY3) };
                        pgb.SetBlendTriangularShape(1.0f, 0.0f);

                        graphics.FillPolygon(pgb, Path);
                        //
                        res_box.Image = newimg;
                        res_box.Refresh();
                        pgb.Dispose();
                    }
                }
            }
        }
        private void clean()
        {
            clean(true);
        }
        private void clean(bool delete_pointPB)
        {
            if (originalPictureBox.Image == null)            
                MessageBox.Show("Изображение не загружено.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                segmentPictureBox.Image = null; 
                if (delete_pointPB) 
                    pointPictureBox.Image = null;
                trianglePictureBox.Image = null;
                resultPictureBox.Image = null;
                redPictureBox.Image = null;
                greenPictureBox.Image = null;
                bluePictureBox.Image = null;

                segment_bmp = null;
                imageForTriangulation = null;

                brightnessTextBox.Text = "Введите значения яркостей";
                limitTextBox.Text = "Введите диапазон";
                infoTextBox.Clear();

                triangles.Clear();
                listOfShortCuts.Clear();
                if (delete_pointPB)
                    points.Clear();
            }
        }
        private void save_image()
        {
            if (originalPictureBox.Image != null && redPictureBox.Image != null)
            {
                Bitmap bitmap1 = new Bitmap(redPictureBox.Image); // сохранение с копированием (созданием нового объекта)
                //Bitmap bitmap1 = (Bitmap)resultImageBox.Image; // сохранение без копирования
                SaveFileDialog saveFD = new SaveFileDialog();
                saveFD.DefaultExt = "jpg";
                saveFD.Filter = "Изображение (JPEG) (*.jpg)|*.jpg|Изображение (BMP) (*.bmp)|*.bmp|Изображение (PNG) (*.png)|*.png";
                if (saveFD.ShowDialog() == DialogResult.OK)
                    bitmap1.Save(saveFD.FileName);
            }
            else if (originalPictureBox.Image != null && redPictureBox.Image == null)
                MessageBox.Show("Прежде чем сохранить результат, необходимо внести изменения.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Изображение не загружено.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void addPointTo(Point e, PictureBox ptPB, PictureBox trigPB, PictureBox paintPB)
        {
            if (ptPB.Image != null && points.Count == 0)
                ptPB.Image = init_pictureBox(ptPB);
            bool process = false;
            if (!antiAliasСheckBox.Checked)
            {
                ////
                Point center = center_of_bitmap((Bitmap)segmentPictureBox.Image);
                Point origin = origin_of_segment(center, segment_bmp);
                if ((e.X > origin.X && e.X < origin.X + segment_bmp.Width) && (e.Y > origin.Y && e.Y < origin.Y + segment_bmp.Height))
                    process = true;
            }
            else if (originalPictureBox.Image != null && segmentPictureBox.Image != null)
                process = true;

            if (process)
            {
                if (e.X < segmentPictureBox.Image.Width && e.Y < segmentPictureBox.Image.Height)
                {
                    if (points.Count == 0) switch_pictureboxes();
                    Bitmap orig_pnts = (Bitmap)(segmentPictureBox.Image);
                    Bitmap pnts = (Bitmap)(ptPB.Image);

                    Pivot p = new Pivot(e.X, e.Y, imageForTriangulation.GetPixel(e.X, e.Y));
                    p = converter(p);
                    draw_custom_pivot(orig_pnts, pnts, p);
                    points.Add(p);

                    //удалить повторяющиеся точки
                    List<Pivot> points_without_doubles = points.Distinct().ToList();
                    points.Clear();
                    points = points_without_doubles;


                    if (points.Count == 1)
                    {
                        Bitmap dyn_triang = (Bitmap)(trigPB.Image);
                        dyn_triang.SetPixel(e.X, e.Y, Color.Black);
                        trigPB.Image = dyn_triang;
                    }
                    if (points.Count == 2)
                    {
                        Bitmap dyn_triang = (Bitmap)(trigPB.Image);
                        Pen blackPen = new Pen(Color.Black, 1);
                        int x1 = points_without_doubles[0].koordX;
                        int x2 = points_without_doubles[1].koordX;
                        int y1 = points_without_doubles[0].koordY;
                        int y2 = points_without_doubles[1].koordY;
                        using (var graphics = Graphics.FromImage(dyn_triang))
                        {
                            graphics.DrawLine(blackPen, x1, y1, x2, y2);
                        }
                        trigPB.Image = dyn_triang;
                    }
                    if (points.Count >= 3)
                    {
                        trigPB.Image = init_pictureBox(trigPB);
                        triangulate(trigPB);
                        paint(paintPB);
                    }

                    int N = points.Count; // число ОТ
                    List<Point> hull = convexHull(points);
                    int convex_hull = hull.Count; // число точек на внешней границе триангуляции
                    int count_of_triangles = 2 * N - convex_hull - 2; //число треугольников триангуляции Делоне
                   /* if (points.Count == 1 || points.Count == 2)
                        infoTextBox.Text = "Число ОТ = " + N + ".   Число треугольников = " + triangles.Count + ".   Ожидаемое число = 0";
                    else
                    {
                        infoTextBox.Text = "Число ОТ = " + N + ".   Число треугольников = " + triangles.Count + ".   Ожидаемое число = " + count_of_triangles;
                        // brightnessTextBox.Text = "2*" + N + "- " + convex_hull + " -2 = " + count_of_triangles;
                    }*/
                    segmentPictureBox.Image = orig_pnts;
                    ptPB.Image = pnts;
                }
            }
        }

        //кнопки, скроллбары и пикчербоксы: клики
        private void segmentPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (segmentPictureBox.Image == null)
            {
                return;
            }
            Point p = new Point(e.X, e.Y);
            addPointTo(p, redPictureBox, greenPictureBox, bluePictureBox);           
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            open_image();
            Triangulator trg = new Triangulator();
        }
        private void triangleButton_Click(object sender, EventArgs e)
        {
            if (trianglePictureBox.Image != null)
                trianglePictureBox.Image = null;
            triangulate(trianglePictureBox);
        }
        private void paintButton_Click(object sender, EventArgs e)
        {
            if (trianglePictureBox.Image != null && points.Count >= 3)
                paint(resultPictureBox);
            else
                MessageBox.Show("Прежде чем закрашивать, необходимо произвести триангуляцию.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void processButton_Click(object sender, EventArgs e)
        {
            if (antiAliasСheckBox.Checked)
            {
                MessageBox.Show("Невозможно произвести обработку при выделении сегмента со сглаживанием.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (points.Count != 0)
                {
                    MessageBox.Show("Необходимо произвести очистку.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clean();
                }
                if (brightnessTextBox.TextLength != 0)
                {
                    if (segment_bmp != null && imageForTriangulation != null)
                    {
                        Bitmap proc_col_img = process_area_col(create_brightness_limits(brightnessTextBox), imageForTriangulation);
                        Bitmap proc_brght_img = process_area_br(create_brightness_limits(brightnessTextBox), imageForTriangulation);
                        draw_areas(trianglePictureBox, resultPictureBox, redPictureBox, greenPictureBox, bluePictureBox, proc_col_img, proc_brght_img);
                    }
                    else
                        MessageBox.Show("Выберите сегмент для обработки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Введите значения яркостей.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void limitButton_Click(object sender, EventArgs e)
        {
            if (limitTextBox.TextLength != 0)
            {
                List<int> limit = create_limit(limitTextBox);
                Bitmap bmpe = process_area_col(limit, segment_bmp);

                draw_area(pointPictureBox, bmpe, true);
            }
            else
                MessageBox.Show("Введите диапазон яркостей для обработки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void simButtonClick(object sender, EventArgs e)
        {
            if (imageForTriangulation == null)
                sim_image(get_image());
            else if (originalPictureBox.Image == null)
                MessageBox.Show("Изображение не загружено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                sim_image(imageForTriangulation);
        }
        private void cleanButton_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            save_image();
        }
        private void skoButton_Click(object sender, EventArgs e)
        {
            if (originalPictureBox.Image == null)
            {
                MessageBox.Show("Изображение не загружено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (segmentPictureBox.Image == null)
            {
                MessageBox.Show("Выберите сегмент для обработки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (resultPictureBox.Image == null)
            {
                MessageBox.Show("Сначала необходимо произвести обработку.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Matrix origiginal_pic = new Matrix((Bitmap)segmentPictureBox.Image);
                Matrix processed_pic = new Matrix((Bitmap)resultPictureBox.Image);
                Matrix res_matrix = origiginal_pic.resultMatrix(processed_pic);
                double sko = res_matrix.sko();
                infoTextBox.Text = ("СКО = " + sko);
            }
        }

        private void zoomCoeffTrackBar_Scroll(object sender, EventArgs e)
        {
            zoomCoeff.Value = zoomCoeffTrackBar.Value;
            redraw(end_click_x, end_click_y);
        }
        private void zoomCoeff_ValueChanged(object sender, EventArgs e)
        {
            zoomCoeffTrackBar.Value = (int)zoomCoeff.Value;
        }

        private void brightnessTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            brightnessTextBox.Text = "";
        }
        private void limitTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            limitTextBox.Text = "";
        }

    }
}
