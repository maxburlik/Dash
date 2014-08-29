<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.LogonView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "Logon"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           {%>
        <div class="editor-label">
            Username:
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Username) %>
            <%: Html.ValidationMessageFor(model => model.Username) %>
        </div>
        <div class="editor-label">
            Password:
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </div>
        <p>
            <input type="submit" value="Login" />
        </p>
        <% } %>
    </div>
</asp:Content>
