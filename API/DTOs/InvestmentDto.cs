namespace API.DTOs
{
    public class InvestmentDto
    {
       public string Name { get; set; }
       public DateTime StartDate { get; set; }
       public double Principal { get; set; }
       public string InterestType { get; set; }
       public float InterestRate { get; set; }
       public double CurrentValue { get; set; }
    }
}