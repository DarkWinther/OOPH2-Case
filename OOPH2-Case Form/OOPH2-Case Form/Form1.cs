﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        /// Initialize all components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Do this when the form loads
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
            table.Clear();
            table.Columns.Clear();
        }

        /// <summary>
        /// Submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
                return;
            switch (ps)
            {
                case PanelState.OpretKunde:
                    if (String.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        MessageBox.Show("Indtast venligst et efternavn.");
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        MessageBox.Show("Indtast venligst en adresse.");
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        MessageBox.Show("Indtast venligst et postnummer.");
                        return;
                    }
                    int post, tlf;
                    Int32.TryParse(textBox4.Text, out post);
                    Int32.TryParse(textBox5.Text, out tlf);
                    nyKunde = new Kunde()
                    {
                        fornavn = textBox1.Text,
                        efternavn = textBox2.Text,
                        adresse = textBox3.Text,
                        postNr = post,
                        tlfNr = tlf
                    };
                    nyKunde.OpretKunde();
                    break;
                case PanelState.OpretKonto:
                    if (String.IsNullOrWhiteSpace(comboBox2.Text))
                    {
                        MessageBox.Show("Vælg venligst en kontotype.");
                        return;
                    }
                    int kunde;
                    Int32.TryParse(textBox1.Text, out kunde);
                    nyKonto = new Konto()
                    {
                        typeNr = comboBox2.SelectedIndex + 1,
                        kundeNr = kunde
                    };
                    nyKonto.OpretKonto();
                    break;
                case PanelState.HævBeløb:
                    try
                    {
                        valgteKonto.Udbetaling(Convert.ToDouble(textBox1.Text));
                        UpdateSBL();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error!\n\nDer er sket en fejl, hvis dette forsætter så kontakt IT-Support!");
                    }
                    break;
                case PanelState.IndsætBeløb:
                    try
                    {
                        valgteKonto.Indbetaling(Convert.ToDouble(textBox1.Text));
                        UpdateSBL();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error!\n\nDer er sket en fejl, hvis dette forsætter så kontakt IT-Support!");
                    }
                    break;
                default:
                    MessageBox.Show("Error!\n\nDer er sket en fejl, dette skulle ikke kunne ske så kontakt IT-Support med det samme!");
                    break;
            }
            table.Clear();
            table.Columns.Clear();
            Form1_Load(sender, e);
            Clear(textBox1, textBox2, textBox3, textBox4, textBox5);
            comboBox2.ResetText();
            if (ps == PanelState.HævBeløb || ps == PanelState.IndsætBeløb)
                SamletBeløb_label.Visible = true;
        }

        /// <summary>
        /// Opret Kunde button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.KeyPress -= new KeyPressEventHandler(NumbersOnly);
            textBox1.KeyPress -= new KeyPressEventHandler(textBox5_KeyPress);
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
            table.Clear();
            table.Columns.Clear();
            Form1_Load(sender, e);
            VisKonto_btn.Enabled = false;
            FjernKunde_btn.Enabled = false;
            Hide(label13, label14, label15, label16, label17, SamletBeløb_label);
            if (ps == PanelState.HævBeløb || ps == PanelState.IndsætBeløb)
                Hide(textBox1, textBox2, label1, label2, Submit_btn, SamletBeløb_label);
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
        }

        /// <summary>
        /// Opret konto button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.KeyPress -= new KeyPressEventHandler(NumbersOnly);
            textBox1.KeyPress += new KeyPressEventHandler(textBox5_KeyPress);
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
            table.Clear();
            table.Columns.Clear();
            Hide(label18, label19);
            Indsæt_btn.Enabled = false;
            Hæv_btn.Enabled = false;
            FjernKonto_btn.Enabled = false;
            UdskrivTrans_btn.Enabled = false;
            if (ps == PanelState.HævBeløb || ps == PanelState.IndsætBeløb)
                Hide(textBox1, textBox2, label1, label2, Submit_btn, SamletBeløb_label);
        }

        /// <summary>
        /// Hæv beløb button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.KeyPress -= new KeyPressEventHandler(textBox5_KeyPress);
            textBox1.KeyPress += new KeyPressEventHandler(NumbersOnly);
            HideAll();
            Show(label1, textBox1, Submit_btn);
            Submit_btn.Text = "Hæv beløb";
            label1.Text = "Beløb";
            ps = PanelState.HævBeløb;
        }

        /// <summary>
        /// Indsæt beløb button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.KeyPress -= new KeyPressEventHandler(textBox5_KeyPress);
            textBox1.KeyPress += new KeyPressEventHandler(NumbersOnly);
            HideAll();
            Show(label1, textBox1, Submit_btn);
            Submit_btn.Text = "Indsæt beløb";
            label1.Text = "Beløb";
            ps = PanelState.IndsætBeløb;
        }

        /// <summary>
        /// Udskriv transaktioner button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            adapter = valgteKonto.ListTransaktioner();
            table.Clear();
            table.Columns.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        /// <summary>
        /// Vælg alt tekst i comboBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_Enter(object sender, EventArgs e)
        {
            SøgKunde_text.SelectAll();
        }

        /// <summary>
        /// Vælg en kunde fra databasen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        table.Columns.Clear();
                        throw new KeyNotFoundException("Kunne ikke finde kundenummeret for den specificerede kunde");
                    }
                    else
                    {
                        valgteKunde = new Kunde((int)table.Rows[0]["KundeNr"], table.Rows[0]["Fornavn"].ToString().Trim(),
                            table.Rows[0]["Efternavn"].ToString().Trim())
                       {
                            postNr = (int)table.Rows[0]["PostNr"],
                            adresse = table.Rows[0]["Adresse"].ToString().Trim(),
                            byNavn = table.Rows[0]["Bynavn"].ToString().Trim(),
                            oprettelsesdato = DateTime.Parse(table.Rows[0]["Oprettelsesdato"].ToString())
                        };
                        if (!String.IsNullOrEmpty(table.Rows[0]["TlfNr"].ToString()))
                            valgteKunde.tlfNr = Int32.Parse(table.Rows[0]["TlfNr"].ToString().Trim());
                    }
                    label13.Text = valgteKunde.kundeNr.ToString();
                    label14.Text = valgteKunde.fornavn + " " + valgteKunde.efternavn;
                    label15.Text = valgteKunde.adresse;
                    label16.Text = valgteKunde.postNr + " " + valgteKunde.byNavn;
                    label17.Text = valgteKunde.tlfNr == 0 ? "N/A" : valgteKunde.tlfNr.ToString();
                    UpdateSBL();
                    Show(label13, label14, label15, label16, label17, SamletBeløb_label);
                    VisKonto_btn.Enabled = true;
                    FjernKunde_btn.Enabled = true;
                }
            }
            catch (Exception)
            {
                table.Clear();
                SøgKunde_text.Clear();
                MessageBox.Show("Error!\n\nDer er sket en fejl, hvis dette forsætter så kontakt IT-Support!");
            }
        }

        /// <summary>
        /// Vælg en konto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SøgKonto_text_KeyUp(object sender, KeyEventArgs e)
        {
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
                        table.Columns.Clear();
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
                    Indsæt_btn.Enabled = true;
                    Hæv_btn.Enabled = true;
                    FjernKonto_btn.Enabled = true;
                    UdskrivTrans_btn.Enabled = true;
                }
            }
            catch (Exception)
            {
                table.Clear();
                SøgKonto_text.Clear();
                MessageBox.Show("Error!\n\nDer er sket en fejl, hvis dette forsætter så kontakt IT-Support!");
            }
        }

        /// <summary>
        /// Vis kundeoversigt button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kundeoversigt_btn_Click(object sender, EventArgs e)
        {
            adapter = SQLAPI.Read("* FROM Kunde");
            table.Clear();
            table.Columns.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoResizeColumns();
        }

        /// <summary>
        /// Sætter værdierne i dropdown menuen for kontotyper når man skal skabe en konto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            adapter = SQLAPI.Read("TypeNavn FROM KontoType");
            table.Clear();
            table.Columns.Clear();
            adapter.Fill(table);
            List<string> typeliste = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                typeliste.Add(row[0].ToString());
            }
            comboBox2.DataSource = typeliste;
            table.Clear();
            table.Columns.Clear();
        }

        /// <summary>
        /// Opdaterer SamletBeløb_label med den samlede saldo fra serveren.
        /// </summary>
        private void UpdateSBL()
        {
            adapter = SQLAPI.Read("Sum(Saldo) FROM Konto WHERE KundeNr = " + valgteKunde.kundeNr);
            table.Clear();
            table.Columns.Clear();
            adapter.Fill(table);
            SamletBeløb_label.Text = String.IsNullOrWhiteSpace(table.Rows[0][0].ToString()) ? "0.00" : String.Format("{0:N2}", Convert.ToDouble(table.Rows[0][0].ToString()));
            table.Clear();
            table.Columns.Clear();
        }

        /// <summary>
        /// Only allow numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Only allow numbers and period
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.KeyChar = '.';
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Clear panels method
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
        /// Hideall method used to hide things we dont want the user to see
        /// </summary>
        private void HideAll()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Visible = false;
            }
        }

        /// <summary>
        /// Show method used to unhide things so the user can see them
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
        /// Hide method used to hide things we dont want the user to see
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
