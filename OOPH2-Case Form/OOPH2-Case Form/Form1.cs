using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOPH2_Case_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Fornavn FROM Kunde;", SQLAPI.connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Fornavn";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLAPI.Create("Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) Values('Kevin', 'Winther', 2820, 'Ermelundsvej', CAST('2012-06-05 12:00' AS smalldatetime))");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLAPI.Delete("Kunde WHERE KundeNr = 1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLAPI.Update("Kunde SET TlfNr = 88888888 WHERE KundeNr = 2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLAPI.Read("* FROM Kunde");
        }
    }
}
