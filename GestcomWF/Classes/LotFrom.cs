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
        public Decimal LOCEN1 { get; set; } // Pains
        public Decimal LOCEM1 { get; set; } // Pains
        public Decimal LOC11 { get; set; } // Pains
        public Decimal LOC12 { get; set; } // Pains
        public Decimal LOC13 { get; set; } // Pains
        public Decimal LOPUAC { get; set; }
        public Decimal LOPU1 { get; set; }
        public Decimal LOPU2 { get; set; }
        public Decimal LOPU3 { get; set; }
        public Decimal FRNUM { get; set; } // Num Fromagerie
        public String FRNOM { get; set; }
        public String FRADR { get; set; }
        public Decimal FRCPOS { get; set; }
        public String FRVILL { get; set; }
        public String FRNDIR { get; set; }
        public Decimal FRBANQ { get; set; }
        public Decimal FRGUIC { get; set; }
        public string FRCOM1 { get; set; }
        public string FRCOM2 { get; set; }
        public string FRDOMI { get; set; }

        public Decimal FACTURATION { get; set; }
        public Decimal FRPRIME { get; set; }

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
        public LotFrom(decimal lOFROM, string fRNOM, string fRNDIR, string fRADR, decimal fRCPOS, decimal fRPRIME, decimal lOCEN1, decimal lOCEM1, decimal lOC11, decimal lOC12, decimal lOC13, decimal lOPUAC, decimal lOPU1, decimal lOPU2, decimal lOPU3, decimal lOANNE, decimal lOMOIS, string fRVILL, decimal fRNUM, decimal facturation, string fRDOMI, decimal fRBANQ, decimal fRGUIC, string fRCOM1, string fRCOM2)
        {
            LOFROM = lOFROM;
            FRNOM = fRNOM;
            FRNDIR = fRNDIR;
            FRADR = fRADR;
            FRCPOS = fRCPOS;
            FRPRIME = fRPRIME;
            LOCEN1 = lOCEN1;
            LOCEM1 = lOCEM1;
            LOC11 = lOC11;
            LOC12 = lOC12;
            LOC13 = lOC13;
            LOPUAC = lOPUAC;
            LOPU1 = lOPU1;
            LOPU2 = lOPU2;
            LOPU3 = lOPU3;
            LOANNE = lOANNE;
            LOMOIS = lOMOIS;
            FRVILL = fRVILL;
            FRNUM = fRNUM;
            FACTURATION = facturation;
            FRDOMI = fRDOMI;
            FRBANQ = fRBANQ;
            FRGUIC = fRGUIC;
            FRCOM1 = fRCOM1;
            FRCOM2 = fRCOM2;
        }

        public LotFrom(decimal lOFROM, string fRNOM, string fRNDIR, string fRADR, decimal fRCPOS, decimal lOCEN1, decimal lOCEM1, decimal lOPUAC, decimal lOANNE, decimal lOMOIS, string fRVILL, decimal fRNUM, string fRDOMI, decimal fRBANQ, decimal fRGUIC, string fRCOM1, string fRCOM2)
        {
            LOFROM = lOFROM;
            FRNOM = fRNOM;
            FRNDIR = fRNDIR;
            FRADR = fRADR;
            FRCPOS = fRCPOS;
            LOCEN1 = lOCEN1;
            LOCEM1 = lOCEM1;
            LOPUAC = lOPUAC;
            LOANNE = lOANNE;
            LOMOIS = lOMOIS;
            FRVILL = fRVILL;
            FRNUM = fRNUM;
            FRDOMI = fRDOMI;
            FRBANQ = fRBANQ;
            FRGUIC = fRGUIC;
            FRCOM1 = fRCOM1;
            FRCOM2 = fRCOM2;
        }
    }
}
