using System;
using System.Collections.Generic;
using System.Linq;
using USDAFoodDB.Context;
using USDAFoodDB.Models;

namespace USDAFoodDB.Tools {
    public class DataInitializer {
        private const int BATCH_SIZE_DELIM = 1000;
        private const string DATA_FILEPATH = "./Src/SR-Leg_ASC";

        private static void AddToDatabase<T>(USDAFoodContext originalContext, ref List<T> objs,
            int batchSize = BATCH_SIZE_DELIM) where T : class {
            USDAFoodContext context;
            using (context = new USDAFoodContext(originalContext.DbContextOptions)) {
                int count = 0;

                foreach (T obj in objs) {
                    count = count + 1;
                    context = context.BulkInsert(obj, count, batchSize);
                }

                context.SaveChanges();
            }
        }

        private static void Init_FdGroups(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/FD_GROUP.txt");
            List<FdGroup> fdGroups = new List<FdGroup>();

            foreach (string[] datapoint in dataList) {
                fdGroups.Add(new FdGroup {
                    FdGrpCd = datapoint[0],
                    FdGrpDesc = datapoint[1]
                });
            }

            AddToDatabase(context, ref fdGroups);
        }

        private static void Init_LangDesc(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/LANGDESC.txt");
            List<LangDesc> langDescs = new List<LangDesc>();

            foreach (string[] datapoint in dataList) {
                langDescs.Add(new LangDesc() {
                    FactorCode = datapoint[0],
                    Description = datapoint[1]
                });
            }

            AddToDatabase(context, ref langDescs);
        }

        private static void Init_FoodDes(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/FOOD_DES.txt");
            List<FoodDes> foodDeses = new List<FoodDes>();

            foreach (string[] datapoint in dataList) {
                foodDeses.Add(new FoodDes() {
                    NdbNo = datapoint[0],
                    FdGrpCd = datapoint[1],
                    LongDesc = datapoint[2],
                    ShrtDesc = datapoint[3],
                    ComName = datapoint[4],
                    ManufacName = datapoint[5],
                    Survey = datapoint[6],
                    RefDesc = datapoint[7],
                    Refuse = Common.GetValidInt32FromString(datapoint[8]),
                    SciName = datapoint[9],
                    NFactor = Common.GetValidDoubleFromString(datapoint[10]),
                    ProFactor = Common.GetValidDoubleFromString(datapoint[11]),
                    FatFactor = Common.GetValidDoubleFromString(datapoint[12]),
                    ChoFactor = Common.GetValidDoubleFromString(datapoint[13])
                });
            }

            AddToDatabase(context, ref foodDeses);
        }

        private static void Init_Langual(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/LANGUAL.txt");
            List<Langual> languals = new List<Langual>();

            foreach (string[] datapoint in dataList) {
                languals.Add(new Langual() {
                    NdbNo = datapoint[0],
                    FactorCode = datapoint[1]
                });
            }

            AddToDatabase(context, ref languals);
        }

        private static void Init_Footnote(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/FOOTNOTE.txt");
            List<Footnote> footnotes = new List<Footnote>();

            foreach (string[] datapoint in dataList) {
                footnotes.Add(new Footnote() {
                    NdbNo = datapoint[0],
                    FootntNo = datapoint[1],
                    FootntTyp = datapoint[2],
                    NutrNo = datapoint[3],
                    FootntTxt = datapoint[4]
                });
            }

            AddToDatabase(context, ref footnotes);
        }

        private static void Init_Weight(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/WEIGHT.txt");
            List<Weight> weights = new List<Weight>();

            foreach (string[] datapoint in dataList) {
                weights.Add(new Weight() {
                    NdbNo = datapoint[0],
                    Seq = datapoint[1],
                    Amount = Common.GetValidDoubleFromString(datapoint[2]),
                    MsreDesc = datapoint[3],
                    GmWgt = Common.GetValidDoubleFromString(datapoint[4]),
                    NumDataPts = Common.GetValidInt32FromString(datapoint[5]),
                    StdDev = Common.GetValidDoubleFromString(datapoint[6])
                });
            }

            AddToDatabase(context, ref weights);
        }

        private static void Init_DerivCd(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/DERIV_CD.txt");
            List<DerivCd> derivCds = new List<DerivCd>();

            foreach (string[] datapoint in dataList) {
                derivCds.Add(new DerivCd() {
                    Deriv_Cd = datapoint[0],
                    DerivDesc = datapoint[1]
                });
            }

            AddToDatabase(context, ref derivCds);
        }

        private static void Init_SrcCd(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/SRC_CD.txt");
            List<SrcCd> srcCds = new List<SrcCd>();

            foreach (string[] datapoint in dataList) {
                srcCds.Add(new SrcCd() {
                    Src_Cd = datapoint[0],
                    SrcCdDesc = datapoint[1]
                });
            }

            AddToDatabase(context, ref srcCds);
        }

