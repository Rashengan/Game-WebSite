using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The Passwords does not matched")]
        public string ConfirmPassword { get; set; } = string.Empty;


        
    }
}