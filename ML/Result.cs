﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Correct{ get; set; }
        public string ErrorMessage { get; set; }
        public Exception Ex { get; set; }
        public object Object{ get; set; }//GetById para un registro
        public List<Object>  Objects{ get; set; }//GetAll
    }
}
