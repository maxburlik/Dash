<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.CreateNewTournamentView>" %>

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
            $("#existing_tournament_table").dataTable({
                "bJQueryUI": true,
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aoColumnDefs": [{ "bSortable": false, "aTargets": [6, 7]}]
            });

            $("#show_create_form").click(function () {
                if ($("#tournament_create_form").is(":hidden")) {
                    $("#show_create_form").text("Hide - Create Tournament Form");
                    $("#tournament_create_form").slideDown("slow");
                } else {
                    $("#show_create_form").text("Show - Create Tournament Form");
                    $("#tournament_create_form").slideUp("slow");
                }
            });


            $("a[id^=show-tournament_details_]").click(function () {
                var target_td = "#" + $(this).attr("id").split("-")[1];
                var title_id = "#tournament_title_" + $(this).attr("id").split("_")[2];
                var title = $(title_id).text();
                $("#" + $(this).attr("id")).colorbox({ title: title, width: "60%", inline: true, href: target_td });
            });
            $("#Tournament_RegistrationStartDate").datepicker({ dateFormat: 'mm/dd/yy' });
            $("#Tournament_RegistrationEndDate").datepicker({ dateFormat: 'mm/dd/yy' });
            $("#Tournament_TournamentStartDate").datepicker({ dateFormat: 'mm/dd/yy' });
            $("#Tournament_TournamentEndDate").datepicker({ dateFormat: 'mm/dd/yy' });

            $('form').submit(function () {
                var status = true;
                var whitespace = /^\s+$/;
                document.getElementById('StatusPanel').innerHTML = "";

                if (document.getElementById('Tournament_TournamentName').value == '' ||
                    whitespace.test(document.getElementById('Tournament_TournamentName').value)) {

                    $('#Tournament_TournamentName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The name is required</li></ul>';
                    status = false;
                }
                else {
                    $('#Tournament_TournamentName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Tournament_Location').value == '' ||
                    whitespace.test(document.getElementById('Tournament_Location').value)) {

                    $('#Tournament_Location').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The location is required</li></ul>';
                    status = false;
                }
                else {
                    $('#Tournament_Location').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Tournament_RegistrationStartDate').value == '' ||
                    whitespace.test(document.getElementById('Tournament_RegistrationStartDate').value)) {

                    $('#Tournament_RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The registration start date is required</li></ul>';
                    status = false;
                }
                else {
                    $('#Tournament_RegistrationStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('Tournament_RegistrationEndDate').value == '' ||
                    whitespace.test(document.getElementById('Tournament_RegistrationEndDate').value)) {

                    $('#Tournament_RegistrationEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The registration end date is required</li></ul>';
                    status = false;
                }
                else {
                    $('#Tournament_RegistrationEndDate').removeClass("HighLightError").addClass('UnHighlightError');
                }



                if (document.getElementById('Tournament_TournamentStartDate').value == '' ||
                    whitespace.test(document.getElementById('Tournament_TournamentStartDate').value)) {

                    $('#Tournament_TournamentStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The tournament start date is required</li></ul>';
                    status = false;
                }
                else {
                    $('#Tournament_TournamentStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                }



                if (document.getElementById('Tournament_TournamentEndDate').value == '' ||
                    whitespace.test(document.getElementById('Tournament_TournamentEndDate').value)) {

                    $('#Tournament_TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The tournament end date is required</li></ul>';
                    status = false;
                }
                else {
                    $('#Tournament_TournamentEndDate').removeClass("HighLightError").addClass('UnHighlightError');
                }



                if (document.getElementById('Tournament_TournamentInfo').value == '' ||
                    whitespace.test(document.getElementById('Tournament_TournamentInfo').value)) {

                    $('#Tournament_TournamentInfo').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The description is required</li></ul>';
                    status = false;
                }
                else {
                    $('#Tournament_TournamentInfo').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Tournament_RegistrationStartDate').value != '' &&
                    !whitespace.test(document.getElementById('Tournament_RegistrationStartDate').value)) {
                    var date = $("#Tournament_RegistrationStartDate").val();
                    if (!validate_date2(date)) {
                        $('#Tournament_RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration start date format is not correct, please use the format: mm/dd/yyyy.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Tournament_RegistrationStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Tournament_RegistrationEndDate').value != '' &&
                    !whitespace.test(document.getElementById('Tournament_RegistrationEndDate').value)) {
                    var date = $("#Tournament_RegistrationEndDate").val();
                    if (!validate_date2(date)) {
                        $('#Tournament_RegistrationEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration end date format is not correct, please use the format: mm/dd/yyyy.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Tournament_RegistrationEndDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Tournament_TournamentStartDate').value != '' &&
                    !whitespace.test(document.getElementById('Tournament_TournamentStartDate').value)) {
                    var date = $("#Tournament_TournamentStartDate").val();
                    if (!validate_date2(date)) {
                        $('#Tournament_TournamentStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Tournament start date format is not correct, please use the format: mm/dd/yyyy.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Tournament_TournamentStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Tournament_TournamentEndDate').value != '' &&
                    !whitespace.test(document.getElementById('Tournament_TournamentEndDate').value)) {
                    var date = $("#Tournament_TournamentEndDate").val();
                    if (!validate_date2(date)) {
                        $('#Tournament_TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Tournament end date format is not correct, please use the format: mm/dd/yyyy.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Tournament_TournamentEndDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Tournament_RegistrationStartDate').value != '' &&
                     !whitespace.test(document.getElementById('Tournament_RegistrationStartDate').value) &&
                     document.getElementById('Tournament_RegistrationEndDate').value != '' &&
                     !whitespace.test(document.getElementById('Tournament_RegistrationEndDate').value)) {

                    $('#Tournament_RegistrationStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                    $('#Tournament_RegistrationEndDate').removeClass("HighLightError").addClass('UnHighlightError');


                    var registration_start_date = $("#Tournament_RegistrationStartDate").val();
                    var registration_end_date = $("#Tournament_RegistrationEndDate").val();

                    if (!validate_start_and_end_date(registration_start_date, registration_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration start date must be earlier than registration end date</li></ul>';
                        $('#Tournament_RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#Tournament_RegistrationEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }
                }

                if (document.getElementById('Tournament_TournamentStartDate').value != '' &&
                     !whitespace.test(document.getElementById('Tournament_TournamentStartDate').value) &&
                                          document.getElementById('Tournament_TournamentEndDate').value != '' &&
                     !whitespace.test(document.getElementById('Tournament_TournamentEndDate').value)) {
                    $('#Tournament_TournamentStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                    $('#Tournament_TournamentEndDate').removeClass("HighLightError").addClass('UnHighlightError');

                    var tournament_start_date = $("#Tournament_TournamentStartDate").val();
                    var tournament_end_date = $("#Tournament_TournamentEndDate").val();

                    if (!validate_start_and_end_date(tournament_start_date, tournament_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Tournament start date must be earlier than tournament end date</li></ul>';
                        $('#Tournament_TournamentStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#Tournament_TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }
                }

                if (document.getElementById('Tournament_RegistrationStartDate').value != '' &&
                     !whitespace.test(document.getElementById('Tournament_RegistrationStartDate').value) &&
                     document.getElementById('Tournament_RegistrationEndDate').value != '' &&
                     !whitespace.test(document.getElementById('Tournament_RegistrationEndDate').value) &&
                     document.getElementById('Tournament_TournamentStartDate').value != '' &&
                     !whitespace.test(document.getElementById('Tournament_TournamentStartDate').value) &&
                                          document.getElementById('Tournament_TournamentEndDate').value != '' &&
                     !whitespace.test(document.getElementById('Tournament_TournamentEndDate').value)) {


                    if (!validate_start_and_end_date(registration_start_date, tournament_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration start date must be earlier than tournament start date</li></ul>';
                        $('#Tournament_RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#Tournament_TournamentStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }

                    if (!validate_start_and_end_date(registration_start_date, tournament_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration start date must be earlier than tournament end date</li></ul>';
                        $('#Tournament_RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#Tournament_TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }

                    if (!validate_start_and_end_date(registration_end_date, tournament_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration end date must be earlier than tournament end date</li></ul>';
                     $('#Tournament_RegistrationEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#Tournament_TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }

                }

                if (!status)
                    return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Tournaments"); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <div class="pageContent">
        <%: Html.ActionLink("<< Go Back", "Create")%>
    </div>
    <%} %>
    <div id="pageContent">
        <% if (Model != null)
           {%>
        <a id="show_create_form" href="#">Show - Create Tournament Form</a>
        <%} %>
        <div id="tournament_create_form" class="hide">
            <div id="StatusPanel" style="color: Red;">
            </div>
            <h1>
                Create a New Tournament</h1>
            <% Html.EnableClientValidation(); %>
            <% Html.BeginForm();
               {
                   if (Model != null)
                   {%>
            <table id="tournament_create_table">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <strong>Registration</strong>
                    </td>
                    <td>
                    </td>
                    <td>
                        <strong>Tournament</strong>
                    </td>
                </tr>
                <tr valign="top">
                    <td>
                        Name:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Tournament.TournamentName)%><br />
                        <%: Html.ValidationMessageFor(m => Model.Tournament.TournamentName)%>
                    </td>
                    <td>
                        Start Date:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Tournament.RegistrationStartDate)%><br />
                        <%: Html.ValidationMessageFor(m => Model.Tournament.RegistrationStartDate)%>
                    </td>
                    <td>
                        Start Date:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Tournament.TournamentStartDate)%><br />
                        <%: Html.ValidationMessageFor(m => Model.Tournament.TournamentStartDate)%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Location:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Tournament.Location)%><br />
                        <%: Html.ValidationMessageFor(m => Model.Tournament.Location)%>
                    </td>
                    <td>
                        End Date:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Tournament.RegistrationEndDate)%><br />
                        <%: Html.ValidationMessageFor(m => Model.Tournament.RegistrationEndDate)%>
                    </td>
                    <td>
                        End Date:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Tournament.TournamentEndDate)%><br />
                        <%: Html.ValidationMessageFor(m => Model.Tournament.TournamentEndDate)%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
                    </td>
                    <td colspan="6" align="center">
                        <%= Html.TextAreaFor(m => Model.Tournament.TournamentInfo)%><br />
                        <%: Html.ValidationMessageFor(m => Model.Tournament.TournamentInfo)%>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <input id="tournamentSubmit" class="float_right" type="submit" value="Create" />
                    </td>
                </tr>
            </table>
            <% Html.EndForm(); %>
        </div>
        <div id="existing_tournaments">
            <h1>
                Existing Tournaments</h1>
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
                        <th colspan="2">
                        Action
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
                            <a href="<%: Url.Content("~/Tournament/Edit/") %><%:Model.Tournaments[i].TournamentID %>">
                                Edit</a>
                        </td>
                        <td>
                            <a href="<%: Url.Content("~/Tournament/Delete/") %><%:Model.Tournaments[i].TournamentID %>">
                                Delete</a>
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
                <p>
                <br />
                    <%: Model.Tournaments[i].TournamentInfo%>
                </p>
            </div>
        </div>
        <%}
                   }
               }%>
    </div>
</asp:Content>
