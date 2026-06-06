using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab3_4
{
    public class MainForm : Form
    {
        private Picture mainPicture;
        private Picture secondPicture;
        
        private Button btnMove;
        private Button btnScale;
        private Button btnMerge;
        private Label lblInfo;

        public MainForm()
        {
            this.Text = "Лабораторна 3, 4 (Варіант 3) - Юдін Юрій";
            this.Size = new Size(850, 600);
            this.DoubleBuffered = true; 

            mainPicture = new Picture(new Point(0, 0));
            mainPicture.AddFigure(new Rectangle(new Point(50, 150), 100, 50));
            mainPicture.AddFigure(new Square(new Point(50, 250), 60));
            mainPicture.AddFigure(new HatchedRectangle(new Point(200, 150), 80, 120, HatchStyle.DiagonalCross));
            mainPicture.AddFigure(new RectangularCuboid(new Point(350, 250), 80, 100, 40));
            mainPicture.AddFigure(new Cube(new Point(550, 250), 70));
            mainPicture.AddFigure(new SquarePyramid(new Point(200, 400), 80, 100));

            secondPicture = new Picture(new Point(0, 0));
            secondPicture.AddFigure(new Cube(new Point(650, 400), 50));

            InitializeUI();
        }

        private void InitializeUI()
        {
            btnMove = new Button() { Text = "Рухати (+10x, +10y)", Location = new Point(10, 10), Width = 150 };
            btnScale = new Button() { Text = "Масштабувати (x1.1)", Location = new Point(170, 10), Width = 150 };
            btnMerge = new Button() { Text = "Об'єднати зображення", Location = new Point(330, 10), Width = 150 };
            lblInfo = new Label() { Location = new Point(10, 40), Size = new Size(810, 80), AutoSize = false };

            btnMove.Click += (s, e) => { mainPicture.MovePicture(10, 10); UpdateInfo(); };
            btnScale.Click += (s, e) => { mainPicture.ScalePicture(1.1f); UpdateInfo(); };
            btnMerge.Click += (s, e) => { mainPicture.MergeWith(secondPicture); secondPicture = new Picture(new Point(0,0)); UpdateInfo(); };

            this.Controls.Add(btnMove);
            this.Controls.Add(btnScale);
            this.Controls.Add(btnMerge);
            this.Controls.Add(lblInfo);

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            lblInfo.Text = mainPicture.GetState();
            this.Invalidate(); 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            mainPicture.Draw(e.Graphics);
            secondPicture.Draw(e.Graphics);
        }
    }
}
