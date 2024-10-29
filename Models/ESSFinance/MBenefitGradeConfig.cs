using System;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSFinance;

public partial class MBenefitGradeConfig
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Grade is required.")]
    public string? Grade { get; set; }

    [Required(ErrorMessage = "Optical Frame value is required.")]
    public int? OpticalFrame { get; set; }

    [Required(ErrorMessage = "Optical Lense value is required.")]
    public int? OpticalLense { get; set; }

    [Required(ErrorMessage = "Medical value is required.")]
    public int? Medical { get; set; }

    [Required(ErrorMessage = "Pointing value is required.")]
    public int? Pointing { get; set; }

    [Required(ErrorMessage = "Loan value is required.")]
    public int? Loan { get; set; }

    [Required(ErrorMessage = "RA value is required.")]
    public int? Ra { get; set; }

    [Required(ErrorMessage = "Overtime status is required.")]
    public bool? IsOvertime { get; set; }

    [Required(ErrorMessage = "Config Type is required.")]
    public string? ConfigType { get; set; }

    [Required(ErrorMessage = "COP value is required.")]
    public int? Cop { get; set; }

    [Required(ErrorMessage = "Car Loan value is required.")]
    public int? CarLoan { get; set; }

    [Required(ErrorMessage = "Home Renovation value is required.")]
    public int? HomeRenov { get; set; }

    [Required(ErrorMessage = "Emergency Loan value is required.")]
    public int? EmergencyLoan { get; set; }
}
