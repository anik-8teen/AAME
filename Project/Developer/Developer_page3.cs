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
    public partial class Developer_page3 : Form
    {
        string id;
        public Developer_page3(string ID)
        {
            InitializeComponent();
            id = ID;
            Developer dv = new Developer();
            label1.Text = dv.get_info(id).NAME;
            pictureBox3.Image = dv.get_info(id).PICTURE;
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.MediumPurple;
            button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
            button7.BackColor = Color.WhiteSmoke;

            ArrayList list = dv.get_Member_id(id);
            if (list != null)
            {
                foreach (string member_id in list)
                {
                    comboBox1.Items.Add(member_id);
                }
            }
            dataGridView1.DataSource = dv.buid_feedback_dataGridview(id);
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard da = new Dashboard();
            da.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_Dashboard dvd = new Developer_Dashboard(id);
            dvd.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login_page log = new Login_page();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page1 dv = new Developer_page1(id);
            dv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page2 dv = new Developer_page2(id);
            dv.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Member mb = new Member();
                pictureBox4.Image = mb.get_info(comboBox1.Text).PIC;
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.Text = mb.get_info(comboBox1.Text).NAME;
                richTextBox2.ReadOnly = false;
                richTextBox3.ReadOnly = false;
                button7.Visible = true;
                button8.Visible = true;
            }
            
        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "(Feedback Title)")
            {
                richTextBox2.Text = "";
                richTextBox2.ForeColor = Color.Black;
            }
        }

        private void richTextBox2_Leave(object sender, EventArgs e)
        {
            if(richTextBox2.Text== "")
            {
                richTextBox2.Text = "(Feedback Title)";
                richTextBox2.ForeColor = Color.LightGray;
            }
        }

        private void richTextBox3_Enter(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "(Feedback Details)")
            {
                richTextBox3.Text = "";
                richTextBox3.ForeColor = Color.Black;
            }
        }

        private void richTextBox3_Leave(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "")
            {
                richTextBox3.Text = "(Feedback Details)";
                richTextBox3.ForeColor = Color.LightGray;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Developer dv = new Developer();
            if(richTextBox2.Text!="" && richTextBox3.Text!="" && richTextBox2.Text != "(Feedback Title)" && richTextBox3.Text != "(Feedback Details)")
            {
                if (dv.has_title(id, richTextBox2.Text,comboBox1.Text)==false)
                {
                    dv.insert_feedback(comboBox1.Text, dv.get_info(id).COURSE, richTextBox2.Text, richTextBox3.Text, id);
                    comboBox1.SelectedIndex = -1;
                    richTextBox1.Text = "(Member Name)";
                    richTextBox1.ForeColor = Color.LightGray;
                    richTextBox2.Text = "(Feedback Title)";
                    richTextBox2.ForeColor = Color.LightGray;
                    richTextBox3.Text = "(Feedback Details)";
                    richTextBox3.ForeColor = Color.LightGray;
                    richTextBox2.ReadOnly = true;
                    richTextBox3.ReadOnly = true;
                    pictureBox4.Image = Project.Properties.Resources.Choce_photo;
                    button7.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    dataGridView1.DataSource = dv.buid_feedback_dataGridview(id);
                }
                else
                {
                    MessageBox.Show("Title Not Uniqe", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("please fill all the field", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            if (MessageBox.Show("Are you sure want to discard this?", "AAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                comboBox1.SelectedIndex = -1;
                richTextBox1.Text = "(Member Name)";
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox2.Text = "(Feedback Title)";
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox3.Text = "(Feedback Details)";
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox2.ReadOnly = true;
                richTextBox3.ReadOnly = true;
                pictureBox4.Image = Project.Properties.Resources.Choce_photo;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
            }
        }
        string old_title;
        string member_id;
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            richTextBox2.ForeColor = Color.Black;
            richTextBox3.ForeColor = Color.Black;
            Member mb = new Member();
            pictureBox4.Image = mb.get_info(dataGridView1.SelectedRows[0].Cells[2].Value.ToString()).PIC;
            old_title = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            member_id = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Developer dv = new Developer();
            Feedback_Info need = new Feedback_Info();
            need=dv.GetFeedback_Info(id, dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            richTextBox1.Text = mb.get_info(dataGridView1.SelectedRows[0].Cells[2].Value.ToString()).NAME;
            richTextBox2.Text = need.TITLE;
            richTextBox3.Text = need.FEEDBACK;
            button8.Visible = true;
            button9.Visible = true;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            richTextBox2.ReadOnly = false;
            richTextBox3.ReadOnly = false;
            richTextBox2.ForeColor = Color.Blue;
            richTextBox3.ForeColor = Color.Blue;
            button9.Visible = false;
            button10.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            Developer dv = new Developer();
            if (richTextBox2.Text != "" && richTextBox3.Text != "" && richTextBox2.Text != "(Feedback Title)" && richTextBox3.Text != "(Feedback Details)")
            {
                if (dv.has_title(id, richTextBox2.Text, comboBox1.Text) == false || old_title==richTextBox2.Text)
                {
                    dv.update_feedback(member_id,richTextBox2.Text, richTextBox3.Text,id, old_title);
                    comboBox1.SelectedIndex = -1;
                    richTextBox1.Text = "(Member Name)";
                    richTextBox1.ForeColor = Color.LightGray;
                    richTextBox2.Text = "(Feedback Title)";
                    richTextBox2.ForeColor = Color.LightGray;
                    richTextBox3.Text = "(Feedback Details)";
                    richTextBox3.ForeColor = Color.LightGray;
                    richTextBox2.ReadOnly = true;
                    richTextBox3.ReadOnly = true;
                    pictureBox4.Image = Project.Properties.Resources.Choce_photo;
                    button7.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    dataGridView1.DataSource = dv.buid_feedback_dataGridview(id);
                }
                else
                {
                    MessageBox.Show("Title Not Uniqe", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("please fill all the field", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "(Type Member ID For sarch)")
            {
                Developer mb = new Developer();
                DataView dv = new DataView(mb.buid_feedback_dataGridview(id));
                dv.RowFilter = string.Format("Title LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = dv;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "(Type Member ID For sarch)")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "(Type Member ID For sarch)";
                textBox1.ForeColor = Color.LightGray;
            }
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

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page7 mamber = new Developer_page7(id);
            mamber.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page8 db = new Developer_page8(id);
            db.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page9 dv = new Developer_page9(id);
            dv.Show();
        }
    }
}
