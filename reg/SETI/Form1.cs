using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
namespace SETI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async Task rMain()
        {
            string city = textBox1.Text;

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Пожалуйста, введите название города.", "Ошибка ввода");
                return;
            }

            string APIkey = "6f7b4977c06cf7032b4f49790617fc3d";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={APIkey}&units=metric&lang=ru";
            
            try 
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage restop = await client.GetAsync(url);
                    restop.EnsureSuccessStatusCode();

                    string responce = await restop.Content.ReadAsStringAsync();
                    
                    using (JsonDocument jeson = JsonDocument.Parse(responce))
                    {
                        JsonElement root = jeson.RootElement;
                        JsonElement main = root.GetProperty("main");
                        JsonElement weather = root.GetProperty("weather")[0];
                        JsonElement wind = root.GetProperty("wind");

                        string weatherInfo = $"Погода в городе {city}:\n\n" +
                                             $"- Температура: {main.GetProperty("temp").GetDouble()}°C\n" +
                                             $"- Влажность: {main.GetProperty("humidity").GetInt32()}%\n" +
                                             $"- Скорость ветра: {wind.GetProperty("speed").GetDouble()} м/с\n" +
                                             $"- Описание: {weather.GetProperty("description").GetString()}";

                        MessageBox.Show(weatherInfo, "Прогноз погоды");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Ошибка: Город не найден или проблема с подключением.\n\nДетали: {ex.Message}", "Ошибка запроса");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка");
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await rMain();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
