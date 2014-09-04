<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.DomainModels.Tournament>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "Manage Roles"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <div>
            
            <% Html.BeginForm(); %>
            
           <% if (Model != null)
              { %>
            <h1>Are you sure you want to delete tournament: '<%: Model.TournamentName%>'?</h1> <br />
            Yes, <input id="btnSubmit" type="submit" value="Delete It!" />
            <% } %><br /><br />
            <%: Html.ActionLink("<< Go back ", "Create", "Tournament")%> <br /><br />
            <% Html.EndForm(); %>
        </div>
    </div>
</asp:Content>
