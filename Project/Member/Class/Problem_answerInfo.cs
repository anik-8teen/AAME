using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Problem_answerInfo
    {
        int si;
        string problem_name;
        string course;
        byte[] data;
        int point;
        byte[] answer;
        string developer_id;
        string member_id;
        int get_point;
        string feedback;

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
        public string PROBLEM_NAME
        {
            get
            {
                return problem_name;
            }
            set
            {
                problem_name = value;
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
        public byte[] DATA
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        public int POINT
        {
            get
            {
                return point;
            }
            set
            {
                point = value;
            }
        }
        public byte[] ANSWER
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
            }
        }
        public string DEVELOPER_ID
        {
            get
            {
                return developer_id;
            }
            set
            {
                developer_id = value;
            }
        }
        public string MEMBER_ID
        {
            get
            {
                return member_id;
            }
            set
            {
                member_id = value;
            }
        }
        public int GET_POINT
        {
            get
            {
                return get_point;
            }
            set
            {
                get_point = value;
            }
        }
        public string FEEDBACK
        {
            get
            {
                return feedback;
            }
            set
            {
                feedback = value;
            }
        }
    }
}
