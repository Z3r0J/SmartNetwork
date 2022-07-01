using AutoMapper;
using SmartNetwork.Core.Application.ViewModel.Users;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, SaveUserViewModel>()
                .ForMember(dest=>dest.File,opt=>opt.Ignore())
                .ForMember(dest=>dest.ConfirmPassword,opt=>opt.Ignore())
                .ReverseMap()
                .ForMember(dest=> dest.Created,opt=>opt.Ignore())
                .ForMember(dest=> dest.CreatedBy,opt=>opt.Ignore())
                .ForMember(dest=> dest.LastModified,opt=>opt.Ignore())
                .ForMember(dest=> dest.LastModifiedBy,opt=>opt.Ignore())
                .ForMember(dest=> dest.Posts,opt=>opt.Ignore())
                .ForMember(dest=> dest.Likes,opt=>opt.Ignore())
                .ForMember(dest=> dest.Comments,opt=>opt.Ignore())
                .ForMember(dest=> dest.FriendsByOther,opt=>opt.Ignore())
                .ForMember(dest=> dest.FriendsByYou,opt=>opt.Ignore());

            CreateMap<User, UserViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
        }
    }
}
