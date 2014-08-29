using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Models.DomainModels;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;

namespace SMS.Models.DBModels
{
    public class UserAccessRepository
    {

        public bool DeleteUser(string Username)
        {
            bool status = false;
            SqlCommand cmd = new SqlCommand("DeleteUserAccount", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter usernameParam = new SqlParameter("@username", SqlDbType.VarChar, 25);
            usernameParam.Value = Username;

            cmd.Parameters.Add(usernameParam);


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
        public bool UpdatePerson(Person Person)
        {
            bool status = false;

            if ((Person != null) && (Person.ID != Guid.Empty) && (Person.Address != null) && (Person.Address.Id != Guid.Empty))
            {
                SqlCommand cmd = new SqlCommand("UpdatePerson", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter personIDParam = new SqlParameter("@personID", SqlDbType.UniqueIdentifier);
                personIDParam.Value = Person.ID;

                SqlParameter addressIDParam = new SqlParameter("@addressID", SqlDbType.UniqueIdentifier);
                addressIDParam.Value = Person.Address.Id;

                SqlParameter addressProvinceParam = new SqlParameter("@addressProvince", SqlDbType.VarChar, 50);
                addressProvinceParam.Value = Person.Address.Province;

                SqlParameter addressStreetParam = new SqlParameter("@addressStreet", SqlDbType.VarChar, 100);
                addressStreetParam.Value = Person.Address.StreetAddress;

                SqlParameter addressPostalParam = new SqlParameter("@addressPostal", SqlDbType.VarChar, 50);
                addressPostalParam.Value = Person.Address.PostalCode;

                SqlParameter addressCityParam = new SqlParameter("@addressCity", SqlDbType.VarChar, 50);
                addressCityParam.Value = Person.Address.City;

                SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar, 60);
                emailParam.Value = Person.Email;

                SqlParameter firstNameParam = new SqlParameter("@firstName", SqlDbType.VarChar, 30);
                firstNameParam.Value = Person.FirstName;

                SqlParameter lastNameParam = new SqlParameter("@lastName", SqlDbType.VarChar, 30);
                lastNameParam.Value = Person.LastName;

                SqlParameter mainPhoneParam = new SqlParameter("@mainPhone", SqlDbType.VarChar, 30);
                mainPhoneParam.Value = Person.MainPhone;

                SqlParameter workPhoneParam = new SqlParameter("@workPhone", SqlDbType.VarChar, 30);

                if ((Person.WorkPhone != null) && (Person.WorkPhone != ""))
                    workPhoneParam.Value = Person.WorkPhone;
                else
                    workPhoneParam.Value = Person.MainPhone;

                cmd.Parameters.Add(personIDParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(firstNameParam);
                cmd.Parameters.Add(lastNameParam);
                cmd.Parameters.Add(mainPhoneParam);
                cmd.Parameters.Add(workPhoneParam);
                cmd.Parameters.Add(addressCityParam);
                cmd.Parameters.Add(addressStreetParam);
                cmd.Parameters.Add(addressIDParam);
                cmd.Parameters.Add(addressProvinceParam);
                cmd.Parameters.Add(addressPostalParam);

                try
                {
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    status = true;

                }
                catch (Exception e)
                {
                    cmd.Connection.Close();

                }

            }
            return status;

        }
        public bool UpdateUserAccount(UserAccount UserAccount)
        {
            bool status = false;


            if (UserAccount.Person.ID == Guid.Empty)
                UserAccount.Person.ID = GetPersonID(UserAccount.Username);

            bool personStatus = UpdatePerson(UserAccount.Person);

            if (personStatus)
            {
                SqlCommand cmd = new SqlCommand("UpdateUserAccount", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter usernameParam = new SqlParameter("@username", SqlDbType.VarChar, 25);
                usernameParam.Value = UserAccount.Username;

                SqlParameter roleIDParam = new SqlParameter("@roleID", SqlDbType.UniqueIdentifier);
                roleIDParam.Value = UserAccount.Role.ID;

                cmd.Parameters.Add(usernameParam);
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
            return status;
        }

        public int NumberOfUsersInRole(Guid RoleId)
        {
            Guid typeID = Guid.Empty;
            int result = -1;

            SqlCommand cmd = new SqlCommand("NumOfUsersInRole", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@roleid", SqlDbType.UniqueIdentifier));
            cmd.Parameters[0].Value = RoleId;

            try
            {
                cmd.Connection.Open();
                result = Int32.Parse(cmd.ExecuteScalar().ToString());
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }


            return result;
        }
        public bool DeleteRole(Guid RoleId)
        {
            bool status = false;
            Guid typeID = Guid.Empty;

            SqlCommand cmd = new SqlCommand("DeleteRole", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@roleid", SqlDbType.UniqueIdentifier));
            cmd.Parameters[0].Value = RoleId;

            try
            {
                cmd.Connection.Open();
                int numRowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                status = true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }


            return status;

        }

        public Guid GetPersonID(string Username)
        {
            Guid personID = Guid.Empty;

            SqlCommand cmd = new SqlCommand("GetPersonID", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 25));
            cmd.Parameters[0].Value = Username;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                if (dt.Rows.Count == 1)
                {
                    personID = Guid.Parse(dt.Rows[0]["person_id"].ToString());
                }
            }
            catch (Exception e)
            {
                return Guid.Empty;

            }

            return personID;
        }

        public Person GetPerson(Guid PersonID)
        {

            SqlCommand cmd = new SqlCommand("GetPerson", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.UniqueIdentifier)).Value = PersonID;
            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                if (dt.Rows.Count == 1)
                {
                    Person person = new Person(PersonID);
                    person.FirstName = dt.Rows[0]["firstname"].ToString();
                    person.LastName = dt.Rows[0]["lastname"].ToString();
                    person.MainPhone = dt.Rows[0]["mainphone"].ToString();
                    person.WorkPhone = dt.Rows[0]["workphone"].ToString();
                    person.Email = dt.Rows[0]["email"].ToString();
                    Address address = new Address(Guid.Parse(dt.Rows[0]["address_id"].ToString()));
                    person.Address = address;
                    return person;
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public Guid GetTypeID(string TypeName)
        {
            Guid typeID = Guid.Empty;

            SqlCommand cmd = new SqlCommand("GetTypeID", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@typeName", SqlDbType.VarChar, 50));
            cmd.Parameters[0].Value = TypeName;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                if (dt.Rows.Count == 1)
                {
                    typeID = Guid.Parse(dt.Rows[0]["typetable_id"].ToString());
                }
            }
            catch (Exception e)
            {
                return Guid.Empty;

            }

            return typeID;
        }
        public Role GetRole(Guid RoleID)
        {
            Role role = null;
            SqlCommand cmd = new SqlCommand("GetRoleByID", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@roleID", SqlDbType.UniqueIdentifier));
            cmd.Parameters[0].Value = RoleID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                if (dt.Rows.Count == 1)
                {
                    role = new Role(RoleID, dt.Rows[0]["RoleName"].ToString(), "");
                    role.AvailableFunctions = GetAllAvailableFunctions(role);
                }
            }
            catch (Exception e)
            {

                return null;

            }

            return role;
        }
        public List<Role> GetAllRoles()
        {
            List<Role> roles = null;
            SqlCommand cmd = new SqlCommand("GetAllRoles", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                roles = new List<Role>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //TODO: Include Description in role
                    Role role = new Role(Guid.Parse(dt.Rows[i]["RoleID"].ToString()), dt.Rows[i]["RoleName"].ToString(), "");
                    role.AvailableFunctions = GetAllAvailableFunctions(role);
                    roles.Add(role);
                }

            }
            catch (Exception e)
            {

            }

            return roles;

        }

        public Address GetAddress(Guid AddressID)
        {

            Address address = null;
            SqlCommand cmd = new SqlCommand("GetAddress", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            param.Value = AddressID;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                if (dt.Rows.Count == 1)
                {
                    address = new Address(AddressID);

                    address.City = dt.Rows[0]["city"].ToString();
                    address.Country = dt.Rows[0]["country"].ToString();
                    address.PostalCode = dt.Rows[0]["postalcode"].ToString();
                    address.Province = dt.Rows[0]["province"].ToString();
                    address.StreetAddress = dt.Rows[0]["streetaddress"].ToString();


                }

            }
            catch (Exception e)
            {

            }

            return address;

        }

        public Guid CreateAddress(Address Address)
        {

            SqlCommand cmd = new SqlCommand("CreateAddress", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            Guid addressID = Guid.NewGuid();

            SqlParameter idParam = new SqlParameter("@addressid", SqlDbType.UniqueIdentifier);
            idParam.Value = addressID;

            SqlParameter streetParam = new SqlParameter("@streetAddress", SqlDbType.VarChar, 100);
            streetParam.Value = Address.StreetAddress;

            SqlParameter cityParam = new SqlParameter("@city", SqlDbType.VarChar, 50);
            cityParam.Value = Address.City;

            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            provinceParam.Value = Address.Province;

            SqlParameter countryParam = new SqlParameter("@country", SqlDbType.VarChar, 50);
            countryParam.Value = Address.Country;

            SqlParameter postalParam = new SqlParameter("@postalCode", SqlDbType.VarChar, 10);
            postalParam.Value = Address.PostalCode;


            cmd.Parameters.Add(idParam);
            cmd.Parameters.Add(streetParam);
            cmd.Parameters.Add(cityParam);
            cmd.Parameters.Add(provinceParam);
            cmd.Parameters.Add(countryParam);
            cmd.Parameters.Add(postalParam);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }
            catch (Exception e)
            {
                return Guid.Empty;
            }


            return addressID;


        }

        //TODO: Take out the second parameter as it is included in Person.Address.ID
        public Guid CreatePerson(Person Person, Guid AddressID)
        {

            Guid personTypeId = GetTypeID(Person.Type.ToString());
            Guid personID = Guid.NewGuid();

            if ((AddressID != Guid.Empty) && (personTypeId != Guid.Empty))
            {
                SqlCommand cmd = new SqlCommand("CreatePerson", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter personIDParam = new SqlParameter("@personID", SqlDbType.UniqueIdentifier);
                personIDParam.Value = personID;

                SqlParameter addressIDParam = new SqlParameter("@addressID", SqlDbType.UniqueIdentifier);
                addressIDParam.Value = AddressID;

                SqlParameter personTypeParam = new SqlParameter("@personType", SqlDbType.UniqueIdentifier);
                personTypeParam.Value = personTypeId;

                SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar, 60);
                emailParam.Value = Person.Email;

                SqlParameter firstNameParam = new SqlParameter("@firstName", SqlDbType.VarChar, 30);
                firstNameParam.Value = Person.FirstName;

                SqlParameter lastNameParam = new SqlParameter("@lastName", SqlDbType.VarChar, 30);
                lastNameParam.Value = Person.LastName;

                SqlParameter mainPhoneParam = new SqlParameter("@mainPhone", SqlDbType.VarChar, 30);
                mainPhoneParam.Value = Person.MainPhone;

                SqlParameter workPhoneParam = new SqlParameter("@workPhone", SqlDbType.VarChar, 30);
                
                if((Person.WorkPhone != null) && (Person.WorkPhone != ""))
                    workPhoneParam.Value = Person.WorkPhone;
                else
                    workPhoneParam.Value = Person.MainPhone;

                SqlParameter orgIDParam = new SqlParameter("@org_id", SqlDbType.UniqueIdentifier);
                orgIDParam.Value = Person.Organization.Id;


                cmd.Parameters.Add(personIDParam);
                cmd.Parameters.Add(addressIDParam);
                cmd.Parameters.Add(personTypeParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(firstNameParam);
                cmd.Parameters.Add(lastNameParam);
                cmd.Parameters.Add(mainPhoneParam);
                cmd.Parameters.Add(workPhoneParam);
                cmd.Parameters.Add(orgIDParam);


                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                }

                catch (Exception e)
                {
                    cmd.Connection.Close();
                    personID = Guid.Empty;
                }


            }

            return personID;
        }
        public List<UserAccount> GetUserAccounts()
        {

            List<UserAccount> userAccounts = null;
            SqlCommand cmd = new SqlCommand("GetUserAccounts", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();

                userAccounts = new List<UserAccount>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UserAccount userAccount = new UserAccount();

                    userAccount.Username = dt.Rows[i]["username"].ToString();
                    userAccount.Person = new Person(Guid.Parse(dt.Rows[i]["person_id"].ToString()));
                    userAccount.Person.FirstName = dt.Rows[i]["firstname"].ToString();
                    userAccount.Person.LastName = dt.Rows[i]["lastname"].ToString();
                    userAccount.Person.MainPhone = dt.Rows[i]["mainphone"].ToString();
                    userAccount.Person.WorkPhone = dt.Rows[i]["email"].ToString();
                    userAccount.Person.Email = dt.Rows[i]["email"].ToString();
                    userAccount.Person.Address = new Address(Guid.Parse(dt.Rows[i]["address_id"].ToString()));
                    userAccount.Person.Organization = new Organization(Guid.Parse(dt.Rows[i]["org_id"].ToString()));

                    string personTypeName = GetTypeName(Guid.Parse(dt.Rows[i]["person_type_id"].ToString()));

                    userAccount.Person.Type = (PersonType)Enum.Parse(typeof(PersonType), personTypeName);

                    userAccount.Role = GetRole(Guid.Parse(dt.Rows[i]["role_id"].ToString()));

                    userAccounts.Add(userAccount);

                }

            }
            catch (Exception e)
            {

            }



            return userAccounts;

        }

        public string GetTypeName(Guid TypeID)
        {
            string typeName = String.Empty;

            SqlCommand cmd = new SqlCommand("GetTypeName", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@typeID", SqlDbType.UniqueIdentifier));
            cmd.Parameters[0].Value = TypeID;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                if (dt.Rows.Count == 1)
                {
                    typeName = dt.Rows[0]["typename"].ToString();
                }
            }
            catch (Exception e)
            {
                return String.Empty;

            }

            return typeName;
        }

        public bool CreateUserAccount(UserAccount UserAccount)
        {
            Guid addressID = CreateAddress(UserAccount.Person.Address);
            bool status = false;

            if (addressID != Guid.Empty)
            {
                Guid personID = CreatePerson(UserAccount.Person, addressID);

                if (personID != Guid.Empty)
                {
                    SqlCommand cmd = new SqlCommand("CreateUserAccount", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter personIDParam = new SqlParameter("@personID", SqlDbType.UniqueIdentifier);
                    personIDParam.Value = personID;

                    SqlParameter userNameParam = new SqlParameter("@username", SqlDbType.VarChar, 25);
                    userNameParam.Value = UserAccount.Username;

                    SqlParameter roleIDParam = new SqlParameter("@roleID", SqlDbType.UniqueIdentifier);
                    roleIDParam.Value = UserAccount.Role.ID;

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


            return status;
        }
        public bool CreateRole(Role role)
        {
            SqlCommand cmd = new SqlCommand("CreateNewRole", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter idParam = new SqlParameter("@roleID", SqlDbType.UniqueIdentifier);
            idParam.Value = Guid.NewGuid();

            SqlParameter nameParam = new SqlParameter("@roleName", SqlDbType.VarChar, 500);
            nameParam.Value = role.RoleName;

            cmd.Parameters.Add(idParam);
            cmd.Parameters.Add(nameParam);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                SqlCommand availFuncCmd = new SqlCommand("CreateRoleAvailableFunction", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
                availFuncCmd.CommandType = CommandType.StoredProcedure;


                for (int i = 0; i < role.AvailableFunctions.Count; i++)
                {
                    SqlParameter roleIDParam = new SqlParameter("@roleID", SqlDbType.UniqueIdentifier);
                    roleIDParam.Value = idParam.Value;

                    SqlParameter availFuncIDParam = new SqlParameter("@availableFunctionID", SqlDbType.UniqueIdentifier);
                    availFuncIDParam.Value = role.AvailableFunctions[i].ID;

                    availFuncCmd.Parameters.Add(roleIDParam);
                    availFuncCmd.Parameters.Add(availFuncIDParam);

                    try
                    {
                        availFuncCmd.Connection.Open();
                        availFuncCmd.ExecuteNonQuery();
                        availFuncCmd.Connection.Close();
                        availFuncCmd.Parameters.Clear();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;

        }


        public List<AvailableFunction> GetAllAvailableFunctions()
        {
            List<AvailableFunction> availFunctions = null;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllAvailableFunctions";

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                availFunctions = new List<AvailableFunction>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AvailableFunction availFunc = new DomainModels.AvailableFunction(Guid.Parse(dt.Rows[i]["AvailableFunctionID"].ToString()), dt.Rows[i]["FunctionName"].ToString());
                    availFunctions.Add(availFunc);
                }


            }
            catch (Exception e)
            {
                cmd.Connection.Close();

            }

            return availFunctions;
        }
        public UserAccount GetUserAccount(string Username)
        {
            UserAccount userAccount = null;
            SqlCommand cmd = new SqlCommand("GetUserAccount", new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));
            SqlParameter param = new SqlParameter("@username", SqlDbType.VarChar, 25);
            param.Value = Username;

            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                if (dt.Rows.Count == 1)
                {
                    userAccount = new UserAccount();

                    userAccount.Username = dt.Rows[0]["username"].ToString();
                    userAccount.Person = new Person(Guid.Parse(dt.Rows[0]["person_id"].ToString()));
                    userAccount.Person.FirstName = dt.Rows[0]["firstname"].ToString();
                    userAccount.Person.LastName = dt.Rows[0]["lastname"].ToString();
                    userAccount.Person.MainPhone = dt.Rows[0]["mainphone"].ToString();
                    userAccount.Person.WorkPhone = dt.Rows[0]["email"].ToString();
                    userAccount.Person.Email = dt.Rows[0]["email"].ToString();
                    userAccount.Person.Address = GetAddress(Guid.Parse(dt.Rows[0]["address_id"].ToString()));
                    userAccount.Person.Organization = new Organization(Guid.Parse(dt.Rows[0]["org_id"].ToString()));

                    string personTypeName = GetTypeName(Guid.Parse(dt.Rows[0]["person_type_id"].ToString()));

                    userAccount.Person.Type = (PersonType)Enum.Parse(typeof(PersonType), personTypeName);

                    userAccount.Role = GetRole(Guid.Parse(dt.Rows[0]["role_id"].ToString()));

                }

            }
            catch (Exception e)
            {

            }



            return userAccount;

        }

        public List<AvailableFunction> GetAllAvailableFunctions(Role role)
        {
            List<AvailableFunction> availFunctions = null;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllAvailableFunctionsForRole";

            SqlParameter roleIDParam = new SqlParameter("@roleID", SqlDbType.UniqueIdentifier);
            roleIDParam.Value = role.ID;
            cmd.Parameters.Add(roleIDParam);

            try
            {
                cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                cmd.Connection.Close();


                availFunctions = new List<AvailableFunction>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AvailableFunction availFunc = new DomainModels.AvailableFunction(Guid.Parse(dt.Rows[i]["AvailableFunctionID"].ToString()), dt.Rows[i]["AvailableFunctionName"].ToString());
                    availFunctions.Add(availFunc);
                }


            }
            catch (Exception e)
            {
                cmd.Connection.Close();

            }

            return availFunctions;
        }

        
        
    }
}