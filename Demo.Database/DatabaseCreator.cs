using System;
using System.Data.SqlClient;
using System.Threading;

namespace Demo.Database
{
    public class DatabaseCreator
    {
        public static void Create(string masterConnectionString, string appConnectionString)
        {
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    var appDatabaseName = GetDatabaseName(appConnectionString);
                    if (!CheckDatabaseExists(masterConnectionString, appDatabaseName))
                    {
                        Create(masterConnectionString, appDatabaseName);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Thread.Sleep(5000);
                }
            }
        }

        private static void CreateDatabase(string master, string database)
        {
            using (var connection = new SqlConnection(master))
            using (var cmd = new SqlCommand($"CREATE DATABASE {database};", connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static bool CheckDatabaseExists(string master, string database)
        {
            using (var connection = new SqlConnection(master))
            using (var command = new SqlCommand($"SELECT db_id('{database}')", connection))
            {
                connection.Open();
                return (command.ExecuteScalar() != DBNull.Value);
            }
        }

        private static string GetDatabaseName(string connection)
        {
            var builder = new SqlConnectionStringBuilder(connection);
            return builder.InitialCatalog;
        }
    }
}
