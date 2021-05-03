using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Developer_page8 : Form
    {
        string id;
        public Developer_page8(string ID)
        {
            InitializeComponent();
            id = ID;
            Developer dv = new Developer();
            label1.Text = dv.get_info(id).NAME;
            pictureBox3.Image = dv.get_info(id).PICTURE;
            pictureBox4.Image = dv.get_info(id).PICTURE;
            button10.BackColor = Color.MediumPurple;

            textBox1.Text = dv.get_info(id).NAME;
            textBox2.Text = dv.get_info(id).AGE.ToString();
            textBox3.Text = dv.get_info(id).PASSWORD;
            textBox4.Text = dv.get_info(id).PASSWORD;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choce youre picture";
            OFD.Filter = "Image File(*.png;*.jpg) |*.png;*.jpg";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = new Bitmap(OFD.FileName);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (textBox3.Text == textBox4.Text)
                {
                    label10.Visible = false;
                    Developer db = new Developer();
                    db.update_info(id, textBox1.Text, textBox3.Text,Convert.ToInt32(textBox2.Text), pictureBox4.Image);
                    MessageBox.Show("Information updated", "Sucessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Text = textBox1.Text;
                    pictureBox3.Image = pictureBox4.Image;
                }
                else
                {
                    label10.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("please fill all the field", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Developer_Dashboard dvd = new Developer_Dashboard(id);
            dvd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page2 db = new Developer_page2(id);
            db.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page1 db = new Developer_page1(id);
            db.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page3 db = new Developer_page3(id);
            db.Show();
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
            Developer_page5 db = new Developer_page5(id);
            db.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page6 db = new Developer_page6(id);
            db.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page7 db = new Developer_page7(id);
            db.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page9 dv = new Developer_page9(id);
            dv.Show();
        }
    }
}
