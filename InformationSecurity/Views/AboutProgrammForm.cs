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
                $"Алгоритм ГОСТ 28147. Режим гаммирования.{Environment.NewLine}";
        }
    }
}
