using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace FoodStreet.Services
{
    public class POI
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public int Priority { get; set; }
        public bool isInside { get; set; } = false;
        public double ActivationRadius { get; set; }

        public string Description { get; set; }
        public double Rating { get; set; }
        public DateTime LastTriggered { get; set; } = DateTime.MinValue;
    }
}
