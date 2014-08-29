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
    public class TournamentPlanningMatchViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ModelStateDictionary mState = bindingContext.ModelState;
            
            System.Collections.Specialized.NameValueCollection form = controllerContext.HttpContext.Request.Form;
            
            Guid MatchID = Guid.Parse(controllerContext.RouteData.Values["id"].ToString());
            Match match = null;

            if (MatchID != Guid.Empty)
            {
                match = new Match(MatchID);

                for (int i = 0; i < form.AllKeys.Length; i++)
                {
                    if (form.AllKeys[i].EndsWith("TeamApplicationOne.ApplicationID"))
                    {
                        match.TeamApplicationOne = new TeamApplication(Guid.Parse(form[i].ToString()));
                    }
                    if (form.AllKeys[i].EndsWith("TeamApplicationTwo.ApplicationID"))
                    {
                        match.TeamApplicationTwo = new TeamApplication(Guid.Parse(form[i].ToString()));
                    }
                    if (form.AllKeys[i].EndsWith("ScoreOne"))
                    {
                        match.ScoreOne = (form[i].ToString().Trim() != "" && form[i].ToString().Trim() != "N/A") ? form[i].ToString() : "-1";
                    }
                    if (form.AllKeys[i].EndsWith("ScoreTwo"))
                    {
                        match.ScoreTwo = (form[i].ToString().Trim() != "" && form[i].ToString().Trim() != "N/A") ? form[i].ToString() : "-1";
                    }
                    if (form.AllKeys[i].EndsWith("Location"))
                    {
                        match.Location = form[i].ToString();
                    }
                    if (form.AllKeys[i].EndsWith("Duration"))
                    {
                        match.Duration = Int32.Parse(form[i].ToString());
                    }
                    if (form.AllKeys[i].EndsWith("ScheduledDate"))
                    {
                        match.ScheduledDate = DateTime.Parse(form[i].ToString());
                    }
                    if (form.AllKeys[i].EndsWith("Tournament.TournamentID"))
                    {
                        match.Tournament = new Tournament(Guid.Parse(form[i].ToString()));
                    }
                }
            }

            return match;
        }
    }
}
