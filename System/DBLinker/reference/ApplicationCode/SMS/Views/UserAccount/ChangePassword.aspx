<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.ChangePasswordView>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <script src="<%: Url.Content("~/Scripts/MicrosoftAjax.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/MicrosoftMvcValidation.js") %>" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Users"); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <%} %>
    <div id="pageContent">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {
           if (Model != null)
           {%>
        
        <h1>Change Password</h1>
            <%: Html.ValidationSummary()%>
            User: <%: Model.Username %><br /><br /> 
            <%: Html.HiddenFor(model => model.Username)%>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password)%>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(model => model.Password)%>
                <%: Html.ValidationMessageFor(model => model.Password)%>
            </div>
            
            <div class="editor-label">
                Confirm Password
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(model => model.ConfirmPassword)%>
                <%: Html.ValidationMessageFor(model => model.ConfirmPassword)%>
            </div>
            
            <p>
                <input type="submit" value="Submit" />
            </p>

    <% }
       }%>

    <div>
        <%: Html.ActionLink("<< Go Back", "Create") %>
    </div>
    </div>
</asp:Content>


