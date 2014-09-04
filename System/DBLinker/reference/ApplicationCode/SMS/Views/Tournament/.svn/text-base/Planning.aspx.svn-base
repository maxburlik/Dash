<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.TournamentPlanningView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "Tournament Planning"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <div id="ValidationPanel" style="color: Red;"></div>
        <% if (Model != null)
           { %>
        <% using (Html.BeginForm("Planning", "Tournament"))
           { %>
        <h1>
            Tournament Match Planning
        </h1>
        <%: Html.DropDownListFor(m => m.SelectedTournamentID, Model.Tournaments)%><input
            type="submit" value="Display" />
        <%} %>
        <% if (Model.SelectedTournamentID != Guid.Empty)
           { %>
        <br />
        <h2>
            Existing Matches</h2>
        <% if (Model.SelectedTournamentTeamApplications != null && Model.SelectedTournamentMatches != null)
           { %>
        <%: Html.HiddenFor(m => m.SelectedTournamentID)%>
        
        <% for (int i = 0; i < Model.SelectedTournamentMatches.Count; i++)
           {%>
        <div style="border: 0px solid gainsboro;">
            <table cellspacing="0">
                <tr>
                    <td width="100%">
                        <% using (Html.BeginForm("UpdateMatch", "Tournament", new { id = Model.SelectedTournamentMatches[i].Id }, FormMethod.Post, new { id = "frm_update_match_" + Model.SelectedTournamentMatches[i].Id }))
                           { %>
                        <%: Html.HiddenFor(m => m.SelectedTournamentMatches[i].Tournament.TournamentID)%>
                        <table width="100%" cellspacing="0" style="text-align: left;">
                            <% if (i == 0)
                               { %>
                               <thead>
                <tr>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Team A
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Team B
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Score A<br />[optional]
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Score B<br />[optional]
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Location
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Duration<br />[minutes]
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Scheduled Date
                    </th>
                    <th style="border-bottom: 1px solid gainsboro; text-align: right">
                        Action
                    </th>
                </tr>
            </thead>
                            <%} %>
                            <tr style="text-align: left;">
                                <td style="background-color: gainsboro; border-bottom: 1px solid whitesmoke;">
                                    <%: Html.DropDownListFor(m => Model.SelectedTournamentMatches[i].TeamApplicationOne.ApplicationID, Model.SelectedTournamentTeamApplications, new { style = "width:130px;" })%>
                                    <input id="<%: "TeamApplication_1_[" + i + "]" %>" name="<%: "TeamApplication_1_[" + i + "]" %>"
                                        type="hidden" value="<%: Model.SelectedTournamentMatches[i].TeamApplicationOne.ApplicationID %>" />
                                </td>
                                <td style="background-color: gainsboro; border-bottom: 1px solid whitesmoke;">
                                    <%: Html.DropDownListFor(m => Model.SelectedTournamentMatches[i].TeamApplicationTwo.ApplicationID, Model.SelectedTournamentTeamApplications, new { style = "width:130px;" })%>
                                    <input id="<%: "TeamApplication_2_[" + i + "]" %>" name="<%: "TeamApplication_2_[" + i + "]" %>"
                                        type="hidden" value="<%: Model.SelectedTournamentMatches[i].TeamApplicationTwo.ApplicationID %>" />
                                </td>
                                <td style="background-color: gainsboro; border-bottom: 1px solid whitesmoke;">
                                    <%: Html.TextBoxFor(m => Model.SelectedTournamentMatches[i].ScoreOne, new { style = "width:70px;"})%>
                                </td>
                                <td style="background-color: gainsboro; border-bottom: 1px solid whitesmoke;">
                                    <%: Html.TextBoxFor(m => Model.SelectedTournamentMatches[i].ScoreTwo, new { style = "width:70px;" })%>
                                </td>
                                <td style="background-color: gainsboro; border-bottom: 1px solid whitesmoke;">
                                    <%: Html.TextBoxFor(m => Model.SelectedTournamentMatches[i].Location, new { style = "width:70px;" })%>
                                </td>
                                <td style="background-color: gainsboro; border-bottom: 1px solid whitesmoke;">
                                    <%: Html.TextBoxFor(m => Model.SelectedTournamentMatches[i].Duration, new { style = "width:70px;" })%>
                                </td>
                                <td style="background-color: gainsboro; border-bottom: 1px solid whitesmoke;">
                                    <%: Html.TextBox("SelectedTournamentMatches_" + i + "__.ScheduledDate", Model.SelectedTournamentMatches[i].ScheduledDate.ToShortDateString() + " " + Model.SelectedTournamentMatches[i].ScheduledDate.ToShortTimeString().ToLower(), new { id = "SelectedTournamentMatches_" + i + "__ScheduledDate" })%>
                                </td>
                                <td style="text-align: right">
                                    <input type="submit" value="Update" />
                                </td>
                            </tr>
                        </table>
                        <%} %>
                    </td>
                    <td width="100%" style="text-align: left;">
                    <% using (Html.BeginForm("DeleteMatch", "Tournament", new { id = Model.SelectedTournamentMatches[i].Id }, FormMethod.Post, new { id = "frm_delete_match_" + Model.SelectedTournamentMatches[i].Id }))
                       { %>
                       <%: Html.Hidden("TournamentID", Model.SelectedTournamentID, new { id = Model.SelectedTournamentID })%>
                    <% if (i == 0)
                       { %>
                        <input style="margin-top: 33px;" type="submit" value="Delete" />
                    <%}
                       else
                       {%>
                       <input type="submit" value="Delete" />
                    <%} %>
                    <%} %>
                    </td>
                </tr>
            </table>
        </div>
        <%} %>
        <%}%>
        <h2>
            Create New Match</h2>
        <% using (Html.BeginForm("CreateNewMatch", "Tournament", FormMethod.Post, new { id = "CreateNewMatchForm" }))
           { %>
        <%: Html.HiddenFor(m => m.SelectedTournamentID)%>
        <table width="100%" cellspacing="0" style="text-align: left;">
            <thead>
                <tr>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Team A
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Team B
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Score A<br />[optional]
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Score B<br />[optional]
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Location
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Duration<br />[minutes]
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Scheduled Date
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Action
                    </th>
                </tr>
            </thead>
            <tr>
                <td>
                    <%: Html.DropDownListFor(m => m.SelectedTournamentNewMatch.TeamApplicationOne.ApplicationID, Model.SelectedTournamentTeamApplications, new { style = "width:130px;" })%>
                </td>
                <td>
                    <%: Html.DropDownListFor(m => m.SelectedTournamentNewMatch.TeamApplicationTwo.ApplicationID, Model.SelectedTournamentTeamApplications, new { style = "width:130px;" })%>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.SelectedTournamentNewMatch.ScoreOne, new { style = "width:70px;" })%>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.SelectedTournamentNewMatch.ScoreTwo, new { style = "width:70px;" })%>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.SelectedTournamentNewMatch.Location, new { style = "width:70px;" })%>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.SelectedTournamentNewMatch.Duration, new { style = "width:70px;" })%>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.SelectedTournamentNewMatch.ScheduledDate)%>
                </td>
                <td>
                    <input type="submit" value="Create" />
                </td>
            </tr>
        </table>
        <br /><div id="NewValidationPanel" style="color: Red;"></div>
        <% } %>
        <%}
           }%>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_page.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_jui.css") %>"
        rel="stylesheet" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/Datatables/js/jquery.dataTables.min.js") %>"></script>
    <link type="text/css" href="<%: Url.Content("~/Scripts/jqueryui/css/jquery-ui-1.8.6.custom.css") %>"
        rel="stylesheet" />
    <link media="screen" rel="stylesheet" href="<%: Url.Content("~/Scripts/jqueryui/css/colorbox.css") %>" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery.colorbox-min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-1.8.6.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-timepicker-addon.js") %>"></script>
    <script type="text/javascript">
