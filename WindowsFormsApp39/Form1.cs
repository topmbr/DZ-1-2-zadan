using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp39
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=розсилка.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Створення таблиці для покупців
                string createCustomersTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Customers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        BirthDate DATE,
                        Gender TEXT,
                        Email TEXT,
                        Country TEXT,
                        City TEXT,
                        Interests TEXT
                    );
                ";

                // Створення таблиці для акційних товарів
                string createPromotionsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Promotions (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Section TEXT NOT NULL,
                        ProductName TEXT NOT NULL,
                        Country TEXT,
                        StartDate DATE,
                        EndDate DATE
                    );
                ";

                using (var command = new SQLiteCommand(createCustomersTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createPromotionsTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Таблиці створено успішно.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
