using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Collections;

namespace Project
{
    public partial class Admin_page2 : Form
    {
        string id;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        bool pic_change = false;
        public Admin_page2(string ID)
        {
            
            InitializeComponent();
            id = ID;
            Admin admin = new Admin();
            label2.Text = admin.get_Info(id).NAME;
            pictureBox1.Image = admin.get_Info(id).PIC;
            button3.BackColor = Color.MediumPurple;
            Developer dv = new Developer();
            
            Cource c = new Cource();
            ArrayList list = c.see_cource();
            foreach (string need in list)
            {
                comboBox1.Items.Add(need);
            }    

        }

        //INSERT DATA IN GRID VIEW TABLE 
        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text)  || String.IsNullOrEmpty(textBox4.Text)  || String.IsNullOrEmpty(comboBox1.Text) || pic_change == false || numericUpDown1.Value==0)
            {
                MessageBox.Show("please! Fill All Column!","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (textBox4.Text == textBox2.Text)
                {
                    label8.Visible = false;
                    Developer db = new Developer();
                    string new_id = db.insert_developer(textBox4.Text, textBox1.Text, comboBox1.Text, Convert.ToInt32(numericUpDown1.Value),pictureBox3.Image);
                    MessageBox.Show(new_id, "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    label8.Visible = true;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choce youre picture";
            OFD.Filter = "Image File(*.png;*.jpg) |*.png;*.jpg";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(OFD.FileName);
                pic_change = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
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
            Login_page log = new Login_page();
            log.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard ad = new Admin_Dashboard(id);
            ad.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page1 ad = new Admin_page1(id);
            ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page3 Ad = new Admin_page3(id);
            Ad.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page4 ad = new Admin_page4(id);
            ad.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page5 admin = new Admin_page5(id);
            admin.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page6 admin = new Admin_page6(id);
            admin.Show();
        }
    }
}
