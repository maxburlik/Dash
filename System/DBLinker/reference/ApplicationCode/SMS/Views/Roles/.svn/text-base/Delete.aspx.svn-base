<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.DomainModels.Role>" %>

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
            <h1>Are you sure you want to delete '<%: Model.RoleName%>' role?</h1> <br />
            Yes, <input id="btnSubmit" type="submit" value="Delete It!" />
            <% } %><br /><br />
            <%: Html.ActionLink("<< Go back ", "Create", "Roles")%> <br /><br />
            <% Html.EndForm(); %>
        </div>
    </div>
</asp:Content>
