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
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // This is where you can write Fluent API statements as an alternative
            // to decorating your entity classes with attributes.
            base.OnModelCreating(modelBuilder);

            configureEntityFdGroup(modelBuilder);
            configureEntityFoodDes(modelBuilder);
            configureEntityDatSrcLn(modelBuilder);
            configureEntityDataSrc(modelBuilder);
            configureEntityNutData(modelBuilder);
            configureEntityFootnote(modelBuilder);
            configureEntityWeight(modelBuilder);
            configureEntityLangual(modelBuilder);
            configureEntityLangDesc(modelBuilder);
            configureEntityNutrDef(modelBuilder);
            configureEntitySrcCd(modelBuilder);
            configureEntityDerivCd(modelBuilder);
        }

        private void configureEntityFoodDes(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<FoodDes>().HasKey(fd => fd.NdbNo);

            // NOT NULL
            mb.Entity<FoodDes>().Property(fd => fd.NdbNo).IsRequired();
            mb.Entity<FoodDes>().Property(fd => fd.FdGrpCd).IsRequired();
            mb.Entity<FoodDes>().Property(fd => fd.LongDesc).IsRequired();
            mb.Entity<FoodDes>().Property(fd => fd.ShrtDesc).IsRequired();

            // NVARCHAR(x)
            mb.Entity<FoodDes>().Property(fd => fd.NdbNo).HasMaxLength(5);
            mb.Entity<FoodDes>().Property(fd => fd.FdGrpCd).HasMaxLength(4);
            mb.Entity<FoodDes>().Property(fd => fd.LongDesc).HasMaxLength(200);
            mb.Entity<FoodDes>().Property(fd => fd.ShrtDesc).HasMaxLength(60);
            mb.Entity<FoodDes>().Property(fd => fd.ComName).HasMaxLength(100);
            mb.Entity<FoodDes>().Property(fd => fd.ManufacName).HasMaxLength(65);
            mb.Entity<FoodDes>().Property(fd => fd.Survey).HasMaxLength(1);
            mb.Entity<FoodDes>().Property(fd => fd.RefDesc).HasMaxLength(135);
            mb.Entity<FoodDes>().Property(fd => fd.SciName).HasMaxLength(65);

            // RELATIONSHIP: ONE FdGroup TO MANY FoodDes
            mb.Entity<FoodDes>()
                .HasOne(fd => fd.FdGroup)
                .WithMany(fdg => fdg.FoodDeses)
                .HasForeignKey(fd => fd.FdGrpCd);
        }

        private void configureEntityFdGroup(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<FdGroup>().HasKey(fdg => fdg.FdGrpCd);

            // NOT NULL
            mb.Entity<FdGroup>().Property(fdg => fdg.FdGrpCd).IsRequired();
            mb.Entity<FdGroup>().Property(fdg => fdg.FdGrpDesc).IsRequired();

            // NVARCHAR(x)
            mb.Entity<FdGroup>().Property(fdg => fdg.FdGrpCd).HasMaxLength(4);
            mb.Entity<FdGroup>().Property(fdg => fdg.FdGrpDesc).HasMaxLength(60);
        }

        private void configureEntityNutData(ModelBuilder mb) {
            // PRIMARY KEY (composite)
            mb.Entity<NutData>().HasKey(nd => new {nd.NdbNo, nd.NutrNo});
            mb.Entity<NutData>().HasIndex(nd => new {nd.NdbNo, nd.NutrNo}).IsUnique();

            // NOT NULL
            mb.Entity<NutData>().Property(nd => nd.NdbNo).IsRequired();
            mb.Entity<NutData>().Property(nd => nd.NutrNo).IsRequired();
            mb.Entity<NutData>().Property(nd => nd.NutrVal).IsRequired();
            mb.Entity<NutData>().Property(nd => nd.NumDataPts).IsRequired();
            mb.Entity<NutData>().Property(nd => nd.SrcCd).IsRequired();

            // NVARCHAR(x)
            mb.Entity<NutData>().Property(nd => nd.NdbNo).HasMaxLength(5);
            mb.Entity<NutData>().Property(nd => nd.NutrNo).HasMaxLength(3);
            mb.Entity<NutData>().Property(nd => nd.SrcCd).HasMaxLength(2);
            mb.Entity<NutData>().Property(nd => nd.DerivCd).HasMaxLength(4);
            mb.Entity<NutData>().Property(nd => nd.RefNdbNo).HasMaxLength(5);
            mb.Entity<NutData>().Property(nd => nd.AddNutrMark).HasMaxLength(1);
            mb.Entity<NutData>().Property(nd => nd.StatCmt).HasMaxLength(10);
            mb.Entity<NutData>().Property(nd => nd.AddModDate).HasMaxLength(10);

            // RELATIONSHIP: ONE FoodDes TO MANY NutData
            mb.Entity<NutData>()
                .HasOne(nd => nd.FoodDes)
                .WithMany(fd => fd.NutDatas)
                .HasForeignKey(nd => nd.NdbNo);

            // RELATIONSHIP: ONE SrcCd TO MANY NutData 
            mb.Entity<NutData>()
                .HasOne(nd => nd.Src_Cd)
                .WithMany(sc => sc.NutDatas)
                .HasForeignKey(nd => nd.SrcCd);

            // RELATIONSHIP: ONE DerivCd TO MANY NutData 
            mb.Entity<NutData>()
                .HasOne(nd => nd.Deriv_Cd)
                .WithMany(dc => dc.NutDatas)
                .HasForeignKey(nd => nd.DerivCd);

            // RELATIONSHIP: ONE NutrDef TO MANY NutData
            mb.Entity<NutData>()
                .HasOne(nd => nd.NutrDef)
                .WithMany(nd => nd.NutDatas)
                .HasForeignKey(nd => nd.NutrNo);
        }

        private void configureEntityDatSrcLn(ModelBuilder mb) {
            // PRIMARY KEY (composite)
            mb.Entity<DatSrcLn>().HasKey(dsl => new {dsl.NdbNo, dsl.NutrNo, dsl.DataSrcId});

            // NOT NULL
            mb.Entity<DatSrcLn>().Property(dsl => dsl.NdbNo).IsRequired();
            mb.Entity<DatSrcLn>().Property(dsl => dsl.NutrNo).IsRequired();
            mb.Entity<DatSrcLn>().Property(dsl => dsl.DataSrcId).IsRequired();

            // NVARCHAR(x)
            mb.Entity<DatSrcLn>().Property(dsl => dsl.NdbNo).HasMaxLength(5);
            mb.Entity<DatSrcLn>().Property(dsl => dsl.NutrNo).HasMaxLength(3);
            mb.Entity<DatSrcLn>().Property(dsl => dsl.DataSrcId).HasMaxLength(6);

            // RELATIONSHIP: MANY NutData TO MANY DataSrc
            mb.Entity<DatSrcLn>()
                .HasOne(dsl => dsl.NutData)
                .WithMany(nd => nd.DatSrcLns)
                .HasForeignKey(dsl => new {dsl.NdbNo, dsl.NutrNo});
            mb.Entity<DatSrcLn>()
                .HasOne(dsl => dsl.DataSrc)
                .WithMany(ds => ds.DatSrcLns)
                .HasForeignKey(dsl => dsl.DataSrcId);
        }

        private void configureEntityDataSrc(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<DataSrc>().HasKey(ds => ds.DataSrcId);

            // NOT NULL
            mb.Entity<DataSrc>().Property(ds => ds.DataSrcId).IsRequired();
            mb.Entity<DataSrc>().Property(ds => ds.Title).IsRequired();

            // NVARCHAR(x)
            mb.Entity<DataSrc>().Property(ds => ds.DataSrcId).HasMaxLength(6);
            mb.Entity<DataSrc>().Property(ds => ds.Authors).HasMaxLength(255);
            mb.Entity<DataSrc>().Property(ds => ds.Title).HasMaxLength(255);
            mb.Entity<DataSrc>().Property(ds => ds.Year).HasMaxLength(4);
            mb.Entity<DataSrc>().Property(ds => ds.Journal).HasMaxLength(135);
            mb.Entity<DataSrc>().Property(ds => ds.VolCity).HasMaxLength(16);
            mb.Entity<DataSrc>().Property(ds => ds.IssueState).HasMaxLength(5);
            mb.Entity<DataSrc>().Property(ds => ds.StartPage).HasMaxLength(5);
            mb.Entity<DataSrc>().Property(ds => ds.EndPage).HasMaxLength(5);
        }

        private void configureEntityFootnote(ModelBuilder mb) {
            // SHADOW PROPERTY && PRIMARY KEY
            mb.Entity<Footnote>().Property<int>("FootnoteID");

            /* NOTE: Shadow Properties
             Shadow properties are properties that are not defined in 
             your .NET entity class but are defined for that entity type 
             in the EF Core model. The value and state of these properties 
             is maintained purely in the Change Tracker.
             */

            // NOT NULL
            mb.Entity<Footnote>().Property(f => f.NdbNo).IsRequired();
            mb.Entity<Footnote>().Property(f => f.FootntNo).IsRequired();
            mb.Entity<Footnote>().Property(f => f.FootntTyp).IsRequired();
            mb.Entity<Footnote>().Property(f => f.FootntTxt).IsRequired();

            // NVARCHAR(x)
            mb.Entity<Footnote>().Property(f => f.NdbNo).HasMaxLength(5);
            mb.Entity<Footnote>().Property(f => f.FootntNo).HasMaxLength(4);
            mb.Entity<Footnote>().Property(f => f.FootntTyp).HasMaxLength(1);
            mb.Entity<Footnote>().Property(f => f.NutrNo).HasMaxLength(3);
            mb.Entity<Footnote>().Property(f => f.FootntTxt).HasMaxLength(200);

            // RELATIONSHIP: ONE FoodDes TO MANY Footnotes
            mb.Entity<Footnote>()
                .HasOne(f => f.FoodDes)
                .WithMany(fd => fd.Footnotes)
                .HasForeignKey(f => f.NdbNo);
        }

        private void configureEntityWeight(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<Weight>().HasKey(w => new {w.NdbNo, w.Seq});

            // NOT NULL
            mb.Entity<Weight>().Property(f => f.NdbNo).IsRequired();
            mb.Entity<Weight>().Property(f => f.Seq).IsRequired();
            mb.Entity<Weight>().Property(f => f.Amount).IsRequired();
            mb.Entity<Weight>().Property(f => f.MsreDesc).IsRequired();
            mb.Entity<Weight>().Property(f => f.GmWgt).IsRequired();

            // NVARCHAR(x)
            mb.Entity<Weight>().Property(f => f.NdbNo).HasMaxLength(5);
            mb.Entity<Weight>().Property(f => f.Seq).HasMaxLength(2);
            mb.Entity<Weight>().Property(f => f.MsreDesc).HasMaxLength(84);

            // RELATIONSHIP: ONE FoodDes TO MANY Weights
            mb.Entity<Weight>()
                .HasOne(w => w.FoodDes)
                .WithMany(fd => fd.Weights)
                .HasForeignKey(w => w.NdbNo);
        }

        private void configureEntityLangual(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<Langual>().HasKey(l => new {l.NdbNo, l.FactorCode});

            // NOT NULL
            mb.Entity<Langual>().Property(l => l.NdbNo).IsRequired();
            mb.Entity<Langual>().Property(l => l.FactorCode).IsRequired();

            // NVARCHAR(x)
            mb.Entity<Langual>().Property(l => l.NdbNo).HasMaxLength(5);
            mb.Entity<Langual>().Property(l => l.FactorCode).HasMaxLength(5);

            // RELATIONSHIP: Many FoodDes TO MANY LangDesc
            mb.Entity<Langual>()
                .HasOne(l => l.FoodDes)
                .WithMany(fd => fd.Languals)
                .HasForeignKey(l => l.NdbNo);
            mb.Entity<Langual>()
                .HasOne(l => l.LangDesc)
                .WithMany(ld => ld.Languals)
                .HasForeignKey(l => l.FactorCode);
        }

        private void configureEntityLangDesc(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<LangDesc>().HasKey(ld => ld.FactorCode);

            // NOT NULL
            mb.Entity<LangDesc>().Property(ld => ld.FactorCode).IsRequired();
            mb.Entity<LangDesc>().Property(ld => ld.Description).IsRequired();

            // NVARCHAR(x)
            mb.Entity<LangDesc>().Property(ld => ld.FactorCode).HasMaxLength(5);
            mb.Entity<LangDesc>().Property(ld => ld.Description).HasMaxLength(140);
        }

        private void configureEntityNutrDef(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<NutrDef>().HasKey(nd => nd.NutrNo);

            // NOT NULL
            mb.Entity<NutrDef>().Property(nd => nd.NutrNo).IsRequired();
            mb.Entity<NutrDef>().Property(nd => nd.Units).IsRequired();
            mb.Entity<NutrDef>().Property(nd => nd.NutrDesc).IsRequired();
            mb.Entity<NutrDef>().Property(nd => nd.NumDec).IsRequired();
            mb.Entity<NutrDef>().Property(nd => nd.SrOrder).IsRequired();

            // NVARCHAR(x)
            mb.Entity<NutrDef>().Property(nd => nd.NutrNo).HasMaxLength(3);
            mb.Entity<NutrDef>().Property(nd => nd.Units).HasMaxLength(7);
            mb.Entity<NutrDef>().Property(nd => nd.Tagname).HasMaxLength(20);
            mb.Entity<NutrDef>().Property(nd => nd.NutrDesc).HasMaxLength(60);
            mb.Entity<NutrDef>().Property(nd => nd.NumDec).HasMaxLength(1);
        }

        private void configureEntitySrcCd(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<SrcCd>().HasKey(sc => sc.Src_Cd);

            // NOT NULL
            mb.Entity<SrcCd>().Property(sc => sc.Src_Cd).IsRequired();
            mb.Entity<SrcCd>().Property(sc => sc.SrcCdDesc).IsRequired();

            // NVARCHAR(x)
            mb.Entity<SrcCd>().Property(sc => sc.Src_Cd).HasMaxLength(2);
            mb.Entity<SrcCd>().Property(sc => sc.SrcCdDesc).HasMaxLength(60);
        }

        private void configureEntityDerivCd(ModelBuilder mb) {
            // PRIMARY KEY
            mb.Entity<DerivCd>().HasKey(dc => dc.Deriv_Cd);

            // NOT NULL
            mb.Entity<DerivCd>().Property(dc => dc.Deriv_Cd).IsRequired();
            mb.Entity<DerivCd>().Property(dc => dc.DerivDesc).IsRequired();

            // NVARCHAR(x)
            mb.Entity<DerivCd>().Property(sc => sc.Deriv_Cd).HasMaxLength(4);
            mb.Entity<DerivCd>().Property(sc => sc.DerivDesc).HasMaxLength(120);
        }
    }
}