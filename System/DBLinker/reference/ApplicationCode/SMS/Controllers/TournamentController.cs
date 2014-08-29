using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models.ViewModels;
using SMS.Models.DomainModels;
using SMS.Models.DBModels;
using SMS.Views.Shared;
using System.Configuration;
using SMS.Models.ViewModels.Binders;

namespace SMS.Controllers
{
    public class TournamentController : Controller
    {
        //
        // GET: /Tournament/
        [Authorize(Roles = "Manage Tournaments")]
        public ActionResult Index()
        {
            return View("Create");
        }


        [HttpGet]
        public ActionResult All()
        {
            CreateNewTournamentView tournaments = new CreateNewTournamentView();
            TournamentAccessRepository rep = new TournamentAccessRepository();
            tournaments.Tournaments = rep.GetAllTournaments();

            return View("TournamentsInfo", tournaments);
        }

        [Authorize(Roles = "Manage Tournaments")]
        [HttpGet]
        public ActionResult Create()
        {
            CreateNewTournamentView tournaments = new CreateNewTournamentView();
            TournamentAccessRepository rep = new TournamentAccessRepository();
            tournaments.Tournaments = rep.GetAllTournaments();

            return View("Create", tournaments);
        }

        [Authorize(Roles = "Manage Tournaments")]
        [HttpPost]
        public ActionResult Create(Tournament Tournament)
        {
            try
            {
                TournamentAccessRepository rep = new TournamentAccessRepository();
                Guid TournamentID = rep.CreateNewTournament(Tournament);
                if (TournamentID != Guid.Empty)
                {
                    ViewData["Message"] = "The new tournament has been created.";
                    return View("Create", null);
                }

            }
            catch (Exception e)
            {
                ViewData["Message"] = "There was an error processing your request. Please try again.";
                return View();
            }

            return View();
        }

        [Authorize(Roles = "Manage Tournaments")]
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ModelState.Clear();
            TournamentAccessRepository rep = new TournamentAccessRepository();
            Tournament tournament = new Tournament(id);
            tournament = rep.GetTournamentByID(id);
            return View("Edit", tournament);
        }

        [Authorize(Roles = "Manage Tournaments")]
        [HttpPost]
        public ActionResult Edit(Tournament Tournament, Guid id)
        {
            TournamentAccessRepository rep = new TournamentAccessRepository();
            try
            {
                Tournament tournament = new Tournament(id);
                tournament.TournamentName = Tournament.TournamentName;
                tournament.TournamentInfo = Tournament.TournamentInfo;
                tournament.Location = Tournament.Location;
                tournament.RegistrationStartDate = Tournament.RegistrationStartDate;
                tournament.RegistrationEndDate = Tournament.RegistrationEndDate;
                tournament.TournamentStartDate = Tournament.TournamentStartDate;
                tournament.TournamentEndDate = Tournament.TournamentEndDate;

                bool isUpdated = rep.UpdateTournament(tournament);

                if (isUpdated)
                    ViewData["Message"] = "Tournament has been updated successfully!";
                else
                    ViewData["Message"] = "There was an error updating this tournament. Please contact your administrator!";

                return View("Edit", null);
            }
            catch (Exception e)
            {
            }
            return View("Edit");
        }

