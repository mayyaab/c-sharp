using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game.UI
{
    public partial class Form1 : Form
    {
        private readonly Field _field = new Field();
        private Position _selectedBall;
        private int BallSize { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private int CellSize => Math.Min(ClientRectangle.Height, ClientRectangle.Width) / _field.Height;
        private int LineWidth => 5;

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            PaintGrid(e.Graphics);
            PaintBalls(e.Graphics);
        }

        private void PaintGrid(Graphics graphics)
        {
            var cellSize = CellSize;
            var gridWidth = cellSize * _field.Height;
            var gridHeight = cellSize * _field.Height;

            using var pen = new Pen(Color.SandyBrown, LineWidth);

            // Draw horizontal lines
            var rowLine = 0;
            for (int row = 0; row <= _field.Width; row++)
            {
                graphics.DrawLine(pen, 0, rowLine, gridWidth, rowLine);
                rowLine += cellSize;
            }

            // Draw vertical lines
            var columnLine = 0;
            for (int col = 0; col <= _field.Height; col++)
            {
                graphics.DrawLine(pen, columnLine, 0, columnLine, gridHeight);
                columnLine += cellSize;
            }
        }

        private void PaintBalls(Graphics graphics)
        {
            var indent = LineWidth;

            var cellSize = CellSize;
            BallSize = CellSize - 2 * indent;

            for (int row = 0; row < _field.Height; row++)
            {
                for (int col = 0; col < _field.Width; col++)
                {
                    if (_field.GetBallColorAt(row, col) != BallColor.Empty)
                    {
                        var colorPen = MapColor(_field.GetBallColorAt(row, col));
                        using var pen = new Pen(colorPen, 5);
                        using var brush = new SolidBrush(colorPen);
                        graphics.DrawEllipse(pen, row * cellSize + indent, col * cellSize + indent, BallSize, BallSize);
                        graphics.FillEllipse(brush, row * cellSize + indent, col * cellSize + indent, BallSize, BallSize);
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

        private void Form1_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = (MouseEventArgs) e;
            var clickedPosition = CalculatePositionByCoordinates(mouseEventArgs.X, mouseEventArgs.Y);
            var colorClickedPosition = _field.GetBallColorAt(clickedPosition);

            if (_selectedBall == null)
            {
                if (colorClickedPosition != BallColor.Empty)
                {
                    _selectedBall = clickedPosition;
                    TwitchBall(_selectedBall);
                }
            }
            else
            {
                if (colorClickedPosition != BallColor.Empty)
                {
                    _selectedBall = clickedPosition;
                    TwitchBall(_selectedBall);
                }

                else if (colorClickedPosition == BallColor.Empty)
                {
                    if (_field.GetPath(_selectedBall, clickedPosition, new bool[_field.Height, _field.Width]) != null)
                    {
                        _field.MoveBall(_selectedBall, clickedPosition);
                        _field.PlaceBalls();
                    }
                    _field.RemoveLines(clickedPosition);
                    Invalidate();
                    _selectedBall = null;
                }
            }
        }

        private Position CalculatePositionByCoordinates(int x, int y)
        {
            var cellSize = CellSize;

            var positionX = x / cellSize;
            var positionY = y / cellSize;

            return new Position(positionX, positionY);
        }

        private void TwitchBall(Position position)
        {

            BallSize *= 2;
            Invalidate();
        }
    }
}
