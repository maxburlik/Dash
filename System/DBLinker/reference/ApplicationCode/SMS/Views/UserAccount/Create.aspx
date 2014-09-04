<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.UserAccountView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
 <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_page.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_jui.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/jqueryui/css/jquery-ui-1.8.6.custom.css") %>"
        rel="stylesheet" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-1.8.6.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/Datatables/js/jquery.dataTables.min.js") %>"></script>

    <script src="<%: Url.Content("~/Scripts/MicrosoftAjax.js")  %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/MicrosoftMvcValidation.js") %>" type="text/javascript"></script>
     <script type="text/javascript">
         $(function () {
             $("#ExistingUsersTable").dataTable({
                 "bJQueryUI": true,
                 "sPaginationType": "full_numbers", "bSort": true, "bInfo": false, "bFilter": true, "bPaginate": true
             });

             $("#Roles option[value='794c2858-17db-462c-ab13-065b8f6719bf']").remove();
             
         })

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "Manage Users"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <table cellpadding="10" style="width: 100%;">
            <tr valign="top">
                <td style="border-right: 1px solid gainsboro; width: 20%;">
                    <div id="createUserPanel">
                        <% Html.EnableClientValidation(); %>
                        <% using (Html.BeginForm())
                           {%>
                        <h1>
                            Create User</h1>
                        <%: Html.ValidationSummary() %>
                        <div class="editor-label">
                            First Name:
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.FirstName) %>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.FirstName) %>
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
                            <%--<%: Html.TextBoxFor(model => model.UserAccount.Person.Address.Province)%>--%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Address.Province)%>

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
                            <%: Html.TextBoxFor(model => model.UserAccount.Username) %>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Username) %>
                        </div>
                        <div class="editor-label">
                            Password:
                        </div>
                        <div class="editor-field">
                            <%: Html.PasswordFor(model => model.UserAccount.Password)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Password)%>
                        </div>
                        <div class="editor-label">
                            Confirm Password:
                        </div>
                        <div class="editor-field">
                            <%: Html.PasswordFor(model => model.UserAccount.ConfirmPassword)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.ConfirmPassword)%>
                        </div>
                        <div class="editor-label">
                            Email:
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.UserAccount.Person.Email)%>
                            <%: Html.ValidationMessageFor(model => model.UserAccount.Person.Email)%>
                        </div>
                        <div class="editor-field">
                            Role:<br />
                            <%: Html.DropDownListFor(m=> m.Roles, Model.Roles) %>
                        </div>
                        <p>
                            <input type="submit" value="Create" />
                        </p>
                        <% } %>
                    </div>
                </td>
                <td style="width: 80%;">
                    <div id="existingUserPanel" style="margin-left: 50px">
                        <h1>
                            Existing Users</h1>
                        <table id="ExistingUsersTable" cellspacing="0" cellpadding="10" style="width: 100%;">
                            <thead>
                            <tr>
                                <th>
                                    Username
                                </th>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Email
                                </th>
                                <th>
                                    Role
                                </th>
                                <th>
                                    Change Password
                                </th>
                                <th>
                                    Edit
                                </th>
                                <th>
                                    Delete
                                </th>
                            </tr>
                            </thead>
                            <% if (Model.ExistingUserAccounts != null) foreach (var item in Model.ExistingUserAccounts)
                                   { %>
                            <tr>
                                <td style="border-bottom: 1px solid gainsboro; border-left: 1px solid gainsboro;">
                                    <%: item.Username %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: item.Person.FirstName + " " + item.Person.LastName %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: item.Person.Email %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: item.Role.RoleName %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: Html.ActionLink("Change Password", "ChangePassword", "UserAccount", new { id = item.Username }, null) %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: Html.ActionLink("Edit", "Edit", "UserAccount", new { id = item.Username }, null) %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro; border-right: 1px solid gainsboro;">
                                    <%: Html.ActionLink("Delete", "Delete", "UserAccount", new { id = item.Username }, null) %>
                                </td>
                            </tr>
                            <% } %>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
