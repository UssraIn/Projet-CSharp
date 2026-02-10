using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class TextManager
    {
       

            public List<(string Text, Vector2 Position, double Height)> GetFixedTexts()
            {
                return new List<(string, Vector2, double)>
            {
                ("No= des piquets et points", new Vector2(-68, -6), 3),
                ("Distances Partielles", new Vector2(-68, -16), 3),
                ("Distances Cumulaires", new Vector2(-68, -26), 3),
                ("Cotes terrain naturel", new Vector2(-68, -36), 3),
                ("Cotes projet (Gen inferior)", new Vector2(-68, -46), 3),
                ("Profondeurs du debut", new Vector2(-68, -56), 3),
                ("Caracteristiques de conduits", new Vector2(-68, -66), 3),
                ("Pentes (0/00)", new Vector2(-46, -73), 3),
                ("Longueur", new Vector2(-68, -79), 3),
                ("Nature du terrain", new Vector2(-68, -86), 3)
            };
            }

        }
    }

