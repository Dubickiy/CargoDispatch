using System;
using System.ComponentModel.DataAnnotations;
namespace CargoDispath.DAL.Entities
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }
        public String UserId { get; set; }
        public String Name { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public String Payment { get; set; }
        public double Price { get; set; }
        public String TimeOfNeccessaryLoading { get; set; }
        public String FromCountry { get; set; }
        public String FromRegion { get; set; }
        public String FromCity { get; set; }
        public String ToCounry { get; set; }
        public String ToRegion { get; set; }
        public String ToCity { get; set; }
        public bool IsElectronic { get; set; }
        public String LoadingType { get; set; }
        public String CarType { get; set; }

    }
}
