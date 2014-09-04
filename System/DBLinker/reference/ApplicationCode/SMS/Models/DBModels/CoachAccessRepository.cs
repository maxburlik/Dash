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
    public class CoachAccessRepository
    {
        public Event GetCoachEvent(Guid EventID)
        {
            SqlCommand cmd = new SqlCommand("GetEvent", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@event_id", SqlDbType.UniqueIdentifier);
            param.Value = EventID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            Event anEvent = null;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                
                if (dt.Rows.Count == 1)
                {
                    anEvent = new Event(Guid.Parse(dt.Rows[0]["event_id"].ToString()));
                    anEvent.Description = dt.Rows[0]["event_description"].ToString();
                    anEvent.Location = dt.Rows[0]["location"].ToString();
                    anEvent.Name = dt.Rows[0]["name"].ToString();
                    anEvent.ScheduledDate = DateTime.Parse(dt.Rows[0]["startDate"].ToString());
                }
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return anEvent;
        }
        public bool DeleteCoachEvent(Guid EventID, Guid CoachID)
        {
            bool status = false;

            SqlCommand cmd = new SqlCommand("DeleteCoachEvent", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter eventIDParam = new SqlParameter("@event_id", SqlDbType.UniqueIdentifier);
            eventIDParam.Value = EventID;


            cmd.Parameters.Add(eventIDParam);


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return status;
        }
        public List<Event> GetTeamEvents(Guid TeamID)
        {
            List<Event> events = null;
            SqlCommand cmd = new SqlCommand("GetTeamEvents", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            param.Value = TeamID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                events = new List<Event>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Event anEvent = new Event(Guid.Parse(dt.Rows[i]["event_id"].ToString()));
                    anEvent.Description = dt.Rows[i]["event_description"].ToString();
                    anEvent.Location = dt.Rows[i]["location"].ToString();
                    anEvent.Name = dt.Rows[i]["name"].ToString();
                    anEvent.ScheduledDate = DateTime.Parse(dt.Rows[i]["startDate"].ToString());
                    anEvent.CreatedDate = DateTime.Parse(dt.Rows[i]["timeCreated"].ToString());

                    events.Add(anEvent);
                }

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return events;
        }
        public List<Event> GetEvents(Guid CoachID)
        {
            List<Event> events = null;
            SqlCommand cmd = new SqlCommand("GetCoachEvents", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@coachid", SqlDbType.UniqueIdentifier);
            param.Value = CoachID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                events = new List<Event>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Event anEvent = new Event(Guid.Parse(dt.Rows[i]["event_id"].ToString()));
                    anEvent.Description = dt.Rows[i]["event_description"].ToString();
                    anEvent.Location = dt.Rows[i]["location"].ToString();
                    anEvent.Name = dt.Rows[i]["name"].ToString();
                    anEvent.ScheduledDate = DateTime.Parse(dt.Rows[i]["startDate"].ToString());
                    anEvent.CreatedDate = DateTime.Parse(dt.Rows[i]["timeCreated"].ToString());
                    
                    events.Add(anEvent);
                }

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return events;
        }

        public bool CreateTeamEventAssociation(Guid TeamID, Guid EventID)
        {
            bool status = false;

            SqlCommand cmd = new SqlCommand("CreateTeamEventMap", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter teamIDParam = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            teamIDParam.Value = TeamID;

            SqlParameter eventIDParam = new SqlParameter("@event_id", SqlDbType.UniqueIdentifier);
            eventIDParam.Value = EventID;


            cmd.Parameters.Add(teamIDParam);
            cmd.Parameters.Add(eventIDParam);


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }


            return status;
        }

        public bool CreateEvent(Event Event)
        {
            bool status = false;

            UserAccessRepository rep = new UserAccessRepository();



            SqlCommand cmd = new SqlCommand("CreateEvent", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            Guid eventID = Guid.NewGuid();

            SqlParameter idParam = new SqlParameter("@event_id", SqlDbType.UniqueIdentifier);
            idParam.Value = eventID;

            SqlParameter createdByParam = new SqlParameter("@created_by_id", SqlDbType.UniqueIdentifier);
            createdByParam.Value = Event.CreatedBy;

            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 50);
            nameParam.Value = Event.Name;

            SqlParameter scheduledTimeParam = new SqlParameter("@scheduledTime", SqlDbType.DateTime);
            scheduledTimeParam.Value = Event.ScheduledDate;

            SqlParameter locationParam = new SqlParameter("@location", SqlDbType.VarChar, 50);
            locationParam.Value = Event.Location;

            SqlParameter eventTypeParam = new SqlParameter("@typetable_id", SqlDbType.UniqueIdentifier);
            eventTypeParam.Value = rep.GetTypeID("CoachEvent");

            SqlParameter descriptionParam = new SqlParameter("@event_description", SqlDbType.VarChar, 4000);
            descriptionParam.Value = Event.Description;

            cmd.Parameters.Add(idParam);
            cmd.Parameters.Add(createdByParam);
            cmd.Parameters.Add(nameParam);
            cmd.Parameters.Add(scheduledTimeParam);
            cmd.Parameters.Add(locationParam);
            cmd.Parameters.Add(eventTypeParam);
            cmd.Parameters.Add(descriptionParam);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                for (int i = 0; i < Event.Teams.Count; i++)
                {
                    if (!CreateTeamEventAssociation(Event.Teams[i].Id, eventID))
                    {
                        status = false;
                        break;
                    }
                    else
                        status = true;
                    
                }
                
                    

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                status = false;
            }

            return status;

        }
        public bool DeleteTeam(Guid TeamID)
        {
            bool status = false;

            SqlCommand cmd = new SqlCommand("DeleteTeam", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter teamIDParam = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            teamIDParam.Value = TeamID;

            cmd.Parameters.Add(teamIDParam);


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return status;
        }


        public int NumOfPlayersInTeam(Guid TeamID)
        {
            int numOfPlayers = -1;

            Team team = null;

            SqlCommand cmd = new SqlCommand("GetNumOfPlayersInTeam", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            param.Value = TeamID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                if (dt.Rows.Count > 0)
                {

                    numOfPlayers = Int32.Parse(dt.Rows[0]["Total_Players"].ToString());
                }

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }


            return numOfPlayers;
        }
        public Team GetTeam(Guid TeamID)
        {
            Team team = null;

            SqlCommand cmd = new SqlCommand("GetTeam", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            param.Value = TeamID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                if(dt.Rows.Count > 0)
                {

                    team = new Team(Guid.Parse(dt.Rows[0]["team_id"].ToString()));
                    team.Category = dt.Rows[0]["category"].ToString();
                    team.Name = dt.Rows[0]["team_name"].ToString();
                    team.CoachID = Guid.Parse(dt.Rows[0]["coach_id"].ToString());
                }

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return team;
        }
        public bool UnassignTeamPlayer(Guid PlayerID)
        {
            bool status = false;

            SqlCommand cmd = new SqlCommand("UnassignTeamPlayer", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter playerIDParam = new SqlParameter("@player_id", SqlDbType.UniqueIdentifier);
            playerIDParam.Value = PlayerID;

            cmd.Parameters.Add(playerIDParam);


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return status;
        }

        public bool AssignPlayerBackToRegistrar(Guid PlayerID)
        {
            bool status = false;

            SqlCommand cmd = new SqlCommand("AssignPlayerBackToRegistrar", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter playerIDParam = new SqlParameter("@player_id", SqlDbType.UniqueIdentifier);
            playerIDParam.Value = PlayerID;

            cmd.Parameters.Add(playerIDParam);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return status;
        }

        public bool ChangeTeam(Guid PlayerID, Guid NewTeamID)
        {
            bool status = false;

            SqlCommand cmd = new SqlCommand("ChangePlayersTeam", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter teamIDParam = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            teamIDParam.Value = NewTeamID;

            SqlParameter playerIDParam = new SqlParameter("@player_id", SqlDbType.UniqueIdentifier);
            playerIDParam.Value = PlayerID;



            cmd.Parameters.Add(teamIDParam);
            cmd.Parameters.Add(playerIDParam);


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return status;
        }
        public Guid GetTeamID(Guid PlayerID)
        {
            Guid teamID = Guid.Empty;

            SqlCommand cmd = new SqlCommand("GetTeamID", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@player_id", SqlDbType.UniqueIdentifier));
            cmd.Parameters[0].Value = PlayerID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                if (dt.Rows.Count == 1)
                {
                    teamID = Guid.Parse(dt.Rows[0]["team_id"].ToString());
                }
            }
            catch (Exception e)
            {
                cmd.Connection.Close();

            }

            return teamID;
        }

        public bool AssignPlayerToTeam(Guid PlayerID, Guid TeamID, Guid CoachID)
        {
            bool status = false;

            SqlCommand cmd = new SqlCommand("AssignTeamToPlayer", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter teamIDParam = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            teamIDParam.Value = TeamID;

            SqlParameter coachIDParam = new SqlParameter("@coach_id", SqlDbType.UniqueIdentifier);
            coachIDParam.Value = CoachID;

            SqlParameter playerIDParam = new SqlParameter("@player_id", SqlDbType.UniqueIdentifier);
            playerIDParam.Value = PlayerID;



            cmd.Parameters.Add(teamIDParam);
            cmd.Parameters.Add(coachIDParam);
            cmd.Parameters.Add(playerIDParam);


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return status;
        }

        public bool CreateTeam(Team Team)
        {
            bool status = false;

            SqlCommand cmd = new SqlCommand("CreateTeam", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            idParam.Value = Guid.NewGuid();

            SqlParameter teamNameParam = new SqlParameter("@team_name", SqlDbType.VarChar, 50);
            teamNameParam.Value = Team.Name;

            SqlParameter categoryParam = new SqlParameter("@category", SqlDbType.VarChar, 30);
            categoryParam.Value = Team.Category;

            SqlParameter coachIDParam = new SqlParameter("@coach_id", SqlDbType.UniqueIdentifier);
            coachIDParam.Value = Team.CoachID;


            cmd.Parameters.Add(idParam);
            cmd.Parameters.Add(teamNameParam);
            cmd.Parameters.Add(categoryParam);
            cmd.Parameters.Add(coachIDParam);


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }


            return status;
        }

        public List<Person> GetTeamPlayers(Guid TeamID)
        {
            List<Person> players = null;

            SqlCommand cmd = new SqlCommand("GetTeamPlayers", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@team_id", SqlDbType.UniqueIdentifier);
            param.Value = TeamID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                players = new List<Person>();
                UserAccessRepository userRep = new UserAccessRepository();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Person person = userRep.GetPerson(Guid.Parse(dt.Rows[i]["player_id"].ToString()));


                    players.Add(person);
                }

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return players;
        }
        public List<Team> GetTeams(Guid CoachID)
        {
            List<Team> teams = null;
            SqlCommand cmd = new SqlCommand("GetTeams", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@coach_id", SqlDbType.UniqueIdentifier);
            param.Value = CoachID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                teams = new List<Team>();

                for(int i = 0 ; i < dt.Rows.Count; i++)
                {
                    
                    Team team = new Team(Guid.Parse(dt.Rows[i]["team_id"].ToString()));
                    team.Name = dt.Rows[i]["team_name"].ToString();
                    team.Category = dt.Rows[i]["category"].ToString();
                    team.CoachID = CoachID;

                    
                    teams.Add(team);
                }

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return teams;
        }


        public List<PlayerApplication> GetUnassignedPlayers(Guid CoachID)
        {
            List<PlayerApplication> applications = null;
            SqlCommand cmd = new SqlCommand("GetCoachUnassignedPlayers", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@coach_id", SqlDbType.UniqueIdentifier);
            param.Value = CoachID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                applications = new List<PlayerApplication>();

                for(int i = 0 ; i < dt.Rows.Count; i++)
                {
                    
                    Person person = new Person(Guid.Parse(dt.Rows[i]["player_id"].ToString()));
                    person.FirstName = dt.Rows[i]["firstname"].ToString();
                    person.LastName = dt.Rows[i]["lastname"].ToString();
                    person.MainPhone = dt.Rows[i]["mainphone"].ToString();
                    person.WorkPhone = dt.Rows[i]["workphone"].ToString();
                    person.Email = dt.Rows[i]["email"].ToString();
                    
                    
                    PlayerApplication application = new PlayerApplication(Guid.Parse(dt.Rows[i]["playerapp_id"].ToString()), person);
                    application.BirthDate = DateTime.Parse(dt.Rows[i]["birthdate"].ToString());
                    
                    applications.Add(application);
                }

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }



            return applications;
        }

        public List<Coach> GetAllTeams()
        {
            SqlCommand cmd = new SqlCommand("GetAllTeams", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            List<Coach> coaches = null;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                coaches = new List<Coach>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Coach coach = new Coach();
                    Team team = new Team(Guid.Parse(dt.Rows[i]["team_id"].ToString()));
                    team.Name = dt.Rows[i]["TeamName"].ToString();
                    team.Category = dt.Rows[i]["Category"].ToString();
                    coach.FirstName = dt.Rows[i]["FirstName"].ToString();
                    coach.LastName = dt.Rows[i]["LastName"].ToString();

                    team.Players = GetTeamPlayers(Guid.Parse(dt.Rows[i]["team_id"].ToString()));
                    coach.Teams = new List<Team>();
                    coach.Teams.Add(team);
                    coaches.Add(coach);


                    
                }

            }
            catch (Exception e)
            {

                cmd.Connection.Close();
            }

            return coaches;
        }





    }
}