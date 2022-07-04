using SmartNetwork.Core.Application.ViewModel.Friends;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Interfaces.Services
{
    public interface IFriendServices : IGenericServices<SaveFriendViewModel,FriendViewModel,Friend>
    {
        Task<FriendViewModel> CheckAreFriend(SaveFriendViewModel viewModel);
    }
}
