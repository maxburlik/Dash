using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SMS.Models.ViewModels.Validators;

namespace SMS.Models.ViewModels
{
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
  
    public class ChangePasswordView
    {
        [Required(ErrorMessage = "Please type in password.")]
        public string Password {get;set;}

        [Display(Name="Confirm Password")]
        [Required(ErrorMessage = "Please confirm password.")]
        public string ConfirmPassword { get; set; }


        public string Username { get; set; }

    }
}