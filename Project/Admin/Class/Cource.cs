using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Project
{
    class Cource
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        static ArrayList course;
        public Cource()
        {
            see_cource();
        }


        public ArrayList see_cource()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Course_Table";
            SqlCommand cmd = new SqlCommand(query, con);
            course = new ArrayList();
            course.Clear();

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    course.Add(Convert.ToString(dr.GetValue(0)));      
                }
                return course;
            }
            con.Close();
            return null;
        }

        public void insert_course(string course_name)
        {
            int si=0;
            bool has_Course = false;
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Course_Table";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dar = cmd.ExecuteReader();
            if (dar.HasRows == true)
            {
                has_Course = true;
            }
            con.Close();


            con = new SqlConnection(cs);
            query = "SELECT MAx(SI) From Course_Table";
            cmd = new SqlCommand(query, con);
            course = new ArrayList();
            course.Clear();

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read() && has_Course)
                {
                    si=Convert.ToInt32(dr.GetValue(0));
                }
            }
            else
            {
                si = 0;
            }
            con.Close();

            con = new SqlConnection(cs);
            query = "insert into Course_Table values (@Course_Name,@si)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Course_Name", course_name);
            cmd.Parameters.AddWithValue("@si", si+1);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
        }

        public ArrayList course_List()
        {
            see_cource();
            return course;
        }

       

        public DataTable bind_courseDataGrid()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select Si as 'SI' ,Course_Name as 'Course Name' from Course_Table order by si asc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }
    }
}
