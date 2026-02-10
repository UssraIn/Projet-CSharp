using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Projet_CSharp
{
    internal class BddPostgis
    {
      

            private string connectionString =
                  "Host=localhost;Port=8000;Database=postgres;Username=postgres;Password=2003";


            public List<DxfPoint> GetPoints()
            {
                List<DxfPoint> points = new List<DxfPoint>();

                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
            SELECT 
                id,
                ST_X(geom) AS x,
                ST_Y(geom) AS y
            FROM point__dxf;
        ";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            points.Add(new DxfPoint(
                                reader.GetInt32(0),   // id
                                reader.GetDouble(1),  // x
                                reader.GetDouble(2)   // y
                            ));
                        }
                    }
                }

                return points;

            }

            public void InsertPoint(DxfPoint p)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
            INSERT INTO point_dxf (geom)
            VALUES (ST_SetSRID(ST_MakePoint(@x, @y), 4326));
        ";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("x", p.X);
                        cmd.Parameters.AddWithValue("y", p.Y);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
    }

