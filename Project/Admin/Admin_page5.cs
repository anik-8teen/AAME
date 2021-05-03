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
    public partial class Admin_page5 : Form
    {
        string id;
        public Admin_page5(string ID)
        {
            InitializeComponent();
            id = ID;
            Admin admin = new Admin();
            label2.Text = admin.get_Info(id).NAME;
            pictureBox1.Image = admin.get_Info(id).PIC;
            button1.BackColor = Color.MediumPurple;
            comboBox();
        }
        public void comboBox()
        {
            Cource cource = new Cource();
            ArrayList couse_list = cource.see_cource();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select Course");
            foreach(string need in couse_list)
            {
                comboBox1.Items.Add(need);
            }

           
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text!= "Select Developer")
            {
                Developer dv = new Developer();
                ArrayList developer_list = dv.developer_list();
                Developer_Info need = new Developer_Info();

                foreach (Developer_Info dev in developer_list)
                {
                    if (dev.ID == comboBox2.Text)
                    {
                        need = dev;
                        break;
                    }
                }
                Member mb = new Member();
                label6.Text = need.NAME;
                pictureBox3.Image = need.PICTURE;
                textBox1.Text = need.COURSE;
                textBox2.Text = need.AGE.ToString();
                textBox7.Text = need.QUIZ_ADD.ToString();
                textBox10.Text = need.NOTE_ADDED.ToString();
                textBox3.Text = need.PROBLEM_ADDED.ToString();
                textBox5.Text = mb.member_list(comboBox2.Text).Count.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page6 admin = new Admin_page6(id);
            admin.Show();
        }
    }
}
