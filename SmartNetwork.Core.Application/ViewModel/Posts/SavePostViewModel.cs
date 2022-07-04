using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Posts
{
    public class SavePostViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string PictureUrl { get; set; }
        public int UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
