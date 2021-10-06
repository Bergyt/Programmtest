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
    public partial class Form2 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = StudentDB.mdb";
        private OleDbConnection myConnection;
       
        public Form2()
        {

            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string Name = textBox2.Text;
            //string Surname = textBox3.Text;
            string Position = textBox4.Text;
            string query = "INSERT INTO Ученики ([№], ФИО, Оценка) VALUES (" + kod + ",'"+ Name + "','" + Position + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Ученик добавлен");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
