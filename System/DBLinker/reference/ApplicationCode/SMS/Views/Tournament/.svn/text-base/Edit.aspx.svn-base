<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.DomainModels.Tournament>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <link type="text/css" href="<%: Url.Content("~/Scripts/jqueryui/css/jquery-ui-1.8.6.custom.css") %>"
        rel="stylesheet" />
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
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-1.8.6.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/validation.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#RegistrationStartDate").datepicker({ dateFormat: 'mm/dd/yy' });
            $("#RegistrationEndDate").datepicker({ dateFormat: 'mm/dd/yy' });
            $("#TournamentStartDate").datepicker({ dateFormat: 'mm/dd/yy' });
            $("#TournamentEndDate").datepicker({ dateFormat: 'mm/dd/yy' });

            $('form').submit(function () {
                var status = true;
                var whitespace = /^\s+$/;
                document.getElementById('StatusPanel').innerHTML = "";

                if (document.getElementById('TournamentName').value == '' ||
                    whitespace.test(document.getElementById('TournamentName').value)) {

                    $('#TournamentName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The name is required</li></ul>';
                    status = false;
                }
                else {
                    $('#TournamentName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Location').value == '' ||
                    whitespace.test(document.getElementById('Location').value)) {

                    $('#Location').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The location is required</li></ul>';
                    status = false;
                }
                else {
                    $('#Location').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('RegistrationStartDate').value == '' ||
                    whitespace.test(document.getElementById('RegistrationStartDate').value)) {

                    $('#RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The registration start date is required</li></ul>';
                    status = false;
                }
                else {
                    $('#RegistrationStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('RegistrationEndDate').value == '' ||
                    whitespace.test(document.getElementById('RegistrationEndDate').value)) {

                    $('#RegistrationEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The registration end date is required</li></ul>';
                    status = false;
                }
                else {
                    $('#RegistrationEndDate').removeClass("HighLightError").addClass('UnHighlightError');
                }



                if (document.getElementById('TournamentStartDate').value == '' ||
                    whitespace.test(document.getElementById('TournamentStartDate').value)) {

                    $('#TournamentStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The tournament start date is required</li></ul>';
                    status = false;
                }
                else {
                    $('#TournamentStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                }



                if (document.getElementById('TournamentEndDate').value == '' ||
                    whitespace.test(document.getElementById('TournamentEndDate').value)) {

                    $('#TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The tournament end date is required</li></ul>';
                    status = false;
                }
                else {
                    $('#TournamentEndDate').removeClass("HighLightError").addClass('UnHighlightError');
                }



                if (document.getElementById('TournamentInfo').value == '' ||
                    whitespace.test(document.getElementById('TournamentInfo').value)) {

                    $('#TournamentInfo').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>The description is required</li></ul>';
                    status = false;
                }
                else {
                    $('#TournamentInfo').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('RegistrationStartDate').value != '' &&
                    !whitespace.test(document.getElementById('RegistrationStartDate').value)) {
                    var date = $("#RegistrationStartDate").val();
                    if (!validate_date2(date)) {
                        $('#RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration start date format is not correct, please use the format: mm/dd/yyyy.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#RegistrationStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('RegistrationEndDate').value != '' &&
                    !whitespace.test(document.getElementById('RegistrationEndDate').value)) {
                    var date = $("#RegistrationEndDate").val();
                    if (!validate_date2(date)) {
                        $('#RegistrationEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration end date format is not correct, please use the format: mm/dd/yyyy.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#RegistrationEndDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('TournamentStartDate').value != '' &&
                    !whitespace.test(document.getElementById('TournamentStartDate').value)) {
                    var date = $("#TournamentStartDate").val();
                    if (!validate_date2(date)) {
                        $('#TournamentStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Tournament start date format is not correct, please use the format: mm/dd/yyyy.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#TournamentStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('TournamentEndDate').value != '' &&
                    !whitespace.test(document.getElementById('TournamentEndDate').value)) {
                    var date = $("#TournamentEndDate").val();
                    if (!validate_date2(date)) {
                        $('#TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Tournament end date format is not correct, please use the format: mm/dd/yyyy.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#TournamentEndDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('RegistrationStartDate').value != '' &&
                     !whitespace.test(document.getElementById('RegistrationStartDate').value) &&
                     document.getElementById('RegistrationEndDate').value != '' &&
                     !whitespace.test(document.getElementById('RegistrationEndDate').value)) {

                    $('#RegistrationStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                    $('#RegistrationEndDate').removeClass("HighLightError").addClass('UnHighlightError');


                    var registration_start_date = $("#RegistrationStartDate").val();
                    var registration_end_date = $("#RegistrationEndDate").val();

                    if (!validate_start_and_end_date(registration_start_date, registration_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration start date must be earlier than registration end date</li></ul>';
                        $('#RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#RegistrationEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }
                }

                if (document.getElementById('TournamentStartDate').value != '' &&
                     !whitespace.test(document.getElementById('TournamentStartDate').value) &&
                                          document.getElementById('TournamentEndDate').value != '' &&
                     !whitespace.test(document.getElementById('TournamentEndDate').value)) {
                    $('#TournamentStartDate').removeClass("HighLightError").addClass('UnHighlightError');
                    $('#TournamentEndDate').removeClass("HighLightError").addClass('UnHighlightError');

                    var tournament_start_date = $("#TournamentStartDate").val();
                    var tournament_end_date = $("#TournamentEndDate").val();

                    if (!validate_start_and_end_date(tournament_start_date, tournament_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Tournament start date must be earlier than tournament end date</li></ul>';
                        $('#TournamentStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }
                }

                if (document.getElementById('RegistrationStartDate').value != '' &&
                     !whitespace.test(document.getElementById('RegistrationStartDate').value) &&
                     document.getElementById('RegistrationEndDate').value != '' &&
                     !whitespace.test(document.getElementById('RegistrationEndDate').value) &&
                     document.getElementById('TournamentStartDate').value != '' &&
                     !whitespace.test(document.getElementById('TournamentStartDate').value) &&
                                          document.getElementById('TournamentEndDate').value != '' &&
                     !whitespace.test(document.getElementById('TournamentEndDate').value)) {


                    if (!validate_start_and_end_date(registration_start_date, tournament_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration start date must be earlier than tournament start date</li></ul>';
                        $('#RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#TournamentStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }

                    if (!validate_start_and_end_date(registration_start_date, tournament_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration start date must be earlier than tournament end date</li></ul>';
                        $('#RegistrationStartDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }

                    if (!validate_start_and_end_date(registration_end_date, tournament_end_date)) {
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Registration end date must be earlier than tournament end date</li></ul>';
                        $('#RegistrationEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#TournamentEndDate').removeClass('UnHighlightError').addClass('HighlightError');
                        status = false;
                    }

                    if (!status)
                        return false;
                }


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
    <%} %>
    <div id="pageContent">
        <% if (Model != null)
           {%>
        <h1>
            Edit Tournament</h1>
        <%} %>
        <div id="StatusPanel" style="color: Red;">
        </div>
        <div>
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
                        <%= Html.TextBoxFor(m => Model.TournamentName)%><br />
                        <%: Html.ValidationMessageFor(m => Model.TournamentName)%>
                    </td>
                    <td>
                        Start Date:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.RegistrationStartDate)%><br />
                        <%: Html.ValidationMessageFor(m => Model.RegistrationStartDate)%>
                        <script type="text/javascript">
                            $('#RegistrationStartDate').val($('#RegistrationStartDate').val().split(" ", 2)[0])
                        </script>
                    </td>
                    <td>
                        Start Date:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.TournamentStartDate)%><br />
                        <%: Html.ValidationMessageFor(m => Model.TournamentStartDate)%>
                        <script type="text/javascript">
                            $('#TournamentStartDate').val($('#TournamentStartDate').val().split(" ", 2)[0])
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        Location:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.Location)%><br />
                        <%: Html.ValidationMessageFor(m => Model.Location)%>
                    </td>
                    <td>
                        End Date:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.RegistrationEndDate)%><br />
                        <%: Html.ValidationMessageFor(m => Model.RegistrationEndDate)%>
                        <script type="text/javascript">
                            $('#RegistrationEndDate').val($('#RegistrationEndDate').val().split(" ", 2)[0])
                        </script>
                    </td>
                    <td>
                        End Date:
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => Model.TournamentEndDate)%><br />
                        <%: Html.ValidationMessageFor(m => Model.TournamentEndDate)%>
                        <script type="text/javascript">
                            $('#TournamentEndDate').val($('#TournamentEndDate').val().split(" ", 2)[0])
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
                    </td>
                    <td colspan="6" align="center">
                        <%= Html.TextAreaFor(m => Model.TournamentInfo)%><br />
                        <%: Html.ValidationMessageFor(m => Model.TournamentInfo)%>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <input id="tournamentSubmit" class="float_right" type="submit" value="Update" />
                    </td>
                </tr>
            </table>
            <% Html.EndForm(); %>
            <%}
               } %>
        </div>
    </div>
    <div class="pageContent">
        <%: Html.ActionLink("<< Go Back", "Create")%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
