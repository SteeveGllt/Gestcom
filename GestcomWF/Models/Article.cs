using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestcom.Models
{
    public class Article
    {
       
        public Decimal ARNUM { get; set; }
        public string ARDESI { get; set; }
        public string ARFAMI { get; set; }
        public string ARUNIT { get; set; }
        public Decimal ARPRIX { get; set; }
        public Decimal ARTVA { get; set; }
        public Decimal ARPOID { get; set; }
        public string ARCEC { get; set; }
        public string ARDIV { get; set; }
        public string ARSUPP { get; set; }

        public Article(Decimal ARNUM, string ARDESI, string ARFAMI, string ARUNIT, Decimal ARPRIX, Decimal ARTVA, Decimal ARPOID, string ARCEC, string ARDIV, string ARSUPP) {
            this.ARNUM = ARNUM;
            this.ARDESI = ARDESI;
            this.ARFAMI = ARFAMI;
            this.ARUNIT = ARUNIT;
            this.ARPRIX = ARPRIX;
            this.ARTVA = ARTVA;
            this.ARPOID = ARPOID;
            this.ARCEC = ARCEC;
            this.ARDIV = ARDIV;
            this.ARSUPP = ARSUPP;
        }
    }
}
