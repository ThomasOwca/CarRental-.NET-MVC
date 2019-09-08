using CarRental.Models;
using CarRental.Models.Entities;
using CarRental.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = ApplicationDbContext.Create();
        }

        [HttpGet]
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
        public ActionResult Index(string carMake, string carModel, int? carYear)
        {
            if (carMake != null && carModel != null && carYear != null)
            {
                if (carMake != "" && carModel != "" && (carYear >= 1940 && carYear <= 2021))
                {
                    _context.Cars.Add(new Car { Make = carMake, Model = carModel, Year = (int)carYear, Added = DateTime.Now });
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCar(int id)
        {
            try
            {
                var carToDelete = _context.Cars.FirstOrDefault(car => car.Id == id);
                _context.Cars.Remove(carToDelete);
                _context.SaveChanges();
            }
            catch (Exception) {}

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BulkUpdate(CarViewModel model)
        {
            try
            {
                var cars = _context.Cars
                    .Where(car => !car.IsRemoved)
                    .OrderByDescending(car => car.Id)
                    .ToList();

                for (int i = 0; i < cars.Count; i++)
                {
                    if (model.CheckedBoxes[i])
                    {
                        _context.Cars.Remove(cars[i]);
                    }
                }

                _context.SaveChanges();

            }
            catch (Exception) {}

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}