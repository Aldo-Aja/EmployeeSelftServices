using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EGradeCategoryController : Controller
    {
        private readonly MyAppDbContext context;

        public EGradeCategoryController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var GradeCategory = from b in context.EGradeCategories
                        select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                GradeCategory = GradeCategory.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EGradeCategory/Index.cshtml", GradeCategory.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EGradeCategory newGradeCategory)
        {
            if (context.EGradeCategories.Any(b => b.Name.ToLower() == newGradeCategory.Name.ToLower()))
            {
                return Json(new { success = false, message = "This GradeCategory already exists." });
            }
            context.EGradeCategories.Add(newGradeCategory);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EGradeCategory updatedGradeCategory)
        {
            var existingGradeCategory = context.EGradeCategories.Find(updatedGradeCategory.Id);

            if (existingGradeCategory == null)
            {
                return NotFound();
            }
            bool nameExists = context.EGradeCategories
                .Any(b => b.Name.ToLower() == updatedGradeCategory.Name.ToLower() && b.Id != updatedGradeCategory.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This GradeCategory already exists." });
            }

            existingGradeCategory.Name = updatedGradeCategory.Name;
            existingGradeCategory.Value = updatedGradeCategory.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
