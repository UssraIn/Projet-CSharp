using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DXFReader
    {
    

            public List<DxfPoint> ReadPoints(string filePath)
        {
            List<DxfPoint> points = new List<DxfPoint>();

            string[] lines = File.ReadAllLines(filePath);
            double x = 0, y = 0;
            bool isPoint = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "0" && lines[i + 1] == "POINT")
                {
                    isPoint = true;
                }

                if (isPoint && lines[i] == "10")
                {
                    x = double.Parse(lines[i + 1], CultureInfo.InvariantCulture);
                }

                if (isPoint && lines[i] == "20")
                {
                    y = double.Parse(lines[i + 1], CultureInfo.InvariantCulture);
                    points.Add(new DxfPoint(x, y));
                    isPoint = false;
                }
            }

            return points;
        }
        }
    }

