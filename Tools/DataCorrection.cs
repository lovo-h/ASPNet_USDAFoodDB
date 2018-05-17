using System;
using System.Collections.Generic;
using System.Text;

namespace USDAFoodDB.Tools {
    public class DataCorrection {
        public static void FixDatSrcLnRecords() {
            const string srcDirectoryFilePath = "./Src/SR-Leg_ASC/";
            const string datasrclnFilepath = srcDirectoryFilePath + "DATSRCLN.txt";
            const string nutdataFilepath = srcDirectoryFilePath + "NUT_DATA.txt";
            const string newDatasrclnFilepath = srcDirectoryFilePath + "DATSRCLN.fixed.txt";

            if (System.IO.File.Exists(newDatasrclnFilepath)) {
                Console.WriteLine(newDatasrclnFilepath + " already exists.");
                return;
            }

            List<string[]> datasrclnList = Common.ReadFilepath(datasrclnFilepath);
            List<string[]> nutdataList = Common.ReadFilepath(nutdataFilepath);

            Dictionary<string, SortedSet<string>> nutdataDictionary = new Dictionary<string, SortedSet<string>>();

            string ndbNo;
            string nutrNo;

            foreach (string[] nutdataRow in nutdataList) {
                ndbNo = nutdataRow[0];
                nutrNo = nutdataRow[1];

                if (!nutdataDictionary.ContainsKey(ndbNo)) {
                    nutdataDictionary[ndbNo] = new SortedSet<string>();
                }

                nutdataDictionary[ndbNo].Add(nutrNo);
            }

            StringBuilder sb = new StringBuilder();
            int invalidDataCount = 0;

            foreach (string[] datasrclnStrings in datasrclnList) {
                ndbNo = datasrclnStrings[0];
                nutrNo = datasrclnStrings[1];

                if (!nutdataDictionary.ContainsKey(ndbNo) || !nutdataDictionary[ndbNo].Contains(nutrNo)) {
                    invalidDataCount++;
                    continue;
                }

                sb.Append(string.Join("^", datasrclnStrings) + "\n");
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(newDatasrclnFilepath)) {
                file.Write(sb.ToString());
            }
        }
    }
}