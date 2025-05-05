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
            // Скрываем элементы по умолчанию
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

            // Устанавливаем значения по умолчанию
            txtHost.Text = "localhost";
            txtPort.Text = "5432";
            txtDatabase.Text = "Sharpes_labs";
            txtUsername.Text = "postgres";
            txtPassword.Text = "12345";


            gamesDataTable = new DataTable();
            gamesDataTable.Columns.Add("ID", typeof(int));
            gamesDataTable.Columns.Add("Название", typeof(string));
            gamesDataTable.Columns.Add("Жанр", typeof(string));
            gamesDataTable.Columns.Add("Год выпуска", typeof(int));

            // Настройка DataGridView
            dataGridView.DataSource = gamesDataTable;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Visible = false;

            // Настройка ListBox для функций
            listBoxFunctions.Items.Add("insert_game - Добавить игру");
            listBoxFunctions.Items.Add("delete_game_by_id - Удалить игру по ID");
            listBoxFunctions.Items.Add("get_all_games - Получить все игры");
            listBoxFunctions.Visible = false;
            lblStatus.Text = "Соединение не инициализировано";
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            // Показываем TextBox'ы для ввода параметров соединения
            txtHost.Visible = true;
            txtPort.Visible = true;
            txtDatabase.Visible = true;
            txtUsername.Visible = true;
            txtPassword.Visible = true;

            // Показываем кнопки открытия/закрытия соединения
            btnOpen.Visible = true;
            btnClose.Visible = true;

            // Инициализируем соединение
            string connectionString = $"Host={txtHost.Text};Port={txtPort.Text};Database={txtDatabase.Text};Username={txtUsername.Text};Password={txtPassword.Text}";
            connection = new NpgsqlConnection(connectionString);

            lblStatus.Text = "Соединение инициализировано, но не открыто";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    lblStatus.Text = "Соединение открыто";

                    // Показываем кнопку выполнения команды
                    btnExecute.Visible = true;

                    // Показываем элементы для работы с данными
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
                    lblStatus.Text = "Соединение уже открыто";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии соединения: {ex.Message}");
                lblStatus.Text = "Ошибка соединения";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    lblStatus.Text = "Соединение закрыто";

                    // Скрываем кнопку выполнения команды
                    btnExecute.Visible = false;

                    // Скрываем элементы для работы с данными
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
                    lblStatus.Text = "Соединение уже закрыто";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при закрытии соединения: {ex.Message}");
                lblStatus.Text = "Ошибка при закрытии соединения";
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                // Очищаем RichTextBox и показываем его
                richTextBox.Clear();
                richTextBox.Visible = true;
                dataGridView.Visible = false;

                using (var command = new NpgsqlCommand("SELECT * FROM games", connection))
                using (var reader = command.ExecuteReader())
                {
                    richTextBox.AppendText("Содержимое таблицы games:\n\n");
                    while (reader.Read())
                    {
                        richTextBox.AppendText($"ID: {reader["id"]}, Название: {reader["title"]}, Жанр: {reader["genre"]}, Год выпуска: {reader["release_year"]}\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
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
                richTextBox.AppendText("Содержимое таблицы games:\n\n");

                while (reader.Read())
                {
                    richTextBox.AppendText($"ID: {reader["id"]}, Название: {reader["title"]}, Жанр: {reader["genre"]}, Год выпуска: {reader["release_year"]}\n");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при просмотре данных: {ex.Message}");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем форму для ввода данных
                using (Form inputForm = new Form())
                {
                    inputForm.Text = "Добавление новой игры";
                    inputForm.Size = new System.Drawing.Size(400, 250); // Увеличили размер окна
                    inputForm.StartPosition = FormStartPosition.CenterParent;

                    Label lblTitle = new Label() { Text = "Название:", Left = 20, Top = 20, Width = 100 };
                    TextBox txtTitle = new TextBox() { Left = 130, Top = 20, Width = 230 };

                    Label lblGenre = new Label() { Text = "Жанр:", Left = 20, Top = 60, Width = 100 };
                    TextBox txtGenre = new TextBox() { Left = 130, Top = 60, Width = 230 };

                    Label lblYear = new Label() { Text = "Год выпуска:", Left = 20, Top = 100, Width = 100 };
                    TextBox txtYear = new TextBox() { Left = 130, Top = 100, Width = 230 };

                    Button btnOk = new Button() { Text = "Добавить", Left = 150, Top = 140, Width = 100, Height = 40};
                    btnOk.DialogResult = DialogResult.OK;

                    Button btnCancel = new Button() { Text = "Отмена", Left = 260, Top = 140, Width = 100, Height = 40 };
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
                        // Устанавливаем значения по умолчанию, если поля пустые
                        string title = string.IsNullOrEmpty(txtTitle.Text) ? "DOOM" : txtTitle.Text;
                        string genre = string.IsNullOrEmpty(txtGenre.Text) ? "Action" : txtGenre.Text;
                        int year = string.IsNullOrEmpty(txtYear.Text) ? 2002 : int.Parse(txtYear.Text);

                        string insertQuery = "INSERT INTO games (title, genre, release_year) VALUES (@title, @genre, @year)";
                        command = new NpgsqlCommand(insertQuery, connection);

                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@genre", genre);
                        command.Parameters.AddWithValue("@year", year);

                        int rowsAffected = command.ExecuteNonQuery();
                        richTextBox.AppendText($"\nДобавлено {rowsAffected} записей.");
                        // Убрали автоматическое обновление списка
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вставке данных: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Пример удаления записи (удаляем последнюю добавленную запись)
                string deleteQuery = "DELETE FROM games WHERE id = (SELECT MAX(id) FROM games)";
                command = new NpgsqlCommand(deleteQuery, connection);

                int rowsAffected = command.ExecuteNonQuery();
                richTextBox.AppendText($"\nУдалено {rowsAffected} записей.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении данных: {ex.Message}");
            }
        }

        private void btnExecuteFunction_Click(object sender, EventArgs e)
        {
            if (listBoxFunctions.SelectedItem == null)
            {
                MessageBox.Show("Выберите функцию из списка");
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
                MessageBox.Show($"Ошибка при выполнении функции: {ex.Message}");
            }
        }

        private void InsertGameUsingFunction()
        {
            using (Form inputForm = new Form())
            {
                inputForm.Text = "Добавление новой игры";
                inputForm.Size = new System.Drawing.Size(400, 250);
                inputForm.StartPosition = FormStartPosition.CenterParent;

                Label lblTitle = new Label() { Text = "Название:", Left = 20, Top = 20, Width = 100 };
                TextBox txtTitle = new TextBox() { Left = 130, Top = 20, Width = 230 };

                Label lblGenre = new Label() { Text = "Жанр:", Left = 20, Top = 60, Width = 100 };
                TextBox txtGenre = new TextBox() { Left = 130, Top = 60, Width = 230 };

                Label lblYear = new Label() { Text = "Год выпуска:", Left = 20, Top = 100, Width = 100 };
                TextBox txtYear = new TextBox() { Left = 130, Top = 100, Width = 230 };

                Button btnOk = new Button() { Text = "Добавить", Left = 150, Top = 140, Width = 100, Height = 40 };
                btnOk.DialogResult = DialogResult.OK;

                Button btnCancel = new Button() { Text = "Отмена", Left = 260, Top = 140, Width = 100, Height = 40 };
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
                        MessageBox.Show($"Игра добавлена с ID: {newId}");
                    }
                }
            }
        }

        private void DeleteGameByIdUsingFunction()
        {
            using (Form inputForm = new Form())
            {
                inputForm.Text = "Удаление игры по ID";
                inputForm.Size = new System.Drawing.Size(300, 150);
                inputForm.StartPosition = FormStartPosition.CenterParent;

                Label lblId = new Label() { Text = "Введите ID игры:", Left = 20, Top = 20, Width = 150 };
                TextBox txtId = new TextBox() { Left = 170, Top = 20, Width = 80 };

                Button btnOk = new Button() { Text = "Удалить", Left = 100, Top = 60, Width = 80, Height = 40 };
                btnOk.DialogResult = DialogResult.OK;

                Button btnCancel = new Button() { Text = "Отмена", Left = 190, Top = 60, Width = 80, Height = 40 };
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

                            MessageBox.Show(result ? "Игра успешно удалена" : "Игра с указанным ID не найдена");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите корректный ID (число).");
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
                    // Проверяем, есть ли данные
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("В таблице нет данных");
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

                // Обновляем отображение DataGridView
                dataGridView.Refresh();
                dataGridView.Visible = true;
                richTextBox.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных: {ex.Message}\n\nПодробности:\n{ex.StackTrace}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация формы
        }
    }
}