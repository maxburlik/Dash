<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="pageContent">
    <h1>Groups Randomizer</h1>
    Teams Per Group: <input type="text" id="txtTeamsPerGroups" /><br />
    Team Names (separated by comma):<br /> <textarea id="txtTeams" rows="10" cols="100" ></textarea><br />
    <input type="button" id="btnGenerateGroups" value="Generate Groups" />

    <div id="GroupingResultsPanel"></div>
    <br /><br />
    <h1>Match Randomizer (Double Elimination)</h1>
    Teams (separated by comma):<br /> <textarea id="txtTeamsForMatch" rows="10" cols="100" ></textarea><br />
    <input type="button" id="btnGenerateMatches" value="Generate Matches" />
     <div id="MatchResultsPanel"></div>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
<script type="text/javascript">
    $(function () {
        $('#btnGenerateGroups').click(function () {

            if ($('#txtTeamsPerGroups').val() != null);
            {
                var teamsPerGroup = $('#txtTeamsPerGroups').val();
                var teams = $('#txtTeams').val().split(",");
                var numOfTeams = teams.length;
                var randomizedTeams = [];
                var strOutput = "";
                var numOfGroups = Math.ceil(numOfTeams / teamsPerGroup);

                //Randomly shuffle teams
                for (var i = 0; randomizedTeams.length < numOfTeams; i++) {
                    var randomNumber = Math.floor(Math.random() * (teams.length));

                    randomizedTeams[i] = teams[randomNumber];
                    strOutput += randomizedTeams[i] + ",";

                    RemoveArrayElement(teams, randomNumber);
                }

                var groups = [];

                for (var i = 0; i < numOfGroups; i++) {
                    groups[i] = "";
                    for (var j = 0; j < teamsPerGroup; j++) {
                        if (randomizedTeams[0] != null) {
                            groups[i] += "<br />" + randomizedTeams[0];
                            RemoveArrayElement(randomizedTeams, 0);
                        }
                    }
                }

                //
                var html = '<table style="border: 1px solid gainsboro;">';
                html += "<tr valign='top'>";

                for (var i = 0; i < groups.length; i++) {


                    html += "<td><b><u>Group " + (i + 1) + "</u></b> " + groups[i] + "</td>";


                }
                html += "</tr>";
                html += "</table>";
                document.getElementById('GroupingResultsPanel').innerHTML = html;
            }
        });

        $('#btnGenerateMatches').click(function () {
            var teams = $('#txtTeamsForMatch').val().split(",");
            var numOfTeams = teams.length;
            var matches = new Array(numOfTeams);

            for (i = 0; i < numOfTeams; i++) {
                matches[i] = new Array(2);
                matches[i][0] = "";
                matches[i][1] = "";
            }

            for (var i = 0; i < numOfTeams; i++) { //numOfTeams*2 because it is double elimination. Each team will play two matches
                var potentialCandidates = GetPotentialCandidates(teams[i], teams, matches);
                var randomNumber = Math.floor(Math.random() * (potentialCandidates.length));
                var numOfMatches = GetTotalMatchesForTeam(matches, teams[i]);

                if (numOfMatches < 2) {
                    matches[i][0] = teams[i] + "," + potentialCandidates[randomNumber];
                    RemoveArrayElement(potentialCandidates, randomNumber);
                }

                numOfMatches = GetTotalMatchesForTeam(matches, teams[i]);

                if (numOfMatches < 2) {
                    randomNumber = Math.floor(Math.random() * (potentialCandidates.length));
                    matches[i][1] = teams[i] + "," + potentialCandidates[randomNumber];
                }
            }

            var htmlStr = "";
            for (var i = 0; i < numOfTeams; i++) {

                if (matches[i][0] != "") {
                    htmlStr += matches[i][0] + "<br />";
                }
                if (matches[i][1] != "") {
                    htmlStr += matches[i][1] + "<br />";
                }
            }

            document.getElementById('MatchResultsPanel').innerHTML = htmlStr;


        });
    });

    function GetPotentialCandidates(candidateFor, teams, matches) {

        var potentialCandidates = [];
        var potentialCandidatesString = "";

        for (var i = 0; i < teams.length; i++) {
            if (teams[i] != candidateFor) {
                var status = IsThereAMatch(matches, candidateFor, teams[i]);

                if (status == false) {
                    var totalMatches = GetTotalMatchesForTeam(matches, teams[i]);
                    if (totalMatches < 2) {
                        potentialCandidatesString += teams[i] + ",";
                    }
                }
            }
        }

        var teamTokens = potentialCandidatesString.split(",");

        for (var i = 0; i < teamTokens.length; i++) {
            if(teamTokens[i] != "")
                potentialCandidates[i] = teamTokens[i];
        }

        return potentialCandidates;
    }
    function GetTotalMatchesForTeam(matches, team) {
        var totalMatches = 0;

        for (var i = 0; i < matches.length; i++) {

            var matchA = matches[i][0];//.split(",");
            var matchB = matches[i][1]; //.split(",");

            if (matchA != "") {
                if (matchA.split(",")[0] == team || matchA.split(",")[1] == team)
                    totalMatches += 1;
            }
            if (matchB != "") {
                if (matchB.split(",")[0] == team || matchB.split(",")[1] == team)
                    totalMatches += 1;
            }
        }

        return totalMatches;
    }
    function IsThereAMatch(matches, teamA, teamB) {
        var status = false;

        for (var i = 0; i < matches.length; i++) {
            var matchA = matches[i][0]; //.split(",")[0];
            var matchB = matches[i][1]; //.split(",")[1];

            if (matchA != "") {
                var matchATeamOne = matchA.split(",")[0];
                var matchATeamTwo = matchA.split(",")[1];

                if ((matchATeamOne == teamA && matchATeamTwo == teamB) || (matchATeamOne == teamB && matchATeamTwo == teamA)) {
                    status = true;
                    break;
                }
            }

            if (matchB != "") {
                var matchBTeamOne = matchB.split(",")[0];
                var matchBTeamTwo = matchB.split(",")[1];

                if ((matchBTeamOne == teamA && matchBTeamTwo == teamB) || (matchBTeamOne == teamB && matchBTeamTwo == teamA)) {
                    status = true;
                    break;
                }
            }
        }

        return status;
    }
    function RemoveArrayElement(arr, index) {
        arr.splice(index, 1);
    }
</script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
