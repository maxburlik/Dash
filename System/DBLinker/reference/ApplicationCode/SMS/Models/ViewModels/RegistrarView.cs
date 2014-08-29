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
    public class RegistrarManageNewPlayerView
    {
        public RegistrarManageNewPlayerView(){}
        public List<SelectListItem> Coaches { get; set; }
        public PlayerApplication Player {get; set;}
    }

    public class RegistrarManageNewPlayersView
    {
        public RegistrarManageNewPlayersView() { }
        public RegistrarManageNewPlayersView(Guid PlayerApplicationID) { }
      // public PlayerApplication Player { get; set; }
        public List<PlayerApplication> Players { get; set; }
    }


    public class RegistrarManageNewOrganizationsView
    {
        public RegistrarManageNewOrganizationsView() { }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please type in your authorization code.")]
        public string AuthorizationCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please type in your organization code.")]
        public string OrganizationName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please type in your user name.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please type in your password.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please type your password again.")]
        public string ConfirmPassword { get; set; }
    }
}