﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManage.Models.Tables
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
    }
}
