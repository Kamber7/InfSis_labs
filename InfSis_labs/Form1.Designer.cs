using System.Windows.Forms;

namespace InfSis_labs
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnInit = new Button();
            txtHost = new TextBox();
            txtPort = new TextBox();
            txtDatabase = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnOpen = new Button();
            btnClose = new Button();
            btnExecute = new Button();
            lblStatus = new Label();
            richTextBox = new RichTextBox();
            btnView = new Button();
            btnInsert = new Button();
            btnDelete = new Button();
            listBoxFunctions = new ListBox();
            btnExecuteFunction = new Button();
            dataGridView = new DataGridView();
            btnLoadDataSet = new Button();
            btnFilter = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnInit
            // 
            btnInit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnInit.Location = new Point(50, 24);
            btnInit.Name = "btnInit";
            btnInit.Size = new Size(350, 60);
            btnInit.TabIndex = 0;
            btnInit.Text = "Инициализировать соединение";
            btnInit.UseVisualStyleBackColor = true;
            btnInit.Click += btnInit_Click;
            // 
            // txtHost
            // 
            txtHost.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtHost.Location = new Point(50, 99);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(350, 34);
            txtHost.TabIndex = 1;
            txtHost.Text = "localhost";
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPort.Location = new Point(50, 146);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(350, 34);
            txtPort.TabIndex = 2;
            txtPort.Text = "5432";
            // 
            // txtDatabase
            // 
            txtDatabase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDatabase.Location = new Point(50, 193);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(350, 34);
            txtDatabase.TabIndex = 3;
            txtDatabase.Text = "Sharpes_labs";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(50, 241);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(350, 34);
            txtUsername.TabIndex = 4;
            txtUsername.Text = "postgres";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(50, 287);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(350, 34);
            txtPassword.TabIndex = 5;
            txtPassword.Text = "12345";
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpen.Location = new Point(50, 334);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(170, 60);
            btnOpen.TabIndex = 6;
            btnOpen.Text = "Открыть соединение";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(230, 334);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(170, 60);
            btnClose.TabIndex = 7;
            btnClose.Text = "Закрыть соединение";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnExecute
            // 
            btnExecute.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExecute.Location = new Point(50, 400);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(350, 51);
            btnExecute.TabIndex = 8;
            btnExecute.Text = "Выполнить";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(500, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 21);
            lblStatus.TabIndex = 9;
            // 
            // richTextBox
            // 
            richTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox.Location = new Point(450, 50);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(900, 600);
            richTextBox.TabIndex = 10;
            richTextBox.Text = "";
            // 
            // btnView
            // 
            btnView.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnView.Location = new Point(450, 670);
            btnView.Name = "btnView";
            btnView.Size = new Size(150, 60);
            btnView.TabIndex = 11;
            btnView.Text = "Просмотр";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnInsert
            // 
            btnInsert.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnInsert.Location = new Point(610, 670);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(150, 60);
            btnInsert.TabIndex = 12;
            btnInsert.Text = "Вставить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(1090, 670);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 60);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // listBoxFunctions
            // 
            listBoxFunctions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxFunctions.FormattingEnabled = true;
            listBoxFunctions.ItemHeight = 21;
            listBoxFunctions.Location = new Point(50, 457);
            listBoxFunctions.Name = "listBoxFunctions";
            listBoxFunctions.Size = new Size(350, 130);
            listBoxFunctions.TabIndex = 15;
            listBoxFunctions.Visible = false;
            // 
            // btnExecuteFunction
            // 
            btnExecuteFunction.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExecuteFunction.Location = new Point(50, 602);
            btnExecuteFunction.Name = "btnExecuteFunction";
            btnExecuteFunction.Size = new Size(350, 60);
            btnExecuteFunction.TabIndex = 16;
            btnExecuteFunction.Text = "Выполнить функцию";
            btnExecuteFunction.UseVisualStyleBackColor = true;
            btnExecuteFunction.Visible = false;
            btnExecuteFunction.Click += btnExecuteFunction_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView.Location = new Point(450, 50);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(900, 600);
            dataGridView.TabIndex = 17;
            dataGridView.Visible = false;
            // 
            // btnLoadDataSet
            // 
            btnLoadDataSet.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadDataSet.Location = new Point(770, 670);
            btnLoadDataSet.Name = "btnLoadDataSet";
            btnLoadDataSet.Size = new Size(150, 60);
            btnLoadDataSet.TabIndex = 18;
            btnLoadDataSet.Text = "Загрузить DataSet";
            btnLoadDataSet.UseVisualStyleBackColor = true;
            btnLoadDataSet.Click += btnLoadDataSet_Click;
            // 
            // btnFilter
            // 
            btnFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnFilter.Location = new Point(50, 670);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(350, 60);
            btnFilter.TabIndex = 19;
            btnFilter.Text = "Фильтр (RPG)";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.Location = new Point(930, 670);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 60);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "Обновить данные";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // Form1
            // 
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1400, 800);
            Controls.Add(btnInit);
            Controls.Add(txtHost);
            Controls.Add(txtPort);
            Controls.Add(txtDatabase);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(btnOpen);
            Controls.Add(btnClose);
            Controls.Add(btnExecute);
            Controls.Add(lblStatus);
            Controls.Add(richTextBox);
            Controls.Add(btnView);
            Controls.Add(btnInsert);
            Controls.Add(btnDelete);
            Controls.Add(listBoxFunctions);
            Controls.Add(btnExecuteFunction);
            Controls.Add(dataGridView);
            Controls.Add(btnLoadDataSet);
            Controls.Add(btnFilter);
            Controls.Add(btnUpdate);
            MinimumSize = new Size(1200, 700);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление базой данных PostgreSQL";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnInit;
        private TextBox txtHost;
        private TextBox txtPort;
        private TextBox txtDatabase;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnOpen;
        private Button btnClose;
        private Button btnExecute;
        private Label lblStatus;
        private RichTextBox richTextBox;
        private Button btnView;
        private Button btnInsert;
        private Button btnDelete;
        private ListBox listBoxFunctions;
        private Button btnExecuteFunction;
        private DataGridView dataGridView;
        private Button btnLoadDataSet;
        private Button btnFilter;
        private Button btnUpdate;
    }
}