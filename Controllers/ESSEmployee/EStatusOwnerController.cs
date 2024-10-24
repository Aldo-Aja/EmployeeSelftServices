using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EStatusOwnerController : Controller
    {
        private readonly MyAppDbContext context;

        public EStatusOwnerController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var StatusOwner = from b in context.EStatusOwners
                        select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                StatusOwner = StatusOwner.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EStatusOwner/Index.cshtml", StatusOwner.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EStatusOwner newStatusOwner)
        {
            if (context.EStatusOwners.Any(b => b.Name.ToLower() == newStatusOwner.Name.ToLower()))
            {
                return Json(new { success = false, message = "This StatusOwner already exists." });
            }
            context.EStatusOwners.Add(newStatusOwner);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EStatusOwner updatedStatusOwner)
        {
            var existingStatusOwner = context.EStatusOwners.Find(updatedStatusOwner.Id);

            if (existingStatusOwner == null)
            {
                return NotFound();
            }
            bool nameExists = context.EStatusOwners
                .Any(b => b.Name.ToLower() == updatedStatusOwner.Name.ToLower() && b.Id != updatedStatusOwner.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This StatusOwner already exists." });
            }

            existingStatusOwner.Name = updatedStatusOwner.Name;
            existingStatusOwner.Value = updatedStatusOwner.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
