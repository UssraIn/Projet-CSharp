using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DXFReader
    {
        /**  public List<DxfPoint> ReadPoints(string filePath)
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
         } **/

        /**  public List<DxfPoint> ReadPoints(string filePath)
          {
              List<DxfPoint> points = new List<DxfPoint>();

              string[] lines = File.ReadAllLines(filePath);
              bool isPointEntity = false;
              double x = 0, y = 0;

              for (int i = 0; i < lines.Length - 1; i++)
              {
                  string line = lines[i].Trim();

                  // Détection d'une entité POINT
                  if (line == "0" && lines[i + 1].Trim() == "LINE")
                  {
                      isPointEntity = true;
                  }

                  if (isPointEntity && line == "10")
                  {
                      x = double.Parse(lines[i + 1], CultureInfo.InvariantCulture);
                  }

                  if (isPointEntity && line == "20")
                  {
                      y = double.Parse(lines[i + 1], CultureInfo.InvariantCulture);
                      points.Add(new DxfPoint(x, y));
                      isPointEntity = false;
                  }
              }

              return points;
          }**/
        public List<DxfPoint> ReadPoints(string filePath)
        {
            List<DxfPoint> points = new List<DxfPoint>();
            string[] lines = File.ReadAllLines(filePath);

            double? tempX = null;

            for (int i = 0; i < lines.Length; i++)
            {
                // Détection X
                if (lines[i].Contains("3.7795") && i + 6 < lines.Length)
                {
                    string value = lines[i + 6].Replace(",", ".");
                    tempX = double.Parse(value, CultureInfo.InvariantCulture);
                }

                // Détection Y
                else if (lines[i].Contains("3.1890") && i + 6 < lines.Length)
                {
                    string value = lines[i + 6].Replace(",", ".");
                    double y = double.Parse(value, CultureInfo.InvariantCulture);

                    if (tempX.HasValue)
                    {
                        points.Add(new DxfPoint(tempX.Value, y));
                        tempX = null; // reset pour le prochain point
                    }
                }
            }

            return points;
        }
    }
}

