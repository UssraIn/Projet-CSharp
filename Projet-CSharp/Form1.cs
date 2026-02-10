using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            try
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
            }
        
    }
    }
}
