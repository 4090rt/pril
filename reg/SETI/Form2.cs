using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace SETI
{
    public partial class Form2 : Form
    {
         public Form2()
        {
            InitializeComponent();
        }
        private async Task rMain()
        {
            string timezone = textBox1.Text;
            string URL2 = $"https://api.open-meteo.com/v1/forecast?latitude=55.75&longitude=37.61&timezone={timezone}";
            if (string.IsNullOrEmpty(timezone))
            {
                return;
            }
            try
            {
                using (HttpClient client = new HttpClient())
                {              
                    HttpResponseMessage recp = await client.GetAsync(URL2);
                    MessageBox.Show($"StatusCode: {recp.StatusCode}", "Статус ответа");
                    recp.EnsureSuccessStatusCode();
                    string rep = await recp.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(rep) || rep.StartsWith("["))
                    {
                        MessageBox.Show("Город не найден или API вернул пустой ответ.", "Ошибка");
                        return;
                    }
                    using (JsonDocument doc = JsonDocument.Parse(rep))
                    {
                        var root = doc.RootElement;

                        if (root.TryGetProperty("timezone", out JsonElement timezoneElem) &&
                            root.TryGetProperty("current_time", out JsonElement currentTimeElem))
                        {
                            string timezone1 = timezoneElem.GetString();
                            string currentTime = currentTimeElem.GetString();
                            MessageBox.Show($"Часовой пояс: {timezone1}\nТекущее время: {currentTime}", "Время");
                        }
                        else
                        {
                            MessageBox.Show("В ответе нет нужных данных!", "Ошибка");
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Ошибка: Город не найден или проблема с подключением.Детали: {ex.Message}", "Ошибка запроса");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка");
                return;
            }
        }
            private async Task rMain2()
            {
            string City = textBox1.Text;
            string APIKey = "6f7b4977c06cf7032b4f49790617fc3d";
            string URL = $"https://api.openweathermap.org/data/2.5/weather?q={City}&appid={APIKey}&units=metric&lang=ru";
            try
            {
                using (HttpClient CLIEN = new HttpClient())
                {
                    HttpResponseMessage recpon = await CLIEN.GetAsync(URL);
                    recpon.EnsureSuccessStatusCode();
                    string resp = await recpon.Content.ReadAsStringAsync();

                    using (JsonDocument json = JsonDocument.Parse(resp))
                    {
                        JsonElement root = json.RootElement;
                        JsonElement weather = root.GetProperty("weather")[0];
                        JsonElement main = root.GetProperty("main");
                        JsonElement wind = root.GetProperty("wind");

                        string weatherInfo =
                            $"Погода в городе {City}:" +
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
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка");
                return;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
              await rMain();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await rMain2();
        }
    }
}