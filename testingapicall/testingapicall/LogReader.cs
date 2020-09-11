using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace testingapicall
{
    public class LogReader
    {
        string shaper = "The Shaper's Realm";
        public bool EnteredBossArea(out string bossarea,out string instanceip,out DateTime timestamp)
        {
            instanceip = null;
            bossarea = null;
            timestamp = DateTime.MinValue;
            using (var reader = new StreamReader(@"C:\Users\Benjamin Roesdal\Desktop\learningstuff\Client.txt"))
            {
                if (reader.BaseStream.Length > 1024)
                {
                    reader.BaseStream.Seek(-1024, SeekOrigin.End);
                }
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("Connecting to instance server at"))
                    {
                        Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                        MatchCollection result = ip.Matches(line);
                        instanceip = result[0].ToString();
                    }
                    if (line.Contains(shaper))
                    {
                        bossarea = shaper;
                        Regex time = new Regex(@"\b\d{1,2}\:\d{1,2}\:\d{1,2}\b");
                        MatchCollection timeresult = time.Matches(line);
                        timestamp = DateTime.Parse(timeresult[0].ToString());
                    }
                }

                if (instanceip != null && bossarea != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
