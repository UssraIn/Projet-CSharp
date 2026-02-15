using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfCircle
    {
     /**
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
            }**/
     
            public double X { get; set; }
            public double Y { get; set; }
            public double Radius { get; set; }
            public string Layer { get; set; }

            public DxfCircle(double x, double y, double radius, string layer = "0")
            {
                X = x;
                Y = y;
                Radius = radius;
                Layer = layer;
            }

            public string ToDxf()
            {
                return "0\nCIRCLE\n" +
                       "8\n" + Layer + "\n" +
                       "10\n" + X.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "20\n" + Y.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "30\n0.0\n" +
                       "40\n" + Radius.ToString(CultureInfo.InvariantCulture) + "\n";
            }
        }
    }
