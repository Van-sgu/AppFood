using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStreet.Models
{
    public class POI
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double Radius { get; set; }
        public int Priority { get; set; }

        public string Tts{ get; set; }
        public string Description { get; set; } // Nội dung thuyết minh
       
    }
}
