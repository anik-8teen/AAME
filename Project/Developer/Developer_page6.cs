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
    public partial class Developer_page6 : Form
    {
        string id;
        string member_id;
        int old_point;
        int si;
        bool edit = false;
        Problem_answerInfo ans = new Problem_answerInfo();
        string ans_name;
        public Developer_page6(string ID)
        {
            InitializeComponent();
            id = ID;
            button6.BackColor = Color.MediumPurple;
            Developer dv = new Developer();
            label1.Text = dv.get_info(id).NAME;
            pictureBox3.Image = dv.get_info(id).PICTURE;
            dataGridView1.DataSource= dv.bind_problemAnsDataGrid(id);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dv = new Dashboard();
            dv.Show();
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
            Developer_Dashboard developer = new Developer_Dashboard(id);
            developer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page1 developer = new Developer_page1(id);
            developer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page2 developer = new Developer_page2(id);
            developer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page3 developer = new Developer_page3(id);
            developer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page4 developer = new Developer_page4(id);
            developer.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page5 developer = new Developer_page5(id);
            developer.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button12.Enabled = true;
            button13.Enabled = true;
            button7.Visible = true;
            button8.Visible = true;

            Member mb = new Member();
            member_id= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            si = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            ans = mb.get_problemAnsInfo(member_id, id, si);

            pictureBox4.Image = mb.get_info(member_id).PIC;
            richTextBox1.ForeColor = Color.Black;
            richTextBox2.ForeColor = Color.Black;
            richTextBox1.Text = mb.get_info(member_id).NAME;
            richTextBox2.Text = ans.PROBLEM_NAME;
            numericUpDown1.Value = ans.POINT;
            ans_name = ans.PROBLEM_NAME+" " + member_id;

            if (ans.FEEDBACK == "")
            {
                numericUpDown2.Value = 0;
                numericUpDown2.ReadOnly = false;
                richTextBox3.ReadOnly = false;
            }
            else
            {
                richTextBox3.ForeColor = Color.Black;
                richTextBox3.ReadOnly = true;
                richTextBox3.Text = ans.FEEDBACK;
                numericUpDown2.Value = ans.GET_POINT;
                old_point = ans.GET_POINT;
                button9.Visible = true;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {     
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            string path;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = dialog.FileName + "/" + ans.PROBLEM_NAME + ".pdf";
                File.WriteAllBytes(path, ans.DATA);
            }
            MessageBox.Show("Downloaded", "AAME", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            string path;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = dialog.FileName + "/" + ans_name + ".pdf";
                File.WriteAllBytes(path, ans.ANSWER);
            }
            MessageBox.Show("Downloaded", "AAME", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(richTextBox3.Text!="" && richTextBox3.Text!= "(Feedback)" && edit==false)
            {
                if (Convert.ToInt32(numericUpDown2.Value) == 0)
                {
                    if (MessageBox.Show("Are you sure point of this problem is 0?", "AAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Member mb = new Member();
                        mb.update_problemAns(member_id, id, Convert.ToInt32(numericUpDown2.Value), richTextBox3.Text, si);
                        richTextBox1.ForeColor = Color.LightGray;
                        richTextBox2.ForeColor = Color.LightGray;
                        richTextBox3.ForeColor = Color.LightGray;
                        richTextBox1.Text = "(Member Name)";
                        richTextBox2.Text = "(Problem Name)";
                        richTextBox3.Text = "(Feedback)";
                        richTextBox3.ReadOnly = true;
                        numericUpDown2.ForeColor = Color.Black;
                        button7.Visible = false;
                        button8.Visible = false;
                        button9.Visible = false;
                        numericUpDown1.Value = 0;
                        numericUpDown2.Value = 0;
                        button12.Enabled = false;
                        button13.Enabled = false;
                        numericUpDown2.ReadOnly = true;
                        edit = false;
                        pictureBox4.Image = Properties.Resources.Choce_photo;
                    }
                }
                else
                {
                    Member mb = new Member();
                    mb.update_problemAns(member_id, id, Convert.ToInt32(numericUpDown2.Value), richTextBox3.Text, si);
                    richTextBox1.ForeColor = Color.LightGray;
                    richTextBox2.ForeColor = Color.LightGray;
                    richTextBox3.ForeColor = Color.LightGray;
                    richTextBox1.Text = "(Member Name)";
                    richTextBox2.Text = "(Problem Name)";
                    richTextBox3.Text = "(Feedback)";
                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    button12.Enabled = false;
                    button13.Enabled = false;
                    richTextBox3.ReadOnly = true;
                    button7.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    numericUpDown2.ReadOnly = true;
                    edit = false;
                    numericUpDown2.ForeColor = Color.Black;
                    pictureBox4.Image = Properties.Resources.Choce_photo;
                }

                MessageBox.Show("Point Added", "AAME", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else if(richTextBox3.Text!="" && richTextBox3.Text!= "(Feedback)" && edit)
            {
                Member mb = new Member();
                mb.update_problemAns_Edit(member_id, id, Convert.ToInt32(numericUpDown2.Value),old_point, richTextBox3.Text, si);
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox1.Text = "(Member Name)";
                richTextBox2.Text = "(Problem Name)";
                richTextBox3.Text = "(Feedback)";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                button12.Enabled = false;
                button13.Enabled = false;
                richTextBox3.ReadOnly = true;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                numericUpDown2.ReadOnly = true;
                edit = false;
                numericUpDown2.ForeColor = Color.Black;
                pictureBox4.Image = Properties.Resources.Choce_photo;
                MessageBox.Show("Point Added", "AAME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Add a feedback!", "AAME", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to discus this?", "AAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                richTextBox1.ForeColor = Color.LightGray;
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox3.ForeColor = Color.LightGray;
                richTextBox1.Text = "(Member Name)";
                richTextBox2.Text = "(Problem Name)";
                richTextBox3.Text = "(Feedback)";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                button12.Enabled = false;
                button13.Enabled = false;
                richTextBox3.ReadOnly = true;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                numericUpDown2.ReadOnly = true;
                edit = false;
                pictureBox4.Image = Properties.Resources.Choce_photo;
                numericUpDown2.ForeColor = Color.Black;
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            edit = true;
            richTextBox3.ForeColor = Color.Blue;
            numericUpDown2.ForeColor = Color.Blue;
            richTextBox3.ReadOnly = false;
            numericUpDown2.ReadOnly = false;
        }

        private void richTextBox3_Enter(object sender, EventArgs e)
        {
            if(richTextBox3.Text== "(Feedback)")
            {
                richTextBox3.Text = "";
                richTextBox3.ForeColor = Color.Black;
            }
        }

        private void richTextBox3_Leave(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "")
            {
                richTextBox3.Text = "(Feedback)";
                richTextBox3.ForeColor = Color.LightGray;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Developer_page7 mamber = new Developer_page7(id);
            mamber.Show();
        }

        private void button11_Click(object sender, EventArgs e)
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
