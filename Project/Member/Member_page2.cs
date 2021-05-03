
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
    public partial class Member_page2 : Form
    {
        string id;
        static int quiz_Qcount = 1;
        static int total_mark = 0;
        ArrayList quiz_ans=new ArrayList();
        static ArrayList wrong_list = new ArrayList();
        public Member_page2(string ID)
        {
            InitializeComponent();
            id = ID;
            Member mb = new Member();
            if (Quiz_Has())
            {
                if (mb.get_QuizName(ID, mb.get_info(id).QUIZ_ATTEND, mb.get_info(id).DEVELOPER_ID) != null)
                {
                    label2.Text = "Available Quiz Name:" + mb.get_QuizName(ID, mb.get_info(id).QUIZ_ATTEND, mb.get_info(id).DEVELOPER_ID);
                    button8.Visible = true;
                    label2.ForeColor = Color.Black;
                }
                else
                {
                    label2.Text = "No Quiz Available Yet!";
                    button8.Visible = false;
                    label2.ForeColor = Color.Red;
                }
            }
            else
            {
                label2.Text = "Complete Your lacture note fast!";
                button8.Visible = false;
                label2.ForeColor = Color.Red;
            }

            
            label4.Text = "You Attend "+Convert.ToString(mb.get_info(ID).QUIZ_ATTEND)+" Quiz";
            label8.Text = "Your  Total Mark: " + Convert.ToString(mb.get_info(ID).QUIZ_MARK);
            label1.Text = mb.get_Name(ID);
            //mb.get_PIC(ID);
            pictureBox3.Image = mb.get_PIC(ID);
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.MediumPurple;
            button3.BackColor = Color.WhiteSmoke;
            //button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
        }

        public bool Quiz_Has()
        {
            Member mb = new Member();
            if (mb.get_info(id).QUIZ_ATTEND< mb.get_info(id).LACTURE_NOTE_COMPLETED )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Member_page1 member1 = new Member_page1(id);
            member1.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
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
            Member_Dashbord member2 = new Member_Dashbord(id);
            member2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page3 member3 = new Member_page3(id);
            member3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Member mb = new Member();
            dataGridView1.Rows.Clear();
            wrong_list.Clear();
            button11.Visible = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            button9.Visible = true;
            panel1.Visible = true;
            quiz_Qcount = 1;
            label3.Text = mb.get_quizQuestion(id, quiz_Qcount, mb.get_info(id).QUIZ_ATTEND+1, mb.get_info(id).DEVELOPER_ID).QUESTION;
            this.label3.AutoSize = false;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButton1.Text= mb.get_quizQuestion(id, quiz_Qcount, mb.get_info(id).QUIZ_ATTEND + 1, mb.get_info(id).DEVELOPER_ID).OPTION1;
            radioButton2.Text = mb.get_quizQuestion(id, quiz_Qcount, mb.get_info(id).QUIZ_ATTEND + 1, mb.get_info(id).DEVELOPER_ID).OPTION2;
            radioButton3.Text = mb.get_quizQuestion(id, quiz_Qcount, mb.get_info(id).QUIZ_ATTEND + 1, mb.get_info(id).DEVELOPER_ID).OPTION3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            if (radioButton1.Checked==true || radioButton2.Checked==true || radioButton3.Checked==true)
            {
                Member mb = new Member();
                if (quiz_Qcount == 1)
                {
                    quiz_ans.Clear();
                }
                Quiz_Ans ans = new Quiz_Ans();
                if (radioButton1.Checked)
                {
                    ans.ANS = radioButton1.Text;
                    ans.SI = quiz_Qcount;
                    ans.QUIZ_NO = mb.get_info(id).QUIZ_ATTEND + 1;
                    quiz_ans.Add(ans);
                }
                else if (radioButton2.Checked)
                {
                    ans.ANS = radioButton2.Text;
                    ans.SI = quiz_Qcount;
                    ans.QUIZ_NO = mb.get_info(id).QUIZ_ATTEND + 1;
                    quiz_ans.Add(ans);
                }
                else if (radioButton3.Checked)
                {
                    ans.ANS = radioButton3.Text;
                    ans.SI = quiz_Qcount;
                    ans.QUIZ_NO = mb.get_info(id).QUIZ_ATTEND + 1;
                    quiz_ans.Add(ans);
                }

                quiz_Qcount += 1;
                if (mb.get_quizQuestion(id, quiz_Qcount,mb.get_info(id).QUIZ_ATTEND+1, mb.get_info(id).DEVELOPER_ID) != null)
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    label3.Text = mb.get_quizQuestion(id, quiz_Qcount, mb.get_info(id).QUIZ_ATTEND + 1, mb.get_info(id).DEVELOPER_ID).QUESTION;
                    radioButton1.Text = mb.get_quizQuestion(id, quiz_Qcount, mb.get_info(id).QUIZ_ATTEND + 1, mb.get_info(id).DEVELOPER_ID).OPTION1;
                    radioButton2.Text = mb.get_quizQuestion(id, quiz_Qcount, mb.get_info(id).QUIZ_ATTEND + 1, mb.get_info(id).DEVELOPER_ID).OPTION2;
                    radioButton3.Text = mb.get_quizQuestion(id, quiz_Qcount, mb.get_info(id).QUIZ_ATTEND + 1,mb.get_info(id).DEVELOPER_ID).OPTION3;
                }
                else
                {
                    button9.Visible = false;
                    button10.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Please select your answer fast!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Member mb = new Member();
            foreach (Quiz_Ans ans in quiz_ans)
            {
                
                total_mark =mb.start_Quiz(id, ans.SI, ans.ANS, ans.QUIZ_NO, mb.get_info(id).DEVELOPER_ID);
            }
            mb.update_quizInfo(id, total_mark);
            Member member = new Member();
            label4.Text = "You Attend " + Convert.ToString(member.get_info(id).QUIZ_ATTEND) + " Quiz";
            label8.Text = "Your  Total Mark: " + Convert.ToString(member.get_info(id).QUIZ_MARK);
            label9.Text = "Your point of this quiz is  " + Convert.ToString(total_mark) + ".";
            label9.Visible = true;
            button10.Visible = false;
            button12.Visible = true;
            button11.Visible = false;
            //wrong_list.Clear();
            wrong_list = member.get_wrong_QuizAns(id, member.get_info(id).QUIZ_ATTEND);

            if (wrong_list != null)
            {
                label10.Visible = true;
                Wrong_Ans wans = new Wrong_Ans();
                Wrong_Ans fast_wans = new Wrong_Ans();
                int count = 0;
                foreach (Wrong_Ans ans in wrong_list)
                {
                    if (count == 0)
                    {
                        fast_wans = ans;
                        count++;
                    }
                    dataGridView1.Rows.Add(new Object[]{
                    ans.SI,
                    ans.QUIESTION
                    });
                }
                dataGridView1.Visible = true;
                label3.Text = fast_wans.QUIESTION;
                //MessageBox.Show(Convert.ToString(member.get_info(id).QUIZ_ATTEND));
                //MessageBox.Show(Convert.ToString(fast_wans.SI));
                radioButton1.Text = member.get_quizQuestion(id, fast_wans.SI,member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).OPTION1;
                radioButton2.Text = member.get_quizQuestion(id, fast_wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).OPTION2;
                radioButton3.Text = member.get_quizQuestion(id, fast_wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).OPTION3;
                if(radioButton1.Text== member.get_quizQuestion(id, fast_wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).CORRECT_ANS)
                {
                    radioButton1.ForeColor = Color.LimeGreen;
                    radioButton2.ForeColor = Color.Black;
                    radioButton3.ForeColor = Color.Black;
                }
                else if (radioButton2.Text == member.get_quizQuestion(id, fast_wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).CORRECT_ANS)
                {
                    radioButton1.ForeColor = Color.Black;
                    radioButton2.ForeColor = Color.LimeGreen;
                    radioButton3.ForeColor = Color.Black;
                }
                else if (radioButton3.Text == member.get_quizQuestion(id, fast_wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).CORRECT_ANS)
                {
                    radioButton1.ForeColor = Color.Black;
                    radioButton2.ForeColor = Color.Black;
                    radioButton3.ForeColor = Color.LimeGreen;
                }

                if(radioButton1.Text == fast_wans.WRONG_ANS)
                {
                    radioButton1.Checked = true;
                    radioButton1.ForeColor = Color.Red;
                }
                else if (radioButton2.Text == fast_wans.WRONG_ANS)
                {
                    radioButton2.Checked = true;
                    radioButton2.ForeColor = Color.Red;
                }
                else if (radioButton3.Text == fast_wans.WRONG_ANS)
                {
                    radioButton3.Checked = true;
                    radioButton3.ForeColor = Color.Red;
                }
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Member mb = new Member();
            label9.Visible = false;
            panel1.Visible = false;
            button12.Visible = false;
            if (Quiz_Has())
            {
                if (mb.get_QuizName(id, mb.get_info(id).QUIZ_ATTEND, mb.get_info(id).DEVELOPER_ID) != null)
                {
                    label2.Text = "Available Quiz Name:" + mb.get_QuizName(id, mb.get_info(id).QUIZ_ATTEND, mb.get_info(id).DEVELOPER_ID);
                    button8.Visible = true;
                    label2.ForeColor = Color.Black;
                }
                else
                {
                    label2.Text = "No Quiz Available Yet!";
                    button8.Visible = false;
                    label2.ForeColor = Color.Red;
                }
            }
            else
            {
                label2.Text = "Complete Your lacture note fast!";
                button8.Visible = false;
                label2.ForeColor = Color.Red;
            }
            label10.Visible = false;
            dataGridView1.Visible = false;
            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            radioButton3.ForeColor = Color.Black;



        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to discard this?", "Admin_page1", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Member member = new Member();
                label4.Text = "You Attend " + Convert.ToString(member.get_info(id).QUIZ_ATTEND) + " Quiz";
                label8.Text = "Your  Total Mark: " + Convert.ToString(member.get_info(id).QUIZ_MARK);
                panel1.Visible = false;
                button11.Visible = false;
                button8.Visible = true;
                button10.Visible = false;

            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            radioButton3.ForeColor = Color.Black;
            Member member = new Member();    
            string SI = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int si = Convert.ToInt32(SI);
            string question = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Wrong_Ans wans = new Wrong_Ans();
            foreach (Wrong_Ans ans in wrong_list)
            {
                if (ans.SI == si)
                {
                    wans = ans;
                }
            }

            dataGridView1.Visible = true;
            label3.Text = wans.QUIESTION;
            radioButton1.Text = member.get_quizQuestion(id, wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).OPTION1;
            radioButton2.Text = member.get_quizQuestion(id, wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).OPTION2;
            radioButton3.Text = member.get_quizQuestion(id, wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).OPTION3;
            if (radioButton1.Text == member.get_quizQuestion(id, wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).CORRECT_ANS)
            {

                radioButton1.ForeColor = Color.LimeGreen;
            }
            else if (radioButton2.Text == member.get_quizQuestion(id, wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).CORRECT_ANS)
            {
                radioButton2.ForeColor = Color.LimeGreen;
            }
            else if (radioButton3.Text == member.get_quizQuestion(id, wans.SI, member.get_info(id).QUIZ_ATTEND, member.get_info(id).DEVELOPER_ID).CORRECT_ANS)
            {
                radioButton3.ForeColor = Color.LimeGreen;
            }

            if (radioButton1.Text == wans.WRONG_ANS)
            {
                radioButton1.Checked = true;
                radioButton1.ForeColor = Color.Red;
            }
            else if (radioButton2.Text == wans.WRONG_ANS)
            {
                radioButton2.Checked = true;
                radioButton2.ForeColor = Color.Red;
            }
            else if (radioButton3.Text == wans.WRONG_ANS)
            {
                radioButton3.Checked = true;
                radioButton3.ForeColor = Color.Red;
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

