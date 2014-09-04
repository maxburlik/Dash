<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.CoachManageTeamEventsView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
        <% Html.RenderPartial("UserNavigation", "Manage Team Events"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        <table width="100%">
            <tr valign="top">
                <td style="border-right: 1px solid gainsboro; width: 20%">
                    <div id="CreateEventPanel">
                        <h1>
                            Create Event</h1>
                        <% Html.EnableClientValidation(); %>
                        <% using (Html.BeginForm())
                           {%>
                        <%: Html.ValidationSummary(true) %>
                        <div id="CreateEventPanel">
                            <div class="editor-label">
                                Name:
                            </div>
                            <div class="editor-field">
                                <%: Html.TextBoxFor(model => model.Event.Name)%>
                                <%: Html.ValidationMessageFor(model => model.Event.Name)%>
                            </div>
                            <div class="editor-label">
                                Date/Time:
                            </div>
                            <div class="editor-field">
                                <%: Html.TextBoxFor(model => model.Event.ScheduledDate)%>
                                <%: Html.ValidationMessageFor(model => model.Event.ScheduledDate)%>
                            </div>
                            <div class="editor-label">
                                Location:
                            </div>
                            <div class="editor-field">
                                <%: Html.TextBoxFor(model => model.Event.Location)%>
                                <%: Html.ValidationMessageFor(model => model.Event.Location)%>
                            </div>
                            <div class="editor-label">
                                Teams:
                            </div>
                            <% if (Model.TeamsToNotify != null)
                               {%>
                            <div id="HasSelectedTeamDiv" class="editor-field" style="margin-left: 10px;">
                                <%= Html.CheckBoxList("Teams", Model.TeamsToNotify)%>
                                <%: Html.ValidationMessageFor(model => model.HasSelectedTeam)%>
                            </div>
                            <%} %>
                            <div class="editor-label">
                                Description:
                            </div>
                            <div class="editor-field">
                                <%: Html.TextAreaFor(model => model.Event.Description)%>
                                <%: Html.ValidationMessageFor(model => model.Event.Description)%>
                            </div>
                            <div class="editor-field">
                                <%: Html.CheckBoxFor(model => model.SendEmailToPlayers)%>
                                Send email to players
                                <input id="HasSelectedTeam" name="HasSelectedTeam" type="checkbox" value="false"
                                    style="visibility: hidden" />
                            </div>
                            <p>
                                <br />
                                <input type="submit" id="btnCreateEvent" value="Create" />
                                <div id="ErrorPanel" style="color: Red;"></div>
                            </p>
                        </div>
                    </div>
                </td>
                <td style="width: 80%; padding-left: 50px;">
                    <div id="ExistingEventsPanel">
                        <h1>
                            Existing Events</h1>
                        <table id="ExistingEventsTable" cellspacing="0" width="100%">
                            <thead>
                            <tr>
                                <th>
                                    Name
                                </th>
                                <th>
                                Created
                                </th>
                                <th>
                                    Scheduled
                                </th>
                                <th>
                                    Location
                                </th>
                                <th>
                                    Description
                                </th>
                                <th>
                                    Action
                                </th>
                            </tr>
                            </thead>
                            <% for (int i = 0; i < Model.ExistingEvents.Count; i++)
                               {
                                   SMS.Models.DomainModels.Event anEvent = Model.ExistingEvents[i]; 
                            %>
                            <tr>
                                <td id="event_title_<%:i%>" style="border-bottom: 1px solid gainsboro; border-left: 1px solid gainsboro;">
                                    <%: anEvent.Name %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro; padding-left: 10px;">
                                    <%: anEvent.CreatedDate.ToShortDateString() %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro; padding-left: 10px;">
                                    <%: anEvent.ScheduledDate.ToString() %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro; padding-left: 10px;">
                                    <%: anEvent.Location %>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro; padding-left: 10px;">
                                    <a id="show-event_details_<%:i%>" href="#">Show</a>
                                </td>
                                <td style="border-bottom: 1px solid gainsboro; border-right: 1px solid gainsboro; padding-left: 10px;">
                                    <%: Html.ActionLink("Delete","DeleteEvent", new{ id = anEvent.Id}) %>
                                </td>
                            </tr>
                            <% } %>
                        </table>
                    </div>
                </td>
            </tr>
        </table>

        <% for (int i = 0; i < Model.ExistingEvents.Count; i++)
           { %>
         <div class="hide">
            <div id="event_details_<%: i%>"><br />
                <p>
                    <%: Model.ExistingEvents[i].Description %>
                </p>
            </div>
        </div>
        <%} %>
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_page.css") %>"
        rel="stylesheet" />
    <link type="text/css" href="<%: Url.Content("~/Scripts/Datatables/css/datatable_jui.css") %>"
        rel="stylesheet" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/Datatables/js/jquery.dataTables.min.js") %>"></script>

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/MicrosoftMvcJQueryValidation.js") %>" type="text/javascript"></script>
    <link type="text/css" href="<%: Url.Content("~/Scripts/jqueryui/css/jquery-ui-1.8.6.custom.css") %>"
        rel="stylesheet" />
    <link media="screen" rel="stylesheet" href="<%: Url.Content("~/Scripts/jqueryui/css/colorbox.css") %>" />
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery.colorbox-min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-1.8.6.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%: Url.Content("~/Scripts/jqueryui/jquery-ui-timepicker-addon.js") %>"></script>
    <script type="text/javascript">
        $(function () {

            if ($('input[type=checkbox]').length < 3) {
                document.getElementById('btnCreateEvent').disabled = true;
                document.getElementById('ErrorPanel').innerHTML = "You do not have any teams!";
            }
            $("#ExistingEventsTable").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers", "bSort": true, "bInfo": false, "bFilter": true, "bPaginate": true
            });


            $("a[id^=show-event_details_]").click(function () {
                var target_td = "#" + $(this).attr("id").split("-")[1];
                var title_id = "#event_title_" + $(this).attr("id").split("_")[2];
                var title = $(title_id).text();
                $("#" + $(this).attr("id")).colorbox({ title: title, width: "60%", inline: true, href: target_td });
            });

            jQuery.validator.addMethod('HasSelectedTeam', function (value, element, params) {


                if (value == null) { return false; }
                if (value == params.reqparam.toString()) {
                    return true;

                }
                return false;
            });

            $(':checkbox').click(function (e) {
                if ($('#HasSelectedTeamDiv :checked').length > 0) {
                    $('#HasSelectedTeam').attr('value', 'true');
                    $('#HasSelectedTeam').attr('checked', 'checked');

                }
                else {
                    $('#HasSelectedTeam').attr('value', 'false');
                    $('#HasSelectedTeam').attr('checked', null);

                }
            });
            $('#Event_ScheduledDate').datetimepicker({ ampm: true, dateFormat: 'mm/dd/yy' });
        });

    </script>
</asp:Content>