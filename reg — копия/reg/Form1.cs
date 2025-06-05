using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Drawing;
using MetroFramework.Components;
using MetroFramework.Forms;
namespace reg
{
    public partial class Form1 : MetroForm
    {
        // Константы для стилей
        private static class AppStyles
        {
            public static readonly Color PrimaryColor = Color.FromArgb(0, 120, 215);
            public static readonly Color SecondaryColor = Color.FromArgb(240, 240, 240);
            public static readonly Color TextColor = Color.FromArgb(64, 64, 64);
            public static readonly Font TitleFont = new Font("Segoe UI", 14, FontStyle.Bold);
            public static readonly Font RegularFont = new Font("Segoe UI", 10);
            public static readonly Padding StandardPadding = new Padding(10);
        }

        public Form1()
        {
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            // Настройка формы
            this.BackColor = AppStyles.SecondaryColor;
            this.Font = AppStyles.RegularFont;
            this.Padding = new Padding(20);
            this.MinimumSize = new Size(400, 500);

            // Создаем группу для элементов регистрации
            GroupBox registrationGroup = new GroupBox
            {
                Text = "Данные для регистрации",
                Font = AppStyles.RegularFont,
                ForeColor = AppStyles.TextColor,
                Location = new Point(20, 60),
                Size = new Size(this.ClientSize.Width - 40, 300),
                Padding = new Padding(10)
            };

            // Добавляем элементы в группу
            int yOffset = 30;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    // Добавляем подсказки для полей
                    if (textBox.Name == "textBox1")
                    {
                        textBox.PlaceholderText = "Введите логин";
                        AddLabelAbove(textBox, "Логин:", registrationGroup, ref yOffset);
                    }
                    else if (textBox.Name == "textBox2")
                    {
                        textBox.PlaceholderText = "Введите пароль";
                        textBox.PasswordChar = '●';
                        AddLabelAbove(textBox, "Пароль:", registrationGroup, ref yOffset);
                    }
                    else if (textBox.Name == "textBox3")
                    {
                        textBox.PlaceholderText = "example@email.com";
                        AddLabelAbove(textBox, "Email:", registrationGroup, ref yOffset);
                    }

                    textBox.Location = new Point(20, yOffset);
                    yOffset += textBox.Height + 20;
                    registrationGroup.Controls.Add(textBox);
                }
                else if (control is Button button)
                {
                    button.Location = new Point((registrationGroup.Width - button.Width) / 2, yOffset);
                    registrationGroup.Controls.Add(button);
                }
            }

            this.Controls.Add(registrationGroup);

            // Стилизация текстовых полей
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Font = AppStyles.RegularFont;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = AppStyles.TextColor;
                    textBox.Padding = new Padding(5);
                    textBox.Margin = AppStyles.StandardPadding;
                    textBox.Width = registrationGroup.Width - 60;

