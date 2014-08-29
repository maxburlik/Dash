using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models.DomainModels;
using SMS.Models.DBModels;
using SMS.Models.ViewModels;
using System.Web.Security;
using System.Configuration;
using SMS.Models.ViewModels.Validators;
using System.Net.Mail;

namespace SMS.Controllers
{
    public class UserAccountController : Controller
    {
        //
        // GET: /User/
        
        public ActionResult Logon()
        {
            if(System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/UserAccount/Home");

       
            return View();
        }

        [Authorize(Roles = "Manage Users")]
        [HttpPost]
        public ActionResult Delete(object id)
        {
            UserAccessRepository rep = new UserAccessRepository();

            UserAccount userAcc = rep.GetUserAccount((string)id);

            if (userAcc != null)
            {
                if (rep.DeleteUser(userAcc.Username))
                {
                    if (Membership.DeleteUser(userAcc.Username))
                    {
                        ViewData["Message"] = "User account deleted successfully!";
                        userAcc = null;
                    }

                    else
                    {
                        ViewData["Message"] = "There was an error deleting user account. Please contact your administrator";
                        userAcc = null;
                    }
                }

                return View(userAcc);
            }
            else
            {
                ViewData["Message"] = "User could not be found!";
            }


            return View(userAcc);
        }

        [Authorize(Roles = "Manage Users")]
        public ActionResult Delete(string id)
        {
            UserAccessRepository rep = new UserAccessRepository();
            
            UserAccount userAcc = rep.GetUserAccount(id);

            if (userAcc != null)
            {
                return View(userAcc);
            }
            else
            {
                ViewData["Message"] = "User could not be found!";
            }


            return View(userAcc);
        }

        [Authorize(Roles = "Manage Users")]
        public ActionResult ChangePassword(string id)
        {
            ChangePasswordView ChangePasswordView = new ChangePasswordView();
            ChangePasswordView.Username = id;

            return View(ChangePasswordView);
        }


        [HttpPost]
        [Authorize(Roles = "Manage Users")]
        public ActionResult ChangePassword(ChangePasswordView ChangePasswordView)
        {
            MembershipUser user = Membership.GetUser(ChangePasswordView.Username);
            if (ModelState.IsValid)
            {

                if (user.ChangePassword(user.ResetPassword(), ChangePasswordView.Password))
                {
                    ViewData["Message"] = "Password changed successfully!";
                    ChangePasswordView = null;
                }
                else
                    ViewData["Message"] = "There was an error chaning user's password. Please contact your administrator.";

            }
            return View(ChangePasswordView);
        }

        [HttpPost]
        public ActionResult Logon(LogonView LogonView)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(LogonView.Username, LogonView.Password))
                {
                    FormsAuthentication.SetAuthCookie(LogonView.Username, true);
                    Response.Redirect("~/UserAccount/Home");
                }
                else
                {
                    ViewData["Message"] = "Invalid username and/or password. Please contact your administrator.";
                }

            }

