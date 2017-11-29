using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace clock_baobao
{
   public  class Seting
    {
       
        public static string ApppRuanPath = System.Environment.CurrentDirectory.ToString();
        public static string AppDirectroyPath = System.Environment.CurrentDirectory.ToString().Replace(@"bin\Debug", "");
        public static string SetingPath = string.Empty;
        public static string SetingPathWeatherTxt = AppDirectroyPath + @"bin\datasrc\datatxt.txt";
        public static string SetingPathWeatherTatusImg = AppDirectroyPath + @"bin\datasrc\status.txt";


        public Seting()
        {
             GetSetingPathWeatherTxt();
        }
        public static string  GetSetingPathWeatherTxt()
        {
            SetingPathWeatherTxt = AppDirectroyPath + @"bin\datasrc\datatxt.txt";
            return SetingPathWeatherTxt;
        }


    }
}
