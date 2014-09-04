using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Models.DomainModels;
using System.Web.Mvc;
using SMS.Views.Shared;
using SMS.Models.ViewModels.Validators;

namespace SMS.Models.ViewModels
{
    public class CoachManageTeamEventsView
    {
        public CoachManageTeamEventsView() { }
        public Event Event;
        public List<CheckBoxListInfo> TeamsToNotify;
        public List<Event> ExistingEvents;
        public bool SendEmailToPlayers;

        [BoolType(true, ErrorMessage = "Please select at least one available team.")]
        public bool HasSelectedTeam { get; set; }
    }
    public class CoachManageTeamsView
    {
        public List<PlayerApplication> UnassignedPlayers;
        public List<SelectListItem> CurrentTeams;
        public Team NewTeam;
    }

    public class CoachAssignTeamView
    {
        public CoachAssignTeamView() {}
        public string PlayerName;
        public List<SelectListItem> Teams;
        public Guid PlayerID;
    }

    public class CoachChangeTeamView
    {
        public CoachChangeTeamView() { }
        public string PlayerName;
        public List<SelectListItem> Teams;
        public Guid PlayerID;
        public Guid ExistingTeamID;
    }
}