            return View();
        }

        [ValidateOnlyIncomingValuesAttribute]
        [Authorize(Roles = "Manage Users")]
        [HttpPost]
        public ActionResult Edit(UserAccountView UserAccountView, Guid Roles)
        {
            
            UserAccessRepository rep = new UserAccessRepository();

            List<Role> roles = rep.GetAllRoles();
            UserAccountView.Roles = new List<SelectListItem>();
            UserAccountView.UserAccount.Role = rep.GetRole(Roles);

            ModelState.Remove("Roles"); //We remove any model state error on Roles because we manually load it from the database as drop-down list only returns the selected role 
                        
            foreach (Role role in roles)
            {
                UserAccountView.Roles.Add(new SelectListItem { Text = role.RoleName, Value = role.ID.ToString() });
            }
            
            if (ModelState.IsValid)
            {
                if (UserAccountView.UserAccount != null)
                {
                    

                    ////////////////////
                    MembershipUser user = Membership.GetUser(UserAccountView.UserAccount.Username);

                    UserAccount existingAccount = rep.GetUserAccount(UserAccountView.UserAccount.Username);

                    foreach (AvailableFunction func in existingAccount.Role.AvailableFunctions)
                    {
                        System.Web.Security.Roles.RemoveUserFromRole(existingAccount.Username, func.FunctionName);

                    }

                    foreach (var func in UserAccountView.UserAccount.Role.AvailableFunctions)
                    {
                        System.Web.Security.Roles.AddUserToRole(UserAccountView.UserAccount.Username, func.FunctionName);
                    }

                    
                    ////////////////////
                    bool status = rep.UpdateUserAccount(UserAccountView.UserAccount);

                    if (status)
                        ViewData["Message"] = "User updated successfully!";
                    else
                        ViewData["Message"] = "There was an error updating this user. Please contact your administrator!";

                    return View("Edit", null);
                }
                else
                {
                    ViewData["Message"] = "User could not be found!";
                }

            }
            
            return View(UserAccountView);

        }
        
        [Authorize(Roles = "Manage Users")]
        public ActionResult Edit(string id)
        {
            UserAccessRepository rep = new UserAccessRepository();
            UserAccountView userAccView = new UserAccountView();
            
            userAccView.UserAccount = rep.GetUserAccount(id);

            List<Role> roles = rep.GetAllRoles();
            userAccView.Roles = new List<SelectListItem>();

            foreach (Role role in roles)
            {
                userAccView.Roles.Add(new SelectListItem { Text = role.RoleName, Value = role.ID.ToString() });
            }


            if (userAccView.UserAccount != null)
            {
                View("Edit", userAccView);
            }
            else
            {
                ViewData["Message"] = "User could not be found!";
            }
            
            return View("Edit",userAccView);
        }

        [Authorize(Roles = "Manage Users")]
        [HttpGet]
        public ActionResult Create(string message)
        {
            UserAccessRepository rep = new UserAccessRepository();
            UserAccountView userAccView = new UserAccountView();
            
            List<Role> roles = rep.GetAllRoles();
            userAccView.Roles = new List<SelectListItem>();
            userAccView.ExistingUserAccounts = rep.GetUserAccounts();

            foreach (Role role in roles)
            {
                userAccView.Roles.Add(new SelectListItem { Text = role.RoleName, Value = role.ID.ToString() });
            }

            if (message != null)
                ViewData["Message"] = message;

            return View(userAccView);
        }

        [Authorize(Roles="Manage Users")]
        [HttpPost]
        public ActionResult Create(UserAccount UserAccount, Guid Roles)
        {
            UserAccessRepository rep = new UserAccessRepository();
            
            if (ModelState.IsValid)
            {
                
                UserAccount.Role = rep.GetRole(Roles);
                UserAccount.Person.Address.Country = "Canada";
                UserAccount.Person.Organization = new Organization(Guid.Parse(ConfigurationManager.AppSettings["HostingOrganizationID"].ToString()));

                MembershipCreateStatus createStatus;
                MembershipUser newUser = Membership.CreateUser(UserAccount.Username, UserAccount.Password, UserAccount.Person.Email, "Q", "P", true, out createStatus);
                UserAccount.Person.Type = PersonType.Employee;

                switch (createStatus)
                {
                    case MembershipCreateStatus.DuplicateUserName:
                        ViewData["Message"] = "Duplicate username! This username already exists in the system.";

                        break;
                    case MembershipCreateStatus.InvalidPassword:
                        ViewData["Message"] = "Invalid password! Minimum password length is six characters.";

                        break;
                    case MembershipCreateStatus.Success:
                        foreach (AvailableFunction func in UserAccount.Role.AvailableFunctions)
                        {
                            System.Web.Security.Roles.AddUserToRole(UserAccount.Username, func.FunctionName);

                        }

                        if (rep.CreateUserAccount(UserAccount))
                        {
                            ViewData["Message"] = "User account created succesfully!";
                            UserAccount = null;
                            ModelState.Clear(); //Will clear out the form

                            return RedirectToAction("Create", "UserAccount", new { message = "User account created succesfully!" });
                        }
                        else
                            ViewData["Message"] = "There was an error creating this user. Please contact your administrator.";

                        break;
                    default:
                        ViewData["Message"] = "There was an error creating this user. Please contact your administrator.";
                        break;
                }


            }

            UserAccountView userAccView = new UserAccountView();

            List<Role> roles = rep.GetAllRoles();
            userAccView.Roles = new List<SelectListItem>();

            foreach (Role role in roles)
            {
                userAccView.Roles.Add(new SelectListItem { Text = role.RoleName, Value = role.ID.ToString() });
            }

            userAccView.ExistingUserAccounts = rep.GetUserAccounts();
            userAccView.UserAccount = UserAccount;

            return View("Create",userAccView);
        }

        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult LogOff()
        {

            FormsAuthentication.SignOut();

            Response.Redirect("~/UserAccount/Logon");

            return View("Logon");
        }

    }
}
