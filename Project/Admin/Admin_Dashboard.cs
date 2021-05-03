using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Admin_Dashboard : Form
    {
        string id;
        public Admin_Dashboard(string ID)
        {
            InitializeComponent();
            id = ID;
            Admin ad = new Admin();
            Developer dv = new Developer();
            Member mb = new Member();
            Cource cource = new Cource();
            pictureBox3.Image = ad.get_Info(id).PIC;
            label1.Text = ad.get_Info(id).NAME;
            label4.Text = ad.get_Info(id).EMAIL;
            textBox7.Text = dv.developer_list().Count.ToString();
            textBox2.Text = mb.member_list().Count.ToString();
            textBox4.Text = cource.course_List().Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page1 ad = new Admin_page1(id);
            ad.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page2 ad = new Admin_page2(id);
            ad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page3 Ad = new Admin_page3(id);
            Ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page4 ad = new Admin_page4(id);
            ad.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page5 admin = new Admin_page5(id);
            admin.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page6 admin = new Admin_page6(id);
            admin.Show();
        }
    }
}
