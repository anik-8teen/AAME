using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Member_page6 : Form
    {
        string id;
        byte[] barFile;
        int si;
        Problem_answerInfo ans ;
        public Member_page6(string ID)
        {
            InitializeComponent();
            id = ID;
            Member mb = new Member();
            label1.Text = mb.get_Name(ID);
            //mb.get_PIC(ID);
            pictureBox3.Image = mb.get_PIC(ID);
            button4.BackColor = Color.MediumPurple;
            dataGridView1.DataSource = mb.bind_ProblemDataGrid(ID, mb.get_info(id).DEVELOPER_ID);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dv = new Dashboard();
            dv.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Dashbord mbd = new Member_Dashbord(id);
            mbd.Show();
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
            Member_page1 mbd = new Member_page1(id);
            mbd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page2 mbd = new Member_page2(id);
            mbd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page3 mbd = new Member_page3(id);
            mbd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page4 mbd = new Member_page4(id);
            mbd.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page5 mbd = new Member_page5(id);
            mbd.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            richTextBox1.ForeColor = Color.LightGray;
            richTextBox1.Text = "(Problem Name)";
            richTextBox2.ForeColor = Color.LightGray;
            richTextBox2.Text = "(Feedback)";
            button10.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            label3.Visible = false;
            label2.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown1.Value = 0;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button11.Visible = false;

            si =Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            Member mb = new Member();

            Developer dv = new Developer();
            Problem_Info info = dv.get_problem(mb.get_info(id).DEVELOPER_ID, si);
            richTextBox1.Text = info.PROBLEM_NAME;
            richTextBox1.ForeColor = Color.Black;
            button12.Enabled = true;
            numericUpDown1.Value = info.POINT;
            ans = mb.get_problemAnsInfo(id, mb.get_info(id).DEVELOPER_ID, si);

            if (ans == null)
            {
                button10.Enabled = true;
                button7.Visible = true;
                button8.Visible = true;
            }
            else
            {
                button13.Enabled = true;
                label2.Visible = true;

                if (ans.FEEDBACK == "")
                {
                    button7.Visible = true;
                    button8.Visible = true;
                    button9.Visible = true;
                }
                else
                {
                    label3.Visible = true;
                    numericUpDown2.Visible = true;
                    numericUpDown2.Value = ans.GET_POINT;
                    richTextBox2.Text = ans.FEEDBACK;
                    richTextBox2.ForeColor = Color.Black;
                    button11.Visible = true;
                }

            }
            
        }

      
        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Choce file";
            openFileDialog1.Filter = "PDF File(*.pdf) |*.pdf";
            openFileDialog1.Filter = "PDF File(*.pdf) |*.pdf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = "";
                long nLength = 0;

                if (openFileDialog1.FileName != "")
                {
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                    FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                    sFileName = fileInfo.Name;
                    nLength = fs.Length;
                    barFile = new byte[fs.Length];
                    fs.Read(barFile, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                }
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (barFile != null && ans==null)
            {
                Member mb = new Member();
                Developer db = new Developer();
                Problem_Info need = db.get_problem(mb.get_info(id).DEVELOPER_ID, si);
                mb.uplode_problemAns(id, mb.get_info(id).DEVELOPER_ID, mb.get_info(id).COURSE, need.POINT, richTextBox1.Text, need.DATA, barFile, si);
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox1.Text = "(Problem Name)";
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox2.Text = "(Feedback)";
                button10.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                label3.Visible = false;
                label2.Visible = false;
                numericUpDown2.Visible = false;
                numericUpDown1.Value = 0;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                MessageBox.Show("Answer Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(barFile != null && ans != null)
            {
                Member mb = new Member();
                mb.update_ans(id,mb.get_info(id).DEVELOPER_ID,barFile,si);
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox1.Text = "(Problem Name)";
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox2.Text = "(Feedback)";
                button10.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                label3.Visible = false;
                label2.Visible = false;
                numericUpDown2.Visible = false;
                numericUpDown1.Value = 0;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                MessageBox.Show("Answer Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Chose a file please!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to discard this?", "AAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox1.Text = "(Problem Name)";
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox2.Text = "(Feedback)";
                button10.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                label3.Visible = false;
                numericUpDown2.Visible = false;
                numericUpDown1.Value = 0;
                button7.Visible = false;
                button8.Visible = false;
                label2.Visible = false;
                button9.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            button10.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Visible = false;
            richTextBox1.ForeColor = Color.LightGray;
            richTextBox1.Text = "(Problem Name)";
            richTextBox2.ForeColor = Color.LightGray;
            richTextBox2.Text = "(Feedback)";
            button10.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            label3.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown1.Value = 0;
            button7.Visible = false;
            button8.Visible = false;
            label2.Visible = false;
            button9.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Member mb = new Member();
            Developer db = new Developer();
            Problem_Info need = db.get_problem(mb.get_info(id).DEVELOPER_ID, si);
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            string path;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = dialog.FileName + "/" + need.PROBLEM_NAME + ".pdf";
                File.WriteAllBytes(path, need.DATA);
            }
            MessageBox.Show("Downloaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Member mb = new Member();
            Problem_answerInfo need= mb.get_problemAnsInfo(id, mb.get_info(id).DEVELOPER_ID, mb.get_info(id).PROBLEM_SOLVED);
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            string ans_name = "Answer ";
            string path;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = dialog.FileName + "/" + ans_name + ".pdf";
                File.WriteAllBytes(path, need.ANSWER);
            }
            MessageBox.Show("Downloaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
