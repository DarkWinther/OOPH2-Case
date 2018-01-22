﻿using System;
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
        private enum PanelState { Empty, OpretKunde, OpretKonto, HævBeløb, IndsætBeløb }
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();
        private PanelState ps = PanelState.Empty;
        Kunde valgteKunde;
        Kunde nyKunde;
        Konto valgteKonto;
        Konto nyKonto;

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            adapter = SQLAPI.Read("CONCAT(Fornavn, ' ', Efternavn, ' | ', KundeNr) AS Navn FROM Kunde;");
            adapter.Fill(table);
            AutoCompleteStringCollection strColl = new AutoCompleteStringCollection();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                strColl.Add(table.Rows[i][0].ToString());
            }
            SøgKunde_text.AutoCompleteCustomSource = strColl;
            Hide(label13, label14, label15, label16, label17, label18, label19, SamletBeløb_label);
        }

        /// <summary>
        /// Submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            switch (ps)
            {
                case PanelState.OpretKunde:
                    // TODO: Create the object
                    nyKunde = new Kunde();
                    nyKunde.OpretKunde();
                    break;
                case PanelState.OpretKonto:
                    // TODO: Create the object
                    nyKonto = new Konto();
                    nyKonto.OpretKonto();
                    break;
                case PanelState.HævBeløb:
                    try
                    {
                        valgteKonto.Udbetaling(Convert.ToInt32(textBox2.Text));
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error!\n\n" + exc.Message);
                    }
                    break;
                case PanelState.IndsætBeløb:
                    try
                    {
                        valgteKonto.Indbetaling(Convert.ToInt32(textBox2.Text));
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error!\n\n" + exc.Message);
                    }
                    break;
                default:
                    MessageBox.Show("Error!\n\nDette skulle ikke ske!");
                    break;
            }
            Clear(textBox1, textBox2, textBox3, textBox4, textBox5);
            comboBox2.ResetText();
        }

        /// <summary>
        /// Opret Kunde button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, label2, label3, label4, label5, textBox1, textBox2, textBox3, textBox4, textBox5, Submit_btn);
            label1.Text = "Fornavn";
            label2.Text = "Efternavn";
            label3.Text = "Adresse";
            label4.Text = "Post nummer";
            label5.Text = "Telefon nummer";
            Submit_btn.Text = "Tilføj kunde";
            ps = PanelState.OpretKunde;
        }

        /// <summary>
        /// Fjern Kunde button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (valgteKunde == null)
            {
                MessageBox.Show("Error!\n\nDu har ikke valgt en kunde!");
                return;
            }
            valgteKunde.FjernKunde();
            MessageBox.Show("Den valgte kunde blev fjernet!");
        }

        /// <summary>
        /// Vis konto button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            adapter = valgteKunde.KontiList();
            table.Clear();
            table.Columns.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoResizeColumns();
            UdskrivTrans_btn.Enabled = true;
        }

        /// <summary>
        /// Opret konto button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, label2, textBox1, comboBox2, Submit_btn);
            label1.Text = "KundeNr";
            label2.Text = "KontoType";
            Submit_btn.Text = "Tilføj Konto";
            comboBox2.Location = textBox2.Location;
            ps = PanelState.OpretKonto;
        }

        /// <summary>
        /// Fjern Konto button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            if (valgteKonto == null)
            {
                MessageBox.Show("Error!\n\nDu har ikke valgt en konto!");
                return;
            }
            valgteKonto.FjernKonto();
            MessageBox.Show("Den valgte konto blev fjernet!");
        }

        /// <summary>
        /// Hæv beløb button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, label2, textBox1, textBox2, Submit_btn);
            Submit_btn.Text = "Hæv beløb";
            label1.Text = "KontoNr";
            label2.Text = "Beløb";
            ps = PanelState.HævBeløb;
        }

        /// <summary>
        /// Indsæt beløb button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            HideAll();
            Show(label1, label2, textBox1, textBox2, Submit_btn);
            Submit_btn.Text = "Indsæt beløb";
            label1.Text = "KontoNr";
            label2.Text = "Beløb";
            ps = PanelState.IndsætBeløb;
        }

        /// <summary>
        /// Udskriv transaktioner button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            //adapter = SQLAPI.Read("* FROM Transaktion WHERE KontoNr = ")
        }

        /// <summary>
        /// Vælg al tekst i comboBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_Enter(object sender, EventArgs e)
        {
            SøgKunde_text.SelectAll();
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (String.IsNullOrWhiteSpace(SøgKunde_text.Text))
                        return;

                    string searchVal = SøgKunde_text.Text.Split('|').Last();
                    searchVal = searchVal.Trim();
                    if (String.IsNullOrEmpty(searchVal))
                    {
                        if (Int32.TryParse(SøgKunde_text.Text, out int n))
                            searchVal = SøgKunde_text.Text;
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
                            table.Rows[0]["Efternavn"].ToString())
                       {
                            postNr = (int)table.Rows[0]["PostNr"],
                            adresse = table.Rows[0]["Adresse"].ToString(),
                            byNavn = table.Rows[0]["Bynavn"].ToString(),
                            oprettelsesdato = DateTime.Parse(table.Rows[0]["Oprettelsesdato"].ToString())
                        };
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
                    SamletBeløb_label.Text = table.Rows[0][0].ToString();
                    Show(label13, label14, label15, label16, label17, SamletBeløb_label);
                    VisKonto_btn.Enabled = true;
                }
            }
            catch (Exception exc)
            {
                table.Clear();
                SøgKunde_text.Clear();
                MessageBox.Show("Error!\n\n" + exc.Message);
            }
        }

        private void SøgKonto_text_KeyUp(object sender, KeyEventArgs e)
        {
            // TODO: Create the søg konto method.
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(SøgKonto_text.Text))
                        return;

                    string kontoSearch = SøgKonto_text.Text;

                    adapter = SQLAPI.Read("* FROM Konto WHERE KontoNr LIKE '" + kontoSearch + "'");
                    table.Clear();
                    adapter.Fill(table);
                    if (table.Rows.Count != 1)
                    {
                        throw new KeyNotFoundException("Kontonummeret eksister ikke!");
                    }
                    else
                    {
                        valgteKonto = new Konto((int)table.Rows[0]["KontoNr"], (int)table.Rows[0]["KundeNr"]);
                    }

                    label18.Text = valgteKonto.kontoNr.ToString();
                    label19.Text = valgteKonto.kundeNr.ToString();
                    table.Clear();
                    table.Columns.Clear();
                    Show(label18, label19);

                }
            }
            catch (Exception exc)
            {
                table.Clear();
                SøgKonto_text.Clear();
                MessageBox.Show("Error!\n\n" + exc.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txt"></param>
        private void Clear(params TextBox[] txt)
        {
            foreach (var item in txt)
            {
                item.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HideAll()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Visible = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="things"></param>
        private void Show(params Control[] things)
        {
            foreach (var item in things)
            {
                item.Visible = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="things"></param>
        private void Hide(params Control[] things)
        {
            foreach (var item in things)
            {
                item.Visible = false;
            }
        }
    }
}
