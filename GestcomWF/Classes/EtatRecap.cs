using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestcomWF.Classes
{
    public class EtatRecap
    {
        public String FRNOM { get; set; }
        public Decimal LOCEM1 { get; set; }
        public Decimal LOCEN1 { get; set; }
        public Decimal LOC11 { get; set; }
        public Decimal LOC12 { get; set; }
        public Decimal LOC13 { get; set; }
        public Decimal MONTANT { get; set; }

        public EtatRecap(string fRNOM, decimal lOCEM1, decimal lOCEN1, decimal lOC11, decimal lOC12, decimal lOC13, decimal mONTANT)
        {
            FRNOM = fRNOM;
            LOCEM1 = lOCEM1;
            LOCEN1 = lOCEN1;
            LOC11 = lOC11;
            LOC12 = lOC12;
            LOC13 = lOC13;
            MONTANT = mONTANT;
        }
    }
}
