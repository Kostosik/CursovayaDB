using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using BCrypt;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MenuFromTxt;
using DBConnectionLib;
using DBQueryLib;

namespace CursovayaDB
{
    public partial class Login : Form
    {
        bool loginCheck = false;

        string[] UserLines;
        string[] PasswordLines;
        DBConnection loginConnection;
        DBQuery loginQuery;

        public Login()
        {
            InitializeComponent();

            var capsLockStatusLabel = new ToolStripStatusLabel();
            statusStrip.Items.Add(capsLockStatusLabel);
            this.KeyPreview = true;
            this.KeyDown += (sender, e) =>
            {
                capsLockStatusLabel.Text = string.Format("Клавиша CapsLock: " + (Control.IsKeyLocked(Keys.CapsLock) ? "Нажата" :  "Не нажата"));
            };
            capsLockStatusLabel.Text = string.Format("Клавиша CapsLock: " + (Control.IsKeyLocked(Keys.CapsLock) ? "Нажата" : "Не нажата"));

            var keyboardLayoutStatusLabel = new ToolStripStatusLabel();
            statusStrip.Items.Add(keyboardLayoutStatusLabel);
            this.InputLanguageChanged += (sender, e) =>
            {
                keyboardLayoutStatusLabel.Text = string.Format("Язык ввода: {0}", InputLanguage.CurrentInputLanguage.LayoutName);
            };
            keyboardLayoutStatusLabel.Text = string.Format("Язык ввода: {0}", InputLanguage.CurrentInputLanguage.LayoutName);
            statusStrip.Size = new Size(this.Width, 20);
            statusStrip.AutoSize = false;


            loginConnection = new DBConnection("server=localhost;uid=root;pwd=admin;database="+ MenuFromTxt.Properties.Settings.Default.DBName);
            loginConnection.connect();
            loginQuery = new DBQuery();
            UserLines = loginQuery.CreateQueryRead(loginConnection.conn, "select userName from password");
            PasswordLines = loginQuery.CreateQueryRead(loginConnection.conn, "select Password from password");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoginLabel.Text = "Имя пользователя";
            PasswordLabel.Text = "Пароль";
            LoginBtn.Text = "Вход";
            ExitBtn.Text = "Отмена";
            AppNameLabel.Text = MenuFromTxt.Properties.Settings.Default.AppTitle;
            AppNameLabel.Size = new Size(this.Width - 15, 26);
            AppNameLabel.AutoSize = false;
            whatToDoLabel.Text = "Введите имя пользователя и пароль";
            whatToDoLabel.Size = new Size ( this.Width-15,26);
            whatToDoLabel.AutoSize = false;
            versionLabel.Text = MenuFromTxt.Properties.Settings.Default.Version;
            versionLabel.Size = new Size(this.Width - 15, 26);
            versionLabel.AutoSize = false;
            this.Text = "Вход";
            keysPicture.Image = Image.FromFile("keys.png");
            keysPicture.BringToFront();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckLoginPass(string userLine,string passwordLine)
        {
            PasswordEncrypt encrypt = new PasswordEncrypt();


            if (LoginTB.Text == userLine && encrypt.PasswordCheck(PasswordTB.Text, passwordLine)) //PasswordTB.Text == passwordLine)
            {
                string[] menuText;

                string query = "select MenuText from password where UserName = '" + userLine + "' and Password = '" + passwordLine + "'";

                loginCheck = true;
                App app = new App();
                app.loggedUser = userLine;
                menuText = loginQuery.CreateQueryRead(loginConnection.conn, query);

                Menu menu = new Menu(app, menuText[0]);

                app.Visible = true;
                this.Visible = false;
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            for(int i=0;i<UserLines.Length;i++)
                CheckLoginPass(UserLines[i], PasswordLines[i]);

            if (loginCheck == false)
            {
                MessageBox.Show("Неправильный логин или пароль !");
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter) 
            {
                LoginBtn_Click(sender, null);
            }
        }
    }
}
