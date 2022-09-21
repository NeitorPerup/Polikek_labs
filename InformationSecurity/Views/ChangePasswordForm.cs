using System;
using InformationSecurity.Models;
using System.Windows.Forms;
using InformationSecurity.BusinessLogic.Helpers;
using System.Text.RegularExpressions;

namespace InformationSecurity.Views
{
    public partial class ChangePasswordForm : Form
    {
        private User User;
        private readonly Regex reg;
        public ChangePasswordForm(User user)
        {
            User = user;
            InitializeComponent();
            ChangeVisible();
            reg = new Regex(@"([a-zA-z]+[а-яА-я]+)|([а-яА-я]+[a-zA-z]+)");
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string oldPassword = textBoxOldPassword.Text;
            string newPassword = textBoxNewPassword.Text;
            string repeatedPassword = textBoxRepeatPssword.Text;

            if (!User.NeedEnterPassword)
            {
                if (string.IsNullOrEmpty(oldPassword))
                {
                    MessageBox.Show("Введите старый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (oldPassword.Md5() != User.Password)
                {
                    MessageBox.Show("Неверный старый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Введите новый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(repeatedPassword))
            {
                MessageBox.Show("Повторите новый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword != repeatedPassword)
            {
                MessageBox.Show("Введите одинаковый новый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (User.CheckPassword)
            {
                if (!reg.IsMatch(newPassword))
                {
                    MessageBox.Show("В пароле должны быть символы латиници и кириллицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            User.Password = newPassword.Md5();
            MessageBox.Show("Пароль изменён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChangeVisible()
        {
            if (User.NeedEnterPassword)
            {
                textBoxOldPassword.Visible = false;
                labelOldPassword.Visible = false;
            }
        }
    }
}
