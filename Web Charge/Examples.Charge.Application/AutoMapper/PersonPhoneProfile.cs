using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonPhoneProfile : Profile
    {
        public PersonPhoneProfile()
        {
            CreateMap<PersonPhone, PersonPhoneDto>()
               .ReverseMap()
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.BusinessEntityID))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
               .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
               //.ForMember(dest => dest.Person.BusinessEntityID, opt => opt.Ignore())
               //.ForMember(dest => dest.Person.Phones, opt => opt.Ignore())
               //.ForMember(dest => dest.Person.DomainEvents, opt => opt.Ignore())
               .ForMember(dest => dest.PhoneNumberType, opt => opt.MapFrom(src => src.PhoneNumberType));
               //.ForMember(dest => dest.PhoneNumberType.DomainEvents, opt => opt.Ignore());
               //.ForMember(dest => dest.PhoneNumberType.PhoneNumberTypeID, opt => opt.Ignore());


            CreateMap<PersonPhoneDto, PersonPhoneRequest>()
                .ReverseMap()
                .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.BusinessEntityID))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID));

            CreateMap<Person, PersonDto>()
                .ReverseMap();

            CreateMap<PhoneNumberType, PhoneNumberTypeDto>()
                .ReverseMap();
        }
    }
}
