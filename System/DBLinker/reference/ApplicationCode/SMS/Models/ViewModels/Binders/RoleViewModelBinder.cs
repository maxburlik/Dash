using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models.ViewModels;
using SMS.Views.Shared;

namespace SMS.Models.ViewModels.Binders
{
    public class RoleViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ModelStateDictionary mState = bindingContext.ModelState;
            
            System.Collections.Specialized.NameValueCollection form = controllerContext.HttpContext.Request.Form;

            RoleView roleViewModel = new RoleView();

            roleViewModel.Name = form["Name"];

            if(form["HasAvailableFunctions"] != null)
                roleViewModel.HasAvailableFunctions = bool.Parse(form["HasAvailableFunctions"]);

            if (roleViewModel.HasAvailableFunctions == false)
            {
                mState.AddModelError("HasAvailableFunctions", "Please select at least one available function.");
            }

            if (roleViewModel.AvailableFunctions == null)
                roleViewModel.AvailableFunctions = new List<CheckBoxListInfo>();

            if (form.AllKeys.Length > 2)
            {
                for (int i = 2; i < form.AllKeys.Length; i++)
                {
                    if (form.AllKeys[i].Substring(0, form.AllKeys[i].IndexOf('[')).Contains("AvailableFunctions"))
                    {
                        CheckBoxListInfo chk = new CheckBoxListInfo();
                        chk.Value = form[form.AllKeys[i]];

                        

                        roleViewModel.AvailableFunctions.Add(chk);
                    }
                }

            }

            
            return roleViewModel;
        }
    }
}