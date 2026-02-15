using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Récupérer les points depuis PostGIS
                BddPostgis bdd = new BddPostgis();
                var points = bdd.GetPoints();

                if (points.Count == 0)
                {
                    MessageBox.Show("Aucun point trouvé dans la base de données.");
                    return;
                }

                // 2️⃣ Construire le dessin DXF
                var builder = new DrawingBuilder();

                foreach (var p in points)
                {
                    builder.AddPoint(p.X, p.Y);
                }

                var drawing = builder.BuildDrawing();

                // 3️⃣ Choix du fichier DXF
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Fichiers DXF (*.dxf)|*.dxf";
                dlg.Title = "Créer un DXF depuis PostGIS";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    drawing.SaveAsDxf(dlg.FileName);

                    // ✅ OUVERTURE AUTOMATIQUE DANS LIBRECAD
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = dlg.FileName,
                        UseShellExecute = true
                    });

                    MessageBox.Show(
                        "DXF généré et ouvert dans LibreCAD ✔",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /** try
             {
                 // 1️⃣ Choisir le fichier DXF
                 OpenFileDialog dlg = new OpenFileDialog();
                 dlg.Filter = "Fichiers DXF (*.dxf)|*.dxf";
                 dlg.Title = "Importer un DXF vers PostGIS";

                 if (dlg.ShowDialog() != DialogResult.OK)
                     return;

                 // 2️⃣ Lire les points depuis le DXF
                 DXFReader reader = new DXFReader();
                 var points = reader.ReadPoints(dlg.FileName);

                 if (points.Count == 0)
                 {
                     MessageBox.Show("Aucun point trouvé dans le fichier DXF.");
                     return;
                 }

                 // 3️⃣ Insérer les points dans PostGIS
                 BddPostgis bdd = new BddPostgis();

                 foreach (var p in points)
                 {
                     bdd.InsertPoint(p);
                 }

                 // 4️⃣ Message de succès
                 MessageBox.Show(
                     $"Import réussi ✔\n{points.Count} points ajoutés dans la base.",
                     "Succès",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                 );
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Erreur");
             } **/




            /**   try
               {
                   OpenFileDialog dlg = new OpenFileDialog();
                   dlg.Filter = "Fichiers DXF (*.dxf)|*.dxf";

                   if (dlg.ShowDialog() != DialogResult.OK)
                       return;

                   DXFReader reader = new DXFReader();
                   var points = reader.ReadPoints(dlg.FileName);

                   if (points.Count == 0)
                   {
                       MessageBox.Show("Aucun point trouvé.");
                       return;
                   }

                   BddPostgis bdd = new BddPostgis();
                   bdd.InsertPoints(points);

                   MessageBox.Show($"{points.Count} points importés avec succès ✔");
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }**/
          
            try
            {
                // 1️⃣ Choisir le fichier DXF
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Fichiers DXF (*.dxf)|*.dxf";
                dlg.Title = "Choisir un fichier DXF";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                string selectedFile = dlg.FileName;

                // 2️⃣ Lire les points du DXF
                DXFReader reader = new DXFReader();
                List<DxfPoint> points = reader.ReadPoints(selectedFile);

                if (points.Count == 0)
                {
                    MessageBox.Show("Aucun point trouvé dans le fichier DXF.");
                    return;
                }

                // 3️⃣ Insérer dans la base
                BddPostgis bdd = new BddPostgis();
                bdd.InsertPoints(points);

                MessageBox.Show(
                    $"{points.Count} points importés avec succès ✔",
                    "Import terminé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }


    

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit  ?", "Exit confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BddPostgis bdd = new BddPostgis();
                List<DxfPoint> points = bdd.GetPoints();

                if (points.Count == 0)
                {
                    MessageBox.Show("Aucun point trouvé dans la base.");
                    return;
                }
                var builder = new DrawingBuilder();
                //CustomDxfDocument doc = new CustomDxfDocument();

                foreach (var p in points)
                {
                    // doc.Points.Add(p);
                   builder.AddPoint(p.X, p.Y);

                }
                var drawing = builder.BuildDrawing();
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Fichiers DXF (*.dxf)|*.dxf";
                dlg.Title = "Enregistrer le fichier DXF";
                dlg.FileName = "export_points.dxf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    drawing.SaveAsDxf(dlg.FileName);
                    MessageBox.Show($"{points.Count} points exportés avec succès ✔");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        { 
            try
            {
                // 1️⃣ Création du document DXF
                CustomDxfDocument doc = new CustomDxfDocument();

                // Ajouter des layers
                doc.AddLayer(new DxfLayer("Layer1"));
                doc.AddLayer(new DxfLayer("Layer2"));

                // Ajouter des points
                doc.AddPoint(new DxfPoint(10, 10));
                doc.AddPoint(new DxfPoint(20, 15));

                // Ajouter des lignes
                doc.AddLine(new DxfPoint(0, 0), new DxfPoint(30, 40));
                doc.AddLine(new DxfPoint(10, 5), new DxfPoint(25, 35));

                // Ajouter des cercles
                doc.AddCircle(new DxfCircle(15, 15, 5));
                doc.AddCircle(new DxfCircle(40, 20, 10));

                // Ajouter des arcs
                doc.AddArc(new DxfArc(50, 50, 20, 0, 180));
                doc.AddArc(new DxfArc(60, 30, 10, 90, 270));

                // Ajouter du texte
                doc.AddText("Hello DXF!", 5, 5, 2);
                doc.AddText("Test Arc + Circle", 45, 25, 3);

                // 2️⃣ Choisir le fichier DXF
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Fichiers DXF (*.dxf)|*.dxf";
                dlg.Title = "Enregistrer le fichier DXF";
                dlg.FileName = "test_entites.dxf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // 3️⃣ Sauvegarder
                    doc.SaveAsDxf(dlg.FileName);
                    MessageBox.Show("Fichier DXF créé avec succès ✔\n" + dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }
   