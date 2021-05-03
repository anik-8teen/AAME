using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Project
{
    class Salary
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public void insert_salary(string name,int salary,string developer_id,string month,string year)
        {
            SqlConnection Con = new SqlConnection(cs);
            string query = "insert into Salary_Table values(@Name,@Salary,getdate(),@Developer_id,@month,@year)";
            SqlCommand cMd = new SqlCommand(query, Con);
            cMd.Parameters.AddWithValue("@Name", name);
            cMd.Parameters.AddWithValue("@Salary", salary);
            cMd.Parameters.AddWithValue("@Developer_id", developer_id);
            cMd.Parameters.AddWithValue("@month", month);
            cMd.Parameters.AddWithValue("@year", year);
            Con.Open();
            int a = cMd.ExecuteNonQuery();
            Con.Close();
        }

        public bool has_salary( string developer_id, string month, string year)
        {
            SqlConnection Con = new SqlConnection(cs);
            string query = "Select * from Salary_Table where Developer_id=@Developer_id and month=@month and year=@year";
            SqlCommand cMd = new SqlCommand(query, Con);
            cMd.Parameters.AddWithValue("@Developer_id", developer_id);
            cMd.Parameters.AddWithValue("@month", month);
            cMd.Parameters.AddWithValue("@year", year);

            Con.Open();
            SqlDataReader dr = cMd.ExecuteReader();
            if (dr.HasRows)
            {
                Con.Close();
                return true;
            }
            Con.Close();
            return false;

        }

        public DataTable bindSalaryDataGrid()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select Developer_id as 'Developer ID' ,Name as 'Developer Name',Salary as 'Amount',month as 'Month',year as 'Year' from  Salary_Table order by SDate DESC";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public DataTable bindSalaryDataGrid_forDeveloper(string id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select  month as 'Month',year as 'Year',Salary as 'Amount' from  Salary_Table where Developer_id='"+id+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }
    }
}
