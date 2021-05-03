using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Member_page3 : Form
    {
        string id;
        string old_title;
        public Member_page3(string ID)
        {
            InitializeComponent();
            id = ID;
            Member mb = new Member();
            label1.Text = mb.get_Name(ID);
            dataGridView1.DataSource = mb.BindQustionDataGridView(ID);
            //mb.get_PIC(ID);
            pictureBox3.Image = mb.get_PIC(ID);
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.MediumPurple;
            //button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
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
            Member_Dashbord mbd = new Member_Dashbord(id);
            mbd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page2 member2 = new Member_page2(id);
            member2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page1 member1 = new Member_page1(id);
            member1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Ask_question question = new Ask_question(id);
            question.Show();
            Member mb = new Member();
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button12.Visible = true;
            Member mb = new Member();
            Member_QuestionInfo need = mb.get_QuestionInfo(id, dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            
            richTextBox3.Text = need.QUESTION_TITLE;
            richTextBox3.ForeColor = Color.Black;
            richTextBox1.Text = need.QUESTION_DETAILS;
            richTextBox1.ForeColor = Color.Black;
            if (need.QUESTION_REPLY=="")
            {

                //richTextBox2.ForeColor = Color.Black;
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox2.Text = "No reply yet";
                button9.Visible = true;
                button10.Visible = true;
                button11.Visible = true;
                button11.Enabled = false;
            }
            else
            {
                richTextBox2.ForeColor = Color.Black;
                richTextBox2.Text = need.QUESTION_REPLY;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //old_title = textBox1.Text;
            button11.Enabled = true;
            old_title = richTextBox3.Text;
            richTextBox3.ReadOnly = false;
            richTextBox1.ReadOnly = false;
            richTextBox3.ForeColor = Color.Blue;
            richTextBox1.ForeColor = Color.Blue;
            //richTextBox2.ForeColor = Color.Blue;
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Member mb = new Member();
            
            if (richTextBox3.Text == old_title && (MessageBox.Show("Are you sure want to change this?", "AAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                mb.member_questionEdit(id, richTextBox3.Text, richTextBox1.Text);
                button11.Enabled = false;
                dataGridView1.DataSource = mb.BindQustionDataGridView(id);
                richTextBox3.ReadOnly = true;
                richTextBox1.ReadOnly = true;
                richTextBox3.ForeColor = Color.Black;
                richTextBox1.ForeColor = Color.Black;
            }
            else if (richTextBox3.Text!=old_title)
            {
                if (mb.Is_titleUnique(id, richTextBox3.Text) && (MessageBox.Show("Are you sure want to change this?", "AAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    mb.member_questionEdit_WithTitle(id, richTextBox3.Text, richTextBox1.Text,old_title);
                    dataGridView1.DataSource = mb.BindQustionDataGridView(id);
                    button11.Enabled = false;
                    richTextBox3.ReadOnly = true;
                    richTextBox1.ReadOnly = true;
                    richTextBox3.ForeColor = Color.Black;
                    richTextBox1.ForeColor = Color.Black;
                }
                else if(mb.Is_titleUnique(id, richTextBox3.Text) == false)
                {
                    MessageBox.Show("Title Not Uniqe", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure want to discrad this?", "Admin_page1", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                richTextBox3.Text = "Title";
                richTextBox1.Text = "Details";
                richTextBox2.Text = "No reply yet";
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox3.ReadOnly = true;
                richTextBox1.ReadOnly = true;
                button9.Visible = false;
                button10.Visible = false;
                button11.Enabled = false;
                button11.Visible = false;
                button12.Visible = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this?", "Admin_page1", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Member mb = new Member();
                mb.member_questionDelete(id, richTextBox3.Text);
                dataGridView1.DataSource = mb.BindQustionDataGridView(id);
                richTextBox3.Text = "Title";
                richTextBox1.Text = "Details";
                richTextBox2.Text = "No reply yet";
                richTextBox3.ReadOnly = true;
                richTextBox2.ReadOnly = true;
                richTextBox1.ReadOnly = true;
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox1.ForeColor = Color.LightGray;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text== "Type here for sarche")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Type here for sarche";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!= "Type here for sarche")
            {
                Member mb = new Member();
                DataView dv = new DataView(mb.BindQustionDataGridView(id));
                dv.RowFilter = string.Format("Title LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = dv;
            }
            
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page6 mbd = new Member_page6(id);
            mbd.Show();
        }
    }
}
