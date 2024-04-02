using AutoMapper;
using Invoice_Management_Api.Dtos.Response;

namespace Invoice_Management_Api.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<City, GetCitiesResponse>().ForMember(dest => dest.Branches, src => src.MapFrom(x => x.Branches.Select(b => b.BranchName)));


            CreateMap<Cashier, GetCashiersResponse>().ForMember(dest => dest.BranchName, src => src.MapFrom(x => x.Branch.BranchName));

            CreateMap<Branch, GetBranchesResponse>().ForMember(dest => dest.City, src => src.MapFrom(x => x.City.CityName))
                .ForMember(dest => dest.Cashiers, src => src.MapFrom(x => x.Cashiers.Select(c => c.CashierName)));

        }
    }
}
