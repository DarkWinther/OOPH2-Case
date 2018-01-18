using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH2_Case_Form
{
    class Konto
    {
        private int _kontoNr;
        private string _typeNavn;
        private float _renteSats;
        private int _kundeNr;
        private double _saldo;
        private DateTime _oprettelsesdato;

        /// <summary>
        /// Creates all the properties for Konto
        /// </summary>

        public int kontoNr { get { return _kontoNr; } set { _kontoNr = value; } }
        public string typeNavn { get { return _typeNavn; } set { _typeNavn = value; } }
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

        public Konto(int kontoNr) : this()
        {
            this.kontoNr = kontoNr;
        }

        public Konto(int kontoNr, string typeNavn, float renteSats, double saldo) : this(kontoNr)
        {
            this.typeNavn = typeNavn;
            this.renteSats = renteSats;
            this.saldo = saldo;
        }

        /// <summary>
        /// Lists all data for the given konto
        /// </summary>
        public void ListKontoData()
        {
            SQLAPI.Read("* FROM Konto WHERE KundeNr = " + kundeNr);
        }

        /// <summary>
        /// List all transactions for the given konto
        /// </summary>
        public void ListTransaktioner()
        {
            SQLAPI.Read("* FROM Transaktion WHERE KontoNr = " + kontoNr);
        }

        /// <summary>
        /// Creates the given konto
        /// </summary>
        public void OpretKonto()
        {
        }

        /// <summary>
        /// Removes the given konto
        /// </summary>
        public void FjernKonto()
        {
            SQLAPI.Delete("Konto WHERE KontoNr = " + kontoNr);
        }

        /// <summary>
        /// ???
        /// </summary>
        public void RetRentesats()
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public void UdregnRente()
        {
        }

        /// <summary>
        /// Creates a transaction for a indbetaling.
        /// </summary>
        /// <param name="amount"></param>
        public void Indbetaling(int amount)
        {
            // TODO: Get The current saldo of the konto.
            SQLAPI.Update("Konto SET Saldo = " + amount + "WHERE KontoNr = " + kontoNr); // Update the saldo on the the account
            SQLAPI.Insert("Transaktion(Beløb,Dato,KontoNr) Values(" + amount + "," + DateTime.Now + "," + kontoNr + ")"); // Create a transaction
        }

        /// <summary>
        /// Creates a transaction for a udbetaling.
        /// </summary>
        /// <param name="amount"></param>
        public void Udbetaling(int amount)
        {
            // TODO: Get The current saldo of the konto.
            SQLAPI.Update("Konto SET Saldo = " + amount + "WHERE KontoNr = " + kontoNr); // Update the saldo on the the account
            SQLAPI.Insert("Transaktion(Beløb,Dato,KontoNr) Values(" + amount + "," + DateTime.Now + "," + kontoNr + ")"); // Create a transaction
        }
    }
}
