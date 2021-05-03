using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Quiz_info
    {
        int si;
        string quiz_name;
        string question;
        string option1;
        string option2;
        string option3;
        int point;
        string correct_ans;
        int quiz_no;
        string developer_id;

        public int SI
        {
            set
            {
                si = value;
            }
            get
            {
                return si;
            }
        }
        public string QUIZ_NAME
        {
            set
            {
                quiz_name = value;
            }
            get
            {
                return quiz_name;
            }
        }
        public string QUESTION
        {
            set
            {
                question = value;
            }
            get
            {
                return question;
            }
        }
        public string OPTION1
        {
            set
            {
                option1 = value;
            }
            get
            {
                return option1;
            }
        }
        public string OPTION2
        {
            set
            {
                option2 = value;
            }
            get
            {
                return option2;
            }
        }
        public string OPTION3
        {
            set
            {
                option3 = value;
            }
            get
            {
                return option3;
            }
        }
        public int POINT
        {
            set
            {
                point = value;
            }
            get
            {
                return point;
            }
        }
        public string CORRECT_ANS
        {
            set
            {
                correct_ans = value;
            }
            get
            {
                return correct_ans;
            }
        }
        public int QUIZ_NO
        {
            set
            {
                quiz_no = value;
            }
            get
            {
                return quiz_no;
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
    }
}
