using System;
using System.Collections.Generic;
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
        }
    }

