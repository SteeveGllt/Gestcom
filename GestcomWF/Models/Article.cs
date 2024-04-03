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
        public string ARCPT1 { get; set; }
        public string ARCPT2 { get; set; }
        public int ARDLUO { get; set; }
        public decimal AREAN13 { get; set; }

        public Article(decimal ARNUM, string ARDESI, string ARFAMI, string ARUNIT, decimal ARPRIX, decimal ARTVA, decimal ARPOID, string ARCEC, string ARCPT1, string ARCPT2, int ARDLUO, decimal AREAN13) {
            this.ARNUM = ARNUM;
            this.ARDESI = ARDESI;
            this.ARFAMI = ARFAMI;
            this.ARUNIT = ARUNIT;
            this.ARPRIX = ARPRIX;
            this.ARTVA = ARTVA;
            this.ARPOID = ARPOID;
            this.ARCEC = ARCEC;
            this.ARCPT1 = ARCPT1;
            this.ARCPT2 = ARCPT2;
            this.ARDLUO = ARDLUO;
            this.AREAN13 = AREAN13;
        }

        public Article() { }
    }
}
