<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.UserAccountView>" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <script src="<%: Url.Content("~/Scripts/MicrosoftAjax.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/MicrosoftMvcValidation.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            var roleid = $('#UserAccount_Role_ID').attr("value");

            if (roleid == "794c2858-17db-462c-ab13-065b8f6719bf") {//To remove third party role because they register themselves. Admin cannot create this user
                $('#Roles').attr("disabled", "disabled");
                $('#Roles').attr("id", "OldRoles");
                $('#OldRoles').attr("name", "OldRoles");
                $('#UserAccount_Role_ID').attr("id", "Roles");
                $('#Roles').attr("name", "Roles");
                $('#Roles').attr("value", "794c2858-17db-462c-ab13-065b8f6719bf");
                $('#RolesPanel').empty();
            }
            else {
                $("#Roles option[value='794c2858-17db-462c-ab13-065b8f6719bf']").remove();
                $('#Roles').val($('#UserAccount_Role_ID').attr("value")); //Set selected role based on hidden input UserAccount.Role.ID

            }


            $('#UserAccount_Person_Address_Province').val($('#ExistingProvince').attr("value"));


        });

        
        </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Users"); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <%} %>
    <div id="pageContent">
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           {
               if (Model != null)
               { %>





        <h1>Edit User</h1>
        <%: Html.ValidationSummary()%>
        <div class="editor-label">
            First Name:
        </div>
        <%: Html.HiddenFor(m => Model.UserAccount.Person.ID)%>
        <%: Html.HiddenFor(m => Model.UserAccount.Person.Address.Id)%>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.UserAccount.Person.FirstName)%>
            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.FirstName)%>
        </div>
        <div class="editor-label">
            Last Name:
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.UserAccount.Person.LastName)%>
            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.LastName)%>
        </div>
        <div class="editor-label">
            Street Address:
        </div>

        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.UserAccount.Person.Address.StreetAddress)%>
            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Address.StreetAddress)%>
        </div>
        <div class="editor-label">
            City:
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.UserAccount.Person.Address.City)%>
            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Address.City)%>
        </div>
        <div class="editor-label">
            Province:
        </div>
        <div class="editor-field">
            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Address.Province)%>
            <%: Html.Hidden("ExistingProvince",Model.UserAccount.Person.Address.Province)%>

             <select id="UserAccount_Person_Address_Province" name="UserAccount.Person.Address.Province">
                                <option value="AB">AB</option>
                                <option value="BC">BC</option>
                                <option value="MB">MB</option>
                                <option value="NB">NB</option>
                                <option value="NL">NL</option>
                                <option value="ON">ON</option>
                                <option value="SK">SK</option>
                            </select>

        </div>
        <div class="editor-label">
            Postal Code:
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.UserAccount.Person.Address.PostalCode)%>
            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Address.PostalCode)%>
        </div>
        <div class="editor-label">
            Phone:
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.UserAccount.Person.MainPhone)%>
            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.MainPhone)%>
        </div>
        <div class="editor-label">
            Username:
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.UserAccount.Username, new { readOnly = true })%>
            <%: Html.ValidationMessageFor(model => model.UserAccount.Username)%>
        </div>
        <div class="editor-label">
            Email:
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.UserAccount.Person.Email)%>
            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Email)%>
        </div>
        <div id="RolesPanel" class="editor-field">
            Role:<br />
            <%: Html.DropDownListFor(m => m.Roles, Model.Roles)%>
            
        </div>
        <%: Html.HiddenFor(m => m.UserAccount.Role.ID, Model.UserAccount.Role.ID)%>
        <p>
            <input type="submit" value="Update" />
        </p>
        <% }
           }%>

        <%: Html.ActionLink("<< Go back ", "Create", "UserAccount")%>
        <br />
        <br />

        
    </div>
</asp:Content>
