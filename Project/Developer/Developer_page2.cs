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
    public partial class Developer_page2 : Form
    {
        string id;
        public Developer_page2(string ID)
        {
            InitializeComponent();
            id = ID;
            Developer dv = new Developer();
            label1.Text = dv.get_info(id).NAME;
            pictureBox3.Image = dv.get_info(id).PICTURE;
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.MediumPurple;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page1 da_d = new Developer_page1(id);
            da_d.Show();
        }


        private void richTextBox1_Enter_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "(Question Name)")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = Color.Black;
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "(Question Name)";
                richTextBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "(Enter Quiz  Name)")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "(Enter Quiz  Name)";
                textBox1.ForeColor = Color.LightGray;
            }
            
        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "(Option 1)")
            {
                richTextBox2.Text = "";
                richTextBox2.ForeColor = Color.Black;
            }
            
        }

        private void richTextBox2_Leave(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                richTextBox2.Text = "(Option 1)";
                richTextBox2.ForeColor = Color.LightGray;
            }
        }

        private void richTextBox3_Enter(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "(Option 2)")
            {
                richTextBox3.Text = "";
                richTextBox3.ForeColor = Color.Black;
            }
        }

        private void richTextBox3_Leave(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "")
            {
                richTextBox3.Text = "(Option 2)";
                richTextBox3.ForeColor = Color.LightGray;
            }
        }

        private void richTextBox4_Enter(object sender, EventArgs e)
        {
            if (richTextBox4.Text == "(Option 3)")
            {
                richTextBox4.Text = "";
                richTextBox4.ForeColor = Color.Black;
            }
        }

        private void richTextBox4_Leave(object sender, EventArgs e)
        {
            if (richTextBox4.Text == "")
            {
                richTextBox4.Text = "(Option 3)";
                richTextBox4.ForeColor = Color.LightGray;
            }
        }
        static int si=0;
        static ArrayList quiz_q;
        private void button8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox1.Text != "(Enter Quiz  Name)")
            {
                textBox1.ReadOnly = true;
                button8.Visible = false;
                si = 1;
                panel1.Visible = true;
                quiz_q = new ArrayList();
                quiz_q.Clear();
            }
            else
            {
                MessageBox.Show("please fill the fild", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        //dv.insert_question(si, textBox1.Text, richTextBox1.Text, richTextBox2.Text, richTextBox3.Text, richTextBox4.Text, Convert.ToInt32(numericUpDown1.Value), richTextBox2.Text, id);
        private void button9_Click(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text!="" && richTextBox2.Text != "" && richTextBox3.Text != "" && richTextBox4.Text != "" && richTextBox1.Text!= "(Question Name)" && richTextBox2.Text != "(Option 1)" && richTextBox3.Text != "(Option 2)" && richTextBox4.Text != "(Option 3)")
            {
                if(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                {
                    Quiz_info quiz; 
                    if (radioButton1.Checked)
                    {
                        quiz= new Quiz_info();
                        quiz.SI = si;
                        si = si + 1;
                        quiz.QUIZ_NAME = textBox1.Text;
                        quiz.QUESTION = richTextBox1.Text;
                        quiz.OPTION1 = richTextBox2.Text;
                        quiz.OPTION2 = richTextBox3.Text;
                        quiz.OPTION3 = richTextBox4.Text;
                        quiz.POINT = Convert.ToInt32(numericUpDown1.Value);
                        quiz.CORRECT_ANS= richTextBox2.Text;
                        quiz.DEVELOPER_ID = id;
                        quiz_q.Add(quiz);
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        richTextBox1.Text = "(Question Name)";
                        richTextBox1.ForeColor = Color.LightGray;
                        richTextBox2.Text = "(Option 1)";
                        richTextBox2.ForeColor = Color.LightGray;
                        richTextBox3.Text = "(Option 2)";
                        richTextBox3.ForeColor = Color.LightGray;
                        richTextBox4.Text = "(Option 3)";
                        richTextBox4.ForeColor = Color.LightGray;

                    }
                    else if (radioButton2.Checked)
                    {
                        quiz = new Quiz_info();
                        quiz.SI = si;
                        si = si + 1;
                        quiz.QUIZ_NAME = textBox1.Text;
                        quiz.QUESTION = richTextBox1.Text;
                        quiz.OPTION1 = richTextBox2.Text;
                        quiz.OPTION2 = richTextBox3.Text;
                        quiz.OPTION3 = richTextBox4.Text;
                        quiz.POINT = Convert.ToInt32(numericUpDown1.Value);
                        quiz.CORRECT_ANS = richTextBox3.Text;
                        quiz.DEVELOPER_ID = id;
                        quiz_q.Add(quiz);
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        richTextBox1.Text = "(Question Name)";
                        richTextBox1.ForeColor = Color.LightGray;
                        richTextBox2.Text = "(Option 1)";
                        richTextBox2.ForeColor = Color.LightGray;
                        richTextBox3.Text = "(Option 2)";
                        richTextBox3.ForeColor = Color.LightGray;
                        richTextBox4.Text = "(Option 3)";
                        richTextBox4.ForeColor = Color.LightGray;
                    }
                    else if (radioButton3.Checked)
                    {
                        quiz = new Quiz_info();
                        quiz.SI = si;
                        si = si + 1;
                        quiz.QUIZ_NAME = textBox1.Text;
                        quiz.QUESTION = richTextBox1.Text;
                        quiz.OPTION1 = richTextBox2.Text;
                        quiz.OPTION2 = richTextBox3.Text;
                        quiz.OPTION3 = richTextBox4.Text;
                        quiz.POINT = Convert.ToInt32(numericUpDown1.Value);
                        quiz.CORRECT_ANS = richTextBox4.Text;
                        quiz.DEVELOPER_ID = id;
                        quiz_q.Add(quiz);
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        richTextBox1.Text = "(Question Name)";
                        richTextBox1.ForeColor = Color.LightGray;
                        richTextBox2.Text = "(Option 1)";
                        richTextBox2.ForeColor = Color.LightGray;
                        richTextBox3.Text = "(Option 2)";
                        richTextBox3.ForeColor = Color.LightGray;
                        richTextBox4.Text = "(Option 3)";
                        richTextBox4.ForeColor = Color.LightGray;
                    }

                }
                else
                {
                    MessageBox.Show("please select correct ans", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("please fill all the fild", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && richTextBox2.Text != "" && richTextBox3.Text != "" && richTextBox4.Text != "" && richTextBox1.Text != "(Question Name)" && richTextBox2.Text != "(Option 1)" && richTextBox3.Text != "(Option 2)" && richTextBox4.Text != "(Option 3)")
            {
                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                {
                    Quiz_info quiz;
                    if (radioButton1.Checked)
                    {
                        quiz = new Quiz_info();
                        quiz.SI = si;
                        si = si + 1;
                        quiz.QUIZ_NAME = textBox1.Text;
                        quiz.QUESTION = richTextBox1.Text;
                        quiz.OPTION1 = richTextBox2.Text;
                        quiz.OPTION2 = richTextBox3.Text;
                        quiz.OPTION3 = richTextBox4.Text;
                        quiz.POINT = Convert.ToInt32(numericUpDown1.Value);
                        quiz.CORRECT_ANS = richTextBox2.Text;
                        quiz.DEVELOPER_ID = id;
                        quiz_q.Add(quiz);
                        panel1.Enabled = false;
                        dataGridView1.Visible = true;
                        button12.Visible = true;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        richTextBox1.Text = "(Question Name)";
                        richTextBox1.ForeColor = Color.LightGray;
                        richTextBox2.Text = "(Option 1)";
                        richTextBox2.ForeColor = Color.LightGray;
                        richTextBox3.Text = "(Option 2)";
                        richTextBox3.ForeColor = Color.LightGray;
                        richTextBox4.Text = "(Option 3)";
                        richTextBox4.ForeColor = Color.LightGray;
                        numericUpDown1.Value = 0;
                        Developer dv = new Developer();
                        dv.insert_question(quiz_q, id);
                        dv.update_AddQuizInfo(id);
                        Developer dvv = new Developer();
                        ArrayList list = dv.get_quizInfo(id, dvv.get_info(id).QUIZ_ADD);
                        foreach (Quiz_info quiz1 in list)
                        {
                            dataGridView1.Rows.Add(new Object[]{
                            quiz1.SI,
                            quiz1.QUESTION,
                            quiz1.QUIZ_NO

                           });
                        }

                    }
                    else if (radioButton2.Checked)
                    {
                        quiz = new Quiz_info();
                        quiz.SI = si;
                        si = si + 1;
                        quiz.QUIZ_NAME = textBox1.Text;
                        quiz.QUESTION = richTextBox1.Text;
                        quiz.OPTION1 = richTextBox2.Text;
                        quiz.OPTION2 = richTextBox3.Text;
                        quiz.OPTION3 = richTextBox4.Text;
                        quiz.POINT = Convert.ToInt32(numericUpDown1.Value);
                        quiz.CORRECT_ANS = richTextBox3.Text;
                        quiz.DEVELOPER_ID = id;
                        quiz_q.Add(quiz);
                        panel1.Enabled = false;
                        dataGridView1.Visible = true;
                        button12.Visible = true;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        richTextBox1.Text = "(Question Name)";
                        richTextBox1.ForeColor = Color.LightGray;
                        richTextBox2.Text = "(Option 1)";
                        richTextBox2.ForeColor = Color.LightGray;
                        richTextBox3.Text = "(Option 2)";
                        richTextBox3.ForeColor = Color.LightGray;
                        richTextBox4.Text = "(Option 3)";
                        richTextBox4.ForeColor = Color.LightGray;
                        numericUpDown1.Value = 0;
                        Developer dv = new Developer();
                        dv.insert_question(quiz_q, id);
                        dv.update_AddQuizInfo(id);
                        Developer dvv = new Developer();
                        ArrayList list = dv.get_quizInfo(id, dvv.get_info(id).QUIZ_ADD);
                        foreach (Quiz_info quiz1 in list)
                        {
                            dataGridView1.Rows.Add(new Object[]{
                            quiz1.SI,
                            quiz1.QUESTION,
                            quiz1.QUIZ_NO

                           });
                        }
                    }
                    else if (radioButton3.Checked)
                    {
                        quiz = new Quiz_info();
                        quiz.SI = si;
                        si = si + 1;
                        quiz.QUIZ_NAME = textBox1.Text;
                        quiz.QUESTION = richTextBox1.Text;
                        quiz.OPTION1 = richTextBox2.Text;
                        quiz.OPTION2 = richTextBox3.Text;
                        quiz.OPTION3 = richTextBox4.Text;
                        quiz.POINT = Convert.ToInt32(numericUpDown1.Value);
                        quiz.CORRECT_ANS = richTextBox4.Text;
                        quiz.DEVELOPER_ID = id;
                        quiz_q.Add(quiz);
                        panel1.Enabled = false;
                        dataGridView1.Visible = true;
                        button12.Visible = true;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        richTextBox1.Text = "(Question Name)";
                        richTextBox1.ForeColor = Color.LightGray;
                        richTextBox2.Text = "(Option 1)";
                        richTextBox2.ForeColor = Color.LightGray;
                        richTextBox3.Text = "(Option 2)";
                        richTextBox3.ForeColor = Color.LightGray;
                        richTextBox4.Text = "(Option 3)";
                        richTextBox4.ForeColor = Color.LightGray;
                        numericUpDown1.Value = 0;
                        Developer dv = new Developer();
                        dv.insert_question(quiz_q, id);
                        dv.update_AddQuizInfo(id);
                        Developer dvv = new Developer();
                        ArrayList list = dv.get_quizInfo(id, dvv.get_info(id).QUIZ_ADD);
                        foreach (Quiz_info quiz1 in list)
                        {
                            dataGridView1.Rows.Add(new Object[]{
                            quiz1.SI,
                            quiz1.QUESTION,
                            quiz1.QUIZ_NO

                           });
                        }
                    }

                }
                else
                {
                    MessageBox.Show("please select correct ans", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("please fill all the fild", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int need_si=Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string nees_q = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int quiz_no = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            Developer dv = new Developer();
            ArrayList list = dv.get_quizInfo(id, quiz_no);
            Quiz_info q = new Quiz_info();
            foreach(Quiz_info need in list)
            {
                if(need.SI==need_si && need.QUESTION == nees_q)
                {
                    q = need;
                    break;
                }
            }
            richTextBox1.ForeColor = Color.Black;
            richTextBox2.ForeColor = Color.Black;
            richTextBox3.ForeColor = Color.Black;
            richTextBox4.ForeColor = Color.Black;
            richTextBox1.Text = q.QUESTION;
            richTextBox2.Text = q.OPTION1;
            richTextBox3.Text = q.OPTION2;
            richTextBox4.Text = q.OPTION3;
            numericUpDown1.Value = q.POINT;

            if (q.CORRECT_ANS== richTextBox2.Text)
            {
                radioButton1.Checked=true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                richTextBox2.ForeColor = Color.LimeGreen;
            }
            else if (q.CORRECT_ANS == richTextBox3.Text)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
                radioButton3.Checked = false;
                richTextBox3.ForeColor = Color.LimeGreen;
            }
            else if (q.CORRECT_ANS == richTextBox4.Text)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = true;
                richTextBox4.ForeColor = Color.LimeGreen;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            textBox1.ReadOnly = false;
            button12.Visible = false;
            button8.Visible = true;
            panel1.Visible = false;
            textBox1.Text = "(Enter Quiz  Name)";
            textBox1.ForeColor = Color.LightGray;
            dataGridView1.Rows.Clear();
            dataGridView1.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            richTextBox1.Text = "(Question Name)";
            richTextBox1.ForeColor = Color.LightGray;
            richTextBox2.Text = "(Option 1)";
            richTextBox2.ForeColor = Color.LightGray;
            richTextBox3.Text = "(Option 2)";
            richTextBox3.ForeColor = Color.LightGray;
            richTextBox4.Text = "(Option 3)";
            richTextBox4.ForeColor = Color.LightGray;
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page7 mamber = new Developer_page7(id);
            mamber.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page8 db = new Developer_page8(id);
            db.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page9 dv = new Developer_page9(id);
            dv.Show();
        }
    }
}
