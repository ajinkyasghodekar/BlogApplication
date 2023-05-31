using AutoMapper;
using BlogApplication.DataAccess.Models;
using BlogApplication.DataAccess.Models.DTO.Blog;
using BlogApplication.DataAccess.Models.DTO.Subscription;
using BlogApplication.DataAccess.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlogApi
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<Blog, BlogDTO>().ReverseMap();
            CreateMap<Blog, BlogCreateDTO>().ReverseMap();
            CreateMap<Blog, BlogUpdateDTO>().ReverseMap();

            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<Users, UserCreateDTO>().ReverseMap();
            CreateMap<Users, UserUpdateDTO>().ReverseMap();

            CreateMap<Subscription, SubscriptionDTO>().ReverseMap();
            CreateMap<Subscription, SubscriptionCreateDTO>().ReverseMap();
            CreateMap<Subscription, SubscriptionUpdateDTO>().ReverseMap();
        }
    }
}