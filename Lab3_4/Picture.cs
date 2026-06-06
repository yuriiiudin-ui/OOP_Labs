using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Lab3_4
{
    public class Picture
    {
        public Point Location { get; set; }
        private List<Figure> figures;

        public Picture(Point location)
        {
            Location = location;
            figures = new List<Figure>();
        }

        public Figure this[int index]
        {
            get { return figures[index]; }
            set { figures[index] = value; }
        }

        public void AddFigure(Figure f)
        {
            figures.Add(f);
        }

        public void MoveAllFigures(int dx, int dy)
        {
            foreach (var f in figures)
            {
                f.Move(dx, dy);
            }
        }

        public void MovePicture(int dx, int dy)
        {
            Location = new Point(Location.X + dx, Location.Y + dy);
            MoveAllFigures(dx, dy);
        }

        public void ScalePicture(float factor)
        {
            foreach (var f in figures)
            {
                f.Scale(factor);
            }
        }

        public string GetState()
        {
            return string.Join(" | ", figures.Select(f => f.GetInfo()));
        }

        public void MergeWith(Picture other)
        {
            figures.AddRange(other.figures);
        }

        public void Draw(Graphics g)
        {
            foreach (var f in figures)
            {
                f.Draw(g);
            }
        }
    }
}
