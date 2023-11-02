using Gestcom.ModelAdo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gestcom.Models
{
    public class Lot
    {
        public Decimal LOFACO { get; set; }
        public Decimal LOFROM { get; set; }
        public Decimal LOANNE { get; set; }
        public Decimal LOMOIS { get; set; }
        public Decimal LODEP { get; set; }
        public Decimal LOCEB1 { get; set; }
        public Decimal LOCEN1 { get; set; }
        public Decimal LOCPES { get; set; }
        public Decimal LOCEM1 { get; set; }
        public Decimal LOCC1 { get; set; }
        public Decimal LOC11 { get; set; }
        public Decimal LOC12 { get; set; }
        public Decimal LOC13 { get; set; }
        public Decimal LOC14 { get; set; }
        public Decimal LOPUAC { get; set; }
        public Decimal LOCACO { get; set; }
        public Decimal LOPU1 { get; set; }
        public Decimal LOPU2 { get; set; }
        public Decimal LOPU3 { get; set; }
        public Decimal LOPU4 { get; set; }
        public Decimal LOCDEF { get; set; }
        public Decimal LOC21 { get; set; }
        public Decimal LOC22 { get; set; }
        public Decimal LOC23 { get; set; }
        public Decimal LOC24 { get; set; }
        public Decimal LOVM1 { get; set; }
        public Decimal LOVM2 { get; set; }
        public Decimal LOVM3 { get; set; }
        public Decimal LOVM4 { get; set; }
        public Decimal LOVV1 { get; set; }
        public Decimal LOVV2 { get; set; }
        public Decimal LOVV3 { get; set; }
        public Decimal LOVV4 { get; set; }
        public Decimal LOVP1 { get; set; }
        public Decimal LOVP2 { get; set; }
        public Decimal LOVP3 { get; set; }
        public Decimal LOVP4 { get; set; }
        public Decimal LOSM1 { get; set; }
        public Decimal LOSM2 { get; set; }
        public Decimal LOSM3 { get; set; }
        public Decimal LOSM4 { get; set; }
        public Decimal LOSP1 { get; set; }
        public Decimal LOSP2 { get; set; }
        public Decimal LOSP3 { get; set; }
        public Decimal LOSP4 { get; set; }
        public Decimal LOTCON { get; set; }
        public Decimal DATC1 { get; set; }
        public Decimal DATC2 { get; set; }
        public Decimal LOCC2N { get; set; }
        public Decimal DATACO { get; set; }
        public Decimal LOFR1 { get; set; }
        public Decimal LOFR2 { get; set; }
        public Decimal LOFR3 { get; set; }
        public Decimal LOFR4 { get; set; }
        public Decimal LOFV1 { get; set; }
        public Decimal LOFV2 { get; set; }
        public Decimal LOFV3 { get; set; }
        public Decimal LOFV4 { get; set; }
        public String LOVID { get; set; }
        public Decimal LOPSTK { get; set; }
        public String VIDE { get; set; }

        public Lot () { }
        public Lot(decimal lofrom, decimal locem1, decimal loc11, decimal loc12, decimal loc13) {
            LOFROM = lofrom;
            LOCEM1 = locem1;
            LOC11 = loc11;
            LOC12 = loc12;
            LOC13 = loc13;
        }

        public Lot(decimal lofrom, decimal locem1, decimal lopuac)
        {
            LOFROM = lofrom;
            LOCEM1 = locem1;
            LOPUAC = lopuac;
        }

        public Lot(decimal lofrom, decimal locem1, decimal loc11, decimal loc12, decimal loc13, decimal lopu1, decimal lopu2, decimal lopu3)
        {
            LOFROM = lofrom;
            LOCEM1 = locem1;
            LOC11 = loc11;
            LOC12 = loc12;
            LOC13 = loc13;
            LOPU1 = lopu1;
            LOPU2 = lopu2;
            LOPU3 = lopu3;

        }

    }
}
