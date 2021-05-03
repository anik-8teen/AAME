using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Admin_page3 : Form
    {
        string id;
        public Admin_page3(string ID)
        {
           
            InitializeComponent();
            id = ID;
            Admin admin = new Admin();
            label2.Text = admin.get_Info(id).NAME;
            pictureBox1.Image = admin.get_Info(id).PIC;
            button4.BackColor = Color.MediumPurple;
            Cource cource = new Cource();
            dataGridView1.DataSource = cource.bind_courseDataGrid();

        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "(Enter Course Name For Add)")
            {
                bool found_course = false;
                Cource cource = new Cource();
                ArrayList c_list = cource.see_cource();
                foreach(string need in c_list)
                {
                    if (need == textBox1.Text)
                    {
                        found_course = true;
                        break;
                    }
                }
                if (!found_course)
                {
                    Cource cource1 = new Cource();
                    cource1.insert_course(textBox1.Text);
                    dataGridView1.DataSource = cource1.bind_courseDataGrid();
                }
                else
                {
                    MessageBox.Show("You already added this course!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Please insert a course name!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "(Enter Course Name For Add)")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "(Enter Course Name For Add)";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard db = new Dashboard();
            db.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page page = new Login_page();
            page.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard Ad = new Admin_Dashboard(id);
            Ad.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page1 Ad = new Admin_page1(id);
            Ad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page2 Ad = new Admin_page2(id);
            Ad.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page4 Ad = new Admin_page4(id);
            Ad.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page5 admin = new Admin_page5(id);
            admin.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page6 admin = new Admin_page6(id);
            admin.Show();
        }
    }
}
