using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Comments
{
    public class SaveCommentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The comment is required")]
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
