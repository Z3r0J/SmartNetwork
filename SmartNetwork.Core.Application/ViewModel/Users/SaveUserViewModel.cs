﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Users
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

        public IFormFile Image { get; set; }
    }
}
