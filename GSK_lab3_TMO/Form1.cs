using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GSK_lab3_TMO
{
    public partial class Form1 : Form
    {
        Graphics gf;
        Pen DrawPen = new Pen(Color.Black, 1);
        private int type = 3;  // Переменная для хранения текущего значения type
        List<Point> VertexList = new List<Point>();
        Figure Figure = new Figure();
        List<Point> poligonA = new List<Point>();
        List<Point> poligonB = new List<Point>();
        int TMO;
        List<int> Xal = new List<int>();
        List<int> Xar = new List<int>();
        List<int> Xbl = new List<int>();
        List<int> Xbr = new List<int>();

        public Form1()
        {
            InitializeComponent();
            gf = pictureBox1.CreateGraphics(); //инициализация графики
        }

        // Обработчик события выбора цвета
        private void color_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (color_box.SelectedIndex) // выбор цвета
            {
                case 0:
                    DrawPen.Color = Color.Black;
                    break;
                case 1:
                    DrawPen.Color = Color.Red;
                    break;
                case 2:
                    DrawPen.Color = Color.Green;
                    break;
                case 3:
                    DrawPen.Color = Color.Blue;
                    break;
            }
        }

        // рисование линий
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int i = VertexList.Count;
            VertexList.Add(new Point() { X = e.X, Y = e.Y });

            // Проверка, можно ли еще рисовать (допускается только две фигуры)
            if (poligonA.Count > 0 && poligonB.Count > 0) return;

            // Отрисовка точки
            gf.DrawEllipse(DrawPen, e.X - 2, e.Y - 2, 5, 5);

            // В зависимости от типа фигуры рисуем линии
            switch (type)
            {
                case 0:
                    if (VertexList.Count != 3) return;

                    Figure.DrawT(gf, DrawPen, VertexList);
                    SavePolygon();

                    break;
                case 1:
                    if (VertexList.Count != 2) return;

                    Figure.DrawP(gf, DrawPen, VertexList);
                    SavePolygon();

                    break;
                case 2:
                    if (VertexList.Count != 2) return;

                    Figure.DrawK(gf, DrawPen, VertexList);
                    SavePolygon();

                    break;
                case 3:
                    if (VertexList.Count > 1)
                    {
                        gf.DrawLine(DrawPen, VertexList[i - 1], VertexList[i]);
                    }

                    if (e.Button == MouseButtons.Right) // Конец ввода
                    {
                        gf.DrawLine(DrawPen, VertexList[i], VertexList[0]);
                    }
                    break;
            }

            // Завершаем рисование фигуры по правому клику
            if (e.Button == MouseButtons.Right)
            {
                gf.DrawLine(DrawPen, VertexList[i], VertexList[0]);  // Замыкаем фигуру
                SavePolygon();
            }
        }

        public void SavePolygon()
        {
            Figure.VertexList = new List<Point>(VertexList);    // Сохраняем фигуру
            Figure.coloringAlgorithm(gf, DrawPen);

            if (poligonA.Count == 0)
            {
                poligonA = new List<Point>(VertexList); // Сохраняем первую фигуру
                SetPolygonEdges(poligonA, ref Xal, ref Xar);
            }
            else
            {
                poligonB = new List<Point>(VertexList); // Сохраняем вторую фигуру
                SetPolygonEdges(poligonB, ref Xbl, ref Xbr);
            }

            VertexList.Clear(); // Очищаем для нового набора точек
        }

        private void SetPolygonEdges(List<Point> polygon, ref List<int> leftEdges, ref List<int> rightEdges)
        {
            // Очистка перед заполнением
            leftEdges.Clear();
            rightEdges.Clear();

            foreach (var point in polygon)
            {
                if (leftEdges.Count == 0 || point.X < leftEdges.Last())
                {
                    leftEdges.Add(point.X);
                }
                else
                {
                    rightEdges.Add(point.X);
                }
            }
        }

        // очистка
        private void btn_clear_Click(object sender, EventArgs e)
        {
            gf.Clear(Color.White);
            VertexList.Clear();
            poligonA.Clear();
            poligonB.Clear();
            Xal.Clear();
            Xar.Clear();
            Xbl.Clear();
            Xbr.Clear();
        }

        private void type_0_Click(object sender, EventArgs e)
        {
            type = 0;
        }

        private void type_1_Click(object sender, EventArgs e)
        {
            type = 1;
        }

        private void type_2_Click(object sender, EventArgs e)
        {
            type = 2;
        }

        private void другоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 3;
        }

        private void Union_Click(object sender, EventArgs e)
        {
            TMO = 1;
            ExecuteTMO();
        }

        private void Intersection_Click(object sender, EventArgs e)
        {
            TMO = 2;
            ExecuteTMO();
        }

        private void SymmetricDifference_Click(object sender, EventArgs e)
        {
            TMO = 3;
            ExecuteTMO();
        }

        private void DifferenceAB_Click(object sender, EventArgs e)
        {
            TMO = 4;
            ExecuteTMO();
        }

        private void DifferenceBA_Click(object sender, EventArgs e)
        {
            TMO = 5;
            ExecuteTMO();
        }

        public struct Segment
        {
            public int x;
            public int dQ;
        }

        private void ExecuteTMO()
        {
            int Xemin = 0;
            int Xemax = pictureBox1.Width;
            List<int> SetQ = new List<int>();
            if (TMO == 1) SetQ = new List<int> { 1, 3 };  // Объединение
            else if (TMO == 2) SetQ = new List<int> { 3, 3 };  // Пересечение
            else if (TMO == 3) SetQ = new List<int> { 1, 2 };  // Симметрическая разность
            else if (TMO == 4) SetQ = new List<int> { 2, 2 };  // Разность A - B
            else if (TMO == 5) SetQ = new List<int> { 1, 1 };  // Разность B - A

            List<Segment> M = new List<Segment>();

            int n = Xal.Count;
            for (int i = 0; i < n; i++)
            {
                M.Add(new Segment { x = Xal[i], dQ = 2 });
            }

            int nM = n;
            n = Xar.Count;
            for (int i = 0; i < n; i++)
            {
                M.Add(new Segment { x = Xar[i], dQ = -2 });
            }

            nM += n;
            n = Xbl.Count;
            for (int i = 0; i < n; i++)
            {
                M.Add(new Segment { x = Xbl[i], dQ = 1 });
            }

            nM += n;
            n = Xbr.Count;
            for (int i = 0; i < n; i++)
            {
                M.Add(new Segment { x = Xbr[i], dQ = -1 });
            }

            nM += n;
            M = M.OrderBy(segment => segment.x).ToList();

            List<int> Xrl = new List<int>();
            List<int> Xrr = new List<int>();
            int k = 1, m = 1, Q = 0;

            if (M[0].x >= Xemin && M[0].dQ < 0)
            {
                Xrl.Add(Xemin);
                Q = -M[0].dQ;
                k++;
            }

            for (int i = 0; i < nM; i++)
            {
                int x = M[i].x;
                int Qnew = Q + M[i].dQ;

                if (!SetQ.Contains(Q) && SetQ.Contains(Qnew))
                {
                    Xrl.Add(x);
                    k++;
                }
                else if (SetQ.Contains(Q) && !SetQ.Contains(Qnew))
                {
                    Xrr.Add(x);
                    m++;
                }

                Q = Qnew;
            }

            if (SetQ.Contains(Q))
            {
                Xrr.Add(Xemax);
            }

            DrawResult(Xrl, Xrr);
        }

        private void DrawResult(List<int> Xrl, List<int> Xrr)
        {
            for (int i = 0; i < Xrl.Count && i < Xrr.Count; i++)
            {
                gf.DrawLine(DrawPen, Xrl[i], 0, Xrr[i], 0);
            }
        }
    }
}
