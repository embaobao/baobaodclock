using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace clock_baobao
{
    class WeatherData
    {
      

        public static Dictionary<string, string> Weathertxt = new Dictionary<string, string>();
        public static Dictionary<string, string> WeatherStatusimglist = new Dictionary<string, string>();
        private Dictionary<string, string> ForeCaseDatelist1 = new Dictionary<string, string>();
        private Dictionary<string, string> ForeCaseDatelist2 = new Dictionary<string, string>();
        private Dictionary<string, string> ForeCaseDatelist3 = new Dictionary<string, string>();
        private Dictionary<string, string> FoCaNows = new Dictionary<string, string>();
        private Dictionary<string, string[]> FoCaLifes = new Dictionary<string, string[]>();


        string HttpGetDateString = string.Empty;

        public WeatherData(string location)
        {
            LoadweatherTxt();
            LoadStatusimgList();
            HttpGetDateString = HttpGet(location);
            HttpGetDateString = heweather.urlencoding(HttpGetDateString);
            GetForeCaseDate();
            AddList(heweather.nows,FoCaNows);
            loadLifes();

        }


        public static void AddList(string[] strs,Dictionary<string, string> list)

        {
            try
            {
                foreach (string s in strs)
                {
                    string[] ss = s.Trim().Split(':');
                    if (ss.Length >= 2)
                    {
                        list.Add(ss[0], ss[1]);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
     
        private void loadLifes()
        {
            string[] li = heweather.lifes;
            foreach (string str in li)
            {
                string[] lifetxt =null;
                string key= heweather.GetLifeType(str);
                string brf = heweather.GetLifeValue(0, str, false);
                string txt = heweather.GetLifeValue(1,str,false);
                lifetxt = new string[] { brf, txt };
                FoCaLifes.Add(key,lifetxt);
            }

        }
        public bool GetForeCaseDate()
        {
            ForeCaseDatelist1.Clear();
            ForeCaseDatelist2.Clear();
            ForeCaseDatelist3.Clear();
            string[] loc = heweather.locations;
            string[] times = heweather.uptimes;
            string[] day1 = heweather.forecasts_day1;
            string[] day2 = heweather.forecasts_day2;
            string[] day3 = heweather.forecasts_day3;
           // string[] nows = heweather.nows;
           // string[] lifes = heweather.lifes;
            string forecasedata = "";
            if (heweather.status == "ok")
            {
                try
                {

                   
                    foreach (string s in times)
                    {
                        string[] ss = s.Trim().Split(':');
                        if (ss.Length >= 2)
                        {
                            ForeCaseDatelist1.Add(ss[0], ss[1]);
                            ForeCaseDatelist2.Add(ss[0], ss[1]);
                            ForeCaseDatelist3.Add(ss[0], ss[1]);
                        }

                    }
                
                    foreach (string s in loc)
                    {
                        string[] ss = s.Trim().Split(':');
                        if (ss.Length >= 2)
                        {
                            ForeCaseDatelist1.Add(ss[0], ss[1]);
                            ForeCaseDatelist2.Add(ss[0], ss[1]);
                            ForeCaseDatelist3.Add(ss[0], ss[1]);
                        }
                    }
                    foreach (string s in day1)
                    {
                        string[] ss = s.Trim().Split(':');
                        if (ss.Length >= 2)
                        {
                            ForeCaseDatelist1.Add(ss[0], ss[1]);

                        }
                    }
                    foreach (string s in day2)
                    {
                        string[] ss = s.Trim().Split(':');
                        if (ss.Length >= 2)
                        {

                            ForeCaseDatelist2.Add(ss[0], ss[1]);
                        }
                    }
                    foreach (string s in day3)
                    {
                        string[] ss = s.Trim().Split(':');
                        if (ss.Length >= 2)
                        {

                            ForeCaseDatelist3.Add(ss[0], ss[1]);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }



            }
            else
            {

                // forecasedata="天气数据获取失败！";
                return false;
            }
            return true;

        }
        public  void LoadweatherTxt()
        {
            string txt = FileIO.Out(Seting.SetingPathWeatherTxt);
            txt = txt.Replace("\r\n", "");
            string[] WeatherTxts = txt.Trim().Split(',');
            txt = "";
         
            try
            {
                for (int i = 0; i < WeatherTxts.Length - 1; i++)
                {
                    if (!string.IsNullOrEmpty(WeatherTxts[i].Trim()))
                    {
                        Weathertxt.Add(WeatherTxts[i], WeatherTxts[i + 1]);
                        i++;
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void LoadStatusimgList()
        {
            WeatherStatusimglist.Clear();
            string txt = FileIO.Out(Seting.SetingPathWeatherTatusImg);

            txt = txt.Replace("\r\n", ",");
            string strs = string.Empty;
            string[] Weathertatus = txt.Trim().Split(',');
        
            try
            {
                for (int i = 0; i < Weathertatus.Length - 3; i++)
            {
                if (!string.IsNullOrEmpty(Weathertatus[i].Trim()))
                {
                    WeatherStatusimglist.Add(Weathertatus[i], Weathertatus[i + 1] + "," + Weathertatus[i + 2] + ","  + Weathertatus[i + 3]);
                    i++;
                    i++;
                    i++;

                }
            }
        
            }
            catch (Exception ex)
            {

            }
           
        }
        public  string showonlyforweathertxt(string key)
        {
            string value = string.Empty;

            value = Weathertxt[key].ToString();
            return value;

        }

        public string GetOneValueForWeatherData(string key, int day)
        {
            string value = string.Empty;
            
            switch (day)
            {

                case 1:
                     value = ForeCaseDatelist1[key].ToString();
                    break;
                case 2:
                    value = ForeCaseDatelist2[key].ToString(); break;
                case 3:
                    value = ForeCaseDatelist3[key].ToString();
                    break;
                default:
                     value = ForeCaseDatelist1[key].ToString()
                   + ForeCaseDatelist2[key].ToString()
                  + ForeCaseDatelist3[key].ToString();
                    break;
            }
            return value;




        }
        public string OneValueForNowDate(string key)
        {
            return FoCaNows[key];
        }
        public string OneValueForLifeDate(string key,int info)
        {
            return FoCaLifes[key][info];
        }
        public string[] ArriyValueForLifeDate(string key)
        {
            return FoCaLifes[key];
        }

        public string showonly(string key, Dictionary<string, string> list)
        {
            string value = string.Empty;

            value = list[key].ToString();
            return value;

        }


        public  string showall(string s)

        {
            string values = string.Empty;
            string key = string.Empty;
            string all = string.Empty;


            foreach (string str in Weathertxt.Keys)
            {
                key += str;
                values += Weathertxt[str];
                all += str + ":" + Weathertxt[str] + "\r\n";
            }


            if (s == "key")
            {
                return key;
            }
            else if (s == "value")
            {
                return values;

            }
            else
            {

                return all;

            }

        }
        public  string showall(string s, Dictionary<string, string> list)

        {
            string values = string.Empty;
            string key = string.Empty;
            string all = string.Empty;


            foreach (string str in list.Keys)
            {
                key += str;
                values += list[str];
                all += str + ":" + list[str] + "\r\n";
            }


            if (s == "key")
            {
                return key;
            }
            else if (s == "value")
            {
                return values;

            }
            else
            {

                return all;

            }

        }


        public static string showall(string s, Dictionary<string, string> list, bool isdata)

        {
            string value = string.Empty;
            string key = string.Empty;
            string values = string.Empty;
            string keys = string.Empty;
            string all = string.Empty;
            string alls = string.Empty;



            foreach (string str in list.Keys)
            {
                if (isdata == true)
                {
                    key = str;
                    keys += key;
                    value = list[str];
                    values += value;
                    all += key + ":" + list[str] + "\r\n";
                }
                else
                {
                    if
                        (Weathertxt.Keys.Contains(str))
                    {
                        key = Weathertxt[str];
                        keys += Weathertxt[str];
                    }
                    else
                    {
                        key = "erro";
                        keys += "erro";
                    }

                    value = list[str];
                    values += value;
                    all += key + ":" + value + "\r\n";
                }

            }


            if (s == "key")
            {
                return keys;
            }
            else if (s == "value")
            {
                return values;

            }
            else
            {

                return all;

            }

        }


        public static string HttpGet(string location)
        {
           // https://free-api.heweather.com/s6/weather?
            string url = @"https://free-api.heweather.com/s6/weather?key=c5d2fd02807c42c58212a01aacfcdfe6&location=" + location;
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}








