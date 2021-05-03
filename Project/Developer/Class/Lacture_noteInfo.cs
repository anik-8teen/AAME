using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Lacture_noteInfo
    {
        int si;
        string note_name;
        string course;
        byte[] data;
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
        public string NOTE_NAME
        {
            set
            {
                note_name = value;
            }
            get
            {
                return note_name;
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
    }
}
