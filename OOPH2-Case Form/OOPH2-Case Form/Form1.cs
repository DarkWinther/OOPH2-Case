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
        private SqlDataAdapter adapter = new SqlDataAdapter("SELECT Fornavn FROM Kunde;", SQLAPI.connection);
        private DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Fornavn";
        }

        //Opret Kunde
        private void button5_Click(object sender, EventArgs e)
        {
            Show(label1, label2, label3, label4, label5, textBox1, textBox2, textBox3, textBox4, textBox5, button1);
            Hide(comboBox2);
            label1.Text = "Fornavn";
            label2.Text = "Efternavn";
            label3.Text = "Adresse";
            label4.Text = "Post nummer";
            label5.Text = "Telefon nummer";
            button1.Text = "Tilføj kunde";
        }

        //Fjern Kunde
        private void button6_Click(object sender, EventArgs e)
        {
            Show(label1, textBox1, button1);
            Hide(label2, label3, label4, label5, textBox2, textBox3, textBox4, textBox5, comboBox2);
            label1.Text = "KundeNr";
            button1.Text = "Fjern Kunde";
        }

        //Opret konto
        private void button9_Click(object sender, EventArgs e)
        {
            Show(label1, label2, textBox1, comboBox2, button1);
            Hide(label3, label4, label5, textBox2, textBox3, textBox4, textBox5);
            label1.Text = "KundeNr";
            label2.Text = "KontoType";
            button1.Text = "Tilføj Konto";
            comboBox2.Location = textBox2.Location;
        }

        //Fjern Konto
        private void button10_Click(object sender, EventArgs e)
        {
            Hide(label2, label3, label4, label5, textBox2, textBox3, textBox4, textBox5, comboBox2);
            Show(label1, textBox1, button1);
            button1.Text = "Fjern Konto";
            label1.Text = "KontoNr";
        }

        //Hæv beløb
        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void Hide(params Control[] things)
        {
            foreach (var item in things)
            {
                item.Visible = false;
            }
        }

        private void Show(params Control[] things)
        {
            foreach (var item in things)
            {
                item.Visible = true;
            }
        }
    }
}
