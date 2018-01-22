using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOPH2_Case_Form
{
    class Konto
    {
        private SqlDataAdapter adapter = new SqlDataAdapter();

        private int _kontoNr;
        private int _typeNr;
        private float _renteSats;
        private int _kundeNr;
        private double _saldo;
        private DateTime _oprettelsesdato;

        /// <summary>
        /// Creates all the properties for Konto
        /// </summary>

        public int kontoNr { get { return _kontoNr; } set { _kontoNr = value; } }
        public int typeNr { get { return _typeNr; } set { _typeNr = value; } }
        public float renteSats { get { return _renteSats; } set { _renteSats = value; } }
        public int kundeNr { get { return _kundeNr; } set { _kundeNr = value; } }
        public double saldo { get { return _saldo; } set { _saldo = value; } }
        public DateTime oprettelsesdato { get { return _oprettelsesdato; } set { _oprettelsesdato = value; } }

        /// <summary>
        /// Create all constructors for Konto
        /// </summary>

        public Konto()
        {
            oprettelsesdato = DateTime.Now;
        }

        public Konto(int kontoNr, int kundeNr) : this()
        {
            this.kontoNr = kontoNr;
            this.kundeNr = kundeNr;
        }

        public Konto(int kontoNr, int kundeNr, int typeNr, float renteSats, double saldo) : this(kontoNr, kundeNr)
        {
            this.typeNr = typeNr;
            this.renteSats = renteSats;
            this.saldo = saldo;
        }

        /// <summary>
        /// Lists all data for the given konto
        /// </summary>
        public SqlDataAdapter ListKontoData()
        {
            return SQLAPI.Read("* FROM Konto WHERE KontoNr = " + kontoNr);
        }

        /// <summary>
        /// List all transactions for the given konto
        /// </summary>
        public SqlDataAdapter ListTransaktioner()
        {
            return SQLAPI.Read("* FROM Transaktion WHERE KontoNr = " + kontoNr);
        }

        /// <summary>
        /// Creates the given konto
        /// </summary>
        public void OpretKonto()
        {
            SQLAPI.Insert("Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(" + typeNr + ", " + kundeNr + ", " + saldo + ", " + oprettelsesdato + ")");
            MessageBox.Show("Kunden er nu oprettet!");
        }

        /// <summary>
        /// Removes the given konto
        /// </summary>
        public void FjernKonto()
        {
            SQLAPI.Delete("Transaktion WHERE KontoNr = " + kontoNr);
            SQLAPI.Delete("Konto WHERE KontoNr = " + kontoNr);
        }

        /// <summary>
        /// Updates the rente.
        /// </summary>
        public void RetRentesats(float newrente)
        {
            SQLAPI.Update("KontoType SET Rentesats = " + newrente + " WHERE TypeNr = " + typeNr);
        }

        /// <summary>
        /// Creates a transaction for a indbetaling.
        /// </summary>
        /// <param name="amount"></param>
        public void Indbetaling(double amount)
        {
            double newSaldo = 0;
            System.Data.DataTable table = new System.Data.DataTable();
            adapter = SQLAPI.Read("Saldo FROM Konto WHERE KontoNr = " + kontoNr);
            adapter.Fill(table);
            newSaldo = Double.Parse(table.Rows[0]["Saldo"].ToString()) + amount;
            SQLAPI.Update("Konto SET Saldo = " + newSaldo + " WHERE KontoNr = " + kontoNr); // Update the saldo on the the account
            SQLAPI.Insert("Transaktion(Beløb,Dato,KontoNr) Values(" + amount +
                ", CAST('" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' AS DATETIME)," + kontoNr + ")"); // Create a transaction
        }

        /// <summary>
        /// Creates a transaction for a udbetaling.
        /// </summary>
        /// <param name="amount"></param>
        public void Udbetaling(double amount)
        {
            double newSaldo = 0;
            System.Data.DataTable table = new System.Data.DataTable();
            adapter = SQLAPI.Read("Saldo FROM Konto WHERE KontoNr = " + kontoNr);
            adapter.Fill(table);
            newSaldo = Double.Parse(table.Rows[0]["Saldo"].ToString()) - amount;
            if (newSaldo < 0)
            {
                System.Windows.Forms.MessageBox.Show("Error!\n\nDer er ikke penge nok på kontoen");
            }
            else
            {
                SQLAPI.Update("Konto SET Saldo = " + newSaldo + " WHERE KontoNr = " + kontoNr); // Update the saldo on the the account
                SQLAPI.Insert("Transaktion(Beløb,Dato,KontoNr) Values(" + (amount * -1) +
                    ", CAST('" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' AS DATETIME)," + kontoNr + ")"); // Create a transaction
            }
        }
    }
}
