
namespace InformationSecurity.Views
{
    partial class ChangePasswordForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.labelOldPassword = new System.Windows.Forms.Label();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRepeatPssword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(224, 200);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(160, 41);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(44, 200);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(153, 41);
            this.buttonChange.TabIndex = 8;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // labelOldPassword
            // 
            this.labelOldPassword.AutoSize = true;
            this.labelOldPassword.Location = new System.Drawing.Point(44, 39);
            this.labelOldPassword.Name = "labelOldPassword";
            this.labelOldPassword.Size = new System.Drawing.Size(116, 20);
            this.labelOldPassword.TabIndex = 7;
            this.labelOldPassword.Text = "Старый пароль";
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Location = new System.Drawing.Point(199, 36);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.PasswordChar = '*';
            this.textBoxOldPassword.Size = new System.Drawing.Size(185, 27);
            this.textBoxOldPassword.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Новый пароль";
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(199, 86);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(185, 27);
            this.textBoxNewPassword.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Повторите пароль";
            // 
            // textBoxRepeatPssword
            // 
            this.textBoxRepeatPssword.Location = new System.Drawing.Point(199, 141);
            this.textBoxRepeatPssword.Name = "textBoxRepeatPssword";
            this.textBoxRepeatPssword.PasswordChar = '*';
            this.textBoxRepeatPssword.Size = new System.Drawing.Size(185, 27);
            this.textBoxRepeatPssword.TabIndex = 12;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 285);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRepeatPssword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.labelOldPassword);
            this.Controls.Add(this.textBoxOldPassword);
            this.Name = "ChangePassword";
            this.Text = "Изменение пароля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label labelOldPassword;
        private System.Windows.Forms.TextBox textBoxOldPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRepeatPssword;
    }
}