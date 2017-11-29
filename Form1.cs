using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;


namespace clock_baobao
{
  
       
    public partial class mainform : Form
    {
        bool isLock = true;
        bool swich = false;
        Point sspoint ;
        int refarshcount = 0;
        //int op =70;
        //Color c = Color.CornflowerBlue;

        public mainform()
        {
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer2.Enabled = true;
            timer2.Interval = 60000;
            sspoint = new Point(this.Location.X, this.Location.Y);
            loadForecaseDataday1();
            LoadDateDay2();
            LoadDateDay3();

        }

        private void LoadDateDay2()
        {
            ForeCase day2 = new ForeCase("洛阳", 2);
            day2time_lb.Text = day2.ForeCaseData1;
            day2fotxt_lb.Text = "白:" + day2.ForeCaseDStatus1 + "—夜间:" + day2.ForeCaseNStatus1;
            day2tmpmax_lb.Text = day2.Tmp_max1;
            day2tmpmin_lb.Text = day2.Tmp_min1;
            day2win_lb.Text = day2.Wind_dir + "," + day2.Wind_power1;
            day2week_lb.Text = GetWeek(1);
            day2_pic.Image = day2.Dimg;
        }
        private void LoadDateDay3()
        {
            ForeCase day3 = new ForeCase("洛阳", 3);
            day3time_lb.Text = day3.ForeCaseData1;
            day3fotxt_lb.Text = "白:" + day3.ForeCaseDStatus1 + "—夜间:" + day3.ForeCaseNStatus1;
            day3tmpmax_lb.Text = day3.Tmp_max1;
            day3tmpmin_lb.Text = day3.Tmp_min1;
            day3win_lb.Text = day3.Wind_dir + "," + day3.Wind_power1;
            day3week_lb.Text = GetWeek(2);
            day3_pic.Image = day3.Dimg;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 停止计时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false;
        }

        private void 开始计时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(button3, "点击移动窗体！");
            hms_lb.Text = getnowtimes("时分秒");
            ymd_lb.Text = System.DateTime.Now.ToLongDateString();
            week_lb.Text= System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(WeatherData.HttpGet("洛阳"));
            //string t = "";
            //int cout = 0;
            // heweather.urlencoding(WeatherData.HttpGet("洛阳"));
            //foreach (string s in heweather.lifes)
            //{
            //    t+= cout+ heweather.GetLifeType(s)+"\r\n";
            //    cout++;
            //}
            
          //  textBox1.Text = t;// heweather.showdata(heweather.lifes);
          //  MessageBox.Show(t);
           // MessageBox.Show(heweather.showdata(heweather.lifes));
             //loadForecaseData();

       


        }

        private void loadForecaseDataday1()
        {
           
            ForeCase day1 = new ForeCase("洛阳", 1);
            //MessageBox.Show(  day1.GetingImgSrc("101"));
            if (day1.ifdata)
            {
               
                day1time_lb.Text = day1.ForeCaseData1;
                day1week_lb.Text = getnowtimes("星期");
                day1_tmpmax_lb.Text = day1.Tmp_max1;
                day1_tmpmin_lb.Text = day1.Tmp_min1;
                if (day1.Now_img==null)
                {
                  now_pic.Image = day1.Dimg;
                  //MessageBox.Show("以获取今天白天天气信息");
                }
                else
                {
               
                    now_pic.Image = day1.Now_img;
                }

                now_fotxt_lb.Text =day1.Now_forecase;
                nowtmp_lb.Text = day1.Now_tmp;
                now_win_lb.Text = "风向:"+day1.Now_windir + "\r\n"+"风力:" + takestrbiglength(day1.Now_WinPower);
                life_air_lb.Text ="今天的空气质量:"+ day1.Life_air + "\r\n"+"宝宝提醒您：" + takestrbiglength(day1.Tlife_air);
                life_cloth_lb.Text="今天天气:"+day1.Life_dress+ "\r\n" + "宝宝提醒您：" +takestrbiglength(day1.Tlife_dress); 
                life_comf_lb.Text = "今天的天气:" + day1.Life_comfortablle + "\r\n"+ "宝宝提醒您：" + takestrbiglength(day1.Tlife_comfortablle); 
                life_flu_lb.Text = "今天的天气:" + day1.Life_influenza + "\r\n"+ "宝宝提醒您：" + takestrbiglength(day1.Tlife_influenza); 
                life_travel_lb.Text = "今天的天气"+day1.Life_travel +"旅行"+ "\r\n" + takestrbiglength(day1.Tlife_travel); 
                life_uv_lb.Text = "今天的紫外线:" + day1.Life_ultraviolet + "\r\n" + "宝宝提醒您：" + takestrbiglength(day1.Tlife_ultraviolet); 
                life_washcar_lb.Text = "今天"+day1.Life_washcar + "洗车"+"\r\n" + "宝宝提醒您：" + takestrbiglength(day1.Tlife_washcar);
                notifyIcon1.BalloonTipTitle = "天气提醒";
                notifyIcon1.BalloonTipText = "天气:" + day1.Life_comfortablle + "\r\n" + "宝宝提醒您：" + day1.Tlife_comfortablle+"\r\n"+life_cloth_lb.Text;
                notifyIcon1.ShowBalloonTip(2000);
               
                toolTip1.SetToolTip(button1,life_cloth_lb.Text);
               
            }
            else
            {
                MessageBox.Show("数据获取失败！");
            }

        }
        
        public static string  takestrbiglength(string  str)
        {
            if (str.Length>12)
            {
               str =str.Insert(12,"\r\n");
            }
            
                return str;
        }

        private void panel_day1_Paint(object sender, PaintEventArgs e)
        {

        }


