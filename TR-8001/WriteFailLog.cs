using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TR_8001
{
    public class WriteFailLog
    {


        public void Read(string filePath, string failLogPath)
        {
            List<String> newlines = new List<String>();

            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                String line = null;
                String newline = null;

                string nameFile = null;

                line = reader.ReadToEnd();

                String[] lines = line.Split('\n');

                string[] items1 = lines[1].Split(',');

                string[] items2 = lines[2].Split(',');

                int i = 0;
                int j = 6;
                for (i = 0; i < 8; i++)
                {
                    if (items1[i].Contains("BoardName"))
                    {
                        newline = "BoardName ," + items2[i] + "\r\n";
                    }

                    if (items1[i].Contains("BarCode"))
                    {
                        newline += "BarCode , " + items2[i] + "\r\n";
                        nameFile = items2[i];
                    }
                }
                newline += "Result , FAIL\r\n";
                newline += $"Time , {DateTime.Now.ToString("hh:mm:ss")} , {DateTime.Now.ToString("dd/MM/yyyy")}";

                string[] items5 = lines[5].Split(',');
                for (i = 0; i < lines[5].Split(',').Count(); i++)
                {
                    if (items5[i].Contains("Result"))
                    {
                        for (j = 6; j < lines.Count()-1; j++)
                        {

                            if (lines[j].Contains(","))
                            {
                                if (Convert.ToInt32(lines[j].Split(',')[i]) == 1)
                                {
                                    if(!newline.Contains("PartName"))
                                        newline += "\n" + lines[5];
                                    newline += lines[j] + "";
                                }
                            }
                            else
                            {
                                newline += lines[j] + "";
                            }

                        }
                    }
                }

                string newfilePath = failLogPath + "\\" + nameFile + ".csv";

                try
                {
                    using (StreamWriter writer = new StreamWriter(newfilePath, true))
                    {
                        writer.WriteLine(newline);
                        writer.Close();
                    }
                }

                catch (Exception ex)
                {
                    MsgBox.ShowException(ex.Message, "Error", "OK", "Cancel");
                    
                }
            }
        }
    }
}
