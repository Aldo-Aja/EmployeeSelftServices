using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EEducationController : Controller
    {
        private readonly MyAppDbContext context;

        public EEducationController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Education = from b in context.EEducations
                        select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Education = Education.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EEducation/Index.cshtml", Education.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EEducation newEducation)
        {
            if (context.EEducations.Any(b => b.Name.ToLower() == newEducation.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Education already exists." });
            }
            context.EEducations.Add(newEducation);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EEducation updatedEducation)
        {
            var existingEducation = context.EEducations.Find(updatedEducation.Id);

            if (existingEducation == null)
            {
                return NotFound();
            }
            bool nameExists = context.EEducations
                .Any(b => b.Name.ToLower() == updatedEducation.Name.ToLower() && b.Id != updatedEducation.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Education already exists." });
            }

            existingEducation.Name = updatedEducation.Name;
            existingEducation.Value = updatedEducation.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
