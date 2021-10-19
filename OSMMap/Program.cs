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

            Map mapa = new Map();
            mapa.Lat = 49.83148019813019;
            mapa.Lon = 18.159852471293025; 
            mapa.Zoom = 17;
            mapa.Layer = new Layer("http://c.tile.stamen.com/watercolor/{z}/{x}/{y}.jpg",17);
            mapa.Render("fileName.png");
        }
    }
}
