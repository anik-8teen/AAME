using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Member_page5 : Form
    {
        string id;
        public Member_page5(string ID)
        {
            InitializeComponent();
            id = ID;
            Member mb = new Member();
            label1.Text = mb.get_Name(ID);
            //mb.get_PIC(ID);
            pictureBox3.Image = mb.get_PIC(ID);
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            //button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.MediumPurple;
            Developer dv = new Developer();
            dataGridView1.DataSource = dv.bind_lactureDataGrid(mb.get_info(id).DEVELOPER_ID);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard Dv = new Dashboard();
            Dv.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Dashbord md = new Member_Dashbord(id);
            md.Show();
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
            Member_page1 memeber = new Member_page1(id);
            memeber.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page2 memeber = new Member_page2(id);
            memeber.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page3 memeber = new Member_page3(id);
            memeber.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page4 memeber = new Member_page4(id);
            memeber.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page6 mbd = new Member_page6(id);
            mbd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_page6 mbd = new Member_page6(id);
            mbd.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column1")
            {
                Developer dv = new Developer();
                Member mb = new Member();
                dv.download_lactureNote(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value), mb.get_info(id).DEVELOPER_ID );
                MessageBox.Show("Shaved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Column2")
            {
                int selected_note = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
                Member mb = new Member();
                if (selected_note == mb.get_info(id).LACTURE_NOTE_COMPLETED + 1)
                {
                    string mess = "Your Lacture Note Completed List upgraded.Now you can sit in next quiz, If available.";
                    mb.update_doneLactureNoteNumber(id);
                    MessageBox.Show(mess, "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(selected_note<= mb.get_info(id).LACTURE_NOTE_COMPLETED)
                {
                    MessageBox.Show("You already added it to your completed list!", "AAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Complete previous note fast!", "AAME", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
