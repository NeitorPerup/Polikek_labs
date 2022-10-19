
namespace InformationSecurity.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьПарольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спарвкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SGenerateButton = new System.Windows.Forms.Button();
            this.sTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fileSaveButton = new System.Windows.Forms.Button();
            this.fileLoadButton = new System.Windows.Forms.Button();
            this.keyGenerateButton = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пользователиToolStripMenuItem,
            this.изменитьПарольToolStripMenuItem,
            this.спарвкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(447, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            this.пользователиToolStripMenuItem.Click += new System.EventHandler(this.пользователиToolStripMenuItem_Click);
            // 
            // изменитьПарольToolStripMenuItem
            // 
            this.изменитьПарольToolStripMenuItem.Name = "изменитьПарольToolStripMenuItem";
            this.изменитьПарольToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.изменитьПарольToolStripMenuItem.Text = "Изменить пароль";
            this.изменитьПарольToolStripMenuItem.Click += new System.EventHandler(this.изменитьПарольToolStripMenuItem_Click);
            // 
            // спарвкаToolStripMenuItem
            // 
            this.спарвкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.спарвкаToolStripMenuItem.Name = "спарвкаToolStripMenuItem";
            this.спарвкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.спарвкаToolStripMenuItem.Text = "Спарвка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // SGenerateButton
            // 
            this.SGenerateButton.Location = new System.Drawing.Point(279, 83);
            this.SGenerateButton.Name = "SGenerateButton";
            this.SGenerateButton.Size = new System.Drawing.Size(131, 32);
            this.SGenerateButton.TabIndex = 27;
            this.SGenerateButton.Text = "Сгенерировать";
            this.SGenerateButton.UseVisualStyleBackColor = true;
            this.SGenerateButton.Click += new System.EventHandler(this.SGenerateButton_Click);
            // 
            // sTextBox
            // 
            this.sTextBox.Location = new System.Drawing.Point(59, 84);
            this.sTextBox.Name = "sTextBox";
            this.sTextBox.ReadOnly = true;
            this.sTextBox.Size = new System.Drawing.Size(177, 22);
            this.sTextBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "S:";
            // 
            // fileSaveButton
            // 
            this.fileSaveButton.Location = new System.Drawing.Point(239, 435);
            this.fileSaveButton.Name = "fileSaveButton";
            this.fileSaveButton.Size = new System.Drawing.Size(171, 85);
            this.fileSaveButton.TabIndex = 23;
            this.fileSaveButton.Text = "Сохранить зашифрованный файл";
            this.fileSaveButton.UseVisualStyleBackColor = true;
            this.fileSaveButton.Click += new System.EventHandler(this.fileSaveButton_Click);
            // 
            // fileLoadButton
            // 
            this.fileLoadButton.Location = new System.Drawing.Point(21, 435);
            this.fileLoadButton.Name = "fileLoadButton";
            this.fileLoadButton.Size = new System.Drawing.Size(163, 85);
            this.fileLoadButton.TabIndex = 20;
            this.fileLoadButton.Text = "Загрузить файл для шифрования";
            this.fileLoadButton.UseVisualStyleBackColor = true;
            this.fileLoadButton.Click += new System.EventHandler(this.fileLoadButton_Click);
            // 
            // keyGenerateButton
            // 
            this.keyGenerateButton.Location = new System.Drawing.Point(279, 41);
            this.keyGenerateButton.Name = "keyGenerateButton";
            this.keyGenerateButton.Size = new System.Drawing.Size(131, 34);
            this.keyGenerateButton.TabIndex = 18;
            this.keyGenerateButton.Text = "Сгенерировать";
            this.keyGenerateButton.UseVisualStyleBackColor = true;
            this.keyGenerateButton.Click += new System.EventHandler(this.keyGenerateButton_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(59, 47);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.ReadOnly = true;
            this.keyTextBox.Size = new System.Drawing.Size(177, 22);
            this.keyTextBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Key:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(21, 121);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(389, 293);
            this.textBox.TabIndex = 28;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 587);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.SGenerateButton);
            this.Controls.Add(this.sTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileSaveButton);
            this.Controls.Add(this.fileLoadButton);
            this.Controls.Add(this.keyGenerateButton);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Основная форма";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьПарольToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спарвкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button SGenerateButton;
        private System.Windows.Forms.TextBox sTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fileSaveButton;
        private System.Windows.Forms.Button fileLoadButton;
        private System.Windows.Forms.Button keyGenerateButton;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox;
    }
}