                    // Добавляем эффект при фокусе
                    textBox.Enter += (s, e) => textBox.BackColor = Color.FromArgb(240, 240, 240);
                    textBox.Leave += (s, e) => textBox.BackColor = Color.White;
                }
                else if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = AppStyles.PrimaryColor;
                    button.ForeColor = Color.White;
                    button.Font = AppStyles.RegularFont;
                    button.Cursor = Cursors.Hand;
                    button.Padding = new Padding(10);
                    button.Margin = AppStyles.StandardPadding;
                    button.Size = new Size(200, 40);

                    // Добавляем эффект при наведении
                    button.MouseEnter += (s, e) => button.BackColor = Color.FromArgb(0, 100, 195);
                    button.MouseLeave += (s, e) => button.BackColor = AppStyles.PrimaryColor;
                }
            }

            // Добавляем заголовок
            Label titleLabel = new Label
            {
                Text = "Регистрация",
                Font = AppStyles.TitleFont,
                ForeColor = AppStyles.PrimaryColor,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(titleLabel);
        }

        private void AddLabelAbove(Control control, string text, Control parent, ref int yOffset)
        {
            Label label = new Label
            {
                Text = text,
                Font = AppStyles.RegularFont,
                ForeColor = AppStyles.TextColor,
                AutoSize = true,
                Location = new Point(20, yOffset)
            };
            parent.Controls.Add(label);
            yOffset += label.Height + 5;
        }

        public static readonly string file = "User.txt";
        public static int countuser = 0;
        public static string[,] user = new string[50, 3];
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static string HashLogin(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytesses = sha256.ComputeHash(Encoding.UTF8.GetBytes(name));
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < bytesses.Length; i++)
                    {
                        sb.Append(bytesses[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            else
            {
                MessageBox.Show("Ошибка при хешировании логина:", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            userss(sender, e);
        }
        private void saveUsers(string password, string login, string email)
        {
            try
            {
                using (StreamWriter po = new StreamWriter(file))
                {
                    for (int i = 0; i < countuser; i++)
                    {
                        po.WriteLine($"{user[i, 0]}|{user[i, 1]}|{user[i, 2]}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении пользователей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static string HashPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder build = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        build.Append(bytes[i].ToString("x2"));
                    }
                    return build.ToString();
                }
            }
            else
            {
                MessageBox.Show("Ошибка при хешировании пароля:", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
        //
        //public static bool Validpassword(string password, string HashPassword)
        //{
        //    return HashPassword(password) == hasspass;}
        private void userss(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;
            if (File.Exists(file))
            {
                try
                {
                    string[] filep = File.ReadAllLines(file);
                    countuser = 0;
                    foreach (string line in filep)
                    {
                        string[] parts = line.Split("|");
                        if (parts.Length == 3)
                        {
                            user[countuser, 0] = parts[0];
                            user[countuser, 1] = parts[1];
                            user[countuser, 2] = parts[2];
                            countuser++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении пользователей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Проверяем пароль перед сохранением
            if (!proverka(password))
            {
                return; // Прерываем регистрацию, если пароль не соответствует требованиям
            }

            HashLogin(name);
            HashPassword(password);
            hashemail(email);

            user[countuser, 0] = name;
            user[countuser, 1] = password;
            user[countuser, 2] = email;
            countuser++;

            saveUsers(password, name, email);
            MessageBox.Show("Пользователь успешно зарегистрирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            Form2 form2 = new Form2(this);
            form2.Show();
            this.Hide();
        }
        static string hashemail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                using (SHA256 sHA3_2563 = SHA256.Create())
                {
                    byte[] bytesss = sHA3_2563.ComputeHash(Encoding.UTF8.GetBytes(email));
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < bytesss.Length; i++)
                    {
                        sb.Append(bytesss[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            else
            {
                MessageBox.Show("Ошибка при хешировании почты:", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
        public bool proverka(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пароль не может быть пустым!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать более 8 символов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Regex.IsMatch(password, @"\d"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы 1 цифру!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Regex.IsMatch(password, @"[a-zA-Z]"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы 1 букву!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Regex.IsMatch(password, @"[!?/.,_-]"))
            {
                MessageBox.Show("Пароль должен содержать спец символ (!?/.,_-)", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        //static string hasfgg(string gh)
        //{
        //    if (!string.IsNullOrEmpty(gh))
        //    {
        //        using (SHA3_256 sha3 = SHA3_256.Create())
        //        {
        //            byte[] byt = sha3.ComputeHash(Encoding.UTF8.GetBytes(gh));
        //            StringBuilder sr = new StringBuilder();
        //            for (int i = 0; i < byt.Length; i++)
        //            {
        //                sr.Append(byt[i].ToString("x2"));
        //            }
        //            return sr.ToString();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Ошибка при хешировании логина:", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return string.Empty;
        //    }
        //}
        public bool AuthorizeUser(string login, string password, string email)
        {
            if (File.Exists(file))
            {
                try
                {
                    string[] filep = File.ReadAllLines(file);
                    foreach (string line in filep)
                    {
                        string[] parts = line.Split("|");
                        if (parts.Length == 3)
                        {
                            // Сравниваем хеши логина и пароля
                            string hashedLogin = HashLogin(login);
                            string hashedPassword = HashPassword(password);
                            string hasmail = hashemail(email);

                            if (parts[0] == hashedLogin && parts[1] == hashedPassword && parts[2] == hasmail)
                            {
                                MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                    }
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при авторизации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Файл пользователей не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
            this.Hide();
        }
    }
}
    
    

