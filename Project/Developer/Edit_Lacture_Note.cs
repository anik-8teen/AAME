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
    public partial class Edit_Lacture_Note : Form
    {
        string id;
        int si;
        public Edit_Lacture_Note(string ID,int SI)
        {
            InitializeComponent();
            id = ID;
            si = SI;
        }

        byte[] barFile = null;
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "(Lacture note name)")
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Choce file";
                openFileDialog1.Filter = "Image File(*.pdf) |*.pdf";

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
            else
            {
                MessageBox.Show("Enter lacture note name fast", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (barFile != null)
            {
                Developer dv = new Developer();
                dv.update_lacture(id, textBox1.Text, barFile,si);
                MessageBox.Show("Data Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Developer_page4 db = new Developer_page4(id);
                db.Show();
                return;
               
            }
            else
            {
                MessageBox.Show("Select file fast", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to discard this?", "AAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Developer_page4 db = new Developer_page4(id);
                db.Show();
                return;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "(Lacture note name)")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "(Lacture note name)";
                textBox1.ForeColor = Color.LightGray;
            }
        }
    }
}
