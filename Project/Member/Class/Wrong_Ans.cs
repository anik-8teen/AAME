using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Wrong_Ans
    {
        int si;
        string quiestion;
        string correct_ans;
        string wrong_ans;
        int mark;
        bool has_wrong = false;
        int quiz_no;


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
        public bool HAS_WRONG
        {
            set
            {
                has_wrong = value;
            }
            get
            {
                return has_wrong;
            }
        }

        public string QUIESTION
        {
            set
            {
                quiestion = value;
            }
            get
            {
                return quiestion;
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

        public string WRONG_ANS
        {
            set
            {
                wrong_ans = value;
            }
            get
            {
                return wrong_ans;
            }
        }

        public int MARK
        {
            set
            {
                mark = value;
            }
            get
            {
                return mark;
            }
        }

    }
}
