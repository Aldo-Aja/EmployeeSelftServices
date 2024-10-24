using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EUniversityController : Controller
    {
        private readonly MyAppDbContext context;

        public EUniversityController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var University = from b in context.EUniversities
                             select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                University = University.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EUniversity/Index.cshtml", University.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EUniversity newUniversity)
        {
            if (context.EUniversities.Any(b => b.Name.ToLower() == newUniversity.Name.ToLower()))
            {
                return Json(new { success = false, message = "This University already exists." });
            }
            context.EUniversities.Add(newUniversity);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EUniversity updatedUniversity)
        {
            var existingUniversity = context.EUniversities.Find(updatedUniversity.Id);

            if (existingUniversity == null)
            {
                return NotFound();
            }
            bool nameExists = context.EUniversities
                .Any(b => b.Name.ToLower() == updatedUniversity.Name.ToLower() && b.Id != updatedUniversity.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This University already exists." });
            }

            existingUniversity.Name = updatedUniversity.Name;
            existingUniversity.Value = updatedUniversity.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
