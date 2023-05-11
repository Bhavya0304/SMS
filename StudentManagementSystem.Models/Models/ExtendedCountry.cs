using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Context
{
    [MetadataType(typeof(Metadata))]
    public partial class Country
    {
        internal class Metadata
        {
            [Required]
            public string CountryName { get; set; }

        }

    }
}