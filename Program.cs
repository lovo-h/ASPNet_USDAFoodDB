using Microsoft.EntityFrameworkCore;
using USDAFoodDB.Context;

namespace USDAFoodDB {
    class Program {
        private const string ConnString = "Server=localhost,1433;Database=USDAFoodAPI;" +
                                          "User Id=sa;Password=password123!;" +
                                          "MultipleActiveResultSets=true";

        static void Main() {
            var optionsBuilder = new DbContextOptionsBuilder<USDAFoodContext>();
            optionsBuilder.UseSqlServer(ConnString);

            using (var context = new USDAFoodContext(optionsBuilder.Options)) {
                
            }
        }
    }
}