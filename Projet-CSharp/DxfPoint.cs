using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfPoint
    {
         

            public int Id { get; set; }   // ✅ ajouté
            public double X { get; set; }
            public double Y { get; set; }

            // Pour création manuelle / dessin
            public DxfPoint(double x, double y)
            {
                X = x;
                Y = y;
            }

            // Pour lecture depuis BDD
            public DxfPoint(int id, double x, double y)
            {
                Id = id;
                X = x;
                Y = y;
            }

            public string ToDxf()
            {
                return $"0\nPOINT\n10\n{X}\n20\n{Y}\n";
            }
        }
    }


