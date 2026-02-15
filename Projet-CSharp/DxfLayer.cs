using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfLayer
    {
        
            public string Name { get; set; }
            public DxfLayer(string name)
            {
                Name = name;
            }
            public string ToDxf()
            {
                return "0\nLAYER\n2\n" + Name + "\n70\n0\n";
            }

    }
}

