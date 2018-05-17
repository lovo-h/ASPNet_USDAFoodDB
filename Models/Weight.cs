namespace USDAFoodDB.Models {
    public class Weight {
        public string NdbNo { get; set; }
        public string Seq { get; set; }
        public double Amount { get; set; }
        public string MsreDesc { get; set; }
        public double GmWgt { get; set; }
        public int NumDataPts { get; set; }
        public double StdDev { get; set; }

        public FoodDes FoodDes { get; set; }
    }
}