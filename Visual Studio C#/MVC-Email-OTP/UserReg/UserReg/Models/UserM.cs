//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserReg.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserM
    {
        public int UserId { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }
        public Nullable<bool> EmailVerification { get; set; }
        public Nullable<System.Guid> ActivetionCode { get; set; }
        public string OTP { get; set; }
    }
}
