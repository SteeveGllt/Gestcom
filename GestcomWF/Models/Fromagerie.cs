using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestcom.Models
{
    public class Fromagerie
    {
        public Fromagerie(decimal fRNUM)
        {
            FRNUM = fRNUM;
        }
        public Fromagerie(decimal fRNUM, string fRNOM)
        {
            FRNOM = fRNOM;
        }

        public Fromagerie(decimal fRNUM, string fRNOM, string fRADR, decimal fRCPOS, string fRVILL, string fRNDIR, decimal fRTYPE, decimal fRTCON, decimal fRCMEU, decimal fRCPOI, string fRMODR, string fRDOMI, decimal fRBANQ, decimal fRGUIC, string fRCOM1, string fRCOM2, decimal cOE1, decimal cOE2, decimal cOE3, decimal cOE4, decimal fRREFA, decimal fRPUAC, decimal fRETRE, string fRHIVE, string fRCVER, decimal fRVVER, string fREVER, bool fRACTIF)
         {
             FRNUM = fRNUM;
             FRNOM = fRNOM;
             FRADR = fRADR;
             FRCPOS = fRCPOS;
             FRVILL = fRVILL;
             FRNDIR = fRNDIR;
             FRTYPE = fRTYPE;
             FRTCON = fRTCON;
             FRCMEU = fRCMEU;
             FRCPOI = fRCPOI;
             FRMODR = fRMODR;
             FRDOMI = fRDOMI;
             FRBANQ = fRBANQ;
             FRGUIC = fRGUIC;
             FRCOM1 = fRCOM1;
             FRCOM2 = fRCOM2;
             COE1 = cOE1;
             COE2 = cOE2;
             COE3 = cOE3;
             COE4 = cOE4;
             FRREFA = fRREFA;
             FRPUAC = fRPUAC;
             FRETRE = fRETRE;
             FRHIVE = fRHIVE;
             FRCVER = fRCVER;
             FRVVER = fRVVER;
             FREVER = fREVER;
             FRACTIF = fRACTIF;
    }

        public Decimal FRNUM { get; set; }
        public String FRNOM { get; set;}
        public String FRADR { get; set;}
        public Decimal FRCPOS { get; set;}
        public String FRVILL { get; set;}
        public String FRNDIR { get; set;}
        public Decimal FRTYPE { get; set;}
        public Decimal FRTCON { get; set;}
        public Decimal FRCMEU { get; set;}
        public Decimal FRCPOI { get; set;}
        public String FRMODR { get; set;}
        public String FRDOMI { get; set;}
        public Decimal FRBANQ { get; set;}
        public Decimal FRGUIC { get; set;}
        public String FRCOM1 { get; set;}
        public String FRCOM2 { get; set;}
        public Decimal COE1 { get; set;}
        public Decimal COE2 { get; set;}
        public Decimal COE3 { get; set;}
        public Decimal COE4 { get; set;}
        public Decimal FRREFA { get; set;}
        public Decimal FRPUAC { get; set;}
        public Decimal FRETRE { get; set;}
        public String FRHIVE { get; set;}
        public String FRCVER { get; set;}
        public Decimal FRVVER { get; set;}
        public String FREVER { get; set;}
        public Boolean FRACTIF { get; set;}

      
    }
}
