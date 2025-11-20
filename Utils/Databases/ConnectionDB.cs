namespace Utils.Databases
{
    public class ConnectionDB
    {
        private static readonly string _connectionString = "Data Source=localhost;Initial Catalog=LocadoraBD;Persist Security Info=True;User ID=sa;Password=SqlServer@1995;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";  //"Data Source=localhost;;Initial Catalog=LocadoraBD;Persist Security Info=True;User ID=sa;Password=SqlServer@1995;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

        public static string GetConnectionString() 
        {
            return _connectionString;
        }
    }
}
