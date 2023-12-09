using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=розсилка.db;Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Підключено до бази даних.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Тут можна додати код для виконання операцій з базою даних

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка підключення до бази даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                        MessageBox.Show("Відключено від бази даних.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


    }
}
