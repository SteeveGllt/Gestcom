using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestcomWF.Classes
{
    public class LotFrom
    {
        public Decimal LOFROM { get; set; } // Lot From = Num Fromagerie
        public Decimal LOANNE { get; set; }
        public Decimal LOMOIS { get; set; }
        public Decimal LOCEM1 { get; set; } // Pains
        public Decimal LOC11 { get; set; } // Pains
        public Decimal LOC12 { get; set; } // Pains
        public Decimal LOC13 { get; set; } // Pains
        public Decimal FRNUM { get; set; } // Num Fromagerie
        public String FRNOM { get; set; }
        public String FRADR { get; set; }
        public Decimal FRCPOS { get; set; }
        public String FRVILL { get; set; }
        public String FRNDIR { get; set; }

        public LotFrom(decimal lOFROM, string fRNOM, string fRNDIR, string fRADR, decimal fRCPOS, decimal lOCEM1, decimal lOC11, decimal lOC12, decimal lOC13, decimal lOANNE, decimal lOMOIS, string fRVILL, decimal fRNUM)
        {
            LOFROM = lOFROM;
            FRNOM = fRNOM;
            FRNDIR = fRNDIR;
            FRADR = fRADR;
            FRCPOS = fRCPOS;
            LOCEM1 = lOCEM1;
            LOC11 = lOC11;
            LOC12 = lOC12;
            LOC13 = lOC13;
            LOANNE = lOANNE;
            LOMOIS = lOMOIS;
            FRVILL = fRVILL;
            FRNUM = fRNUM;
        }
    }
}
