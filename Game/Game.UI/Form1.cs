using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // TG: Use ClientRectangle to calculate the cellSize
            // Since you are drawing squares it should be min of height and width

            const int cellSize = 70;
            using var pen = new Pen(Color.SandyBrown, 5);

            // TG: Make it a field of the class
            var field = new Field();

            var rowLine = 0;
            for (int row = 0; row <= field.Height; row++)
            {
                e.Graphics.DrawLine(pen, 0, rowLine, cellSize * field.Height, rowLine);
                rowLine+= cellSize;
            }

            var columnLine = 0;
            for (int col = 0; col <= field.Width; col++)
            {
                e.Graphics.DrawLine(pen, columnLine, 0, columnLine, cellSize* field.Width);
                columnLine += cellSize;
            }

            // TG: Scan the field and draw the balls
            // https://stackoverflow.com/questions/1835062/drawing-circles-with-system-drawing
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
