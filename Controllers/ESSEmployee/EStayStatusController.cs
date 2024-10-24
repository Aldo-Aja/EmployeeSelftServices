using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EStayStatusController : Controller
    {
        private readonly MyAppDbContext context;

        public EStayStatusController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var StayStatus = from b in context.EStayStatuses
                              select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                StayStatus = StayStatus.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EStayStatus/Index.cshtml", StayStatus.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EStayStatus newStayStatus)
        {
            if (context.EStayStatuses.Any(b => b.Name.ToLower() == newStayStatus.Name.ToLower()))
            {
                return Json(new { success = false, message = "This StayStatus already exists." });
            }
            context.EStayStatuses.Add(newStayStatus);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EStayStatus updatedStayStatus)
        {
            var existingStayStatus = context.EStayStatuses.Find(updatedStayStatus.Id);

            if (existingStayStatus == null)
            {
                return NotFound();
            }
            bool nameExists = context.EStayStatuses
                .Any(b => b.Name.ToLower() == updatedStayStatus.Name.ToLower() && b.Id != updatedStayStatus.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This StayStatus already exists." });
            }

            existingStayStatus.Name = updatedStayStatus.Name;
            existingStayStatus.Value = updatedStayStatus.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
