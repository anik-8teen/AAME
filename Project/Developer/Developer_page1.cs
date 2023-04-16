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
    public partial class Developer_page1 : Form
    {
        string id;
        public Developer_page1(String ID)
        {
            InitializeComponent();
            richTextBox2.Enabled = false;
            id = ID;
            Developer dv = new Developer();
            label1.Text = dv.get_info(id).NAME;
            pictureBox3.Image = dv.get_info(id).PICTURE;
            dataGridView1.DataSource = dv.BindQustionDataGridView(id);
            button1.BackColor = Color.MediumPurple;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
        }


        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard da = new Dashboard();
            da.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login_page login = new Login_page();
            login.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_Dashboard da_d = new Developer_Dashboard(id);
            da_d.Show();
        }



        private void button8_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text != "" && richTextBox2.Text!= "richTextBox2.Text")
            {
                Developer dv = new Developer();
                Developer_Question dq = dv.get_Question_info(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString());

                richTextBox2.Enabled = false;
                dv.insert_question_Reply(dq.MEMBER_ID, richTextBox3.Text, richTextBox2.Text,id);
                button7.Visible = false;
                button8.Visible = false;
                richTextBox3.Text = "Title";
                richTextBox1.Text = "Details";
                richTextBox2.Text = "No reply yet";
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox1.ForeColor = Color.LightGray;
                
                dataGridView1.DataSource = dv.BindQustionDataGridView(id);
            }
            else
            {
                MessageBox.Show("Please add reply fast", "Admin_page1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to discard this?", "Admin_page1", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                richTextBox2.Enabled = false;
                button7.Visible = false;
                button8.Visible = false;
                richTextBox3.Text = "Title";
                richTextBox1.Text = "Details";
                richTextBox2.Text = "No reply yet";
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox1.ForeColor = Color.LightGray;
                
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button7.Visible = true;
            button8.Visible = true;
            Developer dv = new Developer();
            Developer_Question need = dv.get_Question_info(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString());

            richTextBox2.Enabled = true;
            richTextBox3.Text = need.QUESTION_TITLE;
            richTextBox3.ForeColor = Color.Black;
            richTextBox1.Text = need.QUESTION_DETAILS;
            richTextBox1.ForeColor = Color.Black;
           
        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            if(richTextBox2.Text== "No reply yet")
            {
                richTextBox2.Text = "";
                richTextBox2.ForeColor = Color.Black;
            }
        }

        private void richTextBox2_Leave(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                richTextBox2.Text = "No reply yet";
                richTextBox2.ForeColor = Color.LightGray; ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page2 dv = new Developer_page2(id);
            dv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page3 dv = new Developer_page3(id);
            dv.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page4 db = new Developer_page4(id);
            db.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page5 dv = new Developer_page5(id);
            dv.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page6 developer = new Developer_page6(id);
            developer.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page7 mamber = new Developer_page7(id);
            mamber.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page8 db = new Developer_page8(id);
            db.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page9 dv = new Developer_page9(id);
            dv.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "Type here for sarche")
            {
                Developer mb = new Developer();
                DataView dv = new DataView(mb.BindQustionDataGridView(id));
                dv.RowFilter = string.Format("Title LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = dv;
            }
        }
    }
}
