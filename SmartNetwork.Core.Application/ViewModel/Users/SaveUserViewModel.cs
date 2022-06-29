using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.ViewModel.Users
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Complete the Name.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Complete the Lastname.")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        [Required(ErrorMessage = "Complete the Email.")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Complete the Phone.")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Complete the Username.")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Complete the Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Complete the Confirm Password.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="The password doesn't match.")]
        public string ConfirmPassword { get; set; }
        public int Status { get; set; } = 0;

        [Required(ErrorMessage = "Select a profile photo")]
        public IFormFile Image { get; set; }
    }
}
