using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EDepartmentController : Controller
    {
        private readonly MyAppDbContext context;

        public EDepartmentController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var department = from c in context.EDepartments
                             select new EDepartment
                             {
                                 Id = c.Id,
                                 Name = c.Name ?? "N/A",
                                 Value = c.Value ?? "N/A",
                                 Code = c.Code ?? "N/A"
                             };
            if (!string.IsNullOrEmpty(searchTerm))
            {
                department = department.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EDepartment/Index.cshtml", department.ToList());
        }

        [HttpPost]
        public IActionResult Create(EDepartment newDepartment)
        {
            if (context.EDepartments.Any(b => b.Name.ToLower() == newDepartment.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Department already exists." });
            }
            context.EDepartments.Add(newDepartment);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EDepartment updatedDepartment)
        {
            var existingDepartment = context.EDepartments.Find(updatedDepartment.Id);

            if (existingDepartment == null)
            {
                return NotFound();
            }
            bool nameExists = context.EDepartments
                .Any(b => b.Name.ToLower() == updatedDepartment.Name.ToLower() && b.Id != updatedDepartment.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Department already exists." });
            }

            existingDepartment.Name = updatedDepartment.Name ?? existingDepartment.Name;
            existingDepartment.Value = updatedDepartment.Value ?? existingDepartment.Value;
            existingDepartment.Code = updatedDepartment.Code ?? existingDepartment.Code;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
