<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.RegisterNewPlayerView>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/validation.js") %>"></script>
    <script type="text/javascript">
        $(function () {
            $('#Register').attr("id", "currentPage");
            $('#PlayerApplication_Player_Address_Province').val('BC');
            $('#PlayerApplication_Guardian1_Address_Province').val('BC');
            $('#PlayerApplication_Guardian2_Address_Province').val('BC');

            document.getElementById('GuardianPanel').style.display = 'none';
            document.getElementById('AgreementPanel').style.display = 'none';
            document.getElementById('btnSubmit').disabled = true;


            $('#PlayerApplication_ConsentApproved').click(function () {
                if ($('#PlayerApplication_ConsentApproved:checked').length > 0) {
                    document.getElementById('btnSubmit').disabled = false;
                }
                else {
                    document.getElementById('btnSubmit').disabled = true;
                }
            });
            $('#lnkBackToPlayer').click(function () {
                var status = true;
                status = GuardianValidation();

                document.getElementById('StatusPanel').innerHTML = "";
                document.getElementById('PlayerPanel').style.display = 'block';
                document.getElementById('GuardianPanel').style.display = 'none';
                document.getElementById('AgreementPanel').style.display = 'none';

            });
            $('#lnkAdvanceToConsent').click(function () {

                var status = true;
                status = GuardianValidation();

                if (status == true) {
                    document.getElementById('PlayerPanel').style.display = 'none';
                    document.getElementById('GuardianPanel').style.display = 'none';
                    document.getElementById('AgreementPanel').style.display = 'block';
                }

            });

            function GuardianValidation() {
                var status = true;
                var whitespace = /^\s+$/;

                document.getElementById('StatusPanel').innerHTML = "";

                if (document.getElementById('PlayerApplication_Guardian1_LastName').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian1_LastName').value)) {

                    $('#PlayerApplication_Guardian1_LastName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 1 last name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian1_LastName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian1_FirstName').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian1_FirstName').value)) {

                    $('#PlayerApplication_Guardian1_FirstName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 1 first name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian1_FirstName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian1_Email').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian1_Email').value)) {

                    $('#PlayerApplication_Guardian1_Email').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 1 email is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian1_Email').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian1_Email').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Guardian1_Email').value)) {
                    var email = $("#PlayerApplication_Guardian1_Email").val();
                    if (!isValidEmail(email)) {

                        $('#PlayerApplication_Guardian1_Email').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian1\'s email is not a valid email address.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#PlayerApplication_Guardian1_Email').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }


                if (document.getElementById('PlayerApplication_Guardian1_MainPhone').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian1_MainPhone').value)) {

                    $('#PlayerApplication_Guardian1_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 1 cell is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian1_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian1_MainPhone').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Guardian1_MainPhone').value)) {
                    var phone = $("#PlayerApplication_Guardian1_MainPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#PlayerApplication_Guardian1_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian1\'s cell phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#PlayerApplication_Guardian1_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }


                if (document.getElementById('PlayerApplication_Guardian1_WorkPhone').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian1_WorkPhone').value)) {

                    $('#PlayerApplication_Guardian1_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 1 phone is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian1_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian1_WorkPhone').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Guardian1_WorkPhone').value)) {
                    var phone = $("#PlayerApplication_Guardian1_WorkPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#PlayerApplication_Guardian1_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian1\'s work phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#PlayerApplication_Guardian1_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('PlayerApplication_Guardian1_Address_PostalCode').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Guardian1_Address_PostalCode').value)) {
                    var postalCode = $("#PlayerApplication_Guardian1_Address_PostalCode").val();
                    if (!isValidPostalCode(postalCode)) {

                        $('#PlayerApplication_Guardian1_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian1\'s postal code is not valid.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#PlayerApplication_Guardian1_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('PlayerApplication_Guardian2_LastName').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian2_LastName').value)) {

                    $('#PlayerApplication_Guardian2_LastName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 2 last name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian2_LastName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian2_FirstName').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian2_FirstName').value)) {

                    $('#PlayerApplication_Guardian2_FirstName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 2 first name is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian2_FirstName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian2_Email').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian2_Email').value)) {

                    $('#PlayerApplication_Guardian2_Email').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 2 email is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian2_Email').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian2_Email').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Guardian2_Email').value)) {
                    var email = $("#PlayerApplication_Guardian2_Email").val();
                    if (!isValidEmail(email)) {

                        $('#PlayerApplication_Guardian2_Email').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian2\'s email is not a valid email address.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#PlayerApplication_Guardian2_Email').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('PlayerApplication_Guardian2_MainPhone').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian2_MainPhone').value)) {

                    $('#PlayerApplication_Guardian2_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 2 cell is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian2_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian2_MainPhone').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Guardian2_MainPhone').value)) {
                    var phone = $("#PlayerApplication_Guardian2_MainPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#PlayerApplication_Guardian2_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian2\'s cell phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#PlayerApplication_Guardian2_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('PlayerApplication_Guardian2_WorkPhone').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian2_WorkPhone').value)) {

                    $('#PlayerApplication_Guardian2_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian 2 phone is required.</li></ul>';
                    status = false;
                }
                else {
                    $('#PlayerApplication_Guardian2_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian2_WorkPhone').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Guardian2_WorkPhone').value)) {
                    var phone = $("#PlayerApplication_Guardian2_WorkPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#PlayerApplication_Guardian2_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian2\'s work phone format is not correct.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#PlayerApplication_Guardian2_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('PlayerApplication_Guardian2_Address_PostalCode').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Guardian2_Address_PostalCode').value)) {
                    $('#PlayerApplication_Guardian2_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Guardian2_Address_PostalCode').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Guardian2_Address_PostalCode').value)) {
                    var postalCode = $("#PlayerApplication_Guardian2_Address_PostalCode").val();
                    if (!isValidPostalCode(postalCode)) {

                        $('#PlayerApplication_Guardian2_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Guardian2\'s postal code is not valid.</li></ul>';
                        status = false;
                    }
                    else {
                        $('#PlayerApplication_Guardian2_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                return status;
            }


            $("#PlayerApplication_BirthDate").change(function () {

                var date = $("#PlayerApplication_BirthDate").val();
                if (!validate_date1(date)) {
                    return false;
                }
                return true;
            });

            $('#lnkAdvanceToGuardian').click(function () {

                //do validation here
                var playerFormStatus = true;
                var whitespace = /^\s+$/;

                document.getElementById('StatusPanel').innerHTML = "";




                if (document.getElementById('PlayerApplication_Player_LastName').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Player_LastName').value)) {

                    $('#PlayerApplication_Player_LastName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s last name is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_Player_LastName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Player_FirstName').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Player_FirstName').value)) {

                    $('#PlayerApplication_Player_FirstName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s first name is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_Player_FirstName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Player_Address_StreetAddress').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Player_Address_StreetAddress').value)) {

                    $('#PlayerApplication_Player_Address_StreetAddress').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s address is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_Player_Address_StreetAddress').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Player_Address_City').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Player_Address_City').value)) {

                    $('#PlayerApplication_Player_Address_City').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s city is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_Player_Address_City').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('PlayerApplication_Player_Address_PostalCode').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Player_Address_PostalCode').value)) {

                    $('#PlayerApplication_Player_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s postal code is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_Player_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Player_Address_PostalCode').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Player_Address_PostalCode').value)) {
                    var postalCode = $("#PlayerApplication_Player_Address_PostalCode").val();
                    if (!isValidPostalCode(postalCode)) {

                        $('#PlayerApplication_Player_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s postal code is not valid.</li></ul>';
                        playerFormStatus = false;
                    }
                    else {
                        $('#PlayerApplication_Player_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('PlayerApplication_BirthDate').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_BirthDate').value)) {

                    $('#PlayerApplication_BirthDate').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s birth date is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_BirthDate').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_BirthDate').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_BirthDate').value)) {
                    var date = $("#PlayerApplication_BirthDate").val();
                    if (!validate_date2(date)) {

                        $('#PlayerApplication_BirthDate').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s birth date format is not correct.</li></ul>';
                        playerFormStatus = false;
                    }
                    else {
                        $('#PlayerApplication_BirthDate').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }


                if (document.getElementById('PlayerApplication_Player_WorkPhone').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Player_WorkPhone').value)) {

                    $('#PlayerApplication_Player_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s phone is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_Player_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Player_WorkPhone').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Player_WorkPhone').value)) {
                    var phone = $("#PlayerApplication_Player_WorkPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#PlayerApplication_Player_WorkPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s work phone format is not correct.</li></ul>';
                        playerFormStatus = false;
                    }
                    else {
                        $('#PlayerApplication_Player_WorkPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('PlayerApplication_Player_MainPhone').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Player_MainPhone').value)) {

                    $('#PlayerApplication_Player_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s Cell Phone is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_Player_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Player_MainPhone').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Player_MainPhone').value)) {
                    var phone = $("#PlayerApplication_Player_MainPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#PlayerApplication_Player_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s Cell Phone format is not correct.</li></ul>';
                        playerFormStatus = false;
                    }
                    else {
                        $('#PlayerApplication_Player_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('PlayerApplication_Player_Email').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_Player_Email').value)) {

                    $('#PlayerApplication_Player_Email').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s email is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_Player_Email').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_Player_Email').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_Player_Email').value)) {
                    var email = $("#PlayerApplication_Player_Email").val();
                    if (!isValidEmail(email)) {

                        $('#PlayerApplication_Player_Email').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s email is not a valid email address.</li></ul>';
                        playerFormStatus = false;
                    }
                    else {
                        $('#PlayerApplication_Player_Email').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }


                if (document.getElementById('PlayerApplication_School').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_School').value)) {

                    $('#PlayerApplication_School').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s school name is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_School').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('PlayerApplication_BCMedicalNumber').value == '' ||
                    whitespace.test(document.getElementById('PlayerApplication_BCMedicalNumber').value)) {

                    $('#PlayerApplication_BCMedicalNumber').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s medical number is required.</li></ul>';
                    playerFormStatus = false;
                }
                else {
                    $('#PlayerApplication_BCMedicalNumber').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('PlayerApplication_BCMedicalNumber').value != '' &&
                    !whitespace.test(document.getElementById('PlayerApplication_BCMedicalNumber').value)) {
                    var medicalNum = $("#PlayerApplication_BCMedicalNumber").val();
                    if (!isValidMedicalNumber(medicalNum)) {

                        $('#PlayerApplication_BCMedicalNumber').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Player\'s medical number is not valid.</li></ul>';
                        playerFormStatus = false;
                    }
                    else {
                        $('#PlayerApplication_BCMedicalNumber').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }



                if (playerFormStatus == true) {

                    document.getElementById('PlayerPanel').style.display = 'none';
                    document.getElementById('GuardianPanel').style.display = 'block';
                    document.getElementById('AgreementPanel').style.display = 'none';


                }

            });










            $('#lnkBackToGuardian').click(function () {
                document.getElementById('PlayerPanel').style.display = 'none';
                document.getElementById('GuardianPanel').style.display = 'block';
                document.getElementById('AgreementPanel').style.display = 'none';
            });




        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", ""); %>
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
            Registration - New Player</h1>
        <%: Html.ValidationSummary(true)%>
        <div id="StatusPanel" style="color: Red;">
        </div>
        <div id="PlayerPanel" style="height: 400px;">
            <h3>
                Player's Information</h3>
            <table border="0" width="300px" style="float: left; border-right: 0px solid gainsboro;
                padding-right: 30px;">
                <tr>
                    <td>
                        Last Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Player.LastName)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Player.LastName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Player.FirstName)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Player.FirstName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Player.Address.StreetAddress)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Player.Address.StreetAddress)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        City:
                        <div class="editor-field" style="float: right;">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Player.Address.City)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Player.Address.City)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province:<div class="editor-field" style="float: right">
                            <select id="PlayerApplication_Player_Address_Province" style="width: 157px;" name="PlayerApplication.Player.Address.Province">
                                <option value="AB">AB</option>
                                <option value="BC">BC</option>
                                <option value="MB">MB</option>
                                <option value="NB">NB</option>
                                <option value="NL">NL</option>
                                <option value="ON">ON</option>
                                <option value="SK">SK</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Postal Code:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Player.Address.PostalCode)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Player.Address.PostalCode)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Previous Team:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.PreviousTeam)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.PreviousTeam)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Medical Alerts:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.MedicalAlert)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.MedicalAlert)%>
                        </div>
                    </td>
                </tr>
            </table>
            <table style="float: left; margin-left: 50px; border-left: 0px solid gainsboro;">
                <tr>
                    <td>
                        Birthdate:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.BirthDate)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.BirthDate)%>
                        </div>
                    </td>
                    <td>[mm/dd/yyyy]</td>
                </tr>
                <tr>
                    <td>
                        Gender:<div class="editor-field" style="float: right">
                            <select id="PlayerApplication_Gender" style="width: 157px;" name="PlayerApplication.Gender">
                                <option value="M">Male</option>
                                <option value="F">Female</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Home Ph#:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Player.WorkPhone)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Player.WorkPhone)%>
                        </div>
                    </td>
                    <td>
                        [e.g. 6041234567]
                    </td>
                </tr>
                <tr>
                    <td>
                        Cell Ph#:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Player.MainPhone)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Player.MainPhone)%>
                        </div>
                    </td>
                    <td>
                        [e.g. 6041234567]
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Player.Email)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Player.Email)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        School:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.School)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.School)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Medical #:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.BCMedicalNumber)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.BCMedicalNumber)%>
                        </div>
                    </td>
                    <td>
                        [Must be 10 digits. e.g. 1234567890]
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <a id="lnkAdvanceToGuardian" href="#" style="float: left; margin-left: 450px;">Next
                >></a>
        </div>
        <div id="GuardianPanel" style="height: 400px;">
            <h3>
                Emergency Contact 1</h3>
            <table style="width: 350px; float: left;">
                <tr>
                    <td>
                        Last Name:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian1.LastName)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian1.LastName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian1.FirstName)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian1.FirstName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address (if different):
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian1.Address.StreetAddress)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian1.Address.StreetAddress)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        City (if different):<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian1.Address.City)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian1.Address.City)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province:<div class="editor-field" style="float: right">
                            <select id="PlayerApplication_Guardian1_Address_Province" style="width: 157px;" name="PlayerApplication.Guardian1.Address.Province">
                                <option value="AB">AB</option>
                                <option value="BC">BC</option>
                                <option value="MB">MB</option>
                                <option value="NB">NB</option>
                                <option value="NL">NL</option>
                                <option value="ON">ON</option>
                                <option value="SK">SK</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Postal:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian1.Address.PostalCode)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian1.Address.PostalCode)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian1.Email)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian1.Email)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cell Ph#:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian1.MainPhone)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian1.MainPhone)%>
                        </div>
                    </td>
                    <td>
                        [e.g.6041234567]
                    </td>
                </tr>
                <tr>
                    <td>
                        Home Ph#:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian1.WorkPhone)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian1.WorkPhone)%>
                        </div>
                    </td>
                    <td>
                        [e.g.6041234567]
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        <a id="lnkBackToPlayer" href="#" style="float: right; margin-right: 150px;">&lt;&lt;
                            Back</a>
                    </td>
                </tr>
            </table>
            <table style="float: left; width: 350px; margin-top: -50px; margin-left: 150px;">
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
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian2.LastName)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian2.LastName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian2.FirstName)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian2.FirstName)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address (if different):<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian2.Address.StreetAddress)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian2.Address.StreetAddress)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        City (if different):<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian2.Address.City)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian2.Address.City)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province:<div class="editor-field" style="float: right">
                            <select id="PlayerApplication_Guardian2_Address_Province" style="width: 157px;" name="PlayerApplication.Guardian2.Address.Province">
                                <option value="AB">AB</option>
                                <option value="BC">BC</option>
                                <option value="MB">MB</option>
                                <option value="NB">NB</option>
                                <option value="NL">NL</option>
                                <option value="ON">ON</option>
                                <option value="SK">SK</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Postal:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian2.Address.PostalCode)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian2.Address.PostalCode)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:<div class="editor-field" style="float: right;">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian2.Email)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian2.Email)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cell Ph#:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian2.MainPhone)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian2.MainPhone)%>
                        </div>
                    </td>
                    <td>
                        [e.g.6041234567]
                    </td>
                </tr>
                <tr>
                    <td>
                        Home Ph#:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.PlayerApplication.Guardian2.WorkPhone)%>
                            <%: Html.ValidationMessageFor(model => model.PlayerApplication.Guardian2.WorkPhone)%>
                        </div>
                    </td>
                    <td>
                       [e.g.6041234567]
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <br />
                        <br />
                        <a id="lnkAdvanceToConsent" style="padding-top: 0px;" href="#">Next >></a>
                    </td>
                </tr>
            </table>
        </div>
        <div id="AgreementPanel" style="text-align: center;">
            <p>
                <b>Guardian Consent and Indemnity Agreement:</b><br />
                I consent to the above player participating in the activities of the Phoenix FC
                Society and acknowledge that there are some risks associated with such participation.
                I release, hold harmless, and agree to indemnify the said association and its officers,
                club officials, members and agents from all injury, loss and damage which might
                be claimed against the said Association or them or any of them or on behalf of the
                said Player and arising directly or indirectly from such participation, including
                transportation.
                <br />
                <br />
                Agree
                <%: Html.CheckBoxFor(model => model.PlayerApplication.ConsentApproved)%>
                <%: Html.ValidationMessageFor(model => model.PlayerApplication.ConsentApproved)%>
                <br />
                <br />
                <br />
                <br />
                <a id="lnkBackToGuardian" href="#">&lt;&lt; Back</a><br />
                <br />
                <br />
                <input id="btnSubmit" type="submit" value="Submit Application" />
            </p>
        </div>
        <% }
           }%>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
