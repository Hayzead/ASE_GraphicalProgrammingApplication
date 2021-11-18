using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
                    case "Triangle":
                        new Triangle(draw).drawPolygon(e, int.Parse(newCoordinate[1], CultureInfo.InvariantCulture.NumberFormat),
                      int.Parse(newCoordinate[2], CultureInfo.InvariantCulture.NumberFormat)); 
                        break;
                    default: 
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

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Refresh();

            string input = textBox1.Text;
            string[] newCoordinate = input.Split(' ');

            if (newCoordinate.Length >= 1)
            {
                switch (newCoordinate[0])
                {
                    case "moveTo":

                    case "Rectangle":

                    case "Triangle":

                    case "drawTo":
                        if (newCoordinate.Length != 3)
                        {
                            label1.Text = "Invalid Syntax";
                        }
                        else
                        {
                            label1.Text = "Valid Syntax";
                        }
                        break;

                    case "Circle":
                        if (newCoordinate.Length != 2)
                        {
                            label1.Text = "This Invalid Syntax";
                        }
                        else
                        {
                            label1.Text = "Valid Syntax";
                        }
                        break;
                    default:
                        label1.Text = "Invalid Syntax";
                        break;
                }
            }
            else
            {
                label1.Text = "Invalid Syntax";
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string strfilename = openFileDialog1.FileName;
                    string filetext = File.ReadAllText(strfilename); 
                    textBox1.Text = filetext;
                }

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        { 
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(textBox1.Text);
                    }
                } 
        }
    }
    }

