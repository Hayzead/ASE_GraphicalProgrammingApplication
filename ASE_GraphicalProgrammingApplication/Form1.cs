using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_GraphicalProgrammingApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string userInput = textBox1.Text;
            string[] userInputArray = userInput.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            DrawingClass draw = new DrawingClass();
            draw.x = 0;
            draw.y = 0;
            draw.color = Pens.Black;
            foreach (string input in userInputArray)
            {
                string[] newCoordinate = input.Split(' ');
                switch (newCoordinate[0])
                {
                    case "Clear":
                        e.Graphics.Clear(System.Drawing.Color.White);
                        break;
                    case "Circle":
                        new Circle(draw).drawCircle(e, int.Parse(newCoordinate[1], CultureInfo.InvariantCulture.NumberFormat));
                        break;
                    case "Rectangle":
                        new Rectangle(draw).drawRectangle(e, int.Parse(newCoordinate[1], CultureInfo.InvariantCulture.NumberFormat),
                      int.Parse(newCoordinate[2], CultureInfo.InvariantCulture.NumberFormat));
                        break; 
                    case "drawTo":
                        new DrawLine(draw).drawLine(e, int.Parse(newCoordinate[1], CultureInfo.InvariantCulture.NumberFormat),
                      int.Parse(newCoordinate[2], CultureInfo.InvariantCulture.NumberFormat));
                        break;
                    case "moveTo":
                        draw.x = int.Parse(newCoordinate[1], CultureInfo.InvariantCulture.NumberFormat);
                        draw.y = int.Parse(newCoordinate[2], CultureInfo.InvariantCulture.NumberFormat);
                        break;
                    case "Fill":
                        switch (newCoordinate[1])
                        {
                            case "on":
                                draw.fill = true;
                                break;
                            case "off":
                                draw.fill = false;
                                break;
                        }
                        break;
                    case "Pen":
                        switch (newCoordinate[1])
                        {
                            case "Black":
                                draw.color = Pens.Black;
                                break;
                            case "Green":
                                draw.color = Pens.Green;
                                break;
                            case "Red":
                                draw.color = Pens.Red;
                                break;
                            case "Brown":
                                draw.color = Pens.Brown;
                                break;
                            default:
                                draw.color = Pens.Black;
                                break;

                        }
                        break;

                    default:
                        // code block
                        break;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void command(object sender, EventArgs e)
        {
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Refresh();
        }
    }
}
