using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace clock_baobao
{
    public class heweather
    {
        public static string  location = string.Empty;
        public static string forecast = string.Empty; 
        public static string status = string.Empty;
        public static string uptime = string.Empty;
        public static string now = string.Empty;
        public static string life = string.Empty;
        public static string [] locations, forecasts,uptimes,forecasts_day1, forecasts_day2, forecasts_day3,nows,lifes;
       
     public   heweather(string callbackstr)
        {
            urlencoding(callbackstr);
        }
        public static string urlencoding(string WaiteEncondingstr)
        {
            string EncodingurlStr = "";
            WaiteEncondingstr = WaiteEncondingstr.Substring(WaiteEncondingstr.IndexOf("{") + 1).ToString();
            WaiteEncondingstr= WaiteEncondingstr.Substring(0, WaiteEncondingstr.Length - (WaiteEncondingstr.Length - (WaiteEncondingstr.LastIndexOf("}" ))));
            WaiteEncondingstr = WaiteEncondingstr.Substring(WaiteEncondingstr.IndexOf("[") + 1).ToString();
            WaiteEncondingstr = WaiteEncondingstr.Substring(0, WaiteEncondingstr.Length - (WaiteEncondingstr.Length - (WaiteEncondingstr.LastIndexOf("]"))));
            WaiteEncondingstr = WaiteEncondingstr.Substring(WaiteEncondingstr.IndexOf("{") + 1).ToString();
            WaiteEncondingstr = WaiteEncondingstr.Substring(0, WaiteEncondingstr.Length - (WaiteEncondingstr.Length - (WaiteEncondingstr.LastIndexOf("}"))));

            WaiteEncondingstr = WaiteEncondingstr.Replace("\"basic\"", "%basic");
            WaiteEncondingstr = WaiteEncondingstr.Replace("\"daily_forecast\"", "%forecast");
            WaiteEncondingstr = WaiteEncondingstr.Replace("\"status\"", "%status");
            WaiteEncondingstr = WaiteEncondingstr.Replace("\"update\"", "%update");
            WaiteEncondingstr = WaiteEncondingstr.Replace("\"now\"", "%now");
            WaiteEncondingstr = WaiteEncondingstr.Replace("\"lifestyle\"", "%lifestyle");
            
              
                

            string[] weatherdate = new string[5];
            weatherdate = WaiteEncondingstr.Split('%');
           
          
            for (int i = 0; i < weatherdate.Length; i++)
            {
                switch (hasstr(weatherdate[i]))
                {
                    case"b" :
                        location = weatherdate[i];
                        break;
                    case "f":
                        forecast = weatherdate[i];
                        break;
                    case "n":
                        now = weatherdate[i];
                        break;
                    case "l":
                        life = weatherdate[i];
                        break;
                    case "u":
                       uptime = weatherdate[i];
                        break;
                    case "s":
                       status = weatherdate[i];
                        break;
                }
            }


            now = now.Replace("now:{", "");
            now = now.Replace("}", "");
            now = now.Replace("\"", "");
            nows = now.Split(',');

            location = location.Replace("basic:{", "");
            location = location.Replace("},", "");
            location = location.Replace("\"", "");
            locations = location.Split(',');
            forecast = forecast.Replace("forecast:[", "");
            forecast = forecast.Replace("]", "");
            forecast = forecast.Replace("},", "},%");
            forecast = forecast.Replace("\"", "");
            forecasts = forecast.Split('%');

            //forecast = forecast.Replace("forecast:[", "");
            //forecast = forecast.Replace("]", "");
            //forecast = forecast.Replace("},", "},%");
            //forecast = forecast.Replace("\"", "");
            //forecasts = forecast.Split('%');

            forecasts_day1 = forecasts[0].Replace("{", "").Replace("}", "").Split(',');
            forecasts_day2 = forecasts[1].Replace("{", "").Replace("}", "").Split(',');
            forecasts_day3 = forecasts[2].Replace("{", "").Replace("}", "").Split(',');
            uptime = uptime.Replace("update:{", "");
            uptime = uptime.Replace("},", "");
            uptime = uptime.Replace("\"", "");
            uptimes = uptime.Split(',');
            status = status.Replace("status:\"", "");
            status = status.Replace("\",", "");

            life = life.Replace("lifestyle:[", "");
            life = life.Replace("]", "");
            life = life.Replace("\"", "");
            life = life.Replace("{", "");
            life = life.Replace("},", "%");
            life = life.Replace("}","");
            lifes = life.Split('%');

            //status 测试通过；
            //showdata(locations) 测试通过；
            // showdata(forecasts)测试通过；
            // showdata(uptimes)测试通过；
            // showdata(lifes)测试通过；
            //showdata(nows)测试通过；
             WaiteEncondingstr = showdata(locations) + showdata(forecasts) + showdata(uptimes) + showdata(lifes) + showdata(nows)+status;
           // WaiteEncondingstr = showdata(nows);

            EncodingurlStr = WaiteEncondingstr;
            return EncodingurlStr ;
        }

        public static  string showdata(string [] data)
        {
            string datastr = string.Empty;
            foreach (string str in data)
            {
                if (str.Trim() != null || str.Trim() != "")
                {
                     datastr +=  str  +"\r\n";
                }
               
            }
            return datastr;
        }

        public static string hasstr(string str)
        {

            if (str.Contains("basic"))
            {
                return "b";
            }
            else if (str.Contains("forecast"))
            {
                return "f";
            }
            else if (str.Contains("now"))
            {
                return "n";
            }
            else if (str.Contains("lifestyle"))
            {
                return "l";
            }
            else if (str.Contains("status"))
            {
                return "s";

            }
            else if (str.Contains("update"))
            {
                return "u";
            }
            else
            {
                return null;
            }
                
           
        }

        public static string GetLifeType(string LifeData)
        {
            string[] LifeDatas = LifeData.Split(',');
            LifeData = LifeDatas[2];
            LifeData = LifeData.Replace("type:", "");
            return LifeData;
        }
        public static string GetLifeValue(int key ,string LifeData)
        {

          string []  LifeDatas  = LifeData.Split(',');
            
          LifeData = LifeDatas[key];
     
            return LifeData;
            
        }
        public static string GetLifeValue(int key, string LifeData,bool hasKey)
        {
            hasKey = false;
            string[] LifeDatas = LifeData.Split(',');
            LifeData = LifeDatas[key];
            if (hasKey == true)
            {
                return LifeData;
            }
            else
            {
              LifeData=LifeData.Replace("brf:", "");
              LifeData = LifeData.Replace("txt:", "");
              LifeData = LifeData.Replace("type:", "");
              return LifeData;
            }
           

        }

    }
}
