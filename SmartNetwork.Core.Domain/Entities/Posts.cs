using SmartNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Domain.Entities
{
    public class Posts : AuditableBaseEntity
    {
        public string Body { get; set; }
        public string PictureUrl { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }


        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
