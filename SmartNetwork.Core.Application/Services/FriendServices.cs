using AutoMapper;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Friends;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Services
{
    public class FriendServices : GenericServices<SaveFriendViewModel,FriendViewModel,Friend>, IFriendServices
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        public FriendServices(IFriendRepository friendRepository,IMapper mapper) : base(friendRepository,mapper)
        {
            _mapper = mapper;
            _friendRepository = friendRepository;
        }

        public async Task<FriendViewModel> CheckAreFriend(SaveFriendViewModel viewModel) {

            var response = await _friendRepository.CheckAreFriend(_mapper.Map<Friend>(viewModel));

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<FriendViewModel>(response);
        } 

    }
}
