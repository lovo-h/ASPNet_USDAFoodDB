using System;
using System.Collections.Generic;
using USDAFoodDB.Context;
using USDAFoodDB.Models;

namespace USDAFoodDB.Tools {
    public class DataInitializer {
        private const string DATA_FILEPATH = "./Src/SR-Leg_ASC";

        private static void Init_FoodDes(USDAFoodContext context) {
            List<string[]> dataList = Common.ReadFilepath(DATA_FILEPATH + "/FOOD_DES.txt");
            List<FoodDes> foodDeses = new List<FoodDes>();

            foreach (string[] datapoint in dataList) {
                foodDeses.Add(new FoodDes() {
                    NdbNo = datapoint[0],
                    FdGrpCd = datapoint[1],
                    LongDesc = datapoint[2],
                    ShrtDesc = datapoint[3],
                    ComName = datapoint[4],
                    ManufacName = datapoint[5],
                    Survey = datapoint[6],
                    RefDesc = datapoint[7],
                    Refuse = string.IsNullOrEmpty(datapoint[8]) ? 0 : Convert.ToInt32(datapoint[8]),
                    SciName = datapoint[9],
                    NFactor = string.IsNullOrEmpty(datapoint[10]) ? 0.0 : Convert.ToDouble(datapoint[10]),
                    ProFactor = string.IsNullOrEmpty(datapoint[11]) ? 0.0 : Convert.ToDouble(datapoint[11]),
                    FatFactor = string.IsNullOrEmpty(datapoint[12]) ? 0.0 : Convert.ToDouble(datapoint[12]),
                    ChoFactor = string.IsNullOrEmpty(datapoint[13]) ? 0.0 : Convert.ToDouble(datapoint[13])
                });
            }
        }
    }
}
