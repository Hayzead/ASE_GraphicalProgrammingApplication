using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GraphicalProgrammingApplication
{
    class Circle : DrawingClass
    {
        public void drawCircle(PaintEventArgs e, int radius)
        {

            if (fill)
            {
                e.Graphics.FillEllipse(solid, x, y, radius, radius);
            }
            else
            {
                e.Graphics.DrawEllipse(color, x, y, radius, radius);
            }
        }
        public Circle(DrawingClass s)
        {
            this.x = s.x;
            this.y = s.y;
            color = Pens.Black;
            this.fill = s.fill;
            this.solid = new SolidBrush(s.color.Color);
        }
    }
}
