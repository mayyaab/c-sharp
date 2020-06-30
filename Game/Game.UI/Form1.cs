using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game.UI
{
    public partial class Form1 : Form
    {
        private readonly Field _field = new Field();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            PaintGrid(e.Graphics);
            PaintBalls(e.Graphics);
        }

        private void PaintGrid(Graphics graphics)
        {
            var cellSize = ClientRectangle.Height / 9;

            using var pen = new Pen(Color.SandyBrown, 5);

            var rowLine = 0;
            for (int row = 0; row <= _field.Height; row++)
            {
                graphics.DrawLine(pen, 0, rowLine, cellSize * _field.Height, rowLine);
                rowLine += cellSize;
            }

            var columnLine = 0;
            for (int col = 0; col <= _field.Width; col++)
            {
                graphics.DrawLine(pen, columnLine, 0, columnLine, cellSize * _field.Width);
                columnLine += cellSize;
            }
        }

        private void PaintBalls(Graphics graphics)
        {
            var ballInCellSize = ClientRectangle.Height / 9;
            var indentBallSize = ClientRectangle.Height / 24;

            for (int row = 0; row < _field.Height; row++)
            {
                for (int col = 0; col < _field.Width; col++)
                {
                    if (_field.GetBallColorAt(row, col) != BallColor.Empty)
                    {
                        var colorPen = MapColor(_field.GetBallColorAt(row, col));
                        using var pen = new Pen(colorPen, 5);
                        graphics.DrawEllipse(pen, row * ballInCellSize + indentBallSize, col * ballInCellSize + indentBallSize, 20, 20);
                    }
                }
            }
        }

        private Color MapColor(BallColor color)
        {
            switch (color)
            {
                case BallColor.Empty: return Color.SandyBrown;
                case BallColor.White: return Color.DarkGray;
                case BallColor.Black: return Color.Black;
                case BallColor.Blue: return Color.Blue;
                case BallColor.Red: return Color.Red;
                case BallColor.Yellow: return Color.Yellow;
            }

            return Color.SandyBrown;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _field.PlaceBalls();

        }
    }
}
