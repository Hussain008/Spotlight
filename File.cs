﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotlight
{
    public class FileObj
    {
        public String name
        {
            get;
            set;
        }
        public String location
        {
            get;
            set;
        }

        public int rank
        {
            get;
            set;
        }

        public FileObj()
        {

        }
        public FileObj(String name, String location, int rank)
        {
            this.name = name;
            this.location = location;
            this.rank = rank;
        }
    }
}
