<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SMS.Models.DomainModels.Match>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "View All Team"); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <%} %>
    <div id="pageContent">
        <h1>
            Match Schedule:       
                     <% if (Model != null)
                                              { %>
                   <%:Model.ElementAt(0).Tournament.TournamentName %>
                   <%} %></h1>
            <table id="match_table" style="text-align: left;">
                <tr>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Team A
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Team B
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Score A
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Score B
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Location
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Duration[minutes]
                    </th>
                    <th style="border-bottom: 1px solid gainsboro;">
                        Scheduled Date
                    </th>
                </tr>
                <% if (Model != null)
                   { %>
                <% foreach (var item in Model)
                   { %>
                <tr >
                    <td style="text-align: left;"> 
                        <%:item.TeamApplicationOne.Organization.Name %> - <%: item.TeamApplicationOne.TeamName %>(<%: item.TeamApplicationOne.Category %>)
                    </td>
                    <td style="text-align: left;">
                        <%:item.TeamApplicationTwo.Organization.Name %> - <%: item.TeamApplicationTwo.TeamName %>(<%: item.TeamApplicationTwo.Category %>)
                    </td>
                    <td style="text-align: left;">
                        <%: item.ScoreOne%>
                    </td>
                    <td style="text-align: left;">
                        <%: item.ScoreTwo%>
                    </td>
                    <td style="text-align: left;">
                        <%: item.Location %>
                    </td>
                    <td style="text-align: left;">
                        <%: item.Duration %>
                    </td>
                    <td style="text-align: left;">
                        <%: String.Format("{0:MMM dd, yyyy hh:mmtt}", item.ScheduledDate) %>
                    </td>
                </tr>
                <% }
               } %>
            </table><br />
        <p>
            <%: Html.ActionLink("<< Go Back", "All") %>
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
