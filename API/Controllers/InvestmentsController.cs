using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;
        
        public InvestmentsController(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _investmentRepository = investmentRepository;            
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<InvestmentDto>>> GetInvestments()
        {
            var investments = await _investmentRepository.GetInvestmentsAsync();

            var investmentsToReturn = _mapper.Map<IEnumerable<InvestmentDto>>(investments);

            return Ok(investmentsToReturn);
        }
        
        [HttpGet("{name}")]
        public async Task<ActionResult<InvestmentDto>> GetInvestment(string name)
        {
            var investment = await _investmentRepository.GetInvestmentAsync(name);
            
            if (investment == null) return NotFound("Investment doesn't exist. Please check Investment Name");
            
            var investmentToReturn = _mapper.Map<InvestmentDto>(investment);
            
            return investmentToReturn;

        }

        [HttpPost("add-investment")]
        public async Task<ActionResult<InvestmentDto>> AddInvestment(RegisterInvestmentDto investmentDto)
        {
            Investment investment = await _investmentRepository.GetInvestmentAsync(investmentDto.Name);
            
            if (investment != null) return BadRequest("Investment already exist. Please use diffrent Investment Name");

            investment=new();

             _mapper.Map(investmentDto, investment);

            await _investmentRepository.AddInvestmentAsync(investment);

            if (await _investmentRepository.SaveAllAsync()) return await GetInvestment(investment.Name);

            return BadRequest("Failed to Create Investment");
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateInvestment(RegisterInvestmentDto investmentDto)
        {

            var investment = await _investmentRepository.GetInvestmentAsync(investmentDto.Name);

            if (investment == null) return NotFound("Investment doesn't exist. Please check the Investment Name");

            _mapper.Map(investmentDto, investment);

            _investmentRepository.UpdateInvestment(investment);

            if (await _investmentRepository.SaveAllAsync()) return Ok("Investment updated successfully!!");

            return BadRequest("Failed to update the Investment");
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteInvestment(string name)
        {
            var investment = await _investmentRepository.GetInvestmentAsync(name);            

            if (investment == null) return NotFound("Investment doesn't exist. Please check the Investment Name");

            _investmentRepository.DeleteInvestment(investment);
            
            if (await _investmentRepository.SaveAllAsync()) return Ok("Investment Deleted");

            return BadRequest("Problem deleting an Investment");
        }
    }
}