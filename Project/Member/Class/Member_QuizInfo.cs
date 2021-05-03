using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Member_QuizInfo
    {
        int si;
        string quiz_name;
        string quiestion;
        string option1;
        string option2;
        string option3;
        string correct_ans;
        int mark;
        int quiz_no;
        string developer_id;

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

        public int SI
        {
            get
            {
                return si;
            }
            set
            {
                si = value;
            }

        }
        public string QUIZ_NAME
        {
            get
            {
                return quiz_name;
            }
            set
            {
                quiz_name = value;
            }
        }

        public string QUESTION
        {
            get
            {
                return quiestion;
            }
            set
            {
                quiestion = value;
            }
        }

        public string OPTION1
        {
            get
            {
                return option1;
            }
            set
            {
                option1 = value;
            }
        }

        public string OPTION2
        {
            get
            {
                return option2;
            }
            set
            {
                option2 = value;
            }
        }

        public string OPTION3
        {
            get
            {
                return option3;
            }
            set
            {
                option3 = value;
            }
        }

        public string CORRECT_ANS
        {
            get
            {
                return correct_ans;
            }
            set
            {
                correct_ans = value;
            }
        }

        public int MARK
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }

        public int QUIZ_NO
        {
            get
            {
                return quiz_no;
            }
            set
            {
                quiz_no = value;
            }
        }

    }
}
