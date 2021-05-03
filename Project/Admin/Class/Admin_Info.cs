using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Project
{
    class Admin_Info
    {
        string id;
        string password;
        string name;
        string email;
        Image pic;

        public Image PIC
        {
            get
            {
                return pic;
            }
            set
            {
                pic = value;
            }
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string PASSWORD
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string NAME
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string EMAIL
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
    }
}
