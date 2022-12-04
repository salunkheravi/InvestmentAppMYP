using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Investment
    {
       [Key]
       public string Name { get; set; }
       public DateTime StartDate { get; set; }
       public double Principal { get; set; }
       public string InterestType { get; set; }
       public float InterestRate { get; set; }
       public double GetCurrentValue()
       {
            double currentValue = 0.0;
            var periodInMonths = Math.Round(DateTime.Now.Subtract(this.StartDate).Days / (365.2425 / 12));
            if(this.InterestType.ToLower() == "simple")
            { 
                //Calculating the simple interest based on the information provided on 
                //https://www.calculatorsoup.com/calculators/financial/simple-interest-plus-principal-calculator.php
                currentValue = this.Principal * (1 + ((this.InterestRate/100 ) * (periodInMonths/12)));
                
            }else if(this.InterestType.ToLower() == "compound")
            {
            }
            return Math.Round(currentValue,2);
       }
    }
}