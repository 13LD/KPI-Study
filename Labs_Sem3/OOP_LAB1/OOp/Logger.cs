using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp
{
    public class Logger
    {
        static FileStream log;
        static StreamWriter writer;
        private Logger()
        { }

        public static void Init()
        {
            log = new FileStream("F:\\Films\\OOP_LAB1\\log.txt", FileMode.Truncate, FileAccess.Write);
            writer = new StreamWriter(log);
            WriteMsg("Logging started");
        }
        public static void WriteMsg(string m)
        {
            writer.WriteLine(DateTime.Now.ToString() + " " + m);
        }
        public static void Final()
        {
            WriteMsg("Logging finished");
            writer.Flush();
            log.Close();
        }
    }

}
