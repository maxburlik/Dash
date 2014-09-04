using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.DomainModels
{
    public class Address
    {
        public Address() { }
        public Address(Guid Id)
        {
            _id = Id;
        }
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _streetAddress = "";

        [Required(ErrorMessage="Please type in street address.")]
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }
        private string _city = "";

        [Required(ErrorMessage="Please type in city.")]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _province = "";

        [Required(ErrorMessage = "Please type in province.")]
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _postalCode = "";

        [Required(ErrorMessage = "Please type in postal code.")]
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }
    }
}