        private static void Init_NutrDef(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/NUTR_DEF.txt");
            List<NutrDef> nutrDefs = new List<NutrDef>();

            foreach (string[] datapoint in dataList) {
                nutrDefs.Add(new NutrDef() {
                    NutrNo = datapoint[0],
                    Units = datapoint[1],
                    Tagname = datapoint[2],
                    NutrDesc = datapoint[3],
                    NumDec = datapoint[4],
                    SrOrder = Common.GetValidInt32FromString(datapoint[5])
                });
            }

            AddToDatabase(context, ref nutrDefs);
        }

        private static void Init_DataSrc(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/DATA_SRC.txt");
            List<DataSrc> dataSrcs = new List<DataSrc>();

            foreach (string[] datapoint in dataList) {
                dataSrcs.Add(new DataSrc() {
                    DataSrcId = datapoint[0],
                    Authors = datapoint[1],
                    Title = datapoint[2],
                    Year = datapoint[3],
                    Journal = datapoint[4],
                    VolCity = datapoint[5],
                    IssueState = datapoint[6],
                    StartPage = datapoint[7],
                    EndPage = datapoint[8]
                });
            }

            AddToDatabase(context, ref dataSrcs);
        }

        private static void Init_NutData(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/NUT_DATA.txt");
            List<NutData> nutDatas = new List<NutData>();

            foreach (string[] datapoint in dataList) {
                nutDatas.Add(new NutData() {
                    NdbNo = datapoint[0],
                    NutrNo = datapoint[1],
                    NutrVal = Common.GetValidDoubleFromString(datapoint[2]),
                    NumDataPts = Common.GetValidDoubleFromString(datapoint[3]),
                    StdError = Common.GetValidDoubleFromString(datapoint[4]),
                    SrcCd = datapoint[5],
                    DerivCd = string.IsNullOrEmpty(datapoint[6]) ? null : datapoint[6],
                    RefNdbNo = datapoint[7],
                    AddNutrMark = datapoint[8],
                    NumStudies = Common.GetValidInt32FromString(datapoint[9]),
                    Min = Common.GetValidDoubleFromString(datapoint[10]),
                    Max = Common.GetValidDoubleFromString(datapoint[11]),
                    Df = Common.GetValidInt32FromString(datapoint[12]),
                    LowEb = Common.GetValidDoubleFromString(datapoint[13]),
                    UpEb = Common.GetValidDoubleFromString(datapoint[14]),
                    StatCmt = datapoint[15],
                    AddModDate = datapoint[16]
                });
            }

            AddToDatabase(context, ref nutDatas);
        }

        private static void Init_DatSrcLn(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/DATSRCLN.fixed.txt");
            List<DatSrcLn> datSrcLns = new List<DatSrcLn>();

            foreach (string[] datapoint in dataList) {
                datSrcLns.Add(new DatSrcLn() {
                    NdbNo = datapoint[0],
                    NutrNo = datapoint[1],
                    DataSrcId = datapoint[2]
                });
            }

            AddToDatabase(context, ref datSrcLns);
        }

        public static void Initialize(USDAFoodContext context) {
            Common.NarrateAction("Ensuring DATSRCLN records", () => DataCorrection.FixDatSrcLnRecords() );
            Common.NarrateAction("Ensuring Empty Database", () => context.Database.EnsureDeleted() );
            Common.NarrateAction("Ensuring Created Database", () => context.Database.EnsureCreated() );

            if (!context.FdGroups.Any()) {
                Common.NarrateAction("Adding FdGroups", () => Init_FdGroups(context));
            }

            if (!context.LangDescs.Any()) {
                Common.NarrateAction("Adding LangDescs", () => Init_LangDesc(context));
            }

            if (!context.FoodDeses.Any()) {
                Common.NarrateAction("Adding FoodDeses", () => Init_FoodDes(context));
            }

            if (!context.Languals.Any()) {
                Common.NarrateAction("Adding Languals", () => Init_Langual(context));
            }

            if (!context.Footnotes.Any()) {
                Common.NarrateAction("Adding Footnotes", () => Init_Footnote(context));
            }

            if (!context.Weights.Any()) {
                Common.NarrateAction("Adding Weights", () => Init_Weight(context));
            }

            if (!context.DerivCds.Any()) {
                Common.NarrateAction("Adding DerivCds", () => Init_DerivCd(context));
            }

            if (!context.SrcCds.Any()) {
                Common.NarrateAction("Adding SrcCds", () => Init_SrcCd(context));
            }

            if (!context.NutrDefs.Any()) {
                Common.NarrateAction("Adding NutrDefs", () => Init_NutrDef(context));
            }

            if (!context.DataSrcs.Any()) {
                Common.NarrateAction("Adding DataSrcs", () => Init_DataSrc(context));
            }

            if (!context.NutDatas.Any()) {
                Common.NarrateAction("Adding NutDatas", () => Init_NutData(context));
            }

            if (!context.DatSrcLns.Any()) {
                Common.NarrateAction("Adding DatSrcLns", () => Init_DatSrcLn(context));
            }
        }
    }
}