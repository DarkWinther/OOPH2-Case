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
        Kunde valgteKunde;
        Konto valgteKonto;

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
            Hide(label13, label14, label15, label16, label17, label18);
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
            adapter = valgteKunde.KontiList();
            table.Clear();
            table.Columns.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoResizeColumns();
            button13.Enabled = true;
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
            //adapter = SQLAPI.Read("* FROM Transaktion WHERE KontoNr = ")
        }

        //Vælg al tekst i comboBox1
        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.SelectAll();
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (String.IsNullOrWhiteSpace(textBox6.Text))
                        return;
                    string searchVal = textBox6.Text.Split('|').Last();
                    searchVal = searchVal.Trim();
                    if (String.IsNullOrEmpty(searchVal))
                    {
                        int n;
                        if (Int32.TryParse(textBox6.Text, out n))
                            searchVal = textBox6.Text;
                        else throw new FormatException("Kundenummeret kunne ikke læses");
                    }
                    adapter = SQLAPI.Read("* FROM Kunde, PostNr WHERE Kunde.PostNr = PostNr.PostNr AND KundeNr LIKE '" + searchVal + "'");
                    table.Clear();
                    adapter.Fill(table);
                    if (table.Rows.Count != 1)
                    {
                        throw new KeyNotFoundException("Kunne ikke finde kundenummeret for den specificerede kunde");
                    }
                    else
                    {
                        valgteKunde = new Kunde((int)table.Rows[0]["KundeNr"], table.Rows[0]["Fornavn"].ToString(),
                            table.Rows[0]["Efternavn"].ToString());
                        valgteKunde.postNr = (int)table.Rows[0]["PostNr"];
                        valgteKunde.adresse = table.Rows[0]["Adresse"].ToString();
                        valgteKunde.byNavn = table.Rows[0]["Bynavn"].ToString();
                        valgteKunde.oprettelsesdato = ConvertORD(table.Rows[0]["Oprettelsesdato"].ToString());
                        if (!String.IsNullOrEmpty(table.Rows[0]["TlfNr"].ToString()))
                            valgteKunde.tlfNr = Int32.Parse(table.Rows[0]["TlfNr"].ToString());
                    }
                    label13.Text = valgteKunde.kundeNr.ToString();
                    label14.Text = valgteKunde.fornavn + " " + valgteKunde.efternavn;
                    label15.Text = valgteKunde.adresse;
                    label16.Text = valgteKunde.postNr + " " + valgteKunde.byNavn;
                    label17.Text = valgteKunde.tlfNr == 0 ? "N/A" : valgteKunde.tlfNr.ToString();
                    adapter = SQLAPI.Read("Sum(Saldo) FROM Konto WHERE KundeNr = " + valgteKunde.kundeNr);
                    table.Clear();
                    table.Columns.Clear();
                    adapter.Fill(table);
                    label18.Text = table.Rows[0][0].ToString();
                    Show(label13, label14, label15, label16, label17, label18);
                    button8.Enabled = true;
                }
            }
            catch (Exception exc)
            {
                table.Clear();
                textBox6.Clear();
                MessageBox.Show("Error!\n\n" + exc.Message);
            }
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

        private void Hide(params Control[] things)
        {
            foreach (var item in things)
            {
                item.Visible = false;
            }
        }

        private DateTime ConvertORD(string oprettelsesdato)
        {
            string[] temp = oprettelsesdato.Split();
            int day = Int32.Parse(temp[0].Split('/')[0]);
            int month = Int32.Parse(temp[0].Split('/')[1]);
            int year = Int32.Parse(temp[0].Split('/')[2]);
            int hour = Int32.Parse(temp[1].Split(':')[0]);
            int minute = Int32.Parse(temp[1].Split(':')[1]);
            int second = Int32.Parse(temp[1].Split(':')[2]);
            return new DateTime(year, month, day, hour, minute, second);
            
        }
    }
}
