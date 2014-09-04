using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models.ViewModels;
using SMS.Models.DomainModels;
using SMS.Models.DBModels;
using SMS.Views.Shared;
using System.Diagnostics;


namespace SMS.Controllers
{
    public class RegistrarController : Controller
    {
        //
        // GET: /Registrar/
        //    [Authorize(Roles = "Manage Players")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Registrar/ManagePlayerApplication/id/
        [Authorize(Roles = "Manage Players Registration")]
        [HttpGet]
        public ActionResult ManagePlayerApplication(RegistrarManageNewPlayerView Player, Guid id)
        {

            RegistrarAccessRepository rep = new RegistrarAccessRepository();
            Player.Player = rep.GetPlayer(id);
            List<Person> coaches = rep.GetAllCoaches();
            Player.Coaches = new List<SelectListItem>();
            if (coaches.Count > 0)
                foreach (Person coach in coaches)
                {
                    Player.Coaches.Add(new SelectListItem { Text = coach.FirstName + " " + coach.LastName, Value = coach.ID.ToString() });
                }
            if (Player.Player.Coach == null)
            {
                Player.Player.Coach= new Person();
                Player.Player.Coach.ID = Guid.Empty;
            }
            return View("ManagePlayerApplication", Player);
        }


        //
        // POST: /Registrar/ManagePlayerApplication/
        [Authorize(Roles = "Manage Players Registration")]
        [HttpPost]
        public ActionResult ManagePlayerApplication(PlayerApplication Player, string Coaches, Guid id)//id = PlayerApplicationID
        {
            RegistrarAccessRepository rep = new RegistrarAccessRepository();
            try
            {
                Player.ID = id;
                bool isUpdated = rep.UpdatePlayer(Player, Coaches);

                if (isUpdated)
                    ViewData["Message"] = "Player application updated successfully!";
                else
                    ViewData["Message"] = "There was an error updating this player application. Please contact your administrator!";

                return View("ManagePlayerApplication", null);
            }
            catch (Exception e)
            {
            }
            return View("ManagePlayerApplication");
        }

        [Authorize(Roles = "Manage Players Registration")]
        [HttpGet]
        public ActionResult DeactivatePlayer(string id)//id = PlayerApplicationID
        {

            PlayerApplication player = new PlayerApplication(Guid.Parse(id));
            return View("DeactivatePlayer",player);
        }

        // POST: /Registrar/ManagePlayerApplication/
        [Authorize(Roles = "Manage Players Registration")]
        [HttpPost]
        public ActionResult DeactivatePlayer(Guid id)//id = PlayerApplicationID
        {
            RegistrarAccessRepository rep = new RegistrarAccessRepository();
            try
            {
                bool isDeactivated = rep.DeactivatePlayer(id);

                if (isDeactivated)
                    ViewData["Message"] = "Player is deactivated successfully!";
                else
                    ViewData["Message"] = "There was an error deactivating this player application. Please contact your administrator!";

                return View("DeactivatePlayer", null);
            }
            catch (Exception e)
            {
            }
            return View("ManagePlayerApplication");
        }

        // GET: /Registrar/ManagePlayerApplications/
        [Authorize(Roles = "Manage Players Registration")]
        [HttpGet]
        public ActionResult ManagePlayerApplications()
        {
            RegistrarAccessRepository rep = new RegistrarAccessRepository();
            RegistrarManageNewPlayersView players = new RegistrarManageNewPlayersView();
            players.Players = rep.GetAllPlayers();
            return View("ManagePlayerApplications", players);
        }

        [Authorize(Roles = "Manage Organizations Registration")]
        [HttpGet]
        public ActionResult ManageOrganizationsRegistration()
        {

            return View();
        }

        [Authorize(Roles = "Manage Organizations Registration")]
        [HttpPost]
        public ActionResult GenerateAuthorizationCode()
        {
            RegistrarAccessRepository rep = new RegistrarAccessRepository();

            Guid code = Guid.NewGuid();

            if (rep.CreateAuthorizationCode(code))
            {
                ViewData["Message"] = code.ToString().Split('-')[4].ToString();
            }
            else
            {
                ViewData["Message"] = "There was a problem generating authorization code. Please contact your administrator.";
            }

            RedirectToAction("ManageOrganizationsRegistration");

            return View("ManageOrganizationsRegistration");
        }
    }
}
