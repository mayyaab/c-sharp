using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            const int cellSize = 70;
            using var pen = new Pen(Color.SandyBrown, 5);
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
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
