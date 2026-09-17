using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private int failedAttempts = 0; // Счетчик неудачных попыток входа
        private string currentCaptcha = ""; // Сгенерированный код капчи

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Проверяем капчу, если она активна (были ошибки входа)
            if (failedAttempts >= 1)
            {
                if (txtCaptcha.Text != currentCaptcha)
                {
                    MessageBox.Show("Капча введена неверно! Форма заблокирована на 10 секунд.");
                    await BlockFormAsync();
                    GenerateCaptcha();
                    return;
                }
            }

            // 2. Идем в базу проверять логин и пароль
            string login = txtLogin.Text;
            string password = txtPassword.Text;


            // Проверяем админа (Стаса) и обычного клиента
            if ((login == "admin" && password == "admin") || (login == "client" && password == "client"))
            {
                failedAttempts = 0;
                string fullName = login == "admin" ? "Савин Станислав Гордеевич" : "Игнатов Роман Степанович";
                int roleId = login == "admin" ? 1 : 3; // 1 - Админ, 3 - Клиент

                MessageBox.Show($"Добро пожаловать, {fullName}!");

                // ТУТ БУДЕТ ОТКРЫТИЕ СЛЕДУЮЩЕГО ОКНА МАГАЗИНА!
                // Передаем роль пользователя в главное окно, чтобы скрыть/показать кнопки
                MainForm mainForm = new MainForm(roleId, fullName);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else // Если логин или пароль не подошли
            {
                failedAttempts++;
                MessageBox.Show("Неверный логин или пароль!");

                if (failedAttempts == 1)
                {
                    // Показываем скрытые элементы капчи после 1-й ошибки
                    lblCaptcha.Visible = true;
                    txtCaptcha.Visible = true;
                    GenerateCaptcha();
                }
                else if (failedAttempts > 1)
                {
                    // Намертво блокируем интерфейс на 10 секунд по ТЗ
                    await BlockFormAsync();
                    GenerateCaptcha();
                }
            }

        }

        // Генератор капчи из 4 случайных цифр по ТЗ
        private void GenerateCaptcha()
        {
            Random rand = new Random();
            currentCaptcha = rand.Next(1000, 9999).ToString();
            lblCaptcha.Text = $"Введите код: {currentCaptcha}";
            txtCaptcha.Text = "";
        }

        // Асинхронная блокировка по требованиям ТЗ
        private async System.Threading.Tasks.Task BlockFormAsync()
        {
            btnSubmit.Enabled = false;
            txtLogin.Enabled = false;
            txtPassword.Enabled = false;
            txtCaptcha.Enabled = false;

            // Задержка ровно на 10 секунд (10000 миллисекунд)
            await System.Threading.Tasks.Task.Delay(10000);

            btnSubmit.Enabled = true;
            txtLogin.Enabled = true;
            txtPassword.Enabled = true;
            txtCaptcha.Enabled = true;
        }
    }
}
