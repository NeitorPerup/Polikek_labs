using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mii_Labs_1.Models;

namespace Mii_Labs_1
{
    public partial class Formmain : Form
    {
        private const int DivisionsNumberX = 10;
        private const int DivisionsNumberY = 4;

        private int DivisionsLenX;
        private int DivisionsLenY;

        private int ValueOfDivisionX;
        private double ValueOfDivisionY;

        private int FullAdditionalHeight;

        //Длина стрелки
        private const int ARR_LEN = 10;

        private Graphics graphics;

        public Formmain()
        {
            InitializeComponent();
            textBoxA.Text = "10";
            textBoxB.Text = "30";
            textBoxC.Text = "50";
            textBoxD.Text = "70";
        }

        private void DrawAxises(Graphics graphics)
        {
            DrawXAxis(graphics);
            DrawYAxis(graphics);
        }

        private void DrawXAxis(Graphics g)
        {
            if (ValueOfDivisionX == 0) throw new Exception("Найс на 0 делим");

            Point start = new Point(30, pictureBox.Height - 30);
            Point end = new Point(pictureBox.Size.Width, start.Y);
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLine(Pens.Black, end.X, end.Y, end.X - ARR_LEN, end.Y - 5);
            g.DrawLine(Pens.Black, end.X, end.Y, end.X - ARR_LEN, end.Y + 5);

            //Деления в положительном направлении оси
            DivisionsLenX = (pictureBox.Width - 15) / DivisionsNumberX; // длина 1 деления
            int oneDivisionPixel = 4;
            for (int i = 0; i < DivisionsNumberX; i++)
            {
                int x = start.X + DivisionsLenX * i;
                g.DrawLine(Pens.Black, x, start.Y - oneDivisionPixel, x, start.Y + oneDivisionPixel);
                DrawText(new Point(x, start.Y + 3), (i * ValueOfDivisionX).ToString(), g);
            }
        }

        //Рисование оси Y
        private void DrawYAxis(Graphics g)
        {
            Point start = new Point(30, pictureBox.Height - 30);
            Point end = new Point(start.X, 30);

            //Деления в положительном направлении оси
            DivisionsLenY = pictureBox.Height / DivisionsNumberY - 20; // длина 1 деления
            int oneDivisionPixel = 4;
            ValueOfDivisionY = 1.0 / DivisionsNumberY;
            for (int i = 1; i <= DivisionsNumberY ; i++)
            {
                int y = start.Y - DivisionsLenY * i;
                g.DrawLine(Pens.Black, 
                        start.X - oneDivisionPixel,
                        y, 
                        start.X + oneDivisionPixel,
                        y
                );
                DrawText(new Point(start.X - 15, y), (i * ValueOfDivisionY).ToString("f2"), g);

                if (i == DivisionsNumberY)
                    FullAdditionalHeight = y;
            }
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            end.Y -= ARR_LEN;
            g.DrawLine(Pens.Black, end.X, end.Y, end.X - 5, end.Y + ARR_LEN);
            g.DrawLine(Pens.Black, end.X, end.Y, end.X + 5, end.Y + ARR_LEN);
        }

        private void DrawText(Point point, string text, Graphics g, bool isYAxis = false)
        {
            var f = new Font(Font.FontFamily, 6);
            var size = g.MeasureString(text, f);
            var pt = isYAxis
                ? new PointF(point.X + 1, point.Y - size.Height / 2)
                : new PointF(point.X - size.Width / 2, point.Y + 1);
            var rect = new RectangleF(pt, size);
            g.DrawString(text, f, Brushes.Black, rect);
        }

        private int PointToCoordinate(int point)
        {
            if (ValueOfDivisionX == 0) throw new Exception("Найс на 0 делим");

            return (DivisionsLenX / ValueOfDivisionX) * point + 30;
        }

        private void DrawGraphic(Graphics g, Pen pen, TrapezePoints points, bool isDop = false)
        {
            int y1 = FullAdditionalHeight;
            int y2 = pictureBox.Height - 30;

            if (isDop)
            {
                int t = y1;
                y1 = y2;
                y2 = t;
            }

            g.DrawLine(pen,
                PointToCoordinate(points.A),
                y2,
                PointToCoordinate(points.B),
                y1);
            g.DrawLine(pen,
                PointToCoordinate(points.B),
                y1,
                PointToCoordinate(points.C),
                y1);
            g.DrawLine(pen,
                PointToCoordinate(points.C),
                y1,
                PointToCoordinate(points.D),
                y2);
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            TrapezePoints points = new TrapezePoints();
            int parser;
            int x = 0;

            if (!int.TryParse(textBoxA.Text, out parser))
            {
                MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            points.A = parser;
            if (!int.TryParse(textBoxB.Text, out parser))
            {
                MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            points.B = parser;
            if (!int.TryParse(textBoxC.Text, out parser))
            {
                MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            points.C = parser;
            if (!int.TryParse(textBoxD.Text, out parser))
            {
                MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            points.D = parser;

            if (!int.TryParse(textBoxX.Text, out x))
            {
                MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!points.CheckPoints())
            {
                MessageBox.Show("Неверные данные, значения точек должны увеличиваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            double affiliation = Logic.Affilation(points, x);
            textBoxAffiliate.Text = affiliation.ToString();
            textBoxAffiliateDop.Text = (1 - affiliation).ToString();

            ValueOfDivisionX = (points.D - 5) / (DivisionsNumberX - 3);

            if (graphics == null)
                graphics = pictureBox.CreateGraphics();
            graphics.Clear(Color.White);

            DrawAxises(graphics);
            DrawGraphic(graphics, Pens.Red, points);
            DrawGraphic(graphics, Pens.Green, points, true);
            graphics.DrawLine(Pens.Black,
                PointToCoordinate(x),
                FullAdditionalHeight,
                PointToCoordinate(x),
                pictureBox.Height - 30);
        }
    }
}
