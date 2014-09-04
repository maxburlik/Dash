<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.TeamView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "View All Team"); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <%} %>
    <div id="pageContent">
        <table width="100%">
            <tr valign="top">
                <td style="width: 100%">
                    <h1>
                        Teams Information
                    </h1>
 
                    To provide a unified, positive soccer experience for youth in the Greater Vancouver area, in a manner that develops and enhances their skills and passion for the game - and translates into success both on the field and off. 
While we are passionate about soccer and we want our players and teams to be successful, in games, leagues and tournaments. We want our players to also be successful in life. Soccer provides and teaches many of the values that are required to be successful. A perfect and obvious skill is teamwork. While it is possible to score a goal without any help from your teammates, it is extremely difficult. The same can be said in life. Soccer can teach kids (of any age), to be better teammates, and to help and support others when the help is needed.
Our executive team is made of like-minded individuals that saw a void in the Vancouver soccer scene and came together to help kids who were missing out on opportunities of playing summer soccer.
<br /><br /><h1>Current Teams/Page</h1>
                    <div id="Teams Info" style="width: 100%;">
                        <table width="100%" cellspacing="0" style="border: 1px solid gainsboro;">
                            <thead>
                                <tr>
                                    <td style="border-bottom: 1px solid gainsboro; width: 20%;">
                                        <b>Coach Name</b>
                                    </td>
                                    <td style="border-bottom: 1px solid gainsboro; width: 20%;">
                                        <b>Team Name</b>
                                    </td>
                                    <td style="border-bottom: 1px solid gainsboro; width: 20%;">
                                        <b>Number Of Players</b>
                                    </td>
                                    <td style="border-bottom: 1px solid gainsboro; width: 20%;">
                                        <b>Team Category</b>
                                    </td>
                                    <td style="border-bottom: 1px solid gainsboro; width: 20%;">
                                        <b>Team Page</b>
                                    </td>
                                </tr>
                            </thead>
                            <% foreach (var item in Model.Coaches)
                               { %>
                            <tr>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: item.FirstName + " " + item.LastName %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: item.Teams[0].Name %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: item.Teams[0].Players.Count %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: item.Teams[0].Category %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro;">
                                    <%: Html.ActionLink("View Team Page","Team", new {id = item.Teams[0].Id }) %>
                                </td>
                            </tr>
                            <% }%>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#Teams').attr("id", "currentPage");

        })

    </script>
</asp:Content>
