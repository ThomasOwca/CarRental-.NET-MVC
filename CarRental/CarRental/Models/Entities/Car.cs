using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public DateTime Added { get; set; }
        public bool IsRemoved { get; set; }
    }
}