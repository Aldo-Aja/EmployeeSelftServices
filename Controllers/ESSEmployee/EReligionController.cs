using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EReligionController : Controller
    {
        private readonly MyAppDbContext context;

        public EReligionController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Religion = from b in context.EReligions
                           select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Religion = Religion.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EReligion/Index.cshtml", Religion.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EReligion newReligion)
        {
            if (context.EReligions.Any(b => b.Name.ToLower() == newReligion.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Religion already exists." });
            }
            context.EReligions.Add(newReligion);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EReligion updatedReligion)
        {
            var existingReligion = context.EReligions.Find(updatedReligion.Id);

            if (existingReligion == null)
            {
                return NotFound();
            }
            bool nameExists = context.EReligions
                .Any(b => b.Name.ToLower() == updatedReligion.Name.ToLower() && b.Id != updatedReligion.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Religion already exists." });
            }

            existingReligion.Name = updatedReligion.Name;
            existingReligion.Value = updatedReligion.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
