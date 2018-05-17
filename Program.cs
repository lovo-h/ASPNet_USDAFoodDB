using System;
using System.Data.SqlClient;


namespace USDAFoodDB {
    class Program {
        private const string ConnString = "Server=localhost,1433;Database=master;" +
                                          "User Id=sa;Password=password123!;" +
                                          "MultipleActiveResultSets=true";

        static void Main() {
            var connection = new SqlConnection(ConnString);

            try {
                connection.Open();
                Console.WriteLine("Successfully connected.");
                connection.Close();
            } catch (Exception ex) {
                Console.WriteLine("Cannot open a connection:" + ex.Message);
            }
        }
    }
}
