using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MyAPP
{
    public partial class Form3 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = StudentDB.mdb";
        private OleDbConnection myConnection;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentDBDataSet.Тема". При необходимости она может быть перемещена или удалена.
            this.темаTableAdapter.Fill(this.studentDBDataSet.Тема);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Owner = this;
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox4.Text);
            string query = "DELETE FROM Тема WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данная тема удалена");
            this.темаTableAdapter.Fill(this.studentDBDataSet.Тема);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.темаTableAdapter.Fill(this.studentDBDataSet.Тема);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE тема SET Тема ='" + textBox5.Text + "' Дата = '" + dateTimePicker1.Text + "' WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Изменение добавлены");
            this.темаTableAdapter.Fill(this.studentDBDataSet.Тема);
        }
    }
}
