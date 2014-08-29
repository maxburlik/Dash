<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.CoachManageTeamsView>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {

            $('#lnkDeleteTeam').click(function () {
                window.location = '<%: Url.Content("~/Coach/DeleteTeam/") %>' + $('#CurrentTeams').attr("value");
            });


            $.getJSON('<%: Url.Content("~/Coach/TeamPlayers/") %>' + $('#CurrentTeams')[0].value, null, function (data) {

                $('#TeamPlayersPanel').html("Loading...please...wait...");

                var html = "";
                if (data.length > 0) {

                    html += '<table cellspacing="0" style="width: 300px; border: 1px solid gainsboro;">';
                    html += '<tr>';
                    html += '<td style="border-bottom: 1px solid gainsboro;"><b>Name</b>';
                    html += '<td style="border-bottom: 1px solid gainsboro;"><b>Action</b></td>';
                    html += '</tr>';
                }
                else {
                    html += "No players in this team!";
                }

                for (var i = 0; i < data.length; i++) {
                    html += "<tr>";
                    html += '<td style="border-bottom: 1px solid gainsboro;">' + data[i].FirstName + ', ' + data[i].LastName + '</td>';
                    html += '<td style="border-bottom: 1px solid gainsboro;"><br/><a href="<%: Url.Content("~/Coach/UnassignTeam/") %>' + data[i].ID + '">Unassign Team</a><br /><a href="<%: Url.Content("~/Coach/ChangeTeam/") %>' + data[i].ID + '">Change Team</a><br /><a href="<%: Url.Content("~/Coach/AssignPlayerBackToRegistrar/") %>' + data[i].ID + '">Send Back to Registrar</a><br /><br /></td>';
                }
                $('#TeamPlayersPanel').html(html);
            });

            $("#CurrentTeams").change(function () {
                $("#CurrentTeams option:selected").each(function () {
                    $.getJSON('<%: Url.Content("~/Coach/TeamPlayers/") %>' + $(this)[0].value, null, function (data) {

                        $('#TeamPlayersPanel').html("Loading...please...wait...");
                        var html = "";
                        if (data.length > 0) {

                            html += '<table cellspacing="0" style="width: 300px; border: 1px solid gainsboro;">';
                            html += '<tr>';
                            html += '<td style="border-bottom: 1px solid gainsboro;"><b>Name</b>';
                            html += '<td style="border-bottom: 1px solid gainsboro;"><b>Action</b></td>';
                            html += '</tr>';
                        }
                        else {
                            html += "No players in this team!";
                        }

                        for (var i = 0; i < data.length; i++) {
                            html += "<tr>";
                            html += '<td style="border-bottom: 1px solid gainsboro;">' + data[i].FirstName + ', ' + data[i].LastName + '</td>';
                            html += '<td style="border-bottom: 1px solid gainsboro;"><br/><a href="<%: Url.Content("~/Coach/UnassignTeam/") %>' + data[i].ID + '">Unassign Team</a><br /><a href="<%: Url.Content("~/Coach/ChangeTeam/") %>' + data[i].ID + '">Change Team</a><br /><a href="<%: Url.Content("~/Coach/AssignPlayerBackToRegistrar/") %>' + data[i].ID + '">Send Back to Registrar</a><br /><br /></td>';
                        }
                        $('#TeamPlayersPanel').html(html);
                    });
                });
            });


        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "Manage Teams"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <table>
            <tr valign="top">
                <td style="width: 300px">
                    <h1>
                        Unassigned Players</h1>
                    <div id="UnassignedPlayersPanel">
                        <table width="300px" cellspacing="0" style="border: 1px solid gainsboro;">
                            <thead>
                                <tr>
                                    <td style="border-bottom: 1px solid gainsboro; width: 100px;">
                                        <b>Name</b>
                                    </td>
                                    <td style="border-bottom: 1px solid gainsboro; width: 100px;">
                                        <b>Category</b>
                                    </td>
                                    <td style="border-bottom: 1px solid gainsboro; width: 100px;">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </thead>
                            <% foreach (var item in Model.UnassignedPlayers)
                               { %>
                            <tr>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: item.Player.FirstName + " " + item.Player.LastName %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    U<%:new DateTime((DateTime.Now - item.BirthDate).Ticks).Year %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: Html.ActionLink("Assign Team", "AssignTeam", "Coach", new { id = item.Player.ID }, null) %> <br /><br /> <%: Html.ActionLink("Send back to Registrar", "AssignPlayerBackToRegistrar", "Coach", new { id = item.Player.ID }, null) %><br /><br />
                                </td>
                            </tr>
                            <% }%>
                        </table>
                    </div>
                </td>
                <td style="width: 300px; padding-left: 50px;">
                    <div id="CurrentPlayersPanel">
                        <h1>
                            Current Team/Players</h1>
                        Teams:<%: Html.DropDownListFor(m => m.CurrentTeams, Model.CurrentTeams) %><a id="lnkDeleteTeam" href="#">Delete</a>
                        <br />
                        <br />
                        <div id="TeamPlayersPanel">
                        </div>
                    </div>
                </td>
                <td style="width: 300px; padding-left: 100px;">
                    <div id="NewTeamPanel">
                        <% Html.BeginForm(); %>
                        <h1>
                            New Team</h1>
                        <table>
                            <tr>
                                <td>
                                    Team Name:
                                </td>
                                <td>
                                    <%: Html.TextBoxFor(m => m.NewTeam.Name) %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Category:
                                </td>
                                <td>
                                    <select id="NewTeam_Category" style="width: 100px;" name="NewTeam.Category">
                                        <% for (int i = 5; i < 25; i++)
                                           { %>
                                        <option value="U<%: i %>">U<%: i %></option>
                                        <% } %>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <input type="submit" value="Create" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <% Html.EndForm(); %>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
