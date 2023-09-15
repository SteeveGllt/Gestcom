using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestcom.Models
{
    public class EntreeLot
    {
        public Decimal LOFACO { get; set; }
        public Decimal LOFROM { get; set; }
        public Decimal LOANNE { get; set; }
        public Decimal LOMOIS { get; set; }
        public Decimal LODEP { get; set; }
        public DateTime Date_Entrée { get; set; }
        public DateTime Date_Début { get; set; }
        public DateTime DAte_Fin { get; set; }
        public Decimal LOCENM { get; set; }
        public Decimal LOCENB { get; set; }
        public Decimal LOCPES { get; set; }
        public Decimal LOCENN { get; set; }
        public Decimal LOTAUX { get; set; }

        public EntreeLot() { }

    }
}
