using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class Form3 : Form
    {
        public int idnumber;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5ETB5FH;Initial Catalog=studentmanagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count (*) from addstudents where username=@username and id=@id", con);
            SqlCommand display=new SqlCommand("select username,id,telephone,address,gender,department,dob from addstudents where id=@id", con);
            display.Parameters.AddWithValue("@id", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox2.Text));
            int count=(int)cmd.ExecuteScalar();
            if(count > 0)
            {
                Form4 form4 = new Form4();// create an object of form4
                form4.Show();
                idnumber = int.Parse(textBox2.Text);
                form4.label1.Text = textBox1.Text;
                form4.userid=int.Parse(textBox2.Text);// access the userid variable in form4
                SqlDataReader srd=display.ExecuteReader();
                while (srd.Read())
                {
                    form4.label14.Text=srd.GetValue(0).ToString();
                    form4.label15.Text=srd.GetValue(1).ToString();
                    form4.label16.Text = srd.GetValue(2).ToString();
                    form4.label17.Text=srd.GetValue(3).ToString();
                    form4.label18.Text=srd.GetValue(4).ToString();
                    form4.label19.Text=srd.GetValue(5).ToString();
                    form4.label20.Text=srd.GetValue(6).ToString();
                }

            }
            else
            {
                MessageBox.Show("Invalid username or id");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
