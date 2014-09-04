using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models.ViewModels;
using SMS.Views.Shared;
using SMS.Models.DomainModels;

namespace SMS.Models.ViewModels.Binders
{
    public class CoachManageTeamEventsViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ModelStateDictionary mState = bindingContext.ModelState;

            System.Collections.Specialized.NameValueCollection form = controllerContext.HttpContext.Request.Form;

            CoachManageTeamEventsView coachManageTeamsEventsView = new CoachManageTeamEventsView();

            if(form["Event.Name"] == "")
                mState.AddModelError("Name", "Name is required");

            if (form["Event.ScheduledDate"] == "")
                mState.AddModelError("ScheduledDate", "Scheduled date is required");

            if (form["Event.Description"] == "")
                mState.AddModelError("Description", "Description is required");

            if (form["Event.Location"] == "")
                mState.AddModelError("Location", "Location is required");

            if (form["HasSelectedTeam"] != null)
                coachManageTeamsEventsView.HasSelectedTeam = bool.Parse(form["HasSelectedTeam"]);

            if (coachManageTeamsEventsView.HasSelectedTeam == false)
            {
                mState.AddModelError("HasSelectedTeam", "Please select at least one available team.");
            }

            if (mState.Count == 0)
            {
                coachManageTeamsEventsView.Event = new Event(Guid.NewGuid());
                coachManageTeamsEventsView.Event.Name = form["Event.Name"];
                coachManageTeamsEventsView.Event.Location = form["Event.Location"];
                coachManageTeamsEventsView.Event.ScheduledDate = DateTime.Parse(form["Event.ScheduledDate"]);
                coachManageTeamsEventsView.Event.Description = form["Event.Description"];
                coachManageTeamsEventsView.SendEmailToPlayers = form["SendEmailToPlayers"].ToString().Equals("false") ? false : true;
                
                
                if (form.AllKeys.Length > 5)
                {
                    coachManageTeamsEventsView.TeamsToNotify = new List<CheckBoxListInfo>();

                    for (int i = 3; i < form.AllKeys.Length - 3; i++)
                    {
                        if (form.AllKeys[i].Substring(0, form.AllKeys[i].IndexOf('[')).Contains("Teams"))
                        {
                            CheckBoxListInfo chk = new CheckBoxListInfo();
                            chk.Value = form[form.AllKeys[i]];

                            coachManageTeamsEventsView.TeamsToNotify.Add(chk);
                        }
                    }

                }
            }

            return coachManageTeamsEventsView;
        }
    }
}