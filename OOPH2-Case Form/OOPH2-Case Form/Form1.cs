using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPH2_Case_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLAPI.Create("Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato)",
                "'Kevin', 'Winther', 2820, 'Ermelundsvej', CAST('2012-06-05 12:00' AS smalldatetime)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLAPI.Delete("Kunde", "KundeNr", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLAPI.Update("Kunde", "TlfNr = 88888888", "KundeNr = 2");
        }
    }
}
