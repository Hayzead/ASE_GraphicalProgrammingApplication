using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GraphicalProgrammingApplication
{
    class Triangle : DrawingClass
    {
        public void drawPolygon(PaintEventArgs e, int x, int y)
        {
            Point[] points = new Point[3];
            points[0].X = this.x;
            points[0].Y = this.y;

            points[1].X = x;
            points[1].Y = x;

            points[2].X = y;
            points[2].Y = x; 
            if (fill)
            {
                e.Graphics.FillPolygon(solid, points);
            }
            else
            { 
                e.Graphics.DrawPolygon(color, points);
            }
        }
        public Triangle(DrawingClass d)
        {
            this.x = d.x;
            this.y = d.y;
            color = Pens.Black;
            this.fill = d.fill;
            this.solid = new SolidBrush(d.color.Color);
        }
    }
}
