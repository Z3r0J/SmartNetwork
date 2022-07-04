using AutoMapper;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Likes;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Services
{
    public class LikeServices : GenericServices<SaveLikeViewModel,LikeViewModel,Like>, ILikeServices
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public LikeServices(ILikeRepository likeRepository,IMapper mapper) : base(likeRepository,mapper)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
        }

        public async virtual Task<SaveLikeViewModel> GetLikeExists(SaveLikeViewModel model)
        {
            var response = await _likeRepository.GetLikeExist(_mapper.Map<Like>(model));
            
            if (response == null) return null;

            return _mapper.Map<SaveLikeViewModel>(response);

        }
    }
}
