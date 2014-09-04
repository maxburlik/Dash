using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SMS.Models.DomainModels
{
    public class Person
    {
        public Person() { }
        private string _email;

        [Required(ErrorMessage="Please type in email address.")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _firstName;

        [Required(ErrorMessage="Please type in first name.")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _lastName;

        [Required(ErrorMessage = "Please type in last name.")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private string _mainPhone;

        [Required(ErrorMessage = "Please type in phone number.")]
        public string MainPhone
        {
            get { return _mainPhone; }
            set { _mainPhone = value; }
        }
        private string _workPhone;

        public string WorkPhone
        {
            get { return _workPhone; }
            set { _workPhone = value; }
        }

        private Address _address;

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private Organization _org;

        public Organization Organization
        {
            get { return _org; }
            set { _org = value; }
        }
        private PersonType _type;

        public PersonType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private Guid _id;

        public Guid ID
        {
            get { return _id; }
            set { _id = value;  } 
        }

        public Person(Guid ID)
        {
            _id = ID;
        }
    }

    public enum PersonType
    {
        Player,
        Employee,
        ThirdParty
    }
}