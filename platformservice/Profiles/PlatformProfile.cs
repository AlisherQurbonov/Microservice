using AutoMapper;
using platformservice.Dtos;
using platformservice.Entities;

namespace platformservice.Profiles;

public class PlatformProfile : Profile
{
    public PlatformProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformCreateDto, Platform>();
    }
}