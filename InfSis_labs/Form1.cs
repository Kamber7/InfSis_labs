using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace InfSis_labs
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection connection;
        private NpgsqlCommand command;
        private DataTable gamesDataTable;

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // �������� �������� �� ���������
            txtHost.Visible = false;
            txtPort.Visible = false;
            txtDatabase.Visible = false;
            txtUsername.Visible = false;
            txtPassword.Visible = false;
            btnOpen.Visible = false;
            btnClose.Visible = false;
            btnExecute.Visible = false;
            richTextBox.Visible = false;
            btnView.Visible = false;
            btnInsert.Visible = false;
            btnDelete.Visible = false;

            // ������������� �������� �� ���������
            txtHost.Text = "localhost";
            txtPort.Text = "5432";
            txtDatabase.Text = "Sharpes_labs";
            txtUsername.Text = "postgres";
            txtPassword.Text = "12345";


            gamesDataTable = new DataTable();
            gamesDataTable.Columns.Add("ID", typeof(int));
            gamesDataTable.Columns.Add("��������", typeof(string));
            gamesDataTable.Columns.Add("����", typeof(string));
            gamesDataTable.Columns.Add("��� �������", typeof(int));

            // ��������� DataGridView
            dataGridView.DataSource = gamesDataTable;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Visible = false;

            // ��������� ListBox ��� �������
            listBoxFunctions.Items.Add("insert_game - �������� ����");
            listBoxFunctions.Items.Add("delete_game_by_id - ������� ���� �� ID");
            listBoxFunctions.Items.Add("get_all_games - �������� ��� ����");
            listBoxFunctions.Visible = false;
            lblStatus.Text = "���������� �� ����������������";
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            // ���������� TextBox'� ��� ����� ���������� ����������
            txtHost.Visible = true;
            txtPort.Visible = true;
            txtDatabase.Visible = true;
            txtUsername.Visible = true;
            txtPassword.Visible = true;

            // ���������� ������ ��������/�������� ����������
            btnOpen.Visible = true;
            btnClose.Visible = true;

            // �������������� ����������
            string connectionString = $"Host={txtHost.Text};Port={txtPort.Text};Database={txtDatabase.Text};Username={txtUsername.Text};Password={txtPassword.Text}";
            connection = new NpgsqlConnection(connectionString);

            lblStatus.Text = "���������� ����������������, �� �� �������";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    lblStatus.Text = "���������� �������";

                    // ���������� ������ ���������� �������
                    btnExecute.Visible = true;

                    // ���������� �������� ��� ������ � �������
                    richTextBox.Visible = true;
                    btnView.Visible = true;
                    btnInsert.Visible = true;
                    btnDelete.Visible = true;
                    listBoxFunctions.Visible = true;
                    btnExecuteFunction.Visible = true;
                    dataGridView.Visible = true;
                }
                else
                {
                    lblStatus.Text = "���������� ��� �������";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ����������: {ex.Message}");
                lblStatus.Text = "������ ����������";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    lblStatus.Text = "���������� �������";

                    // �������� ������ ���������� �������
                    btnExecute.Visible = false;

                    // �������� �������� ��� ������ � �������
                    richTextBox.Visible = false;
                    btnView.Visible = false;
                    btnInsert.Visible = false;
                    btnDelete.Visible = false;
                    listBoxFunctions.Visible = false;
                    btnExecuteFunction.Visible = false;
                    dataGridView.Visible = false;
                }
                else
                {
                    lblStatus.Text = "���������� ��� �������";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ����������: {ex.Message}");
                lblStatus.Text = "������ ��� �������� ����������";
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                // ������� RichTextBox � ���������� ���
                richTextBox.Clear();
                richTextBox.Visible = true;
                dataGridView.Visible = false;

                using (var command = new NpgsqlCommand("SELECT * FROM games", connection))
                using (var reader = command.ExecuteReader())
                {
                    richTextBox.AppendText("���������� ������� games:\n\n");
                    while (reader.Read())
                    {
                        richTextBox.AppendText($"ID: {reader["id"]}, ��������: {reader["title"]}, ����: {reader["genre"]}, ��� �������: {reader["release_year"]}\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� �������: {ex.Message}");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox.Clear();
                richTextBox.Visible = true;
                dataGridView.Visible = false;
                command = new NpgsqlCommand("SELECT * FROM games", connection);
                var reader = command.ExecuteReader();

                richTextBox.Clear();
                richTextBox.AppendText("���������� ������� games:\n\n");

                while (reader.Read())
                {
                    richTextBox.AppendText($"ID: {reader["id"]}, ��������: {reader["title"]}, ����: {reader["genre"]}, ��� �������: {reader["release_year"]}\n");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ��������� ������: {ex.Message}");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // ������� ����� ��� ����� ������
                using (Form inputForm = new Form())
                {
                    inputForm.Text = "���������� ����� ����";
                    inputForm.Size = new System.Drawing.Size(400, 250); // ��������� ������ ����
                    inputForm.StartPosition = FormStartPosition.CenterParent;

                    Label lblTitle = new Label() { Text = "��������:", Left = 20, Top = 20, Width = 100 };
                    TextBox txtTitle = new TextBox() { Left = 130, Top = 20, Width = 230 };

                    Label lblGenre = new Label() { Text = "����:", Left = 20, Top = 60, Width = 100 };
                    TextBox txtGenre = new TextBox() { Left = 130, Top = 60, Width = 230 };

                    Label lblYear = new Label() { Text = "��� �������:", Left = 20, Top = 100, Width = 100 };
                    TextBox txtYear = new TextBox() { Left = 130, Top = 100, Width = 230 };

                    Button btnOk = new Button() { Text = "��������", Left = 150, Top = 140, Width = 100, Height = 40};
                    btnOk.DialogResult = DialogResult.OK;

                    Button btnCancel = new Button() { Text = "������", Left = 260, Top = 140, Width = 100, Height = 40 };
                    btnCancel.DialogResult = DialogResult.Cancel;

                    inputForm.Controls.Add(lblTitle);
                    inputForm.Controls.Add(txtTitle);
                    inputForm.Controls.Add(lblGenre);
                    inputForm.Controls.Add(txtGenre);
                    inputForm.Controls.Add(lblYear);
                    inputForm.Controls.Add(txtYear);
                    inputForm.Controls.Add(btnOk);
                    inputForm.Controls.Add(btnCancel);

                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        // ������������� �������� �� ���������, ���� ���� ������
                        string title = string.IsNullOrEmpty(txtTitle.Text) ? "DOOM" : txtTitle.Text;
                        string genre = string.IsNullOrEmpty(txtGenre.Text) ? "Action" : txtGenre.Text;
                        int year = string.IsNullOrEmpty(txtYear.Text) ? 2002 : int.Parse(txtYear.Text);

                        string insertQuery = "INSERT INTO games (title, genre, release_year) VALUES (@title, @genre, @year)";
                        command = new NpgsqlCommand(insertQuery, connection);

                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@genre", genre);
                        command.Parameters.AddWithValue("@year", year);

                        int rowsAffected = command.ExecuteNonQuery();
                        richTextBox.AppendText($"\n��������� {rowsAffected} �������.");
                        // ������ �������������� ���������� ������
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������� ������: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // ������ �������� ������ (������� ��������� ����������� ������)
                string deleteQuery = "DELETE FROM games WHERE id = (SELECT MAX(id) FROM games)";
                command = new NpgsqlCommand(deleteQuery, connection);

                int rowsAffected = command.ExecuteNonQuery();
                richTextBox.AppendText($"\n������� {rowsAffected} �������.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ������: {ex.Message}");
            }
        }

        private void btnExecuteFunction_Click(object sender, EventArgs e)
        {
            if (listBoxFunctions.SelectedItem == null)
            {
                MessageBox.Show("�������� ������� �� ������");
                return;
            }

            try
            {
                string selectedFunction = listBoxFunctions.SelectedItem.ToString().Split('-')[0].Trim();

                switch (selectedFunction)
                {
                    case "insert_game":
                        InsertGameUsingFunction();
                        break;
                    case "delete_game_by_id":
                        DeleteGameByIdUsingFunction();
                        break;
                    case "get_all_games":
                        GetAllGamesUsingFunction();
                        btnExecute.Enabled = true;
                        btnView.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� �������: {ex.Message}");
            }
        }

        private void InsertGameUsingFunction()
        {
            using (Form inputForm = new Form())
            {
                inputForm.Text = "���������� ����� ����";
                inputForm.Size = new System.Drawing.Size(400, 250);
                inputForm.StartPosition = FormStartPosition.CenterParent;

                Label lblTitle = new Label() { Text = "��������:", Left = 20, Top = 20, Width = 100 };
                TextBox txtTitle = new TextBox() { Left = 130, Top = 20, Width = 230 };

                Label lblGenre = new Label() { Text = "����:", Left = 20, Top = 60, Width = 100 };
                TextBox txtGenre = new TextBox() { Left = 130, Top = 60, Width = 230 };

                Label lblYear = new Label() { Text = "��� �������:", Left = 20, Top = 100, Width = 100 };
                TextBox txtYear = new TextBox() { Left = 130, Top = 100, Width = 230 };

                Button btnOk = new Button() { Text = "��������", Left = 150, Top = 140, Width = 100, Height = 40 };
                btnOk.DialogResult = DialogResult.OK;

                Button btnCancel = new Button() { Text = "������", Left = 260, Top = 140, Width = 100, Height = 40 };
                btnCancel.DialogResult = DialogResult.Cancel;

                inputForm.Controls.AddRange(new Control[] { lblTitle, txtTitle, lblGenre, txtGenre, lblYear, txtYear, btnOk, btnCancel });

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new NpgsqlCommand("SELECT insert_game(@title, @genre, @year)", connection))
                    {
                        command.Parameters.AddWithValue("@title", string.IsNullOrEmpty(txtTitle.Text) ? (object)DBNull.Value : txtTitle.Text);
                        command.Parameters.AddWithValue("@genre", string.IsNullOrEmpty(txtGenre.Text) ? (object)DBNull.Value : txtGenre.Text);
                        command.Parameters.AddWithValue("@year", string.IsNullOrEmpty(txtYear.Text) ? (object)DBNull.Value : int.Parse(txtYear.Text));

                        int newId = (int)command.ExecuteScalar();
                        MessageBox.Show($"���� ��������� � ID: {newId}");
                    }
                }
            }
        }

        private void DeleteGameByIdUsingFunction()
        {
            using (Form inputForm = new Form())
            {
                inputForm.Text = "�������� ���� �� ID";
                inputForm.Size = new System.Drawing.Size(300, 150);
                inputForm.StartPosition = FormStartPosition.CenterParent;

                Label lblId = new Label() { Text = "������� ID ����:", Left = 20, Top = 20, Width = 150 };
                TextBox txtId = new TextBox() { Left = 170, Top = 20, Width = 80 };

                Button btnOk = new Button() { Text = "�������", Left = 100, Top = 60, Width = 80, Height = 40 };
                btnOk.DialogResult = DialogResult.OK;

                Button btnCancel = new Button() { Text = "������", Left = 190, Top = 60, Width = 80, Height = 40 };
                btnCancel.DialogResult = DialogResult.Cancel;

                inputForm.Controls.AddRange(new Control[] { lblId, txtId, btnOk, btnCancel });

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    if (int.TryParse(txtId.Text, out int id))
                    {
                        using (var command = new NpgsqlCommand("SELECT delete_game_by_id(@id)", connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            bool result = (bool)command.ExecuteScalar();

                            MessageBox.Show(result ? "���� ������� �������" : "���� � ��������� ID �� �������");
                        }
                    }
                    else
                    {
                        MessageBox.Show("����������, ������� ���������� ID (�����).");
                    }
                }
            }
        }

        private void GetAllGamesUsingFunction()
        {
            try
            {
                gamesDataTable.Rows.Clear();

                using (var command = new NpgsqlCommand("SELECT * FROM get_all_games()", connection))
                using (var reader = command.ExecuteReader())
                {
                    // ���������, ���� �� ������
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("� ������� ��� ������");
                        return;
                    }

                    while (reader.Read())
                    {
                        gamesDataTable.Rows.Add(
                            reader["id"],
                            reader["title"],
                            reader["genre"],
                            reader["release_year"]
                        );
                    }
                }

                // ��������� ����������� DataGridView
                dataGridView.Refresh();
                dataGridView.Visible = true;
                richTextBox.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ��������� ������: {ex.Message}\n\n�����������:\n{ex.StackTrace}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ������������� �����
        }
    }
}