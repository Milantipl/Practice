﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserReg.Models
{
    public class UserRegistration
    {
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is requierd")]
        public string Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is requierd")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile num is requierd")]
        public string Mobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID is requierd")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is requierd")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Need min 6 character")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is requierd")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password should match with Password")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Profile is requierd")]
        public string Profile { get; set; }
        
    }
}