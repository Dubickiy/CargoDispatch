using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoDispath.Entities
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}