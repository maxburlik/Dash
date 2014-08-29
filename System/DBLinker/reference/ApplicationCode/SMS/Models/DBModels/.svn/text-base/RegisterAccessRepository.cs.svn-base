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

namespace SMS.Models.DBModels
{
    public class RegisterAccessRepository
    {
        public Guid CreatePlayerApplication(PlayerApplication PlayerApplication)
        {
            UserAccessRepository rep = new UserAccessRepository();

            // Player's information
            Guid playerAddressID = rep.CreateAddress(PlayerApplication.Player.Address);
            Guid playerID = rep.CreatePerson(PlayerApplication.Player, playerAddressID);

            // Guardian1's information(required)
            Guid guardian1AddressID = rep.CreateAddress(PlayerApplication.Guardian1.Address);
            Guid guardian1ID = rep.CreatePerson(PlayerApplication.Guardian1, guardian1AddressID);

            // Guardian2's information(optional)
            Guid guardian2ID = Guid.Empty;
            if (PlayerApplication.Guardian2 != null) //If user enter the address, use the one entered
            {
                Guid guardian2AddressID = rep.CreateAddress(PlayerApplication.Guardian2.Address);
                guardian2ID = rep.CreatePerson(PlayerApplication.Guardian2, guardian2AddressID);
            }
            else //if not, user the player's address
            {
                Guid guardian2AddressID = rep.CreateAddress(PlayerApplication.Player.Address);
                guardian2ID = rep.CreatePerson(PlayerApplication.Guardian2, guardian2AddressID);

            }

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CreateNewPlayerApplication";

            Guid playerApplicationID = Guid.NewGuid();
            cmd.Parameters.Add(new SqlParameter("@playerApplicationID", SqlDbType.UniqueIdentifier)).Value = playerApplicationID;
            cmd.Parameters.Add(new SqlParameter("@bcMedicalNumber", SqlDbType.VarChar,10)).Value = PlayerApplication.BCMedicalNumber;
            cmd.Parameters.Add(new SqlParameter("@registrationDate", SqlDbType.DateTime)).Value = PlayerApplication.RegistrationDate;
            cmd.Parameters.Add(new SqlParameter("@endDate", SqlDbType.DateTime)).Value = SqlDateTime.Null;
            cmd.Parameters.Add(new SqlParameter("@birthDate", SqlDbType.DateTime)).Value = PlayerApplication.BirthDate;
            cmd.Parameters.Add(new SqlParameter("@consentApproved", SqlDbType.Bit)).Value = PlayerApplication.ConsentApproved ? 1 : 0;
            cmd.Parameters.Add(new SqlParameter("@gender", SqlDbType.Char)).Value = PlayerApplication.Gender;
            cmd.Parameters.Add(new SqlParameter("@medicalAlert", SqlDbType.VarChar, 200)).Value = PlayerApplication.MedicalAlert;
            cmd.Parameters.Add(new SqlParameter("@paid", SqlDbType.Bit)).Value = 0;
            cmd.Parameters.Add(new SqlParameter("@payment", SqlDbType.Money)).Value = PlayerApplication.Payment;
            cmd.Parameters.Add(new SqlParameter("@previousTeam", SqlDbType.VarChar, 50)).Value = PlayerApplication.PreviousTeam;
            cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar, 50)).Value = PlayerApplication.School;
            cmd.Parameters.Add(new SqlParameter("@playerID", SqlDbType.UniqueIdentifier)).Value = playerID;
            cmd.Parameters.Add(new SqlParameter("@guardian1ID", SqlDbType.UniqueIdentifier)).Value = guardian1ID;
            cmd.Parameters.Add(new SqlParameter("@guardian2ID", SqlDbType.UniqueIdentifier)).Value = guardian2ID;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }

            catch (Exception e)
            {
                playerApplicationID = Guid.Empty;

            }

            return playerApplicationID;
        }
        public bool IsValidAuthorizationCode(string Code)
        {
            bool status = false;
            try
            {
                List<Guid> allValidCodes = this.GetValidAuthorizationCodes();
                for (int i = 0; i < allValidCodes.Count; i++)
                {
                    if (allValidCodes[i].ToString().Split('-')[4].ToString().ToLower().Equals(Code.ToLower()))
                    {
                        status = true;
                        break;
                    }

                }
            }
            catch (Exception e)
            {
            }

            return status;
        }

        /// <summary>
        /// Create a new organization 
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public Guid CreateOrganization(Organization Organization)
        {
            UserAccessRepository rep = new UserAccessRepository();

            //rep.CreateUserAccount(UserAccount)

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CreateNewOrganization";

            Guid organizationID = Guid.NewGuid();
            cmd.Parameters.Add(new SqlParameter("@organizationID", SqlDbType.UniqueIdentifier)).Value = organizationID;
            cmd.Parameters.Add(new SqlParameter("@org_name", SqlDbType.VarChar, 80)).Value = Organization.Name;
            cmd.Parameters.Add(new SqlParameter("@registration_date", SqlDbType.DateTime)).Value = DateTime.Now;
            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.VarChar, 30)).Value = Organization.Phone;
            cmd.Parameters.Add(new SqlParameter("@fax", SqlDbType.VarChar, 30)).Value = Organization.Fax;
            cmd.Parameters.Add(new SqlParameter("@url", SqlDbType.VarChar, 512)).Value = Organization.Url;
            cmd.Parameters.Add(new SqlParameter("@address_id", SqlDbType.UniqueIdentifier)).Value = Organization.Address.Id;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }
            catch (Exception e)
            {
                organizationID = Guid.Empty;

            }

            return organizationID;
        }

        public List<Guid> GetValidAuthorizationCodes()
        {
            List<Guid> allValidAuthorizationCodes = null;



            SqlCommand cmd = new SqlCommand("GetAuthorizationCode", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                allValidAuthorizationCodes = new List<Guid>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    allValidAuthorizationCodes.Add(Guid.Parse(dt.Rows[i]["AuthorizationCode"].ToString()));
                }
            }
            catch (Exception e)
            {
                cmd.Connection.Close();

            }

            return allValidAuthorizationCodes;

        }
        public bool CreateOrganizationAccount(UserAccount UserAccount)
        {
            UserAccessRepository userAccRep = new UserAccessRepository();
            Guid addressID = userAccRep.CreateAddress(UserAccount.Person.Organization.Address);
            bool status = false;

            if (addressID != Guid.Empty)
            {
                UserAccount.Person.Organization.Address.Id = addressID;
                UserAccount.Person.Organization.Phone = UserAccount.Person.MainPhone;
                UserAccount.Person.Organization.Fax = UserAccount.Person.MainPhone;
                Guid orgID = CreateOrganization(UserAccount.Person.Organization);

                if (orgID != Guid.Empty)
                {
                    UserAccount.Person.Organization.Id = orgID;
                    Guid personID = userAccRep.CreatePerson(UserAccount.Person, addressID);

                    if (personID != Guid.Empty)
                    {
                        SqlCommand cmd = new SqlCommand("CreateUserAccount", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter personIDParam = new SqlParameter("@personID", SqlDbType.UniqueIdentifier);
                        personIDParam.Value = personID;

                        SqlParameter userNameParam = new SqlParameter("@username", SqlDbType.VarChar, 25);
                        userNameParam.Value = UserAccount.Username;

                        SqlParameter roleIDParam = new SqlParameter("@roleID", SqlDbType.UniqueIdentifier);
                        roleIDParam.Value = Guid.Parse("794c2858-17db-462c-ab13-065b8f6719bf"); //Defined in Seed Data Max, will give Third-Party Role

                        cmd.Parameters.Add(personIDParam);
                        cmd.Parameters.Add(userNameParam);
                        cmd.Parameters.Add(roleIDParam);


                        try
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                            status = true;

                        }
                        catch (Exception e)
                        {

                        }
                    }

                }

            }

            return status;
        }

        public bool DeleteAuthorizationCode(string code)
        {
            bool status = false;
            SqlCommand cmd = new SqlCommand("DeleteAuthorizationCode", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter codeParam = new SqlParameter("@code", SqlDbType.VarChar, 50);
            codeParam.Value = code;

            cmd.Parameters.Add(codeParam);


            try
            {
                cmd.Connection.Open();
                int numOfRowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
               
                if(numOfRowsAffected > 0)
                   status = true;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            return status;
        }
    }

}
