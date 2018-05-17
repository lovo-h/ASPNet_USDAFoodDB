using Microsoft.EntityFrameworkCore;
using USDAFoodDB.Models;

namespace USDAFoodDB.Context {
    public class USDAFoodContext : DbContext {
        
        public DbContextOptions<USDAFoodContext> DbContextOptions;
        public DbSet<FdGroup> FdGroups { get; set; }
        public DbSet<FoodDes> FoodDeses { get; set; }
        public DbSet<NutData> NutDatas { get; set; }
        public DbSet<NutrDef> NutrDefs { get; set; }
        public DbSet<DerivCd> DerivCds { get; set; }
        public DbSet<SrcCd> SrcCds { get; set; }
        public DbSet<LangDesc> LangDescs { get; set; }
        public DbSet<Langual> Languals { get; set; }
        public DbSet<Footnote> Footnotes { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<DatSrcLn> DatSrcLns { get; set; }
        public DbSet<DataSrc> DataSrcs { get; set; }
        
        public USDAFoodContext(DbContextOptions<USDAFoodContext> options) : base(options) {
            DbContextOptions = options;
        }
    }
}