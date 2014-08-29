using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.DomainModels
{
    public class Team
    {
        private List<Person> _players;

        public List<Person> Players
        {
            get { return _players; }
            set { _players = value; }
        }
        private string _category;

        public Team() { }
        public Team(Guid ID)
        {
            _id = ID;
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }
        private string _name;

        private Guid _coachID;

        public Guid CoachID
        {
            get { return _coachID; }
            set { _coachID = value; }
        }

        
        [Required(ErrorMessage="Team name is required.")]
        public string Name
        {
            get { return (_name); }
            set { _name = value; }
        }

    }
}