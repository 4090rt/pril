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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            AddPicture();
        }
        private async Task AddPicture()
        {
            try
            {
                string cpuz = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\CPUZ.jpg";
                if (!File.Exists(cpuz))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {cpuz}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using Bitmap bitmap1 = new Bitmap(cpuz);
                    {
                        pictureBox1.Image = new Bitmap(cpuz);
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
                string cpuzv1 = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\cpuzv1.jpg";
                if (!File.Exists(cpuzv1))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {cpuzv1}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using Bitmap bitmap = new Bitmap(cpuzv1);
                    {
                        pictureBox2.Image = new Bitmap(cpuzv1);
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
                string cpuzv2 = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\cpuzv2.jpg";
                if (!File.Exists(cpuzv2))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {cpuzv2}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using Bitmap bitmap = new Bitmap(cpuzv2);
                    {
                        pictureBox3.Image = new Bitmap(cpuzv2);
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
                string cpuzv3 = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\cpuzv3.jpg";
                if (!File.Exists(cpuzv3))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {cpuzv3}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using Bitmap bitmap = new Bitmap(cpuzv3);
                    {
                        pictureBox4.Image = new Bitmap(cpuzv3);
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
            string puti = Path.Combine(Application.StartupPath);
            if (File.Exists(puti))
            {
                try
                {
                    Process.Start(puti);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка запуска {puti}");
                }
            }
            else
            {
                MessageBox.Show($"Файл не найден по пути: {puti}");
            }
        }
    }
}

