using CrudIntern.Models.ESSEmployee;
using CrudIntern.Models.ESSFinance;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSFinance
{
    public class MBankingRoutingCodeController : Controller
    {
        private readonly FinanceDbContext context;

        public MBankingRoutingCodeController(FinanceDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var BankingRoutingCode = from c in context.MBankingRoutingCodes
                               select new MBankingRoutingCode
                               {
                                   Id = c.Id,
                                   BankName = c.BankName?? "N/A",
                                   RoutingCode = c.RoutingCode ?? "N/A",
                               };
            if (!string.IsNullOrEmpty(searchTerm))
            {
                BankingRoutingCode = BankingRoutingCode.Where(b => b.BankName.Contains(searchTerm));
            }
            return View("~/Views/ESSFinance/MBankingRoutingCode/Index.cshtml", BankingRoutingCode.ToList());
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(MBankingRoutingCode newBank)
        {
            if (context.MBankingRoutingCodes.Any(b => b.BankName.ToLower() == newBank.BankName.ToLower()))
            {
                return Json(new { success = false, message = "This bank already exists." });
            }
            context.MBankingRoutingCodes.Add(newBank);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(MBankingRoutingCode updatedBank)
        {
            var existingBank = context.MBankingRoutingCodes.Find(updatedBank.Id);

            if (existingBank == null)
            {
                return NotFound();
            }
            bool nameExists = context.MBankingRoutingCodes
                .Any(b => b.BankName.ToLower() == updatedBank.BankName.ToLower() && b.Id != updatedBank.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This bank already exists." });
            }

            existingBank.BankName = updatedBank.BankName ?? existingBank.BankName;
            existingBank.RoutingCode = updatedBank.RoutingCode ?? existingBank.RoutingCode;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
