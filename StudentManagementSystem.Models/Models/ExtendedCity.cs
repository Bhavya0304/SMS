using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Context
{
    [MetadataType(typeof(Metadata))]
    public partial class City
    {
        internal class Metadata
        {
            [Required]
            public string CityName { get; set; }

        }

    }
}