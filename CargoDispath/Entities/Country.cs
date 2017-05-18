using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoDispath.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        [JsonIgnore]
        public ICollection<Region> _Regions { get; set; }
        public Country()
        {
            _Regions = new List<Region>();
        }
    }
}