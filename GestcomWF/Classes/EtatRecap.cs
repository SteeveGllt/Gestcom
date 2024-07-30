using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestcomWF.Classes
{
    public class EtatRecap
    {
        private String FRNOM;
        private Decimal LOCEM1;
        private Decimal LOCEN1;
        private Decimal LOC11;
        private Decimal LOC12;
        private Decimal LOC13;
        private Decimal MONTANT;

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
