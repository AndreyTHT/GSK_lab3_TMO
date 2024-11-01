using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace GSK_lab3_TMO
{
    internal class Figure
    {
        // Список вершин многоугольника
        public List<Point> VertexList { get; set; } = new List<Point>();

        // Конструктор по умолчанию
        public Figure() { }

        // Конструктор, принимающий список вершин
        public Figure(List<Point> vertices)
        {
            VertexList = vertices;
        }

        // Метод очистки списка вершин
        public void ClearVertices()
        {
            VertexList.Clear();
        }

        // Метод закрашивания фигуры
        public void coloringAlgorithm(Graphics g, Pen DrawPen)
        {

            // Поиск Ymin и Ymax
            int Ymin = VertexList[0].Y;
            int Ymax = VertexList[0].Y;
            foreach (var point in VertexList)
            {
                if (point.Y < Ymin) Ymin = point.Y;
                if (point.Y > Ymax) Ymax = point.Y;
            }

            // Пробегаем по каждой строке от Ymin до Ymax
            for (int Y = Ymin; Y <= Ymax; Y++)
            {
                List<int> Xb = new List<int>(); // Список пересечений X

                // Поиск пересечений текущей строки Y со сторонами многоугольника
                for (int i = 0; i < VertexList.Count; i++)
                {
                    int k = 0;
                    if (i < VertexList.Count - 1)
                    {
                        k = i + 1;
                    }

                    Point Pi = VertexList[i];
                    Point Pk = VertexList[k];

                    // Условие пересечения строки Y со стороной Pi Pk
                    if ((Pi.Y < Y && Pk.Y >= Y) || (Pi.Y >= Y && Pk.Y < Y))
                    {
                        // Вычисляем координату X пересечения
                        int xIntersect = Pi.X + (Y - Pi.Y) * (Pk.X - Pi.X) / (Pk.Y - Pi.Y);
                        Xb.Add(xIntersect); // Добавляем в список пересечений
                    }
                }

                // Сортируем пересечения по X
                Xb.Sort();

                // Закрашиваем сегменты
                for (int j = 0; j < Xb.Count; j += 2)
                {
                    if (j + 1 < Xb.Count)
                    {
                        g.DrawLine(DrawPen, Xb[j], Y, Xb[j + 1], Y);
                    }
                }
            }
        }
        

        // Рисование треугольника
        public void DrawT(Graphics g, Pen DrawPen, List<Point> VertexList)
        {
            // Рисуем три стороны треугольника, соединяя вершины
            g.DrawLine(DrawPen, VertexList[0], VertexList[1]);
            g.DrawLine(DrawPen, VertexList[1], VertexList[2]);
            g.DrawLine(DrawPen, VertexList[2], VertexList[0]);
        }

        // Рисование прямоугольника
        public void DrawP(Graphics g, Pen DrawPen, List<Point> VertexList)
        {
            // Определяем координаты противоположных углов прямоугольника
            int x1 = VertexList[0].X;
            int y1 = VertexList[0].Y;
            int x2 = VertexList[1].X;
            int y2 = VertexList[1].Y;

            // Определяем четыре вершины прямоугольника
            Point topLeft = new Point(Math.Min(x1, x2), Math.Min(y1, y2));
            Point topRight = new Point(Math.Max(x1, x2), Math.Min(y1, y2));
            Point bottomLeft = new Point(Math.Min(x1, x2), Math.Max(y1, y2));
            Point bottomRight = new Point(Math.Max(x1, x2), Math.Max(y1, y2));

            // Добавляем вершины в список VertexList
            VertexList.Clear();
            VertexList.Add(topLeft);
            VertexList.Add(topRight);
            VertexList.Add(bottomRight);
            VertexList.Add(bottomLeft);

            // Рисуем четыре стороны прямоугольника
            g.DrawLine(DrawPen, topLeft, topRight);        // Верхняя сторона
            g.DrawLine(DrawPen, topRight, bottomRight);    // Правая сторона
            g.DrawLine(DrawPen, bottomRight, bottomLeft);  // Нижняя сторона
            g.DrawLine(DrawPen, bottomLeft, topLeft);      // Левая сторона
        }

        // Рисование круга
        public void DrawK(Graphics g, Pen DrawPen, List<Point> VertexList)
        {
            if (VertexList.Count < 2)
            {
                // Проверяем, что в списке достаточно точек для рисования круга
                return;
            }

            // Вычисляем радиус как расстояние между центром и второй точкой
            int radius = (int)Math.Sqrt(Math.Pow(VertexList[1].X - VertexList[0].X, 2) + Math.Pow(VertexList[1].Y - VertexList[0].Y, 2));

            // Создаем кисть для закрашивания круга, используя цвет пера
            using (Brush fillBrush = new SolidBrush(DrawPen.Color))
            {
                // Закрашиваем круг
                g.FillEllipse(fillBrush, VertexList[0].X - radius, VertexList[0].Y - radius, radius * 2, radius * 2);
            }

            // Рисуем контур круга
            g.DrawEllipse(DrawPen, VertexList[0].X - radius, VertexList[0].Y - radius, radius * 2, radius * 2);
        }

    }
}


