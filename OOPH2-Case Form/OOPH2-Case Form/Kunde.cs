using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOPH2_Case_Form
{
    class Kunde
    {
        private SqlDataAdapter adapter = new SqlDataAdapter();

        private int _kundeNr;
        private string _fornavn;
        private string _efternavn;
        private int _postNr;
        private string _byNavn;
        private string _adresse;
        private int _tlfNr;
        private DateTime _oprettelsesdato;

        /// <summary>
        /// Creates all the properties for Kunde
        /// </summary>

        public int kundeNr { get { return _kundeNr; } set { _kundeNr = value; } }
        public string fornavn { get { return _fornavn; } set { _fornavn = value; } }
        public string efternavn { get { return _efternavn; } set { _efternavn = value; } }
        public int postNr { get { return _postNr; } set { _postNr = value; } }
        public string byNavn { get { return _byNavn; } set { _byNavn = value; } }
        public string adresse { get { return _adresse; } set { _adresse = value; } }
        public int tlfNr { get { return _tlfNr; } set { _tlfNr = value; } }
        public DateTime oprettelsesdato { get { return _oprettelsesdato; } set { _oprettelsesdato = value; } }


        /// <summary>
        /// Create all constructors for Kunde
        /// </summary>

        public Kunde()
        {
            oprettelsesdato = DateTime.Now;
        }

        public Kunde(int kundeNr) : this()
        {
            this.kundeNr = kundeNr;
        }

        public Kunde(int kundeNr, string fornavn, string efternavn) : this(kundeNr)
        {
            this.fornavn = fornavn;
            this.efternavn = efternavn;
        }

        public Kunde(int kundeNr, string fornavn, string efternavn, int postNr, string byNavn, string adresse) : this(kundeNr, fornavn, efternavn)
        {
            this.postNr = postNr;
            this.byNavn = byNavn;
            this.adresse = adresse;
        }

        public Kunde(int kundeNr, string fornavn, string efternavn, int postNr, string byNavn, string adresse, int tlfNr) : this(kundeNr, fornavn, efternavn, postNr, byNavn, adresse)
        {
            this.tlfNr = tlfNr;
        }

        /// <summary>
        /// Lists all the kunde data from the given kunde
        /// </summary>
        public SqlDataAdapter ListKundeData()
        {
            return SQLAPI.Read("* FROM Kunde WHERE KundeNr = " + kundeNr);
        }

        /// <summary>
        /// Lists all the kontier from the given kunde
        /// </summary>
        public SqlDataAdapter KontiList()
        {
            return SQLAPI.Read(
                "KontoNr, Saldo, TypeNavn, Rentesats, OprettelsesDato " +
                "FROM Konto, KontoType " +
                "WHERE Konto.KontoType = KontoType.TypeNr AND KundeNr = " + kundeNr);
        }

        /// <summary>
        /// Creates a kunde
        /// </summary>
        public void OpretKunde()
        {
            bool success;
            if (tlfNr == 0)
            {
                success = SQLAPI.Insert("Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'" + fornavn + "', N'" + efternavn + "', " + postNr + ", N'" + adresse + "', CAST('" + oprettelsesdato.ToString("yyyy-MM-dd hh:mm:ss") + "' AS DATETIME))");
            }
            else
            {
                success = SQLAPI.Insert("Kunde(Fornavn, Efternavn, PostNr, Adresse, TlfNr, OprettelsesDato) VALUES(N'" + fornavn + "', N'" + efternavn + "', " + postNr + ", N'" + adresse + "', " + tlfNr + ", CAST('" + oprettelsesdato.ToString("yyyy-MM-dd hh:mm:ss") + "' AS DATETIME))");
            }
            if (success)
                MessageBox.Show("Kunden er nu oprettet!");
        }

        /// <summary>
        /// Updates a kunde
        /// </summary>
        public void OpdaterKunde(int type)
        {
            switch (type)
            {
                case 1:
                    SQLAPI.Update("Kunde SET Fornavn = " + fornavn + " WHERE KundeNr = " + kundeNr);
                    break;
                case 2:
                    SQLAPI.Update("Kunde SET Efternavn = " + efternavn + " WHERE KundeNr = " + kundeNr);
                    break;
                case 3:
                    SQLAPI.Update("Kunde SET Adresse = " + adresse + " WHERE KundeNr = " + kundeNr);
                    break;
                case 4:
                    SQLAPI.Update("Kunde SET PostNr = " + postNr + " WHERE KundeNr = " + kundeNr);
                    break;
                case 5:
                    SQLAPI.Update("Kunde SET TlfNr = " + tlfNr + " WHERE KundeNr = " + kundeNr);
                    break;
                default:
                    MessageBox.Show("Error\nIf you find a developer give him/her this message: OpdaterKunde() did not lead to anything.");
                    break;
            }
        }

        /// <summary>
        /// Removes the given kunde
        /// </summary>
        public void FjernKunde()
        {
            SQLAPI.Delete("Konto WHERE KundeNr = " + kundeNr);
            SQLAPI.Delete("Kunde WHERE KundeNr = " + kundeNr);
        }
    }
}
