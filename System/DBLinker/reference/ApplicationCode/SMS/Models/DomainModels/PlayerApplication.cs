using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.DomainModels
{
    public class PlayerApplication
    {
        public PlayerApplication(){}

        public PlayerApplication(Guid ID, Person Player)
        {
            _id = ID;
            _player = Player;
        }
        
        private Guid _id;
        public PlayerApplication(Guid ID)
        {
            _id = ID;
        }
        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _bcMedicalNumber;
        
        [Display(Name="BC Medical Number")]
        public string BCMedicalNumber
        {
            get { return _bcMedicalNumber; }
            set { _bcMedicalNumber = value; }
        }

        private DateTime _registrationDate;
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }


        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private bool _consentApproved;
        public bool ConsentApproved
        {
            get { return _consentApproved; }
            set { _consentApproved = value; }
        }

        private char _gender;
        public char Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _medicalAlert;
        public string MedicalAlert
        {
            get { return _medicalAlert; }
            set { _medicalAlert = value; }
        }
        private bool _paid;
        public bool Paid
        {
            get { return _paid; }
            set { _paid = value; }
        }
        private double _payment;
        public double Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        // TODO: attached to the actual team object
        private string _previousTeam;
        public string PreviousTeam
        {
            get { return _previousTeam; }
            set { _previousTeam = value; }
        }
        private string _school;
        public string School
        {
            get { return _school; }
            set { _school = value; }
        }

        private Person _player;
        public Person Player
        {
            get { return _player; }
            set { _player = value; }
        }

        private Person _guardian1;
        public Person Guardian1
        {
            get { return _guardian1; }
            set { _guardian1 = value; }
        }

        private Person _guardian2;
        public Person Guardian2
        {
            get { return _guardian2; }
            set { _guardian2 = value; }
        }

        private Person _coach;
        public Person Coach
        {
            get { return _coach; }
            set { _coach = value; }
        }
    }
}
