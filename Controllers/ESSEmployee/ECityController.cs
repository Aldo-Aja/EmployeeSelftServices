using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class ECityController : Controller
    {
        private readonly MyAppDbContext context;

        public ECityController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var city = from c in context.ECities
                       select c;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                city = city.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/ECity/Index.cshtml", city.ToList());
        }
        
        [HttpPost]
        public IActionResult Create(ECity newCity)
        {
            if (context.ECities.Any(b => b.Name.ToLower() == newCity.Name.ToLower()))
            {
                return Json(new { success = false, message = "This City already exists." });
            }
            context.ECities.Add(newCity);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(ECity updatedCity)
        {
            var existingCity = context.ECities.Find(updatedCity.Id);
    
            if (existingCity == null)
            {
                return NotFound();
            }
            bool nameExists = context.ECities
                .Any(b => b.Name.ToLower() == updatedCity.Name.ToLower() && b.Id != updatedCity.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This City already exists." });
            }

            existingCity.Name = updatedCity.Name;
            existingCity.Value = updatedCity.Value;
            existingCity.ProvinceId = updatedCity.ProvinceId;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
