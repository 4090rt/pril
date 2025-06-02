using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace reg
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            AddPicture();
            AddPicture2();
            AddPicture3();
            AddPicture4();
            LoadImagesWithDelay();
        }

        private async Task AddPicture()
        {
            try
            {
                string aida = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\AIDA64.jpg";
                if (!File.Exists(aida))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {aida}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using Bitmap bitmap1 = new Bitmap(aida);
                    {
                        pictureBox1.Image = new Bitmap(aida);
                    }
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                }
                this.Controls.Add(pictureBox1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}\nПопробуйте открыть файл в графическом редакторе и сохранить его заново.",
                    "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label1.Text = " Анализ системы — подробная информация об оборудовании и ПО. " + Environment.NewLine + "Тесты производительности — проверка CPU, GPU, памяти и дисков." + Environment.NewLine + "Мониторинг датчиков — температура, напряжение, скорость вентиляторов." + Environment.NewLine + "Отчеты — сохранение данных о системе в разных форматах.";
            label1.Font = new Font("Verdana", 8f);
            label1.ForeColor = Color.Black;
            label2.Text = " AIDA64";
            label2.Font = new Font("Verdana", 12f);
            label2.ForeColor = Color.Black;
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Green;
        }
        private async Task AddPicture2()
        {
            try
            {
                string CPUZ = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\CPUZ.jpg";
                if (!File.Exists(CPUZ))
                {
                    MessageBox.Show($"Файл изображения не найден по пути:{CPUZ}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    using Bitmap bitmap2 = new Bitmap(CPUZ);
                    {
                        pictureBox2.Image = new Bitmap(CPUZ);
                    }
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                }
                this.Controls.Add(pictureBox2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}\nПопробуйте открыть файл в графическом редакторе и сохранить его заново.",
                    "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label3.Text = " Анализ CPU — название, архитектура, частота, кэш." + Environment.NewLine + "Память и материнская плата — тип ОЗУ, частота, модель платы." + Environment.NewLine + "Графика — данные о видеокарте." + Environment.NewLine + "Бенчмарк — тест производительности процессора.";
            label3.Font = new Font("Verdana", 8f);
            label3.ForeColor = Color.Black;
            label4.Text = "CPUZ";
            label4.Font = new Font("Verdana", 12f);
            label4.ForeColor = Color.Black;
            button2.ForeColor = Color.White;
            button2.BackColor = Color.Green;
        }
        private async Task AddPicture3()
        {
            try
            {
                string FUR = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\FurMark.jpg";
                if (!File.Exists(FUR))
                {
                    MessageBox.Show($"Файл изображения не найден по пути:{FUR}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    using Bitmap bitmap2 = new Bitmap(FUR);
                    {
                        pictureBox3.Image = new Bitmap(FUR);
                    }
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                }
                this.Controls.Add(pictureBox2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}\nПопробуйте открыть файл в графическом редакторе и сохранить его заново.",
                    "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label6.Text = " Нагрузочный тест GPU — проверка стабильности и охлаждения под максимальной нагрузкой." + Environment.NewLine + "Нагрузочный тест GPU — проверка стабильности и охлаждения под максимальной нагрузкой." + Environment.NewLine + "Мониторинг — отображение температуры, частот и других параметров в реальном времени.";
            label6.Font = new Font("Verdana", 8f);
            label6.ForeColor = Color.Black;
            label5.Text = "FurMark";
            label5.Font = new Font("Verdana", 12f);
            label5.ForeColor = Color.Black;
            button3.ForeColor = Color.White;
            button3.BackColor = Color.Green;
        }
        private async Task AddPicture4()
        {
            try
            {
                string disk = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\CrystalDisk.jpg";
                if (!File.Exists(disk))
                {
                    MessageBox.Show($"Файл изображения не найден по пути:{disk}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    using Bitmap bitmap2 = new Bitmap(disk);
                    {
                        pictureBox4.Image = new Bitmap(disk);
                    }
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                }
                this.Controls.Add(pictureBox2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}\nПопробуйте открыть файл в графическом редакторе и сохранить его заново.",
                    "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label8.Text = " CrystalDiskInfo — отображает состояние диска (температура, S.M.A.R.T.-атрибуты и другие)." + Environment.NewLine + "CrystalDiskMark — измеряет скорость чтения и записи." + Environment.NewLine + "Используется для проверки работоспособности и производительности дисков.";
            label8.Font = new Font("Verdana", 8f);
            label8.ForeColor = Color.Black;
            label7.Text = "Crystall Desk";
            label7.Font = new Font("Verdana", 12f);
            label7.ForeColor = Color.Black;
            button4.ForeColor = Color.White;
            button4.BackColor = Color.Green;
        }

        private async Task Delay(int milliseconds)
        {
            await Task.Delay(milliseconds);
        }
        private async void LoadImagesWithDelay()
        {
            try
            {
                // Загрузка первого изображения
                await Delay(1000); // Задержка 1 секунда
                await AddPicture();

                // Загрузка второго изображения
                await Delay(1000); // Задержка 1 секунда
                await AddPicture2();

                await Delay(1000);
                await AddPicture3();

                await Delay(1000);
                await AddPicture4();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

