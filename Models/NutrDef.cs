using System.Collections.Generic;

namespace USDAFoodDB.Models {
    public class NutrDef {
        public string NutrNo { get; set; }
        public string Units { get; set; }
        public string Tagname { get; set; }
        public string NutrDesc { get; set; }
        public string NumDec { get; set; }
        public int SrOrder { get; set; }

        public List<NutData> NutDatas { get; set; }
    }
}