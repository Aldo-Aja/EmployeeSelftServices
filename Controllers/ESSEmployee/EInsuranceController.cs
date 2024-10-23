using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EInsuranceController : Controller
    {
        private readonly MyAppDbContext context;

        public EInsuranceController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Insurance = from b in context.EInsurances
                        select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Insurance = Insurance.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EInsurance/Index.cshtml", Insurance.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EInsurance newInsurance)
        {
            if (context.EInsurances.Any(b => b.Name.ToLower() == newInsurance.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Insurance already exists." });
            }
            context.EInsurances.Add(newInsurance);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EInsurance updatedInsurance)
        {
            var existingInsurance = context.EInsurances.Find(updatedInsurance.Id);

            if (existingInsurance == null)
            {
                return NotFound();
            }
            bool nameExists = context.EInsurances
                .Any(b => b.Name.ToLower() == updatedInsurance.Name.ToLower() && b.Id != updatedInsurance.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Insurance already exists." });
            }

            existingInsurance.Name = updatedInsurance.Name;
            existingInsurance.Value = updatedInsurance.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
