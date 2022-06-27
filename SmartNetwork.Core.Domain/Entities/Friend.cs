using SmartNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Domain.Entities
{
    public class Friend : AuditableBaseEntity
    {
        public int UserFirst { get; set; }
        public User UserFrom { get; set; }

        public int UserSecond { get; set; }
        public User UserTo { get; set; }


    }
}
