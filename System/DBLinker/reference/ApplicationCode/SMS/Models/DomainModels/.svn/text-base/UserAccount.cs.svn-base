using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SMS.Models.ViewModels.Validators;

namespace SMS.Models.DomainModels
{
    [PropertiesMustMatch("Password", "ConfirmPassword",ErrorMessage = "The password and confirmation password do not match.")]
    public class UserAccount
    {
    
        private Person _person;

        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        private Role _role;

        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }



        private string _username;

        [Required(ErrorMessage="Please type in username.")]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _password;

        [Required(ErrorMessage="Please type in password")]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _confirmedPassword;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please confirm password")]
        public string ConfirmPassword
        {
            get { return _confirmedPassword; }
            set { _confirmedPassword = value; }
        }

        public UserAccount()
        {

        }
        public UserAccount(string Username, string Password)
        {
            _username = Username;
            _password = Password;

        }





    }
}