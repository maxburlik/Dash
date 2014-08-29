<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.ThirdPartyManageExistingApplicationsView>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <link media="screen" rel="stylesheet" href="<%: Url.Content("~/Scripts/jqueryui/css/colorbox.css") %>" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery.colorbox-min.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("a[id^=show_app_TeamApplication_Message_]").click(function () {
                var target_div =  $(this).attr("id").split("_")[4];
                var title_id = "#app_TeamApplication_TeamName_" + target_div;
                var title = $(title_id).text();
                $("#" + $(this).attr("id")).colorbox({ title: title, width: "25%", inline: true, href: "#app_TeamApplication_Message_" + target_div });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Team Applications"); %>
    <div id="pageContent">
        <% if (Model.message != "" && Model.message != null)
           { %>
               <p id="StatusMessage" style="text-align:center; margin-top:0px; margin-bottom:5px;"><%: Model.message %></p>
        <% } %>
        <table>
            <tr>
                <td style="width:21%; vertical-align:text-top;">
        
                    <% if (Model != null)
                       {
                           using (Html.BeginForm())
                           { %>
                               <%: Html.ValidationSummary(true) %>
                               <%: Html.DropDownListFor(m => m.SelectedTournamentId, Model.TournamentDropList)%>
                </td>
                <td style="vertical-align:text-top;">
                               <input type="submit" value="Display" />
                        <% }
                       }%>
                </td>
                <td></td>
            </tr>
            <tr valign="top">
                <td style="overflow:auto; width:21%">
    <% if (Model.SelectedTournament != null)
       { %>
                           <h3><span style="font-weight: bold;"> <%: Model.SelectedTournament.TournamentName%> </span></h3><br />
                           
                           <span style="font-weight: bold;">Registration: </span><br />
                            <%: Model.SelectedTournament.RegistrationStartDate%> to 
                            <%: Model.SelectedTournament.RegistrationEndDate%> <br />
                            <br />
                           <span style="font-weight: bold;">Tournament: </span><br />
                            <%: Model.SelectedTournament.TournamentStartDate%> to 
                            <%: Model.SelectedTournament.TournamentEndDate%> <br />
                            <br />
                           <span style="font-weight: bold;">Location: </span><br />
                            <%: Model.SelectedTournament.Location%> <br />
                            <br />
                           <span style="font-weight: bold;">Description: </span><br />
                            <%: Model.SelectedTournament.TournamentInfo%> 

                            <div>
                                <br /><br />
                                <%: Html.ActionLink("<< Back to Index", "../UserAccount/Home")%>
                            </div>
                </td>
                <td style="width:51%">
                            
           <% if (Model.TeamApplications.Count > 0)
              { %>       
                            <table style="width:100%;">
                                <tr style="text-align:left">
                                    <th style="border-bottom: 1px solid gainsboro; font-size:10; width:21%">Team Name</th>
                                    <th style="border-bottom: 1px solid gainsboro; font-size:10; width:15%">Category</th>
                                    <th style="border-bottom: 1px solid gainsboro; font-size:10; width:17%">Coach</th>
                                    <th style="border-bottom: 1px solid gainsboro; font-size:10; width:14%">Submit Teams</th>
                                    <th style="border-bottom: 1px solid gainsboro; font-size:10; width:15%">Status</th>
                                    <th style="border-bottom: 1px solid gainsboro; font-size:10; width:17%"> </th>
                                </tr>
                            </table>
            
                        <% using (Html.BeginForm("SubmitTeamApplications","ThirdParty"))
                           {
                               int counter = 0; %>
                           <div style="height:180px; overflow:auto; width:100%">
                            <%: Html.ValidationSummary(true) %>
                            <table style="text-align:left; width:100%"> <!--start teams table-->
                            <% foreach (SMS.Models.ViewModels.ThirdPartyTeamApplicationView app in Model.TeamApplications)
                               {
                                   %>
                                <tr>
                                    <td id="app_TeamApplication_TeamName_<%: app.TeamApplication.ApplicationID %>" style="font-size:10; width:21%">
                                        <%: app.TeamApplication.TeamName%>
                                    </td>
                                    <td style="font-size:10; width:15%">
                                        <%: app.TeamApplication.Category%>
                                    </td>
                                    <td style="font-size:10; width:17%">
                                        <%: app.TeamApplication.CoachName%>
                                    </td>
                                    <td style="width:14%">
                                   <% if (app.IsChecked)
                                      {%>
                                          <input type="checkbox" disabled="disabled" name = "<%: "CheckedApplicationIDs" + "[" + counter + "]" %>" id = "<%: "CheckedApplicationIDs" + "[" + counter + "]" %>" value="<%: app.TeamApplication.ApplicationID  %>" />
                                   <% } %>
                                   <% else
                                      { %>
                                          <input type="checkbox" name = "<%: "CheckedApplicationIDs" + "[" + counter + "]" %>" id = "<%: "CheckedApplicationIDs" + "[" + counter + "]" %>" value="<%: app.TeamApplication.ApplicationID  %>" />
                                   <% } %>
                                    </td>
                                    <td style="font-size:10; width:15%">
                                        <% if (app.TeamApplication.Status == 0)
                                           {%>
                                            <span style="color:Gray">Created</span>
                                        <% }
                                           else if (app.TeamApplication.Status == 1)
                                           {%>
                                            <span style="color:#00CCCC">Submitted</span>
                                        <% }
                                           else if (app.TeamApplication.Status == 2)
                                           {%>
                                            <span style="color:Green">Approved</span>
                                        <% }
                                           else if (app.TeamApplication.Status == 3)
                                           {%>
                                            <span style="color:Orange">Not Approved</span>
                                        <% } %>
                                    </td>
                                    <td style="width:17%">
                                        <% if (app.TeamApplication.Status == 0)
                                           { %>
                                            <%: Html.ActionLink("Edit", "EditTeamApplication", new { TeamapplicationID = app.TeamApplication.ApplicationID })%>
                                        <% }
                                           else
                                           { %>
                                            <span style="text-decoration:underline; color:Gray">Edit</span>
                                        <% } %>

                                        <% if (app.TeamApplication.Status < 2 || app.TeamApplication.Status == 3)
                                           { %>
                                        <%: Html.ActionLink("Delete", "DeleteTeamApplication", new { TeamapplicationID = app.TeamApplication.ApplicationID })%>
                                        <% }
                                           else
                                           { %>
                                            <span style="text-decoration:underline; color:Gray">Delete</span>
                                        <% } %>
                                        <% if (app.TeamApplication.TeamMessage != "" && app.TeamApplication.TeamMessage != null)
                                           { %>
                                                <a href="#" id="show_app_TeamApplication_Message_<%: app.TeamApplication.ApplicationID %>">Message</a>
                                                <div class="hide">
                                                    <div id="app_TeamApplication_Message_<%: app.TeamApplication.ApplicationID %>">
                                                        <br />
                                                        <p style="margin:10px">
                                                            <%: app.TeamApplication.TeamMessage %>
                                                        </p>
                                                    </div>
                                                </div>
                                        <% } %>
                                    </td>
                                </tr>
                            <% counter++;
                               }%>
                            </table> <!--end teams table-->   
                           </div>
                           <p>
                            <input type="submit" value="Submit Selected Teams" />
                           </p>
                        <% } %>
           <% }
              else
              { %>
                  Add new team applications from the menu below.
           <% } %>
                </td>
                <td style="padding:10px; width:21%;">
                    <br />
                    <% Html.RenderPartial("AddTeamApplication", Model.NewApplication); %>
                </td>
            </tr>
        </table>
 <% }
       else
       {%>
       Choose a tournament from the dropdown menu.
    <% }%>    
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

