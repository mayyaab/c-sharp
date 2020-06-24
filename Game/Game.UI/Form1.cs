using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game.UI
{
    public partial class Form1 : Form
    {
        private Field field = new Field();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_PaintLines(object sender, PaintEventArgs e)
        {
            var cellSize = ClientRectangle.Height/9;
            var ballInCellSize = ClientRectangle.Height / 9;
            var indentBallSize = ClientRectangle.Height / 24;

            using var pen = new Pen(Color.SandyBrown, 5);

            var rowLine = 0;
            for (int row = 0; row <= field.Height; row++)
            {
                e.Graphics.DrawLine(pen, 0, rowLine, cellSize * field.Height, rowLine);
                rowLine += cellSize;
            }

            var columnLine = 0;
            for (int col = 0; col <= field.Width; col++)
            {
                e.Graphics.DrawLine(pen, columnLine, 0, columnLine, cellSize * field.Width);
                columnLine += cellSize;
            }

            for (int row = 0; row < field.Height; row++)
            {
                for (int col = 0; col < field.Width; col++)
                {
                    e.Graphics.DrawEllipse(pen, row * ballInCellSize + indentBallSize, col * ballInCellSize + indentBallSize, 20, 20);
                }
            }
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PlaceBalls_Click(object sender, EventArgs e)
        {
        }
    }
}
