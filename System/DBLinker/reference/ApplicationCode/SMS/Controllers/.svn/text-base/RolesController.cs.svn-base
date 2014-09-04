using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models.ViewModels;
using SMS.Models.ViewModels.Binders;
using SMS.Models.DomainModels;
using SMS.Models.DBModels;
using SMS.Views.Shared;

namespace SMS.Controllers
{
    public class RolesController : Controller
    {
        //
        // GET: /Roles/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Roles/Details/5
        [Authorize(Roles = "Manage Roles")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Roles/Create
        [Authorize(Roles = "Manage Roles")]
        [HttpGet]
        public ActionResult Create(string message)
        {
            RoleView roleView = new RoleView();
            UserAccessRepository rep = new UserAccessRepository();
            

            roleView.AvailableFunctions = new List<CheckBoxListInfo>();
            roleView.Roles = rep.GetAllRoles();

            // Get the list of roles in the system
            List<AvailableFunction> allFunctions = rep.GetAllAvailableFunctions();

            if (allFunctions.Count > 0) //It is possible that database might not have any available functions initially
            {
                for (int i = 0; i < allFunctions.Count(); i++)
                    roleView.AvailableFunctions.Add(new CheckBoxListInfo(allFunctions.ElementAt(i).ID.ToString(), allFunctions.ElementAt(i).FunctionName, false));
            }

            if (message != null)
                ViewData["Message"] = message;

            return View("Create", roleView);
        } 

        //
        // POST: /Roles/Create
        [Authorize(Roles = "Manage Roles")]
        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(RoleViewModelBinder))]RoleView RoleView)//[ModelBinder(typeof(RoleViewModelBinder))],string[] selectedAvailableFunctions
        {
            UserAccessRepository rep = new UserAccessRepository();

            // Get the list of roles in the system
            List<AvailableFunction> allFunctions = rep.GetAllAvailableFunctions();

            RoleView.Roles = rep.GetAllRoles();



            if (ModelState.IsValid)
            {
                Role newRole = new Role(Guid.NewGuid(), RoleView.Name, RoleView.Description);
                newRole.AvailableFunctions = new List<AvailableFunction>();

                for (int i = 0; i < allFunctions.Count(); i++)
                {
                    foreach (var item in RoleView.AvailableFunctions)
                    {
                        if (Guid.Parse(item.Value).Equals(allFunctions[i].ID))
                        {
                            newRole.AvailableFunctions.Add(new AvailableFunction(Guid.Parse(allFunctions[i].ID.ToString()), allFunctions[i].FunctionName));
                        }

                    }

                }

                if (rep.CreateRole(newRole) == true)
                {
                    return RedirectToAction("Create", "Roles", new { message = "Your role '" + RoleView.Name + "' was created successfully!" });

                }
                else
                {
                    return RedirectToAction("Create", "Roles", new { message = "There was an error creating your role. Please contact your administrator." });

                }
            }

            RoleView.Roles = rep.GetAllRoles();
           
            if (RoleView.AvailableFunctions == null)
                RoleView.AvailableFunctions = new List<CheckBoxListInfo>();

            RoleView.AvailableFunctions.Clear();

            foreach (var item in allFunctions)
            {
                RoleView.AvailableFunctions.Add(new CheckBoxListInfo(item.ID.ToString(), item.FunctionName, false));

            }

            return View("Create", RoleView);
        }
       
        //
        // GET: /Roles/Delete/5
        [Authorize(Roles = "Manage Roles")]
        public ActionResult Delete(Guid id)
        {
            UserAccessRepository rep = new UserAccessRepository();

            Role role = rep.GetRole(id);

            return View(role);
        }

        //
        // POST: /Roles/Delete/ID
        [Authorize(Roles = "Manage Roles")]
        [HttpPost]
        public ActionResult Delete(string id)
        {
            UserAccessRepository rep = new UserAccessRepository();
            Guid ID = Guid.Parse(id);

            try
            {
                
                if (rep.NumberOfUsersInRole(ID) == 0)
                {
                    if (rep.DeleteRole(ID))
                        ViewData["Message"] = "Role deleted successfully!";
                    else
                        ViewData["Message"] = "There was an error deleting role. Please contact your administrator.";

                }
                else
                {
                    ViewData["Message"] = "Role couldn't be deleted because there are users under this role.";
                }

                
            }
            catch
            {
                return View();
            }

            return View();
        }
    }
}
