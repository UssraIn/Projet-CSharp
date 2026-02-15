using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projet_CSharp
{
    internal class DxfDocument
    {
     
            public List<object> Entities = new List<object>();
            public void add(object entity)
            {
                Entities.Add(entity);
            }
            public void Save(string Path)
            {
                StringBuilder dxf = new StringBuilder();
                dxf.Append("0\nSECTION\n2\nENTITIES\n");


                foreach (var entity in Entities)
                {
                    switch (entity)
                    {
                        case DxfPoint point:
                            dxf.Append(point.ToDxf());
                        break;


                        case DxfLine line:
                            dxf.Append(line.ToDxf());
                        break;


                        case DxfText text:
                            dxf.Append(text.ToDxf());
                        break;

                         case DxfPolyline Polyline:
                        dxf.Append(Polyline.ToDxf());
                        break;


                        case DxfCircle Circle:
                            dxf.Append(Circle.ToDxf());
                            break;

                        case DxfArc Arc:
                            dxf.Append(Arc.ToDxf());
                        break;



                    }

                }
                dxf.Append("0\nENDSEC\n0\nEOF");
                File.WriteAllText(Path, dxf.ToString());
            }
    }
}
