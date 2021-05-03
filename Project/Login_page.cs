using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Login_page : Form
    {
        public Login_page()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f1 = new Dashboard();
            f1.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor=Color.Aqua;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Aqua;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.WhiteSmoke;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_Account_page ca = new Create_Account_page();
            ca.Show();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                //comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.Error_icon;
                errorProvider1.SetError(this.comboBox1, "Please fill this fild");
            }
            else
            {
                errorProvider1.SetError(this.comboBox1, " ");
                errorProvider1.Icon = Properties.Resources.Correct_icon;
                
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                //textBox1.Focus();
                errorProvider2.Icon = Properties.Resources.Error_icon;
                errorProvider2.SetError(this.textBox1, "Please fill this fild");
            }
            else
            {
                errorProvider2.SetError(this.textBox1, " ");
                errorProvider2.Icon = Properties.Resources.Correct_icon;
                
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter ID";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                //textBox2.Focus();
                errorProvider3.Icon = Properties.Resources.Error_icon;
                errorProvider3.SetError(this.textBox2, "Please fill this fild");
            }
            else
            {
                errorProvider2.SetError(this.textBox2, " ");
                errorProvider3.Icon = Properties.Resources.Correct_icon;
                
            }
            if (textBox2.Text == "")
            {
                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = "Enter Password";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please fil all the fild!");
            }

            else if(comboBox1.Text== "Admin" && string.IsNullOrEmpty(textBox1.Text) == false && string.IsNullOrEmpty(textBox2.Text) == false)
            {
                Admin ad=new Admin();
                if(ad.login(textBox1.Text, textBox2.Text))
                {
                    label3.Visible = false;
                    this.Hide();
                    Admin_Dashboard amm = new Admin_Dashboard(textBox1.Text);
                    amm.Show();
                }
                else
                {
                    label3.Visible = true;
                }

            }


            else if (comboBox1.Text == "Devoloper" && string.IsNullOrEmpty(textBox1.Text)==false && string.IsNullOrEmpty(textBox2.Text)==false)
            {
                Developer dv = new Developer();
                label3.Visible = false;
                if (dv.login(textBox1.Text, textBox2.Text)){
                    this.Hide();
                    Developer_Dashboard member = new Developer_Dashboard(textBox1.Text);
                    member.Show();
                }
                else
                {
                    label3.Visible = true;
                }
                
            }

            else if(comboBox1.Text== "Member" && string.IsNullOrEmpty(textBox1.Text) == false && string.IsNullOrEmpty(textBox2.Text) == false)
            {

                Member mb = new Member();
                if (mb.login(textBox1.Text, textBox2.Text))
                {

                    label3.Visible = false;
                    this.Hide();
                    Member_Dashbord member = new Member_Dashbord(textBox1.Text);
                    member.Show();
                }

                else
                {
                    label3.Visible = true;
                }
            }

            else
            {

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "Enter ID")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text== "Enter Password")
            {
                textBox2.UseSystemPasswordChar = true;
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked && textBox2.Text!="Enter Password")
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else if(textBox2.Text != "Enter Password")
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