        public static string getnowtimes(string str)
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            int yers = time.Year;
            int month = time.Month;
            int day = time.Day;
            int hour = time.Hour;
            int minute = time.Minute;
            int second = time.Second;
            int millisecond = time.Millisecond;
            string months, days, hours, minutes, seconds;
            months = addzero(month);
            days = addzero(day);
            hours = addzero(hour);
            minutes = addzero(minute);
            seconds = addzero(second);
            string y_m_d = yers + "年" + months + "月" + days + "日";
            string h_m_s = hours + ":" + minutes + ":" + seconds;
            string minsecond = millisecond.ToString();
            string addminsecond = ":" + millisecond.ToString();
            string alltimeaddminsecond = y_m_d + h_m_s + addminsecond;
            string alltime = y_m_d + h_m_s;
            string nowtimes = string.Empty;
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();

            if (str == "有毫秒")
            {
                nowtimes = alltimeaddminsecond;
            }
            else if (str == "年月日")
            {
                nowtimes = y_m_d;
            }
            else if (str == "时分秒")
            {
                nowtimes = h_m_s;
            }
            else if (str == "时分秒加毫秒")
            {
                nowtimes = h_m_s + addminsecond;
            }
            else if (str == "年")
            {
                nowtimes = yers.ToString();

            }
            else if (str == "月")
            {
                nowtimes = months;

            }
            else if (str == "日")
            {

                nowtimes = days;

            }
            else if (str == "时")
            {
                nowtimes = hours.ToString();

            }
            else if (str == "分")
            {
                nowtimes = minutes;

            }
            else if (str == "秒")
            {
                nowtimes = seconds;
            }
            else if (str == "毫秒")
            {
                nowtimes = millisecond.ToString();

            }
            else if (str == "加毫秒")
            {
                nowtimes = addminsecond.ToString();

            }
            else if (str == "星期")
            {
                nowtimes = week;

            }

            else
            {
                nowtimes = alltime;
            }

            return nowtimes;
        }
        private static string addzero(int add)
        {
            string addstr = "";
            if (add < 9)
            {
                addstr = "0" + add.ToString();
            }
            else
            {
                addstr = add.ToString();
            }
            return addstr;
        }

        public static string GetWeek(int i)
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d")) + i].ToString();
            return week;
        }
        public static string GetWeek()
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            return week;
        }

        private void day1_tmpmax_lb_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void hms_lb_Click(object sender, EventArgs e)
        {

        }

        private void week_lb_Click(object sender, EventArgs e)
        {

        }

        private void vis_bt_Click(object sender, EventArgs e)
        {
            if (time_tb.Visible == true)
            {
                time_tb.Visible = false;
                this.Size=new Size(469,335);
                this.vis_bt.Text = "︾";
            }
            else
            {
                time_tb.Visible = true;
                this.Size = new Size(469, 508);
                 this.vis_bt.Text = "︽";
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            //if ((int)formop_nd.Value > 90)
            //{
            //    MessageBox.Show("窗体全部透明可就不见了呦！所以请小于80吧！");
            //}
            //else if ((int)formop_nd.Value < 0)
            //{
            //    MessageBox.Show("至少得大于0吧！");
            //}

            //else
            //{
            //    op = 100 - (int)formop_nd.Value;
            //}
            //this.Refresh();



        }

        private void forca_bt_Click(object sender, EventArgs e)
        {

        }

        private void forca_bt_Click_1(object sender, EventArgs e)
        {
            if (forca_pl.Visible == true)
            {
                forca_pl.Visible = false;
                time_pl.Location = new Point(2,3);
                this.Size = new Size(469,time_pl.Height+5);
                forca_bt.Text = "︽";
            }
            else
            {
                forca_pl.Visible = true;
                time_pl.Location = new Point(2,338);
                this.Size = new Size(469, 508);
                forca_bt.Text = "︾";
            }

        }

        private void mainform_Paint(object sender, PaintEventArgs e)
        {
            //this.Opacity = op;
            //this.BackColor = c;
            //this.Refresh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //colorDialog1.ShowDialog();
            //if (colorDialog1.Color != null)
            //{
            //    c = colorDialog1.Color;
            //}
            //this.BackColor = c;
            //this.Refresh();
        }

        private void mainform_MouseMove(object sender, MouseEventArgs e)
        {
            if (isLock == false)
            {
                if (swich == true)
                {
                    Point spoint = new Point(this.Location.X, this.Location.Y);
                    this.Location = new Point(spoint.X + e.X, spoint.Y + e.Y);
                }
            }

        }

        private void mainform_MouseDown(object sender, MouseEventArgs e)
        {
           
                swich = true;
            
        }

        private void mainform_MouseUp(object sender, MouseEventArgs e)
        {
            swich = false;
        }

        private void 解除锁定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           isLock =false;
        }

        private void 锁定窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           isLock = true;
        }

        private void 复位窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Location = sspoint;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            swich = true;

        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            swich = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            if (swich == true)
            {
                Point spoint = new Point(this.Location.X, this.Location.Y);
                this.Location = new Point(spoint.X + e.X, spoint.Y + e.Y);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            refarshcount++;
            if (refarshcount >30)
            {
                loadForecaseDataday1();
                LoadDateDay2();
                LoadDateDay3();
                refarshcount = 0;
                MessageBox.Show(life_comf_lb.Text+"/r/n"+life_cloth_lb.Text+"\r\n");
                notifyIcon1.BalloonTipTitle = "天气提醒";
                notifyIcon1.BalloonTipText =nowtmp_lb+"\r\n"+ now_win_lb;
            }
        }
    }
}
