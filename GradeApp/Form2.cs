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

        private void showpanel(Panel paneltoshow)
        {
            paneltoshow.Visible = true;
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5ETB5FH;Initial Catalog=studentmanagement;Integrated Security=True"); // connect to databse studentmanagement
        private void Form2_Load(object sender, EventArgs e)
        {
            binddata();

            panel1.Size = new Size(59, 638);

            panel2.Visible = false;
            panel3.Visible = false;
            panel7.Visible = false;
            panel10.Visible = false;


            con.Open();
            SqlCommand malecount=new SqlCommand("select count(*) from addstudents where gender='Male'",con);// get the number of rows where gender column equal to male
            SqlCommand femalecount=new SqlCommand("select count(*) from addstudents where gender='Female'",con);// get the number of rows where gender column equal to female
            int nomale=(int)malecount.ExecuteScalar(); // convert to int
            int nofemale=(int)femalecount.ExecuteScalar();
            con.Close();

            // add data to chart1
            chart1.Series["Series1"].Points.AddXY("Male", nomale);
            chart1.Series["Series1"].Points.AddXY("Female", nofemale);




            con.Open();
            SqlCommand countcompute= new SqlCommand("select count(*) from addstudents where department='coumputing'", con);// get the number of rows where department column equal to Computer Science
            SqlCommand countbusiness = new SqlCommand("select count(*) from addstudents where department='busness'", con);// get the number of rows where department column equal to Business
            SqlCommand countengineering = new SqlCommand("select count(*) from addstudents where department='engeniring'", con);// get the number of rows where department column equal to Engineering
            SqlCommand countmedical = new SqlCommand("select count(*) from addstudents where department='medical'", con);// get the number of rows where department column equal to Medical
            
            int nocumputing = (int)countcompute.ExecuteScalar(); // convert to int
            int nobusiness = (int)countbusiness.ExecuteScalar();
            int noengineering = (int)countengineering.ExecuteScalar();
            int nomedical = (int)countmedical.ExecuteScalar();
            con.Close();

            // add data to chart2

            chart2.Series["Department"].Points.AddXY("Computing", nocumputing);
            chart2.Series["Department"].Points.AddXY("Business", nobusiness);
            chart2.Series["Department"].Points.AddXY("Engineering", noengineering);
            chart2.Series["Department"].Points.AddXY("Medical", nomedical);


            // get number of rows in addstudents table(total number of students)
            con.Open();
            SqlCommand count = new SqlCommand("select count(*) from addstudents", con);
            string countstring = count.ExecuteScalar().ToString(); // execute queary and convert to string
            con.Close();
            label17.Text = countstring; // display number of rows in label17


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // insert user information to table addstudents
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into addstudents (username,id,telephone,address,gender,department,dob) values(@username,@id,@telephone,@address,@gender,@department,@dob)", con);
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
            dataGridView2.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // clear userinput fields
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox3.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // update user information in addstudents table
            con.Open();
            SqlCommand update = new SqlCommand("update addstudents set username=@username,telephone=@telephone,address=@address,gender=@gender,department=@department,dob=@dob where id=@id", con);
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
            //delete userinformation in addstudents table
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

        //SqlConnection connect = new SqlConnection("Data Source=DESKTOP-5ETB5FH;Initial Catalog=studentmanagement;Integrated Security=True");
        private void button6_Click_1(object sender, EventArgs e)
        {
            // add course information to course table
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into course (username,id,course) values(@username,@id,@course)", con);
            cmd.Parameters.AddWithValue("@username", textBox5.Text);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@course", textBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Inserted Successfully");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //update course information in course table
            con.Open();
            SqlCommand courseupdate = new SqlCommand("update course set username=@username,course=@course where id=@id", con);
            courseupdate.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
            courseupdate.Parameters.AddWithValue("@username", textBox5.Text);
            courseupdate.Parameters.AddWithValue("@course", textBox7.Text);
            courseupdate.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated Successfully");

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //delete course information in course information
            con.Open();
            SqlCommand deletecourse = new SqlCommand("delete from course where id=@id", con);
            deletecourse.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
            deletecourse.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted Successfully");
        }

        private void button9_Click(object sender, EventArgs e)
        {
 
            showpanel(panel3);

        }



        private void button10_Click(object sender, EventArgs e)
        {
            showpanel(panel2); 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // resizable side bar

        bool sidebarexpand;

        private void sidebar(object sender, EventArgs e)
        {
            if (sidebarexpand)
            {
                panel1.Width -= 10;
                if (panel1.Width == panel1.MinimumSize.Width)
                {
                    sidebarexpand = false;
                    timer1.Stop();
                }

            }
            else
            {
                panel1.Width += 10;
                if (panel1.Width == panel1.MaximumSize.Width)
                {
                    sidebarexpand = true;
                    timer1.Stop();
                }
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel7.Visible = false;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel7.Visible =false;
            panel10.Visible=false;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand grades = new SqlCommand("update  course set grade=@grade where username=@username and id=@id and course=@course ",con);
            SqlCommand gpa = new SqlCommand("update addstudents set gpa=@gpa where username=@username and id=@id", con);

            grades.Parameters.AddWithValue("@grade",textBox11.Text);
            grades.Parameters.AddWithValue("@username", textBox10.Text);
            grades.Parameters.AddWithValue("@id",int.Parse(textBox9.Text));
            grades.Parameters.AddWithValue("@course",textBox8.Text);

            gpa.Parameters.AddWithValue("@gpa", textBox12.Text);
            gpa.Parameters.AddWithValue("@username",textBox10.Text);
            gpa.Parameters.AddWithValue("@id", int.Parse(textBox9.Text));

            grades.ExecuteNonQuery();
            gpa.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data updated");
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            showpanel(panel7);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        bool showbutton = false;
        private void displaybuttons(object sender, EventArgs e)
        {
            if (!showbutton)
            {
                panel8.Height += 10;
                panel9.Location = new Point(panel9.Location.X,panel8.Location.Y+panel8.Height);
                if (panel8.Height == panel8.MaximumSize.Height)
                {
                    showbutton = true;
                    timer2.Stop();
                }
            }
            else
            {
                panel8.Height -= 10;
                panel9.Location = new Point(panel9.Location.X,panel8.Location.Y+panel8.Height);
                if (panel8.Height == panel8.MinimumSize.Height)
                {
                    showbutton = false;
                    timer2.Stop();
                }
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            timer2.Start();
        }

        void searchbinddata()
        {
            con.Open();
            SqlCommand search = new SqlCommand("select * from addstudents where id=@id or username=@username", con);
            if (int.TryParse(textBox13.Text, out int id))
            {
                search.Parameters.AddWithValue("@id", id);
            }
            else
            {
                search.Parameters.AddWithValue("@id", 0);
            }
            search.Parameters.AddWithValue("@username", textBox13.Text);
            search.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter sda = new SqlDataAdapter(search);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            onlyblind = true;   
        }

        private void button18_Click(object sender, EventArgs e)
        {
            searchbinddata();

        }

        public bool onlyblind = false;

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            if (!onlyblind)
            {
                binddata();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            showpanel(panel10);
        }


        private void inpp(object sender, EventArgs e)
        {
            textBox13.Text = "";
            onlyblind = false;

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void paintrows(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if(e.RowIndex % 2 == 0)
            {
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
            }
        }
    }
}