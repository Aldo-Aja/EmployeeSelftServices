using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class ERelationshipController : Controller
    {
        private readonly MyAppDbContext context;

        public ERelationshipController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Relationship = from b in context.ERelationships
                        select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Relationship = Relationship.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/ERelationship/Index.cshtml", Relationship.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(ERelationship newRelationship)
        {
            if (context.ERelationships.Any(b => b.Name.ToLower() == newRelationship.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Relationship already exists." });
            }
            context.ERelationships.Add(newRelationship);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(ERelationship updatedRelationship)
        {
            var existingRelationship = context.ERelationships.Find(updatedRelationship.Id);

            if (existingRelationship == null)
            {
                return NotFound();
            }
            bool nameExists = context.ERelationships
                .Any(b => b.Name.ToLower() == updatedRelationship.Name.ToLower() && b.Id != updatedRelationship.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Relationship already exists." });
            }

            existingRelationship.Name = updatedRelationship.Name;
            existingRelationship.Value = updatedRelationship.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
