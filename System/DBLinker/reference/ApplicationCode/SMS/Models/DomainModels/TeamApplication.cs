using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.DomainModels
{
    public class TeamApplication
    {
        public TeamApplication() { }
        
        private Guid _tournid;
        private Guid _orgid;
        private Guid _appid;
        public TeamApplication(Guid tournID, Guid orgID, Guid teamappID)
        {
            _tournid = tournID;
            _orgid = orgID;
            _appid = teamappID;
        }

        public TeamApplication(Guid tournID, Guid orgID)
        {
            _tournid = tournID;
            _orgid = orgID;
        }

        public TeamApplication(Guid teamappID)
        {
            _appid = teamappID;
        }

        public Guid TournamentID
        {
            get { return _tournid; }
        }

        public Guid OrganizationID
        {
            get { return _orgid; }
        }

        public Guid ApplicationID
        {
            get { return _appid; }
            set { _appid = value; }
        }

        private string _teamName;
        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private string _coachname;
        public string CoachName
        {
            get { return _coachname; }
            set { _coachname = value; }
        }

        private int _statusfield;
        public int Status
        {
            get { return _statusfield; }
            set { _statusfield = value; }
        }

        private string _teammessage;
        public string TeamMessage
        {
            get { return _teammessage; }
            set { _teammessage = value; }
        }

        private Organization _org;
        public Organization Organization
        {
            get { return _org; }
            set { _org = value; }
        }


        private DateTime _submissionDate;
        public DateTime SubmissionDate
        {
            get { return _submissionDate; }
            set { _submissionDate = value; }
        }
    }
}