using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfArc
    {
      
            public float X, Y, Radius, StartAngle, EndAngle;
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
            }
        }
    }

