using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Models.DomainModels;
using System.Web.Mvc;

namespace SMS.Models.ViewModels
{
    public class ThirdPartyManageExistingApplicationsView
    {
        public List<SelectListItem> TournamentDropList { get; set; }
        public List<ThirdPartyTeamApplicationView> TeamApplications { get; set; }
        public Tournament SelectedTournament { get; set; }
        public Guid SelectedTournamentId { get; set; }
        public TeamApplication NewApplication { get; set; }
        public string message { get; set; } 
    }

    public class ThirdPartyTeamApplicationView
    {
        public ThirdPartyTeamApplicationView() { }
        public TeamApplication TeamApplication { get; set; }
        public bool IsChecked { get; set; }
    }

    public class ThirdPartyTeamApplicationInfoView
    {
        public TeamApplication TeamApplication { get; set; }
        public Guid ApplicationID { get; set; }
        public Guid TournamentID { get; set; }
    }
}