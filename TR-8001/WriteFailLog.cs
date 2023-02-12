using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR_8001
{
    public class WriteFailLog
    {
        public bool Read(string filePath, string failLogPath)
        {

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    String line = null;
                    String newline = null;

                    string nameFile = null;

                    line = reader.ReadToEnd();

                    String[] lines = line.Split('\n');

                    string[] items1 = lines[1].Split(',');

                    string[] items2 = lines[2].Split(',');

                    int i = 0;
                    for (i = 0; i <= items1.Count() - 1; i++)
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

                    newline += "Time , " + DateTime.Now.ToString("hh:mm:ss") + "," + DateTime.Now.ToString("dd/MM/yyyy") + "\r\n\r\n";

                    newline += lines[5];

                    string[] items5 = lines[5].Split(',');
                    try
                    {
                        for (i = 0; i <= items5.Count() - 1; i++)
                        {
                            if (items5[i].Contains("Result"))
                            {
                                for (int j = 6; j < lines.Count() - 1; j++)
                                {
                                    if (Convert.ToInt32(lines[j].Split(',')[i]) == 1)
                                    {
                                        newline += lines[j];
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowException(ex.Message, "ERROR", "OK", "Cancel");
                        return false;
                    }


                    string newfilePath = failLogPath + "\\" + nameFile + ".csv";

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(newfilePath, true))
                        {
                            writer.WriteLine(newline);
                            writer.Close();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowException(ex.Message, "ERROR", "OK", "Cancel");
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
