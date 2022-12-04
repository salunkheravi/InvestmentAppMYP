using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
            return currentValue;
       }
    }
}