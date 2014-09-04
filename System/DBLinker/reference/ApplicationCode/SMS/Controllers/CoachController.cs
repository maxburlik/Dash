using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models.ViewModels;
using SMS.Models.DBModels;
using System.Web.Security;
using SMS.Models.DomainModels;
using SMS.Views.Shared;
using SMS.Models.ViewModels.Binders;
using System.Net.Mail;

namespace SMS.Controllers
{
    public class CoachController : Controller
    {
        //
        // GET: /Coach/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Manage Team Events")]
        public ActionResult ManageTeamEvents(string message)
        {
            CoachAccessRepository coachRep = new CoachAccessRepository();
            UserAccessRepository userRep = new UserAccessRepository();

            CoachManageTeamEventsView CoachTeamEventsView = new CoachManageTeamEventsView();

            Guid CoachID = userRep.GetPersonID(System.Web.HttpContext.Current.User.Identity.Name);

            CoachTeamEventsView.ExistingEvents = coachRep.GetEvents(CoachID);

            List<Team> teams = coachRep.GetTeams(CoachID);


            if (teams.Count != 0)
            {
                CoachTeamEventsView.TeamsToNotify = new List<Views.Shared.CheckBoxListInfo>();
                for (int i = 0; i < teams.Count; i++)
                    CoachTeamEventsView.TeamsToNotify.Add(new CheckBoxListInfo(teams.ElementAt(i).Id.ToString(), teams.ElementAt(i).Name, false));

            }

            if (message != null)
                ViewData["Message"] = message;

            
            return View(CoachTeamEventsView);
        }

        [Authorize(Roles = "Manage Team Events")]
        public ActionResult DeleteEvent(Guid id) //id = EventID
        {
            CoachAccessRepository coachRep = new CoachAccessRepository();
            
            Event anEvent = coachRep.GetCoachEvent(id);

            return View(anEvent);
        }
        [Authorize(Roles = "Manage Team Events")]
        [HttpPost]
        public ActionResult DeleteEvent(string id) //id = EventID
        {
            CoachAccessRepository coachRep = new CoachAccessRepository();
            UserAccessRepository userRep = new UserAccessRepository();
            
            Event anEvent = null;

            Guid CoachID = userRep.GetPersonID(System.Web.HttpContext.Current.User.Identity.Name);
            try
            {
                if (coachRep.DeleteCoachEvent(Guid.Parse(id), CoachID))
                {
                    ViewData["Message"] = "Event deleted succesfully!";
                }
                else
                {
                    ViewData["Message"] = "Couldn't delete this event. Please contact your administrator.";
                }
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Couldn't delete this event. Please contact your administrator.";
            }



            return View(anEvent);
        }
        [Authorize(Roles = "Manage Team Events")]
        [HttpPost]
        public ActionResult ManageTeamEvents([ModelBinder(typeof(CoachManageTeamEventsViewModelBinder))] CoachManageTeamEventsView CoachManageTeamEventsView)
        {
            CoachAccessRepository coachRep = new CoachAccessRepository();
            UserAccessRepository userRep = new UserAccessRepository();
            
            Guid CoachID = userRep.GetPersonID(System.Web.HttpContext.Current.User.Identity.Name);

            List<Team> teams = new List<Team>();

            for (int i = 0; i < CoachManageTeamEventsView.TeamsToNotify.Count; i++)
            {
                Team team = coachRep.GetTeam(Guid.Parse(CoachManageTeamEventsView.TeamsToNotify[i].Value));
                teams.Add(team);
            }

            if (ModelState.IsValid)
            {
                CoachManageTeamEventsView.Event.CreatedBy = CoachID;
                CoachManageTeamEventsView.Event.Teams = teams;

                if (coachRep.CreateEvent(CoachManageTeamEventsView.Event))
                {
                    ViewData["Message"] = "Your event was created successfully.";

                    if (CoachManageTeamEventsView.SendEmailToPlayers)
                    {
                        List<Person> people = new List<Person>();

                        foreach (var team in CoachManageTeamEventsView.Event.Teams)
                        {
                            List<Person> players = coachRep.GetTeamPlayers(team.Id);
                            people.AddRange(players); 
                        }


                        MailMessage message = new MailMessage();

                        //message.To.Add(new MailAddress(PlayerApplication.Player.Email));
                        message.Subject = "PhoenixFC - Event - " + CoachManageTeamEventsView.Event.Name;
                        message.Body = "Dear Player: Your coach has scheduled an event. Please check your team web page for more information.";

                        SmtpClient client = new SmtpClient();
                        
                        

                        foreach (var person in people)
                        {
                            message.To.Add(new MailAddress(person.Email)); 
                        }


                        try
                        {

                            client.Send(message);
                            return RedirectToAction("ManageTeamEvents", "Coach", new { message = "Your event was created successfully." });

                        }
                        catch (Exception e)
                        {
                            if (e is System.Net.Mail.SmtpException)
                            {
                               return RedirectToAction("ManageTeamEvents", "Coach", new { message = "Your event was created successfully. However, there was an error sending email to all players." });

                            }
                        }
                    }


                    CoachManageTeamEventsView.Event = null;
                    CoachManageTeamEventsView.SendEmailToPlayers = false;
                    CoachManageTeamEventsView.ExistingEvents = coachRep.GetEvents(CoachID);

                    
                }
                else
                {
                    return RedirectToAction("ManageTeamEvents", "Coach", new { message = "There was an error creating your event. Please contact your administrator." });

                }

            }

            teams = coachRep.GetTeams(CoachID);
            if (teams.Count != 0)
            {
                CoachManageTeamEventsView.TeamsToNotify = new List<Views.Shared.CheckBoxListInfo>();
                for (int i = 0; i < teams.Count; i++)
                    CoachManageTeamEventsView.TeamsToNotify.Add(new CheckBoxListInfo(teams.ElementAt(i).Id.ToString(), teams.ElementAt(i).Name, false));

            }

            return View(CoachManageTeamEventsView);
        }

