namespace USDAFoodDB.Models {
    public class DatSrcLn {
        public string NdbNo { get; set; }
        public string NutrNo { get; set; }
        public string DataSrcId { get; set; }

        public DataSrc DataSrc { get; set; }
        public NutData NutData { get; set; }
    }
}