        [Authorize(Roles = "Manage Tournaments")]
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            TournamentAccessRepository rep = new TournamentAccessRepository();
            Tournament tournament = new Tournament(id);
            tournament = rep.GetTournamentByID(id);
            return View("Delete", tournament);
        }

        [Authorize(Roles = "Manage Tournaments")]
        [HttpPost]
        public ActionResult Delete(Tournament Tournament, Guid id)
        {
            TournamentAccessRepository rep = new TournamentAccessRepository();
            try
            {
                bool isDeleted = rep.DeleteTournament(id);

                if (isDeleted)
                    ViewData["Message"] = "Tournament has been deleted successfully!";
                else
                    ViewData["Message"] = "There was an error deleting this tournament. Please contact your administrator!";

                return View("Delete", null);
            }
            catch (Exception e)
            {
            }
            return View("Delete");
        }

        [Authorize(Roles = "Tournament Planning")]
        [HttpGet]
        public ActionResult Planning(string id, string message) //id = Tournament ID
        {
            ViewData["Message"] = message;

            TournamentPlanningView view = new TournamentPlanningView();

            if (id != null && id.Trim() != "")
            {
                view.SelectedTournamentID = Guid.Parse(id);

            }

            List<TeamApplication> teamApplications = null; ;
            TournamentAccessRepository tourRep = new TournamentAccessRepository();
            List<Tournament> tournaments = tourRep.GetAllTournaments();



            if (view.SelectedTournamentID != Guid.Empty)
            {
                teamApplications = tourRep.GetAllApprovedTeamApplicationsByTournamentID(view.SelectedTournamentID);
                view.SelectedTournamentMatches = tourRep.GetTournamentMatches(view.SelectedTournamentID);
            }
            else
            {
                teamApplications = new List<TeamApplication>();
                view.SelectedTournamentMatches = new List<Match>();
            }

            view.SelectedTournamentTeamApplications = new List<SelectListItem>();
            foreach (var item in teamApplications)
            {
                view.SelectedTournamentTeamApplications.Add(new SelectListItem { Value = item.ApplicationID.ToString(), Text = item.Organization.Name + " - " + item.TeamName + "(" + item.Category + ")" });
                
            }


            view.Tournaments = new List<SelectListItem>();

            foreach (var item in tournaments)
            {
                view.Tournaments.Add(new SelectListItem { Text = item.TournamentName, Value = item.TournamentID.ToString() });
            }


            return View(view);
        }

        [Authorize(Roles = "Tournament Planning")]
        [HttpPost]
        public ActionResult UpdateMatch([ModelBinder(typeof(TournamentPlanningMatchViewModelBinder))]Match Match)//
        {
            TournamentAccessRepository rep = new TournamentAccessRepository();
            if (rep.UpdateMatch(Match))
                return RedirectToAction("Planning", new { id = Match.Tournament.TournamentID, message = "Match updated successfully!" });
            else
                return RedirectToAction("Planning", new { id = Match.Tournament.TournamentID, message = "There was problem updating match. Please contact your administrator" });
        }

        [Authorize(Roles = "Tournament Planning")]
        [HttpPost]
        public ActionResult Planning(string SelectedTournamentID)
        {
            return RedirectToAction("Planning", new { id = SelectedTournamentID });
        }
        [Authorize(Roles = "Tournament Planning")]
        [HttpPost]
        public ActionResult DeleteMatch(string id, string TournamentID) //MatchID
        {
            TournamentAccessRepository rep = new TournamentAccessRepository();
            if (rep.DeleteMatch(Guid.Parse(id)))
                return RedirectToAction("Planning", new { id = TournamentID, message = "Match deleted successfully!" });
            else
                return RedirectToAction("Planning", new { id = TournamentID, message = "There was an error deleting match. Please contact your administrator" });

        }
        [Authorize(Roles = " Manage Tournament Team Applications")]
        [HttpPost]
        public ActionResult CreateNewMatch(TournamentPlanningView view)
        {
            TournamentAccessRepository rep = new TournamentAccessRepository();
            Guid match_id = rep.CreateTournamentMatch(view.SelectedTournamentNewMatch, view.SelectedTournamentID);

            if (match_id != Guid.Empty)
            {
                return RedirectToAction("Planning", new { id = view.SelectedTournamentID, message = "Match created successfully!" });
            }
            else
            {
                return RedirectToAction("Planning", new { id = view.SelectedTournamentID, message = "There was an error creating match!" });
            }

        }

        [Authorize(Roles = " Manage Tournament Team Applications")]
        [HttpGet]
        public ActionResult ManageTeamApplications(ManageTeamApplicationsView teamApplications, string id, string message)
        {
            try
            {
                ThirdPartyAccessRepository rep = new ThirdPartyAccessRepository();
                teamApplications = new ManageTeamApplicationsView();
                List<Tournament> tournaments = rep.GetRegistrationAvailableTournaments();
                teamApplications.TournamentDropList = new List<SelectListItem>();
                foreach (Tournament tourn in tournaments)
                {
                    teamApplications.TournamentDropList.Add(new SelectListItem { Text = tourn.TournamentName, Value = tourn.TournamentID.ToString() });
                }
                if (id != null)
                {
                    if (message != null)
                        ViewData["Message"] = message;
                    TournamentAccessRepository tournament_rep = new TournamentAccessRepository();
                    teamApplications.TeamApplications = tournament_rep.GetAllTeamApplicationsByTournamentID(Guid.Parse(id));

                }
                return View("ManageTeamApplications", teamApplications);
            }
            catch (Exception e)
            {
                ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
            }

            return null;

        }

        [Authorize(Roles = " Manage Tournament Team Applications")]
        [HttpPost]
        public ActionResult ManageTeamApplications(Guid SelectedTournamentId)
        {
            ManageTeamApplicationsView teamApplications = null;
            try
            {
                teamApplications = new ManageTeamApplicationsView();
                TournamentAccessRepository rep = new TournamentAccessRepository();
                ThirdPartyAccessRepository third_party_rep = new ThirdPartyAccessRepository();
                List<Tournament> tournaments = third_party_rep.GetRegistrationAvailableTournaments();
                teamApplications.TournamentDropList = new List<SelectListItem>();
                foreach (Tournament tourn in tournaments)
                {
                    teamApplications.TournamentDropList.Add(new SelectListItem { Text = tourn.TournamentName, Value = tourn.TournamentID.ToString() });
                }
                teamApplications.TeamApplications = rep.GetAllTeamApplicationsByTournamentID(SelectedTournamentId);
                if (teamApplications.TeamApplications == null)
                    ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
            }
            catch (Exception e)
            {
                ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
            }

            return View("ManageTeamApplications", teamApplications);
        }


        [Authorize(Roles = " Manage Tournament Team Applications")]
        [HttpPost]
        public ActionResult TeamApproveOrDeny(FormCollection Form)
        {

            ManageTeamApplicationsView teamApplications = null;
            try
            {
                Guid teamApplicationID = Guid.Parse(Form.Get(Request.Form.Keys[0]));
                Guid tournamentID = Guid.Parse(Form.Get(Request.Form.Keys[1]));
                string teamMessage = Form.Get(Request.Form.Keys[2]).ToString();
                string decision = Form.Get(Request.Form.Keys[3]).ToString();
                int status = 0;
                if (decision == "Approve")
                    status = 2;
                else if (decision == "Deny")
                    status = 3;
                TournamentAccessRepository rep = new TournamentAccessRepository();
                bool isUpated = rep.UpdateTeamApplication(teamApplicationID, status, teamMessage);
                if (isUpated)
                    ViewData["Message"] = "The team application updated successfully";
                else
                    ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";

                teamApplications = new ManageTeamApplicationsView();
                ThirdPartyAccessRepository third_party_rep = new ThirdPartyAccessRepository();
                List<Tournament> tournaments = third_party_rep.GetRegistrationAvailableTournaments();
                teamApplications.TournamentDropList = new List<SelectListItem>();
                foreach (Tournament tourn in tournaments)
                {

                    teamApplications.TournamentDropList.Add(new SelectListItem { Text = tourn.TournamentName, Value = tourn.TournamentID.ToString() });
                }
                teamApplications.TeamApplications = rep.GetAllTeamApplicationsByTournamentID(tournamentID);
                return RedirectToAction("ManageTeamApplications", new { id = tournamentID, message = ViewData["Message"] });//, message = "The team application updated successfully!" });
            }

            catch (Exception e)
            {
                ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
            }

            return Redirect(Url.Content("~/Tournament/ManageTeamApplications/"));
        }

        [HttpGet]
        public ActionResult MatchSchedule(string id)
        {
            try
            {
                   TournamentAccessRepository rep = new TournamentAccessRepository();
                   List<TeamApplication> teamApplications = rep.GetAllApprovedTeamApplicationsByTournamentID(Guid.Parse(id));
                   List<Match> matches = rep.GetTournamentMatches(Guid.Parse(id));
                   foreach (var match in matches)
                   {
                       foreach (var teamApp in teamApplications)
                       {
                           if (match.TeamApplicationOne.ApplicationID == teamApp.ApplicationID)
                           {
                               match.TeamApplicationOne.Organization = teamApp.Organization;
                           }
                           if (match.TeamApplicationTwo.ApplicationID == teamApp.ApplicationID)
                           {
                               match.TeamApplicationTwo.Organization = teamApp.Organization;
                           }

                       }
                   }

                   return View("MatchSchedule", matches);
            }
            catch
            {
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult Randomizer()
        {
            return View();
        }
    }
}
