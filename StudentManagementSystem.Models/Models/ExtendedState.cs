using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Context
{
    [MetadataType(typeof(Metadata))]
    public partial class State
    {
        internal class Metadata
        {
            [Required]
            public string StateName { get; set; }

        }

        public string CountryName { get; set; }

    }
}