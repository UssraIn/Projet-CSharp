 --CREATE TABLE point__dxf (
             --   id SERIAL PRIMARY KEY,
 --  geom GEOMETRY(Point, 4326)
--);
 --INSERT INTO point__dxf (geom)
 --VALUES
 --(ST_GeomFromText('POINT(0 55)', 4326)),
 --(ST_GeomFromText('POINT(10 59)', 4326)),
 --(ST_GeomFromText('POINT(30 61)', 4326)),
 --(ST_GeomFromText('POINT(35 65)', 4326)),
 --(ST_GeomFromText('POINT(60 70)', 4326)),
 --(ST_GeomFromText('POINT(76 73)', 4326)),
--(ST_GeomFromText('POINT(80 40)', 4326));
SELECT * FROM point__dxf  ;

-- Supprimer tout sauf 7 lignes avec les plus petits id (ou selon ton critère)
--DELETE FROM point__dxf
--WHERE id NOT IN (
   -- SELECT id
   ---- FROM point__dxf
    --ORDER BY id
   -- LIMIT 0
--);

 

--CREATE TABLE line_dxf (
  --  id SERIAL PRIMARY KEY,
   -- start_geom geometry(Point, 4326),
    --end_geom geometry(Point, 4326),
    --layer VARCHAR(50) DEFAULT '0'
--);

--INSERT INTO line_dxf (start_geom, end_geom, layer)
--VALUES (
 --   ST_SetSRID(ST_MakePoint(10, 20), 4326),
 --   ST_SetSRID(ST_MakePoint(30, 40), 4326),
 --   'Layer1'
--);

--SELECT * FROM line_dxf;


--CREATE TABLE circle_dxf (
--    id SERIAL PRIMARY KEY,
--    center_geom geometry(Point, 4326),
--    radius DOUBLE PRECISION,
--    layer VARCHAR(50) DEFAULT '0'
--);

--CREATE TABLE arc_dxf (
 --   id SERIAL PRIMARY KEY,
   -- center_geom geometry(Point, 4326),
    --radius DOUBLE PRECISION,
    --start_angle DOUBLE PRECISION,
    --end_angle DOUBLE PRECISION,
    --layer VARCHAR(50) DEFAULT '0'
--);

--CREATE TABLE layer_dxf (
  --  id SERIAL PRIMARY KEY,
    --name VARCHAR(50) UNIQUE
--);

--CREATE TABLE text_dxf (
 --   id SERIAL PRIMARY KEY,
   -- geom geometry(Point, 4326),
  --  text_value VARCHAR(255),
 --   height DOUBLE PRECISION,
   -- layer VARCHAR(50) DEFAULT '0'
--);


--SELECT * FROM point__dxf ;










--INSERT INTO points_dxf (geom)
--VALUES
--(ST_GeomFromText('POINT(3.12 36.75)', 4326)),
--(ST_GeomFromText('POINT(3.15 36.76)', 4326)),
--(ST_GeomFromText('POINT(2.15 25.26)', 4326)),
--(ST_GeomFromText('POINT(1.65 21.36)', 4326)),
--(ST_GeomFromText('POINT(0.45 16.86)', 4326));

--£SELECT * FROM points_dxf  ;
--SELECT * FROM point__dxf  ;

















--CREATE TABLE point_dxf (
                                  -- id SERIAL PRIMARY KEY,
 --  geom GEOMETRY(Point, 4326)
-- );

  
 -- INSERT INTO point_dxf (geom) VALUES
 --(ST_GeomFromText('POINT(17.0588 36.7538)', 4326)),
 --(ST_GeomFromText('POINT(26.0375 36.7472)', 4326)),
 --(ST_GeomFromText('POINT(33.0422 36.7670)', 4326)),
 --(ST_GeomFromText('POINT(43.0810 36.7264)', 4326));

  --SELECT * FROM point_dxf  ;

 --delete  FROM point_dxf  ;
