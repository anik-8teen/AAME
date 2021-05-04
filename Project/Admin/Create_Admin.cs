using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Create_Admin : Form
    {
        bool picture_change = false;
        Admin admin = new Admin();
        string message;
        public Create_Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox3.Text!="" && textBox2.Text!="" && textBox5.Text!="" && picture_change)
            {
                if(textBox3.Text == textBox2.Text)
                {
                    label10.Visible = false;
                    message = admin.Insert_Admin(textBox1.Text, textBox5.Text, textBox3.Text, pictureBox2.Image);
                    MessageBox.Show(message, "AAME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }
                else
                {
                    label10.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Please Fill All The Field", "AAME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choce youre picture";
            OFD.Filter = "Image File(*.png;*.jpg) |*.png;*.jpg";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(OFD.FileName);
                picture_change = true;
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
