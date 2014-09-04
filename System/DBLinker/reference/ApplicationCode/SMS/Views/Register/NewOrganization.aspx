<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.RegisterNewOrganizationView>"%>
    
<asp:Content ID="Content3" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
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
            $('form').submit(function () {



                //do validation here
                var organizationFormStatus = true;
                var whitespace = /^\s+$/;

                document.getElementById('StatusPanel').innerHTML = "";
                if (document.getElementById('AuthorizationCode').value == '' ||
                    whitespace.test(document.getElementById('AuthorizationCode').value)) {

                    $('#AuthorizationCode').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Authorization Code is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#AuthorizationCode').removeClass("HighLightError").addClass('UnHighlightError');
                }
                if (document.getElementById('UserAccount_Person_Organization_Name').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_Organization_Name').value)) {

                    $('#UserAccount_Person_Organization_Name').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s name is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_Organization_Name').removeClass("HighLightError").addClass('UnHighlightError');
                }
                if (document.getElementById('UserAccount_Person_LastName').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_LastName').value)) {

                    $('#UserAccount_Person_LastName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization Contact\'s last name is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_LastName').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('UserAccount_Person_FirstName').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_FirstName').value)) {

                    $('#UserAccount_Person_FirstName').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization Contact\'s first name is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_FirstName').removeClass("HighLightError").addClass('UnHighlightError');
                }
                if (document.getElementById('UserAccount_Username').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Username').value)) {

                    $('#UserAccount_Username').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Username is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Username').removeClass("HighLightError").addClass('UnHighlightError');
                }
                                
                if (document.getElementById('UserAccount_Password').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Password').value)) {

                    $('#UserAccount_Password').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Password is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Password').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('UserAccount_ConfirmPassword').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_ConfirmPassword').value)) {

                    $('#UserAccount_ConfirmPassword').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Confirm Password is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_ConfirmPassword').removeClass("HighLightError").addClass('UnHighlightError');
                }
                if (document.getElementById('UserAccount_Person_Organization_Address_StreetAddress').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_Organization_Address_StreetAddress').value)) {

                    $('#UserAccount_Person_Organization_Address_StreetAddress').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s address is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_Organization_Address_StreetAddress').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('UserAccount_Person_Organization_Address_City').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_Organization_Address_City').value)) {

                    $('#UserAccount_Person_Organization_Address_City').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s city is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_Organization_Address_City').removeClass("HighLightError").addClass('UnHighlightError');
                }


                if (document.getElementById('UserAccount_Person_Organization_Address_PostalCode').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_Organization_Address_PostalCode').value)) {

                    $('#UserAccount_Person_Organization_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s postal code is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_Organization_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('UserAccount_Person_Organization_Address_PostalCode').value != '' &&
                    !whitespace.test(document.getElementById('UserAccount_Person_Organization_Address_PostalCode').value)) {
                    var postalCode = $("#UserAccount_Person_Organization_Address_PostalCode").val();
                    if (!isValidPostalCode(postalCode)) {

                        $('#UserAccount_Person_Organization_Address_PostalCode').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s postal code is not valid.</li></ul>';
                        organizationFormStatus = false;
                    }
                    else {
                        $('#UserAccount_Person_Organization_Address_PostalCode').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('UserAccount_Person_MainPhone').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_MainPhone').value)) {

                    $('#UserAccount_Person_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s phone is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('UserAccount_Person_MainPhone').value != '' &&
                    !whitespace.test(document.getElementById('UserAccount_Person_MainPhone').value)) {
                    var phone = $("#UserAccount_Person_MainPhone").val();
                    if (!isValidPhoneNumber(phone)) {

                        $('#UserAccount_Person_MainPhone').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s phone format is not correct.</li></ul>';
                        organizationFormStatus = false;
                    }
                    else {
                        $('#UserAccount_Person_MainPhone').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('UserAccount_Person_Email').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_Email').value)) {

                    $('#UserAccount_Person_Email').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s email is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_Email').removeClass("HighLightError").addClass('UnHighlightError');
                }

                if (document.getElementById('UserAccount_Person_Email').value != '' &&
                    !whitespace.test(document.getElementById('UserAccount_Person_Email').value)) {
                    var email = $("#UserAccount_Person_Email").val();
                    if (!isValidEmail(email)) {

                        $('#UserAccount_Person_Email').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s email is not a valid email address.</li></ul>';
                        organizationFormStatus = false;
                    }
                    else {
                        $('#UserAccount_Person_Email').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }

                if (document.getElementById('UserAccount_Person_Organization_Url').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Person_Organization_Url').value)) {

                    $('#UserAccount_Person_Organization_Url').removeClass('UnHighlightError').addClass('HighlightError');
                    document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s URL is required.</li></ul>';
                    organizationFormStatus = false;
                }
                else {
                    $('#UserAccount_Person_Organization_Url').removeClass("HighLightError").addClass('UnHighlightError');
                }
                if (document.getElementById('UserAccount_Person_Organization_Url').value != '' &&
                    !whitespace.test(document.getElementById('UserAUserAccount_Person_Organization_Urlccount_Person_Email').value)) {
                    var email = $("#UserAccount_Person_Organization_Url").val();
                    if (!isValidUrl(url)) {

                        $('#UserAccount_Person_Organization_Url').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Organization\'s url is not a valid url address.</li></ul>';
                        organizationFormStatus = false;
                    }
                    else {
                        $('#UserAccount_Person_Email').removeClass("HighLightError").addClass('UnHighlightError');
                    }
                }
                       
                if ((document.getElementById('UserAccount_ConfirmPassword').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_ConfirmPassword').value))
                    &&
                    (document.getElementById('UserAccount_Password').value == '' ||
                    whitespace.test(document.getElementById('UserAccount_Password').value))
                    ) {

                }
                else {
                    if (document.getElementById('UserAccount_ConfirmPassword').value != document.getElementById('UserAccount_Password').value) {
                        $('#UserAccount_Password').removeClass('UnHighlightError').addClass('HighlightError');
                        $('#UserAccount_ConfirmPassword').removeClass('UnHighlightError').addClass('HighlightError');
                        document.getElementById('StatusPanel').innerHTML += '<ul><li>Password/Confirm Passwords do not match.</li></ul>';
                        organizationFormStatus = false;
                    }
                    else {

                        $('#UserAccount_Password').removeClass("HighLightError").addClass('UnHighlightError');
                        $('#UserAccount_ConfirmPassword').removeClass("HighLightError").addClass('UnHighlightError');

                    }
                }

                if (!organizationFormStatus)
                    return false;

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
            Registration - New Organization</h1>
        <%: Html.ValidationSummary(true)%>
        <div id="StatusPanel" style="color: Red;"></div>
        <div id="PlayerPanel" style="height: 100%;">
            <h3>
                Organization's Information</h3>
            <table border="0" width="80%" style=" border-right: 0px solid gainsboro;
                padding-right: 30px;">
                <tr>
                    <td>
                        Authorization Code: 
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.AuthorizationCode)%>
                            <%: Html.ValidationMessageFor(model => model.AuthorizationCode)%>
                        </div>
                    </td>
                    </tr>
                <tr>
                    <td>
                        Organization Name: 
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.Organization.Name)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Organization.Name)%>
                        </div>
                     </td> 
                </tr>
                 <tr>
                    <td>
                        Firstname:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.FirstName)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Username)%>
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Lastname:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.LastName)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Username)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Username:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.UserAccount.Username)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Username)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password:
                        <div class="editor-field" style="float: right">
                            <%: Html.PasswordFor(model => model.UserAccount.Password)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Password)%>
                        </div>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm Password:
                        <div class="editor-field" style="float: right">
                            <%: Html.PasswordFor(model => model.UserAccount.ConfirmPassword)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.ConfirmPassword)%>
                        </div>
                    </td>
                </tr> 
                <tr>
                    <td>
                        Address:
                        <div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.Organization.Address.StreetAddress)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Organization.Address.StreetAddress)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        City:
                        <div class="editor-field" style="float: right;">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.Organization.Address.City)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Organization.Address.City)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province:<div class="editor-field" style="float: right">
                            <select id="UserAccount_Person_Organization_Address_Province" style="width: 157px;" name="UserAccount.Person.Organization.Address.Province">
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
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.Organization.Address.PostalCode)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Organization.Address.PostalCode)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Phone:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.MainPhone)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.MainPhone)%>
                        </div>
                    </td>
                     <td>
                        [Must be 10 digits. e.g. 6041234567]
                    </td>
                </tr>
                 <tr>
                    <td>
                        Email:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.Email)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Email)%>
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td>
                        URL:<div class="editor-field" style="float: right">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.Organization.Url)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Organization.Url)%>
                        </div>
                    </td>
                </tr>
                <tr>
                <td>
                  <input id="btnSubmit" type="submit" value="Register"/>
                </td>
                </tr>
                                     
            </table>
                                          
             </div> 
            
        <% }
           }%>
    </div>
</asp:Content>

