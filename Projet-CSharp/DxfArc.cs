using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfArc
    {
      
         /**   public float X, Y, Radius, StartAngle, EndAngle;
            public DxfArc(float x, float y, float radius, float startAngle, float endAngle)
            {
                this.X = x;
                this.Y = y;
                this.Radius = radius;
                this.StartAngle = startAngle;
                this.EndAngle = endAngle;
            }
            public string ToDxf()
            {
                return "0\nARC\n" +
                    $"10\n{X}\n20\n{Y}\n" +
                    $"40\n{Radius}\n" +
                    $"50\n{StartAngle}\n51\n{EndAngle}";
            } **/

       

            public double X, Y, Radius, StartAngle, EndAngle;
            public string Layer;

            public DxfArc(double x, double y, double radius,
                          double startAngle, double endAngle,
                          string layer = "0")
            {
                X = x;
                Y = y;
                Radius = radius;
                StartAngle = startAngle;
                EndAngle = endAngle;
                Layer = layer;
            }

            public string ToDxf()
            {
                return "0\nARC\n" +
                       "8\n" + Layer + "\n" +
                       "10\n" + X.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "20\n" + Y.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "30\n0.0\n" +
                       "40\n" + Radius.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "50\n" + StartAngle.ToString(CultureInfo.InvariantCulture) + "\n" +
                       "51\n" + EndAngle.ToString(CultureInfo.InvariantCulture) + "\n";
            }
        }
    }


