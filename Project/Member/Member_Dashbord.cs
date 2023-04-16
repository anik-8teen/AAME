using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Member_Dashbord : Form
    {
        string id;
        public Member_Dashbord(string ID)
        {
            InitializeComponent();
            id = ID;
            Member mb = new Member();
            label1.Text = mb.get_Name(ID);

            pictureBox3.Image = mb.get_PIC(ID);

            if (mb.get_info(id).HAS_DEVELOPER == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button6.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button6.Enabled = true;
                button5.Enabled = true;
                button4.Enabled = true;
            }
            textBox1.Text = mb.get_info(id).COURSE;
            textBox2.Text = mb.get_info(id).EMAIL;
            textBox3.Text = mb.get_info(id).MOBILE_NO;
            textBox6.Text = Convert.ToString(mb.get_info(id).QUIZ_ATTEND);
            textBox7.Text = Convert.ToString(mb.get_info(id).QUIZ_MARK);
            textBox8.Text = Convert.ToString(mb.get_info(id).PROBLEM_SOLVED);
            textBox9.Text = Convert.ToString(mb.get_info(id).PROBLEM_POINT);
            textBox10.Text = Convert.ToString(mb.get_info(id).LACTURE_NOTE_COMPLETED);
            if (mb.get_info(id).HAS_DEVELOPER == 0)
            {
                textBox5.Text = "Inactive";
                textBox5.ForeColor = Color.Red;
            }
            else
            {
                textBox5.Text = "Active";
                textBox5.ForeColor = Color.Green;
            }
            Developer dv = new Developer();
            if (mb.get_info(id).HAS_DEVELOPER != 0)
            {
                label14.Visible = true;
                label15.Visible = true;
                pictureBox4.Visible = true;
                label15.Text = dv.get_info(mb.get_info(id).DEVELOPER_ID).NAME;
                pictureBox4.Image = dv.get_info(mb.get_info(id).DEVELOPER_ID).PICTURE;
            }
            else
            {
                label14.Visible =false;
                label15.Visible = false;
                pictureBox4.Visible = false;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page login = new Login_page();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page1 member1 = new Member_page1(id);
            member1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page2 member2 = new Member_page2(id);
            member2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page3 member3 = new Member_page3(id);
            member3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page4 member = new Member_page4(id);
            member.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page5 memeber = new Member_page5(id);
            memeber.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page6 mbd = new Member_page6(id);
            mbd.Show();
        }
    }
}
