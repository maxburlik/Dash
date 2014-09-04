<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", ""); %>
        <h1>
            Home of the PhoenixFC</h1>
            <div>
                Welcome to the New and Improved Website for PhoenixFC. We are a Vancouver based summer soccer club that is focused on delivering a positive soccer experience to kids of all ages and skill levels. Having been formed in 2010 we have had a very successful start to the summer soccer season. Starting at the
                beginning of spring we were able to put together 6 teams that participated in the USSL, and in various soccer tournaments throughtout the summer. We are hoping to build on our success of 2010 and have more teams for 2011. This website will be updated on regular basis, so come back often. While we are a summer soccer club, we will be planning
                events during the fall and winter, to get players out and have fun.<br /><br />
                We'll be also including various soccer trips and training techniques and programs that you can use to increase your skill level.
                <center><img alt="Poster" src="<%: Url.Content("~/Content/SMSsmall.jpg") %>" /></center>
            </div>
                        
             
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#Home').attr("id", "currentPage");

        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
