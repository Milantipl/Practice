//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcnew.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class student_result
    {
        public int id { get; set; }
        public string grade { get; set; }
        public string subject { get; set; }
        public double marks { get; set; }
        public string @class { get; set; }
    
        public virtual Student_Trainee Student_Trainee { get; set; }
    }
}