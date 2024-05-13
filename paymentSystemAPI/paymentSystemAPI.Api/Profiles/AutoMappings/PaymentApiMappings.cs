using AutoMapper;
using paymentSystemAPI.Application.DTOs;
using paymentSystemAPI.Domain.Models;

namespace paymentSystemAPI.Api.Profiles.AutoMappings
{
    public class PaymentApiMappings : Profile
    {
        public PaymentApiMappings()
        {
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<MerchantDTO, Merchant>();
            CreateMap<Merchant, MerchantDTO>();
        }
    }
}
