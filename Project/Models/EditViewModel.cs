using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Models
{
    public class EditViewModel
    {
        public string? UserID{ get; set; }
        public string? UserName { get; set; } 
        public string? FullName { get; set; } 

        [EmailAddress]
        public string? Email { get; set; } 

        [DataType(DataType.Password)]
        public string? Password { get; set; } 

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The Passwords does not matched")]
        public string? ConfirmPassword { get; set; }

        public IList<string>? SelectedRole {get; set;}
        
    }
}