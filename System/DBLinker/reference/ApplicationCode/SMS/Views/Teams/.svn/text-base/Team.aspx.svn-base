<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.TeamPageView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "View All Team"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <h1>
            <%: Model.Team.Name %></h1>

        <b>Players:</b>
        <% for (int i = 0; i < Model.Team.Players.Count; i++)
           { %>
                <%: Model.Team.Players[i].FirstName + " " + Model.Team.Players[i].LastName %>
        <% if (((i + 1) != Model.Team.Players.Count))
           { %>, <%} %>
        <%} %>
        <br /><br />
        <table id="EventsTable" cellpadding="10px" cellspacing="0" width="100%" style="border: 1px solid gainsboro; height: 100%;">
        <thead><tr class="hide"><th></th></tr></thead>
        <% foreach (var item in Model.Events)
           { %>
                   <tr>
                   <td style="border-bottom: 1px solid gainsboro;">
                   <p style="text-align: right; margin: 0px"><%: item.CreatedDate.ToShortDateString() %></p>
                   <b>Name:</b> <%: item.Name %><br />
                   <b>Scheduled Date:</b> <%: item.ScheduledDate %><br />
                   
                   <b>Location:</b> <%: item.Location %><br />
                   <b>Comment:</b> <%: item.Description %>
                   </td>
                   </tr>
        <% } %>
        </table>
        <br />
        <%: Html.ActionLink("<< Go Back","All") %>
    </div>
</asp:Content>
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
        $(function () {
            $('#Teams').attr("id", "currentPage");

            $("#EventsTable").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers", "bSort": false, "bInfo": false, "bFilter": false,"bPaginate": true
            });

        })

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
