//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System;
using System.Configuration; // TODO: Remember to add System.Configuration.dll
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{

    // In application initialization, must verify database exists
    // - If DB does not exist
    public class DBBinder
    {
        public DBBinder()
        {
            // Run DB initialization procedures
            Init();
        }

        public void UploadFileContents(string fileText)
        {
            // TODO: Ensure newlines, escape chars, etc work for uploading
            // Futureproofing: SQL injection
            string commandText = String.Format(
                "INSERT INTO {0}.dbo.[FileContents] (Id, Text, DateEntered)" +
                "VALUES ({1}, {2}, {3})",
                _dbName, "@value1", "@value2", "@value3");
            ExecuteCommand(commandText, Guid.NewGuid(), fileText, DateTime.Now);
        }

        public string GetLatestFileContents()
        {
            string commandText = String.Format("SELECT TOP 1 Text FROM {0}.dbo.[FileContents] ORDER BY DateEntered DESC", _dbName);
            string fileText = (string)ExecuteQueryScalar(commandText);
            return fileText;
        }

        #region Private Helpers
        private void Init()
        {
            if (!IsDBInitialized())
            {
                CreateDB();
                CreateTables();
                PopulateSampleData();
            }
        }

        // TODO: Need a way to generate SqlConnections in generalized fashion

        private bool IsDBInitialized()
        {
            bool returnValue = false;
            using(SqlConnection conn = new SqlConnection(_masterConnectionString))
            {
                string commandText = String.Format("use {0}", _dbName);
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    command.Connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        returnValue = true;
                    }
                    catch (SqlException) 
                    {
                        Console.WriteLine("DB {0} is not initialized.", _dbName);
                    }
                }
            }

            return returnValue;
        }

        private void CreateDB()
        {
            using (SqlConnection conn = new SqlConnection(_masterConnectionString))
            {
                string commandText = String.Format("CREATE DATABASE {0}", _dbName);
                conn.Open();
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Database is Created Successfully");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("DataBase Creation Failed: {0}", ex.Message);
                        throw;
                    }
                }
            }
        }

        private void CreateTables()
        {
            string commandText = System.IO.File.ReadAllText(@".\db-createtables.sql");
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Tables Created Successfully");
                }
            }
        }

        private void PopulateSampleData()
        {
            // TODO: Sample data
        }

        private void ExecuteCommand(string commandText)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ExecuteCommand(string commandText, params object[] args)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    for(int i=0; i<args.Length; i++)
                    {
                        command.Parameters.AddWithValue(String.Format("@value{0}", i+1), args[i]);
                    }
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private object ExecuteQueryScalar(string queryText)
        {
            object returnValue;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(queryText, conn))
                {
                    returnValue = command.ExecuteScalar();
                }
            }

            return returnValue;
        }
        #endregion

        private static string _dbName = ConfigurationManager.AppSettings["DBName"];
        private static string _masterConnectionString = String.Format(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString, "master");
        private static string _connectionString = String.Format(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString, _dbName);
    }
}
