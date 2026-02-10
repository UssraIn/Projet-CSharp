using Projet_CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfText
    {
       
            public string Text { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public double Height { get; set; }

            public DxfText(string value, double x, double y, double height)
            {
                Text = value;
                X = x;
                Y = y;
                Height = height;
            }
            public string ToDxf()
            {
                return "0\nTEXT\n" +
                    $"10\n{X}\n20\n{Y}\n" +
                     $"40\n{Height}\n" +
                     $"1\n{Text}\n";

            }

        }
    }

