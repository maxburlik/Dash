<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content3" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
<script type="text/javascript">
    $(function () {
        $('#Register').attr("id", "currentPage");
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", ""); %>
        <h1>
            New Registration</h1>

            Register as a <%: Html.ActionLink("New Player","NewPlayer","Register") %> or <%: Html.ActionLink("New Organization","NewOrganization","Register") %>

    </div>
</asp:Content>
