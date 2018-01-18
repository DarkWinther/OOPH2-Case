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

        public int kontoNr { get { return _kontoNr; } set { _kontoNr = value; } }
        public string typeNavn { get { return _typeNavn; } set { _typeNavn = value; } }
        public float renteSats { get { return _renteSats; } set { _renteSats = value; } }
        public int kundeNr { get { return _kundeNr; } set { _kundeNr = value; } }
        public double saldo { get { return _saldo; } set { _saldo = value; } }
        public DateTime oprettelsesdato { get { return _oprettelsesdato; } set { _oprettelsesdato = value; } }

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
        /// 
        /// </summary>
        public void ListKontoData()
        {
            SQLAPI.Read("* FROM Konto WHERE KundeNr = " + kundeNr);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ListTransaktioner()
        {
            SQLAPI.Read("* FROM Transaktion WHERE KontoNr = " + kontoNr);
        }

        /// <summary>
        /// 
        /// </summary>
        public void OpretKonto()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void FjernKonto()
        {
            SQLAPI.Delete("Konto WHERE KontoNr = " + kontoNr);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RetRentesats()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void UdregnRente()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void Indbetaling(int amount)
        {
            // TODO: Get The current saldo of the konto.
            SQLAPI.Update("Konto SET Saldo = " + amount + "WHERE KontoNr = " + kontoNr); // Update the saldo on the the account
            SQLAPI.Insert("Transaktion(Beløb,Dato,KontoNr) Values(" + amount + "," + DateTime.Now + "," + kontoNr + ")"); // Create a transaction
        }

        /// <summary>
        /// 
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
