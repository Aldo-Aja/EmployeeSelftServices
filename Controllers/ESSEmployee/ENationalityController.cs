using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class ENationalityController : Controller
    {
        private readonly MyAppDbContext context;

        public ENationalityController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Nationality = from b in context.ENationalities
                                select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Nationality = Nationality.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/ENationality/Index.cshtml", Nationality.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(ENationality newNationality)
        {
            if (context.ENationalities.Any(b => b.Name.ToLower() == newNationality.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Nationality already exists." });
            }
            context.ENationalities.Add(newNationality);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(ENationality updatedNationality)
        {
            var existingNationality = context.ENationalities.Find(updatedNationality.Id);

            if (existingNationality == null)
            {
                return NotFound();
            }
            bool nameExists = context.ENationalities
                .Any(b => b.Name.ToLower() == updatedNationality.Name.ToLower() && b.Id != updatedNationality.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Nationality already exists." });
            }

            existingNationality.Name = updatedNationality.Name;
            existingNationality.Value = updatedNationality.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
