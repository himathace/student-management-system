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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            binddata();
            panel2.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5ETB5FH;Initial Catalog=studentmanagement;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd= new SqlCommand("insert into addstudents (username,id,telephone,address,gender,department,dob) values(@username,@id,@telephone,@address,@gender,@department,@dob)", con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@telephone", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@department", comboBox3.Text);
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);  
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Inserted Successfully");
            con.Close();
            binddata();
        }

        void binddata()
        {
            SqlCommand cmdbind = new SqlCommand("select * from addstudents", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmdbind);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text=string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox3.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand update= new SqlCommand("update addstudents set username=@username,telephone=@telephone,address=@address,gender=@gender,department=@department,dob=@dob where id=@id",con);
            update.Parameters.AddWithValue("@id", int.Parse(textBox2.Text));
            update.Parameters.AddWithValue("@username", textBox1.Text);
            update.Parameters.AddWithValue("@telephone", textBox3.Text);
            update.Parameters.AddWithValue("@address", textBox4.Text);
            update.Parameters.AddWithValue("@gender", comboBox1.Text);
            update.Parameters.AddWithValue("@department", comboBox3.Text);
            update.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
            update.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated Successfully");
            binddata();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand delete = new SqlCommand("delete from addstudents where id=@id", con);
            delete.Parameters.AddWithValue("@id", int.Parse(textBox2.Text));
            delete.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted Successfully");
            binddata();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        SqlConnection connect= new SqlConnection("Data Source=DESKTOP-5ETB5FH;Initial Catalog=studentmanagement;Integrated Security=True");
        private void button6_Click_1(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("insert into course (username,id,course) values(@username,@id,@course)", connect);
            cmd.Parameters.AddWithValue("@username", textBox5.Text);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@course", textBox7.Text);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Data Inserted Successfully");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand courseupdate = new SqlCommand("update course set username=@username,course=@course where id=@id", connect);
            courseupdate.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
            courseupdate.Parameters.AddWithValue("@username", textBox5.Text);
            courseupdate.Parameters.AddWithValue("@course", textBox7.Text);
            courseupdate.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Data Updated Successfully");

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand deletecourse=new SqlCommand("delete from course where id=@id", connect);
            deletecourse.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
            deletecourse.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Data Deleted Successfully");
        }
    }
}
