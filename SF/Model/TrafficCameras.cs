using System;
using System.Collections.Generic;
using System.Text;

namespace SF.Model
{
    public class TrafficCameras
    {
        public string Type { get; set; }
        public Rights Rights { get; set; }
        public Features[] Features { get; set; }
    }

    public class Rights
    {
        public string Copyright { get; set; }
        public string Licence { get; set; }
    }

    public class Features
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }
    }


    public class Properties
    {
        public string Region { get; set; }
        public string Title { get; set; }
        public string View { get; set; }
        public string Direction { get; set; }
        public string Href { get; set; }

    }
}
