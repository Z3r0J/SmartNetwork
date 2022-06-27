using SmartNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

        public ICollection<Posts> Posts { get; set; }

        public ICollection<Like> Likes { get; set; }

        public ICollection<Comment> Comments { get; set; }


        public ICollection<Friend> FriendsByYou { get; set; }

        public ICollection<Friend> FriendsByOther { get; set; }

    }
}
