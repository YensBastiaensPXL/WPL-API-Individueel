namespace ClassLibrary.Data.Framework
{
    public static class LocalSettings
    {// Kies voor Windows authentication of Sqlserver authentication
        public static string GetConnectionString()
        {
            //string connectionString = "Trusted_Connection=True;";
            string connectionString = "user id = PxlUser2024;";
            connectionString += "Password = PxlUser2024;";
            connectionString += $@"Server=10.128.4.7;";
            connectionString += $"Database=Db2024Team11";
            return connectionString;
        }
    }
}
