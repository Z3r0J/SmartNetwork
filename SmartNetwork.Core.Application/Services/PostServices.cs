using AutoMapper;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Posts;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Services
{
    public class PostServices : GenericServices<SavePostViewModel,PostViewModel,Posts>, IPostServices
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostServices(IPostRepository postRepository,IMapper mapper) : base(postRepository,mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
    }
}
