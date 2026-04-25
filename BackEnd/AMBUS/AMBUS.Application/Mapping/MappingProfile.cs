using AMBUS.Application.Dtos.Request;
using AMBUS.Application.Dtos.Response;
using AMBUS.Domain.Models;
using AutoMapper;

namespace AMBUS.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AuthResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Token, opt => opt.Ignore());

            CreateMap<AppUser, UserProfileResponse>();

            CreateMap<RegisterRequest, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.FName + src.LName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<DriverRegisterRequest, AppUser>()
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name)) 
    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
    .ForMember(dest => dest.NationalNumber, opt => opt.MapFrom(src => src.NationalNumber))
    .ForMember(dest => dest.DrivingLicense, opt => opt.MapFrom(src => src.DrivingLicense))
    .ForMember(dest => dest.LicenseExpire, opt => opt.MapFrom(src => src.LicenseExpire));
        }
    }
}
