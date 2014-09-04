<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SMS.Models.DomainModels.TeamApplication>" %>

    <% using (Html.BeginForm("AddTeamApplication","ThirdParty")) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend><span style="font-weight:bold">Add Team</span></legend>
            <%: Html.HiddenFor(m => m.OrganizationID) %>
            <%: Html.HiddenFor(m => m.TournamentID) %>
            <div class="editor-label">
                <span style="font-size:10">Team Name</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TeamName) %>
                <%: Html.ValidationMessageFor(model => model.TeamName) %>
            </div>
            
            <div class="editor-label">
                <span style="font-size:10">Category</span>
            </div>
            <div class="editor-field">
                <select id="Category" style="width: 150px;" name="Category">
                        <option value="">Please select...</option>
                    <% for (int i = 5; i < 25; i++)
                       { %>
                            <option value="U<%: i %>">U<%: i %></option>
                    <% } %>
                </select>
                <%: Html.ValidationMessageFor(model => model.Category) %>
            </div>
            
            <div class="editor-label">
                <span style="font-size:10">Coach Name</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CoachName) %>
                <%: Html.ValidationMessageFor(model => model.CoachName) %>
            </div>
            
            <br />
            <p>
                <input type="submit" value="Add to List" />
            </p>
        </fieldset>

    <% } %>


