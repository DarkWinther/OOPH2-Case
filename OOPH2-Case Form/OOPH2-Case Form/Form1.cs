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
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();
        private PanelState ps = PanelState.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adapter = SQLAPI.Read("CONCAT(Fornavn, ' ', Efternavn, ' | ', KundeNr) AS Navn FROM Kunde;");
            adapter.Fill(table);
            AutoCompleteStringCollection strColl = new AutoCompleteStringCollection();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                strColl.Add(table.Rows[i][0].ToString());
            }
            textBox6.AutoCompleteCustomSource = strColl;
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

        //Update kundeinfo
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //Vælg al tekst i comboBox1
        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.SelectAll();
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

        private DateTime ConvertORD(string oprettelsesdato)
        {
            int day, month, year, hour, minute, second;
            string[] temp = oprettelsesdato.Split();
            day = Int32.Parse(temp[0].Split('/')[0]);
            month = Int32.Parse(temp[0].Split('/')[1]);
            year = Int32.Parse(temp[0].Split('/')[2]);
            hour = Int32.Parse(temp[1].Split(':')[0]);
            minute = Int32.Parse(temp[1].Split(':')[1]);
            second = Int32.Parse(temp[1].Split(':')[2]);
            DateTime ny = new DateTime(year, month, day, hour, minute, second);
            return ny;
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchVal = textBox6.Text.Split('|').Last();
                searchVal = searchVal.Substring(1);
                adapter = SQLAPI.Read("* FROM Kunde WHERE KundeNr LIKE '%" + searchVal + "'");
                table.Clear();
                adapter.Fill(table);
                if (table.Rows.Count != 1)
                {
                    MessageBox.Show(table.Rows.Count.ToString());
                    throw new KeyNotFoundException("Kunne ikke finde kundenummeret for den specificerede kunde");
                }
                else
                {
                    Kunde nyKunde = new Kunde((int)table.Rows[0]["KundeNr"], table.Rows[0]["Fornavn"].ToString(),
                        table.Rows[0]["Efternavn"].ToString());
                    nyKunde.postNr = (int)table.Rows[0]["PostNr"];
                    nyKunde.adresse = table.Rows[0]["Adresse"].ToString();
                    nyKunde.oprettelsesdato = ConvertORD(table.Rows[0]["Oprettelsesdato"].ToString());
                }
            }
        }
    }
}
