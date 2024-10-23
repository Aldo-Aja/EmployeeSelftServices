using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class ECountryController : Controller
    {
        private readonly MyAppDbContext context;

        public ECountryController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var country = from c in context.ECountries
                              select c;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                country = country.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/ECountry/Index.cshtml", country.ToList());
        }

        [HttpPost]
        public IActionResult Create(ECountry newCountry)
        {
            if (context.ECountries.Any(b => b.Name.ToLower() == newCountry.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Country already exists." });
            }
            context.ECountries.Add(newCountry);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(ECountry updatedCountry)
        {
            var existingCountry = context.ECountries.Find(updatedCountry.Id);

            if (existingCountry == null)
            {
                return NotFound();
            }
            bool nameExists = context.ECountries
                .Any(b => b.Name.ToLower() == updatedCountry.Name.ToLower() && b.Id != updatedCountry.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Country already exists." });
            }

            existingCountry.Name = updatedCountry.Name;
            existingCountry.Value = updatedCountry.Value;
            existingCountry.IsoCode = updatedCountry.IsoCode;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
