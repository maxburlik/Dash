using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models.ViewModels;
using SMS.Models.DBModels;
using System.Web.Security;
using SMS.Models.DomainModels;


namespace SMS.Controllers
{
    public class ThirdPartyController : Controller
    {
        ThirdPartyAccessRepository rep = new ThirdPartyAccessRepository();

        public ActionResult Index()
        {
            return View();
        }

        // HttpPost for adding a new team application; posts form input data to database
        [Authorize(Roles = "Submit Third Party Team Applications")]
        [HttpPost]
        public ActionResult AddTeamApplication(TeamApplication app, Guid TournamentID, Guid OrganizationID)
        {
            TeamApplication temp = new TeamApplication(TournamentID, OrganizationID);
            temp.TeamName = app.TeamName;
            temp.Category = app.Category;
            temp.CoachName = app.CoachName;
            temp.Status = 0;
            bool successbool = false;
            string resultmessage;

            try
            {
                successbool = rep.CreateNewTeamApplication(temp);
            }
            catch (Exception e)
            {
                successbool = false;
            }

            if (successbool)
            {
                resultmessage = "Team application successfully created (not yet submitted).";
            }
            else
            {
                resultmessage = "Please fill in all fields when creating a team application.";
            }

            ModelState.Clear();
            return RedirectToAction("ManageTeamApplications", new { TournamentID = TournamentID, message = resultmessage });
        }

        [Authorize(Roles = "Submit Third Party Team Applications")]
        [HttpGet]
        public ActionResult EditTeamApplication(Guid TeamapplicationID)
        {
            ThirdPartyTeamApplicationInfoView appInfo = new ThirdPartyTeamApplicationInfoView();
            appInfo.TeamApplication = rep.GetTeamApplication(TeamapplicationID);
            appInfo.ApplicationID = appInfo.TeamApplication.ApplicationID;
            appInfo.TournamentID = appInfo.TeamApplication.TournamentID;

            return View("EditTeamApplication", appInfo);
        }

        // HttpPost for editing a team application; updates data in database
        [Authorize(Roles = "Submit Third Party Team Applications")]
        [HttpPost]
        public ActionResult EditTeamApplication(ThirdPartyTeamApplicationInfoView appInfo)
        {
            if (!ModelState.IsValid) 
            {
                return RedirectToAction("ManageTeamApplications", new { TournamentID = appInfo.TournamentID, message = "There was an error in processing your request." });
            }

            bool successbool = false;
            string resultmessage;
            Guid OrgID = rep.GetOrgId(System.Web.HttpContext.Current.User.Identity.Name);
            TeamApplication app = new TeamApplication(appInfo.TournamentID,OrgID,appInfo.ApplicationID);
            app.TeamName = appInfo.TeamApplication.TeamName;
            app.Category = appInfo.TeamApplication.Category;
            app.CoachName = appInfo.TeamApplication.CoachName;

            try
            {
                successbool = rep.EditTeamApplication(app);
            }
            catch (Exception e)
            {
                successbool = false;
            }

            if (successbool)
            {
                resultmessage = "Successfully edited team application.";
            }
            else
            {
                resultmessage = "There was an error in editing chosen team application.";
            }

            ModelState.Clear();
            return RedirectToAction("ManageTeamApplications", new { TournamentID = appInfo.TournamentID, message = resultmessage });
        }

        [Authorize(Roles = "Submit Third Party Team Applications")]
        [HttpGet]
        public ActionResult DeleteTeamApplication(Guid TeamapplicationID)
        {
            ThirdPartyTeamApplicationInfoView appInfo = new ThirdPartyTeamApplicationInfoView();
            appInfo.TeamApplication = rep.GetTeamApplication(TeamapplicationID);
            appInfo.ApplicationID = appInfo.TeamApplication.ApplicationID;
            appInfo.TournamentID = appInfo.TeamApplication.TournamentID;

            return View("DeleteTeamApplication", appInfo);
        }

        // HttpPost for editing a team application; updates data in database
        [Authorize(Roles = "Submit Third Party Team Applications")]
        [HttpPost]
        public ActionResult DeleteTeamApplication(ThirdPartyTeamApplicationInfoView appInfo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ManageTeamApplications", new { TournamentID = appInfo.TournamentID, message = "There was an error in processing your request." });
            }

            bool successbool;
            string resultmessage;
            Guid OrgID = rep.GetOrgId(System.Web.HttpContext.Current.User.Identity.Name);
            TeamApplication app = new TeamApplication(appInfo.TournamentID, OrgID, appInfo.ApplicationID);

            try
            {
                successbool = rep.DeleteTeamApplication(app);
            }
            catch (Exception e)
            {
                successbool = false;
            }

            if (successbool)
            {
                resultmessage = "Successfully deleted team application.";
            }
            else
            {
                resultmessage = "There was an error in deleting chosen team application.";
            }

            ModelState.Clear();
            return RedirectToAction("ManageTeamApplications", new { TournamentID = appInfo.TournamentID, message = resultmessage });
        }

