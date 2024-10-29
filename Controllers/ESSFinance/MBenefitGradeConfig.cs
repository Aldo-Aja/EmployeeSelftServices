using CrudIntern.Models.ESSFinance;
using CrudIntern.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntern.Controllers.ESSFinance
{
    public class MBenefitGradeConfigController : Controller
    {
        private readonly FinanceDbContext context;

        public MBenefitGradeConfigController(FinanceDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var benefitConfigs = from c in context.MBenefitGradeConfigs
                                 select new MBenefitGradeConfig
                                 {
                                     Id = c.Id,
                                     Grade = c.Grade ?? "N/A",
                                     OpticalFrame = c.OpticalFrame ?? 0,
                                     OpticalLense = c.OpticalLense ?? 0,
                                     Medical = c.Medical ?? 0,
                                     Pointing = c.Pointing ?? 0,
                                     Loan = c.Loan ?? 0,
                                     Ra = c.Ra ?? 0,
                                     IsOvertime = c.IsOvertime ?? false,
                                     ConfigType = c.ConfigType ?? "N/A",
                                     Cop = c.Cop ?? 0,
                                     CarLoan = c.CarLoan ?? 0,
                                     HomeRenov = c.HomeRenov ?? 0,
                                     EmergencyLoan = c.EmergencyLoan ?? 0
                                 };

            if (!string.IsNullOrEmpty(searchTerm))
            {
                benefitConfigs = benefitConfigs.Where(b => b.Grade.Contains(searchTerm) || b.ConfigType.Contains(searchTerm));
            }

            return View("~/Views/ESSFinance/MBenefitGradeConfig/Index.cshtml", benefitConfigs.ToList());
        }

        [HttpPost]
        public IActionResult Create(MBenefitGradeConfig newBenefitConfig)
        {
            if (context.MBenefitGradeConfigs.Any(b => b.Grade.ToLower() == newBenefitConfig.Grade.ToLower()))
            {
                return Json(new { success = false, message = "This grade configuration already exists." });
            }

            newBenefitConfig.Grade ??= "N/A";
            newBenefitConfig.OpticalFrame ??= 0;
            newBenefitConfig.OpticalLense ??= 0;
            newBenefitConfig.Medical ??= 0;
            newBenefitConfig.Pointing ??= 0;
            newBenefitConfig.Loan ??= 0;
            newBenefitConfig.Ra ??= 0;
            newBenefitConfig.IsOvertime ??= null;
            newBenefitConfig.ConfigType ??= "N/A";
            newBenefitConfig.Cop ??= 0;
            newBenefitConfig.CarLoan ??= 0;
            newBenefitConfig.HomeRenov ??= 0;
            newBenefitConfig.EmergencyLoan ??= 0;

            context.MBenefitGradeConfigs.Add(newBenefitConfig);
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Edit(MBenefitGradeConfig updatedBenefitConfig)
        {
            var existingConfig = context.MBenefitGradeConfigs.Find(updatedBenefitConfig.Id);

            if (existingConfig == null)
            {
                return NotFound();
            }

            bool gradeExists = context.MBenefitGradeConfigs
                .Any(b => b.Grade.ToLower() == updatedBenefitConfig.Grade.ToLower() && b.Id != updatedBenefitConfig.Id);

            if (gradeExists)
            {
                return Json(new { success = false, message = "This grade configuration already exists." });
            }

            existingConfig.Grade = updatedBenefitConfig.Grade ?? "N/A";
            existingConfig.OpticalFrame = updatedBenefitConfig.OpticalFrame ?? 0;
            existingConfig.OpticalLense = updatedBenefitConfig.OpticalLense ?? 0;
            existingConfig.Medical = updatedBenefitConfig.Medical ?? 0;
            existingConfig.Pointing = updatedBenefitConfig.Pointing ?? 0;
            existingConfig.Loan = updatedBenefitConfig.Loan ?? 0;
            existingConfig.Ra = updatedBenefitConfig.Ra ?? 0;
            existingConfig.IsOvertime = updatedBenefitConfig.IsOvertime ?? null;
            existingConfig.ConfigType = updatedBenefitConfig.ConfigType ?? "N/A";
            existingConfig.Cop = updatedBenefitConfig.Cop ?? 0;
            existingConfig.CarLoan = updatedBenefitConfig.CarLoan ?? 0;
            existingConfig.HomeRenov = updatedBenefitConfig.HomeRenov ?? 0;
            existingConfig.EmergencyLoan = updatedBenefitConfig.EmergencyLoan ?? 0;

            context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
