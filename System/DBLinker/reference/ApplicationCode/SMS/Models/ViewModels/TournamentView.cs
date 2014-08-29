using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Views.Shared;
using SMS.Models.DomainModels;
using System.ComponentModel.DataAnnotations;
using SMS.Models.ViewModels.Validators;

namespace SMS.Models.ViewModels
{
    public class CreateNewTournamentView
    {
        public CreateNewTournamentView() { }
        public Tournament Tournament { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }

    public class ManageTeamApplicationsView
    {
        public ManageTeamApplicationsView() { }
        public List<SelectListItem> TournamentDropList { get; set; }
        public List<TeamApplication> TeamApplications { get; set; }
        public Tournament SelectedTournament { get; set; }
        public Guid SelectedTournamentId { get; set; }
    }
    
    public class TournamentPlanningView
    {
        public List<SelectListItem> Tournaments { get; set; }
        public Guid SelectedTournamentID { get; set; }
        public List<SelectListItem> SelectedTournamentTeamApplications { get; set; }
        public List<Match> SelectedTournamentMatches { get; set; }
        public Match SelectedTournamentNewMatch { get; set; }
    }


}