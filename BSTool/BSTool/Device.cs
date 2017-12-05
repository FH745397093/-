using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSTool
{
    class Device
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string uuid;

        public string Uuid
        {
            get { return uuid; }
            set { uuid = value; }
        }
        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }
        private DateTime createtime;

        public DateTime Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        private string region;

        public string Region
        {
            get { return region; }
            set { region = value; }
        }
    }
}
