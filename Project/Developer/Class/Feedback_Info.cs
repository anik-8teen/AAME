using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Feedback_Info
    {
        DateTime date;
        string member_id;
        string couse;
        string title;
        string feedback;
        string developer_id;

        public DateTime DATE
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
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
        public string COURSE
        {
            get
            {
                return couse;
            }
            set
            {
                couse = value;
            }
        }
        public string TITLE
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
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
    }
}
