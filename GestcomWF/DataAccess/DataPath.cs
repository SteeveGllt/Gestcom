using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestcomWF.DataAccess
{
    public class DataPath
    {
        private string _pathAcompte = @"..\..\..\..\..\\Documents_Excel\Acomptes";
        private string _pathRappel = @"..\..\..\..\..\Documents_Excel\Rappels";
        private string _pathPesee = @"..\..\..\..\..\Documents_Excel\Pesées";
        private string _pathClassement = @"..\..\..\..\..\Documents_Excel\Classements";
        //private string _pathAcompte = @"\\SRVBRUN-FILES\Documents\Fromageries\Acomptes";
        //private string _pathRappel = @"\\SRVBRUN-FILES\Documents\Fromageries\Rappels";
        //private string _pathPesee = @"\\SRVBRUN-FILES\Documents\Fromageries\Pesées";
        //private string _pathClassement = @"\\SRVBRUN-FILES\Documents\Fromageries\Classements";

        public string PathAcompte { get => _pathAcompte; set => _pathAcompte = value; }
        public string PathRappel { get => _pathRappel; set => _pathRappel = value; }
        public string PathPesee { get => _pathPesee; set => _pathPesee = value; }
        public string PathClassement { get => _pathClassement; set => _pathClassement = value; }
    }
}
