using InformationSecurity.Models;
using InformationSecurity.Views.Admin;
using System;
using System.Collections.Generic;
using InformationSecurity.BusinessLogic.Services.GOSTCryptoService;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InformationSecurity.Views
{
    public partial class MainForm : Form
    {
        private User User;
        private string DecrtyptedText;
        byte[] byteKey, byteS, encryptedText;
        string Key = "jэ{уST…ИMЉіЦ\"“Г4т :бо‹JmU|Oxe";
        string S = "жжјJЌс";

        public MainForm(User user)
        {
            User = user;
            InitializeComponent();
            ChangeVisible();
            //if (user.NeedEnterPassword)
            //    ChangePassword();

            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            keyTextBox.Text = Key;
            sTextBox.Text = S;
            byteKey = Encoding.Default.GetBytes(Key);
            byteS = Encoding.Default.GetBytes(S);
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

        private void fileSaveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Gamma gam;

                if (encryptedText != null)
                {

                    if ((byteKey == null) || (byteKey.Length != 32))
                        MessageBox.Show("Введдите 256-битный ключ.");
                    else if ((byteS == null) || (byteS.Length != 8))
                        MessageBox.Show("Введдите 64-битную синхропосылку.");
                    else
                    {
                        gam = new Gamma(encryptedText, byteKey, byteS);
                        byte[] decrByteFile = gam.StartGamma();
                        DecrtyptedText = Encoding.Default.GetString(decrByteFile);
                    }
                }

                string file = saveFileDialog1.FileName;
                File.WriteAllText(file, DecrtyptedText);

                MessageBox.Show("Выгружено в файл", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void keyGenerateButton_Click(object sender, EventArgs e)
        {
            GenerateKey();
        }

        private void SGenerateButton_Click(object sender, EventArgs e)
        {
            GenerateS();
        }

        private void GenerateKey()
        {
            byteKey = new KeyGenerator(EKeyVariant.Key).GenerateKey();
            keyTextBox.Text = Encoding.Default.GetString(byteKey);
        }

        private void GenerateS()
        {
            byteS = new KeyGenerator(EKeyVariant.S).GenerateKey();
            sTextBox.Text = Encoding.Default.GetString(byteS);
        }

        private void fileLoadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                string text = File.ReadAllText(file);

                Gamma gam;

                byte[] btFile = Encoding.Default.GetBytes(text);

                if ((byteKey == null) || (byteKey.Length != 32))
                    MessageBox.Show("Введдите 256-битный ключ.");
                else if ((byteS == null) || (byteS.Length != 8))
                    MessageBox.Show("Введдите 64-битную синхропосылку.");
                else
                {
                    gam = new Gamma(btFile, byteKey, byteS);
                    encryptedText = gam.StartGamma();
                    textBox.Text = Encoding.Default.GetString(encryptedText);
                }
            }
        }
    }
}
