using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

            int cornerRadius = 14; // Adjust the radius as needed
            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = panel1.ClientRectangle;
            int diameter = cornerRadius * 2;

            // Create rounded rectangle path
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // Top-left corner
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // Top-right corner
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // Bottom-right corner
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left corner
            path.CloseAllFigures();

            // Apply the rounded rectangle as the panel's region
            panel1.Region = new Region(path);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }

        private void panle1_resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                
            }
            else if(this.WindowState != FormWindowState.Maximized) 
            {

            }
        }
    }
}