        [Authorize(Roles = "Manage Teams")]
        [HttpPost]
        public ActionResult DeleteTeam(string id) //id = TeamID
        {
            CoachAccessRepository rep = new CoachAccessRepository();

            try
            {
                int numOfPlayers = rep.NumOfPlayersInTeam(Guid.Parse(id));
                
                if (numOfPlayers == 0)
                {
                    if (rep.DeleteTeam(Guid.Parse(id)))
                        ViewData["Message"] = "Team deleted successfully!";
                    else
                        ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
                
                }
                else if (numOfPlayers < 0)
                {
                    ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
          
                }
                else
                {
                    ViewData["Message"] = "Could not delete this team because there are players under this team.";
                }
            }
            catch (Exception e)
            {
                ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
            }

            return View();
        }

        [Authorize(Roles = "Manage Teams")]
        public ActionResult DeleteTeam(Guid id) //id = TeamID
        {
            CoachAccessRepository rep = new CoachAccessRepository();
            Team team = null;

            try
            {
                team = rep.GetTeam(id);


            }
            catch (Exception e)
            {
                ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
            }


            return View(team);
        }

        [Authorize(Roles = "Manage Teams")]
        public ActionResult UnassignTeam(Guid id) //id = PlayerID
        {
            UserAccessRepository rep = new UserAccessRepository();
            Person player = rep.GetPerson(id);

            return View(player);
        }

        [HttpPost]
        [Authorize(Roles = "Manage Teams")]
        public ActionResult UnassignTeam(string id) //id = PlayerID
        {
            UserAccessRepository rep = new UserAccessRepository();
            Person player = null;
            
            try
            {
                player = rep.GetPerson(Guid.Parse(id));
                CoachAccessRepository coachRep = new CoachAccessRepository();

                if (coachRep.UnassignTeamPlayer(Guid.Parse(id)))
                    ViewData["Message"] = "Player was unassigned from team successfully.";
                else
                    ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
          
            }
            catch
            {
                ViewData["Message"] = "There was an error processing your request. Please contact your administrator.";
            }

            player = null;
            return View(player);
        }


        [Authorize(Roles = "Manage Teams")]
        public ActionResult AssignPlayerBackToRegistrar(Guid id) //id = PlayerID
        {
            UserAccessRepository rep = new UserAccessRepository();
            Person player = rep.GetPerson(id);

            return View(player);
        }

        [HttpPost]
        [Authorize(Roles = "Manage Teams")]
        public ActionResult AssignPlayerBackToRegistrar(string id) //id = PlayerID
        {
            UserAccessRepository rep = new UserAccessRepository();
            Person player = null;

            try
            {
                player = rep.GetPerson(Guid.Parse(id));

                CoachAccessRepository coachRep = new CoachAccessRepository();

                if (coachRep.AssignPlayerBackToRegistrar(Guid.Parse(id)))
                    ViewData["Message"] = player.FirstName + ", " + player.LastName + " has been assigned back to registrar.";
                else
                    ViewData["Message"] = "There was an error processing your request. Please contact your administrator";
            }
            catch (Exception e)
            {
                ViewData["Message"] = "There was an error processing your request. Please contact your administrator";
            }
            player = null;
            return View(player);
        }

        [Authorize(Roles = "Manage Teams")]
        [HttpPost]
        public ActionResult ChangeTeam(Guid Teams, Guid PlayerID)
        {

            CoachAccessRepository coachRep = new CoachAccessRepository();
            UserAccessRepository userRep = new UserAccessRepository();
            string currentUserName = System.Web.HttpContext.Current.User.Identity.Name;

            Guid coachID = userRep.GetPersonID(currentUserName);

            Guid ExistingTeamID = coachRep.GetTeamID(PlayerID);

            if (coachRep.ChangeTeam(PlayerID, Teams))
            {
                ViewData["Message"] = "Player's team updated succesfully!";
            }
            else
            {
                ViewData["Message"] = "There was an error updating player's team. Please contact your administrator.";
            }


            return View("ChangeTeam",null);
        }

