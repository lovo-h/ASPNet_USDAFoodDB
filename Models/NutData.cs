namespace USDAFoodDB.Models {
    public class NutData {
        public string NdbNo { get; set; }
        public string NutrNo { get; set; }
        public double NutrVal { get; set; }
        public double NumDataPts { get; set; }
        public double StdError { get; set; }
        public string SrcCd { get; set; }
        public string DerivCd { get; set; }
        public string RefNdbNo { get; set; }
        public string AddNutrMark { get; set; }
        public int NumStudies { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public int Df { get; set; }
        public double LowEb { get; set; }
        public double UpEb { get; set; }
        public string StatCmt { get; set; }
        public string AddModDate { get; set; }
    }
}