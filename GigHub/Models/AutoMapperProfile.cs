using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Controllers.Api;
 
namespace GigHub.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Genere, GenereDto>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}