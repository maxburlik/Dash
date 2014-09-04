using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.DomainModels
{
    public class Tournament
    {
        private Guid _tournid;
        public Tournament()
        {
            _tournid = Guid.NewGuid();
        }

        public Tournament(Guid tournID)
        {
            _tournid = tournID;
        }

        public Guid TournamentID
        {
            get { return _tournid; }
        }

        private string _tournamentName;
        [Required(ErrorMessage = "Please type in tournament name.")]
        public string TournamentName
        {
            get { return _tournamentName; }
            set { _tournamentName = value; }
        }

        private string _tournamentInfo;
        [Required(ErrorMessage = "Please type in tournament information.")]
        public string TournamentInfo
        {
            get { return _tournamentInfo; }
            set { _tournamentInfo = value; }
        }

        private string _location;
        [Required(ErrorMessage = "Please type in tournament location.")]
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private DateTime _registrationstartdate;
        [Required(ErrorMessage = "Please choose a registration start date.")]
        public DateTime RegistrationStartDate
        {
            get { return _registrationstartdate; }
            set { _registrationstartdate = value; }
        }

        private DateTime _registrationenddate;
        [Required(ErrorMessage = "Please choose a registration end date.")]
        public DateTime RegistrationEndDate
        {
            get { return _registrationenddate; }
            set { _registrationenddate = value; }
        }

        private DateTime _tournamentstartdate;
        [Required(ErrorMessage = "Please choose a tournament start date.")]
        public DateTime TournamentStartDate
        {
            get { return _tournamentstartdate; }
            set { _tournamentstartdate = value; }
        }

        private DateTime _tournamentenddate;
        [Required(ErrorMessage = "Please choose a tournament end date.")]
        public DateTime TournamentEndDate
        {
            get { return _tournamentenddate; }
            set { _tournamentenddate = value; }
        }
    }
}