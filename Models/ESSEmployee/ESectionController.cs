using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Models.ESSEmployee
{
    public class ESectionController : Controller
    {
        private readonly MyAppDbContext context;

        public ESectionController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Section = from c in context.ESections
                             select new ESection
                             {
                                 Id = c.Id,
                                 Name = c.Name ?? "N/A",
                                 Value = c.Value ?? "N/A",
                                 DepartmentId = c.DepartmentId ?? 0,
                                 Code = c.Code ?? "N/A"
                             };
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Section = Section.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/ESection/Index.cshtml", Section.ToList());
        }

        [HttpPost]
        public IActionResult Create(ESection newSection)
        {
            if (context.ESections.Any(b => b.Name.ToLower() == newSection.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Section already exists." });
            }
            context.ESections.Add(newSection);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(ESection updatedSection)
        {
            var existingSection = context.ESections.Find(updatedSection.Id);

            if (existingSection == null)
            {
                return NotFound();
            }
            bool nameExists = context.ESections
                .Any(b => b.Name.ToLower() == updatedSection.Name.ToLower() && b.Id != updatedSection.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Section already exists." });
            }

            existingSection.Name = updatedSection.Name ?? existingSection.Name;
            existingSection.Value = updatedSection.Value ?? existingSection.Value;
            existingSection.DepartmentId = updatedSection.DepartmentId ?? existingSection.DepartmentId;
            existingSection.Code = updatedSection.Code ?? existingSection.Code;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
