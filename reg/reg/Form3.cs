using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace reg
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            AddPicture();
            Addlabe();
            figure();
            figure2();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        private void Addlabe()
        {

            label1.Text = " Наша программа представляет собой инструмент" + Environment.NewLine + "Для работы с бесплатным компьютерным софтом," + Environment.NewLine + "Обеспечивая всем необходимым для эффективного использования технологий." + Environment.NewLine + "Она разделена на три основных раздела:";
            label1.Font = new Font("Verdana", 11f);
            label1.ForeColor = Color.Black;

            label2.Text = "1. Программы:";
            label2.Font = new Font("Verdana", 14f);
            label2.ForeColor = Color.Black;

            label3.Text = " В этом разделе вы найдете широкий выбор бесплатных" + Environment.NewLine + "программ для различных задач" + Environment.NewLine + "от офисных приложений до графических редакторов." + Environment.NewLine + "Здесь можно легко искать, просматривать и устанавливать нужные инструменты.";
            label3.Font = new Font("Verdana", 11f);
            label3.ForeColor = Color.Black;

            label4.Text = "2. Ресурсы:";
            label4.Font = new Font("Verdana", 14f);
            label4.ForeColor = Color.Black;

            label5.Text = " Этот раздел предлагает разнообразные учебные материалы," + Environment.NewLine + "руководства и статьи, которые помогут вам лучше понять и использовать доступный софт." + Environment.NewLine + "Вы сможете найти полезные советы и рекомендации по оптимизации работы с программами.";
            label5.Font = new Font("Verdana", 11f);
            label5.ForeColor = Color.Black;

            label6.Text = "3. Загрузка файлов:";
            label6.Font = new Font("Verdana", 14f);
            label6.ForeColor = Color.Black;

            label7.Text = " Здесь вы можете безопасно загружать и делиться файлами," + Environment.NewLine + "связанными с программами и ресурсами. Этот раздел также" + Environment.NewLine + "поддерживает возможность загрузки обновлений и патчей," + Environment.NewLine + "чтобы вы всегда имели доступ к последним версиям.";
            label7.Font = new Font("Verdana", 11f);
            label7.ForeColor = Color.Black;

            label8.Text = " Программа создана для удобства пользователей, предлагая " + Environment.NewLine + "организованный доступ ко всем необходимым ресурсам для" + Environment.NewLine + "максимального использования бесплатного софта.";
            label8.Font = new Font("Verdana", 11f);
            label8.ForeColor = Color.Black;

            label9.Text = "Soft Teck";
            label9.Font = new Font("Impact", 22f);
            label9.ForeColor = Color.Red;
        }
        private void AddPicture()
        {
            try
            {
                string puti = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\Avatar.jpg";
                if (!File.Exists(puti))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {puti}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    // Пробуем загрузить изображение напрямую
                    using (var bitmap = new Bitmap(puti))
                    {
                        pictureBox1.Image = new Bitmap(bitmap);
                    }
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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
        }

        private void figure()
        {
            try
            {
                string putifig = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\Figure1.jpg";
                if (!File.Exists(putifig))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {putifig}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (var bitmapfigure = new Bitmap(putifig))
                    {
                        pictureBox2.Image = new Bitmap(bitmapfigure);
                    }
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
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void figure2()
        {
            try
            {
                string piinfigure2 = @"C:\пргаграмерование\reg\reg\bin\Debug\net8.0-windows\Image\Figure22.jpg";
                if (!File.Exists(piinfigure2))
                {
                    MessageBox.Show($"Файл изображения не найден по пути: {piinfigure2}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using (var bitmapfigure2 = new Bitmap(piinfigure2))
                    {
                        pictureBox3.Image = new Bitmap(bitmapfigure2);
                    }
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Close();
        }
    }
}

