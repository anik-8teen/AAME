using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Developer_Dashboard : Form
    {
        string id;
        public Developer_Dashboard(string ID)
        {
            InitializeComponent();
            id = ID;
            Developer dv = new Developer();
            Member mb = new Member();
            label1.Text = dv.get_info(id).NAME;
            pictureBox3.Image = dv.get_info(id).PICTURE;
            textBox1.Text = dv.get_info(id).COURSE;
            textBox2.Text = dv.get_info(id).AGE.ToString();
            textBox7.Text = dv.get_info(id).QUIZ_ADD.ToString();
            textBox10.Text = dv.get_info(id).NOTE_ADDED.ToString();
            textBox4.Text = dv.get_info(id).PROBLEM_ADDED.ToString();
            textBox5.Text = mb.member_list(id).Count.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page log = new Login_page();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page1 db_1 = new Developer_page1(id);
            db_1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page2 dv = new Developer_page2(id);
            dv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page3 dv = new Developer_page3(id);
            dv.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page4 db = new Developer_page4(id);
            db.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page5 dv = new Developer_page5(id);
            dv.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page6 developer = new Developer_page6(id);
            developer.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page7 mamber = new Developer_page7(id);
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
