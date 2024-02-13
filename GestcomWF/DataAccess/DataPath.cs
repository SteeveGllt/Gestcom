using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestcomWF.DataAccess
{
    public class DataPath
    {
        private string _pathAcompte = "../../../Documents/Acomptes";
        private string _pathRappel = "../../../Documents/Rappels";
        private string _pathPesee = "../../../Documents/Pesée";
        private string _pathClassement = "../../../Documents/Classements";

        public string PathAcompte { get => _pathAcompte; set => _pathAcompte = value; }
        public string PathRappel { get => _pathRappel; set => _pathRappel = value; }
        public string PathPesee { get => _pathPesee; set => _pathPesee = value; }
        public string PathClassement { get => _pathClassement; set => _pathClassement = value; }
    }
}
