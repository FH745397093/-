using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSTool
{
    class Kctdestdb
    {
        private int oid;
        private string oip;
        private string oport;
        private string osid;
        private string oregion;
        private string ouser;
        private string opass;

        public string Opass
        {
            get { return opass; }
            set { opass = value; }
        }

       
        public string Ouser
        {
            get { return ouser; }
            set { ouser = value; }
        }

        public string Oregion
        {
            get { return oregion; }
            set { oregion = value; }
        }

        public string Osid
        {
            get { return osid; }
            set { osid = value; }
        }

        public string Oport
        {
            get { return oport; }
            set { oport = value; }
        }

        public string Oip
        {
            get { return oip; }
            set { oip = value; }
        }

        public int Oid
        {
            get { return oid; }
            set { oid = value; }
        }
        
    }
}
