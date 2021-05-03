using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    class Developer
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        static ArrayList info;
        static ArrayList question_info;
        static ArrayList quiz_info;
        public static ArrayList feedback;
        static ArrayList lacture_note;
        static ArrayList problem;
        public Developer()
        {
            edit_info();
            edit_quesArrayList();
            edit_feedbackArrayList();
            edit_lactureNoteArrayList();
            edit_problemArrayList();
        }

        public void edit_info()
        {
            info = new ArrayList();
            info.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Developer_details";
            SqlCommand cmd = new SqlCommand(query, con);

            info = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Developer_Info dv = new Developer_Info();
                    dv.SI = Convert.ToInt32(dr.GetValue(0));
                    dv.ID = Convert.ToString(dr.GetValue(1));
                    dv.NAME = Convert.ToString(dr.GetValue(3));
                    dv.AGE = Convert.ToInt32(dr.GetValue(5));
                    dv.PASSWORD = Convert.ToString(dr.GetValue(2));
                    dv.COURSE = Convert.ToString(dr.GetValue(4));
                    //dv.EMAIL = Convert.ToString(dr.GetValue(3));
                    Byte[] pic;
                    pic = (byte[])dr.GetValue(6);
                    MemoryStream ms = new MemoryStream(pic);
                    dv.PICTURE = Image.FromStream(ms);
                    dv.QUIZ_ADD = Convert.ToInt32(dr.GetValue(7));
                    dv.NOTE_ADDED = Convert.ToInt32(dr.GetValue(8));
                    dv.PROBLEM_ADDED = Convert.ToInt32(dr.GetValue(9));
                    info.Add(dv);
                }
            }
            con.Close();
        }

        public void edit_quesArrayList()
        {
            question_info = new ArrayList();
            question_info.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Member_qustion where Reply is null";
            SqlCommand cmd = new SqlCommand(query, con);

            question_info = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Developer_Question mb = new Developer_Question();
                    mb.DATE = Convert.ToDateTime(dr.GetValue(0));
                    mb.MEMBER_ID = Convert.ToString(dr.GetValue(1));
                    mb.COURSE = Convert.ToString(dr.GetValue(2));
                    mb.QUESTION_TITLE = Convert.ToString(dr.GetValue(3));
                    mb.QUESTION_DETAILS = Convert.ToString(dr.GetValue(4));
                    mb.QUESTION_REPLY = Convert.ToString(dr.GetValue(5));
                    mb.DEVELOPER_ID = Convert.ToString(dr.GetValue(6));
                    question_info.Add(mb);
                }
            }
            con.Close();
        }

        public void edit_feedbackArrayList()
        {
            feedback = new ArrayList();
            feedback.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Feedback";
            SqlCommand cmd = new SqlCommand(query, con);

            feedback = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Feedback_Info fd = new Feedback_Info();
                    fd.DATE = Convert.ToDateTime(dr.GetValue(0));
                    fd.MEMBER_ID = Convert.ToString(dr.GetValue(1));
                    fd.COURSE = Convert.ToString(dr.GetValue(2));
                    fd.TITLE = Convert.ToString(dr.GetValue(3));
                    fd.FEEDBACK = Convert.ToString(dr.GetValue(4));
                    fd.DEVELOPER_ID = Convert.ToString(dr.GetValue(5));
                    feedback.Add(fd);
                }
            }
            con.Close();

        }
        public void edit_lactureNoteArrayList()
        {
            lacture_note = new ArrayList();
            lacture_note.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Lacture_Note";
            SqlCommand cmd = new SqlCommand(query, con);

            lacture_note = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Lacture_noteInfo note = new Lacture_noteInfo();
                    note.SI = Convert.ToInt32(dr.GetValue(0));
                    note.NOTE_NAME = Convert.ToString(dr.GetValue(1));
                    note.COURSE = Convert.ToString(dr.GetValue(2));
                    note.DATA = (byte[])(dr.GetValue(3));
                    note.DEVELOPER_ID = Convert.ToString(dr.GetValue(4));
                    lacture_note.Add(note);
                }
            }
            con.Close();

        }

        public void edit_problemArrayList()
        {
            problem = new ArrayList();
            problem.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Problem";
            SqlCommand cmd = new SqlCommand(query, con);

            problem = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Problem_Info pro = new Problem_Info();
                    pro.SI = Convert.ToInt32(dr.GetValue(0));
                    pro.PROBLEM_NAME = Convert.ToString(dr.GetValue(1));
                    pro.COURSE = Convert.ToString(dr.GetValue(2));
                    pro.DATA = (byte[])(dr.GetValue(3));
                    pro.DEVELOPER_ID = Convert.ToString(dr.GetValue(4));
                    pro.POINT = Convert.ToInt32(dr.GetValue(5));
                    problem.Add(pro);
                }
            }
            con.Close();

        }

        public void edit_quizInfo()
        {
            quiz_info = new ArrayList();
            quiz_info.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Quiz";
            SqlCommand cmd = new SqlCommand(query, con);

            quiz_info = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Quiz_info q = new Quiz_info();
                    q.SI = Convert.ToInt32(dr.GetValue(0));
                    q.QUIZ_NAME = Convert.ToString(dr.GetValue(1));
                    q.QUESTION = Convert.ToString(dr.GetValue(2));
                    q.OPTION1 = Convert.ToString(dr.GetValue(3));
                    q.OPTION2 = Convert.ToString(dr.GetValue(4));
                    q.OPTION3 = Convert.ToString(dr.GetValue(5));
                    q.POINT= Convert.ToInt32(dr.GetValue(6));
                    q.CORRECT_ANS = Convert.ToString(dr.GetValue(7));
                    q.QUIZ_NO = Convert.ToInt32(dr.GetValue(8));
                    q.DEVELOPER_ID = Convert.ToString(dr.GetValue(9));
                    quiz_info.Add(q);
                }
            }
            con.Close();
        }

        public string insert_developer(string password,string name,string course,int age,Image picture)
        {
            SqlConnection connection = new SqlConnection(cs);
            string lest_id = "";
            string lest_si = "";
            string new_id = "";
            string new_si = "";
            string query = "SELECT ID, SI From DEVELOPER_DETAILS Where SI=(select max(SI) From DEVELOPER_DETAILS)";
            SqlCommand cmd = new SqlCommand(query, connection);
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
                    new_id = "12-" + Convert.ToString(id_m) + "-3";
                    new_si = Convert.ToString(new_s);

                }
                dr.Close();
                string insert = "Insert into DEVELOPER_DETAILS (si,id,password,name,course,age,picture,quiz_add,add_note,add_problem) values(@si,@id,@password,@name,@course,@age,@picture,0,0,0)";
                //@si,@id,@password,@name,@course,@age,@picture
                SqlCommand ins = new SqlCommand(insert, connection);
                ins.Parameters.AddWithValue("@si", new_si);  
                ins.Parameters.AddWithValue("@id", new_id);
                ins.Parameters.AddWithValue("@password", password);
                ins.Parameters.AddWithValue("@name", name);
                ins.Parameters.AddWithValue("@course", course);
                ins.Parameters.AddWithValue("@age", age);
                ins.Parameters.AddWithValue("@picture", SavedPhoto(picture));


                int a = ins.ExecuteNonQuery();

            }
            connection.Close();
            edit_info();
            return "Account created! Developer Id: " + new_id;
        }

        public void insert_question(ArrayList info_q,string developer_id)
        {
            //Quiz_info need;
            //db = new ArrayList();
            int old_quiz_no = 0;

            if (this.get_info(developer_id).QUIZ_ADD > 0)
            {
                SqlConnection connection = new SqlConnection(cs);
                string query = "SELECT quiz_no From quiz Where quiz_no=(select max(quiz_no) From quiz) and developer_id='"+developer_id+"'";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        old_quiz_no = Convert.ToInt32(dr.GetValue(0));
                    }
                    dr.Close();
                    foreach(Quiz_info qu in info_q)
                    {

                        string insert = "Insert into quiz (si,Quiz_name,Question,Option_1,Option_2,Option_3,Point,correct_answer,developer_id,quiz_no) values(@si,@Quiz_name,@Question,@Option_1,@Option_2,@Option_3,@Point,@correct_answer,@developer_id,@quiz_no)";
                        //@si,@Quiz_name,@Question,@Option_1,@Option_2,@Option_3,@Point,@correct_answer,@quiz_no,@developer_id
                        SqlCommand ins = new SqlCommand(insert, connection);
                        ins.Parameters.AddWithValue("@si", qu.SI);
                        ins.Parameters.AddWithValue("@Quiz_name", qu.QUIZ_NAME);
                        ins.Parameters.AddWithValue("@Question", qu.QUESTION);
                        ins.Parameters.AddWithValue("@Option_1", qu.OPTION1);
                        ins.Parameters.AddWithValue("@Option_2", qu.OPTION2);
                        ins.Parameters.AddWithValue("@Option_3", qu.OPTION3);
                        ins.Parameters.AddWithValue("@Point", qu.POINT);
                        ins.Parameters.AddWithValue("@correct_answer", qu.CORRECT_ANS);
                        ins.Parameters.AddWithValue("@quiz_no", old_quiz_no+1);
                        ins.Parameters.AddWithValue("@developer_id", developer_id);

                        int a = ins.ExecuteNonQuery();
                        
                        this.edit_quizInfo();
                    }
                    connection.Close();
                }
                
            }
            else
            {
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                foreach (Quiz_info qu in info_q)
                {

                    string insert = "Insert into quiz (si,Quiz_name,Question,Option_1,Option_2,Option_3,Point,correct_answer,developer_id,quiz_no) values(@si,@Quiz_name,@Question,@Option_1,@Option_2,@Option_3,@Point,@correct_answer,@developer_id,@quiz_no)";
                    //@si,@Quiz_name,@Question,@Option_1,@Option_2,@Option_3,@Point,@correct_answer,@quiz_no,@developer_id
                    SqlCommand ins = new SqlCommand(insert, connection);
                    ins.Parameters.AddWithValue("@si", qu.SI);
                    ins.Parameters.AddWithValue("@Quiz_name", qu.QUIZ_NAME);
                    ins.Parameters.AddWithValue("@Question", qu.QUESTION);
                    ins.Parameters.AddWithValue("@Option_1", qu.OPTION1);
                    ins.Parameters.AddWithValue("@Option_2", qu.OPTION2);
                    ins.Parameters.AddWithValue("@Option_3", qu.OPTION3);
                    ins.Parameters.AddWithValue("@Point", qu.POINT);
                    ins.Parameters.AddWithValue("@correct_answer", qu.CORRECT_ANS);
                    ins.Parameters.AddWithValue("@quiz_no", old_quiz_no + 1);
                    ins.Parameters.AddWithValue("@developer_id", developer_id);

                    int a = ins.ExecuteNonQuery();
                    
                    this.edit_quizInfo();
                }
                connection.Close();
            }

        }

        public void update_AddQuizInfo(string id)
        {
            int has_quiz = 0;
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "select quiz_add from DEveloper_details  where ID='"+id+"'";
            SqlCommand cmd = new SqlCommand(insert, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    has_quiz= Convert.ToInt32(dr.GetValue(0));
                    break;
                }
            }
            dr.Close();
            int a = cmd.ExecuteNonQuery();
            connection.Close();


            connection = new SqlConnection(cs);
            connection.Open();
            insert = "Update DEVELOPER_DETAILS set quiz_add=@quiz_add where ID='" + id + "'";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@quiz_add", has_quiz+1);
            
            this.edit_info();
           a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public ArrayList get_quizInfo(string id,int quiz_no)
        {
            ArrayList list = new ArrayList();
            foreach(Quiz_info quiz in quiz_info)
            {
                if(quiz.DEVELOPER_ID==id && quiz.QUIZ_NO == quiz_no)
                {
                    list.Add(quiz);
                }
            }
            return list;
        }

        public DataTable BindQustionDataGridView(string id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select date_add as 'Date & Time' ,id as 'Member Id',title as 'Title' from Member_qustion where Developer_ID='" + id + "' and Reply is null order by date_add asc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public Developer_Info get_info(string id)
        {
            foreach(Developer_Info need in info)
            {
                if (need.ID == id)
                {
                    return need;
                }
            }
            return null;
        }

        public Developer_Question get_Question_info(string member_id,string title)
        {
            foreach(Developer_Question need in question_info)
            {
                if(need.MEMBER_ID==member_id && need.QUESTION_TITLE == title)
                {
                    return need;
                }
            }
            return null;
        }

        public void insert_question_Reply(string member_ID, string title, string reply, string developer_id)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Update MEMBER_QUSTION set reply=@reply where ID=@member_id and Title=@title and Developer_ID=@Developer_ID";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@member_id", member_ID);
            ins.Parameters.AddWithValue("@title", title);
            ins.Parameters.AddWithValue("@reply", reply);
            ins.Parameters.AddWithValue("@developer_id", developer_id);
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public bool login(string id,string password)
        {
            foreach(Developer_Info need in info)
            {
                if(need.ID==id && need.PASSWORD == password)
                {
                    return true;
                }
            }
            return false;
        }

        public ArrayList get_info_For_ADD_Member()
        {
            return info;
        }

        public ArrayList get_Member_id(string id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select ID from Member where developer_id=@developer_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@developer_id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ArrayList member_id = new ArrayList();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    member_id.Add(Convert.ToString(dr.GetValue(0)));
                }
            }
            con.Close();
            return member_id;
        }

        public bool has_title(string id, string title,string member_id)
        {
            foreach (Feedback_Info has_title in feedback)
            {
                if (has_title.TITLE == title && has_title.DEVELOPER_ID == id && has_title.MEMBER_ID==member_id)
                {
                    return true;
                }
            }
            return false;
        }

        public void insert_feedback(string member_id, string course, string title, string feedback, string developer_id)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Insert into Feedback (Date_add,Member_id,Course,Title,Feedback,Developer_ID) values(getdate(),@Member_id,@Course,@Title,@Feedback,@Developer_ID)";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@Member_id", member_id);
            ins.Parameters.AddWithValue("@Course", course);
            ins.Parameters.AddWithValue("@Title", title);
            ins.Parameters.AddWithValue("@Feedback", feedback);
            ins.Parameters.AddWithValue("@Developer_ID", developer_id);
            int a = ins.ExecuteNonQuery();
            connection.Close();
            this.edit_feedbackArrayList();
        }

        public DataTable buid_feedback_dataGridview(string id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select date_add as 'Date & Time',title as 'Title',member_id as 'Member ID' from feedback where Developer_ID='" + id + "'order by date_add asc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public Feedback_Info GetFeedback_Info(string id,string title,string member_id)
        {
            foreach(Feedback_Info need in feedback)
            {
                if (need.DEVELOPER_ID==id && need.TITLE==title && need.MEMBER_ID == member_id)
                {
                    return need;
                    
                }
            }
            return null;
        }

        public void update_feedback(string member_id, string title, string feedback, string developer_id,string old_title)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Update Feedback set Date_add=getdate(),title=@title,feedback=@feedback  where Member_ID=@member_id and title='"+old_title+"' and Developer_ID=@developer_id";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@title", title);
            ins.Parameters.AddWithValue("@feedback", feedback);
            ins.Parameters.AddWithValue("@member_id", member_id);
            ins.Parameters.AddWithValue("@developer_id", developer_id);
            this.edit_feedbackArrayList();
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public void insert_Lacture(string id,string note_name,byte[] data)
        {
            SqlConnection connection = new SqlConnection(cs);
            string insert = "Insert into Lacture_Note (si,note_name,couse,data,developer_id) values(@si,@note_name,@couse,@data,@developer_id)";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@si", this.get_info(id).NOTE_ADDED+1);
            ins.Parameters.AddWithValue("@note_name", note_name);
            ins.Parameters.AddWithValue("@couse", this.get_info(id).COURSE);
            ins.Parameters.AddWithValue("@data", data);
            ins.Parameters.AddWithValue("@developer_id", id);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            edit_lactureNoteArrayList();

            connection = new SqlConnection(cs);
            string update = "Update DEVELOPER_DETAILS set add_note=@add_note where id=@id";
            int has_note = this.get_info(id).NOTE_ADDED;
            ins = new SqlCommand(update, connection);
            ins.Parameters.AddWithValue("@add_note", has_note+1);
            ins.Parameters.AddWithValue("@id", id);
            connection.Open();
            a = ins.ExecuteNonQuery();
            connection.Close();
            edit_info();
        }

        public DataTable bind_lactureDataGrid(string id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select Si as 'SI' ,Note_name as 'Note name' from Lacture_Note where Developer_ID='" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public void update_lacture(string id, string note_name,byte[] data,int si)
        {
            SqlConnection connection = new SqlConnection(cs);
            string insert = "update Lacture_Note set note_name=@note_name ,data=@data where developer_id=@developer_id and si=@si";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@si", si);
            ins.Parameters.AddWithValue("@note_name", note_name);
            ins.Parameters.AddWithValue("@data", data);
            ins.Parameters.AddWithValue("@developer_id", id);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            edit_lactureNoteArrayList();
        }

        public void download_lactureNote(int si,string id)
        {
            Lacture_noteInfo need = new Lacture_noteInfo();
            foreach (Lacture_noteInfo n in lacture_note)
            {
                if(n.DEVELOPER_ID==id &&  n.SI==si)
                {
                    need = n;
                    break;
                }
            }

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            string path;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = dialog.FileName + "/"+need.NOTE_NAME+".pdf";
                File.WriteAllBytes(path, need.DATA);
            }

        }

        public void insert_Problem(string id, string problem_name, byte[] data,int point)
        {
            SqlConnection connection = new SqlConnection(cs);
            string insert = "Insert into Problem (si,Problem_name,couse,data,developer_id,point) values(@si,@Problem_name,@couse,@data,@developer_id,@point)";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@si", this.get_info(id).PROBLEM_ADDED + 1);
            ins.Parameters.AddWithValue("@Problem_name", problem_name);
            ins.Parameters.AddWithValue("@couse", this.get_info(id).COURSE);
            ins.Parameters.AddWithValue("@data", data);
            ins.Parameters.AddWithValue("@developer_id", id);
            ins.Parameters.AddWithValue("@point", point);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            edit_problemArrayList();

            connection = new SqlConnection(cs);
            string update = "Update DEVELOPER_DETAILS set add_problem=@add_problem where id=@id";
            int has_problem = this.get_info(id).PROBLEM_ADDED;
            ins = new SqlCommand(update, connection);
            ins.Parameters.AddWithValue("@add_problem", has_problem + 1);
            ins.Parameters.AddWithValue("@id", id);
            connection.Open();
            a = ins.ExecuteNonQuery();
            connection.Close();
            edit_info();
        }

        public DataTable bind_problemDataGrid(string id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select Si as 'SI' ,Problem_name as 'Problem name',point as 'Point' from problem where Developer_ID='" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public void update_problem(string id, string problem_name, byte[] data, int si)
        {
            SqlConnection connection = new SqlConnection(cs);
            string insert = "update problem set Problem_name=@Problem_name ,data=@data where developer_id=@developer_id and si=@si";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@si", si);
            ins.Parameters.AddWithValue("@Problem_name", problem_name);
            ins.Parameters.AddWithValue("@data", data);
            ins.Parameters.AddWithValue("@developer_id", id);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            edit_problemArrayList();
        }

        public void download_problem(int si, string id)
        {
            Problem_Info need = new Problem_Info();
            foreach (Problem_Info n in problem)
            {
                if (n.DEVELOPER_ID == id && n.SI == si)
                {
                    need = n;
                    break;
                }
            }

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            string path;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = dialog.FileName + "/" + need.PROBLEM_NAME + ".pdf";
                File.WriteAllBytes(path, need.DATA);
            }

        }

        public DataTable bind_problemAnsDataGrid(string developer_id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select member_id as 'ID',Problem_name as 'Problem name',Si as 'SI' from Problem_answer where developer_id='" + developer_id+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public Problem_Info get_problem(string developer_id,int si)
        {
            foreach(Problem_Info need in problem)
            {
                if(need.DEVELOPER_ID==developer_id && need.SI == si)
                {
                    return need;
                }
            }
            return null;
        }

        public void update_info(string id, string name, string password, int age, Image picture)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Update DEVELOPER_DETAILS set Name=@name,age=@age,password=@password,picture=@picture where ID='" + id + "'";
            //(@si, @name, @id, 'Bronze', @email, @course, @password, @mobile, @picture, 0)";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@name", name);
            ins.Parameters.AddWithValue("@age", age);
            ins.Parameters.AddWithValue("@password", password);
            ins.Parameters.AddWithValue("@picture", SavedPhoto(picture));
            this.edit_info();
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        private byte[] SavedPhoto(Image picture)
        {
            MemoryStream ms = new MemoryStream();
            picture.Save(ms, picture.RawFormat);
            return ms.GetBuffer();
        }

        public ArrayList developer_list()
        {
            return info;
        }
    }
}
