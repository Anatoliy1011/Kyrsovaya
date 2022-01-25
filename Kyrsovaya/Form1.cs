using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kyrsovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string selected_id_employee = textBox1.Text;
            connection.Open();
            string sql = $"SELECT fio_employee, post_employee FROM employees WHERE id_employee={selected_id_employee}";
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    listBox1.Items.Add("ФИО сотрудника: " + reader[0].ToString());
                    listBox1.Items.Add("Должность: " + reader[1].ToString());
                    listBox1.Items.Add("----------------------------------------------------------------------------------------------------");
                    textBox2.Text = reader[0].ToString();
                    textBox3.Text = reader[1].ToString();
                    reader.Close();
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show($"Данные о сотруднике с ID {selected_id_employee} отсутствуют.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show($"Заполните поле ID!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
