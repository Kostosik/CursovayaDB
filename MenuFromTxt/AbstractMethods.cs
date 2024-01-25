using MenuFromTxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursovayaDB
{
    public class AbstractMethods
    {


        public AbstractMethods() { }
        public void Method(ToolStripMenuItem sender, string methodName, string tableName)
        {
            MessageBox.Show("Нажата кнопка: " + sender.Text + " Имя метода: " + methodName);
        }

        public void showInformationUser(ToolStripMenuItem sender, Form ownerForm,string tableName)
        {

        }

        public void showInformationAdmin(ToolStripMenuItem sender, Form ownerForm, string tableName)
        {
            (ownerForm as App).dataGrid.Visible = true;
            (ownerForm as App).tableName = tableName;
            (ownerForm as App).visibilityBtns();
            (ownerForm as App).updateDataGridView();
        }

        public void ProgrammContentsMethod(ToolStripMenuItem sender, Form ownerForm, string tableName)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Visible = true;
        }

        public void PasswordChange(ToolStripMenuItem sender, Form ownerForm, string tableName)
        {
            ChangePassword changePassword = new ChangePassword(ownerForm as App);
            ownerForm.Visible = false;
            changePassword.Visible = true;
        }
    }
}
