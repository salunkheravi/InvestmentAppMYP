using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterInvestmentDto
    {
       [Required] public string Name { get; set; }
       [Required] public DateTime StartDate { get; set; }
       [Required] public double Principal { get; set; }
       [Required] string InterestType { get; set; }
       [Required] public float InterestRate { get; set; }
    }
}