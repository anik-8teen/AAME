using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Member_page1 : Form
    {
        string id;
        
        public Member_page1(string ID)
        {
            InitializeComponent();
            id = ID;
            Member mb = new Member();
            label1.Text = mb.get_Name(ID);
            Member_Info mbs = mb.get_info(ID);
            textBox1.Text = mbs.NAME;
            textBox2.Text = mbs.EMAIL;
            textBox4.Text = mbs.MOBILE_NO;
            textBox3.Text = mbs.PASSWORD;
            textBox5.Text = mbs.PASSWORD;
            //mb.get_PIC(ID);
            pictureBox4.Image = mbs.PIC;
            pictureBox3.Image = mb.get_PIC(ID);
            button1.BackColor = Color.MediumPurple;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page2 member2 = new Member_page2(id);
            member2.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Dashbord member = new Member_Dashbord(id);
            member.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choce youre picture";
            OFD.Filter = "Image File(*.png;*.jpg) |*.png;*.jpg";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = new Bitmap(OFD.FileName);
                
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&& textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                if (textBox3.Text == textBox5.Text)
                {
                    label10.Visible = false;
                    Member mb = new Member();
                    mb.update_info(id, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, pictureBox4.Image);
                    MessageBox.Show("Information updated", "Sucessfull" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.BackColor = Color.Aqua;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.WhiteSmoke;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Aqua;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.WhiteSmoke;
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page6 mbd = new Member_page6(id);
            mbd.Show();
        }
    }
}
