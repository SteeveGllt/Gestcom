using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestcomWF.Models
{
    public class Client
    {
        public Decimal CLNUM { get; set; }
        public string CLNOM { get; set; }
        public string CLMTDI { get; set; }
        public string CLADR1 { get; set; }
        public string CLADR2 { get; set; }
        public Decimal CLCPOS { get; set; }
        public String CLVILL { get; set; }
        public String CLREGL { get; set; }
        public Decimal CLBASE { get; set; }
        public Decimal CLDEPA { get; set; }
        public Decimal CLECHE { get; set; }
        public Decimal CLARRI { get; set; }
        public Decimal CLBQUE { get; set; }
        public Decimal CLGUI { get; set; }
        public String CLCPTE { get; set; }
        public String CLRIB { get; set; }
        public String CLDOM { get; set; }
        public Decimal CLREP { get; set; }
        public Decimal CLEDIT { get; set; }
        public String CLFAMI { get; set; }
        public String CLTRAN { get; set; }
        public Decimal CLLIVR { get; set; }
        public Decimal CLFACT { get; set; }
        public Decimal CLCOMP { get; set; }
        public Decimal CLRIST { get; set; }
        public Decimal CLREMI { get; set; }
        public String CLCODE { get; set; }
        public Decimal CLTVA { get; set; }
        public Decimal CLENSE { get; set; }
        public String CLDIV { get; set; }
        public String CLINTRA { get; set; }
        public String CLSUPP { get; set; }

        public Client(decimal cLNUM, string cLNOM)
        {
            CLNUM = cLNUM;
            CLNOM = cLNOM;
        }

        public Client() { }

        public Client(decimal cLNUM, string cLNOM, string cLMTDI, string cLADR1, string cLADR2, decimal cLCPOS, string cLVILL, string cLREGL, decimal cLBASE, decimal cLDEPA, decimal cLECHE, decimal cLARRI, decimal cLBQUE, decimal cLGUI, string cLCPTE, string cLRIB, string cLDOM, decimal cLREP, decimal cLEDIT, string cLFAMI, string cLTRAN, decimal cLLIVR, decimal cLFACT, decimal cLCOMP, decimal cLRIST, decimal cLREMI, string cLCODE, decimal cLTVA, decimal cLENSE, string cLDIV, string cLINTRA, string cLSUPP) : this(cLNUM, cLNOM)
        {
            CLNUM = cLNUM;
            CLNOM = cLNOM;
            CLMTDI = cLMTDI;
            CLADR1 = cLADR1;
            CLADR2 = cLADR2;
            CLCPOS = cLCPOS;
            CLVILL = cLVILL;
            CLREGL = cLREGL;
            CLBASE = cLBASE;
            CLDEPA = cLDEPA;
            CLECHE = cLECHE;
            CLARRI = cLARRI;
            CLBQUE = cLBQUE;
            CLGUI = cLGUI;
            CLCPTE = cLCPTE;
            CLRIB = cLRIB;
            CLDOM = cLDOM;
            CLREP = cLREP;
            CLEDIT = cLEDIT;
            CLFAMI = cLFAMI;
            CLTRAN = cLTRAN;
            CLLIVR = cLLIVR;
            CLFACT = cLFACT;
            CLCOMP = cLCOMP;
            CLRIST = cLRIST;
            CLREMI = cLREMI;
            CLCODE = cLCODE;
            CLTVA = cLTVA;
            CLENSE = cLENSE;
            CLDIV = cLDIV;
            CLINTRA = cLINTRA;
            CLSUPP = cLSUPP;
        }
    }
}
