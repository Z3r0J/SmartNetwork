﻿using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Interfaces.Repository
{
    public interface IFriendRepository : IGenericRepository<Friend>
    {
        Task<Friend> CheckAreFriend(Friend entity);
    }
}
