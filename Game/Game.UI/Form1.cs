using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Game.UI
{
    public partial class GameLines : Form
    {
        private readonly Field _field = new Field();
        private Position _selectedPosition;
        private int BallSize { get; set; }

        public GameLines()
        {
            InitializeComponent();
        }

        private int CellSize => Math.Min(ClientRectangle.Height, ClientRectangle.Width) / _field.Height;
        private int LineWidth => 5;

        private void GameLines_Paint_1(object sender, PaintEventArgs e)
        {
            PaintGrid(e.Graphics);
            PaintBalls(e.Graphics);
            PaintBordersSelectedBall(e.Graphics);
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
                        DrawingBall(graphics, row, col, cellSize, indent);
                    }
                }
            }
        }

        private void DrawingBall(Graphics graphics, int col, int row, int cellSize, int indent)
        {
            var colorPen = MapColor(_field.GetBallColorAt(col, row));
            using var pen = new Pen(colorPen, 5);
            using var brush = new SolidBrush(colorPen);
            graphics.DrawEllipse(pen, col * cellSize + indent, row * cellSize + indent, BallSize, BallSize);
            graphics.FillEllipse(brush, col * cellSize + indent, row * cellSize + indent, BallSize, BallSize);
        }

        private void BlurOutBall(Graphics graphics, int row, int col, int cellSize, int indent)
        {
           // using var pen = new Pen(Color.White, 5);
            using var brush = new SolidBrush(Color.White);

            //graphics.DrawRectangle(pen, row * cellSize, col * cellSize,
               // cellSize, cellSize);
            graphics.FillRectangle(brush, row * cellSize, col * cellSize,
                cellSize, cellSize);
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

        private void GameLines_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void GameLines_Load(object sender, EventArgs e)
        {
            _field.PlaceBalls();
        }

        private void GameLines_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = (MouseEventArgs) e;
            var clickedPosition = CalculatePositionByCoordinates(mouseEventArgs.X, mouseEventArgs.Y);
            var colorClickedPosition = _field.GetBallColorAt(clickedPosition);

            if (_selectedPosition == null)
            {
                if (colorClickedPosition != BallColor.Empty)
                {
                    _selectedPosition = clickedPosition;
                }
            }
            else
            {
                if (colorClickedPosition != BallColor.Empty)
                {
                    _selectedPosition = clickedPosition;
                }

                else if (colorClickedPosition == BallColor.Empty)
                {
                    if (_field.GetPath(_selectedPosition, clickedPosition, new bool[_field.Height, _field.Width]) != null)
                    {
                        var path = _field.GetPath(_selectedPosition, clickedPosition,
                            new bool[_field.Height, _field.Width]);
                        foreach (var position in path)
                        {
                            using var graphics = CreateGraphics();
                            DrawingBall(graphics, position.Row, position.Column, CellSize, LineWidth);
                            Thread.Sleep(100);
                            BlurOutBall(graphics, position.Row, position.Column, CellSize, LineWidth);
                        }
                        _field.MoveBall(_selectedPosition, clickedPosition);
                        _field.PlaceBalls();
                        _field.RemoveLines(clickedPosition);
                    }
                    _selectedPosition = null;
                }
            }
           // Invalidate();
        }

        private Position CalculatePositionByCoordinates(int x, int y)
        {
            var cellSize = CellSize;

            var positionX = x / cellSize;
            var positionY = y / cellSize;

            return new Position(positionX, positionY);
        }

        private void PaintBordersSelectedBall(Graphics graphics)
        {
            if (_selectedPosition == null) return;
            var cellSize = CellSize;
            var color = MapColor(_field.GetBallColorAt(_selectedPosition));
            using var pen = new Pen(color, 5);

            graphics.DrawRectangle(pen, _selectedPosition.Row * cellSize, _selectedPosition.Column * cellSize,
                cellSize, cellSize);
        }
    }
}
