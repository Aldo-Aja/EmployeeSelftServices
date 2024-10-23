using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EOccupationController : Controller
    {
        private readonly MyAppDbContext context;

        public EOccupationController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Occupation = from b in context.EOccupations
                              select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Occupation = Occupation.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EOccupation/Index.cshtml", Occupation.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EOccupation newOccupation)
        {
            if (context.EOccupations.Any(b => b.Name.ToLower() == newOccupation.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Occupation already exists." });
            }
            context.EOccupations.Add(newOccupation);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EOccupation updatedOccupation)
        {
            var existingOccupation = context.EOccupations.Find(updatedOccupation.Id);

            if (existingOccupation == null)
            {
                return NotFound();
            }
            bool nameExists = context.EOccupations
                .Any(b => b.Name.ToLower() == updatedOccupation.Name.ToLower() && b.Id != updatedOccupation.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Occupation already exists." });
            }

            existingOccupation.Name = updatedOccupation.Name;
            existingOccupation.Value = updatedOccupation.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
