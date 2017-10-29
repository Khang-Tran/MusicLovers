using AutoMapper;
using MusicLovers.Core.DTOs;
using MusicLovers.Core.Models;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers
{
    /// <summary>
    /// This class for Mapping DTOs and Entities
    /// For AutoMapper
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}