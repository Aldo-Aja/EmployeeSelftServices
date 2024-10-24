using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class MAssigmentStatusController : Controller
    {
        private readonly MyAppDbContext context;

        public MAssigmentStatusController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var AssigmentStatus = from b in context.MAssigmentStatuses
                               select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                AssigmentStatus = AssigmentStatus.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/MAssigmentStatus/Index.cshtml", AssigmentStatus.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(MAssigmentStatus newAssigmentStatus)
        {
            if (context.MAssigmentStatuses.Any(b => b.Name.ToLower() == newAssigmentStatus.Name.ToLower()))
            {
                return Json(new { success = false, message = "This AssigmentStatus already exists." });
            }
            context.MAssigmentStatuses.Add(newAssigmentStatus);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(MAssigmentStatus updatedAssigmentStatus)
        {
            var existingAssigmentStatus = context.MAssigmentStatuses.Find(updatedAssigmentStatus.Id);

            if (existingAssigmentStatus == null)
            {
                return NotFound();
            }
            bool nameExists = context.MAssigmentStatuses
                .Any(b => b.Name.ToLower() == updatedAssigmentStatus.Name.ToLower() && b.Id != updatedAssigmentStatus.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This AssigmentStatus already exists." });
            }

            existingAssigmentStatus.Name = updatedAssigmentStatus.Name;
            existingAssigmentStatus.Value = updatedAssigmentStatus.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
