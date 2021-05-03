using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Admin_page6 : Form
    {
        string id;
        public Admin_page6(string ID)
        {
            InitializeComponent();
            id = ID;
            Admin admin = new Admin();
            label2.Text = admin.get_Info(id).NAME;
            pictureBox1.Image = admin.get_Info(id).PIC;
            button6.BackColor = Color.MediumPurple;
            comboBox();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page log = new Login_page();
            log.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard admin = new Admin_Dashboard(id);
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page1 admin = new Admin_page1(id);
            admin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page2 admin = new Admin_page2(id);
            admin.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page3 admin = new Admin_page3(id);
            admin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page4 admin = new Admin_page4(id);
            admin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page5 admin = new Admin_page5(id);
            admin.Show();
        }

        public void comboBox()
        {
            Cource cource = new Cource();
            ArrayList couse_list = cource.see_cource();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select Course");
            foreach (string need in couse_list)
            {
                comboBox1.Items.Add(need);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Select Course")
            {
                Developer dv = new Developer();
                ArrayList developer_list = dv.developer_list();
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Select Developer");
                foreach (Developer_Info need in developer_list)
                {
                    if (need.COURSE == comboBox1.Text)
                    {
                        comboBox2.Items.Add(need.ID);
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Member mb = new Member();
            ArrayList member_list = mb.member_list();
            
            if(comboBox2.Text!= "Select Developer")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Select Member");
                foreach (Member_Info q in member_list)
                {
                    if (q.DEVELOPER_ID == comboBox2.Text)
                    {
                        comboBox3.Items.Add(q.ID);
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Member mb = new Member();
            Member_Info info = mb.get_info(comboBox3.Text);
            if (comboBox3.Text != "Select Member")
            {
                pictureBox3.Image = info.PIC;
                label14.Text = info.NAME;
                textBox1.Text = info.COURSE;
                textBox2.Text = info.EMAIL;
                textBox6.Text = info.QUIZ_ATTEND.ToString();
                textBox3.Text = info.MOBILE_NO;
                textBox7.Text = info.QUIZ_MARK.ToString();
                textBox10.Text = info.LACTURE_NOTE_COMPLETED.ToString();
                textBox8.Text = info.PROBLEM_SOLVED.ToString();
                textBox9.Text = info.PROBLEM_POINT.ToString();

                if (info.HAS_DEVELOPER == 0)
                {
                    textBox5.Text = "Inactive";
                    textBox5.ForeColor = Color.Red;
                }
                else
                {
                    textBox5.Text = "Active";
                    textBox5.ForeColor = Color.Green;
                }
            }
            

        }
    }
}

