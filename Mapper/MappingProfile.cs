using AutoMapper;
using Invoice_Management_Api.Dtos;
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

            CreateMap<InvoiceDetail, GetInvDetailsResponse>().ForMember(dest => dest.CustomerName, src => src.MapFrom(x => x.InvoiceHeader.CustomerName))
                .ForMember(dest => dest.SubTotal, src => src.MapFrom(x => x.ItemCount * x.ItemPrice));

            CreateMap<InvoiceHeader, GetInvHeadersResponse>().ForMember(dest => dest.Branch, src => src.MapFrom(x => x.Branch.BranchName))
                .ForMember(dest => dest.Cashier, src => src.MapFrom(x => x.Cashier.CashierName))
                .ForMember(dest => dest.Items, src => src.MapFrom(x => x.InvoiceDetails.Select(y => new InvDetailsDto
                {
                   ItemName = y.ItemName,
                   ItemCount =  y.ItemCount,
                   ItemPrice =  y.ItemPrice,
                   SubTotal = (y.ItemCount * y.ItemPrice)
                })))
                .ForMember(dest => dest.Total, src => src.MapFrom
                (x => x.InvoiceDetails.Select(i => new
                {
                    SubTotal = (i.ItemCount * i.ItemPrice)
                }).Sum(z => z.SubTotal))
                );

        }
    }
}
