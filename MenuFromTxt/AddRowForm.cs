using CursovayaDB;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DBConnectionLib;
using DBQueryLib;

namespace MenuFromTxt
{
    public partial class AddRowForm : Form
    {
        public AddRowForm()
        {
            InitializeComponent();
        }

        public DataGridViewRow data;

        int[] ocupiedIndexes;
        private DataGridViewRow DataViewRow;
        DataTable dt;
        int selectedIndex =-1;
        List<Control> controls = new List<Control>();

        List<string> ReferencedTables = new List<string>();

        DBConnection AddRowFormConnection;
        DBQuery AddRowFormQuery;



        public AddRowForm(DataTable dataTable)
        {
            InitializeComponent();

            dt = dataTable;

            this.Text = MenuFromTxt.Properties.Settings.Default.AppTitle + " редактирование таблицы ";

            if (dt.Columns.Count > 1)
                ocupiedIndexes = LoadReferencedTables();
            else
                ocupiedIndexes = new int[0];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                Point pLabel = new Point(10, 10 + 50 * i);
                Label label = new Label();
                label.Text = dt.Columns[i].ColumnName;
                label.Location = pLabel;
                label.Parent = this;
                label.AutoSize = true;

                bool isGenerated = false;
                for (int j = 0; j < ocupiedIndexes.Length; j++)
                    if (i == ocupiedIndexes[j])
                    {
                        generateListBox(i);
                        isGenerated = true;
                        
                    }
                if (!isGenerated)
                {
                    Point pBox = new Point(300, 10 + 50 * i);
                    TextBox textBox = new TextBox();
                    textBox.Location = pBox;
                    textBox.Parent = this;
                    controls.Add(textBox);
                }
            }
            
        }

        public AddRowForm(DataTable dataTable,DataGridViewRow viewRow,int index)
        {
            InitializeComponent();

            selectedIndex = index;
            dt = dataTable;
            DataViewRow = viewRow;
            this.Text = MenuFromTxt.Properties.Settings.Default.AppTitle + " редактирование таблицы ";

            if(dt.Columns.Count>1)
                ocupiedIndexes = LoadReferencedTables();
            else
                ocupiedIndexes = new int[0];

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                Point pLabel = new Point(10, 10 + 50 * i);
                Label label = new Label();
                label.Text = dataTable.Columns[i].ColumnName;
                label.Location = pLabel;
                label.Parent = this;
                label.AutoSize = true;

                bool isGenerated = false;
                for (int j = 0; j < ocupiedIndexes.Length; j++)
                    if (i == ocupiedIndexes[j])
                    {
                        generateListBox(i);
                        isGenerated = true;

                    }
                if (!isGenerated)
                {
                    Point pBox = new Point(300, 10 + 50 * i);
                    TextBox textBox = new TextBox();
                    textBox.Location = pBox;
                    textBox.Parent = this;
                    textBox.Text = DataViewRow.Cells[i].Value.ToString();
                    controls.Add(textBox);
                }
            }

