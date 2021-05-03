using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Project
{
    class Developer_Info
    {
        int si;
        string id;
        string name;
        int age;
        Image picture;
        string password;
        string course;
        int quiz_added;
        int note_added;
        int problem_added;
        public int AGE
        {
            set
            {
                age = value;
            }
            get
            {
                return age;
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
        public Image PICTURE
        {
            set
            {
                picture = value;
            }
            get
            {
                return picture;
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
        public int QUIZ_ADD
        {
            set
            {
                quiz_added = value;
            }
            get
            {
                return quiz_added;
            }
        }
        public int NOTE_ADDED
        {
            set
            {
                note_added = value;
            }
            get
            {
                return note_added;
            }
        }
        public int  PROBLEM_ADDED
        {
            set
            {
                problem_added = value;
            }
            get
            {
                return problem_added;
            }
        }
    }
}
