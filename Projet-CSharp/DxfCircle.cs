using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfCircle
    {
     
            public float X { get; set; }
            public float Y { get; set; }
            public float Radius { get; set; }

            public DxfCircle(float x, float y, float radius)
            {
                X = x;
                Y = y;
                Radius = radius;
            }
            public string ToDxf()
            {
                return "0\nCIRCLE\n" +
                    $"10\n{X}\n20\n{Y}\n40\n{Radius}\n";
            }
        }
    }


