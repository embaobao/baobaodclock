using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace clock_baobao
{
    class ForeCase
    {
        //        fl 体感温度，默认单位：摄氏度	23
        //tmp 温度，默认单位：摄氏度	21
        //cond_code 实况天气状况代码	100
        //cond_txt 实况天气状况代码    晴
        //wind_deg    风向360角度	305
        //wind_dir 风向  西北
        //wind_sc 风力	3-4
        //wind_spd 风速，公里/小时	15
        //hum 相对湿度	40
        //pcpn 降水量	0
        //pres 大气压强	1020
        //vis 能见度，默认单位：公里	10
        //cloud 云量

        // brf 生活指数简介
        //txt 生活指数详细描述
        //type 生活指数类型 comf：舒适度指数、cw：洗车指数、
        //drsg：穿衣指数、flu：感冒指数、sport：运动指数、
        // trav：旅游指数、uv：紫外线指数、air：空气污染扩散条件指数

        private string life_comfortablle = string.Empty;
        private string life_washcar = string.Empty;
        private string life_dress = string.Empty;
        private string life_influenza = string.Empty;
        private string life_sport = string.Empty;
        private string life_travel = string.Empty;
        private string life_ultraviolet = string.Empty;
        private string life_air = string.Empty;

        private string tlife_comfortablle = string.Empty;
        private string tlife_washcar = string.Empty;
        private string tlife_dress = string.Empty;
        private string tlife_influenza = string.Empty;
        private string tlife_sport = string.Empty;
        private string tlife_travel = string.Empty;
        private string tlife_ultraviolet = string.Empty;
        private string tlife_air = string.Empty;


        private string now_tmp = string.Empty;
        private string now_WinPower = string.Empty;
        private string now_vis = string.Empty;
        private string now_windir = string.Empty;
        private string now_forecase = string.Empty;
        private string now_f_code = string.Empty;
        private string now_f_imgsrc = string.Empty;
        private Image now_img = null;

        private string Tmp_max = string.Empty;
        private string Tmp_min = string.Empty;
        private string ForeCaseData = string.Empty;
        private string ForeCaseDStatus = string.Empty;
        private string ForeCaseNStatus = string.Empty;
        private string ForeCaseStatusDCode = string.Empty;
        private string ForeCaseStatusNCode = string.Empty;
        private string ForeCaseStatusDImgSrc = string.Empty;
        private string ForeCaseStatusNImgSrc = string.Empty;
        private string Wind_power = string.Empty;
        private string Sun_power = string.Empty;
        private string visiting = string.Empty;
        private string wind_dir = string.Empty;
        private Image dimg = null;
        private Image nimg = null;
        WeatherData wd = null;
        public bool ifdata = false;


        public string Tmp_max1 { get => Tmp_max; set => Tmp_max = value; }
        public string Tmp_min1 { get => Tmp_min; set => Tmp_min = value; }
        public string ForeCaseData1 { get => ForeCaseData; set => ForeCaseData = value; }
        public string ForeCaseDStatus1 { get => ForeCaseDStatus; set => ForeCaseDStatus = value; }
        public string ForeCaseNStatus1 { get => ForeCaseNStatus; set => ForeCaseNStatus = value; }
        public string ForeCaseStatusDCode1 { get => ForeCaseStatusDCode; set => ForeCaseStatusDCode = value; }
        public string ForeCaseStatusNCode1 { get => ForeCaseStatusNCode; set => ForeCaseStatusNCode = value; }
        public string ForeCaseStatusDImgSrc1 { get => ForeCaseStatusDImgSrc; set => ForeCaseStatusDImgSrc = value; }
        public string ForeCaseStatusNImgSrc1 { get => ForeCaseStatusNImgSrc; set => ForeCaseStatusNImgSrc = value; }
        public Image Dimg { get => dimg; set => dimg = value; }
        public Image Nimg { get => nimg; set => nimg = value; }
        internal WeatherData Wd { get => wd; set => wd = value; }
        public string Wind_power1 { get => Wind_power; set => Wind_power = value; }
        public string Sun_power1 { get => Sun_power; set => Sun_power = value; }
        public string Visiting { get => visiting; set => visiting = value; }
        public string Wind_dir { get => wind_dir; set => wind_dir = value; }
        public string Life_comfortablle { get => life_comfortablle; set => life_comfortablle = value; }
        public string Life_washcar { get => life_washcar; set => life_washcar = value; }
        public string Life_dress { get => life_dress; set => life_dress = value; }
        public string Life_influenza { get => life_influenza; set => life_influenza = value; }
        public string Life_sport { get => life_sport; set => life_sport = value; }
        public string Life_travel { get => life_travel; set => life_travel = value; }
        public string Life_ultraviolet { get => life_ultraviolet; set => life_ultraviolet = value; }
        public string Life_air { get => life_air; set => life_air = value; }
        public string Now_tmp { get => now_tmp; set => now_tmp = value; }
        public string Now_WinPower { get => now_WinPower; set => now_WinPower = value; }
        public string Now_vis { get => now_vis; set => now_vis = value; }
        public string Now_windir { get => now_windir; set => now_windir = value; }
        public string Now_forecase { get => now_forecase; set => now_forecase = value; }
        public string Now_f_code { get => now_f_code; set => now_f_code = value; }
        public string Now_f_imgsrc { get => now_f_imgsrc; set => now_f_imgsrc = value; }
        public Image Now_img { get => now_img; set => now_img = value; }
        public string Tlife_comfortablle { get => tlife_comfortablle; set => tlife_comfortablle = value; }
        public string Tlife_washcar { get => tlife_washcar; set => tlife_washcar = value; }
        public string Tlife_dress { get => tlife_dress; set => tlife_dress = value; }
        public string Tlife_influenza { get => tlife_influenza; set => tlife_influenza = value; }
        public string Tlife_sport { get => tlife_sport; set => tlife_sport = value; }
        public string Tlife_travel { get => tlife_travel; set => tlife_travel = value; }
        public string Tlife_ultraviolet { get => tlife_ultraviolet; set => tlife_ultraviolet = value; }
        public string Tlife_air { get => tlife_air; set => tlife_air = value; }

        public ForeCase(string location, int day)
        {
            Wd = new WeatherData(location);
            ifdata = Wd.GetForeCaseDate();
            if (ifdata)
            {
                LodingData(Wd, day);
            }
            else
            {
                ifdata = false;
            }
        }
        private void LodingData(WeatherData wd, int day)
        {
           
            now_tmp = wd.OneValueForNowDate("tmp"); 
            now_WinPower = wd.OneValueForNowDate("wind_sc");
            now_vis = wd.OneValueForNowDate("vis");
            now_windir = wd.OneValueForNowDate("wind_dir");
            now_forecase = wd.OneValueForNowDate("cond_txt");
            now_f_code = wd.OneValueForNowDate("cond_code");
            if (string.IsNullOrEmpty(now_f_code))
            {
                MessageBox.Show("获取当前信息失败！1");
            }
            else
            {
                now_f_imgsrc = GetingImgSrc(now_f_code);
            }
            if (string.IsNullOrEmpty(now_f_imgsrc))
            {
                MessageBox.Show("获取当前信息失败！2");
            }
            else
            {
              //  MessageBox.Show(now_f_imgsrc);
                Image now_img = GetingImg(now_f_imgsrc);
            }
         


            life_dress = wd.OneValueForLifeDate("drsg", 0);
            life_influenza = wd.OneValueForLifeDate("flu", 0);
            life_sport = wd.OneValueForLifeDate("sport", 0);
            life_ultraviolet = wd.OneValueForLifeDate("uv", 0);
            life_air = wd.OneValueForLifeDate("air", 0);



            tlife_dress = wd.OneValueForLifeDate("drsg", 1);
            tlife_influenza = wd.OneValueForLifeDate("flu", 1);
            tlife_sport = wd.OneValueForLifeDate("sport", 1);
            tlife_ultraviolet = wd.OneValueForLifeDate("uv", 1);
            tlife_air = wd.OneValueForLifeDate("air", 1);

            life_comfortablle = wd.OneValueForLifeDate("comf", 0);
            tlife_comfortablle = wd.OneValueForLifeDate("comf", 1);
            life_washcar = wd.OneValueForLifeDate("cw", 0);
            tlife_washcar = wd.OneValueForLifeDate("cw", 1);
            life_travel = wd.OneValueForLifeDate("trav", 0);
            tlife_travel = wd.OneValueForLifeDate("trav", 1);



            ForeCaseData1 = wd.GetOneValueForWeatherData("date", day);
            Tmp_max1 = wd.GetOneValueForWeatherData("tmp_max", day);
            Tmp_min1 = wd.GetOneValueForWeatherData("tmp_min", day);
            ForeCaseStatusDCode1 = wd.GetOneValueForWeatherData("cond_code_d", day);
            ForeCaseStatusNCode1 = wd.GetOneValueForWeatherData("cond_code_n", day);
            ForeCaseDStatus1 = wd.GetOneValueForWeatherData("cond_txt_d", day);
            ForeCaseNStatus1 = wd.GetOneValueForWeatherData("cond_txt_n", day);
            Wind_power = wd.GetOneValueForWeatherData("wind_sc", day);
            Sun_power = wd.GetOneValueForWeatherData("uv_index", day);
            visiting = wd.GetOneValueForWeatherData("vis", day);
            wind_dir = wd.GetOneValueForWeatherData("wind_dir", day);
            ForeCaseStatusDImgSrc1 = GetingImgSrc(ForeCaseStatusDCode1);
            ForeCaseStatusNImgSrc1 = GetingImgSrc(ForeCaseStatusNCode1);
            Dimg = GetingImg(ForeCaseStatusDImgSrc1);
            Nimg = GetingImg(ForeCaseStatusNImgSrc1);
            //
        }
        private Image GetingImg(string src)
        {
            WebClient client = new WebClient();
            byte[] bytes = client.DownloadData(src);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image image = System.Drawing.Image.FromStream(ms);
                return image;
                //this.pictureBox1.Image = image;
            }
        }

        public string GetingImgSrc(string StatusCode)
        {
            string GetTxt = WeatherData.WeatherStatusimglist[StatusCode];
            string[] GetTxts = GetTxt.Split(',');
            GetTxt = "";
            try
            {
                //foreach (string sstr in GetTxts)
                //{
                //    GetTxt += sstr+"\r\n";
                //}
                GetTxt += GetTxts[2];
            }
            catch (Exception)
            {

                throw;
            }


            return GetTxt;
        }


    }
}
