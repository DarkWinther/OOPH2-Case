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
        private enum PanelState { Empty, OpretKunde, FjernKunde, OpretKonto, FjernKonto, HævBeløb, IndsætBeløb }
        private SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Kunde;", SQLAPI.connection);
        private DataTable table = new DataTable();
        private PanelState ps = PanelState.Empty;

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

        //Submit
        private void button1_Click(object sender, EventArgs e)
        {
            switch (ps)
            {
                case PanelState.OpretKunde:
                    break;
                case PanelState.FjernKunde:
                    break;
                case PanelState.OpretKonto:
                    break;
                case PanelState.FjernKonto:
                    break;
                case PanelState.HævBeløb:
                    break;
                case PanelState.IndsætBeløb:
                    break;
                default:
                    break;
            }
        }

        //Opret Kunde
        private void button5_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, label2, label3, label4, label5, textBox1, textBox2, textBox3, textBox4, textBox5, button1);
            label1.Text = "Fornavn";
            label2.Text = "Efternavn";
            label3.Text = "Adresse";
            label4.Text = "Post nummer";
            label5.Text = "Telefon nummer";
            button1.Text = "Tilføj kunde";
            ps = PanelState.OpretKunde;
        }

        //Fjern Kunde
        private void button6_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, textBox1, button1);
            label1.Text = "KundeNr";
            button1.Text = "Fjern Kunde";
            ps = PanelState.FjernKunde;
        }

        //Vis konto
        private void button8_Click(object sender, EventArgs e)
        {

        }

        //Opret konto
        private void button9_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, label2, textBox1, comboBox2, button1);
            label1.Text = "KundeNr";
            label2.Text = "KontoType";
            button1.Text = "Tilføj Konto";
            comboBox2.Location = textBox2.Location;
            ps = PanelState.OpretKonto;
        }

        //Fjern Konto
        private void button10_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, textBox1, button1);
            button1.Text = "Fjern Konto";
            label1.Text = "KontoNr";
            ps = PanelState.FjernKonto;
        }

        //Hæv beløb
        private void button11_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, label2, textBox1, textBox2, button1);
            button1.Text = "Hæv beløb";
            label1.Text = "KontoNr";
            label2.Text = "Beløb";
            ps = PanelState.HævBeløb;
        }

        //Indsæt beløb
        private void button12_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, label2, textBox1, textBox2, button1);
            button1.Text = "Indsæt beløb";
            label1.Text = "KontoNr";
            label2.Text = "Beløb";
            ps = PanelState.IndsætBeløb;
        }

        //Udskriv transaktioner
        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void HideAll()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Visible = false;
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
