using SmartNetwork.Core.Application.ViewModel.Likes;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Interfaces.Services
{
    public interface ILikeServices : IGenericServices<SaveLikeViewModel,LikeViewModel,Like>
    {
        Task<SaveLikeViewModel> GetLikeExists(SaveLikeViewModel model);
    }
}