//<![CDATA[
        $(function () {

            totalTeamAppOne = $("select[id$=__TeamApplicationOne_ApplicationID]").length;
            totalTeamAppTwo = $("select[id$=__TeamApplicationTwo_ApplicationID]").length;

            for (var i = 0; i < totalTeamAppOne; i++) {

                teamAppOne = document.getElementById('TeamApplication_1_[' + i + ']');
                teamAppTwo = document.getElementById('TeamApplication_2_[' + i + ']');

                selectedTeamAppOne = document.getElementById('SelectedTournamentMatches_' + i + '__TeamApplicationOne_ApplicationID');
                selectedTeamAppTwo = document.getElementById('SelectedTournamentMatches_' + i + '__TeamApplicationTwo_ApplicationID');

                $(selectedTeamAppOne).val($(teamAppOne).attr("value"));
                $(selectedTeamAppTwo).val($(teamAppTwo).attr("value"));

                scheduledDate = document.getElementById('SelectedTournamentMatches_' + i + '__ScheduledDate');

                $(scheduledDate).datetimepicker({ ampm: true, dateFormat: 'mm/dd/yy' });
            }

            $('#SelectedTournamentNewMatch_ScheduledDate').datetimepicker({ ampm: true, dateFormat: 'mm/dd/yy' });

            $('form[id^=frm_delete_match_]').submit(function () {
                var answer = confirm('Are you sure you want to delete this match? Click OK to delete or Cancel to discard this request.');

                if (answer)
                    return true;
                else
                    return false;
            });

            var durationRegex = /^[1-9]+[0-9]*$/;
            var whiteSpaceRegex = /^\s+$/;

            $('#CreateNewMatchForm').submit(function () {
                var status = true;
                var newMatchLocationElement = $('#SelectedTournamentNewMatch_Location');
                var newMatchDurationElement = $('#SelectedTournamentNewMatch_Duration');
                var newMatchScheduledDateElement = $('#SelectedTournamentNewMatch_ScheduledDate');
                var teamAElement = $('#SelectedTournamentNewMatch_TeamApplicationOne_ApplicationID');
                var teamBElement = $('#SelectedTournamentNewMatch_TeamApplicationTwo_ApplicationID');

                $('#NewValidationPanel').empty();

                if ($(teamAElement).val() == $(teamBElement).val()) {
                    $(teamAElement).removeClass('UnHighlightError').addClass('HighlightError');

                    $(teamBElement).removeClass('UnHighlightError').addClass('HighlightError');

                    if (document.getElementById('NewMatchTeamABValidationMsg') == null) {
                        document.getElementById('NewValidationPanel').innerHTML += '<ul id="NewMatchTeamABValidationMsg"><li>Team A and Team B cannot be the same.</li></ul>';
                    }
                }
                else {
                    $(teamAElement).removeClass("HighLightError").addClass('UnHighlightError');
                    $(teamBElement).removeClass("HighLightError").addClass('UnHighlightError');

                }

                if ($(newMatchScheduledDateElement).attr("value") == '' ||
                        whiteSpaceRegex.test($(newMatchScheduledDateElement).attr("value"))
                   ) {

                    $(newMatchScheduledDateElement).removeClass('UnHighlightError').addClass('HighlightError');

                    if (document.getElementById('NewMatchScheduledDateValidationMsg') == null) {
                        document.getElementById('NewValidationPanel').innerHTML += '<ul id="NewMatchScheduledDateValidationMsg"><li>Please enter valid scheduled date time [mm/dd/yyyy xx:xx am/pm].</li></ul>';
                    }
                }
                else {
                    $(newMatchScheduledDateElement).removeClass("HighLightError").addClass('UnHighlightError');
                }



                if ($(newMatchLocationElement).attr("value") == '' ||
                        whiteSpaceRegex.test($(newMatchLocationElement).attr("value"))
                   ) {

                    $(newMatchLocationElement).removeClass('UnHighlightError').addClass('HighlightError');

                    if (document.getElementById('NewMatchLocationValidationMsg') == null) {
                        document.getElementById('NewValidationPanel').innerHTML += '<ul id="NewMatchLocationValidationMsg"><li>Please enter valid location.</li></ul>';
                    }
                }
                else {
                    $(newMatchLocationElement).removeClass("HighLightError").addClass('UnHighlightError');
                }


                if ($(newMatchDurationElement).attr("value") == '' ||
                        !durationRegex.test($(newMatchDurationElement).attr("value")) ||
                        whiteSpaceRegex.test($(newMatchDurationElement).attr("value"))
                   ) {

                    $(newMatchDurationElement).removeClass('UnHighlightError').addClass('HighlightError');

                    if (document.getElementById('NewMatchDurationValidationMsg') == null) {
                        document.getElementById('NewValidationPanel').innerHTML += '<ul id="NewMatchDurationValidationMsg"><li>Please enter valid duration (in minutes).</li></ul>';
                    }
                }
                else {
                    $(newMatchDurationElement).removeClass("HighLightError").addClass('UnHighlightError');
                }


                if ((document.getElementById('NewMatchDurationValidationMsg') == null) &&
                    (document.getElementById('NewMatchLocationValidationMsg') == null) &&
                    (document.getElementById('NewMatchScheduledDateValidationMsg') == null) &&
                    (document.getElementById('NewMatchTeamABValidationMsg') == null)
                    ) {
                    status = true;
                }
                else {
                    status = false;
                }

                return status;

            });

            $('form[id^=frm_update_match_]').submit(function () {
                var status = true;

                var durationElement = ($('form[id=' + $(this).attr("id") + '] input[id$=Duration]'));
                var locationElement = ($('form[id=' + $(this).attr("id") + '] input[id$=Location]'));
                var dateElement = ($('form[id=' + $(this).attr("id") + '] input[id$=ScheduledDate]'));
                var teamBElement = ($('form[id=' + $(this).attr("id") + '] select[id$=TeamApplicationTwo_ApplicationID]'));
                var teamAElement = ($('form[id=' + $(this).attr("id") + '] select[id$=TeamApplicationOne_ApplicationID]'));

                $('#ValidationPanel').empty();

                if ($(teamAElement).val() == $(teamBElement).val()) {

                    $(teamAElement).removeClass('UnHighlightError').addClass('HighlightError');
                    $(teamBElement).removeClass('UnHighlightError').addClass('HighlightError');

                    if (document.getElementById('TeamABValidationMsg') == null) {
                        document.getElementById('ValidationPanel').innerHTML += '<ul id="TeamABValidationMsg"><li>Team A and Team B cannot be the same.</li></ul>';
                    }
                }
                else {

                    $(teamAElement).removeClass("HighLightError").addClass('UnHighlightError');
                    $(teamBElement).removeClass("HighLightError").addClass('UnHighlightError');

                }

                if ($(durationElement).attr("value") == '' ||
                        !durationRegex.test($(durationElement).attr("value")) ||
                        whiteSpaceRegex.test($(durationElement).attr("value"))
                   ) {

                    status = false;

                    $(durationElement).removeClass('UnHighlightError').addClass('HighlightError');

                    if (document.getElementById('DurationValidationMsg') == null) {
                        document.getElementById('ValidationPanel').innerHTML += '<ul id="DurationValidationMsg"><li>Please enter valid duration (in minutes).</li></ul>';
                    }
                }
                else {
                    $(durationElement).removeClass("HighLightError").addClass('UnHighlightError');
                }


                if ($(locationElement).attr("value") == '' ||
                        whiteSpaceRegex.test($(locationElement).attr("value"))
                   ) {

                    status = false;

                    $(locationElement).removeClass('UnHighlightError').addClass('HighlightError');

                    if (document.getElementById('LocationValidationMsg') == null) {
                        document.getElementById('ValidationPanel').innerHTML += '<ul id="LocationValidationMsg"><li>Please enter valid location.</li></ul>';
                    }
                }
                else {
                    $(locationElement).removeClass("HighLightError").addClass('UnHighlightError');
                }


                if ($(dateElement).attr("value") == '' ||
                        whiteSpaceRegex.test($(dateElement).attr("value"))
                   ) {

                    status = false;

                    $(dateElement).removeClass('UnHighlightError').addClass('HighlightError');

                    if (document.getElementById('LocationValidationMsg') == null) {
                        document.getElementById('ValidationPanel').innerHTML += '<ul id="DateValidationMsg"><li>Please enter valid scheduled date time [mm/dd/yyyy xx:xx am/pm].</li></ul>';
                    }
                }
                else {
                    $(dateElement).removeClass("HighLightError").addClass('UnHighlightError');
                }


                if ((document.getElementById('DurationValidationMsg') == null) &&
                    (document.getElementById('LocationValidationMsg') == null) &&
                    (document.getElementById('DateValidationMsg') == null) &&
                    (document.getElementById('TeamABValidationMsg') == null)
                    ) {

                    status = true;
                }
                else {

                    status = false;
                }

                return status;
            });

        });

//]]>

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
