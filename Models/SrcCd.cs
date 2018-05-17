using System.Collections.Generic;

namespace USDAFoodDB.Models {
    public class SrcCd {
        public string Src_Cd { get; set; }
        public string SrcCdDesc { get; set; }

        public List<NutData> NutDatas { get; set; }
    }
}