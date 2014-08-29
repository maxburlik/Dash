using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.ViewModels
{
    public class LogonView
    {
        [Required(AllowEmptyStrings=false, ErrorMessage="Please type in your username.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings=false, ErrorMessage="Please type in your password.")]
        public string Password { get; set; }
    }
}