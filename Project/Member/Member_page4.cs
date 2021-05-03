using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Member_page4 : Form
    {
        string id;
        public Member_page4(string ID)
        {
            InitializeComponent();
            id = ID;
            Member mb = new Member();
            label1.Text = mb.get_Name(ID);
            dataGridView1.DataSource = mb.feedback_data(ID,mb.get_info(id).DEVELOPER_ID);
            //mb.get_PIC(ID);
            pictureBox3.Image = mb.get_PIC(ID);
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            //button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.MediumPurple;
            button6.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard db = new Dashboard();
            db.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Dashbord mb = new Member_Dashbord(id);
            mb.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page log = new Login_page();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page1 member = new Member_page1(id);
            member.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page2 member = new Member_page2(id);
            member.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page3 member = new Member_page3(id);
            member.Show();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            richTextBox2.ForeColor = Color.Black;
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Member mb = new Member();
            richTextBox2.Text = mb.Get_feedback(id, mb.get_info(id).DEVELOPER_ID, dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            richTextBox1.ForeColor = Color.LightGray;
            richTextBox2.ForeColor = Color.LightGray;
            richTextBox1.Text = "(Title of feedback)";
            richTextBox2.Text = "(Details of feedback)";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!= "(Type here title for sarche)")
            {
                Member mb = new Member();
                DataView dv = new DataView(mb.feedback_data(id,mb.get_info(id).DEVELOPER_ID));
                dv.RowFilter = string.Format("Title LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = dv;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "(Type here title for sarche)")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "(Type here title for sarche)";
                textBox1.ForeColor = Color.LightGray;
            }
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
