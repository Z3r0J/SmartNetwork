using SmartNetwork.Core.Application.ViewModel.Posts;
using SmartNetwork.Core.Application.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }


        public int PostId { get; set; }
        public PostViewModel Posts { get; set; }
    }
}
