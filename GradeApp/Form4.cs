using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeApp
{
    public partial class Form4 : Form
    {
        public int userid;
        public string username;

        public Form4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //panel2.Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = false;
            panel11.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //panel2.Visible=true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        SqlConnection newconn = new SqlConnection(@"Data Source=DESKTOP-5ETB5FH;Initial Catalog=studentmanagement;Integrated Security=True");
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            newconn.Open();

            SqlCommand find = new SqlCommand("select count(*) from course where id=@id", newconn); // get number of rows equal to id
            find.Parameters.AddWithValue("@id", userid);

            int count = (int)find.ExecuteScalar(); // store the number of rows in a int variable

            if (count > 0) // check if there are rows in the table
            {
                SqlCommand cmd = new SqlCommand("select course from course where id=@id", newconn);
                cmd.Parameters.AddWithValue("@id", userid);

                SqlDataReader reader = cmd.ExecuteReader(); // execute the command and store the result in a reader


                Point panelloc = new Point(20, 70);   // set the location of the first panel


                while (reader.Read())//iterate through all rows
                {
                    string coursename = reader["course"].ToString(); // get the course name from the reader


                    Label displaylabel = new Label();
                    Label status = new Label();
                    Label discription = new Label();
                    Panel coursepan = new Panel();
                    Panel progress = new Panel();
                    Label presentage = new Label();
                    Button view = new Button();


                    coursepan.Size = new Size(570, 138);
                    coursepan.Location = panelloc;
                    coursepan.BackColor = Color.White;


                    displaylabel.Location = new Point(5, 4);
                    displaylabel.Text = coursename;
                    displaylabel.AutoSize = true;
                    displaylabel.ForeColor = Color.Black;
                    displaylabel.Font = new Font("Segoe UI", 15, FontStyle.Bold);


                    status.Location = new Point(510, 15);
                    status.Text = "Status";
                    status.AutoSize = true;
                    status.ForeColor = Color.White;
                    status.BackColor = ColorTranslator.FromHtml("#4a90e2");  // add color using HEX code
                    status.Padding = new Padding(5);


                    discription.Location = new Point(5, 34);
                    discription.Text = "Learn the basics of C++ programming";
                    discription.AutoSize = true;
                    discription.ForeColor = Color.Black;
                    discription.Font = new Font("Segoe UI", 12, FontStyle.Regular);

                    progress.Location = new Point(10, 70);
                    progress.BackColor = Color.DarkGray;
                    progress.Size = new Size(510, 8);


                    presentage.Location = new Point(530, 60);
                    presentage.Text = "0%";
                    presentage.AutoSize = true;
                    presentage.ForeColor = Color.Black;
                    presentage.Font = new Font("Segoe UI", 12, FontStyle.Regular);

                    view.Location = new Point(10, 89);
                    view.Text = "View Details";
                    view.Size = new Size(550, 37);
                    view.BackColor = ColorTranslator.FromHtml("#4a90e2");
                    view.FlatAppearance.BorderSize = 0;
                    view.FlatStyle = FlatStyle.Flat;
                    view.ForeColor = Color.White;
                    view.Font = new Font("Segoe UI", 12, FontStyle.Bold);




                    panelloc.Y += 155;  // move down for next panel

                    coursepan.Controls.Add(displaylabel); // add the labels/buttons/panels to the panel
                    coursepan.Controls.Add(status);
                    coursepan.Controls.Add(discription);
                    coursepan.Controls.Add(progress);
                    coursepan.Controls.Add(presentage);
                    coursepan.Controls.Add(view);


                    this.panel2.Controls.Add(coursepan);  // add panel to the main panel



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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

            newconn.Open();

            SqlCommand find = new SqlCommand("select count(*) from course where id=@id", newconn);
            find.Parameters.AddWithValue("@id", userid);

            int count = (int)find.ExecuteScalar(); // store the number of rows in a int variable

            if (count > 0) // check if there are rows in the table
            {
                SqlCommand cmd = new SqlCommand("select course,grade from course where id=@id", newconn);
                cmd.Parameters.AddWithValue("@id", userid);

                SqlDataReader reader = cmd.ExecuteReader(); // execute the command and store the result in a reader


                Point coursepoint = new Point(10, 10);
                Point newgradepoint=new Point(265, 10);


                
                Panel gradepanel = new Panel();
                gradepanel.Location = new Point(20, 137);
                gradepanel.BackColor = Color.White; 

                int panheight = 45;
                while (reader.Read())//iterate through all rows
                {
                    gradepanel.Size = new Size(747, panheight);

                    string coursename = reader["course"].ToString();
                    string studentsgrade = reader["grade"].ToString();


                    Label displaylabel = new Label();
                    displaylabel.Location = coursepoint;
                    displaylabel.Text = coursename;
                    displaylabel.AutoSize = true;
                    displaylabel.ForeColor = Color.Black;
                    displaylabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    gradepanel.Controls.Add(displaylabel);
                    coursepoint.Y +=45 ;


                    Label displaygrade = new Label();
                    displaygrade.Location = newgradepoint;
                    displaygrade.Text = studentsgrade;
                    displaygrade.AutoSize = true;
                    displaygrade.ForeColor = Color.Black;
                    displaygrade.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    gradepanel.Controls.Add(displaygrade);
                    newgradepoint.Y += 45;

                    panheight += 50; // increase the height of the panel for each course




                }

                this.panel3.Controls.Add(gradepanel);  // add panel to the main panel
                reader.Close(); // close the reader after use





            }
            else
            {
                // if no course is found create a label called dislabel1 and display a message
                Label dislabel = new Label();
                Point newpoint = new Point(30, 80);
                dislabel.Location = newpoint;
                dislabel.Text = "No grades found";
                dislabel.AutoSize = true;
                dislabel.ForeColor = Color.Red;
                dislabel.Font = new Font("Arial", 12, FontStyle.Bold);
                this.panel3.Controls.Add(dislabel); // display the label on the panel

            }
            newconn.Close();


        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = false;
            panel11.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click_1(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel11.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            label25.Text = username;
            newconn.Open();

            SqlCommand find = new SqlCommand("select count(*) from course where id=@id", newconn);
            find.Parameters.AddWithValue("@id", userid);

            int count = (int)find.ExecuteScalar();

            Point newpoint = new Point(20, 198); // set the location of the first label

            if (count > 0)
            {
                SqlCommand cmd = new SqlCommand("select course from course where id=@id", newconn);
                cmd.Parameters.AddWithValue("@id", userid);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())//iterate through all rows
                {
                    string coursename = reader["course"].ToString();
                    Label displaylabel = new Label();
                    Label status = new Label();
                    displaylabel.Location = newpoint;
                    displaylabel.Text = coursename;
                    displaylabel.ForeColor = Color.Black;
                    displaylabel.BackColor = Color.DarkGray;
                    displaylabel.Size = new Size(480, 30);
                    displaylabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                    this.panel4.Controls.Add(displaylabel);
                    newpoint.Y += 40;


                }
            }
            else
            {
                // if no course is found create a label called dislabel1 and display a message
                Label dislabel = new Label();
                Point newpointx = new Point(30, 80);
                dislabel.Location = newpointx;
                dislabel.Text = "No courses found";
                dislabel.AutoSize = true;
                dislabel.ForeColor = Color.Red;
                dislabel.Font = new Font("Arial", 12, FontStyle.Bold);
                this.panel4.Controls.Add(dislabel); // display the label on the panel

            }

            newconn.Close();

            Label dashmarks = new Label();
            dashmarks.Location = new Point(newpoint.X, newpoint.Y + 10);
            dashmarks.Text = "Marks";
            dashmarks.ForeColor = Color.Black;
            dashmarks.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dashmarks.AutoSize = true;
            this.panel4.Controls.Add(dashmarks);





        }

        private void panel9_Paint(object sender, PaintEventArgs e) // add rounded corners to the panel9
        {

            int cornerRadius = 30; // Adjust the radius 
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle panelRect = panel9.ClientRectangle;
            panelRect.Width -= 1; // Adjust for border
            panelRect.Height -= 1;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(panelRect.X, panelRect.Y, cornerRadius, cornerRadius, 180, 90); // Top-left corner
                path.AddArc(panelRect.Right - cornerRadius, panelRect.Y, cornerRadius, cornerRadius, 270, 90); // Top-right corner
                path.AddArc(panelRect.Right - cornerRadius, panelRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom-right corner
                path.AddArc(panelRect.X, panelRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom-left corner
                path.CloseFigure();


                using (Brush brush = new SolidBrush(panel9.BackColor))
                {
                    g.FillPath(brush, path); // Fill the panel with its background color
                }

                using (Pen pen = new Pen(Color.Black, 1)) // Optional: Add a border
                {
                    g.DrawPath(pen, path);
                }

            }
        }

        private void panel18_Paint(object sender, PaintEventArgs e) // add rounded border for panel18(search button panel)
        {
            int cornerRadius = 10; // Adjust the radius
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle panelRect = panel18.ClientRectangle;
            panelRect.Width -= 1; // Adjust for border
            panelRect.Height -= 1;

            using (GraphicsPath path = new GraphicsPath())
            {
                // Create rounded rectangle path
                path.AddArc(panelRect.X, panelRect.Y, cornerRadius, cornerRadius, 180, 90); // Top-left corner
                path.AddArc(panelRect.Right - cornerRadius, panelRect.Y, cornerRadius, cornerRadius, 270, 90); // Top-right corner
                path.AddArc(panelRect.Right - cornerRadius, panelRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom-right corner
                path.AddArc(panelRect.X, panelRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom-left corner
                path.CloseFigure();

                // Fill the panel with its background color
                using (Brush brush = new SolidBrush(panel18.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Draw the border inside the rounded rectangle
                using (Pen pen = new Pen(Color.LightGray, 2)) // Adjust border color and thickness as needed
                {
                    g.DrawPath(pen, path);
                }



            }
        }

        private void courseenter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
