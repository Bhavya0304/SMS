using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Context
{
    [MetadataType(typeof(Metadata))]
    public partial class SMS_User
    {
       internal class Metadata
        {
            [Required(ErrorMessage = "Email is Required!")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Password is Required!")]
            public string Password { get; set; }


            public string Username { get; set; }
        }  
        [Required(ErrorMessage = "Confirm Password is Required!")]
        [Compare("Password",ErrorMessage ="Confirm Password should be same as password!")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}