using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Project
{

    class Member_Info
    {
        string id;
        string password;
        string name;
        string email;
        string status;
        string course;
        string mobile_no;
        int quiz_attend;  
        Image pic;
        int quiz_mark;
        string developer_id;
        int has_developer;
        int problem_solved;
        int lacture_note_completed;
        int problem_point;

        public int PROBLEM_POINT
        {
            set
            {
                problem_point = value;
            }
            get
            {
                return problem_point;
            }
        }
        public int LACTURE_NOTE_COMPLETED
        {
            set
            {
                lacture_note_completed = value;
            }
            get
            {
                return lacture_note_completed;
            }
        }
        public int PROBLEM_SOLVED
        {
            set
            {
                problem_solved = value;
            }
            get
            {
                return problem_solved;
            }
        }
        public int HAS_DEVELOPER
        {
            set
            {
                has_developer = value;
            }
            get
            {
                return has_developer;
            }
        }
        public string DEVELOPER_ID
        {
            set
            {
                developer_id = value;
            }
            get
            {
                return developer_id;
            }
        }

        public int QUIZ_MARK
        {
            set
            {
                quiz_mark = value;
            }
            get
            {
                return quiz_mark;
            }
        }

        public string ID
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }

        public string PASSWORD
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }

        public string NAME
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        public string EMAIL
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }

        public string STATUS
        {
            set
            {
                status = value;
            }
            get
            {
                return status;
            }
        }

        public string COURSE
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
            }
        }

        public string MOBILE_NO
        {
            get
            {
                return mobile_no;
            }
            set
            {
                mobile_no = value;
            }
        }

        public int QUIZ_ATTEND
        {
            get
            {
                return quiz_attend;
            }
            set
            {
                quiz_attend = value;
            }
        }

        public Image PIC
        {
            set
            {
                pic = value;
            }
            get
            {
                return pic;
            }
        }
    }
}
