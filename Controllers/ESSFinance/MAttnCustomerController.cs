using CrudIntern.Models.ESSFinance;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSFinance
{
    public class MAttnCustomerController : Controller
    {
        private readonly FinanceDbContext context;

        public MAttnCustomerController(FinanceDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var AttnCustomer = from c in context.MAttnCustomers
                          select new MAttnCustomer
                          {
                              Id = c.Id,
                              BpCode = c.BpCode ?? "N/A",
                              AttnName = c.AttnName?? "N/A",
                              Email = c.Email ?? "N/A",
                              Description = c.Description ?? "N/A"
                          };
            if (!string.IsNullOrEmpty(searchTerm))
            {
                AttnCustomer = AttnCustomer.Where(b => b.AttnName.Contains(searchTerm));
            }
            return View("~/Views/ESSFinance/MAttnCustomer/Index.cshtml", AttnCustomer.ToList());
        }

        [HttpPost]
        public IActionResult Create(MAttnCustomer newAttnCustomer)
        {
            if (context.MAttnCustomers.Any(b => b.AttnName.ToLower() == newAttnCustomer.AttnName.ToLower()))
            {
                return Json(new { success = false, message = "This AttnCustomer already exists." });
            }
            context.MAttnCustomers.Add(newAttnCustomer);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(MAttnCustomer updatedAttnCustomer)
        {
            var existingAttnCustomer = context.MAttnCustomers.Find(updatedAttnCustomer.Id);

            if (existingAttnCustomer == null)
            {
                return NotFound();
            }
            bool nameExists = context.MAttnCustomers
                .Any(b => b.AttnName.ToLower() == updatedAttnCustomer.AttnName.ToLower() && b.Id != updatedAttnCustomer.Id);

            if (nameExists)
            {
                return Json(new { success = false, message = "This AttnCustomer already exists." });
            }

            existingAttnCustomer.BpCode = updatedAttnCustomer.BpCode ?? existingAttnCustomer.BpCode;
            existingAttnCustomer.AttnName = updatedAttnCustomer.AttnName?? existingAttnCustomer.AttnName;
            existingAttnCustomer.Email = updatedAttnCustomer.Email ?? existingAttnCustomer.Email;
            existingAttnCustomer.Description = updatedAttnCustomer.Description ?? existingAttnCustomer.Description;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
