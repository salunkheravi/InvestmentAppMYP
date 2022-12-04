using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly DataContext _context;        
        public InvestmentRepository(DataContext context)
        {            
            _context = context;
        }

        public async Task AddInvestmentAsync(Investment investment)
        {
            await _context.Investments.AddAsync(investment);  
        }

        public void DeleteInvestment(Investment investment)
        {
            _context.Investments.Remove(investment);
        }

        public async Task<Investment> GetInvestmentAsync(string name)
        {
            return await _context.Investments.FindAsync(name);
        }

        public async Task<IEnumerable<Investment>> GetInvestmentsAsync()
        {
            return await _context.Investments.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateInvestment(Investment investment)
        {
            _context.Entry(investment).State = EntityState.Modified;
        }
    }
}