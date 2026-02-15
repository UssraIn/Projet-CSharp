using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projet_CSharp
{
    internal class CustomDxfDocument
    {

        /**
                public List<DxfPoint> Points { get; set; } = new List<DxfPoint>();
                public List<DxfLine> Lines { get; set; } = new List<DxfLine>();
                
                public List<DxfCircle> Circles = new List<DxfCircle>();
                public List<DxfArc> Arcs = new List<DxfArc>();
                public List<DxfLayer> Layers = new List<DxfLayer>();

                public void AddPoint(DxfPoint p)
                {
                    Points.Add(p);
                }

                public void AddLine(DxfPoint p1, DxfPoint p2)
                {
                    Lines.Add(new DxfLine(p1, p2));
                }

                public List<DxfText> Texts { get; set; } = new List<DxfText>();

                public void AddText(string value, double x, double y, double height)
                {
                    Texts.Add(new DxfText(value, x, y, height));
                }



                // ============================================================
                //                 EXPORT DXF ICI 🎉🎉🎉
                // ============================================================

                public void SaveAsDxf(string filePath)
                {
                    var sb = new StringBuilder();

                    // --------------------------------
                    // DXF HEADER
                    // --------------------------------
                    sb.AppendLine("0");
                    sb.AppendLine("SECTION");
                    sb.AppendLine("2");
                    sb.AppendLine("HEADER");
                    sb.AppendLine("9");
                    sb.AppendLine("$ACADVER");
                    sb.AppendLine("1");
                    sb.AppendLine("AC1009"); // DXF R12 version
                    sb.AppendLine("0");
                    sb.AppendLine("ENDSEC");

                    // --------------------------------
                    // DXF ENTITIES SECTION
                    // --------------------------------
                    sb.AppendLine("0");
                    sb.AppendLine("SECTION");
                    sb.AppendLine("2");
                    sb.AppendLine("ENTITIES");

                    // Add points
                    foreach (var p in Points)
                    {
                        sb.AppendLine("0");
                        sb.AppendLine("POINT");
                        sb.AppendLine("8");
                        sb.AppendLine("0"); // layer
                        sb.AppendLine("10");
                        // sb.AppendLine(p.X.ToString());
                        sb.AppendLine(p.X.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        sb.AppendLine("20");
                        //sb.AppendLine(p.Y.ToString());
                        sb.AppendLine(p.Y.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        sb.AppendLine("30");
                        sb.AppendLine("0.0");
                    }

                    // Add lines
                    foreach (var l in Lines)
                    {
                        sb.AppendLine("0");
                        sb.AppendLine("LINE");
                        sb.AppendLine("8");
                        sb.AppendLine("0"); // layer
                        sb.AppendLine("10");
                        sb.AppendLine(l.Start.X.ToString());
                        sb.AppendLine("20");
                        sb.AppendLine(l.Start.Y.ToString());
                        sb.AppendLine("30");
                        sb.AppendLine("0.0");
                        sb.AppendLine("11");
                        sb.AppendLine(l.End.X.ToString());
                        sb.AppendLine("21");
                        sb.AppendLine(l.End.Y.ToString());
                        sb.AppendLine("31");
                        sb.AppendLine("0.0");
                    }

                    // Add texts
                    foreach (var t in Texts)
                    {
                        sb.AppendLine("0");
                        sb.AppendLine("TEXT");
                        sb.AppendLine("8");
                        sb.AppendLine("0"); // layer
                        sb.AppendLine("10");
                        sb.AppendLine(t.X.ToString());
                        sb.AppendLine("20");
                        sb.AppendLine(t.Y.ToString());
                        sb.AppendLine("30");
                        sb.AppendLine("0.0");
                        sb.AppendLine("40");   // height
                        sb.AppendLine(t.Height.ToString());
                        sb.AppendLine("1");     // text value
                        sb.AppendLine(t.Text);
                    }


                    // --------------------------------
                    // END ENTITIES
                    // --------------------------------
                    sb.AppendLine("0");
                    sb.AppendLine("ENDSEC");

                    // --------------------------------
                    // END OF FILE
                    // --------------------------------
                    sb.AppendLine("0");
                    sb.AppendLine("EOF");

                    File.WriteAllText(filePath, sb.ToString(), Encoding.ASCII);
                } **/

        public List<DxfPoint> Points { get; set; } = new List<DxfPoint>();
        public List<DxfLine> Lines { get; set; } = new List<DxfLine>();
        public List<DxfCircle> Circles { get; set; } = new List<DxfCircle>();
        public List<DxfArc> Arcs { get; set; } = new List<DxfArc>();
        public List<DxfLayer> Layers { get; set; } = new List<DxfLayer>();
        public List<DxfText> Texts { get; set; } = new List<DxfText>();

        public void AddPoint(DxfPoint p) { Points.Add(p); }

        public void AddLine(DxfPoint start, DxfPoint end) { Lines.Add(new DxfLine(start, end)); }

        public void AddCircle(DxfCircle circle) { Circles.Add(circle); }

        public void AddArc(DxfArc arc) { Arcs.Add(arc);}

            public void AddLayer(DxfLayer layer) { Layers.Add(layer); }

            public void AddText(string text, double x, double y, double height) { 
                Texts.Add(new DxfText(text, x, y, height)); }

            public void SaveAsDxf(string filePath)
            {
                var sb = new StringBuilder();
               

            // --------------------------------
            // DXF HEADER
            // --------------------------------
            sb.AppendLine("0");
            sb.AppendLine("SECTION");
            sb.AppendLine("2");
            sb.AppendLine("HEADER");
            sb.AppendLine("9");
            sb.AppendLine("$ACADVER");
            sb.AppendLine("1");
            sb.AppendLine("AC1009"); // DXF R12 version
            sb.AppendLine("0");
            sb.AppendLine("ENDSEC");

            // --------------------------------
            // DXF ENTITIES SECTION
            // --------------------------------
            sb.AppendLine("0");
            sb.AppendLine("SECTION");
            sb.AppendLine("2");
            sb.AppendLine("ENTITIES");

            // Add points
            foreach (var p in Points)
            {
                sb.AppendLine("0");
                sb.AppendLine("POINT");
                sb.AppendLine("8");
                sb.AppendLine("0"); // layer
                sb.AppendLine("10");
                // sb.AppendLine(p.X.ToString());
                sb.AppendLine(p.X.ToString(System.Globalization.CultureInfo.InvariantCulture));
                sb.AppendLine("20");
                //sb.AppendLine(p.Y.ToString());
                sb.AppendLine(p.Y.ToString(System.Globalization.CultureInfo.InvariantCulture));
                sb.AppendLine("30");
                sb.AppendLine("0.0");
            }

            // Add lines
            foreach (var l in Lines)
            {
                sb.AppendLine("0");
                sb.AppendLine("LINE");
                sb.AppendLine("8");
                sb.AppendLine("0"); // layer
                sb.AppendLine("10");
                sb.AppendLine(l.Start.X.ToString());
                sb.AppendLine("20");
                sb.AppendLine(l.Start.Y.ToString());
                sb.AppendLine("30");
                sb.AppendLine("0.0");
                sb.AppendLine("11");
                sb.AppendLine(l.End.X.ToString());
                sb.AppendLine("21");
                sb.AppendLine(l.End.Y.ToString());
                sb.AppendLine("31");
                sb.AppendLine("0.0");
            }

            // Add texts
            foreach (var t in Texts)
            {
                sb.AppendLine("0");
                sb.AppendLine("TEXT");
                sb.AppendLine("8");
                sb.AppendLine("0"); // layer
                sb.AppendLine("10");
                sb.AppendLine(t.X.ToString());
                sb.AppendLine("20");
                sb.AppendLine(t.Y.ToString());
                sb.AppendLine("30");
                sb.AppendLine("0.0");
                sb.AppendLine("40");   // height
                sb.AppendLine(t.Height.ToString());
                sb.AppendLine("1");     // text value
                sb.AppendLine(t.Text);
            }


           
            // Lines
            /**foreach (var l in Lines)
                {
                    sb.AppendLine(l.ToDxf());
                } **/

                // Circles
                foreach (var c in Circles)
                    sb.AppendLine(c.ToDxf());

                // Arcs
                foreach (var a in Arcs)
                    sb.AppendLine(a.ToDxf());

                // Texts
              /**  foreach (var t in Texts)
                {
                    sb.AppendLine("0\nTEXT");
                    sb.AppendLine("8\n0"); // layer
                    sb.AppendLine("10\n" + t.X.ToString(CultureInfo.InvariantCulture));
                    sb.AppendLine("20\n" + t.Y.ToString(CultureInfo.InvariantCulture));
                    sb.AppendLine("30\n0.0");
                    sb.AppendLine("40\n" + t.Height.ToString(CultureInfo.InvariantCulture));
                    sb.AppendLine("1\n" + t.Text);
                }**/

                sb.AppendLine("0\nENDSEC");
                sb.AppendLine("0\nEOF");

                File.WriteAllText(filePath, sb.ToString(), Encoding.ASCII);
            }
        }
    }





