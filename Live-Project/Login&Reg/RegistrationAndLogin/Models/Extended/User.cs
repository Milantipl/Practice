using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class UserM
    {
        //additional field most be added here which is not initially i.e. not save in db
        public string ConfirmPassword { get; set; }

    }
    public class UserMetadata
    {

        [DisplayName("Gender")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select the Gender")]
        public string Gender { get; set; }


        [DisplayName("First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }

        [DisplayName("Mobile")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your Mobile Number")]
        public string Mobile { get; set; }

        [DisplayName("Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter The Mail-Id")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter The Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Minimum 6 Characters Required")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Re-enter The Password")]
        [DisplayName("Conform Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 Characters Required")]
        [Compare("Password", ErrorMessage ="Conform Password and Password doesn't Match")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Profile")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "What is Your Profile")]
        public string Profile { get; set; }
    }
}