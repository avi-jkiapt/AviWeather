using System;
using System.Drawing;
using System.Windows.Forms;
using System.Json;
using System.Net;

namespace AviWeather
{
    public partial class Form1 : Form
    {
        String City;
        String TemperatureF;
        String Temperature;
        String Humidity;
        String Pressure;
        String WindSpeed;
        String Country;
        String Icon;
        String Description;
        String Latitude;
        String Longitude;
        String OneIcon;
        String TwoIcon;
        String ThreeIcon;
        String FourIcon;
        String FiveIcon;
        String FirstDay;
        String SecondDay;
        String ThirdDay;
        String FourDay;
        String FiveDay;
        String FirstDescription;
        String SecondDescription;
        String ThirdDescription;
        String FourDescription;
        String FiveDescription;
        String TempCOne;
        String TempFOne;
        String TempCTwo;
        String TempFTwo;
        String TempCThree;
        String TempFThree;
        String TempCFour;
        String TempFFour;
        String TempCFive;
        String TempFFive;

        public Form1()
        {
            InitializeComponent();
            labelCity.BackColor = Color.Transparent;
            labelDescription.BackColor = Color.Transparent;
            labelHumidity.BackColor = Color.Transparent;
            labelHumidityRes.BackColor = Color.Transparent;
            labelLatitude.BackColor = Color.Transparent;
            labelLatitudeRes.BackColor = Color.Transparent;
            labelLongitude.BackColor = Color.Transparent;
            labelLongitudeRes.BackColor = Color.Transparent;
            labelPressure.BackColor = Color.Transparent;
            labelPressureRes.BackColor = Color.Transparent;
            labelTemperature.BackColor = Color.Transparent;
            labelTemperatureF.BackColor = Color.Transparent;
            labelWindSpeed.BackColor = Color.Transparent;
            labelWindSpeedRes.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            labelLocation.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBoxFive.BackColor = Color.Transparent;
            pictureBoxFour.BackColor = Color.Transparent;
            pictureBoxT.BackColor = Color.Transparent;
            pictureBoxS.BackColor = Color.Transparent;
            pictureBoxF.BackColor = Color.Transparent;
            labelDayOne.BackColor = Color.Transparent;
            labelDayFour.BackColor = Color.Transparent;
            labelDayFive.BackColor = Color.Transparent;
            labelDayThree.BackColor = Color.Transparent;
            labelDayTwo.BackColor = Color.Transparent;
            labelDescFive.BackColor = Color.Transparent;
            labelDescFour.BackColor = Color.Transparent;
            labelDescOne.BackColor = Color.Transparent;
            labelDescTwo.BackColor = Color.Transparent;
            labelDescThree.BackColor = Color.Transparent;
            labelTemcFive.BackColor = Color.Transparent;
            labelTemcFour.BackColor = Color.Transparent;
            labelTemcThree.BackColor = Color.Transparent;
            labeltemcTwo.BackColor = Color.Transparent;
            labelTemcOne.BackColor = Color.Transparent;
            labelTemfFive.BackColor = Color.Transparent;
            labelTemfFour.BackColor = Color.Transparent;
            labelTemfThree.BackColor = Color.Transparent;
            labelTemfTwo.BackColor = Color.Transparent;
            labelTemfOne.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
        }
        void setIcon(PictureBox pb,String icon)
        {
            try
            {
                pb.Load("http://openweathermap.org/img/w/" + Icon + ".png");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Sorry Cannot Load Image");
            }
        }
        private Double celsiusTemp(String temp)
        {
            Double fahTemp = Convert.ToDouble(temp);
            Double celTem = (fahTemp - 32) * 0.556;
            celTem = Math.Round(celTem, 2);
            return celTem;
        }
        private void getForecastWeather(String location)
        {
            try
            {
                WebClient client = new WebClient();

                dynamic res = JsonValue.Parse(client.DownloadString("http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&units=imperial&appid=d99414c365ff0845c676431520203ea0"));
                dynamic list = res["list"];
                dynamic firstDay = list[9];
                dynamic secondDay = list[16];
                dynamic thirdDay = list[24];
                dynamic fourthDay = list[32];
                dynamic fifthDay = list[38];
                dynamic fifthDesc = fifthDay["weather"][0];
                FiveDescription = fifthDesc["description"];
                FiveIcon = fifthDesc["icon"];
                dynamic temp5 = fifthDay["main"];
                double TemFive = temp5["temp"];
                TempFFive = Convert.ToString(TemFive);
                TempCFive =  Convert.ToString(celsiusTemp(TempFFive));
                dynamic fourthDesc = fourthDay["weather"][0];
                dynamic temp4 = fourthDay["main"];
                double TemFour = temp4["temp"];
                TempFFour = Convert.ToString(TemFour);
                TempCFour = Convert.ToString(celsiusTemp(TempFFour));
                dynamic temp3 = thirdDay["main"];
                double TemThree = temp3["temp"];
                TempFThree = Convert.ToString(TemThree);
                TempCThree = Convert.ToString(celsiusTemp(TempFThree));
                dynamic temp2 = secondDay["main"];
                double TemTwo = temp2["temp"];
                TempFTwo = Convert.ToString(TemTwo);
                TempCTwo = Convert.ToString(celsiusTemp(TempFTwo));
                dynamic temp1 = firstDay["main"];
                double TemOne = temp1["temp"];
                TempFOne = Convert.ToString(TemOne);
                TempCOne = Convert.ToString(celsiusTemp(TempFOne));
                FourDescription = fourthDesc["description"];
                FourIcon = fourthDesc["icon"];
                dynamic thirdDesc = thirdDay["weather"][0];
                ThirdDescription = thirdDesc["description"];
                ThreeIcon = thirdDesc["icon"];
                dynamic secondDesc = secondDay["weather"][0];
                SecondDescription = secondDesc["description"];
                TwoIcon = secondDesc["icon"];
                dynamic firstDesc = firstDay["weather"][0];
                FirstDescription = firstDesc["description"];
                OneIcon = firstDesc["icon"];
                String dateTime = firstDay["dt_txt"];
                DateTime daysCon = Convert.ToDateTime(dateTime);
                FirstDay = daysCon.DayOfWeek.ToString();
                String dt2 = secondDay["dt_txt"];
                DateTime daysTwo = Convert.ToDateTime(dt2);
                SecondDay = daysTwo.DayOfWeek.ToString();
                String dt3 = thirdDay["dt_txt"];
                DateTime daysThree = Convert.ToDateTime(dt3);
                ThirdDay = daysThree.DayOfWeek.ToString();
                String dt4 = fourthDay["dt_txt"];
                DateTime daysFour = Convert.ToDateTime(dt4);
                FourDay = daysFour.DayOfWeek.ToString();
                String dt5 = fifthDay["dt_txt"];
                DateTime daysfif = Convert.ToDateTime(dt5);
                FiveDay = daysfif.DayOfWeek.ToString();
            }
            catch (Exception excep)
            {
                MessageBox.Show("There is some error");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String location = textBoxLocation.Text;
            WebClient webClient = new WebClient();
            try
            {
                String ans = webClient.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + location + "&units=imperial&appid=d99414c365ff0845c676431520203ea0");
                dynamic result = JsonValue.Parse(ans);
                dynamic ans1 = result["main"];
                double hum = ans1["humidity"];
                double temp = ans1["temp"];
                double cel = (temp - 32) * 0.556;
                cel = Math.Round(cel, 2);
                Temperature = Convert.ToString(cel);
                TemperatureF = Convert.ToString(temp);
                double press = ans1["pressure"];
                Pressure = Convert.ToString(press);
                Humidity = Convert.ToString(hum);
                dynamic ans2 = result["sys"];
                Country = ans2["country"];
                dynamic ans3 = result["wind"];
                double speed = ans3["speed"];
                WindSpeed = Convert.ToString(speed);
                dynamic ans4 = result["coord"];
                double lon = ans4["lon"];
                Longitude = Convert.ToString(lon);
                double lat = ans4["lat"];
                Latitude = Convert.ToString(lat);
                City = result["name"];
                dynamic ans5 = result["weather"];
                dynamic ans6 = ans5[0];
                Description = ans6["description"];

                Icon = ans6["icon"];

                Console.Write("");

            }
            catch (System.Net.WebException ep)
            {
                MessageBox.Show("Please Check Your Internet Connection");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Sorry");
                //if(typeof(ex) ==System.Net.WebException)
                MessageBox.Show("Sorry, There is some error.");
            }

            labelCity.Text = City;
            labelHumidityRes.Text = Humidity +"%";
            labelLatitudeRes.Text = Latitude;
            labelLongitudeRes.Text = Longitude;
            labelPressureRes.Text = Pressure +"hPa";
            labelTemperature.Text = Temperature + "°C";
            labelWindSpeedRes.Text = WindSpeed +"m/s";
            labelTemperatureF.Text = TemperatureF + "°F";
            label6.Text = Description;
            setIcon(pictureBox1,Icon);
            getForecastWeather(location);
            labelDayFive.Text = FiveDay;
            labelDayFour.Text = FourDay;
            labelDayThree.Text = ThirdDay;
            labelDayTwo.Text = SecondDay;
            labelDayOne.Text = FirstDay;
            labelDescFive.Text = FiveDescription;
            labelDescFour.Text = FourDescription;
            labelDescOne.Text = FirstDescription;
            labelDescThree.Text = ThirdDescription;
            labelDescTwo.Text = SecondDescription;
            labelTemfFive.Text = TempFFive + "°F";
            labelTemfFour.Text = TempFFour + "°F";
            labelTemfThree.Text = TempFThree + "°F";
            labelTemfTwo.Text = TempFTwo + "°F";
            labelTemfOne.Text = TempFOne + "°F";
            labelTemcFive.Text = TempCFive + "°C";
            labelTemcFour.Text = TempCFour + "°C";
            labelTemcThree.Text = TempCThree + "°C";
            labeltemcTwo.Text = TempCTwo + "°C";
            labelTemcOne.Text = TempCOne + "°C";
            setIcon(pictureBoxFive, FiveIcon);
            setIcon(pictureBoxFour, FourIcon);
            setIcon(pictureBoxT, ThreeIcon);
            setIcon(pictureBoxS, TwoIcon);
            setIcon(pictureBoxF, OneIcon);
 
    }
}
}
