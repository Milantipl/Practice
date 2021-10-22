using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Mywef.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }

    }
}