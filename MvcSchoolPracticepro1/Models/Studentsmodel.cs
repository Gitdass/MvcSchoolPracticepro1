using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSchoolPracticepro1.Models
{
    public class Studentsmodel
    {
        public int studentid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string gender { get; set; }

        public string email { get; set; }
        public string phoneno { get; set; }
    }
}