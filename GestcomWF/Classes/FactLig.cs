using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestcomWF.Classes
{
    public class FactLig
    {
        public decimal CMCOMN { get; set; }
        public DateTime CMDATE { get; set; }
        public decimal NUMFAC { get; set; }
        public decimal CA { get; set; }

        public FactLig(decimal cMCOMN, DateTime cMDATE, decimal nUMFAC, decimal cA)
        {
            CMCOMN = cMCOMN;
            CMDATE = cMDATE;
            NUMFAC = nUMFAC;
            CA = cA;
        }

        public FactLig()
        {
        }
    }
}
