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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="admin" && textBox2.Text=="1234")
            {
                Form2 form = new Form2();
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("invalid");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void enter(object sender, EventArgs e)
        {
            textBox1.Text= "UserName";
        }

        private void input(object sender, EventArgs e) // when user click on text box
        {
            textBox1.Text = "";
            
        }

        private void passenter(object sender, EventArgs e) // user click on password box
        {
            textBox2.Text = "";
            textBox2.UseSystemPasswordChar = true;// show password as dots
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            int cornerRadius = 15; // Adjust the radius as needed
            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = panel3.ClientRectangle;
            int diameter = cornerRadius * 2;

            // Create rounded rectangle path
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // Top-left corner
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // Top-right corner
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // Bottom-right corner
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left corner
            path.CloseAllFigures();

            // Apply the rounded rectangle as the panel's region
            panel3.Region = new Region(path);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void loginenter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(77, 95, 203);
        }

        private void loginleave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(94, 114, 228);
        }
    }
}
