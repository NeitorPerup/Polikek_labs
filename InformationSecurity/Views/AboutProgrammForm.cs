using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InformationSecurity.Views
{
    public partial class AboutProgrammForm : Form
    {
        public AboutProgrammForm()
        {
            InitializeComponent();
            textBox.Text =
                $"Автор программы: студент группы ИСЭбд-41 Белов Илья{Environment.NewLine}" +
                $"Вариант №8{Environment.NewLine}" +
                $"Задание:{Environment.NewLine}" +
                $"В пароле должны быть латинские буквы и символы кириллицы{Environment.NewLine}" +
                $"Используемый режим шифрования DES: OFB{Environment.NewLine}" +
                $"Добавление к ключу случайного значения: Нет{Environment.NewLine}" +
                $"Алгоритм хеширования: Md5{Environment.NewLine}";
        }
    }
}
