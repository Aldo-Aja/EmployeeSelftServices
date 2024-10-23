using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EPositionController : Controller
    {
        private readonly MyAppDbContext context;

        public EPositionController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Position = from c in context.EPositions
                             select new EPosition
                             {
                                 Id = c.Id,
                                 Name = c.Name ?? "N/A",
                                 Value = c.Value ?? "N/A",
                                 Authorization = c.Authorization ?? "N/A"
                             };
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Position = Position.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EPosition/Index.cshtml", Position.ToList());
        }

        [HttpPost]
        public IActionResult Create(EPosition newPosition)
        {
            if (context.EPositions.Any(b => b.Name.ToLower() == newPosition.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Position already exists." });
            }
            context.EPositions.Add(newPosition);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EPosition updatedPosition)
        {
            var existingPosition = context.EPositions.Find(updatedPosition.Id);

            if (existingPosition == null)
            {
                return NotFound();
            }
            bool nameExists = context.EPositions
                .Any(b => b.Name.ToLower() == updatedPosition.Name.ToLower() && b.Id != updatedPosition.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Position already exists." });
            }

            existingPosition.Name = updatedPosition.Name ?? existingPosition.Name;
            existingPosition.Value = updatedPosition.Value ?? existingPosition.Value;
            existingPosition.Authorization = updatedPosition.Authorization ?? existingPosition.Authorization;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
