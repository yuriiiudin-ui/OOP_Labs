using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab3_4
{
    public abstract class Figure
    {
        public Point Location { get; set; }

        protected Figure(Point location)
        {
            Location = location;
        }

        public abstract void Move(int dx, int dy);
        public abstract void Scale(float factor);
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract string GetInfo();
        public abstract void Draw(Graphics g);
        
        // Property demonstration
        public Point CurrentLocation
        {
            get { return Location; }
            set { Location = value; }
        }
    }

    public class Rectangle : Figure
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public Rectangle(Point location, float width, float height) : base(location)
        {
            Width = width;
            Height = height;
        }

        public override void Move(int dx, int dy)
        {
            Location = new Point(Location.X + dx, Location.Y + dy);
        }

        public override void Scale(float factor)
        {
            Width *= factor;
            Height *= factor;
        }

        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => 2 * (Width + Height);
        
        public override string GetInfo() => $"Прямокутник в {Location}, Ш:{Width}, В:{Height}";

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, Location.X, Location.Y, Width, Height);
        }
    }

    public class Square : Rectangle
    {
        public Square(Point location, float side) : base(location, side, side)
        {
        }

        public override string GetInfo() => $"Квадрат в {Location}, Сторона:{Width}";
    }

    public class HatchedRectangle : Rectangle
    {
        public HatchStyle HatchStyle { get; set; }

        public HatchedRectangle(Point location, float width, float height, HatchStyle style) 
            : base(location, width, height)
        {
            HatchStyle = style;
        }

        public override void Draw(Graphics g)
        {
            using (HatchBrush brush = new HatchBrush(HatchStyle, Color.Black, Color.Transparent))
            {
                g.FillRectangle(brush, Location.X, Location.Y, Width, Height);
            }
            base.Draw(g);
        }

        public override string GetInfo() => $"Заштр. прямокутник в {Location}, Ш:{Width}, В:{Height}";
    }

    public class RectangularCuboid : Rectangle
    {
        public float Depth { get; set; }

        public RectangularCuboid(Point location, float width, float height, float depth) 
            : base(location, width, height)
        {
            Depth = depth;
        }

        public override void Scale(float factor)
        {
            base.Scale(factor);
            Depth *= factor;
        }

        public override double GetArea() => 2 * (Width * Height + Width * Depth + Height * Depth);
        public override double GetPerimeter() => 4 * (Width + Height + Depth);

        public override string GetInfo() => $"Паралелепіпед в {Location}, Ш:{Width}, В:{Height}, Г:{Depth}";

        public override void Draw(Graphics g)
        {
            float dx = Depth * 0.5f;
            float dy = Depth * 0.5f;
            
            PointF p1 = new PointF(Location.X, Location.Y);
            PointF p2 = new PointF(Location.X + Width, Location.Y);
            PointF p3 = new PointF(Location.X + Width, Location.Y + Height);
            PointF p4 = new PointF(Location.X, Location.Y + Height);
            
            PointF p1b = new PointF(p1.X + dx, p1.Y - dy);
            PointF p2b = new PointF(p2.X + dx, p2.Y - dy);
            PointF p3b = new PointF(p3.X + dx, p3.Y - dy);
            PointF p4b = new PointF(p4.X + dx, p4.Y - dy);

            g.DrawPolygon(Pens.Gray, new[] { p1b, p2b, p3b, p4b });
            g.DrawLine(Pens.Black, p1, p1b);
            g.DrawLine(Pens.Black, p2, p2b);
            g.DrawLine(Pens.Black, p3, p3b);
            g.DrawLine(Pens.Black, p4, p4b);
            g.DrawPolygon(Pens.Black, new[] { p1, p2, p3, p4 });
        }
    }

    public class Cube : RectangularCuboid
    {
        public Cube(Point location, float side) : base(location, side, side, side)
        {
        }
        
        public override string GetInfo() => $"Куб в {Location}, Сторона:{Width}";
    }

    public class SquarePyramid : Square
    {
        public float PyramidHeight { get; set; }

        public SquarePyramid(Point location, float baseSide, float height) : base(location, baseSide)
        {
            PyramidHeight = height;
        }

        public override void Scale(float factor)
        {
            base.Scale(factor);
            PyramidHeight *= factor;
        }

        public override string GetInfo() => $"Піраміда в {Location}, Основа:{Width}, Висота:{PyramidHeight}";

        public override void Draw(Graphics g)
        {
            float depth = Width;
            float dx = depth * 0.5f;
            float dy = depth * 0.5f;

            PointF p1 = new PointF(Location.X, Location.Y + PyramidHeight);
            PointF p2 = new PointF(Location.X + Width, Location.Y + PyramidHeight);
            PointF p3 = new PointF(p2.X + dx, p2.Y - dy);
            PointF p4 = new PointF(p1.X + dx, p1.Y - dy);

            PointF apex = new PointF(Location.X + Width/2 + dx/2, Location.Y + PyramidHeight - PyramidHeight - dy/2);

            g.DrawPolygon(Pens.Gray, new[] { p1, p2, p3, p4 });
            g.DrawLine(Pens.Black, p1, apex);
            g.DrawLine(Pens.Black, p2, apex);
            g.DrawLine(Pens.Black, p3, apex);
            g.DrawLine(Pens.Black, p4, apex);
        }
    }
}
