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
using System.Diagnostics;
using SMS.Models.DBModels;
using SMS.Models.ViewModels;
using System.Text.RegularExpressions;

namespace SMS.Models.DBModels
{
    public class RegistrarAccessRepository
    {
        public List<Person> GetAllCoaches()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllCoaches";

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                List<Person> coaches = new List<Person>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Person coach = new Person(Guid.Parse(dt.Rows[i]["PersonID"].ToString()));
                    coach.LastName = dt.Rows[i]["LastName"].ToString();
                    coach.FirstName = dt.Rows[i]["FirstName"].ToString();
                    coaches.Add(coach);
                }
                return coaches;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return null;
        }



        private bool IsValidGUID(string GUIDCheck)
        {
            if (!string.IsNullOrEmpty(GUIDCheck))
            {
                return new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$").IsMatch(GUIDCheck);
            }
            return false;
        }

        //TODO: The Guardian1 ,and Guardian2 may use the same address with the Player, modifed it to support it
        public bool UpdatePlayer(PlayerApplication Player, string Coaches)
        {
            UserAccessRepository rep = new UserAccessRepository();

            rep.UpdatePerson(Player.Player);
            rep.UpdatePerson(Player.Guardian1);
            rep.UpdatePerson(Player.Guardian2);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdatePlayer";

            cmd.Parameters.Add(new SqlParameter("@playerApplicationID", SqlDbType.UniqueIdentifier)).Value = Player.ID;
            cmd.Parameters.Add(new SqlParameter("@bcMedicalNumber", SqlDbType.VarChar, 10)).Value = Player.BCMedicalNumber;
            cmd.Parameters.Add(new SqlParameter("@birthDate", SqlDbType.DateTime)).Value = Player.BirthDate;
            cmd.Parameters.Add(new SqlParameter("@gender", SqlDbType.Char)).Value = Player.Gender;
            cmd.Parameters.Add(new SqlParameter("@medicalNotes", SqlDbType.VarChar, 200)).Value = (Player.MedicalAlert == null) ? DBNull.Value.ToString() : Player.MedicalAlert;
            cmd.Parameters.Add(new SqlParameter("@paid", SqlDbType.Bit)).Value = Player.Paid ? 1 : 0;
            cmd.Parameters.Add(new SqlParameter("@payment", SqlDbType.Money)).Value = Player.Payment;
            cmd.Parameters.Add(new SqlParameter("@previousTeam", SqlDbType.VarChar, 50)).Value = (Player.PreviousTeam == null) ? DBNull.Value.ToString() : Player.PreviousTeam;
            cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar, 50)).Value = Player.School;
            if (!IsValidGUID(Coaches) || Coaches == "")

                cmd.Parameters.Add(new SqlParameter("@coach_id", SqlDbType.UniqueIdentifier)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@coach_id", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(Coaches);

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


        public PlayerApplication GetPlayer(Guid PlayerID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.CommandText = "GetPlayerApplicationByID";
            cmd.Parameters.Add(new SqlParameter("@playerAppID", SqlDbType.UniqueIdentifier)).Value = PlayerID;
            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                if (dt.Rows.Count == 1)
                {
                    //Player information
                    PlayerApplication player = new PlayerApplication(PlayerID);
                    player.BCMedicalNumber = (dt.Rows[0]["bcMedicalNumber"].ToString());
                    player.BirthDate = DateTime.Parse(dt.Rows[0]["birthdate"].ToString());
                    player.Gender = dt.Rows[0]["gender"].ToString()[0];
                    player.MedicalAlert = dt.Rows[0]["medicalNotes"].ToString();
                    player.Paid = Boolean.Parse(dt.Rows[0]["paid"].ToString());
                    player.Payment = Double.Parse(dt.Rows[0]["payment"].ToString());
                    player.PreviousTeam = dt.Rows[0]["previousTeam"].ToString();
                    player.School = dt.Rows[0]["school"].ToString();

                    UserAccessRepository rep = new UserAccessRepository();
                    player.Player = new Person();
                    player.Player = rep.GetPerson(Guid.Parse(dt.Rows[0]["player_id"].ToString()));
                    player.Player.Address = new Address(player.Player.Address.Id);
                    player.Player.Address = rep.GetAddress(player.Player.Address.Id);

                    //Guardian1's information
                    player.Guardian1 = new Person();
                    player.Guardian1 = rep.GetPerson(Guid.Parse(dt.Rows[0]["contact1_id"].ToString()));
                    player.Guardian1.Address = new Address(player.Guardian1.Address.Id);
                    player.Guardian1.Address = rep.GetAddress(player.Guardian1.Address.Id);

                    if (Guid.Parse(dt.Rows[0]["contact2_id"].ToString()) != Guid.Empty)
                    {
                        player.Guardian2 = new Person();
                        player.Guardian2 = rep.GetPerson(Guid.Parse(dt.Rows[0]["contact2_id"].ToString()));
                        player.Guardian2.Address = new Address(player.Guardian2.Address.Id);
                        player.Guardian2.Address = rep.GetAddress(player.Guardian2.Address.Id);
                    }

                    if (Convert.IsDBNull(dt.Rows[0]["coach_id"]))
                        player.Coach = null;
                    else
                    {
                        Person coach = new Person(Guid.Parse(dt.Rows[0]["coach_id"].ToString()));
                        player.Coach = coach;
                    }
                    return player;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public bool DeactivatePlayer(Guid PlayerID)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeactivatePlayer";

            cmd.Parameters.Add(new SqlParameter("@playerApplicationID", SqlDbType.UniqueIdentifier)).Value = PlayerID;
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

        public List<PlayerApplication> GetAllPlayers()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllPlayerApplicationsForRegistrar";

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                List<PlayerApplication> players = new List<PlayerApplication>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Person person = new Person(Guid.Parse(dt.Rows[i]["PersonID"].ToString()));
                    person.LastName = dt.Rows[i]["LastName"].ToString();
                    person.FirstName = dt.Rows[i]["FirstName"].ToString();
                    PlayerApplication player = new PlayerApplication(Guid.Parse(dt.Rows[i]["PlayerAppID"].ToString()), person);
                    player.BirthDate = DateTime.Parse(dt.Rows[i]["BirthDate"].ToString());
                    player.RegistrationDate = DateTime.Parse(dt.Rows[i]["RegistrationDate"].ToString());
                    player.Paid = (bool)dt.Rows[i]["Paid"];

                    if (Convert.IsDBNull(dt.Rows[i]["CoachID"]))
                        player.Coach = null;
                    else
                    {
                        Person coach = new Person(Guid.Parse(dt.Rows[i]["CoachID"].ToString()));
                        player.Coach = coach;
                    }
                    players.Add(player);

                }
                return players;

                // return ConvertToList<Person>(dt);
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }
            return null;
        }



        public bool CreateAuthorizationCode(Guid guid)
        {
            SqlCommand cmd = new SqlCommand("[CreateOrganizationAuthoriationCode]", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter codeParam = new SqlParameter("@guid", SqlDbType.UniqueIdentifier);
            codeParam.Value = guid;

            cmd.Parameters.Add(codeParam);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();


            }
            catch (Exception e)
            {
                return false;
            }

            return true;

        }
    }
}