using System.ComponentModel;
using System.Data;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Project
{
    class Member
    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        static int point;
        static ArrayList info;
        static ArrayList question_info;
        static ArrayList quiz_info;
        static ArrayList wrong_info=new ArrayList();
        static ArrayList problem_answer;


        public Member()
        {
            this.Edit_ArrayList();
            this.edit_quesArrayList();
            this.update_quizInfo();
            edit_problemAnswerArrayList();
        }

        public void update_quizInfo()
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
                    Member_QuizInfo mb = new Member_QuizInfo();
                    mb.SI = Convert.ToInt32(dr.GetValue(0));
                    mb.QUIZ_NAME= Convert.ToString(dr.GetValue(1));
                    mb.QUESTION = Convert.ToString(dr.GetValue(2));
                    mb.OPTION1 = Convert.ToString(dr.GetValue(3));
                    mb.OPTION2 = Convert.ToString(dr.GetValue(4));
                    mb.OPTION3 = Convert.ToString(dr.GetValue(5));
                    mb.MARK = Convert.ToInt32(dr.GetValue(6));
                    mb.CORRECT_ANS = Convert.ToString(dr.GetValue(7));
                    mb.QUIZ_NO = Convert.ToInt32(dr.GetValue(8));
                    mb.DEVELOPER_ID= Convert.ToString(dr.GetValue(9));
                    quiz_info.Add(mb);
                }
            }
            con.Close();
        }
        public void Edit_ArrayList()
        {
            info = new ArrayList();
            info.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From MEMBER";
            SqlCommand cmd = new SqlCommand(query, con);

            info = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Member_Info mb = new Member_Info();
                    mb.NAME = Convert.ToString(dr.GetValue(1));
                    mb.ID = Convert.ToString(dr.GetValue(2));
                    mb.STATUS = Convert.ToString(dr.GetValue(3));
                    mb.EMAIL = Convert.ToString(dr.GetValue(4));
                    mb.COURSE = Convert.ToString(dr.GetValue(5));
                    mb.PASSWORD = Convert.ToString(dr.GetValue(6));    
                    mb.MOBILE_NO = Convert.ToString(dr.GetValue(7));
                    mb.QUIZ_ATTEND = Convert.ToInt32(dr.GetValue(9));
                    mb.QUIZ_MARK= Convert.ToInt32(dr.GetValue(10));
                    mb.DEVELOPER_ID= Convert.ToString(dr.GetValue(11));
                    mb.HAS_DEVELOPER= Convert.ToInt32(dr.GetValue(12));
                    mb.PROBLEM_SOLVED = Convert.ToInt32(dr.GetValue(13));
                    mb.PROBLEM_POINT = Convert.ToInt32(dr.GetValue(14));
                    mb.LACTURE_NOTE_COMPLETED= Convert.ToInt32(dr.GetValue(15));
                   
                    Byte[] pic;
                    pic = (byte[])dr.GetValue(8);
                    MemoryStream ms = new MemoryStream(pic);
                    mb.PIC = Image.FromStream(ms);
                    info.Add(mb);
                }
            }
            con.Close();
        }

        public void edit_problemAnswerArrayList()
        {
            problem_answer = new ArrayList();
            problem_answer.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Problem_answer";
            SqlCommand cmd = new SqlCommand(query, con);

            problem_answer = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Problem_answerInfo ans = new Problem_answerInfo();
                    ans.SI = Convert.ToInt32(dr.GetValue(0));
                    ans.PROBLEM_NAME = Convert.ToString(dr.GetValue(1));
                    ans.COURSE = Convert.ToString(dr.GetValue(2));
                    ans.DATA =(byte[])(dr.GetValue(3));
                    ans.POINT = Convert.ToInt32(dr.GetValue(4));
                    ans.ANSWER = (byte[])(dr.GetValue(5));
                    ans.DEVELOPER_ID = Convert.ToString(dr.GetValue(6));
                    ans.MEMBER_ID = Convert.ToString(dr.GetValue(7));
                    ans.GET_POINT = Convert.ToInt32(dr.GetValue(8));
                    ans.FEEDBACK = Convert.ToString(dr.GetValue(9));
                    problem_answer.Add(ans);
                }
            }
            con.Close();
        }
        public string insert(string name,string email,string course,string password,string mobile_no,Image picture)
        { 
            //db = new ArrayList();

            SqlConnection connection = new SqlConnection(cs);
            string lest_id = "";
            string lest_si = "";
            string new_id = "";
            string new_si = "";
            string query = "SELECT ID, SI From MEMBER Where SI=(select max(SI) From MEMBER)";
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
                    new_id = "19-" + Convert.ToString(id_m) + "-3";
                    new_si = Convert.ToString(new_s);

                }
                dr.Close();
                string insert = "Insert into member (si,Name,ID,sta,Email,Course,Pass,mobile_no,picture,quiz_attend,quiz_mark,Has_developer,lacture_note_completed,problem_solved,problem_pont) values(@si,@name,@id,'Bronze',@email,@course,@password,@mobile,@picture,0,0,0,0,0,0)";
                //(@si, @name, @id, 'Bronze', @email, @course, @password, @mobile, @picture, 0)";
                SqlCommand ins = new SqlCommand(insert,connection);
                ins.Parameters.AddWithValue("@si", new_si);
                ins.Parameters.AddWithValue("@name", name);
                ins.Parameters.AddWithValue("@id", new_id);
                ins.Parameters.AddWithValue("@email", email);
                ins.Parameters.AddWithValue("@course", course);
                ins.Parameters.AddWithValue("@password", password);
                ins.Parameters.AddWithValue("@mobile", mobile_no);
                ins.Parameters.AddWithValue("@picture", SavedPhoto(picture));

                
                int a = ins.ExecuteNonQuery();

            }
            connection.Close();
            return "Account created! Your Id: " + new_id;
        }
        
        public void edit_quesArrayList()
        {
            question_info = new ArrayList();
            question_info.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Member_qustion";
            SqlCommand cmd = new SqlCommand(query, con);

            question_info = new ArrayList();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Member_QuestionInfo mb = new Member_QuestionInfo();
                    mb.DATE = Convert.ToDateTime(dr.GetValue(0));
                    mb.ID= Convert.ToString(dr.GetValue(1));
                    mb.COURSE = Convert.ToString(dr.GetValue(2));
                    mb.QUESTION_TITLE = Convert.ToString(dr.GetValue(3));
                    mb.QUESTION_DETAILS = Convert.ToString(dr.GetValue(4));
                    mb.QUESTION_REPLY = Convert.ToString(dr.GetValue(5));
                    mb.DEVELOPER_ID= Convert.ToString(dr.GetValue(6));
                    question_info.Add(mb);
                }
            }
            con.Close();
        }

        public void update_info(string id, string name, string email, string password, string mobile_no, Image picture)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Update member set Name=@name,Email=@email,Pass=@password,mobile_no=@mobile,picture=@picture where ID='" + id + "'";
            //(@si, @name, @id, 'Bronze', @email, @course, @password, @mobile, @picture, 0)";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@name", name);
            ins.Parameters.AddWithValue("@email", email);
            ins.Parameters.AddWithValue("@password", password);
            ins.Parameters.AddWithValue("@mobile", mobile_no);
            ins.Parameters.AddWithValue("@picture", SavedPhoto(picture));
            this.Edit_ArrayList();
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        private byte[] SavedPhoto(Image picture)
        {
            MemoryStream ms = new MemoryStream();
            picture.Save(ms, picture.RawFormat);
            return ms.GetBuffer();
        }

        public Member_Info get_info(string id)
        {
            foreach (Member_Info need in info)
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
            foreach(Member_Info need in info)
            {
                if(need.ID==id && need.PASSWORD == password)
                {
                    return true;
                }
            }

            return false;
          
        }

        public string get_Name(string ID)
        {
            foreach (Member_Info need in info)
            {
                if (need.ID == ID)
                {
                    return need.NAME;
                }
            }

            return null;
        }

        public Image get_PIC(string ID)
        {
            foreach (Member_Info need in info)
            {
                if (need.ID == ID)
                {
                    return need.PIC;
                }
            }

            return null;
        }

        public void insert_question(string ID,string title,string details,string developer_id)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Insert into Member_qustion (Date_add,ID,Course,Title,Details,Developer_ID) values(getdate(),@id,@course,@title,@details,@developer_id)";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@id", ID);
            foreach(Member_Info need in info)
            {
                if (need.ID == ID)
                {
                    ins.Parameters.AddWithValue("@course", need.COURSE);
                    break;
                }
            }
            ins.Parameters.AddWithValue("@title", title);
            ins.Parameters.AddWithValue("@details", details);
            ins.Parameters.AddWithValue("@developer_id", developer_id);
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public bool Is_titleUnique(string id,string title)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * From Member_qustion where title=@title and id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@title",title);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return false;
            }
            con.Close();

            return true;
        }

        public DataTable BindQustionDataGridView(string id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query= "Select date_add as 'Date & Time',title as 'Title' from Member_qustion where ID='"+id+ "'order by date_add asc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public Member_QuestionInfo get_QuestionInfo(string id,string title)
        {
            foreach(Member_QuestionInfo need in question_info)
            {
                if(need.ID==id && need.QUESTION_TITLE == title)
                {
                    return need;
                }
            }
            return null;
        }

        public void member_questionEdit(string id,string title,string details)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Update Member_qustion set Date_add=getdate(),title=@title,Details=@details  where ID=@id and title=@title";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@title", title);
            ins.Parameters.AddWithValue("@details", details);
            ins.Parameters.AddWithValue("@id", id);
            this.edit_quesArrayList();
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public void member_questionEdit_WithTitle(string id, string title, string details,string old_title)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open(); 
            string insert = "Update Member_qustion set Date_add=getdate(),title=@title,Details=@details  where ID=@id and title='"+old_title+"'";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@title", title);
            ins.Parameters.AddWithValue("@details", details);
            ins.Parameters.AddWithValue("@id", id);
            this.edit_quesArrayList();
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public void member_questionDelete(string id,string title)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "DELETE FROM Member_qustion WHERE id=@id and title=@title;";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@title", title);
            ins.Parameters.AddWithValue("@id", id);
            this.edit_quesArrayList();
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public Member_QuizInfo get_quizQuestion(string id,int si,int quiz_no,string developer_id)
        {
            Member_Info mb = new Member_Info();

            foreach(Member_Info need in info)
            {
                if (need.ID == id)
                {
                    mb = need;
                    break;
                }
            }
            
            foreach (Member_QuizInfo info in quiz_info)
            {
                if(info.SI == si && info.QUIZ_NO==quiz_no && info.QUIZ_NO==quiz_no && info.DEVELOPER_ID==developer_id)
                {
                    return info;
                }
            }
            return null;
        }


        public string get_QuizName(string id,int attend_quiz,string developer_id)
        {
            int quiz_no = attend_quiz + 1;
            foreach(Member_QuizInfo need in quiz_info)
            {
                if (need.QUIZ_NO == quiz_no && developer_id==need.DEVELOPER_ID)
                {
                    return need.QUIZ_NAME;
                }
            }
            return null;
        }

        public void update_quizInfo(string id,int point)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Update member set Quiz_mark=@pint,Quiz_attend=@quizAttent where ID='" + id + "'";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@pint", this.get_info(id).QUIZ_MARK + point);
            ins.Parameters.AddWithValue("@quizAttent", this.get_info(id).QUIZ_ATTEND+1);
            this.Edit_ArrayList();
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public int start_Quiz(string id,int si,string ans,int quiz_no,string developer_id)
        {
            bool wrong_ans = true;
            if (si == 1)
            {
                wrong_info.Clear();
                point = 0; 
            }

            Member_Info mb=this.get_info(id);
            
            Member_QuizInfo question = new Member_QuizInfo();
            foreach (Member_QuizInfo quiz in quiz_info)
            {
                if(quiz.QUIZ_NO==quiz_no && quiz.SI == si && quiz.DEVELOPER_ID==developer_id)
                {
                    if (ans == quiz.CORRECT_ANS)
                    {
                        wrong_ans = false;
                        point += quiz.MARK;
                        break;
                    }
                    question = quiz;
                }
            }

            if (wrong_ans)
            {
                Wrong_Ans wrong = new Wrong_Ans();
                wrong.QUIESTION = question.QUESTION;
                wrong.CORRECT_ANS = question.CORRECT_ANS;
                wrong.WRONG_ANS = ans;
                wrong.MARK = question.MARK;
                wrong.SI = si;
                wrong.QUIZ_NO = quiz_no;
                wrong.HAS_WRONG = true;
                wrong_info.Add(wrong);
            }

            
            return point;
        }

        public bool HasQuiz(int si,string developer_id)
        {
            foreach(Member_QuizInfo quiz in quiz_info)
            {
                if (quiz.SI == si && quiz.DEVELOPER_ID==developer_id)
                {
                    return true;
                }
            }

            return false;
        }

        public ArrayList get_wrong_QuizAns(string id,int quiz_no)
        {
            ArrayList need = new ArrayList();
            bool hasWrong = false;
            foreach(Wrong_Ans has in wrong_info)
            {
                if (has.HAS_WRONG && has.QUIZ_NO==quiz_no)
                {
                    hasWrong = true;
                    need.Add(has);
                }
            }
            if (hasWrong)
            {
                return need;
            }
            return null;
        }
        
        public DataTable InactiveDataTable()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select id as 'ID',name as 'Name' from Member where Has_developer=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public void updateInactiveMemberInfo(string id,string developer_id)
        {
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            string insert = "Update member set developer_id=@developer_id,Has_developer=1 where ID='" + id + "'";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@developer_id", developer_id);
            this.Edit_ArrayList();
            int a = ins.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable feedback_data(string id,string developer_id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select date_add as 'Date & Time',title as 'Title' from feedback where Developer_ID='"+developer_id+"' and Member_ID='"+id+"' order by date_add asc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;

        }

        public string Get_feedback(string id,string developer_id,string title)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT Feedback From Feedback where Member_ID=@Member_ID and Developer_ID=@Developer_ID and Title=@Title";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Member_ID", id);
            cmd.Parameters.AddWithValue("@Developer_ID", developer_id);
            cmd.Parameters.AddWithValue("@Title", title);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    return Convert.ToString(dr.GetValue(0));
                }
            }
            con.Close();

            return null;
        }
        public Problem_answerInfo get_problemAnsInfo(string member_id,string developer_id,int si)
        {
            foreach(Problem_answerInfo ans in problem_answer)
            {
                if(ans.MEMBER_ID==member_id && ans.DEVELOPER_ID==developer_id && ans.SI == si)
                {
                    return ans;
                }
            }
            return null;
        }

        public void update_problemAns(string member_id,string developer_id, int point, string feedbak, int si)
        {
            SqlConnection connection = new SqlConnection(cs);
            string insert = "update Problem_answer set get_point=@get_point ,feedbak=@feedbak where developer_id=@developer_id and si=@si and member_id=@member_id";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@si", si);
            ins.Parameters.AddWithValue("@get_point", point);
            ins.Parameters.AddWithValue("@member_id", member_id);
            ins.Parameters.AddWithValue("@developer_id", developer_id);
            ins.Parameters.AddWithValue("@feedbak", feedbak);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            edit_problemAnswerArrayList();

            connection = new SqlConnection(cs);
            string update = "Update member set problem_pont=problem_pont+@point where id=@id";
            ins = new SqlCommand(update, connection);
            ins.Parameters.AddWithValue("@id", member_id);
            ins.Parameters.AddWithValue("@point",  point);
            connection.Open();
            a = ins.ExecuteNonQuery();
            connection.Close();
            Edit_ArrayList();
        }

        public void update_problemAns_Edit(string member_id, string developer_id, int point, int old_point,string feedbak, int si)
        {
            SqlConnection connection = new SqlConnection(cs);
            string insert = "update Problem_answer set get_point=@get_point ,feedbak=@feedbak where developer_id=@developer_id and si=@si and member_id=@member_id";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@si", si);
            ins.Parameters.AddWithValue("@get_point", point);
            ins.Parameters.AddWithValue("@member_id", member_id);
            ins.Parameters.AddWithValue("@developer_id", developer_id);
            ins.Parameters.AddWithValue("@feedbak", feedbak);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            edit_problemAnswerArrayList();

            connection = new SqlConnection(cs);
            int new_point = get_info(member_id).PROBLEM_POINT - old_point;
            new_point = new_point + point;
            string update = "Update member set problem_pont=@point where id=@id";
            ins = new SqlCommand(update, connection);
            ins.Parameters.AddWithValue("@id", member_id);
            ins.Parameters.AddWithValue("@point", new_point);
            connection.Open();
            a = ins.ExecuteNonQuery();
            connection.Close();
            Edit_ArrayList();
        }

        public DataTable bind_ProblemDataGrid(string id, string developer_id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select si as 'SI',Problem_name as 'Problem' from Problem where developer_id='" + developer_id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }

        public void uplode_problemAns(string id,string developer_id,string course,int point, string problem_name, byte[] problem,byte[] answer , int si)
        {
            SqlConnection connection = new SqlConnection(cs);
            string insert = "Insert into Problem_answer(Si, Problem_name, Couse, Data, answer,developer_id, member_id,get_point,point) values(@Si,@Problem_name,@Course,@Data, @answer,@developer_id,@member_id,0,@point)"; 
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@si", si);
            ins.Parameters.AddWithValue("@Problem_name", problem_name);
            ins.Parameters.AddWithValue("@Course", course);
            ins.Parameters.AddWithValue("@Data", problem);
            ins.Parameters.AddWithValue("@answer", answer);
            ins.Parameters.AddWithValue("@developer_id", developer_id);
            ins.Parameters.AddWithValue("@member_id", id);
            ins.Parameters.AddWithValue("@point", point);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            edit_problemAnswerArrayList();

            connection = new SqlConnection(cs);
            string update = "Update member set problem_solved=problem_solved+1 where id=@id";
            ins = new SqlCommand(update, connection);
            ins.Parameters.AddWithValue("@id", id);
            connection.Open();
            a = ins.ExecuteNonQuery();
            connection.Close();
            Edit_ArrayList();
        }

        public void update_ans(string id,string developer_id,byte[] answer,int si)
        {
            SqlConnection connection = new SqlConnection(cs);
            string insert = "Update Problem_answer set answer=@answer where developer_id=@developer_id and member_id=@member_id and si=@si";
            SqlCommand ins = new SqlCommand(insert, connection);
            ins.Parameters.AddWithValue("@si", si);
            ins.Parameters.AddWithValue("@developer_id", developer_id);
            ins.Parameters.AddWithValue("@member_id", id);
            ins.Parameters.AddWithValue("@answer", answer);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            edit_problemAnswerArrayList();
        }

        public void update_doneLactureNoteNumber(string id)
        {
            SqlConnection connection = new SqlConnection(cs);
            string update = "Update member set lacture_note_completed=lacture_note_completed+1 where id=@id";
            SqlCommand ins = new SqlCommand(update, connection);
            ins.Parameters.AddWithValue("@id", id);
            connection.Open();
            int a = ins.ExecuteNonQuery();
            connection.Close();
            Edit_ArrayList();
        }

        public ArrayList member_list(string developer_id)
        {
            ArrayList list=new ArrayList();
            foreach(Member_Info need in info)
            {
                if (need.DEVELOPER_ID == developer_id)
                {
                    list.Add(need);
                }
            }
            return list;
        }

        public ArrayList member_list()
        {
            return info;
        }
    }
}
