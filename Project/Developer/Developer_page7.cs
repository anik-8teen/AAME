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
    public partial class Developer_page7 : Form
    {
        string id;
        public Developer_page7(string ID)
        {
            InitializeComponent();
            id = ID;
            Developer dv = new Developer();
            label1.Text = dv.get_info(id).NAME;
            button7.BackColor = Color.MediumPurple;
            pictureBox3.Image = dv.get_info(id).PICTURE;
            Member mb = new Member();
            ArrayList list = mb.member_list(id);
            foreach(Member_Info info in list)
            {
                comboBox1.Items.Add(info.ID);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard db = new Dashboard();
            db.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page log = new Login_page();
            log.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_Dashboard member = new Developer_Dashboard(id);
            member.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Member mb = new Member();
            Member_Info info = mb.get_info(comboBox1.Text);
            textBox1.ForeColor = Color.Black;

            pictureBox4.Image = info.PIC;
            textBox1.Text = info.NAME;
            textBox2.Text = info.EMAIL;
            textBox3.Text = info.MOBILE_NO;
            textBox6.Text = info.QUIZ_ATTEND.ToString();
            textBox7.Text = info.QUIZ_MARK.ToString();
            textBox8.Text = info.PROBLEM_SOLVED.ToString();
            textBox9.Text = info.PROBLEM_POINT.ToString();
            textBox10.Text = info.LACTURE_NOTE_COMPLETED.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page1 mamber = new Developer_page1(id);
            mamber.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page2 mamber = new Developer_page2(id);
            mamber.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page3 mamber = new Developer_page3(id);
            mamber.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page4 mamber = new Developer_page4(id);
            mamber.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page5 mamber = new Developer_page5(id);
            mamber.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page6 mamber = new Developer_page6(id);
            mamber.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page8 db = new Developer_page8(id);
            db.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page9 dv = new Developer_page9(id);
            dv.Show();
        }
    }
}
