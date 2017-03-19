using System;
using System.Drawing;
using System.Windows.Forms;

namespace Triangulation_
{
    public class Matrix
    {
        int rows;
        int columns;
        float[,] mtrx;
        public Matrix(int rows, int columns)
        {
            this.mtrx = new float[rows, columns];
            this.rows = rows;
            this.columns = columns;
        }
        public Matrix(Bitmap picture)
        {
            this.rows = picture.Height;
            this.columns = picture.Width;
            this.mtrx = new float[this.rows, this.columns];
            for (int i = 0; i < picture.Width; i++)
            {
                for (int j = 0; j < picture.Height; j++)
                {
                    Color curr_pix = picture.GetPixel(i, j);
                    float res = (11 * curr_pix.B + 30 * curr_pix.R + 59 * curr_pix.G) / 100;
                    this.mtrx[i, j] = res;
                }
            }

        }
        public Matrix resultMatrix(Matrix second_matrix)
        {
            Matrix result_matrix = new Matrix(this.rows, this.columns);
            if (this.rows != second_matrix.rows || this.columns != second_matrix.columns)
            {
                MessageBox.Show("Неизвестная ошибка.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < this.columns; i++)
                {
                    for (int j = 0; j < this.rows; j++)
                    {
                        result_matrix.mtrx[i, j] = this.mtrx[i, j] - second_matrix.mtrx[i, j];
                    }
                }
            }
            return result_matrix;
        }
        public double sko()
        {
            double res_sko = 0;
            double square_sum = 0;

            for (int i = 0; i < this.columns; i++)
            {
                for (int j = 0; j < this.rows; j++)
                {
                    square_sum += Math.Pow(this.mtrx[i, j], 2);
                }
            }

            res_sko = Math.Sqrt(square_sum / rows / columns);
            return res_sko;
        }
    }
}
