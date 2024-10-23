using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EHardshipLocationController : Controller
    {
        private readonly MyAppDbContext context;

        public EHardshipLocationController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var HardshipLocation = from c in context.EHardshipLocations
                       select c;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                HardshipLocation = HardshipLocation.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EHardshipLocation/Index.cshtml", HardshipLocation.ToList());
        }

        [HttpPost]
        public IActionResult Create(EHardshipLocation newHardshipLocation)
        {
            if (context.EHardshipLocations.Any(b => b.Name.ToLower() == newHardshipLocation.Name.ToLower()))
            {
                return Json(new { success = false, message = "This HardshipLocation already exists." });
            }
            context.EHardshipLocations.Add(newHardshipLocation);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EHardshipLocation updatedHardshipLocation)
        {
            var existingHardshipLocation = context.EHardshipLocations.Find(updatedHardshipLocation.Id);

            if (existingHardshipLocation == null)
            {
                return NotFound();
            }
            bool nameExists = context.EHardshipLocations
                .Any(b => b.Name.ToLower() == updatedHardshipLocation.Name.ToLower() && b.Id != updatedHardshipLocation.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This HardshipLocation already exists." });
            }

            existingHardshipLocation.Name = updatedHardshipLocation.Name;
            existingHardshipLocation.Province = updatedHardshipLocation.Province;
            existingHardshipLocation.ProvinceId = updatedHardshipLocation.ProvinceId;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
