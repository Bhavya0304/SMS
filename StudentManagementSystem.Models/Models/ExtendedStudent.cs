using StudentManagementSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Context
{
    [MetadataType(typeof(Metadata))]
    public partial class Student
    {
        internal class Metadata
        {
            [Required]
            public string FirstName { get; set; }
            [Required]

            public string LastName { get; set; }
            [Required]

            public string Address { get; set; }
            [Required]

            public string MobileNo { get; set; }
            [Required]

            public string Email { get; set; }
            [Required]

            public System.DateTime DOB { get; set; }

           
            [Required]
            public string Gender { get; set; }
            [CheckDropDowns]
            [Required]

            public Nullable<int> Country { get; set; }
            [CheckDropDowns]
            [Required]

            public Nullable<int> State { get; set; }
            [CheckDropDowns]
            [Required]

            public Nullable<int> City { get; set; }
            [Required]
            [MinLength(1,ErrorMessage = "Select Atleast One Teacher")]
            public string Teacher { get; set; }

        }

        public string DOB_str { get; set; }


    }

    public class CheckDropDowns : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return value == null || value.ToString() == "-1" ? new ValidationResult("Invalid Selection") : ValidationResult.Success;
        }
    }
}