using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMMapLib
{
    public class Tile
    {
        private int x;
        private int y;
        private int zoom;
        private string url;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Zoom { get => zoom;
            set {
                if (value < 1)
                {
                    zoom = 1;
                    return;
                }
                zoom = value;
            } 
        }
        public string Url { get => url; set => url = value; }

        public Tile(int x, int y, int zoom, string url)
        {
            this.x = x;
            this.y = y;
            this.zoom = zoom;
            this.url = url;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendFormat("[" + X + "," + Y + "," + Zoom + "]: " + Url);
            sb.AppendFormat("[{0}, {1}, {2}]: {3}", X, Y, Zoom, Url);

            return sb.ToString();
        }
    }
}
