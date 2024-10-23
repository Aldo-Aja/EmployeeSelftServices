using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EProvinceController : Controller
    {
        private readonly MyAppDbContext context;

        public EProvinceController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var Province = from c in context.EProvinces
                       select c;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Province = Province.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/EProvince/Index.cshtml", Province.ToList());
        }

        [HttpPost]
        public IActionResult Create(EProvince newProvince)
        {
            if (context.ECities.Any(b => b.Name.ToLower() == newProvince.Name.ToLower()))
            {
                return Json(new { success = false, message = "This Province already exists." });
            }
            context.EProvinces.Add(newProvince);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EProvince updatedProvince)
        {
            var existingProvince = context.EProvinces.Find(updatedProvince.Id);

            if (existingProvince == null)
            {
                return NotFound();
            }
            bool nameExists = context.EProvinces
                .Any(b => b.Name.ToLower() == updatedProvince.Name.ToLower() && b.Id != updatedProvince.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This Province already exists." });
            }

            existingProvince.Name = updatedProvince.Name;
            existingProvince.Value = updatedProvince.Value;
            existingProvince.CountryId = updatedProvince.CountryId;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
