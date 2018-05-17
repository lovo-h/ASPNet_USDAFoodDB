using System.Collections.Generic;

namespace USDAFoodDB.Models {
    public class LangDesc {
        public string FactorCode { get; set; }
        public string Description { get; set; }

        public List<Langual> Languals { get; set; }
    }
}