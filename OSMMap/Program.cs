using OSMMapLib;
using System;

namespace OSMMap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Tile tile = new Tile(1,5,7,"urlcka");
            Console.WriteLine(tile.ToString());

            Layer layer = new Layer();
            Console.WriteLine(layer.MaxZoom);
            Console.WriteLine(layer.UrlTemplate);
            Console.WriteLine(layer.FormatUrl(tile.X, tile.Y, tile.Zoom));

            Tile tile2 = layer[1, 5, 4];
            Console.WriteLine(tile2.ToString());*/

            int max_zoom = 15;
            float opacity= 1.0f;

            Map mapa = new Map();
            mapa.Lat = 49.17685778906463; 
            mapa.Lon = 20.092766195059372; 
            mapa.Zoom = 17;

            Layer layer1 = new Layer("http://tiles.wmflabs.org/hillshading/{z}/{x}/{y}.png", 10, opacity); 
            Layer layer2 = new Layer("http://tile.memomaps.de/tilegen/{z}/{x}/{y}.png", max_zoom, 0.7f);

            mapa.layers = new Layer[2];
            mapa.layers[0] = layer1; 
            mapa.layers[1] = layer2; 

            //mapa.Layer = new Layer("http://c.tile.stamen.com/watercolor/{z}/{x}/{y}.jpg",max_zoom);
            //mapa.Layer = new Layer("https://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png", max_zoom, opacity);
            //mapa.Layer = new Layer("https://tiles.wmflabs.org/hikebike/{z}/{x}/{y}.png",max_zoom);
            //mapa.Layer = new Layer("http://tiles.wmflabs.org/hillshading/{z}/{x}/{y}.png",max_zoom);
            //mapa.Layer = new Layer("http://tile.memomaps.de/tilegen/{z}/{x}/{y}.png", max_zoom);
            //mapa.Layer = new Layer("https://tiles.wmflabs.org/bw-mapnik/{z}/{x}/{y}.png",max_zoom, 0.1f);

            mapa.Render("fileName_spojena.png");
        }
    }
}
