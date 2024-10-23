using CrudIntern.Models.ESSEmployee;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSEmployee
{
    public class EBankController : Controller
    {
        private readonly MyAppDbContext context;

        public EBankController(MyAppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var banks = from b in context.EBanks
                        select b;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                banks = banks.Where(b => b.Name.Contains(searchTerm));
            }
            return View("~/Views/ESSEmployee/Ebank/Index.cshtml", banks.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EBank newBank)
        {
            if (context.EBanks.Any(b => b.Name.ToLower() == newBank.Name.ToLower()))
            {
                return Json(new { success = false, message = "This bank already exists." });
            }
            context.EBanks.Add(newBank);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(EBank updatedBank)
        {
            var existingBank = context.EBanks.Find(updatedBank.Id);
    
            if (existingBank == null)
            {
                return NotFound();
            }
            bool nameExists = context.EBanks
                .Any(b => b.Name.ToLower() == updatedBank.Name.ToLower() && b.Id != updatedBank.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This bank already exists." });
            }

            existingBank.Name = updatedBank.Name;
            existingBank.Value = updatedBank.Value;

            context.SaveChanges();

            return Json(new { success = true });
        }

    }
}
