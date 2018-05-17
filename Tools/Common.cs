using System;
using System.Collections.Generic;

namespace USDAFoodDB.Tools {
    public class Common {
        public static List<string[]> ReadFilepath(string filePath) {
            System.IO.StreamReader fileReader = new System.IO.StreamReader(filePath);

            List<string[]> dataList = new List<string[]>();
            string line;

            while ((line = fileReader.ReadLine()) != null) {
                dataList.Add(line.Replace("~", "").Split("^"));
            }

            fileReader.Close();
            return dataList;
        }

        public static double GetValidDoubleFromString(string doubleString) {
            return string.IsNullOrEmpty(doubleString) ? 0.0 : Convert.ToDouble(doubleString);
        }

        public static Int32 GetValidInt32FromString(string int32String) {
            return string.IsNullOrEmpty(int32String) ? 0 : Convert.ToInt32(int32String);
        }

        public static void NarrateAction(string actionStr, Action theAction) {
            Console.Write(actionStr + "... ");
            theAction();
            Console.WriteLine("Done");
        }
    }
}