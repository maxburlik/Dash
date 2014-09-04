<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.ManageTeamApplicationsView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Tournament Team Applications"); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <%} %>
    <div id="team_app_tournament_dropdown">
        <h1 class="pageContent">
            Manage Team Applications
        </h1>
        <table class="pageContent">
            <tr>
                <td class="pageContent" style="width: 21%">
                    <% if (Model != null)
                       {
                           Html.BeginForm();
                           { %>
                    <%: Html.ValidationSummary(true) %>
                    <%: Html.DropDownListFor(m => m.SelectedTournamentId, Model.TournamentDropList)%>
                </td>
                <td>
                    <input type="submit" value="Display" />
                    <% Html.EndForm(); %>
                    <% }

                       }%>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="pageContent">
        <% if (Model.TeamApplications != null)
           {
               if (Model.TeamApplications.Count > 0)
               {%>
        <ul class="pageContent">
            <li><a href="#new_team_applications">New Teams</a></li>
            <li><a href="#approved_team_applications">Approved Teams</a></li>
            <li><a href="#denied_team_applications">Denied Teams</a></li>
        </ul>
        <div id="new_team_applications">
            <table id="new_team_applications_table" cellspacing="0">
                <thead>
                    <tr>
                        <th>
                            Organization
                        </th>
                        <th>
                            Coach
                        </th>
                        <th>
                            Team
                        </th>
                        <th>
                            Category
                        </th>
                        <th>
                            Date
                        </th>
                        <th colspan="2">
                            Action
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < Model.TeamApplications.Count; i++)
                       {
                           if (Model.TeamApplications[i].Status == 1)
                           {
                    %>
                    <tr>
                        <td id="team_<%:i%>">
                            <%: Model.TeamApplications[i].Organization.Name%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].CoachName%>
                        </td>
                        <td id="team_name_<%:i%>">
                            <%: Model.TeamApplications[i].TeamName%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].Category%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].SubmissionDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <a id="show-decision_form_<%:i%>" href="#">Select</a>
                        </td>
                    </tr>
                    <%
                        }
                       }
                    %>
                </tbody>
            </table>
        </div>
        <div id="approved_team_applications">
            <table id="approved_team_applications_table" cellspacing="0">
                <thead>
                    <tr>
                        <th>
                            Organization
                        </th>
                        <th>
                            Coach
                        </th>
                        <th>
                            Team
                        </th>
                        <th>
                            Category
                        </th>
                        <th>
                            Date
                        </th>
                        <th>
                            View Message
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < Model.TeamApplications.Count; i++)
                       {
                           if (Model.TeamApplications[i].Status == 2)
                           {
                    %>
                    <tr>
                        <td id="team_<%:i%>">
                            <%: Model.TeamApplications[i].Organization.Name%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].CoachName%>
                        </td>
                        <td id="team_name_<%:i%>">
                            <%: Model.TeamApplications[i].TeamName%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].Category%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].SubmissionDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <a id="show-decision_form_<%:i %>" href="#">View Message</a>
                        </td>
                    </tr>
                    <%
                        }
                       }
                    %>
                </tbody>
            </table>
        </div>
        <div id="denied_team_applications">
            <table id="denied_team_applications_table" cellspacing="0">
                <thead>
                    <tr>
                        <th>
                            Organization
                        </th>
                        <th>
                            Coach
                        </th>
                        <th>
                            Team
                        </th>
                        <th>
                            Category
                        </th>
                        <th>
                            Date
                        </th>
                        <th>
                            View Message
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < Model.TeamApplications.Count; i++)
                       {
                           if (Model.TeamApplications[i].Status == 3)
                           {
                    %>
                    <tr>
                        <td id="team_<%:i%>">
                            <%: Model.TeamApplications[i].Organization.Name%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].CoachName%>
                        </td>
                        <td id="team_name_<%:i%>">
                            <%: Model.TeamApplications[i].TeamName%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].Category%>
                        </td>
                        <td>
                            <%: Model.TeamApplications[i].SubmissionDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <a id="show-decision_form_<%:i %>" href="#">View Message</a>
                        </td>
                    </tr>
                    <%
                        }
                       }
                    %>
                </tbody>
            </table>
        </div>
        <% for (int i = 0; i < Model.TeamApplications.Count; i++)
           {%>
        <div class="hide">
            <div id="decision_form_<%:i%>">
                <% if (Model.TeamApplications[i].Status == 1)
                   { %>
                <% Html.EnableClientValidation(); %>
                <% Html.BeginForm("TeamApproveOrDeny", "Tournament"); %>
                <br />
                <br />
                <table>
                    <tr valign="top">
                        <td>
                            Message:
                        </td>
                        <td>
                            <%: Html.HiddenFor(m => Model.TeamApplications[i].ApplicationID)%>
                            <%: Html.HiddenFor(m => Model.SelectedTournamentId)%>
                            <%= Html.TextAreaFor(m => Model.TeamApplications[i].TeamMessage, 10, 70, new { style = "width: 100%", @class = "textarea" })%><br />
                            <%: Html.ValidationMessageFor(m => Model.TeamApplications[i].TeamMessage)%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="decision">
                                Decision:</label>
                        </td>
                        <td>
                            <%= Html.RadioButton("decision", "Approve")%>
                            Approve
                            <%= Html.RadioButton("decision", "Deny")%>
                            Deny
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <input class="team_application_decision float_right" type="submit" value="Submit" />
                        </td>
                    </tr>
                </table>
                <% Html.EndForm();
                  }%>
                <%
                    else if (Model.TeamApplications[i].Status == 2 || Model.TeamApplications[i].Status == 3)
                    { %>
                <br />
                <br />
                <p>
                <% if (!string.IsNullOrEmpty(Model.TeamApplications[i].TeamMessage))
                      {%>
                    <%:Model.TeamApplications[i].TeamMessage%></p>
                    <%}else {%>
                    N/A
                    
                <% }}%>
            </div>
        </div>
        <%}
               }
               else
               {%>
        Choose a tournament from the dropdown menu.
        <% }
           }
        %>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_page.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_jui.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/jqueryui/css/jquery-ui-1.8.6.custom.css") %>"
        rel="stylesheet" />
    <link media="screen" rel="stylesheet" href="<%: Url.Content("~/Scripts/jqueryui/css/colorbox.css") %>" />
    <style type="text/css">
        .HighlightError
        {
            border: 1px solid red;
        }
        .UnHighlightError
        {
            border: 1px solid Gray;
        }
    </style>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/validation.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-1.8.6.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery.colorbox-min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/Datatables/js/jquery.dataTables.min.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
  
            $("a[id^=show-decision_form_]").click(function () {
                var target_td = "#" + $(this).attr("id").split("-")[1];

                var team_id = "#team_name_" + $(this).attr("id").split("_")[2];
                var team = $(team_id).text();
                $("#" + $(this).attr("id")).colorbox({ title: team, width: "60%", inline: true, href: target_td });
            });

            $("#new_team_applications_table").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers",
                "bProcessing": true,
                "aoColumnDefs": [{ "bSortable": false, "aTargets": [5]}]
            });

            $("#approved_team_applications_table").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers",
                "bProcessing": true,
                "aoColumnDefs": [{ "bSortable": false, "aTargets": [5]}]
            });
            $("#denied_team_applications_table").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers",
                "bProcessing": true,
                "aoColumnDefs": [{ "bSortable": false, "aTargets": [5]}]
            });
            $("#pageContent").tabs();

            $(".team_application_decision").click(function () {
                var decision = $(this).closest("form").find("input[name=decision]:checked").val();
                var message = $(this).closest("form").find("textarea").val();
                var whitespace = /^\s+$/;
                if (decision == null) {
                    alert("Please choose approve or deny, and provide reason if you deny the team.");
                    return false;
                }
                else {
                    if (decision == "Deny") {
                        if (message == "" || whitespace.test(message)) {
                            alert("Please enter the reason of denying the team");
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                        return true;
                }
                return false;
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
