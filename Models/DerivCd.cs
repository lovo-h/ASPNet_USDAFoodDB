using System.Collections.Generic;

namespace USDAFoodDB.Models {
    public class DerivCd {
        public string Deriv_Cd { get; set; }
        public string DerivDesc { get; set; }

        public List<NutData> NutDatas { get; set; }
    }
}