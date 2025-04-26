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
    public partial class Form4 : Form
    {
        public int userid;
        public Form4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel2.Visible=true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        SqlConnection newconn=new SqlConnection(@"Data Source=DESKTOP-5ETB5FH;Initial Catalog=studentmanagement;Integrated Security=True");
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
            newconn.Open();

            SqlCommand find= new SqlCommand("select count(*) from course where id=@id", newconn); // get number of rows equal to id
            find.Parameters.AddWithValue("@id", userid);

            int count= (int)find.ExecuteScalar(); // store the number of rows in a int variable

            if (count > 0) // check if there are rows in the table
            {
                SqlCommand cmd = new SqlCommand("select course from course where id=@id", newconn);
                cmd.Parameters.AddWithValue("@id", userid);

                SqlDataReader reader = cmd.ExecuteReader(); // execute the command and store the result in a reader

                Point newpoint = new Point(50, 100); // set the location of the first label

                while (reader.Read())//iterate through all rows
                {
                    string coursename = reader["course"].ToString(); // get the course name from the reader
                    Label displaylabel = new Label();
                    displaylabel.Location = newpoint;
                    displaylabel.Text = coursename;
                    displaylabel.AutoSize = true;
                    displaylabel.ForeColor = Color.White;
                    displaylabel.BackColor = Color.SteelBlue;
                    displaylabel.Font = new Font("Arial", 18, FontStyle.Bold);
                    this.panel2.Controls.Add(displaylabel); // display the label on the panel
                    newpoint.Y += 50; // move down for next label
                }



            }
            else
            {
                // if no course is found create a label called dislabel1 and display a message
                Label dislabel = new Label();  
                Point newpoint = new Point(30, 80);
                dislabel.Location = newpoint;
                dislabel.Text = "No courses found";
                dislabel.AutoSize = true;
                dislabel.ForeColor = Color.Red;
                dislabel.Font = new Font("Arial", 12, FontStyle.Bold);
                this.panel2.Controls.Add(dislabel); // display the label on the panel

            }
            newconn.Close();

        }
    }
}
