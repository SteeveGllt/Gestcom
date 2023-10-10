using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestcom.Classes
{
    public class EntreeLotFrom
    {

        public Decimal LOFROM { get; set; } // Lot From = Num Fromagerie
        public Decimal LOANNE { get; set; }
        public Decimal LOMOIS { get; set; }
        public DateTime Date_Entrée { get; set; }
        public Decimal LOCENM { get; set; } // Pains
        public Decimal LOCENB { get; set; } // Brut
        public Decimal LOCENN { get; set; } // Net
        public Decimal LOTAUX { get; set; } // Freinte
        public Decimal FRNUM { get; set; } // Num Fromagerie
        public String FRNOM { get; set; }
        public String FRADR { get; set; }
        public Decimal FRCPOS { get; set; }
        public String FRVILL { get; set; }
        public String FRNDIR { get; set; }

        public EntreeLotFrom() { }

        public EntreeLotFrom(decimal lOFROM, decimal lOANNE, decimal lOMOIS, DateTime date_Entrée, decimal lOCENM, decimal lOCENB, decimal lOCENN, decimal lOTAUX, decimal fRNUM, string fRNOM, string fRADR, decimal fRCPOS, string fRVILL, string fRNDIR)
        {
            LOFROM = lOFROM;
            LOANNE = lOANNE;
            LOMOIS = lOMOIS;
            Date_Entrée = date_Entrée;
            LOCENM = lOCENM;
            LOCENB = lOCENB;
            LOCENN = lOCENN;
            LOTAUX = lOTAUX;
            FRNUM = fRNUM;
            FRNOM = fRNOM;
            FRADR = fRADR;
            FRCPOS = fRCPOS;
            FRVILL = fRVILL;
            FRNDIR = fRNDIR;
        }
    }
}
