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
    
    public partial class Form1 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = StudentDB.mdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentDBDataSet.Ученики". При необходимости она может быть перемещена или удалена.
            this.ученикиTableAdapter.Fill(this.studentDBDataSet.Ученики);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentDBDataSet.Тема". При необходимости она может быть перемещена или удалена.
            this.темаTableAdapter.Fill(this.studentDBDataSet.Тема);
           

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Ученики WHERE [№] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данный ученик удален");
             this.ученикиTableAdapter.Fill(this.studentDBDataSet.Ученики);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Ученики SET Оценка ='" + textBox3.Text + "' WHERE [№] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Изменение добавлены");
             this.ученикиTableAdapter.Fill(this.studentDBDataSet.Ученики);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ученикиTableAdapter.Fill(this.studentDBDataSet.Ученики);
        }

        

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.ученикиTableAdapter.Fill(this.studentDBDataSet.Ученики);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Owner = this;
            f3.Show();
        }
    }
}
