<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.CreateNewTournamentView>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_page.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_jui.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/jqueryui/css/jquery-ui-1.8.6.custom.css") %>"
        rel="stylesheet" />
    <link media="screen" rel="stylesheet" href="<%: Url.Content("~/Scripts/jqueryui/css/colorbox.css") %>" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery.colorbox-min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/Datatables/js/jquery.dataTables.min.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#existing_tournament_table").dataTable({
                "bJQueryUI": true,
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aoColumnDefs": [{ "bSortable": false, "aTargets": [6, 7]}]
            });

            $("a[id^=show-tournament_details_]").click(function () {
                var target_td = "#" + $(this).attr("id").split("-")[1];
                var title_id = "#tournament_title_" + $(this).attr("id").split("_")[2];
                var title = $(title_id).text();
                $("#" + $(this).attr("id")).colorbox({ title: title, width: "60%", inline: true, href: target_td });
            });

            $('#Tournaments').attr("id", "currentPage");
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", ""); %>
    <div id="pageContent">
        <% if (Model != null)
           {%>
        <div id="existing_tournaments">
            <h1>
                Upcoming Tournaments</h1>
            <table id="existing_tournament_table" cellspacing="0">
                <thead>
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Location
                        </th>
                        <th>
                            Registration
                            <br class="clear" />
                            Start Date
                        </th>
                        <th>
                            Registration
                            <br class="clear" />
                            End Date
                        </th>
                        <th>
                            Tournament
                            <br class="clear" />
                            Start Date
                        </th>
                        <th>
                            Tournament
                            <br class="clear" />
                            End Date
                        </th>
                        <th>
                            Details
                        </th>
                        <th>
                            Schedule
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < Model.Tournaments.Count; i++)
                       {
                    %>
                    <tr>
                        <td id="tournament_title_<%:i%>">
                            <%: Model.Tournaments[i].TournamentName%>
                        </td>
                        <td>
                            <%: Model.Tournaments[i].Location%>
                        </td>
                        <td>
                            <%: Model.Tournaments[i].RegistrationStartDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <%: Model.Tournaments[i].RegistrationEndDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <%: Model.Tournaments[i].TournamentStartDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <%: Model.Tournaments[i].TournamentEndDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <a id="show-tournament_details_<%:i%>" href="#">Show</a>
                        </td>
                        <td>
                            <%: Html.ActionLink("Show", "MatchSchedule", new { @id = Model.Tournaments[i].TournamentID })%>
                        </td>
                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
        </div>
        <% for (int i = 0; i < Model.Tournaments.Count; i++)
           {%>
        <div class="hide">
            <div id="tournament_details_<%:i%>">
                <br />
                <p>
                    <%: Model.Tournaments[i].TournamentInfo%>
                </p>
            </div>
        </div>
        <%}

           }
           else
           {%>
        <p>
            Currently there is no upcoming tournament</p>
        <% } %>
    </div>
</asp:Content>
