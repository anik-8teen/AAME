using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Admin_page4 : Form
    {
        string id;
        public Admin_page4(string ID)
        {
            
            InitializeComponent();
            id = ID;
            Admin admin = new Admin();
            label2.Text = admin.get_Info(id).NAME;
            pictureBox1.Image = admin.get_Info(id).PIC;
            button5.BackColor = Color.MediumPurple;
            Salary salary = new Salary();
            dataGridView1.DataSource = salary.bindSalaryDataGrid();
            numericUpDown1.Maximum = 1000000;
            numericUpDown1.Minimum = 0;
            ComboBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            if(comboBox1.Text!= "Select developer id" && comboBox2.Text != "Select month" && comboBox3.Text != "Select year" && numericUpDown1.Value != 0 && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                if(salary.has_salary(comboBox1.Text, comboBox2.Text, comboBox3.Text)==false)
                {
                    salary.insert_salary(textBox1.Text, Convert.ToInt32(numericUpDown1.Value), comboBox1.Text, comboBox2.Text, comboBox3.Text);
                    dataGridView1.DataSource = salary.bindSalaryDataGrid();
                }
                else
                {
                    MessageBox.Show("Salary already added", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill All the fild", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        void ComboBox()
        {
            Developer dv = new Developer();
            ArrayList developer_list = dv.developer_list();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select developer id");
            comboBox1.SelectedIndex = 0;
            foreach(Developer_Info developer in developer_list)
            {
                comboBox1.Items.Add(developer.ID);
            }
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Select month");
            comboBox2.SelectedIndex = 0;
            var Months = DateTimeFormatInfo.InvariantInfo.MonthNames;
            foreach (string sm in Months)
            {
                comboBox2.Items.Add(sm);
            }
            comboBox3.Items.Clear();
            comboBox3.Items.Add("Select year");
            comboBox3.SelectedIndex = 0;
            for (int i = DateTime.Now.Year-2; i < DateTime.Now.Year + 5; i++)
            {
                comboBox3.Items.Add(i.ToString());
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
            Login_page login = new Login_page();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page1 login = new Admin_page1(id);
            login.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard login = new Admin_Dashboard(id);
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page2 login = new Admin_page2(id);
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page3 login = new Admin_page3(id);
            login.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text!= "Select developer id")
            {
                Developer dv = new Developer();
                textBox1.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;
                textBox1.Text = dv.get_info(comboBox1.Text).NAME;
                textBox2.Text = dv.get_info(comboBox1.Text).COURSE;
                pictureBox3.Image = dv.get_info(comboBox1.Text).PICTURE;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page5 admin = new Admin_page5(id);
            admin.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page6 admin = new Admin_page6(id);
            admin.Show();
        }
    }
}
