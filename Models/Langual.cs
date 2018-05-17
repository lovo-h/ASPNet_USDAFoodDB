namespace USDAFoodDB.Models {
    public class Langual {
        public string NdbNo { get; set; }
        public string FactorCode { get; set; }

        public FoodDes FoodDes { get; set; }
        public LangDesc LangDesc { get; set; }
    }
}