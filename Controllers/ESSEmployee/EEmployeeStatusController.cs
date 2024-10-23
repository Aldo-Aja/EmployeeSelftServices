using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EEmployeeStatusController : Controller
    {
        private readonly MyAppDbContext context;

        public EEmployeeStatusController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var EmployeeStatus = from b in context.EEmployeeStatuses
                            select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                EmployeeStatus = EmployeeStatus.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EEmployeeStatus/Index.cshtml", EmployeeStatus.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EEmployeeStatus newEmployeeStatus)
        {
            if (context.EEmployeeStatuses.Any(b => b.Name.ToLower() == newEmployeeStatus.Name.ToLower()))
            {
                return Json(new { success = false, message = "This EmployeeStatus already exists." });
            }
            context.EEmployeeStatuses.Add(newEmployeeStatus);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EEmployeeStatus updatedEmployeeStatus)
        {
            var existingEmployeeStatus = context.EEmployeeStatuses.Find(updatedEmployeeStatus.Id);

            if (existingEmployeeStatus == null)
            {
                return NotFound();
            }
            bool nameExists = context.EEmployeeStatuses
                .Any(b => b.Name.ToLower() == updatedEmployeeStatus.Name.ToLower() && b.Id != updatedEmployeeStatus.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This EmployeeStatus already exists." });
            }

            existingEmployeeStatus.Name = updatedEmployeeStatus.Name;
            existingEmployeeStatus.Value = updatedEmployeeStatus.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
