using System;
using System.ComponentModel.DataAnnotations;

namespace CargoDispath.DAL.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Value { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
    }
}
