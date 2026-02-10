using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DxfPolyline
    {
      
            public List<DxfPoint> Vertices { get; set; } = new List<DxfPoint>();
            public bool IsClosed { get; set; }

            public DxfPolyline(bool closed = false)
            {
                IsClosed = closed;
            }

            public void AddVertex(float x, float y)
            {
                Vertices.Add(new DxfPoint(x, y));
            }

            public string ToDxf()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("0");
                sb.AppendLine("LWPOLYLINE");
                sb.AppendLine("90");
                sb.AppendLine(Vertices.Count.ToString());

                foreach (var v in Vertices)
                {
                    sb.AppendLine("10");
                    sb.AppendLine(v.X.ToString());
                    sb.AppendLine("20");
                    sb.AppendLine(v.Y.ToString());
                }
                if (IsClosed)
                {
                    sb.AppendLine("70");
                    sb.AppendLine("1");
                }
                return sb.ToString();

            }
        }
    }

