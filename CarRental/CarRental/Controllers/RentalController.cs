using CarRental.Models;
using CarRental.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RentalController()
        {
            _context = ApplicationDbContext.Create();
        }

        public ActionResult Index()
        {
            var cars = _context.Cars
                .Where(car => !car.IsRemoved)
                .OrderByDescending(car => car.Id)
                .ToList();

            var model = new CarViewModel { Cars = cars };

            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string searchValue)
        {
            var cars = _context.Cars
                .Where(car => !car.IsRemoved)
                .Where(car => car.Model.ToLower().Contains(searchValue.ToLower()) || car.Make.ToLower().Contains(searchValue.ToLower())
                || car.Year.ToString().Contains(searchValue))
                .OrderByDescending(car => car.Id)
                .ToList();

            var model = new CarViewModel { Cars = cars, SearchValue = searchValue };

            if (searchValue.Trim() == "")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Experiment()
        {
            return View(new FieldSetViewModel());
        }

        [HttpPost]
        public ActionResult Experiment(FieldSetViewModel model, string acceptConditions)
        { 
            if (acceptConditions == "yes")
            {
                model.IsChecked = true;
            }
            else if (acceptConditions == "no")
            {
                model.IsChecked = false;
            }

            return View(model);
        }
    }
}