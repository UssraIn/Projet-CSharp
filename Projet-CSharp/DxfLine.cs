using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfLine
    {
      
           public DxfPoint Start { get; set; }
            public DxfPoint End { get; set; }

            public DxfLine(DxfPoint start, DxfPoint end)
            {
                Start = start;
                End = end;
            }

            public string ToDxf()
            {
                return "0\nLINE\n" +
                     $"10\n{Start.X}\n20\n{Start.Y}\n" +
                      $"11\n{End.X}\n21\n{End.Y}\n";
            } 

        /**
            public double X1 { get; set; }
            public double Y1 { get; set; }
            public double X2 { get; set; }
            public double Y2 { get; set; }
            public string Layer { get; set; }

            public DxfLine(double x1, double y1, double x2, double y2, string layer = "0")
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
                Layer = layer;
            }

            public string ToDxf()
            {
                return "0\nLINE\n" +
                       "8\n" + Layer + "\n" +
                       "10\n" + X1.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "20\n" + Y1.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "30\n0.0\n" +
                       "11\n" + X2.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "21\n" + Y2.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "31\n0.0\n";
            }**/
        }
    }
