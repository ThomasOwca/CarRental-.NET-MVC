using CarRental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models.ViewModels
{
    public class CarViewModel
    {
        public List<Car> Cars { get; set; }
        public List<bool> CheckedBoxes { get; set; }
        public string SearchValue { get; set; }
    }
}