using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Models.DomainModels;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection;

namespace SMS.Models.DBModels
{
    public class TournamentAccessRepository
    {
        public bool DeleteMatch(Guid MatchID)
        {


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteMatch";
            cmd.Parameters.Add(new SqlParameter("@match_id", SqlDbType.UniqueIdentifier)).Value = MatchID;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            catch (Exception e)
            {
                cmd.Connection.Close();
                return false;
            }

            return true;

        }
        public bool UpdateMatch(Match Match)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateMatch";

            cmd.Parameters.Add(new SqlParameter("@teamapp_id_one", SqlDbType.UniqueIdentifier)).Value = Match.TeamApplicationOne.ApplicationID;
            cmd.Parameters.Add(new SqlParameter("@teamapp_id_two", SqlDbType.UniqueIdentifier)).Value = Match.TeamApplicationTwo.ApplicationID;
            cmd.Parameters.Add(new SqlParameter("@score_one", SqlDbType.Float)).Value = (Match.ScoreOne == "N/A") ? (object)DBNull.Value : Match.ScoreOne;
            cmd.Parameters.Add(new SqlParameter("@score_two", SqlDbType.Float)).Value = (Match.ScoreTwo == "N/A") ? (object)DBNull.Value : Match.ScoreTwo;
            cmd.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 50)).Value = Match.Location;
            cmd.Parameters.Add(new SqlParameter("@scheduled_date", SqlDbType.DateTime)).Value = Match.ScheduledDate;
            cmd.Parameters.Add(new SqlParameter("@match_id", SqlDbType.UniqueIdentifier)).Value = Match.Id;
            cmd.Parameters.Add(new SqlParameter("@length_of_game", SqlDbType.Int)).Value = Match.Duration;

            try
            {
                cmd.Connection.Open();
                int numOfRecordsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (numOfRecordsAffected > 0)
                    status = true;
            }

            catch (Exception e)
            {
                cmd.Connection.Close();

            }

            return status;
        }
        public List<Match> GetTournamentMatches(Guid TournamentID)
        {
            List<Match> matches = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTournamentMatches";
            cmd.Parameters.Add(new SqlParameter("@tournament_id", SqlDbType.UniqueIdentifier)).Value = TournamentID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                ThirdPartyAccessRepository rep = new ThirdPartyAccessRepository();

                if (dt.Rows.Count > 0)
                {
                    matches = new List<Match>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Match match = new Match(Guid.Parse(dt.Rows[i]["match_id"].ToString()));
                        match.TeamApplicationOne = rep.GetTeamApplication(Guid.Parse(dt.Rows[i]["team1_id"].ToString()));
                        match.TeamApplicationTwo = rep.GetTeamApplication(Guid.Parse(dt.Rows[i]["team2_id"].ToString()));
                        match.ScoreOne = Convert.IsDBNull(dt.Rows[i]["score1"]) ? "-1" : dt.Rows[i]["score1"].ToString();
                        match.ScoreTwo = Convert.IsDBNull(dt.Rows[i]["score2"]) ? "-1" : dt.Rows[i]["score2"].ToString();
                        match.Tournament = GetTournamentByID(Guid.Parse(dt.Rows[i]["tournament_id"].ToString()));
                        match.Location = dt.Rows[i]["location"].ToString();
                        match.ScheduledDate = DateTime.Parse(dt.Rows[i]["scheduled_date"].ToString());
                        match.Duration = Int32.Parse(dt.Rows[i]["length_of_game"].ToString());

                        matches.Add(match);
                    }
                }
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return matches;
        }
        public Guid CreateTournamentMatch(Match Match, Guid TournamentID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CreateMatch";
            Guid match_id = Guid.NewGuid();

            cmd.Parameters.Add(new SqlParameter("@tournament_id", SqlDbType.UniqueIdentifier)).Value = TournamentID;
            cmd.Parameters.Add(new SqlParameter("@teamapp_id_one", SqlDbType.UniqueIdentifier)).Value = Match.TeamApplicationOne.ApplicationID;
            cmd.Parameters.Add(new SqlParameter("@teamapp_id_two", SqlDbType.UniqueIdentifier)).Value = Match.TeamApplicationTwo.ApplicationID;
            cmd.Parameters.Add(new SqlParameter("@score_one", SqlDbType.Float)).Value = (Match.ScoreOne == null) ? (object)DBNull.Value : Match.ScoreOne;
            cmd.Parameters.Add(new SqlParameter("@score_two", SqlDbType.Float)).Value = (Match.ScoreTwo == null) ? (object)DBNull.Value : Match.ScoreTwo;
            cmd.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 50)).Value = Match.Location;
            cmd.Parameters.Add(new SqlParameter("@scheduled_date", SqlDbType.DateTime)).Value = Match.ScheduledDate;
            cmd.Parameters.Add(new SqlParameter("@match_id", SqlDbType.UniqueIdentifier)).Value = match_id;
            cmd.Parameters.Add(new SqlParameter("@length_of_game", SqlDbType.Int)).Value = Match.Duration;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }

            catch (Exception e)
            {
                match_id = Guid.Empty;
                cmd.Connection.Close();

            }

            return match_id;

        }
        public List<TeamApplication> GetAllApprovedTeamApplicationsByTournamentID(Guid TournamentID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetApprovedTeamApplicationsByTournamentID";
            cmd.Parameters.Add(new SqlParameter("@tournamentID", SqlDbType.UniqueIdentifier)).Value = TournamentID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                List<TeamApplication> teamApplications = new List<TeamApplication>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Organization org = new Organization(Guid.NewGuid());
                    org.Name = dt.Rows[i]["OrganizationName"].ToString();
                    TeamApplication team = new TeamApplication(TournamentID, org.Id, Guid.Parse(dt.Rows[i]["TeamApplicationID"].ToString()));
                    team.TeamName = dt.Rows[i]["TeamName"].ToString();
                    team.Category = dt.Rows[i]["Category"].ToString();
                    team.CoachName = dt.Rows[i]["CoachName"].ToString();
                    team.Status = (int)dt.Rows[i]["StatusField"];
                    team.Organization = org;
                    teamApplications.Add(team);

                }
                return teamApplications;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return null;
        }
        public Guid CreateNewTournament(Tournament Tournament)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CreateNewTournament";

            Guid TournamentID = Guid.NewGuid();
            Guid RegistrationID = Guid.NewGuid();
            Guid GameID = Guid.NewGuid();
            UserAccessRepository user_rep = new UserAccessRepository();
            Guid PersonID = user_rep.GetPersonID(System.Web.HttpContext.Current.User.Identity.Name);


            cmd.Parameters.Add(new SqlParameter("@tournamentId", SqlDbType.UniqueIdentifier)).Value = TournamentID;
            cmd.Parameters.Add(new SqlParameter("@registrationID", SqlDbType.UniqueIdentifier)).Value = RegistrationID;
            cmd.Parameters.Add(new SqlParameter("@gameId", SqlDbType.UniqueIdentifier)).Value = GameID;
            cmd.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 50)).Value = Tournament.Location;
            cmd.Parameters.Add(new SqlParameter("@createdById", SqlDbType.UniqueIdentifier)).Value = PersonID;
            cmd.Parameters.Add(new SqlParameter("@tournmentName", SqlDbType.VarChar, 50)).Value = Tournament.TournamentName;
            cmd.Parameters.Add(new SqlParameter("@tournamentInfo", SqlDbType.VarChar, 4000)).Value = Tournament.TournamentInfo;
            cmd.Parameters.Add(new SqlParameter("@registrationStartDate", SqlDbType.DateTime)).Value = Tournament.RegistrationStartDate;
            cmd.Parameters.Add(new SqlParameter("@registrationEndDate", SqlDbType.DateTime)).Value = Tournament.RegistrationEndDate;
            cmd.Parameters.Add(new SqlParameter("@tournamentStartDate", SqlDbType.DateTime)).Value = Tournament.TournamentStartDate;
            cmd.Parameters.Add(new SqlParameter("@tournamentEndDate", SqlDbType.DateTime)).Value = Tournament.TournamentEndDate;


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }

            catch (Exception e)
            {
                TournamentID = Guid.Empty;

            }

            return TournamentID;
        }


        public List<Tournament> GetAllTournaments()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllTournaments";

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                List<Tournament> tournaments = new List<Tournament>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Tournament tournament = new Tournament(Guid.Parse(dt.Rows[i]["tournamentId"].ToString()));
                    tournament.TournamentName = dt.Rows[i]["tournamentName"].ToString();
                    tournament.TournamentInfo = dt.Rows[i]["tournamentInfo"].ToString();
                    tournament.Location = dt.Rows[i]["tournamentLocation"].ToString();
                    tournament.RegistrationStartDate = DateTime.Parse(dt.Rows[i]["registrationStartDate"].ToString());
                    tournament.RegistrationEndDate = DateTime.Parse(dt.Rows[i]["registrationEndDate"].ToString());
                    tournament.TournamentStartDate = DateTime.Parse(dt.Rows[i]["tournamentStartDate"].ToString());
                    tournament.TournamentEndDate = DateTime.Parse(dt.Rows[i]["tournamentEndDate"].ToString());
                    tournaments.Add(tournament);
                }
                return tournaments;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return null;
        }

        public Tournament GetTournamentByID(Guid TournamentID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTournamentById";
            cmd.Parameters.Add(new SqlParameter("@tournamentId", SqlDbType.UniqueIdentifier)).Value = TournamentID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                if (dt.Rows.Count == 1)
                {
                    Tournament tournament = new Tournament(TournamentID);
                    tournament.TournamentName = dt.Rows[0]["tournamentName"].ToString();
                    tournament.Location = dt.Rows[0]["tournamentLocation"].ToString();
                    tournament.TournamentInfo = dt.Rows[0]["tournamentInfo"].ToString();
                    tournament.RegistrationStartDate = DateTime.Parse(dt.Rows[0]["registrationStartDate"].ToString());
                    tournament.RegistrationEndDate = DateTime.Parse(dt.Rows[0]["registrationEndDate"].ToString());
                    tournament.TournamentStartDate = DateTime.Parse(dt.Rows[0]["tournamentStartDate"].ToString());
                    tournament.TournamentEndDate = DateTime.Parse(dt.Rows[0]["tournamentEndDate"].ToString());

                    return tournament;
                }
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return null;
        }

        public bool UpdateTournament(Tournament Tournament)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateTournamentByID";

            cmd.Parameters.Add(new SqlParameter("@tournamentID", SqlDbType.UniqueIdentifier)).Value = Tournament.TournamentID;
            cmd.Parameters.Add(new SqlParameter("@tournamentName", SqlDbType.VarChar, 50)).Value = Tournament.TournamentName;
            cmd.Parameters.Add(new SqlParameter("@tournamentInfo", SqlDbType.VarChar, 4000)).Value = Tournament.TournamentInfo;
            cmd.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 50)).Value = Tournament.Location;
            cmd.Parameters.Add(new SqlParameter("@registrationStartDate", SqlDbType.DateTime)).Value = Tournament.RegistrationStartDate;
            cmd.Parameters.Add(new SqlParameter("@registrationEndDate", SqlDbType.DateTime)).Value = Tournament.RegistrationEndDate;
            cmd.Parameters.Add(new SqlParameter("@tournamentStartDate", SqlDbType.DateTime)).Value = Tournament.TournamentStartDate;
            cmd.Parameters.Add(new SqlParameter("@tournamentEndDate", SqlDbType.DateTime)).Value = Tournament.TournamentEndDate;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            catch (Exception e)
            {
                cmd.Connection.Close();
                return false;

            }

            return true;
        }

        public bool DeleteTournament(Guid TournamentID)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteTournamentByID";
            cmd.Parameters.Add(new SqlParameter("@tournamentID", SqlDbType.UniqueIdentifier)).Value = TournamentID;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            catch (Exception e)
            {
                cmd.Connection.Close();
                return false;
            }

            return true;
        }

        public List<TeamApplication> GetAllTeamApplicationsByTournamentID(Guid TournamentID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllTeamApplicationByTournamentID";
            cmd.Parameters.Add(new SqlParameter("@tournamentID", SqlDbType.UniqueIdentifier)).Value = TournamentID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                List<TeamApplication> teamApplications = new List<TeamApplication>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Organization org = new Organization(Guid.NewGuid());
                    org.Name = dt.Rows[i]["OrganizationName"].ToString();
                    TeamApplication team = new TeamApplication(TournamentID, org.Id, Guid.Parse(dt.Rows[i]["TeamApplicationID"].ToString()));
                    team.TeamName = dt.Rows[i]["TeamName"].ToString();
                    team.Category = dt.Rows[i]["Category"].ToString();
                    team.CoachName = dt.Rows[i]["CoachName"].ToString();
                    team.Status = (int)dt.Rows[i]["StatusField"];
                    team.TeamMessage = dt.Rows[i]["TeamMessage"].ToString();
                    team.SubmissionDate = DateTime.Parse(dt.Rows[0]["SubmissionDate"].ToString());
                    team.Organization = org;
                    teamApplications.Add(team);

                }
                return teamApplications;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return null;
        }

        public bool UpdateTeamApplication(Guid TeamApplicationID, int status, string message)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ApproveOrDenyTeamApplication";

            cmd.Parameters.Add(new SqlParameter("@teamApplicationID", SqlDbType.UniqueIdentifier)).Value = TeamApplicationID;
            cmd.Parameters.Add(new SqlParameter("@statusField", SqlDbType.Int)).Value = status;
            cmd.Parameters.Add(new SqlParameter("@teamMessage", SqlDbType.VarChar, 4000)).Value = message;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            catch (Exception e)
            {
                cmd.Connection.Close();
                return false;

            }

            return true;
        }
    }
}
