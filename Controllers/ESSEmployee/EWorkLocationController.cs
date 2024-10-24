using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EWorkLocationController : Controller
    {
        private readonly MyAppDbContext context;

        public EWorkLocationController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var WorkLocation = from b in context.EWorkLocations
                             select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                WorkLocation = WorkLocation.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EWorkLocation/Index.cshtml", WorkLocation.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EWorkLocation newWorkLocation)
        {
            if (context.EWorkLocations.Any(b => b.Name.ToLower() == newWorkLocation.Name.ToLower()))
            {
                return Json(new { success = false, message = "This WorkLocation already exists." });
            }
            context.EWorkLocations.Add(newWorkLocation);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EWorkLocation updatedWorkLocation)
        {
            var existingWorkLocation = context.EWorkLocations.Find(updatedWorkLocation.Id);

            if (existingWorkLocation == null)
            {
                return NotFound();
            }
            bool nameExists = context.EWorkLocations
                .Any(b => b.Name.ToLower() == updatedWorkLocation.Name.ToLower() && b.Id != updatedWorkLocation.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This WorkLocation already exists." });
            }

            existingWorkLocation.Name = updatedWorkLocation.Name;
            existingWorkLocation.Value = updatedWorkLocation.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
