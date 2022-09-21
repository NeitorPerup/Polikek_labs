using InformationSecurity.BusinessLogic.Helpers;
using InformationSecurity.BusinessLogic.Services;
using InformationSecurity.Models;
using System;
using System.Windows.Forms;

namespace InformationSecurity.Views
{
    public partial class AutorizationForm : Form
    {
        private readonly UserService _userService;
        private int WrongPasswordCounter = 0;
        private readonly int MaxWrongPasswordTry = 3;
        private User user;
        public bool AutorizationSuccess { get; set; }
        public AutorizationForm()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        public User GetUser() => user;

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user = _userService.Get(login);
            if (user == null || !user.IsActive)
            {
                MessageBox.Show("Неверный логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrEmpty(user.Password) && user.Password != password.Md5())
            {
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (WrongPasswordCounter++ == MaxWrongPasswordTry)
                    Close();
                return;
            }
            AutorizationSuccess = true;
            MessageBox.Show($"Выполен вход", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
