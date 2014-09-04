using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Models.DomainModels;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SMS.Models.DBModels
{
    public class ThirdPartyAccessRepository
    {
        public Guid GetOrgId(string userId) // obtain using System.Web.HttpContext.Current.User.Identity.Name
        {
            SqlCommand cmd = new SqlCommand("GetOrgIdByUserId", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@userid", SqlDbType.VarChar,25)).Value = userId;
            
            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                return Guid.Parse(dt.Rows[0]["orgid"].ToString());
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return Guid.Empty;
        }

        public bool CreateNewTeamApplication(TeamApplication app)
        {
            SqlCommand cmd = new SqlCommand("CreateNewTeamApplication", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@teamapplicationid", SqlDbType.UniqueIdentifier)).Value = Guid.NewGuid();
            cmd.Parameters.Add(new SqlParameter("@organizationid", SqlDbType.UniqueIdentifier)).Value = app.OrganizationID;
            cmd.Parameters.Add(new SqlParameter("@tournamentid", SqlDbType.UniqueIdentifier)).Value = app.TournamentID;
            cmd.Parameters.Add(new SqlParameter("@teamname", SqlDbType.VarChar,50)).Value = app.TeamName;
            cmd.Parameters.Add(new SqlParameter("@category", SqlDbType.VarChar,20)).Value = app.Category;
            cmd.Parameters.Add(new SqlParameter("@coachname", SqlDbType.VarChar,100)).Value = app.CoachName;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return false;
        }

        public bool SubmitTeamApplication(Guid TeamapplicationID)
        {
            SqlCommand cmd = new SqlCommand("SubmitTeamApplication", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@teamappId", SqlDbType.UniqueIdentifier)).Value = TeamapplicationID;
            
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return false;
        }

        public TeamApplication GetTeamApplication(Guid TeamapplicationID)
        {
            SqlCommand cmd = new SqlCommand("GetTeamApplication", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@teamappid", SqlDbType.UniqueIdentifier)).Value = TeamapplicationID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                List<TeamApplication> applications = new List<TeamApplication>();

                TeamApplication application = new TeamApplication(Guid.Parse(dt.Rows[0]["tournamentid"].ToString()), Guid.Parse(dt.Rows[0]["orgid"].ToString()), Guid.Parse(dt.Rows[0]["teamappid"].ToString()));
                application.TeamName = dt.Rows[0]["teamname"].ToString();
                application.Category = dt.Rows[0]["category"].ToString();
                application.CoachName = dt.Rows[0]["coachname"].ToString();
                application.Status = (int)dt.Rows[0]["statusfield"];
                application.TeamMessage = dt.Rows[0]["teammessage"].ToString();

                return application;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return null;
        }

        public List<TeamApplication> GetAllTeamApplications(Guid TournamentID, Guid OrgID)
        {
            SqlCommand cmd = new SqlCommand("GetExistingTeamApplications", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@organizationid", SqlDbType.UniqueIdentifier)).Value = OrgID;
            cmd.Parameters.Add(new SqlParameter("@tournamentid", SqlDbType.UniqueIdentifier)).Value = TournamentID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                List<TeamApplication> applications = new List<TeamApplication>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TeamApplication application = new TeamApplication(Guid.Parse(dt.Rows[i]["tournamentid"].ToString()),Guid.Parse(dt.Rows[i]["orgid"].ToString()),Guid.Parse(dt.Rows[i]["teamappid"].ToString()));
                    application.TeamName = dt.Rows[i]["teamname"].ToString();
                    application.Category = dt.Rows[i]["category"].ToString();
                    application.CoachName = dt.Rows[i]["coachname"].ToString();
                    application.Status = (int)dt.Rows[i]["statusfield"];
                    application.TeamMessage = dt.Rows[i]["teammessage"].ToString();
                    
                    applications.Add(application);
                }
                return applications;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return null;
        }

        public bool EditTeamApplication(TeamApplication app)
        {
            SqlCommand cmd = new SqlCommand("EditTeamApplication", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tournid", SqlDbType.UniqueIdentifier)).Value = app.TournamentID;
            cmd.Parameters.Add(new SqlParameter("@orgid", SqlDbType.UniqueIdentifier)).Value = app.OrganizationID;
            cmd.Parameters.Add(new SqlParameter("@teamappid", SqlDbType.UniqueIdentifier)).Value = app.ApplicationID;
            cmd.Parameters.Add(new SqlParameter("@teamname", SqlDbType.VarChar,50)).Value = app.TeamName;
            cmd.Parameters.Add(new SqlParameter("@category", SqlDbType.VarChar,30)).Value = app.Category;
            cmd.Parameters.Add(new SqlParameter("@coachname", SqlDbType.VarChar,100)).Value = app.CoachName;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return false;
        }

        public bool DeleteTeamApplication(TeamApplication app)
        {
            SqlCommand cmd = new SqlCommand("DeleteTeamApplication", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tournid", SqlDbType.UniqueIdentifier)).Value = app.TournamentID;
            cmd.Parameters.Add(new SqlParameter("@orgid", SqlDbType.UniqueIdentifier)).Value = app.OrganizationID;
            cmd.Parameters.Add(new SqlParameter("@teamappid", SqlDbType.UniqueIdentifier)).Value = app.ApplicationID;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return false;
        }

        public List<Tournament> GetRegistrationAvailableTournaments()
        {
            SqlCommand cmd = new SqlCommand("GetRegistrationAvailableTournaments", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@inputdate", SqlDbType.DateTime)).Value = DateTime.Now;

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
                    Tournament tournament = new Tournament(Guid.Parse(dt.Rows[i]["tournamentid"].ToString()));
                    tournament.TournamentName = dt.Rows[i]["tournamentname"].ToString();
                    tournament.TournamentInfo = dt.Rows[i]["tournament_info"].ToString();
                    tournament.RegistrationStartDate = DateTime.Parse(dt.Rows[i]["registration_start_date"].ToString());
                    tournament.RegistrationEndDate = DateTime.Parse(dt.Rows[i]["registration_end_date"].ToString());
                    tournament.TournamentStartDate = DateTime.Parse(dt.Rows[i]["tournament_start_date"].ToString());
                    tournament.TournamentEndDate = DateTime.Parse(dt.Rows[i]["tournament_start_date"].ToString());

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

        public Tournament GetSelectedTournament(Guid SelectedTournamentId)
        {
            SqlCommand cmd = new SqlCommand("GetSelectedTournamentById", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tournamentId", SqlDbType.UniqueIdentifier)).Value = SelectedTournamentId;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                Tournament tournament = new Tournament(Guid.Parse(dt.Rows[0]["tournamentId"].ToString()));
                tournament.TournamentName = dt.Rows[0]["tournamentName"].ToString();
                tournament.TournamentInfo = dt.Rows[0]["tournamentInfo"].ToString();
                tournament.RegistrationStartDate = DateTime.Parse(dt.Rows[0]["registrationStartDate"].ToString());
                tournament.RegistrationEndDate  = DateTime.Parse(dt.Rows[0]["registrationEndDate"].ToString());
                tournament.TournamentStartDate = DateTime.Parse(dt.Rows[0]["tournamentStartDate"].ToString());
                tournament.TournamentEndDate = DateTime.Parse(dt.Rows[0]["tournamentEndDate"].ToString());
                tournament.Location = dt.Rows[0]["tournamentLocation"].ToString();

                return tournament;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return null;
        }

        public Guid GetTournamentIdByTeamApp(Guid ApplicationId)
        {
            SqlCommand cmd = new SqlCommand("GetTournamentIdByTeamApp", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@teamappid", SqlDbType.UniqueIdentifier)).Value = ApplicationId;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                return Guid.Parse(dt.Rows[0]["TournamentID"].ToString());
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return Guid.Empty;
        }
    }
}