using InformationSecurity.Models;
using InformationSecurity.Views.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InformationSecurity.Views
{
    public partial class MainForm : Form
    {
        private User User;
        public MainForm(User user)
        {
            User = user;
            InitializeComponent();
            ChangeVisible();
            if (user.NeedEnterPassword)
                ChangePassword();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutProgrammForm();
            form.ShowDialog();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UsersForm();
            form.ShowDialog();
        }

        private void изменитьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void ChangePassword()
        {
            var form = new ChangePasswordForm(User);
            if (form.ShowDialog() == DialogResult.Cancel && User.NeedEnterPassword)
            {
                MessageBox.Show("Необходимо ввести пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeVisible()
        {
            if (!User.IsAdmin)
            {
                пользователиToolStripMenuItem.Visible = false;
            }
        }
    }
}
