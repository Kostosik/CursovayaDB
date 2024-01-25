namespace CursovayaDB
{
    partial class App
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AddRowBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(1, 104);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(783, 388);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.Visible = false;
            this.dataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellValueChanged);
            this.dataGrid.SelectionChanged += new System.EventHandler(this.dataGrid_SelectionChanged);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(38, 514);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(127, 35);
            this.UpdateBtn.TabIndex = 1;
            this.UpdateBtn.Text = "Обновить таблицу в базе данных";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Visible = false;
            this.UpdateBtn.Click += new System.EventHandler(this.Updatebutton_Click);
            // 
            // AddRowBtn
            // 
            this.AddRowBtn.Location = new System.Drawing.Point(635, 514);
            this.AddRowBtn.Name = "AddRowBtn";
            this.AddRowBtn.Size = new System.Drawing.Size(125, 35);
            this.AddRowBtn.TabIndex = 2;
            this.AddRowBtn.Text = "Добавить запись в таблицу";
            this.AddRowBtn.UseVisualStyleBackColor = true;
            this.AddRowBtn.Visible = false;
            this.AddRowBtn.Click += new System.EventHandler(this.AddRowBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Изменить запись в таблице";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(248, 514);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(125, 35);
            this.DeleteBtn.TabIndex = 4;
            this.DeleteBtn.Text = "Удалить запись в таблице";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Visible = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddRowBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.dataGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "App";
            this.Text = "form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dataGrid;
        internal System.Windows.Forms.Button UpdateBtn;
        internal System.Windows.Forms.Button AddRowBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DeleteBtn;
    }
}

