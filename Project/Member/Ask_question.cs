using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Ask_question : Form
    {
        string id;
        public Ask_question(string ID)
        {
            InitializeComponent();
            id = ID;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Member mb = new Member();
            if (richTextBox1.Text!="" && richTextBox1.Text!= "Write title here" && richTextBox1.Text!="" && richTextBox1.Text!= "Write Details Here")
            {
                if (mb.Is_titleUnique(id, textBox1.Text))
                {
                    mb.insert_question(id, textBox1.Text, richTextBox1.Text,mb.get_info(id).DEVELOPER_ID);
                    MessageBox.Show("Qustion Added", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Member_page3 member = new Member_page3(id);
                    member.Show();
                }
                else
                {
                    MessageBox.Show("Title Not Uniqe", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }
            else
            {
                MessageBox.Show("please fill all the field","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "Write title here")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Write title here";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text == "Write Details Here")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = Color.Black;
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "Write Details Here";
                richTextBox1.ForeColor = Color.LightGray;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to discard this?", "AAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Member_page3 mb = new Member_page3(id);
                mb.Show();
            }
            
        }
    }
}
