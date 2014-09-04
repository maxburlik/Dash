<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.ThirdPartyTeamApplicationInfoView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <% Html.RenderPartial("UserNavigation", "Manage Team Applications"); %>
  <div id="pageContent">
    <h1>Delete Team Application</h1>
    <br />
    <div class="display-label">Team Name</div>
    <div class="display-field"><fieldset style="width:200px; padding:2px; margin:1px"><%: Model.TeamApplication.TeamName %></fieldset></div>
        
    <div class="display-label">Category</div>
    <div class="display-field"><fieldset style="width:200px; padding:2px; margin:1px"><%: Model.TeamApplication.Category %></fieldset></div>

    <div class="display-label">Coach Name</div>
    <div class="display-field"><fieldset style="width:200px; padding:2px; margin:1px"><%: Model.TeamApplication.CoachName %></fieldset></div>

    <div class="display-label">Status</div>
    <div class="display-field">
        <fieldset style="width:200px; padding:2px; margin:1px">
        <% if (Model.TeamApplication.Status == 0)
            { %>
            <span style="color:Gray">Created</span>
        <% }
            else if (Model.TeamApplication.Status == 1)
            { %>
            <span style="color:#00CCCC">Submitted</span>
        <% }
            else if (Model.TeamApplication.Status == 2)
            { %>
            <span style="color:Green">Approved</span>
        <% }
            else if (Model.TeamApplication.Status == 3)
            { %>
            <span style="color:Orange">Not Approved</span>
        <% } %>
        </fieldset>
    </div>
    <h3>Are you sure you want to delete this?</h3>
    <% using (Html.BeginForm()) 
        { %>
        <%: Html.HiddenFor(m => m.ApplicationID) %>
        <%: Html.HiddenFor(m => m.TournamentID) %>
        <p>
		    <input type="submit" value="Delete Listing" />
        </p>
        <br />
    <% } %>
    <div>
        <%: Html.ActionLink("<< Back to List", "ManageTeamApplications", new { TournamentID = Model.TournamentID, message = "" })%>
    </div>
  </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

