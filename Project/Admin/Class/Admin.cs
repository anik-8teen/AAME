using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    class Admin
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        static ArrayList info;
        public Admin()
        {
            this.edit_info();
        }

        public void edit_info()
        {
            info = new ArrayList();
            info.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Admin_Table";
            SqlCommand cmd = new SqlCommand(query, con);

            info = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Admin_Info ad = new Admin_Info();
                    ad.ID = Convert.ToString(dr.GetValue(0));
                    ad.PASSWORD = Convert.ToString(dr.GetValue(1));
                    ad.NAME = Convert.ToString(dr.GetValue(2));
                    ad.EMAIL = Convert.ToString(dr.GetValue(3));
                    Byte[] pic;
                    pic = (byte[])dr.GetValue(4);
                    MemoryStream ms = new MemoryStream(pic);
                    ad.PIC = Image.FromStream(ms);
                    info.Add(ad);
                }
            }
            con.Close();
        }

        //public void insert_admin()

        public Admin_Info get_Info(string id)
        {
            foreach (Admin_Info need in info)
            {
                if (need.ID == id)
                {
                    return need;
                }
            }
            return null;
        }

        public bool login(string id,string password)
        {
            
            foreach (Admin_Info need in info)
            {
                
                if (need.ID == id && need.PASSWORD == password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
