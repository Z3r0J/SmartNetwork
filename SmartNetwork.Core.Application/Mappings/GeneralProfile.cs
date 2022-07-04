using AutoMapper;
using SmartNetwork.Core.Application.ViewModel.Comments;
using SmartNetwork.Core.Application.ViewModel.Friends;
using SmartNetwork.Core.Application.ViewModel.Likes;
using SmartNetwork.Core.Application.ViewModel.Posts;
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
            
            CreateMap<Posts,PostViewModel>()
                .ForMember(dest=>dest.LikeCount,opt=>opt.MapFrom(x=>x.Likes.Count))
                .ForMember(dest=>dest.CommentCount,opt=>opt.MapFrom(x => x.Comments.Count))
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            
            CreateMap<Posts,SavePostViewModel>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Likes, opt => opt.Ignore());

            CreateMap<Comment, CommentViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Comment, SaveCommentViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest=>dest.User,opt=>opt.Ignore())
                .ForMember(dest=>dest.Posts,opt=>opt.Ignore());

            CreateMap<Like, LikeViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            
            CreateMap<Like, SaveLikeViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<Friend, FriendViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            
            CreateMap<Friend, SaveFriendViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UserFrom, opt => opt.Ignore())
                .ForMember(dest => dest.UserTo, opt => opt.Ignore());


        }
    }
}
