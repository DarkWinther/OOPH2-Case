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
        private decimal _saldo;
        private DateTime _oprettelsesdato;

        public int kontoNr { get { return _kontoNr; } set { _kontoNr = value; } }
        public string typeNavn { get { return _typeNavn; } set { _typeNavn = value; } }
        public float renteSats { get { return _renteSats; } set { _renteSats = value; } }
        public int kuneNr { get { return _kundeNr; } set { _kundeNr = value; } }
        public decimal saldo { get { return _saldo; } set { _saldo = value; } }
        public DateTime oprettelsesdato { get { return _oprettelsesdato; } set { _oprettelsesdato = value; } }
    }
}
