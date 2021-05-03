using System;
using System.Collections;
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
    public partial class Admin_page1 : Form
    {
        string id;
        public Admin_page1(string ID)
        {
            id = ID;
            InitializeComponent();
            this.button1.BackColor = Color.MediumPurple;
            this.button2.BackColor = Color.WhiteSmoke;
            this.button3.BackColor = Color.WhiteSmoke;
            this.button4.BackColor = Color.WhiteSmoke;
            Admin ad = new Admin();

            label2.Text = ad.get_Info(ID).NAME;
            pictureBox1.Image = ad.get_Info(id).PIC;
            Member mb = new Member();
            dataGridView1.DataSource = mb.InactiveDataTable();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page2 ad = new Admin_page2(id);
            ad.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page4 ad = new Admin_page4(id);
            ad.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_page3 Ad = new Admin_page3(id);
            Ad.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard db =new Dashboard();
            db.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page login = new Login_page();
            login.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            richTextBox4.Text = "(Nathing Selected)";
            richTextBox4.ForeColor = Color.LightGray;
            comboBox1.Items.Clear();
            comboBox1.Enabled = true;
            button5.Visible = true;
            button6.Visible = true;
            Member mb = new Member();
            string member_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Member_Info need = mb.get_info(member_id);
            richTextBox1.Text =need.NAME;
            richTextBox1.ForeColor = Color.Black;
            richTextBox2.Text = need.ID;
            richTextBox2.ForeColor = Color.Black;
            richTextBox3.Text = need.COURSE;
            richTextBox3.ForeColor = Color.Black;
            pictureBox3.Image = need.PIC;

            Developer dv = new Developer();
            ArrayList list = dv.get_info_For_ADD_Member();

            //Developer_Info select;
            foreach(Developer_Info dinfo in list)
            {
                if (dinfo.COURSE == need.COURSE)
                {
                    comboBox1.Items.Add(dinfo.ID);   
                }
            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Member mb = new Member();
                mb.updateInactiveMemberInfo(richTextBox2.Text, comboBox1.Text);
                Member member = new Member();
                MessageBox.Show("Developer Added", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = member.InactiveDataTable();
                button5.Visible = false;
                button6.Visible = false;
                richTextBox1.Text = "(Nathing Selected)";
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox2.Text = "(Nathing Selected)";
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox3.Text = "(Nathing Selected)";
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox4.Text = "(Nathing Selected)";
                richTextBox4.ForeColor = Color.LightGray;
                comboBox1.Items.Clear();
                pictureBox3.Image = Properties.Resources.Choce_photo;
                comboBox1.Enabled = false;
                dataGridView1.DataSource = mb.InactiveDataTable();
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to discard this?", "Admin_page1", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button5.Visible = false;
                button6.Visible = false;
                richTextBox1.Text = "(Nathing Selected)";
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox2.Text = "(Nathing Selected)";
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox3.Text = "(Nathing Selected)";
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox4.Text = "(Nathing Selected)";
                richTextBox4.ForeColor = Color.LightGray;
                comboBox1.Items.Clear();
                pictureBox3.Image = Properties.Resources.Choce_photo;
                comboBox1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Developer dv = new Developer();
                richTextBox4.Text = dv.get_info(comboBox1.Text).NAME;
                richTextBox4.ForeColor = Color.Black;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard add = new Admin_Dashboard(id);
            add.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard log = new Dashboard();
            log.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login_page log = new Login_page();
            log.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
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
