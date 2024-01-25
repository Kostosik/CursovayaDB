using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursovayaDB;
using System.Configuration;
using Org.BouncyCastle.Asn1.BC;
using DBConnectionLib;
using DBQueryLib;

namespace MenuFromTxt
{
    public partial class ChangePassword : Form
    {
        DBConnection loginConnection;
        DBQuery loginQuery;
        string loggedUser;
        string PasswordLine;
        App ownerForm;

        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(App ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
            loggedUser = ownerForm.loggedUser;
        }


        private void ConnectToDB()
        {
            loginConnection = new DBConnection("server=localhost;uid=root;pwd=admin;database="+ MenuFromTxt.Properties.Settings.Default.DBName);
            loginConnection.connect();
            loginQuery = new DBQuery();
            PasswordLine = loginQuery.CreateQueryRead(loginConnection.conn, "select Password from password where UserName = '" + loggedUser + "'")[0];
        }


        private void LoginBtn_Click(object sender, EventArgs e)
        {
            ConnectToDB();
            PasswordEncrypt encrypt = new PasswordEncrypt();

            if (encrypt.PasswordCheck(NewPasswordTB.Text, PasswordLine))
            {
                MessageBox.Show("Пароли не могут быть одинаковы");
                return;
            }

            if (!encrypt.PasswordCheck(OldPasswordTB.Text, PasswordLine))
            {
                MessageBox.Show("Старый пароль не совпадает с введенным");
                return;
            }
            if (!(NewPasswordTB.Text == ConfirmPasswordTB.Text))
            {
                MessageBox.Show("");
                return;
            }
            string newPassword = encrypt.EncryptPasss(NewPasswordTB.Text);
            string query = "Update password set password = '" + newPassword + "' where UserName = '" + loggedUser + "'";
            loginQuery.CreatequeryWrite(loginConnection.conn, query);

            this.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            OldPasswordLabel.Text = "Прежний пароль";
            NewPasswordLabel.Text = "Новый пароль";
            ConfirmPasswordLabel.Text = "Подтвердите";
            LoginBtn.Text = "Вход";
            ExitBtn.Text = "Отмена";
            AppNameLabel.Text = Properties.Settings.Default.AppTitle;
            AppNameLabel.Size = new Size(this.Width - 15, 26);
            AppNameLabel.AutoSize = false;
            whatToDoLabel.Text = "Изменение текущего пароля";
            whatToDoLabel.Size = new Size(this.Width - 15, 26);
            whatToDoLabel.AutoSize = false;
            versionLabel.Text = Properties.Settings.Default.Version;
            versionLabel.Size = new Size(this.Width - 15, 26);
            versionLabel.AutoSize = false;
            this.Text = "Смена пароля";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            keysPicture.Image = Image.FromFile("keys.png");
            keysPicture.BringToFront();
        }

        private void PasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            ownerForm.Visible = true;
        }
    }
}
