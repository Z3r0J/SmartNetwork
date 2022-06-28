using SmartNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Domain.Entities
{
    public class Comment : AuditableBaseEntity
    {
        public string Body { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int PostId { get; set; }
        public Posts Posts { get; set; }
    }
}
