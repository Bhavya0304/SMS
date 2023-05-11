using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models.Context
{
    [MetadataType(typeof(Metadata))]
    public partial class Subject
    {
        internal class Metadata
        {
            [Required(ErrorMessage = "Subject Name is Required!")]
            public string SubjectName { get; set; }
        }
    }
}
