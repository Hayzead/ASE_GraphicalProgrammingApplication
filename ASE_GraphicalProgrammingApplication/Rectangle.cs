using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GraphicalProgrammingApplication
{
    class Rectangle : DrawingClass
    {
        public void drawRectangle(PaintEventArgs e, int width, int height)
        {
            if (fill)
            {
                e.Graphics.FillRectangle(solid, x, y, width, height);
            }
            else
            {
                e.Graphics.DrawRectangle(color, x, y, width, height);
            }
        }
        public Rectangle(DrawingClass d)
        {
            this.x = d.x;
            this.y = d.y;
            this.color = d.color;
            this.fill = d.fill;
            this.solid = new SolidBrush(d.color.Color);
        }
    }
}