            AddBtn.Text = "Обновить запись в таблице";
            AddBtn.Click -= AddBtn_Click;
            AddBtn.Click += ChangeBtn_Click;

        }

        private void generateListBox(int iPoint)
        {
            Point pBox = new Point(300, 10 + 50 * iPoint);
            ListBox listBox = new ListBox();
            listBox.Location = pBox;
            listBox.Parent = this;
            listBox.Size = new Size(300, 30);

            if (ReferencedTables[0] == "Клиенты")
            {
                string newQuery = "select * from " + ReferencedTables[1];
                string[] str1 = AddRowFormQuery.CreateQueryRead(AddRowFormConnection.conn, newQuery);
                newQuery = "select * from " + ReferencedTables[2];
                string[] newStr = AddRowFormQuery.CreateQueryRead(AddRowFormConnection.conn, newQuery);
                List<string> tableRows = new List<string>();
                tableRows.AddRange(str1);
                tableRows.AddRange(newStr);
                for (int j = 0; j < tableRows.Count; j++)
                {
                    listBox.Items.Add(tableRows[j]);
                }

                controls.Add(listBox);
                for(int i=0;i<3;i++)
                ReferencedTables.RemoveAt(0);
            }
            else
            {
                string newQuery = "select * from " + ReferencedTables[0];
                string[] tableRows = AddRowFormQuery.CreateQueryRead(AddRowFormConnection.conn, newQuery);
                for (int j = 0; j < tableRows.Length; j++)
                {
                    listBox.Items.Add(tableRows[j]);
                }

                controls.Add(listBox);
                ReferencedTables.RemoveAt(0);
            }
        }

        private int[] LoadReferencedTables()
        {
            AddRowFormConnection = new DBConnection("server=localhost;uid=root;pwd=admin;database="+ MenuFromTxt.Properties.Settings.Default.DBName);
            AddRowFormQuery = new DBQuery();
            AddRowFormConnection.connect();

            int []indexes = new int[dt.Columns.Count];
            for(int i=0; i < indexes.Length; i++)
                indexes[i] = -1;

            string[] referencedTable = new string[256];

            

            int k = 0;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == "Клиент_отправитель")
                {
                    ReferencedTables.Add("Клиенты");
                    indexes[k] = i;
                    k++;
                    ReferencedTables.Add("физический_клиент");
                    ReferencedTables.Add("юридический_клиент");
                }
                else if(dt.Columns[i].ColumnName == "Клиент_получатель")
                {
                    ReferencedTables.Add("Клиенты");
                    indexes[k] = i;
                    k++;
                    ReferencedTables.Add("физический_клиент");
                    ReferencedTables.Add("юридический_клиент");
                }
                else
                {
                    string query = "SELECT REFERENCED_TABLE_NAME FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = '" + dt.Columns[i].ColumnName + "';";
                    referencedTable = AddRowFormQuery.CreateQueryRead(AddRowFormConnection.conn, query);
                }
                if (referencedTable.Length > 0)
                {
                    indexes[k] = i;
                    k++;

                    ReferencedTables.Add(referencedTable[0]);
                    string newQuery = "select * from " + referencedTable[0];
                    string[] tableRows = AddRowFormQuery.CreateQueryRead(AddRowFormConnection.conn, newQuery);
                }
            }           
            return indexes;
        }

        private void AddRowForm_Load(object sender, EventArgs e)
        {

        }

        private List<object> validation(List<object> Arr)
        {
            for (int i = 0; i < controls.Count; i++)
                if (controls[i].Text.Length == 0)
                {
                    MessageBox.Show("Значение поля не может быть пустым");
                    return null;
                }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object element = dt.Rows[i][dt.Columns[0].ColumnName];
                if ((element.ToString()) == controls[0].Text && selectedIndex ==-1)
                {
                    MessageBox.Show("Значение совпадает с уже имеющимся значением");
                    return null;
                }
            }

            for (int i = 0; i < controls.Count; i++)
                Arr.Add(controls[i].Text);

            return Arr;
        }

        private void ChangeBtn_Click(object sender,EventArgs e)
        {
            List<object> Arr = new List<object>();
            Arr = validation(Arr);
            if (Arr == null)
                return;

            


            dt.Rows[selectedIndex].BeginEdit();
            for(int i = 0; i < dt.Rows[selectedIndex].ItemArray.Length; i++)
            {
                dt.Rows[selectedIndex][i] = Arr.ToArray()[i];
            }
            dt.Rows[selectedIndex].EndEdit();

            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            List<object> Arr = new List<object>();         

            Arr = validation(Arr);
            if (Arr == null)
                return;

            dt.Rows.Add(Arr.ToArray());
            
            this.Close();
        }

        private void AddRowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(AddRowFormConnection != null)
                if(AddRowFormConnection.conn.State == ConnectionState.Open)
                    AddRowFormConnection.close();
        }
    }
}
