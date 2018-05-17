using System.Collections.Generic;

namespace USDAFoodDB.Models {
    public class FoodDes {
        public string NdbNo { get; set; }
        public string FdGrpCd { get; set; }
        public string LongDesc { get; set; }
        public string ShrtDesc { get; set; }
        public string ComName { get; set; }
        public string ManufacName { get; set; }
        public string Survey { get; set; }
        public string RefDesc { get; set; }
        public int Refuse { get; set; }
        public string SciName { get; set; }
        public double NFactor { get; set; }
        public double ProFactor { get; set; }
        public double FatFactor { get; set; }
        public double ChoFactor { get; set; }

        public FdGroup FdGroup { get; set; }
        public List<Langual> Languals { get; set; }

        public List<NutData> NutDatas { get; set; }
        public List<Footnote> Footnotes { get; set; }
        public List<Weight> Weights { get; set; }
    }
}