using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp.Modeles
{
    internal class Profil
    {
        public int id { get; set; }
        public string name { get; set; }
        public double Longueur { get; set; }

        public List<ProfilPoint> Points { get; set; } = new List<ProfilPoint>();
    }
}
