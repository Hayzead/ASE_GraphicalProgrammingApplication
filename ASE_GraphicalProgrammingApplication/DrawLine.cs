using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GraphicalProgrammingApplication
{
    class DrawLine : DrawingClass
    {
        public void drawLine(PaintEventArgs e, int x, int y)
        {

            e.Graphics.DrawLine(color, this.x, this.y, x, y);
        }
        public DrawLine(DrawingClass d)
        {
            this.x = d.x;
            this.y = d.y;
            color = Pens.Black;
        }
    }
}
