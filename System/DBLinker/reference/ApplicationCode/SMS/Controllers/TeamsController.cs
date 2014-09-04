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

namespace SMS.Controllers
{
    public class TeamsController : Controller
    {
        //
        // GET: /Teams/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult All(Team Teams, string message)
        {
            CoachAccessRepository rep = new CoachAccessRepository();
            TeamView TeamView = new Models.ViewModels.TeamView();

            TeamView.Coaches = rep.GetAllTeams();
            if (message != null)
                ViewData["Message"] = message;
            return View("TeamsInfo", TeamView);
            
        }

        [HttpGet]
        public ActionResult Team(Guid id) //id = TeamID
        {

            CoachAccessRepository rep = new CoachAccessRepository();
            TeamPageView TeamPageView = new TeamPageView();

            TeamPageView.Team = rep.GetTeam(id);
            TeamPageView.Team.Players = rep.GetTeamPlayers(id);

            TeamPageView.Events = rep.GetTeamEvents(TeamPageView.Team.Id);
            

            return View(TeamPageView);
        }

    }
}
