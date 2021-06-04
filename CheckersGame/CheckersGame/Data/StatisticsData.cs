using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerGame.Data
{
    public class StatisticsData
    {

        public StatisticsData()
        {

        }

        public string[] ReadStatistics()
        {
            int counter = 0;
            string[] lines = new string[6];
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\vladm\Desktop\CheckersGame\CheckersGame\statistics.txt");
            while ((line = file.ReadLine()) != null)
            {
                lines[counter]=(line);
                counter++;
            }

            file.Close();
            return lines;
        }

        public void WriteStatistics(bool normalBlackWin, bool surrenderBlackWin, bool normalWhiteWin, bool surrenderWhiteWin)
        {
            string[] lines = ReadStatistics();

            if(normalBlackWin)
            {
                lines[0] = (Int32.Parse(lines[0]) + 1).ToString();
            }
         
            if (normalWhiteWin)
            {
                lines[1] = (Int32.Parse(lines[1]) + 1).ToString();
            }

            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"C:\Users\vladm\Desktop\CheckersGame\CheckersGame\statistics.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
    }
}
