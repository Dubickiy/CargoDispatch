using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CargoDispath.DAL.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public String UserId { get; set; }
       // public ApplicationUser User { get; set; }
        public String Name { get; set; }
        public String Number { get; set; }
        public String Type { get; set; }
        public String Label { get; set; }
        public String Body { get; set; }
        public bool hasTrailer { get; set; }
        public String TrailerNumber { get; set; }
        public String TrailerLabel { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public String LoadingType { get; set; }
        public String AddedInfo { get; set; }

        [JsonIgnore]
        public ICollection<Photo> Photos { get; set; }
        public Car()
        {
            Photos = new List<Photo>();
        }
    }
}
