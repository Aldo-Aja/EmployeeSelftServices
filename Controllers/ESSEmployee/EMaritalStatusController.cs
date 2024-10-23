using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EMaritalStatusController : Controller
    {
        private readonly MyAppDbContext context;

        public EMaritalStatusController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var MaritalStatus = from b in context.EMaritalStatuses
                            select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                MaritalStatus = MaritalStatus.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EMaritalStatus/Index.cshtml", MaritalStatus.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EMaritalStatus newMaritalStatus)
        {
            if (context.EMaritalStatuses.Any(b => b.Name.ToLower() == newMaritalStatus.Name.ToLower()))
            {
                return Json(new { success = false, message = "This MaritalStatus already exists." });
            }
            context.EMaritalStatuses.Add(newMaritalStatus);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EMaritalStatus updatedMaritalStatus)
        {
            var existingMaritalStatus = context.EMaritalStatuses.Find(updatedMaritalStatus.Id);

            if (existingMaritalStatus == null)
            {
                return NotFound();
            }
            bool nameExists = context.EMaritalStatuses
                .Any(b => b.Name.ToLower() == updatedMaritalStatus.Name.ToLower() && b.Id != updatedMaritalStatus.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This MaritalStatus already exists." });
            }

            existingMaritalStatus.Name = updatedMaritalStatus.Name;
            existingMaritalStatus.Value = updatedMaritalStatus.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
