using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace clock_baobao
{
   public  class FileIO
    {
        public static string outstr = string.Empty;
      public  FileIO(string path)
        {
            StreamReader sr = File.OpenText(path);
            outstr=sr.ReadToEnd();
        }
        public static string Out(string path)
        {
            StreamReader sr = File.OpenText(path);
           string str = sr.ReadToEnd();

            return str;

        }

        //StreamReader sr = new StreamReader(@"C: \Users\baobao\Desktop\clock\datatxt.txt");@"C: \Users\baobao\Desktop\clock\datatxt.txt"
     
     
    }
}
