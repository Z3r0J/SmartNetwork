using SmartNetwork.Core.Application.ViewModel.Comments;
using SmartNetwork.Core.Application.ViewModel.Friends;
using SmartNetwork.Core.Application.ViewModel.Likes;
using SmartNetwork.Core.Application.ViewModel.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Users
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

        public List<PostViewModel> Posts { get; set; }

        public List<LikeViewModel> Likes { get; set; }

        public List<CommentViewModel> Comments { get; set; }


        public List<FriendViewModel> FriendsByYou { get; set; }

        public List<FriendViewModel> FriendsByOther { get; set; }
    }
}
