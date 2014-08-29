<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.RoleView>" %>

<asp:Content ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
 <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_page.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_jui.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/jqueryui/css/jquery-ui-1.8.6.custom.css") %>"
        rel="stylesheet" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-1.8.6.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/Datatables/js/jquery.dataTables.min.js") %>"></script>

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/MicrosoftMvcJQueryValidation.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("#ExistingRolesTable").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers", "bSort": true, "bInfo": false, "bFilter": true, "bPaginate": true
            });


            jQuery.validator.addMethod('HasAvailableFunctions', function (value, element, params) {

                if (value == null) { return false; }
                if (value == params.reqparam.toString()) {

                    return true;

                }
                return false;
            });

            $(':checkbox').click(function (e) {
                if ($('#AvailableFunctionsDiv :checked').length > 0) {
                    $('#HasAvailableFunctions').attr('value', 'true');
                    $('#HasAvailableFunctions').attr('checked', 'checked');
                }
                else {
                    $('#HasAvailableFunctions').attr('value', 'false');
                    $('#HasAvailableFunctions').attr('checked', null);

                }
            });
        });

        
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "Manage Roles"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <table style="width: 100%;">
            <tr valign="top">
                <td style="width: 30%; border-right: 1px solid gainsboro;">
                    <div style="width: 100%;">
                        <h1>
                            Create Role</h1>
                        <% Html.EnableClientValidation(); %>
                        <% Html.BeginForm(); %>
                        <% if (Model.AvailableFunctions.Count > 0)
                           { %>
                        Role Name:
                        <%= Html.TextBoxFor(m=> Model.Name,Model.Name) %><br />
                        <%: Html.ValidationMessageFor(m=> Model.Name) %>
                        <br />
                        <br />
                        Available Functions:
                        <input id="HasAvailableFunctions" name="HasAvailableFunctions" type="checkbox" value="false"
                            style="visibility: hidden" /><br />
                        
                        <div id="AvailableFunctionsDiv" style="padding-left: 20px;">
                            <%= Html.CheckBoxList("AvailableFunctions", Model.AvailableFunctions)%></div>
                        <%: Html.ValidationMessageFor(m => Model.HasAvailableFunctions) %>
                        <br />
                        <input id="btnSubmit" type="submit" value="Create" />
                        <%  }
                           else
                           {%>
                        <p>
                            There are no available functions in the system! Please contact your system provider.</p>
                        <%} %>
                        <% Html.EndForm(); %>
                    </div>
                </td>
                <td style="width: 70%">
                    <div id="existingRolesPanel" style="padding-left: 50px; width: 95%">
                        <h1>
                            Existing Roles</h1>
                        <table cellspacing="0" id="ExistingRolesTable">
                            <thead>
                                <tr>
                                    <th>
                                        <b>Role</b>
                                    </th>
                                    <th>
                                        <b>Available Functions</b>
                                    </th>
                                    <th>
                                        <b>Delete</b>
                                    </th>
                                </tr>
                            </thead>
                            <% for (int i = 0; i < Model.Roles.Count; i++)
                               { %>
                            <tr valign="top">
                                <td style="border-bottom: 1px solid gainsboro; border-left: 1px solid gainsboro;">
                                    <%: Model.Roles[i].RoleName %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro; padding-left: 10px;">
                                    <% for (int j = 0; j < Model.Roles[i].AvailableFunctions.Count; j++)
                                       { %>
                                    <%: Model.Roles[i].AvailableFunctions[j].FunctionName.Replace("Viewer","") %><br />
                                    <% } %>
                                    <br />
                                </td>
                                <td style="border-bottom: 1px solid gainsboro; border-right: 1px solid gainsboro;padding-left: 10px;">
                                    <%: Html.ActionLink("Delete", "Delete", "Roles", new { id = Model.Roles[i].ID }, null)%>
                                </td>
                            </tr>
                            <% } %>
                        </table>
                        <%--<a id="lnkCreateRole" href="#">Create New Role</a>--%>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
