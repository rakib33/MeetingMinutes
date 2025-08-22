using AutoMapper;
using MeetingMinutes.Application.DTOs;
using MeetingMinutes.Domain.Entities;
namespace DoctorBooking.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MeetingMinutesMaster, MeetingDto>().ReverseMap();
            CreateMap<CorporateCustomer, CorporateCustomerDto>().ReverseMap();
            CreateMap<IndividualCustomer, IndividualCustomerDto>().ReverseMap();
            CreateMap<MeetingMinutesDetails, MeetingDetailsDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
