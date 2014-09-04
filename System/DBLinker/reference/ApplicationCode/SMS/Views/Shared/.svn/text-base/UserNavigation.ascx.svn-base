<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<div id="loggedin_user_navigation">
    <% if (HttpContext.Current.User.Identity.IsAuthenticated)
       { %>
    Current User:<%: " " + HttpContext.Current.User.Identity.Name %>
    |
    <% } %>
    

    <% if (HttpContext.Current.User.IsInRole("Manage Roles"))
       { %>
    <% if (Model.ToString().Equals("Manage Roles"))
       { %>
    <span id="currentPage">Manage Roles</span>
    <% } %>
    <% else
        { %>
    <%: Html.ActionLink("Manage Roles","Create","Roles") %>
    <%} %>
    <%} %>
    

    <% if (HttpContext.Current.User.IsInRole("Manage Users"))
       { %>
    <% if (Model.ToString().Equals("Manage Users"))
       { %>
    <span id="currentPage">Manage Users</span>
    <% } %>
    <% else
        { %>
    <%: Html.ActionLink("Manage Users","Create","UserAccount") %>
    <%} %>
    <%} %>
    

    <% if (HttpContext.Current.User.IsInRole("Manage Players Registration"))
       { %>
    <% if (Model.ToString().Equals("Manage Players Registration"))
       { %>
    <span id="currentPage">Manage Players Registration</span>
    <% } %>
    <% else
        { %>
    <%: Html.ActionLink("Manage Players Registration", "ManagePlayerApplications", "Registrar")%>
    <%} %>
    <%} %>
    
    
    <% if (HttpContext.Current.User.IsInRole("Manage Organizations Registration"))
       { %>
    <% if (Model.ToString().Equals("Manage Organizations Registration"))
       { %>
    <span id="currentPage">Manage Organizations Registration</span>
    <% } %>
    <% else
        { %>
    <%: Html.ActionLink("Manage Organizations Registration", "ManageOrganizationsRegistration", "Registrar")%>
    <%} %>
    <%} %>


        <% if (HttpContext.Current.User.IsInRole("Manage Tournament Team Applications"))
       { %>
    <% if (Model.ToString().Equals("Manage Tournament Team Applications"))
       { %>
    <span id="currentPage">Manage Tournament Team Applications</span>
    <% } %>
    <% else
        { %>
    <%: Html.ActionLink("Manage Tournament Team Applications", "ManageTeamApplications", "Tournament")%>
    <%} %>
    <%} %>
    
    
    <% if (HttpContext.Current.User.IsInRole("Tournament Planning"))
       { %>
    <% if (Model.ToString().Equals("Tournament Planning"))
       { %>
    <span id="currentPage">Tournament Match Planning</span>
    <% } %>
    <% else
        { %>
        
    <%: Html.ActionLink("Tournament Match Planning", "Planning", "Tournament")%>
    <%} %>
    <%} %>

 
    <% if (HttpContext.Current.User.IsInRole("Manage Tournaments"))
       { %>
    <% if (Model.ToString().Equals("Manage Tournaments"))
       { %>
    <span id="currentPage">Manage Tournaments</span>
    <% } %>
    <% else
        { %>
        
    <%: Html.ActionLink("Manage Tournaments", "Create", "Tournament")%>
    <%} %>
    <%} %>

 
    <% if (HttpContext.Current.User.IsInRole("Manage Team Events"))
       { %>
    <% if (Model.ToString().Equals("Manage Team Events"))
       { %>
    <span id="currentPage">Manage Team Events</span>
    <% } %>
    <% else
        { %>
    <%: Html.ActionLink("Manage Team Events", "ManageTeamEvents", "Coach")%>
    <%} %>
    <%} %>
    

    <% if (HttpContext.Current.User.IsInRole("Manage Teams"))
       { %>
    <% if (Model.ToString().Equals("Manage Teams"))
       { %>
    <span id="currentPage">Manage Teams</span>
    <% } %>
    <% else
        { %>
    <%: Html.ActionLink("Manage Teams", "ManageTeams", "Coach")%>
    <%} %>
    <%} %>
    
    <% if (HttpContext.Current.User.IsInRole("Submit Third Party Team Applications"))
       { %>
  
    <% if (Model.ToString().Equals("Manage Team Applications")) { %>
        <span id="currentPage">Manage Team Applications</span>
    <%} %>
      <% else
       { %>
    <%: Html.ActionLink("Manage Team Applications", "ManageTeamApplications", "ThirdParty", new { TournamentID = Guid.Empty, message = "" }, null)%>
    <% }%>
    <%} %>
   
    

    <% if (HttpContext.Current.User.Identity.IsAuthenticated)
       { %>
    <%: Html.ActionLink("Log Off", "LogOff", "UserAccount")%>
    <%} %>
    <% else
        { %>
    <% if (Model.ToString().Equals("Logon"))
       { %>
    <span id="currentPage">Login</span>
    <%}
       else
       { %>
    <%: Html.ActionLink("Log In", "LogOn", "UserAccount")%>
    <% }%>
    <%} %>
</div>


