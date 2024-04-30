namespace ClassLibrary.Data.Framework
{
    static class Settings
    {
        public static string GetConnectionString()
        {
            //string connectionString = "Trusted_Connection=True;";
            string connectionString = "user id = pxluser;";
            connectionString += "Password = pxluser;";
            connectionString += $@"Server=5CG215052M\PXLDIGITAL;";
            connectionString += $"Database=db_kristof_palmaers";
            return connectionString;
        }
    }
}