        [Authorize(Roles = "Manage Teams")]
        public ActionResult ChangeTeam(Guid id)//id = PlayerID
        {
            CoachChangeTeamView CoachChangeTeamView = new Models.ViewModels.CoachChangeTeamView();
            CoachAccessRepository coachRep = new CoachAccessRepository();
            UserAccessRepository userRep = new UserAccessRepository();
            string currentUserName = System.Web.HttpContext.Current.User.Identity.Name;

            Guid coachID = userRep.GetPersonID(currentUserName);

            Person player = userRep.GetPerson(id);

            CoachChangeTeamView.PlayerName = player.FirstName + ", " + player.LastName;
            CoachChangeTeamView.PlayerID = id;

            List<Team> teams = coachRep.GetTeams(coachID);

            CoachChangeTeamView.ExistingTeamID = coachRep.GetTeamID(id);
            

            CoachChangeTeamView.Teams = new List<SelectListItem>();
            foreach (Team team in teams)
            {
                CoachChangeTeamView.Teams.Add(new SelectListItem { Text = team.Category + "-" + team.Name, Value = team.Id.ToString() });
            }

            return View(CoachChangeTeamView);
        }

        [Authorize(Roles = "Manage Teams")]
        [HttpPost]
        public ActionResult AssignTeam(Guid PlayerID, Guid Teams)
        {
            CoachAssignTeamView CoachAssignTeamView = null;
            UserAccessRepository userRep = new UserAccessRepository();
            CoachAccessRepository coachRep = new CoachAccessRepository();
            string currentUserName = System.Web.HttpContext.Current.User.Identity.Name;

            Guid coachID = userRep.GetPersonID(currentUserName);

            if (coachRep.AssignPlayerToTeam(PlayerID, Teams, coachID))
            {
                ViewData["Message"] = "Player has been assigned to a team!";
            }
            else {
                ViewData["Message"] = "There was an error assigning player to a team. Please contact your administrator.";
            }


            return View(CoachAssignTeamView);
        }

        [Authorize(Roles = "Manage Teams")]
        public ActionResult AssignTeam(Guid id) //PlayerID
        {
            CoachAssignTeamView CoachAssignTeamView = new Models.ViewModels.CoachAssignTeamView();
            CoachAccessRepository coachRep = new CoachAccessRepository();
            UserAccessRepository userRep = new UserAccessRepository();
            string currentUserName = System.Web.HttpContext.Current.User.Identity.Name;

            Guid coachID = userRep.GetPersonID(currentUserName);

            Person player = userRep.GetPerson(id);
           
            CoachAssignTeamView.PlayerName = player.FirstName + ", " + player.LastName;
            CoachAssignTeamView.PlayerID = id;
            
            List<Team> teams = coachRep.GetTeams(coachID);

            CoachAssignTeamView.Teams = new List<SelectListItem>();
            foreach (Team team in teams)
            {
                CoachAssignTeamView.Teams.Add(new SelectListItem { Text = team.Category + " - " + team.Name, Value = team.Id.ToString() });
            }

            return View(CoachAssignTeamView);
        }

        [Authorize(Roles = "Manage Teams")]
        public ActionResult ManageTeams(string message)
        {
            CoachAccessRepository coachRep = new CoachAccessRepository();
            UserAccessRepository userRep = new UserAccessRepository();
            CoachManageTeamsView CoachManageTeamsView = new CoachManageTeamsView();
            string currentUserName = System.Web.HttpContext.Current.User.Identity.Name;

            Guid personID = userRep.GetPersonID(currentUserName);

            CoachManageTeamsView.UnassignedPlayers = coachRep.GetUnassignedPlayers(personID);
            List<Team> teams = coachRep.GetTeams(personID);

            CoachManageTeamsView.CurrentTeams = new List<SelectListItem>();

            foreach (Team team in teams)
            {
                CoachManageTeamsView.CurrentTeams.Add(new SelectListItem { Text = team.Category + " - " + team.Name, Value = team.Id.ToString() });
            }

            if (message != null)
                ViewData["Message"] = message;


            return View(CoachManageTeamsView);
        }

        [Authorize(Roles = "Manage Teams")]
        [HttpPost]
        public ActionResult ManageTeams(Team NewTeam)
        {
            CoachAccessRepository coachRep = new CoachAccessRepository();
            UserAccessRepository userRep = new UserAccessRepository();

            string currentUserName = System.Web.HttpContext.Current.User.Identity.Name;

            NewTeam.CoachID = userRep.GetPersonID(currentUserName);

            if (coachRep.CreateTeam(NewTeam))
            {

                return RedirectToAction("ManageTeams", "Coach", new { message = "Team created successfully!" });
            }
            else
            {
                return RedirectToAction("ManageTeams", "Coach", new { message = "There was an error creating team. Please contact your administrator." });
            }
        }

        [Authorize(Roles = "Manage Teams")]
        public JsonResult TeamPlayers(Guid id) //TeamID
        {
            CoachAccessRepository rep = new CoachAccessRepository();

            List<Person> players = rep.GetTeamPlayers(id);

            return Json(players, JsonRequestBehavior.AllowGet);
        }

    }
}
