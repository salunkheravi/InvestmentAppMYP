using API.Entities;

namespace API.Interfaces
{
    public interface IInvestmentRepository
    {
       Task<bool> SaveAllAsync();
       Task<IEnumerable<Investment>> GetInvestmentsAsync();    
       Task<Investment> GetInvestmentAsync(string name);  
       Task AddInvestmentAsync(Investment investment);       
       void UpdateInvestment(Investment investment);
       void DeleteInvestment(Investment investment);

    }
}