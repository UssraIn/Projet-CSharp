using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    internal class DrawingBuilder
    {
            private List<DxfPoint> points = new List<DxfPoint>();

            // Ajouter un point depuis la BDD
            public void AddPoint(double x, double y)
            {
                points.Add(new DxfPoint(x, y));
            }



            public CustomDxfDocument BuildDrawing()
            {
                var doc = new CustomDxfDocument();

                // Define points
                var origin = new DxfPoint(0, 0);
                var point1 = new DxfPoint(0, 110);
                var point2 = new DxfPoint(100, 0);
                var point3 = new DxfPoint(100, -10);
                var point4 = new DxfPoint(100, -20);
                var point5 = new DxfPoint(100, -30);
                var point6 = new DxfPoint(100, -40);

                var point30 = new DxfPoint(100, -50);
                var point31 = new DxfPoint(100, -60);
                var point32 = new DxfPoint(100, -70);
                var point33 = new DxfPoint(100, -80);
                var point34 = new DxfPoint(100, -90);

                var point8 = new DxfPoint(-70, 0);
                var point9 = new DxfPoint(-70, -10);
                var point10 = new DxfPoint(-70, -20);
                var point11 = new DxfPoint(-70, -30);
                var point13 = new DxfPoint(-70, -40);
                var point20 = new DxfPoint(-70, -50);
                var point21 = new DxfPoint(-70, -60);

                var point22 = new DxfPoint(-70, -70);
                var point88 = new DxfPoint(-10, -80);

                var point23 = new DxfPoint(-70, -80);
                var point24 = new DxfPoint(-70, -90);

                var point40 = new DxfPoint(-10, -90);
                var point41 = new DxfPoint(-10, 0);

                var point14 = new DxfPoint(-80, -100);
                var point15 = new DxfPoint(110, -100);
                var point16 = new DxfPoint(-80, 110);
                var point17 = new DxfPoint(110, 110);

                var point50 = new DxfPoint(0, -20);
                var point51 = new DxfPoint(0, -10);

                var point52 = new DxfPoint(10, -10);
                var point53 = new DxfPoint(10, -20);

                var point54 = new DxfPoint(20, -10);
                var point55 = new DxfPoint(20, -20);

                var point56 = new DxfPoint(40, -10);
                var point57 = new DxfPoint(40, -20);

                var point58 = new DxfPoint(50, -10);
                var point59 = new DxfPoint(50, -20);

                var point60 = new DxfPoint(60, -10);
                var point61 = new DxfPoint(60, -20);

                // Add points
                doc.AddPoint(origin);
                doc.AddPoint(point1);
                doc.AddPoint(point2);
                doc.AddPoint(point3);
                doc.AddPoint(point4);
                doc.AddPoint(point5);
                doc.AddPoint(point6);

                doc.AddPoint(point8);
                doc.AddPoint(point9);
                doc.AddPoint(point10);
                doc.AddPoint(point11);
                doc.AddPoint(point13);
                doc.AddPoint(point14);
                doc.AddPoint(point15);
                doc.AddPoint(point16);
                doc.AddPoint(point17);
                doc.AddPoint(point20);
                doc.AddPoint(point21);
                doc.AddPoint(point22);
                doc.AddPoint(point23);
                doc.AddPoint(point24);

                doc.AddPoint(point30);
                doc.AddPoint(point31);
                doc.AddPoint(point32);
                doc.AddPoint(point33);
                doc.AddPoint(point34);

                doc.AddPoint(point40);
                doc.AddPoint(point41);
                doc.AddPoint(point50);
                doc.AddPoint(point51);

                doc.AddPoint(point52);
                doc.AddPoint(point53);
                doc.AddPoint(point54);
                doc.AddPoint(point55);

                doc.AddPoint(point56);
                doc.AddPoint(point57);
                doc.AddPoint(point58);
                doc.AddPoint(point59);
                doc.AddPoint(point60);
                doc.AddPoint(point61);

                doc.AddPoint(point88);

                // Add lines
                doc.AddLine(origin, point1);
                doc.AddLine(origin, point2);
                doc.AddLine(origin, point8);

                doc.AddLine(point3, point9);
                doc.AddLine(point4, point10);
                doc.AddLine(point5, point11);
                doc.AddLine(point6, point13);

                doc.AddLine(point3, point4);
                doc.AddLine(point4, point5);
                doc.AddLine(point5, point6);

                doc.AddLine(point9, point10);
                doc.AddLine(point10, point11);
                doc.AddLine(point11, point13);

                doc.AddLine(point8, point9);
                doc.AddLine(point2, point3);

                doc.AddLine(point14, point15);
                doc.AddLine(point14, point16);
                doc.AddLine(point16, point17);
                doc.AddLine(point17, point15);

                doc.AddLine(point20, point30);
                doc.AddLine(point21, point31);
                doc.AddLine(point22, point32);
                doc.AddLine(point23, point33);
                doc.AddLine(point24, point34);

                doc.AddLine(point6, point30);
                doc.AddLine(point30, point31);
                doc.AddLine(point31, point32);
                doc.AddLine(point32, point33);
                doc.AddLine(point33, point34);

                doc.AddLine(point13, point20);
                doc.AddLine(point20, point21);
                doc.AddLine(point21, point22);
                doc.AddLine(point22, point23);
                doc.AddLine(point23, point24);

                doc.AddLine(point40, point41);
                doc.AddLine(point50, point51);
                doc.AddLine(point52, point53);
                doc.AddLine(point54, point55);

                doc.AddLine(point56, point57);
                doc.AddLine(point58, point59);
                doc.AddLine(point60, point61);

                doc.AddLine(point22, point88);





                // --- AJOUT DES TEXTES FIXES ---
                var tm = new TextManager();
                foreach (var item in tm.GetFixedTexts())
                {
                    doc.AddText(
                        item.Text,
                        item.Position.X,
                        item.Position.Y,
                        item.Height
                    );
                }


                //LES POINTS DE BDDD
                foreach (var p in points)
                {
                    doc.AddPoint(p);
                }

                for (int i = 0 ; i< points.Count - 1; i++)
                {
                var p1 = points[i];
                var p2 = points[i + 1];
                doc.AddLine(p1, p2);
                }

                // Tracer un ligne entre la 1 ere point et la dernier point

                // X = 0 
                  var p0 = points[0];
                  var p0Y = new DxfPoint(0, p0.Y);
                  doc.AddPoint(p0Y);
                  doc.AddLine(p0Y, p0);

                 // Y = 0  
               var pLast = points[points.Count - 1];
               var pLastX = new DxfPoint(pLast.X, 0);
                   doc.AddPoint(pLastX);
                   doc.AddLine(pLast, pLastX);



              return doc;


            //LES POINTS DE BDDD
            /**  if (points.Count > 0)
              {
                  double minX = points.Min(p => p.X);
                  double minY = points.Min(p => p.Y);

                  foreach (var p in points)
                  {
                      // Décalage pour les rendre visibles
                      doc.AddPoint(new DxfPoint(
                          p.X - minX,
                          p.Y - minY
                      ));
                  }
              }***/







        }


    }



}


