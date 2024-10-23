using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class ECostCenterController : Controller
    {
        private readonly MyAppDbContext context;

        public ECostCenterController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var costCenters = from c in context.ECostCenters
                       select c;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                costCenters = costCenters.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/ECostCenter/Index.cshtml", costCenters.ToList());
        }

        [HttpPost]
        public IActionResult Create(ECostCenter newCostCenter)
        {
            if (context.ECities.Any(b => b.Name.ToLower() == newCostCenter.Name.ToLower()))
            {
                return Json(new { success = false, message = "This CostCenter already exists." });
            }
            context.ECostCenters.Add(newCostCenter);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(ECostCenter updatedCostCenter)
        {
            var existingCostCenter = context.ECostCenters.Find(updatedCostCenter.Id);

            if (existingCostCenter == null)
            {
                return NotFound();
            }
            bool nameExists = context.ECostCenters
                .Any(b => b.Name.ToLower() == updatedCostCenter.Name.ToLower() && b.Id != updatedCostCenter.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This CostCenter already exists." });
            }

            existingCostCenter.Name = updatedCostCenter.Name;
            existingCostCenter.Code = updatedCostCenter.Code;
            existingCostCenter.CostCenter = updatedCostCenter.CostCenter;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
