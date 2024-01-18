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
        public Double LOTAUX { get; set; }
        public Decimal MONTANT { get; set; }
        public Decimal PRIX { get; set; }

        public EntreeLot() { }

        public EntreeLot(decimal lOFACO, decimal lOFROM, decimal lOANNE, decimal lOMOIS, decimal lODEP, DateTime date_Entrée, DateTime date_Début, DateTime dAte_Fin, decimal lOCENM, decimal lOCENB, decimal lOCPES, decimal lOCENN, double lOTAUX)
        {
            LOFACO = lOFACO;
            LOFROM = lOFROM;
            LOANNE = lOANNE;
            LOMOIS = lOMOIS;
            LODEP = lODEP;
            Date_Entrée = date_Entrée;
            Date_Début = date_Début;
            DAte_Fin = dAte_Fin;
            LOCENM = lOCENM;
            LOCENB = lOCENB;
            LOCPES = lOCPES;
            LOCENN = lOCENN;
            LOTAUX = lOTAUX;
        }
        public EntreeLot(decimal lOFACO, decimal lOFROM, decimal lOANNE, decimal lOMOIS, decimal lODEP, DateTime date_Entrée, DateTime date_Début, DateTime dAte_Fin, decimal lOCENM, decimal lOCENB, decimal lOCPES, decimal lOCENN, double lOTAUX, decimal pRIX)
        {
            LOFACO = lOFACO;
            LOFROM = lOFROM;
            LOANNE = lOANNE;
            LOMOIS = lOMOIS;
            LODEP = lODEP;
            Date_Entrée = date_Entrée;
            Date_Début = date_Début;
            DAte_Fin = dAte_Fin;
            LOCENM = lOCENM;
            LOCENB = lOCENB;
            LOCPES = lOCPES;
            LOCENN = lOCENN;
            LOTAUX = lOTAUX;
            PRIX = pRIX;
        }

    }
}
