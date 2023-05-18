using Newtonsoft.Json;
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
            [JsonIgnore]
            public virtual ICollection<City> Cities { get; set; }
            [JsonIgnore]

            public virtual ICollection<State> States { get; set; }
            [JsonIgnore]

            public virtual ICollection<Student> Students { get; set; }
            [JsonIgnore]

            public virtual ICollection<Teacher> Teachers { get; set; }

        }

    }
}