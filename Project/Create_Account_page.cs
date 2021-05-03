using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

namespace Project
{
    public partial class Create_Account_page : Form
    {
        
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        bool pic_change = false;
        ArrayList couse_list = new ArrayList();
        public Create_Account_page()
        {
            InitializeComponent();
            Cource cos = new Cource();
            couse_list = cos.see_cource();
            comboBox1.Items.Clear();

            foreach (string need in couse_list)
            {
                comboBox1.Items.Add(need);
            }

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Aqua;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(comboBox1.Text) || pic_change==false)
            {
                MessageBox.Show("please! Fill All Column!");
            }
            else
            {
                if (textBox3.Text == textBox5.Text)
                {
                    label10.Visible = false;
                    Member mem = new Member();
                    string ID = mem.insert(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, textBox4.Text, pictureBox2.Image);
                    MessageBox.Show(ID);
                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }
                else
                {
                    label10.Visible = true;
                }
            }
        }

        private byte[] SavePhoto()
        {
            
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            string st = Convert.ToString(ms.GetBuffer());
            
            return ms.GetBuffer();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
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
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choce youre picture";
            OFD.Filter = "Image File(*.png;*.jpg) |*.png;*.jpg";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(OFD.FileName);
                pic_change = true;
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
    }
}
