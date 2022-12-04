using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helper
{
    public class AutoMapperProfiles : Profile
    {       
        public AutoMapperProfiles()
        {
            CreateMap<Investment, RegisterInvestmentDto>();
            CreateMap<Investment, InvestmentDto>();
            CreateMap<RegisterInvestmentDto, Investment>();
            CreateMap<InvestmentDto, Investment>();
        }
    }
}