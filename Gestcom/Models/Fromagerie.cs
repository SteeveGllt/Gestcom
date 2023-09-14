using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestcom.Models
{
    public class Fromagerie
    {
        public Fromagerie() { }

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
    }
}
