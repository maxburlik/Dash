<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.CoachChangeTeamView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Teams"); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <%} %>
    <div id="pageContent">
        
        <% using (Html.BeginForm())
           {
               if (Model != null)
               {%>
               <h1>
            Change Team</h1>
        <%: Html.ValidationSummary(true)%>
        <br />
        <%: Html.HiddenFor(m => Model.PlayerID)%>
        Player:
        <%: Model.PlayerName%><br />
        Select:<%: Html.DropDownListFor(m => m.Teams, Model.Teams)%>
        <%: Html.HiddenFor(m => m.ExistingTeamID, Model.ExistingTeamID)%>
        <br />
        <br />
        <p>
            <input type="submit" value="Update" />
        </p>
        <% }
           } %>
        <%: Html.ActionLink("<< Go Back", "ManageTeams") %>


    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
         <script type="text/javascript">
             $(function () {
                 $('#Teams').val($('#ExistingTeamID').attr("value")); //Set selected role based on hidden input UserAccount.Role.ID
             });
            </script>
</asp:Content>
