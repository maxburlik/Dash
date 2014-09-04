<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.RegistrarManageNewPlayersView>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_page.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_jui.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/jqueryui/css/jquery-ui-1.8.6.custom.css") %>"
        rel="stylesheet" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-1.8.6.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/Datatables/js/jquery.dataTables.min.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#unassigned_player_applications_table").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers"
            });

            $("#assigned_player_applications_table").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers"
            });
            $("#pageContent").tabs();
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Players Registration"); %>
    <div id="pageContent">
    	<ul>
		<li><a href="#unassigned_player_applications">Unassigned Players</a></li>
		<li><a href="#assigned_player_applications">Assigned Players</a></li>
		  </ul>
        <div id="unassigned_player_applications">
        <br />
            <table id="unassigned_player_applications_table">
                <thead>
                    <tr style="font-weight: bold">
                        <th>
                            Name
                        </th>
                        <th>
                            Age
                        </th>
                        <th>
                            Category
                        </th>
                        <th>
                            Registration Date
                        </th>
                        <th>
                            Paid
                        </th>
                        <th>
                            Select
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < Model.Players.Count; i++)
                       {
                           if (Model.Players[i].Coach == null)
                           { %>
                    <tr>
                        <td>
                            <%: Model.Players[i].Player.FirstName + " " + Model.Players[i].Player.LastName%>
                        </td>
                        <td>
                            <%:new DateTime((DateTime.Now - Model.Players[i].BirthDate).Ticks).Year - 1%>
                        </td>
                        <td>
                            U<%:new DateTime((DateTime.Now - Model.Players[i].BirthDate).Ticks).Year%>
                        </td>
                        <td>
                            <%: Model.Players[i].RegistrationDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <%  if (Model.Players[i].Paid == true)
                                { %>
                            Yes
                            <%}
                                else
                                {%>
                            No
                            <%} %>
                        </td>
                        <td>
                            <%: Html.ActionLink("Select","ManagePlayerApplication","Registrar", new {id = Model.Players[i].ID}, null) %>
                        </td>
                    </tr>
                    <%}
                   } %>
                </tbody>
            </table>
        </div>
        <div id="assigned_player_applications">
        <br />
            <table id="assigned_player_applications_table">
                <thead>
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Age
                        </th>
                        <th>
                            Category
                        </th>
                        <th>
                            Registration Date
                        </th>
                        <th>
                            Paid
                        </th>
                        <th>
                            Select
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < Model.Players.Count; i++)
                       {

                           if (Model.Players[i].Coach != null)
                           { %>
                    <tr>
                        <td>
                            <%: Model.Players[i].Player.FirstName + " " + Model.Players[i].Player.LastName%>
                        </td>
                        <td>
                            <%:new DateTime((DateTime.Now - Model.Players[i].BirthDate).Ticks).Year - 1%>
                        </td>
                        <td>
                            U<%:new DateTime((DateTime.Now - Model.Players[i].BirthDate).Ticks).Year%>
                        </td>
                        <td>
                            <%: Model.Players[i].RegistrationDate.ToString("MMM dd, yyyy")%>
                        </td>
                        <td>
                            <%  if (Model.Players[i].Paid == true)
                                { %>
                            <b>Yes</b>
                            <%}
                                else
                                {%><b>No</b>
                            <%} %>
                        </td>
                        <td>
                            <%: Html.ActionLink("Select","ManagePlayerApplication","Registrar", new { id = Model.Players[i].ID}, null) %>
                        </td>
                    </tr>
                    <%}
                   }
                    %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
