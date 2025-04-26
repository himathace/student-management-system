using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (textBox1.Text=="admin"&&textBox2.Text=="1234")
            {
                Form2 form = new Form2();
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");

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
    }
}
