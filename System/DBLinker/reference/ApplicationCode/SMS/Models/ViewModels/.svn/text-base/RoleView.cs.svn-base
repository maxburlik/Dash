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
    public class RoleView
    {
        [Required(ErrorMessage="Please type in role name.",AllowEmptyStrings=false)]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<CheckBoxListInfo> AvailableFunctions { get; set; }

        [BoolType(true,ErrorMessage="Please select at least one available function.")]
        public bool HasAvailableFunctions { get; set; }

        public List<Role> Roles { get; set; }

    }
}