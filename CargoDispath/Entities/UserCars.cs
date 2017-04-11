using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoDispath.Entities
{
    public class UserCars
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public String FromCountry { get; set; }
        public String FromRegion { get; set; }
        public String FromCity { get; set; }
        public String ToCountry { get; set; }
        public String ToRegion { get; set; }
        public String ToCity { get; set; }
        public String Car { get; set; }
        public String CarType { get; set; }
        public String LoadingType { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public String DateOfSending { get; set; }
        public bool IsElectronic { get; set; }
    }
}