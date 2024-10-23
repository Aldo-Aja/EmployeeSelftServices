using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EgradeController : Controller
    {
        private readonly MyAppDbContext context;

        public EgradeController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Grade = from b in context.EGrades
                                 select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Grade = Grade.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EGrade/Index.cshtml", Grade.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EGrade newGrade)
        {
            if (context.EGrades.Any(b => b.Name.ToLower() == newGrade.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Grade already exists." });
            }
            context.EGrades.Add(newGrade);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EGrade updatedGrade)
        {
            var existingGrade = context.EGrades.Find(updatedGrade.Id);

            if (existingGrade == null)
            {
                return NotFound();
            }
            bool nameExists = context.EGrades
                .Any(b => b.Name.ToLower() == updatedGrade.Name.ToLower() && b.Id != updatedGrade.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Grade already exists." });
            }

            existingGrade.Name = updatedGrade.Name;
            existingGrade.Value = updatedGrade.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
