using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.DomainModels
{
    public class Event
    {
        public Event()
        {

        }
        public Event(Guid ID)
        {
            this._id = ID;
        }
        private DateTime _createdDate;

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        private Guid _createdBy;

        [Display(Name="Created By")]
        public Guid CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        private DateTime _scheduledDate;

        [Required(ErrorMessage="Schedule Date is required.")]
        public DateTime ScheduledDate
        {
            get { return _scheduledDate; }
            set { _scheduledDate = value; }
        }
        private String _description;

        [Required(ErrorMessage="Description is required")]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }
        private string _location;

        [Required(ErrorMessage="Location is required")]
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        private string _name;

        [Required(ErrorMessage="Name is required.")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<Team> _teams;

        public List<Team> Teams
        {
            get { return _teams; }
            set { _teams = value; }
        }


    }

    public enum EventType
    {
        CoachEvent,
        TournamentEvent
    }
}