using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MenuFromTxt;
using DBConnectionLib;
using DBQueryLib;

namespace CursovayaDB
{
    public partial class App : Form
    {
        public string loggedUser;
        bool isAdmin = false;

        private DBConnection appConnection;
        private DBQuery appQuery;
        internal string tableName;
        public DataTable ds;
        DataGridViewRow selectedRow;

        public App()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Text = MenuFromTxt.Properties.Settings.Default.AppTitle;

            ds = new DataTable();

            appConnection = new DBConnection("server=localhost;uid=root;pwd=admin;database="+ MenuFromTxt.Properties.Settings.Default.DBName);
            appQuery = new DBQuery();
            appConnection.connect();

            if ((loggedUser == "Директор") || (loggedUser == "user"))
                loggedUser = "user";
            else
                loggedUser = "admin";

            if (loggedUser == "user")
                isAdmin = false;
            else
                isAdmin = true;

            if (isAdmin)
            {
                dataGrid.AllowUserToAddRows = false;
                dataGrid.AllowUserToDeleteRows = true;
                dataGrid.AllowUserToResizeColumns = true;
                dataGrid.AllowUserToResizeRows = true;
                dataGrid.ReadOnly = true;
                dataGrid.Enabled = true;
            }
            else
            {
                dataGrid.AllowUserToAddRows = false;
                dataGrid.AllowUserToDeleteRows = false;
                dataGrid.AllowUserToResizeColumns = false;
                dataGrid.AllowUserToResizeRows = false;
                dataGrid.ReadOnly = true;
                dataGrid.Enabled = false;
            }
        }

        public void visibilityBtns()
        {
            if (isAdmin)
            {
                UpdateBtn.Visible = true;
                AddRowBtn.Visible = true;
                button1.Visible = true;
                DeleteBtn.Visible = true;
            }
            else
            {
                UpdateBtn.Visible = false;
                AddRowBtn.Visible = false;
                button1.Visible = false;
                DeleteBtn.Visible = false;
            }
        }

        internal void updateDataGridView()
        {
            ds = appQuery.fillTable("select * from "+tableName, appConnection.conn);

            dataGrid.DataSource = ds;

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        internal void UpdateTable()
        {
            string query = "SELECT * FROM " + tableName;

            appQuery.UpdateTableQuery(appConnection.conn, query, ds);
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        public void AddRowFromForm(AddRowForm sender)
        {
            ds.Rows.Add(sender.data);
            sender.Close();
        }

        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            int columnsCount = dataGrid.Columns.Count;
            string[] columsHeader = new string[columnsCount];
            for (int i = 0; i < columnsCount; i++)
                columsHeader[i]=dataGrid.Columns[i].HeaderCell.Value.ToString();

            AddRowForm rowForm = new AddRowForm(ds);
            rowForm.Visible = true;
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGrid.SelectedCells[0].RowIndex;
                selectedRow = dataGrid.Rows[selectedrowindex];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGrid.SelectedCells.Count > 0)
            {
                AddRowForm addRowForm = new AddRowForm(ds, selectedRow, selectedRow.Index);
                addRowForm.Visible = true;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedCells.Count > 0)
            {
                dataGrid.Rows.RemoveAt(dataGrid.SelectedCells[0].RowIndex);
            }
        }
    }
}
