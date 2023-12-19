using DriverWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DriverWebApplication.Controllers
{
    [Controller]
    public class DriverController : Controller
    {
        private static IList<Driver> drivers = new List<Driver>();

        [HttpGet]
        [Route("/")]
        [Route("index")]
        public IActionResult Index()
        {
            return Content("<h1>Welcome to Driver Portal</h1>","text/html");
        }

        [HttpGet]
        [Route("all-drivers/{driverNationalId:regex(^[[2-3]][[0-9]]{{13}}$)?}")]
        public IActionResult GetAllDrivers(string? driverNationalId)
        {
            if (driverNationalId == null)
            {
                return drivers.Count == 0 ? Content("No drivers are added."):Json(drivers);
            }
            else
            {
                foreach (Driver driver in drivers)
                {
                    if (driver.NationalId == driverNationalId)
                    {
                        return Json(driver);
                    }
                }
            }

            return NotFound($"Driver with national Id {driverNationalId} is not found.");
        }

        [HttpPost]
        [Route("add-driver")]
        public IActionResult AddDriver([FromForm] Driver driver)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);

                string message = string.Join("\n", errors);

                return BadRequest(message);
            }

            drivers.Add(driver);

            return Ok($"Driver {driver.NationalId} is successfully added.");
        }

    }
}
