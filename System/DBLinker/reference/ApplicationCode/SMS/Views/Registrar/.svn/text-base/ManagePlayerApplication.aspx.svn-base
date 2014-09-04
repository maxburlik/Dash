<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.RegistrarManageNewPlayerView>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
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
    <script type="text/javascript">

        $(document).ready(function () {

            $('#Coaches').val($('#Player_Coach_ID').attr("value"));

            $("#Player_BirthDate").change(function () {
                var date = $("#Player_BirthDate").val();
                if (!validate_date1(date)) {
                    return false;
                }
                return true;
            });


            $('form').submit(function () {
                var status = true;
                var whitespace = /^\s+$/;
                document.getElementById('StatusPanel').innerHTML = "";

                if (document.getElementById('Player_Player_LastName').value == '' || whitespace.test(document.getElementById('Player_Player_LastName').value)) {
                    $('#Player_Player_LastName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s last name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Player_LastName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Player_FirstName').value == '' || whitespace.test(document.getElementById('Player_Player_FirstName').value)) {
                    $('#Player_Player_FirstName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s first name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Player_FirstName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Player_Address_StreetAddress').value == '' ||
                    whitespace.test(document.getElementById('Player_Player_Address_StreetAddress').value)) {

                    $('#Player_Player_Address_StreetAddress').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s address is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Player_Address_StreetAddress').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Player_Address_City').value == '' ||
                    whitespace.test(document.getElementById('Player_Player_Address_City').value)) {

                    $('#Player_Player_Address_City').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s city is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Player_Address_City').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('Player_Player_Address_PostalCode').value == '' ||
                    whitespace.test(document.getElementById('Player_Player_Address_PostalCode').value)) {

                    $('#Player_Player_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s postal code is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Player_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Player_Address_PostalCode').value != '' &&
                    !whitespace.test(document.getElementById('Player_Player_Address_PostalCode').value)) {
                    var postalCode = $("#Player_Player_Address_PostalCode").val();
                    if (!isValidPostalCode(postalCode)) {

                        $('#Player_Player_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s postal code is not valid.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Player_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_BirthDate').value == '' ||
                    whitespace.test(document.getElementById('Player_BirthDate').value)) {

                    $('#Player_BirthDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s birth date is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_BirthDate').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_BirthDate').value != '' &&
                    !whitespace.test(document.getElementById('Player_BirthDate').value)) {
                    var date = $("#Player_BirthDate").val();
                    if (!validate_date2(date)) {
                        $('#Player_BirthDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s birth date format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_BirthDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_Player_WorkPhone').value == '' ||
                    whitespace.test(document.getElementById('Player_Player_WorkPhone').value)) {

                    $('#Player_Player_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s phone is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Player_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('Player_Player_WorkPhone').value != '' &&
                    !whitespace.test(document.getElementById('Player_Player_WorkPhone').value)) {
                    var phone = $("#Player_Player_WorkPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#Player_Player_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s work phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Player_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_Player_MainPhone').value == '' ||
                    whitespace.test(document.getElementById('Player_Player_MainPhone').value)) {

                    $('#Player_Player_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s Cell is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Player_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Player_MainPhone').value != '' &&
                    !whitespace.test(document.getElementById('Player_Player_MainPhone').value)) {
                    var phone = $("#Player_Player_MainPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#Player_Player_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s main phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Player_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }
                if (document.getElementById('Player_Player_Email').value == '' ||
                    whitespace.test(document.getElementById('Player_Player_Email').value)) {

                    $('#Player_Player_Email').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s email is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Player_Email').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Player_Email').value != '' &&
                    !whitespace.test(document.getElementById('Player_Player_Email').value)) {
                    var email = $("#Player_Player_Email").val();
                    if (!isValidEmail(email)) {

                        $('#Player_Player_Email').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s email is not a valid email address.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Player_Email').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_School').value == '' ||
                    whitespace.test(document.getElementById('Player_School').value)) {

                    $('#Player_School').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s school name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_School').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_BCMedicalNumber').value == '' ||
                    whitespace.test(document.getElementById('Player_BCMedicalNumber').value)) {

                    $('#Player_BCMedicalNumber').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s medical number is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_BCMedicalNumber').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('Player_BCMedicalNumber').value != '' &&
                    !whitespace.test(document.getElementById('Player_BCMedicalNumber').value)) {
                    var medicalNum = $("#Player_BCMedicalNumber").val();
                    if (!isValidMedicalNumber(medicalNum)) {

                        $('#Player_BCMedicalNumber').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s medical number is not valid.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_BCMedicalNumber').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }


                if (document.getElementById('Player_Guardian1_LastName').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian1_LastName').value)) {

                    $('#Player_Guardian1_LastName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Mother\'s last name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian1_LastName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian1_FirstName').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian1_FirstName').value)) {

                    $('#Player_Guardian1_FirstName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Mother\'s first name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian1_FirstName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian1_Email').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian1_Email').value)) {

                    $('#Player_Guardian1_Email').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Mother\'s email is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian1_Email').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian1_Email').value != '' &&
                    !whitespace.test(document.getElementById('Player_Guardian1_Email').value)) {
                    var email = $("#Player_Guardian1_Email").val();
                    if (!isValidEmail(email)) {

                        $('#Player_Guardian1_Email').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian1\'s email is not a valid email address.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Guardian1_Email').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_Guardian1_MainPhone').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian1_MainPhone').value)) {

                    $('#Player_Guardian1_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Mother\'s cell is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian1_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian1_MainPhone').value != '' &&
                    !whitespace.test(document.getElementById('Player_Guardian1_MainPhone').value)) {
                    var phone = $("#Player_Guardian1_MainPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#Player_Guardian1_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian1\'s cell phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Guardian1_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_Guardian1_WorkPhone').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian1_WorkPhone').value)) {

                    $('#Player_Guardian1_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Mother\'s phone is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian1_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian1_WorkPhone').value != '' &&
                    !whitespace.test(document.getElementById('Player_Guardian1_WorkPhone').value)) {
                    var phone = $("#Player_Guardian1_WorkPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#Player_Guardian1_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian1\'s work phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Guardian1_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }


                if (document.getElementById('Player_Guardian1_Address_PostalCode').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian1_Address_PostalCode').value)) {
                    $('#Player_Guardian1_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                }
                if (document.getElementById('Player_Guardian1_Address_PostalCode').value != '' &&
                    !whitespace.test(document.getElementById('Player_Guardian1_Address_PostalCode').value)) {
                    var postalCode = $("#Player_Guardian1_Address_PostalCode").val();
                    if (!isValidPostalCode(postalCode)) {

                        $('#Player_Guardian1_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian1\'s postal code is not valid.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Guardian1_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_Guardian2_LastName').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian2_LastName').value)) {

                    $('#Player_Guardian2_LastName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Father\'s last name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian2_LastName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian2_FirstName').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian2_FirstName').value)) {

                    $('#Player_Guardian2_FirstName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Father\'s first name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian2_FirstName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian2_Email').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian2_Email').value)) {

                    $('#Player_Guardian2_Email').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Father\'s email is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian2_Email').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian2_Email').value != '' &&
                    !whitespace.test(document.getElementById('Player_Guardian2_Email').value)) {
                    var email = $("#Player_Guardian2_Email").val();
                    if (!isValidEmail(email)) {

                        $('#Player_Guardian2_Email').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian2\'s email is not a valid email address.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Guardian2_Email').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_Guardian2_MainPhone').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian2_MainPhone').value)) {

                    $('#Player_Guardian2_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Father\'s cell is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian2_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian2_MainPhone').value != '' &&
                    !whitespace.test(document.getElementById('Player_Guardian2_MainPhone').value)) {
                    var phone = $("#Player_Guardian2_MainPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#Player_Guardian2_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian2\'s cell phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Guardian2_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_Guardian2_WorkPhone').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian2_WorkPhone').value)) {

                    $('#Player_Guardian2_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Father\'s phone is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#Player_Guardian2_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('Player_Guardian2_WorkPhone').value != '' &&
                    !whitespace.test(document.getElementById('Player_Guardian2_WorkPhone').value)) {
                    var phone = $("#Player_Guardian2_WorkPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#Player_Guardian2_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian2\'s work phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Guardian2_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('Player_Guardian2_Address_PostalCode').value == '' ||
                    whitespace.test(document.getElementById('Player_Guardian2_Address_PostalCode').value)) {
                    $('#Player_Guardian2_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('Player_Guardian2_Address_PostalCode').value != '' &&
                    !whitespace.test(document.getElementById('Player_Guardian2_Address_PostalCode').value)) {
                    var postalCode = $("#Player_Guardian2_Address_PostalCode").val();
                    if (!isValidPostalCode(postalCode)) {

                        $('#Player_Guardian2_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian2\'s postal code is not valid.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#Player_Guardian2_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (!status)
                    return false;

            });
        });
 
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Players Registration"); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <%} %>
    <div id="pageContent">
        <% using (Html.BeginForm())
           {
               if (Model != null)
               {
        %>
        <h1>
            Manage New Player</h1>
        <%: Html.ValidationSummary(true)%>
        <div id="StatusPanel" style="color: Red;">
        </div>
        <div id="PlayerPanel" style="height: 300px;">
            <h3>
                Player's Information</h3>
            <table border="0" width="300px" style="float: left; border-right: 0px solid gainsboro;
                padding-right: 30px;">
                <tr>
                    <td>
                        Last Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.HiddenFor(m => Model.Player.ID)%>
                            <%: Html.HiddenFor(model => model.Player.Player.ID) %>
                            <%: Html.TextBoxFor(model => model.Player.Player.LastName)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Player.LastName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Player.FirstName)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Player.FirstName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address:
                        <div class="editor-field" style="float: right">
                            <%: Html.HiddenFor(m => Model.Player.Player.Address.Id)%>
                            <%: Html.HiddenFor(model => model.Player.Player.Address.Id) %>
                            <%: Html.TextBoxFor(model => model.Player.Player.Address.StreetAddress)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Player.Address.StreetAddress)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        City:
                        <div class="editor-field" style="float: right;">
                            <%: Html.TextBoxFor(model => model.Player.Player.Address.City)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Player.Address.City)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province:<div class="editor-field" style="float: right">
                            <select id="PlayerApplication_Player_Address_Province" style="width: 157px;" name="Player.Address.Province">
                                <option value="AB">AB</option>
                                <option value="BC">BC</option>
                                <option value="MB">MB</option>
                                <option value="NB">NB</option>
                                <option value="NL">NL</option>
                                <option value="ON">ON</option>
                                <option value="SK">SK</option>
                            </select>
                            <%: Html.HiddenFor(model => model.Player.Player.Address.Province, Model.Player.Player.Address.Province)%>
                            <script type="text/javascript">
                                $(function () {
                                    $('#PlayerApplication_Player_Address_Province').val($('#Player_Player_Address_Province').attr("value"));
                                });
                            </script>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Postal Code:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Player.Address.PostalCode)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Player.Address.PostalCode)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Previous Team:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.PreviousTeam)%>
                            <%: Html.ValidationMessageFor(model => model.Player.PreviousTeam)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Medical Alerts?:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.MedicalAlert)%>
                            <%: Html.ValidationMessageFor(model => model.Player.MedicalAlert)%>
                        </div>
                    </td>
                </tr>
            </table>
            <table style="float: left; margin-left: 50px; border-left: 0px solid gainsboro;">
                <tr>
                    <td>
                        Birthdate [mm/dd/yyyy]:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model=> model.Player.BirthDate) %>
                            <%: Html.ValidationMessageFor(model => model.Player.BirthDate) %>
                            <script type="text/javascript">
                                $('#Player_BirthDate').val($('#Player_BirthDate').val().split(" ", 2)[0])
                            </script>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Gender:<div class="editor-field" style="float: right">
                            <select id="PlayerApplication_Gender" style="width: 157px;" name="Player.Gender">
                                <option value="M">Male</option>
                                <option value="F">Female</option>
                            </select>
                            <%: Html.HiddenFor(model => model.Player.Gender, Model.Player.Gender)%>
                            <script type="text/javascript">
                                $(function () {
                                    $('#PlayerApplication_Gender').val($('#PlayerApplication_Gender').attr("value"));
                                });
                            </script>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Home Ph#:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Player.WorkPhone)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Player.WorkPhone)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cell Ph#:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Player.MainPhone)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Player.MainPhone)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Player.Email)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Player.Email)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        School:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.School)%>
                            <%: Html.ValidationMessageFor(model => model.Player.School)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Medical #:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.BCMedicalNumber)%>
                            <%: Html.ValidationMessageFor(model => model.Player.BCMedicalNumber)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Paid<div class="editor-field" style="float: right">
                            <%: Html.CheckBoxFor(model => model.Player.Paid)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Paid)%>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="GuardianPanel" style="height: 400px;">
            <h3>
                Emergency Contact1</h3>
            <table style="width: 350px; float: left;">
                <tr>
                    <td>
                        Last Name:<div class="editor-field" style="float: right">
                            <%: Html.HiddenFor(model => model.Player.Guardian1.ID) %>
                            <%: Html.TextBoxFor(model => model.Player.Guardian1.LastName)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian1.LastName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian1.FirstName)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian1.FirstName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address (if different):
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian1.Address.StreetAddress)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian1.Address.StreetAddress)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        City (if different):<div class="editor-field" style="float: right">
                            <%: Html.HiddenFor(m => Model.Player.Guardian1.Address.Id)%>
                            <%: Html.HiddenFor(model => model.Player.Guardian1.Address.Id)%>
                            <%: Html.TextBoxFor(model => model.Player.Guardian1.Address.City)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian1.Address.City)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province:<div class="editor-field" style="float: right">
                            <select id="PlayerApplication_Guardian1_Address_Province" style="width: 157px;" name="Player.Guardian1.Address.Province">
                                <option value="AB">AB</option>
                                <option value="BC">BC</option>
                                <option value="MB">MB</option>
                                <option value="NB">NB</option>
                                <option value="NL">NL</option>
                                <option value="ON">ON</option>
                                <option value="SK">SK</option>
                            </select>
                            <%: Html.HiddenFor(model => model.Player.Guardian1.Address.Province, Model.Player.Guardian1.Address.Province)%>
                            <script type="text/javascript">
                                $(function () {
                                    $('#PlayerApplication_Guardian1_Address_Province').val($('#Player_Guardian1_Address_Province').attr("value"));
                                });
                            </script>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Postal:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian1.Address.PostalCode)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian1.Address.PostalCode)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian1.Email)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian1.Email)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cell Ph#:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian1.MainPhone)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian1.MainPhone)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Home Ph#:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian1.WorkPhone)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian1.WorkPhone)%>
                        </div>
                    </td>
                </tr>
            </table>

            <!-- <input type="checkbox"id="guardian2" name="guardian2" value="true" checked="checked"/>Have the second guardian?<br />-->
            <table id="guardian2_table" style="float: left; width: 350px; margin-top: -40px; margin-left: 100px;">
                <tr>
                    <td>
                        <h3>
                            Emergency Contact 2</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.HiddenFor(model => model.Player.Guardian2.ID) %>
                            <%: Html.TextBoxFor(model => model.Player.Guardian2.LastName)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian2.LastName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian2.FirstName)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian2.FirstName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address (if different):<div class="editor-field" style="float: right">
                            <%: Html.HiddenFor(m => Model.Player.Guardian2.Address.Id)%>
                            <%: Html.HiddenFor(model => model.Player.Guardian2.Address.Id)%>
                            <%: Html.TextBoxFor(model => model.Player.Guardian2.Address.StreetAddress)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian2.Address.StreetAddress)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        City (if different):<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian2.Address.City)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian2.Address.City)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province:<div class="editor-field" style="float: right">
                            <select id="PlayerApplication_Guardian2_Address_Province" style="width: 157px;" name="Player.Guardian2.Address.Province">
                                <option value="AB">AB</option>
                                <option value="BC">BC</option>
                                <option value="MB">MB</option>
                                <option value="NB">NB</option>
                                <option value="NL">NL</option>
                                <option value="ON">ON</option>
                                <option value="SK">SK</option>
                            </select>
                            <%: Html.HiddenFor(model => model.Player.Guardian2.Address.Province, Model.Player.Guardian2.Address.Province)%>
                            <script type="text/javascript">
                                $(function () {
                                    $('#PlayerApplication_Guardian2_Address_Province').val($('#Player_Guardian2_Address_Province').attr("value"));
                                });
                            </script>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Postal:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian2.Address.PostalCode)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian2.Address.PostalCode)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:<div class="editor-field" style="float: right;">
                            <%: Html.TextBoxFor(model => model.Player.Guardian2.Email)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian2.Email)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cell Ph#:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian2.MainPhone)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian2.MainPhone)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Home Ph#:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.Player.Guardian2.WorkPhone)%>
                            <%: Html.ValidationMessageFor(model => model.Player.Guardian2.WorkPhone)%>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="editor-field">
                Assign to Coach:<br />
                <%: Html.DropDownListFor(m => m.Coaches, Model.Coaches, "-- Select Coach --")%>
                <%: Html.HiddenFor(model => model.Player.Coach.ID, Model.Player.Coach.ID)%>
            </div>
                <input type="submit" value="Update" />
        </div>
        <% }
           }
        %>
        <%    if (Model != null)
              {
                  using (Html.BeginForm("DeactivatePlayer", "Registrar", new { id = Model.Player.ID }, FormMethod.Get))
                  { %>
        <input type="submit" value="Deactivate Enrollment" />
        <% }
                  }%><br />
        <%: Html.ActionLink("<< Go Back","ManagePlayerApplications") %>
    </div>
</asp:Content>
