using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reg
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            AddPicture();
            this.KeyPreview = true; // Важно! Форма должна перехватывать нажатия клавиш
            this.KeyDown += Form1_KeyDown; // Подписываемся на событие нажатия клавиш
            this.KeyDown += Form1_KeyDown1;
            this.KeyDown += Form1_KeyDown2;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && isFullscreen)
            {
                ToggleFullscreen(); // Выходим из полноэкранного режима
            }
        }
        private void Form1_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && isFullScreen1)
            {
                ToggleFullscreen1();
            }
        }
        private void Form1_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && isFullScrean2)
            {
                ToggleFullscreen2();
            }
        }
        private void ToggleFullscreen1()
        {
            if (!isFullScreen1)
            {
                originalLocation = pictureBox5.Location;
                originalSize = pictureBox5.Size;

                pictureBox5.Dock = DockStyle.Fill;
                pictureBox5.BringToFront();
                isFullScreen1 = true;
            }
            else
            {
                pictureBox5.Dock = DockStyle.None;
                pictureBox5.Location = originalLocation;
                pictureBox5.Size = originalSize;
                isFullScreen1 = false;
            }
        }
        private void ToggleFullscreen()
        {
            if (!isFullscreen)
            {
                originalLocation = pictureBox4.Location;
                originalSize = pictureBox4.Size;

                pictureBox4.Dock = DockStyle.Fill;
                pictureBox4.BringToFront();
                isFullscreen = true;
            }
            else
            {
                pictureBox4.Dock = DockStyle.None;
                pictureBox4.Location = originalLocation;
                pictureBox4.Size = originalSize;
                isFullscreen = false;
            }
        }
        private void ToggleFullscreen2()
        {
            if (!isFullScrean2)
            {
                originalLocation = pictureBox6.Location;
                originalSize = pictureBox6.Size;

                pictureBox6.Dock = DockStyle.Fill;
                pictureBox6.BringToFront();
                isFullScrean2 = true;
            }
            else
            {
                pictureBox6.Dock = DockStyle.None;
                pictureBox6.Location = originalLocation;
                pictureBox6.Size = originalSize;
                isFullScrean2 = false;
            }
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
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
            label1.Font = new Font("Verdana", 10f);
            label1.ForeColor = Color.Black;
            label2.Text = " AIDA64";
            label2.Font = new Font("Verdana", 12f);
            label2.ForeColor = Color.Black;
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Green;

            try
            {
                string aidav1 = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\aidav1.jpg";
                if (!File.Exists(aidav1))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {aidav1}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using Bitmap bitmap = new Bitmap(aidav1);
                    {
                        pictureBox5.Image = new Bitmap(aidav1);
                    }
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
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


            try
            {
                string aidav2 = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\aidav2.jpg";
                if (!File.Exists(aidav2))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {aidav2}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using Bitmap bitmap = new Bitmap(aidav2);
                    {
                        pictureBox6.Image = new Bitmap(aidav2);
                    }
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                }
                this.Controls.Add(pictureBox3);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}\nПопробуйте открыть файл в графическом редакторе и сохранить его заново.",
                    "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                string aidav3 = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\aidav1.jpg";
                if (!File.Exists(aidav3))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {aidav3}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using Bitmap bitmap = new Bitmap(aidav3);
                    {
                        pictureBox4.Image = new Bitmap(aidav3);
                    }
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                }
                this.Controls.Add(pictureBox4);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}\nПопробуйте открыть файл в графическом редакторе и сохранить его заново.",
                    "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pyti = Path.Combine(Application.StartupPath, "Installers", "aida64extreme765.exe");
            if (File.Exists(pyti))
                try
                {
                    Process.Start(pyti);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка запуска: {ex.Message}");
                }
            else
            {
                MessageBox.Show($"Файл установщика по пути: {pyti} не найден");
            }
        }
        private bool isFullscreen = false; // Флаг полноэкранного режима
        private bool isFullScreen1 = false;
        private bool isFullScrean2 = false;
        private Point originalLocation;
        private Size originalSize;





        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ToggleFullscreen();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ToggleFullscreen1();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ToggleFullscreen2();
        }
    }
}            



