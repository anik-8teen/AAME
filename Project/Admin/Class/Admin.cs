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

        private byte[] SavedPhoto(Image picture)
        {
            MemoryStream ms = new MemoryStream();
            picture.Save(ms, picture.RawFormat);
            return ms.GetBuffer();
        }

        public string Insert_Admin(string name,string email,string password,Image picture)
        {
            bool has_value = false;
            SqlConnection connection = new SqlConnection(cs);
            string query = "SELECT * From Admin_Table";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dar = cmd.ExecuteReader();
            if (dar.HasRows == true)
            {
                has_value = true;

            }
            connection.Close();
            //db = new ArrayList();


            if (has_value)
            {
                connection = new SqlConnection(cs);
                string lest_id = "";
                string lest_si = "";
                string new_id = "";
                string new_si = "";
                query = "SELECT ID, SI From Admin_Table Where SI=(select max(SI) From Admin_Table)";
                cmd = new SqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@id", textBox2.Text);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        lest_id = Convert.ToString(dr.GetValue(0));
                        lest_si = Convert.ToString(dr.GetValue(1));
                        int new_s = Convert.ToInt32(lest_si) + 1;
                        string id_mid = lest_id.Substring(3, 5);
                        long id_m = Convert.ToInt64(id_mid) + 1;
                        new_id = "19-" + Convert.ToString(id_m) + "-3";
                        new_si = Convert.ToString(new_s);

                    }
                    dr.Close();
                    string insert = "Insert into Admin_Table (si,Name,username,Email,password,picture) values(@si,@Name,@username,@Email,@password,@picture)";
                    //si,Name,username,Email,password,picture) values(@si,@Name,@username,@Email,@password,@picture
                    SqlCommand ins = new SqlCommand(insert, connection);
                    ins.Parameters.AddWithValue("@si", new_si);
                    ins.Parameters.AddWithValue("@name", name);
                    ins.Parameters.AddWithValue("@username", new_id);
                    ins.Parameters.AddWithValue("@email", email);
                    ins.Parameters.AddWithValue("@password", password);
                    ins.Parameters.AddWithValue("@picture", SavedPhoto(picture));


                    int a = ins.ExecuteNonQuery();

                }
                connection.Close();
                return "Account created! Your Id: " + new_id;
            }
            else
            {

                connection = new SqlConnection(cs);
                string insert = "Insert into Admin_Table (si,Name,username,Email,password,picture) values(@si,@Name,@username,@Email,@password,@picture)";
                //si,Name,username,Email,password,picture) values(@si,@Name,@username,@Email,@password,@picture
                SqlCommand ins = new SqlCommand(insert, connection);
                ins.Parameters.AddWithValue("@si", 1);
                ins.Parameters.AddWithValue("@name", name);
                ins.Parameters.AddWithValue("@username", "11-41620-3");
                ins.Parameters.AddWithValue("@email", email);
                ins.Parameters.AddWithValue("@password", password);
                ins.Parameters.AddWithValue("@picture", SavedPhoto(picture));

                connection.Open();
                int a = ins.ExecuteNonQuery();
                connection.Close();
                return "Account created! Your Id: 11-41620-3";
            }
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

        public bool Has_Admin()
        {
            SqlConnection connection = new SqlConnection(cs);
            string query = "SELECT * From Admin_Table";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dar = cmd.ExecuteReader();
            if (dar.HasRows == true)
            {
  
                connection.Close();
                return  true;

            }

            connection.Close();
            return false;
        }
    }
}
