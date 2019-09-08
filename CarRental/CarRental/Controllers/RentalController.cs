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

        // GET: Rental
        public ActionResult Index()
        {
            var cars = _context.Cars
                .Where(car => !car.IsRemoved)
                .OrderByDescending(car => car.Id)
                .ToList();

            var model = new CarViewModel { Cars = cars };

            return View(model);
        }
    }
}