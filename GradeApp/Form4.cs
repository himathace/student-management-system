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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
            SqlConnection newconn=new SqlConnection(@"Data Source=DESKTOP-5ETB5FH;Initial Catalog=studentmanagement;Integrated Security=True");
            newconn.Open();
            SqlCommand find= new SqlCommand("select count(*) from course where id=@id", newconn);
            find.Parameters.AddWithValue("@id", userid);
            int count= (int)find.ExecuteScalar();
            if (count > 0)
            {
                SqlCommand cmd = new SqlCommand("select course from course where id=@id", newconn);
                cmd.Parameters.AddWithValue("@id", userid);
                label22.Text = cmd.ExecuteScalar().ToString();
            }
            else
            {
                label22.Text = "No course found";

            }
            newconn.Close();

        }
    }
}
