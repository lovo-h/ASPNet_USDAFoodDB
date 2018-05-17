using System.Collections.Generic;

namespace USDAFoodDB.Models {
    public class FdGroup {
        public string FdGrpCd { get; set; }
        public string FdGrpDesc { get; set; }

        public List<FoodDes> FoodDeses { get; set; }
    }
}