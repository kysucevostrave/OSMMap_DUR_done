using System;
using System.Text;

namespace OSMMapLib
{
    public class Layer
    {
        public string urlTemplate;
        public int maxZoom;

        public string UrlTemplate { get => urlTemplate; private set => urlTemplate = value; }
        public int MaxZoom { get => maxZoom; private set => maxZoom = value; }

        public Layer(string _urlTemplate = "https://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png")
        {
            this.UrlTemplate = _urlTemplate;
            this.MaxZoom = 10;
        }
        public Layer(int _maxZoom)
        {
            this.UrlTemplate = "https://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png";
            this.MaxZoom = _maxZoom;
        }
        public Layer(string _urlTemplate, int _maxZoom = 10) : this(_urlTemplate)
        {
            this.MaxZoom = _maxZoom;
        }

        public Tile this[int _x,int _y, int _zoom]
        {
            get { return new Tile(_x, _y, _zoom, FormatUrl(_x, _y, _zoom)); }
        }


        public string FormatUrl(int _x, int _y, int _zoom)
        {
            StringBuilder sb = new StringBuilder(this.UrlTemplate);

            sb.Replace("{x}", _x.ToString());
            sb.Replace("{y}", _y.ToString());
            sb.Replace("{z}", _zoom.ToString());

            Random rnd = new Random();
            int rnd_num = rnd.Next(0, 3);
            char pismeno = (char)(97 + rnd_num);
            sb.Replace("{c}", pismeno.ToString());

            return sb.ToString();
        }




    }
}
