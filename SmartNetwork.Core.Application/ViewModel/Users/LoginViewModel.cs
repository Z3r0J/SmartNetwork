using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Complete the username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Complete the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
