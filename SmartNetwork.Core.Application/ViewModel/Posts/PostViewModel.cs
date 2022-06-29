using SmartNetwork.Core.Application.ViewModel.Comments;
using SmartNetwork.Core.Application.ViewModel.Likes;
using SmartNetwork.Core.Application.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string PictureUrl { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public List<LikeViewModel> Likes { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
