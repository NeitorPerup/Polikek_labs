using InformationSecurity.BusinessLogic.Services;
using InformationSecurity.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InformationSecurity.Views.Admin
{
    public partial class UserForm : Form
    {
        public string Login { get; set; }
        private readonly UserService _userService;
        public UserForm()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            bool isActive = !checkBoxDisable.Checked;
            bool checkPassword = checkBoxCheckPassword.Checked;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Если при редактировании изменили логин на неуникальный
            if (!string.IsNullOrEmpty(Login) && Login != login && !_userService.IsUniqueLogin(login))
            {
                MessageBox.Show("Данный логин занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Добавление пользователя с существующим логином
            if (string.IsNullOrEmpty(Login) && !_userService.IsUniqueLogin(login))
            {
                MessageBox.Show("Данный логин занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = new User
            {
                Login = login,
                IsActive = isActive,
                CheckPassword = checkPassword
            };

            if (string.IsNullOrEmpty(Login))
                _userService.Add(user);
            else
                _userService.Edit(user, Login);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Login))
            {
                var user = _userService.Get(Login);
                if (user == null)
                    return;

                textBoxLogin.Text = user.Login;
                checkBoxCheckPassword.Checked = user.CheckPassword;
                checkBoxDisable.Checked = !user.IsActive;
            }
        }
    }
}