        [Authorize(Roles = "Submit Third Party Team Applications")]
        [HttpPost]
        public ActionResult SubmitTeamApplications(FormCollection form)
        {
            Guid TournamentID = Guid.Empty;
            List<Guid> ApplicationIDs = new List<Guid>();
            bool successbool = true;
            string resultmessage;

            foreach (var item in form.AllKeys)
            {
                Guid id = Guid.Parse(form[item].ToString());
                ApplicationIDs.Add(id);
            }
            
            try
            {
                if (ApplicationIDs.Count() > 0)
                {
                    TournamentID = rep.GetTournamentIdByTeamApp(ApplicationIDs.First());
                    foreach (Guid id in ApplicationIDs)
                    {
                        successbool = rep.SubmitTeamApplication(id) && successbool;
                    }
                }
                else
                {
                    return RedirectToAction("ManageTeamApplications", new { TournamentID = Guid.Empty, message = "You must select one or more teams to submit." });
                }
            }
            catch (Exception e)
            {
                successbool = false;
            }

            if (successbool)
            {
                resultmessage = "The selected team applications were successfully submitted.";
            }
            else
            {
                resultmessage = "There was an error in submitting one or more team applications.";
            }

            ModelState.Clear();
            return RedirectToAction("ManageTeamApplications", new { TournamentID = TournamentID, message = resultmessage });
        }

        // Main function page for third party organization users. Displays team applications for selected tournament
        [Authorize(Roles = "Submit Third Party Team Applications")]
        [HttpGet]
        public ActionResult ManageTeamApplications(Guid TournamentID, string message) 
        {
            ThirdPartyManageExistingApplicationsView teamsview = new ThirdPartyManageExistingApplicationsView();
            teamsview.message = message;
            try
            {
                Guid OrgID = rep.GetOrgId(System.Web.HttpContext.Current.User.Identity.Name);
                List<TeamApplication> teamApps = rep.GetAllTeamApplications(TournamentID, OrgID);
                teamsview.TeamApplications = new List<ThirdPartyTeamApplicationView>();

                foreach (var item in teamApps)
                {
                    teamsview.TeamApplications.Add(new ThirdPartyTeamApplicationView() { IsChecked = (item.Status > 0) ? true : false, TeamApplication = item });
                }

                List<Tournament> Tournaments = rep.GetRegistrationAvailableTournaments();
                teamsview.TournamentDropList = new List<SelectListItem>();
                teamsview.SelectedTournament = rep.GetSelectedTournament(TournamentID);
                teamsview.NewApplication = new TeamApplication(TournamentID, OrgID);
                teamsview.TournamentDropList.Add(new SelectListItem { Text = "Please select a tournament...", Value = Guid.Empty.ToString() });
                foreach (Tournament tourn in Tournaments)
                {
                    teamsview.TournamentDropList.Add(new SelectListItem { Text = tourn.TournamentName, Value = tourn.TournamentID.ToString() });
                }
            }
            catch (Exception e)
            {
                teamsview.message = "There was an error processing your request. Please contact your administrator.";
            }
            
            return View("ManageTeamApplications",teamsview);
        }

        [Authorize(Roles = "Submit Third Party Team Applications")]
        [HttpPost]
        public ActionResult ManageTeamApplications(string SelectedTournamentId, string message)
        {
            ThirdPartyManageExistingApplicationsView teamsview = new ThirdPartyManageExistingApplicationsView();
            //teamsview.message = message;
            try
            {
                Guid OrgID = rep.GetOrgId(System.Web.HttpContext.Current.User.Identity.Name);

                List<TeamApplication> teamApps = rep.GetAllTeamApplications(Guid.Parse(SelectedTournamentId), OrgID);
                teamsview.TeamApplications = new List<ThirdPartyTeamApplicationView>();

                foreach (var item in teamApps)
                {
                    teamsview.TeamApplications.Add(new ThirdPartyTeamApplicationView() { IsChecked = (item.Status > 0) ? true : false, TeamApplication = item });
                }

                List<Tournament> Tournaments = rep.GetRegistrationAvailableTournaments();
                teamsview.SelectedTournament = rep.GetSelectedTournament(Guid.Parse(SelectedTournamentId));
                teamsview.TournamentDropList = new List<SelectListItem>();
                teamsview.TournamentDropList.Add(new SelectListItem { Text = "Please select a tournament...", Value = Guid.Empty.ToString() });
                foreach (Tournament tourn in Tournaments)
                {
                    teamsview.TournamentDropList.Add(new SelectListItem { Text = tourn.TournamentName.ToString(), Value = tourn.TournamentID.ToString() });
                }
                teamsview.NewApplication = new TeamApplication(Guid.Parse(SelectedTournamentId), OrgID);
            }
            catch (Exception e)
            {
                teamsview.message = "There was an error processing your request. Please contact your administrator.";
            }

            return View("ManageTeamApplications", teamsview);
        }
    }
}
