using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = Properties.Resources.Background;
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Process.Start(@"C:\Program Files\Google\Chrome\Application\Chrome.exe", "https://www.aiub.edu/");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login_page f2 = new Login_page();
            f2.Show();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Aqua;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.WhiteSmoke;
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.BackColor = Color.Aqua;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.WhiteSmoke;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Aqua;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.WhiteSmoke;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.Aqua;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.WhiteSmoke;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = Color.Aqua;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.WhiteSmoke;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.Aqua;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.WhiteSmoke;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.BackColor = Color.Aqua;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.WhiteSmoke;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_Account_page ac = new Create_Account_page();
            ac.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page login = new Login_page();
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            About_us about = new About_us();
            about.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
