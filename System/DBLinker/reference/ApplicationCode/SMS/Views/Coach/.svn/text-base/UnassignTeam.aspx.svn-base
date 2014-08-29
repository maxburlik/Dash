<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.DomainModels.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<% Html.RenderPartial("UserNavigation", "Manage Teams"); %>
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
            Are you sure you want to unassign
            <%: Model.FirstName + ", " + Model.LastName%> from team?</h1>
            <input type="submit" value="Yes" />
       <%}
       } %>
       <br /><br />
       <%: Html.ActionLink("<< Go Back", "ManageTeams") %>
        
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
