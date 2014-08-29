<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.CoachAssignTeamView>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "Manage Teams"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <% Html.BeginForm(); if (Model != null)
           {%>
        <h1>Assign Team</h1>
        <br />
        <%: Html.HiddenFor(m => Model.PlayerID)%>
        Player:
        <%: Model.PlayerName%><br />
        Select:<%: Html.DropDownListFor(m => m.Teams, Model.Teams)%>
        <br />
        <br />
        <input type="submit" value="Assign Team" /><br />
        <br />
        <% Html.EndForm();
           }%>
        <%: Html.ActionLink("<< Go Back","ManageTeams") %>
    </div>
</asp:Content>
