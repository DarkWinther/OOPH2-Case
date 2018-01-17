using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH2_Case_Form
{
    class Kunde
    {
        private int _kundeNr;
        private string _fornavn;
        private string _efternavn;
        private int _postNr;
        private string _adresse;
        private int _tlfNr;
        private DateTime _oprettelsesdato;

        public int kundeNr { get { return _kundeNr; } set { _kundeNr = value; } }
        public string fornavn { get { return _fornavn; } set { _fornavn = value; } }
        public string efternavn { get { return _efternavn; } set { _efternavn = value; } }
        public int postNr { get { return _postNr; } set { _postNr = value; } }
        public string adresse { get { return _adresse; } set { _adresse = value; } }
        public int tlfNr { get { return _tlfNr; } set { _tlfNr = value; } }
        public DateTime oprettelsesdato { get { return _oprettelsesdato; } set { _oprettelsesdato = value; } }
    }
}
