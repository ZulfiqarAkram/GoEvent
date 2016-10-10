using AutoMapper;
using GoEvent.Core.Dto;
using GoEvent.Core.Models;

namespace GoEvent.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}