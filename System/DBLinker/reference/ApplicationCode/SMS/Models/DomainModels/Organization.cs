using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using SMS.Models.ViewModels.Validators;

namespace SMS.Models.DomainModels
{
   // [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public class Organization
    {
        public Organization() { }
        
        public Organization(Guid ID)
        {
            _id = ID;
        }
        
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _fax;

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private Address _address;
        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }
       
        
    }
}