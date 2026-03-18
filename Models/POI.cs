using SQLite;

namespace FoodStreet.Models
{
    public class POI
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double Radius { get; set; }
        public int Priority { get; set; }

        public string Tts{ get; set; }
        public string Description { get; set; } 
       
    }
}
