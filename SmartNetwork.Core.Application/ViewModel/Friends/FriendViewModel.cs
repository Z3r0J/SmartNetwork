using SmartNetwork.Core.Application.ViewModel.Posts;
using SmartNetwork.Core.Application.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Friends
{
    public class FriendViewModel
    {
        public int Id { get; set; }
        public int UserFirst { get; set; }
        public UserViewModel UserFrom { get; set; }
        public int UserSecond { get; set; }
        public UserViewModel UserTo { get; set; }

    }
}
