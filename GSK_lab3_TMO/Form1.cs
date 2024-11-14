using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GSK_lab3_TMO
{
    public partial class Form1 : Form
    {
        // Графический контекст для рисования
        Graphics gf;
        // Перо для рисования с черным цветом и толщиной 1
        Pen DrawPen = new Pen(Color.Black, 1);

        // Переменная для хранения текущего типа фигуры (0 - треугольник, 1 - прямоугольник и т.д.)
        private int type = 3;

        // Список для хранения координат вершин многоугольников
        List<Point> VertexList = new List<Point>();

        // Экземпляр класса Figure для работы с фигурами
        Figure Figure = new Figure();

        // Списки для двух многоугольников
        List<Point> poligonA = new List<Point>();
        List<Point> poligonB = new List<Point>();

        // Переменная для хранения типа теоретико-множественного преобразования (ТМО)
        int TMO;

        // Списки для хранения X-координат точек пересечения
        List<int> Xa = new List<int>();
        List<int> Xb = new List<int>();

        // Конструктор формы
        public Form1()
        {
            InitializeComponent();
            gf = pictureBox1.CreateGraphics(); // Инициализация графического контекста
        }

        // Обработчик выбора цвета
        private void color_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Изменение цвета пера в зависимости от выбора
            switch (color_box.SelectedIndex)
            {
                case 0: DrawPen.Color = Color.Black; break;
                case 1: DrawPen.Color = Color.Red; break;
                case 2: DrawPen.Color = Color.Green; break;
                case 3: DrawPen.Color = Color.Blue; break;
            }
        }

        // Обработчик рисования при нажатии мыши
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Добавляем текущую точку в список вершин
            int i = VertexList.Count;
            VertexList.Add(new Point() { X = e.X, Y = e.Y });

            // Проверка, если обе фигуры уже нарисованы, не продолжаем рисование
            if (poligonA.Count > 0 && poligonB.Count > 0) return;

            // Рисуем точку на экране
            gf.DrawEllipse(DrawPen, e.X - 2, e.Y - 2, 5, 5);

            // В зависимости от выбранного типа фигуры рисуем соответствующую фигуру
            switch (type)
            {
                case 0: // Треугольник
                    if (VertexList.Count != 3) return;
                    Figure.DrawT(gf, DrawPen, VertexList);
                    SavePolygon();
                    break;
                case 1: // Прямоугольник
                    if (VertexList.Count != 2) return;
                    Figure.DrawP(gf, DrawPen, VertexList);
                    SavePolygon();
                    break;
                case 2: // Круг
                    if (VertexList.Count != 2) return;
                    Figure.DrawK(gf, DrawPen, VertexList);
                    SavePolygon();
                    break;
                case 3: // Произвольный многоугольник
                    if (VertexList.Count > 1)
                    {
                        gf.DrawLine(DrawPen, VertexList[i - 1], VertexList[i]);
                    }
                    // Завершаем рисование по правому клику
                    if (e.Button == MouseButtons.Right)
                    {
                        gf.DrawLine(DrawPen, VertexList[i], VertexList[0]); // Замыкаем фигуру
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

        // Сохраняем текущую фигуру в список
        public void SavePolygon()
        {
            Figure.VertexList = new List<Point>(VertexList); // Сохраняем текущую фигуру
            Figure.coloringAlgorithm(gf, DrawPen); // Применяем алгоритм закрашивания

            // Сохраняем фигуру как полигон A или B
            if (poligonA.Count == 0)
            {
                poligonA = new List<Point>(VertexList);
            }
            else
            {
                poligonB = new List<Point>(VertexList);
            }

            // Очищаем список вершин для нового многоугольника
            VertexList.Clear();
        }

        // Обработчик кнопки очистки
        private void btn_clear_Click(object sender, EventArgs e)
        {
            gf.Clear(Color.White); // Очищаем графику
            VertexList.Clear();
            poligonA.Clear();
            poligonB.Clear();
        }

        // Обработчики для выбора типа фигуры
        private void type_0_Click(object sender, EventArgs e) { type = 0; }
        private void type_1_Click(object sender, EventArgs e) { type = 1; }
        private void type_2_Click(object sender, EventArgs e) { type = 2; }
        private void другоеToolStripMenuItem_Click(object sender, EventArgs e) { type = 3; }

        // Обработчики для выбора типа ТМО
        private void Union_Click(object sender, EventArgs e) { TMO = 1; ExecuteTMO(); }
        private void Intersection_Click(object sender, EventArgs e) { TMO = 2; ExecuteTMO(); }
        private void SymmetricDifference_Click(object sender, EventArgs e) { TMO = 3; ExecuteTMO(); }
        private void DifferenceAB_Click(object sender, EventArgs e) { TMO = 4; ExecuteTMO(); }
        private void DifferenceBA_Click(object sender, EventArgs e) { TMO = 5; ExecuteTMO(); }

        // Структура для хранения координат и значения dQ
        private struct PointDQ
        {
            public int x;
            public int dQ;
        }

        // Метод для выполнения ТМО
        private void ExecuteTMO()
        {
            // Находим минимальные и максимальные Y-координаты для обеих фигур
            int Y1min = poligonA[0].Y, Y1max = poligonA[0].Y;
            for (int i = 1; i < poligonA.Count; i++)
            {
                Y1min = Math.Min(Y1min, poligonA[i].Y);
                Y1max = Math.Max(Y1max, poligonA[i].Y);
            }

            int Y2min = poligonB[0].Y, Y2max = poligonB[0].Y;
            for (int i = 1; i < poligonB.Count; i++)
            {
                Y2min = Math.Min(Y2min, poligonB[i].Y);
                Y2max = Math.Max(Y2max, poligonB[i].Y);
            }

            // Определяем диапазон Y для выполнения ТМО
            int max = Math.Max(Y1max, Y2max);
            int min = Math.Min(Y1min, Y2min);

            // Для каждого значения Y между min и max находим пересечения
            for (int y = min; y <= max; y++)
            {
                Xa.Clear();
                Xb.Clear();
                Xa = GetXList(poligonA, y); // Получаем X-координаты для первого многоугольника
                Xb = GetXList(poligonB, y); // Получаем X-координаты для второго многоугольника

                // Задание диапазона SetQ в зависимости от типа ТМО
                List<int> SetQ = new List<int>();
                switch (TMO)
                {
                    case 1: SetQ = new List<int> { 1, 3 }; break; // объединение
                    case 2: SetQ = new List<int> { 3, 3 }; break; // пересечение
                    case 3: SetQ = new List<int> { 1, 2 }; break; // сим. разность
                    case 4: SetQ = new List<int> { 2, 2 }; break; // разность A \ B
                    case 5: SetQ = new List<int> { 1, 1 }; break; // разность B \ A
                    default: break; // Некорректный тип ТМО
                }

                // Процесс обработки пересечений
                List<PointDQ> M = new List<PointDQ>();
                for (int i = 0; i < Xa.Count; i++)
                {
                    M.Add(new PointDQ { x = Xa[i], dQ = (i % 2 == 0) ? 2 : -2 });
                }

                int nM = Xa.Count;
                for (int i = 0; i < Xb.Count; i++)
                {
                    M.Add(new PointDQ { x = Xb[i], dQ = (i % 2 == 0) ? 1 : -1 });
                }

                nM += Xb.Count;

                // Сортировка массива M по x-координатам
                M.Sort((a, b) => a.x.CompareTo(b.x));

                // Инициализация переменных для обработки
                int Q = 0;
                int k = 0;
                List<int> Xr = new List<int>();

                // Процесс вычисления пересечений
                for (int i = 0; i < nM; i++)
                {
                    int x = M[i].x;
                    int Qnew = Q + M[i].dQ;

                    // Добавляем в результат Xr, если нужно
                    if (((Q >= SetQ[0] && Q <= SetQ[1]) && (Qnew < SetQ[0] || Qnew > SetQ[1])) ||
                        ((Q < SetQ[0] || Q > SetQ[1]) && (Qnew >= SetQ[0] && Qnew <= SetQ[1])))
                    {
                        Xr.Add(x);
                        k++;
                    }

                    Q = Qnew;
                }

                Xr.Sort();

                // Рисуем закрашенные области
                for (int i = 0; i < Xr.Count; i += 2)
                {
                    int xStart = Xr[i];
                    int xEnd = Xr[i + 1];
                    gf.DrawLine(DrawPen, xStart, y, xEnd, y); // Рисуем горизонтальные линии
                }
            }
        }

        // Метод для получения списка X-координат пересечений для заданного y
        private List<int> GetXList(List<Point> points, int y)
        {
            List<int> Xb = new List<int>();
            for (int i = 0; i < points.Count; i++)
            {
                int k = (i < points.Count - 1) ? i + 1 : 0;
                int yi = points[i].Y;
                int yk = points[k].Y;

                // Проверяем, есть ли пересечение с горизонтальной линией y
                if (((yi < y) && (yk >= y)) || ((yi >= y) && (yk < y)))
                {
                    // Вычисляем точку пересечения
                    int x = (int)Math.Round(points[i].X + (y - points[i].Y) * (double)(points[k].X - points[i].X) / (points[k].Y - points[i].Y));
                    Xb.Add(x);
                }
            }
            Xb.Sort();
            return Xb;
        }
    }
}
