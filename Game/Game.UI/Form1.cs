using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game.UI
{
    public partial class Form1 : Form
    {
        private readonly Field _field = new Field();
        private Position _selectedBall;
        private int  _ballInCellSize;
        private int _indentBallSize;
        private int _ballSize;
        private int _cellSize;


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
            _cellSize = ClientRectangle.Height / 9;

            using var pen = new Pen(Color.SandyBrown, 5);

            var rowLine = 0;
            for (int row = 0; row <= _field.Height; row++)
            {
                graphics.DrawLine(pen, 0, rowLine, _cellSize * _field.Height, rowLine);
                rowLine += _cellSize;
            }

            var columnLine = 0;
            for (int col = 0; col <= _field.Width; col++)
            {
                graphics.DrawLine(pen, columnLine, 0, columnLine, _cellSize * _field.Width);
                columnLine += _cellSize;
            }
        }

        private void PaintBalls(Graphics graphics)
        {
            _ballInCellSize = ClientRectangle.Height / 9;
            _indentBallSize = ClientRectangle.Height / 75;
            _ballSize = ClientRectangle.Height / 11;

            for (int row = 0; row < _field.Height; row++)
            {
                for (int col = 0; col < _field.Width; col++)
                {
                    if (_field.GetBallColorAt(row, col) != BallColor.Empty)
                    {
                        var colorPen = MapColor(_field.GetBallColorAt(row, col));
                        using var pen = new Pen(colorPen, 5);
                        graphics.DrawEllipse(pen, row * _ballInCellSize + _indentBallSize, col * _ballInCellSize + _indentBallSize, _ballSize, _ballSize);
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
            CalculatePositionByCoordinates(Location.X, Location.Y);
            TwitchBall(_selectedBall);

            if (_field.GetBallColorAt(_selectedBall) == BallColor.Empty)
            {
                  //_field.MoveBall(_selectedBall,  );
            }
            else if (_field.GetBallColorAt(_selectedBall) != BallColor.Empty)
            {
                //_selectedBall =
            }
            else
            {

            }

            //_selectedBall = new Position(MousePosition.X, MousePosition.Y);

           // if (_selectedBall )

            // if selected ball is  null
            // =
            //по координатам вычеслить х и у клика
            // запомнить кликнутую координату
            // _selectedBall

            // если шарик занят и кликаем на другой шарик то шарик перевыбиается

            //else
            //проверка если кликаем на пустое поле
            // если да то MoveBall


        }

        private Position CalculatePositionByCoordinates(int x, int y)
        {
            var positionX = (_field.Height * _cellSize) % x;
            var positionY = (_field.Height * _cellSize) % y;

            return _selectedBall = new Position(positionX, positionY);
        }

        private void TwitchBall(Position position)
        {
            //
        }

        
    }
}
