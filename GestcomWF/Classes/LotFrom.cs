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
        public Decimal LOCENM1 { get; set; } // Pains
        public Decimal LOC11 { get; set; } // Pains
        public Decimal LOC12 { get; set; } // Pains
        public Decimal LOC13 { get; set; } // Pains
        public Decimal FRNUM { get; set; } // Num Fromagerie
        public String FRNOM { get; set; }
        public String FRADR { get; set; }
        public Decimal FRCPOS { get; set; }
        public String FRVILL { get; set; }
        public String FRNDIR { get; set; }

        public LotFrom(decimal lOFROM, decimal lOANNE, decimal lOMOIS, decimal lOCENM1, decimal lOC11, decimal lOC12, decimal lOC13, decimal fRNUM, string fRNOM, string fRADR, decimal fRCPOS, string fRVILL, string fRNDIR)
        {
            LOFROM = lOFROM;
            LOANNE = lOANNE;
            LOMOIS = lOMOIS;
            LOCENM1 = lOCENM1;
            LOC11 = lOC11;
            LOC12 = lOC12;
            LOC13 = lOC13;
            FRNUM = fRNUM;
            FRNOM = fRNOM;
            FRADR = fRADR;
            FRCPOS = fRCPOS;
            FRVILL = fRVILL;
            FRNDIR = fRNDIR;
        }
    }
}
