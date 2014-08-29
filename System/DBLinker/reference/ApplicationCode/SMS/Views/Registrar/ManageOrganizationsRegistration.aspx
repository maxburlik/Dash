<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Organizations Registration"); %>
    
    <div id="pageContent">
        <h1>
            Generate Authorization Code</h1>
            <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
            <% Html.BeginForm("GenerateAuthorizationCode","Registrar"); %>
        <input type="submit" value="Generate Code" />

        <% Html.EndForm(); %>
    </div>
</asp:Content>
