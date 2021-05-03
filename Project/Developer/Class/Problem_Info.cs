using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Problem_Info
    {
        int si;
        string problem_name;
        string course;
        byte[] data;
        string developer_id;
        int point;

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
        public string PROBLEM_NAME
        {
            set
            {
                problem_name = value;
            }
            get
            {
                return problem_name;
            }
        }
        public string COURSE
        {
            set
            {
                course = value;
            }
            get
            {
                return course;
            }
        }
        public byte[] DATA
        {
            set
            {
                data = value;
            }
            get
            {
                return data;
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
    }
}
