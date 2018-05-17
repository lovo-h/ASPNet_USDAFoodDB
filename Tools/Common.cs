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
    }
}
