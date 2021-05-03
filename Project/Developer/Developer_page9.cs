using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Developer_page9 : Form
    {
        string id;
        public Developer_page9(string ID)
        {
            InitializeComponent();
            id = ID;
            Developer dv = new Developer();
            label1.Text = dv.get_info(id).NAME;
            pictureBox3.Image = dv.get_info(id).PICTURE;
            button8.BackColor = Color.MediumPurple;

            Salary salary = new Salary();
            dataGridView1.DataSource = salary.bindSalaryDataGrid_forDeveloper(id);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dv = new Dashboard();
            dv.Show();
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
            Developer_Dashboard dvd = new Developer_Dashboard(id);
            dvd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page1 dv = new Developer_page1(id);
            dv.Show();
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
            Developer_page4 dv = new Developer_page4(id);
            dv.Show();
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
            Developer_page6 dv = new Developer_page6(id);
            dv.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page7 dv = new Developer_page7(id);
            dv.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page8 dv = new Developer_page8(id);
            dv.Show();
        }
    }
}
