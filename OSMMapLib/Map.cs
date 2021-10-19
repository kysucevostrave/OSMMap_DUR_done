using MapRendererLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMMapLib
{
    public class Map
    {
        /*private Layer layer;
        public Layer Layer { get => layer; set => layer = value; }*/

        public Layer[] layers;
     

        private double lat;
        private double lon;
        private int zoom;
        public double Lat { get => lat; set {
                lat = (value + 90.0) % 180 - 90.0;
            }
        }
        public double Lon { get => lon; set
            {
                lon = (value + 180.0) % 360 - 180.0;
            }
        }
        public int Zoom { get {
                if ( zoom > GetMinOfMaxZoom())
                    return GetMinOfMaxZoom();

                if (zoom < 1)
                    return 1;

                return zoom;
            } set => zoom = value; }


        public int CenterTileX { get => (int)((Lon + 180.0) / 360.0 * (1 << Zoom)); }
        public int CenterTileY { get => (int)((1.0 - Math.Log(Math.Tan(Lat * Math.PI / 180.0) + 1.0 / Math.Cos(Lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << Zoom)); }


        public int GetMinOfMaxZoom()
        {
            if (this.layers.Length <= 0)
            {
                return 10;
            }
            int min_value = this.layers[0].MaxZoom;
            for (int i = 1; i < this.layers.Length; i++)
            {
                if (min_value > this.layers[i].MaxZoom)
                {
                    min_value = this.layers[i].MaxZoom;
                }
            }

            return min_value;
        }
        public void Render(string fileName)
        {
            MapRenderer mapRenderer = new MapRenderer(4, 4);

            for (int k = 0; k < this.layers.Length; k++)
            {

                for (int x = -2; x < 2; x++)
                {
                    for (int y = -2; y < 2; y++)
                    {
                        Tile tile = this.layers[k][this.CenterTileX + x, this.CenterTileY + y, this.Zoom];

                        Console.WriteLine(tile);
                   
                        mapRenderer.Set(x + 2, y + 2, tile.Url, this.layers[k].Opacity);
                    }
                }
                mapRenderer.Flush();

            }
            mapRenderer.Render(fileName);
        }
    }
}
