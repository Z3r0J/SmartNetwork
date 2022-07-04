using AutoMapper;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Comments;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Services
{
    public class CommentServices : GenericServices<SaveCommentViewModel,CommentViewModel,Comment>, ICommentServices
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentServices(ICommentRepository commentRepository,IMapper mapper) : base(commentRepository,mapper)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
    }
}
