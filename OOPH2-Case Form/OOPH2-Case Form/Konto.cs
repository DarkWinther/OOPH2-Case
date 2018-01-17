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
        private short _kontoType;
        private int _kundeNr;
        private decimal _saldo;
        private DateTime _oprettelsesdato;

        public int kontoNr { get { return _kontoNr; } set { _kontoNr = value; } }
        public short kontoType { get { return _kontoType; } set { _kontoType = value; } }
        public int kuneNr { get { return _kundeNr; } set { _kundeNr = value; } }
        public decimal saldo { get { return _saldo; } set { _saldo = value; } }
        public DateTime oprettelsesdato { get { return _oprettelsesdato; } set { _oprettelsesdato = value; } }
    }
}
