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
            if (textBox1.Text=="admin" || textBox1.Text=="ADMIN" && textBox2.Text=="1234")
            {
                Form2 form = new Form2();
                form.Show();
                this.Close();
            }
            else
            {
                Label massage = new Label(); // create a new label
                Point newerrorpoint = new Point(70, 450);
                massage.Text = "invalid username or password";
                panel1.BackColor = Color.Red;
                panel2.BackColor = Color.Red;
                massage.Font = new Font("Arial", 10, FontStyle.Bold);
                massage.ForeColor = Color.Red;
                massage.Location = newerrorpoint;// set posssion for the label
                massage.AutoSize = true;// ensure the label resizes to fit the text

                this.Controls.Add(massage); // add the label to the form

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
            panel1.BackColor = Color.Black;
            
        }

        private void passenter(object sender, EventArgs e) // user click on password box
        {
            textBox2.Text = "";
            textBox2.UseSystemPasswordChar = true;// show password as dots
            panel2.BackColor = Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
