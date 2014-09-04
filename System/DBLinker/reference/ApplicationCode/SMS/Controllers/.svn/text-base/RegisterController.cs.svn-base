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
using System.Net.Mail;
using SMS.Models.ViewModels.Validators;

namespace SMS.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Register/Details/5

        public ActionResult Details(int id)
        {

            return View();
        }

        //
        // GET: /Register/RegisterAPlayer

        public ActionResult NewPlayer()
        {
            RegisterNewPlayerView player = new RegisterNewPlayerView();
            return View("NewPlayer", player);
        }

        //
        // POST: /Register/Create

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult NewPlayer(PlayerApplication PlayerApplication)
        {
            try
            {
                RegisterAccessRepository rep = new RegisterAccessRepository();

                PlayerApplication.Paid = false;
                PlayerApplication.RegistrationDate = DateTime.Now;
                PlayerApplication.Payment = 0.0;

                PlayerApplication.Player.Address.Country = "Canada";
                PlayerApplication.Player.Organization = new Organization(Guid.Parse(ConfigurationManager.AppSettings["HostingOrganizationID"].ToString()));

                if (PlayerApplication.Guardian1.Address == null)
                    PlayerApplication.Guardian1.Address = PlayerApplication.Player.Address;
                else
                    PlayerApplication.Guardian1.Address.Country = "Canada";

                PlayerApplication.Guardian1.Organization = PlayerApplication.Player.Organization;

                if (PlayerApplication.Guardian2.Address == null)
                    PlayerApplication.Guardian2.Address = PlayerApplication.Player.Address;
                else
                    PlayerApplication.Guardian2.Address.Country = "Canada";


                if (PlayerApplication.Guardian1.Address.City == null)
                    PlayerApplication.Guardian1.Address.City = PlayerApplication.Player.Address.City;


                if (PlayerApplication.Guardian1.Address.StreetAddress == null)
                    PlayerApplication.Guardian1.Address.StreetAddress = PlayerApplication.Player.Address.StreetAddress;

                if (PlayerApplication.Guardian1.Address.PostalCode == null)
                    PlayerApplication.Guardian1.Address.PostalCode = PlayerApplication.Player.Address.PostalCode;

                if (PlayerApplication.Guardian2.Address.City == null)
                    PlayerApplication.Guardian2.Address.City = PlayerApplication.Player.Address.City;

                if (PlayerApplication.Guardian2.Address.StreetAddress == null)
                    PlayerApplication.Guardian2.Address.StreetAddress = PlayerApplication.Player.Address.StreetAddress;

                if (PlayerApplication.Guardian2.Address.PostalCode == null)
                    PlayerApplication.Guardian2.Address.PostalCode = PlayerApplication.Player.Address.PostalCode;

                if (PlayerApplication.MedicalAlert == null)
                    PlayerApplication.MedicalAlert = "";

                if (PlayerApplication.PreviousTeam == null)
                    PlayerApplication.PreviousTeam = "";

                PlayerApplication.Guardian2.Organization = PlayerApplication.Player.Organization;

                Guid playerApplicationID = rep.CreatePlayerApplication(PlayerApplication);
                if (playerApplicationID != Guid.Empty)
                {
                    MailMessage message = new MailMessage();

                    message.To.Add(new MailAddress(PlayerApplication.Player.Email));
                    message.Subject = "PhoenixFC - Application Recieved!";
                    message.Body = "Dear Player: We have recieved your application. Someone from PhoenixFC will contact you regarding your next steps. Please do not reply to this email. Thank you.";

                    SmtpClient client = new SmtpClient();

                    client.Send(message);

                    ViewData["Message"] = "Thank you. Your application has been submitted. An email has been sent your email account.";
                    return RedirectToAction("All","Teams",new { message = ViewData["Message"] });
                }
            }
            catch (Exception e)
            {
                if (e is System.Net.Mail.SmtpException)
                {
                    ViewData["Message"] = "Your application has been submitted. However, there was an error sending confirmation email. Please contact PhoenixFC at your convenience to confirm your application submission.";
                }
                else
                    ViewData["Message"] = "There was an error processing your request. Please contact administrator.";

                return RedirectToAction("All", "Teams", new { message = ViewData["Message"] });
   
            }

            return View();
        }

        public ActionResult NewOrganization()
        {
            RegisterNewOrganizationView org = new RegisterNewOrganizationView();
            return View("NewOrganization", org);
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Register/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Register/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Register/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        [HttpPost]
        public ActionResult NewOrganization(RegisterNewOrganizationView RegisterNewOrganizationView)
        {
                RegisterAccessRepository repp = new RegisterAccessRepository();
                bool status = repp.IsValidAuthorizationCode(RegisterNewOrganizationView.AuthorizationCode);
                if (status == true)
                {
                    UserAccessRepository rep = new UserAccessRepository();

                    RegisterNewOrganizationView.UserAccount.Role = rep.GetRole(Guid.Parse("794C2858-17DB-462C-AB13-065B8F6719BF"));
                    //RegisterNewOrganizationView.UserAccount.Person.Organization.Id = Guid.NewGuid();
                    RegisterNewOrganizationView.UserAccount.Person.Organization.Address.Country = "Canada";
                    RegisterNewOrganizationView.UserAccount.Person.Address = RegisterNewOrganizationView.UserAccount.Person.Organization.Address;
                   // RegisterNewOrganizationView.UserAccount.Person.Organization.Url = "";
                    
                    if (repp.CreateOrganizationAccount(RegisterNewOrganizationView.UserAccount))
                    {


                        MembershipCreateStatus createStatus;
                        MembershipUser newUser = Membership.CreateUser(RegisterNewOrganizationView.UserAccount.Username, RegisterNewOrganizationView.UserAccount.Password, RegisterNewOrganizationView.UserAccount.Person.Email, "Q", "P", true, out createStatus);
                        RegisterNewOrganizationView.UserAccount.Person.Type = PersonType.ThirdParty;

                        switch (createStatus)
                        {
                            case MembershipCreateStatus.DuplicateUserName:
                                ViewData["Message"] = "Duplicate username! This username already exists in the system.";

                                break;
                            case MembershipCreateStatus.InvalidPassword:
                                ViewData["Message"] = "Invalid password! Minimum password length is six characters.";

                                break;
                            case MembershipCreateStatus.Success:
                                foreach (AvailableFunction func in RegisterNewOrganizationView.UserAccount.Role.AvailableFunctions)
                                {
                                    System.Web.Security.Roles.AddUserToRole(RegisterNewOrganizationView.UserAccount.Username, func.FunctionName);

                                }

                                ViewData["Message"] = "Organization created succesfully!";
                                RegisterNewOrganizationView.UserAccount = null;
                                repp.DeleteAuthorizationCode(RegisterNewOrganizationView.AuthorizationCode); 
                                ModelState.Clear(); //Will clear out the form  
                                RegisterNewOrganizationView = null;
                                break;
                            default:
                                ViewData["Message"] = "There was an error creating this organization. Please contact the administrator.";
                                break;
                        }
                        
                    }
                    else
                        ViewData["Message"] = "There was an error creating this organization. Please contact the administrator.";
                }


                else
                {
                    ViewData["Message"] = "Authorization Code Is Invalid.Please try again or contact administrator.";
                }
            

            
        

            return View("NewOrganization", RegisterNewOrganizationView);
        }
    }
}          
                
            

  

