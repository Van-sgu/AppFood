using Dapper;
using FoodStreet.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace FoodStreet.Data
{
    public class DataServices
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoodStreetDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30;";

        public async Task<List<POI>> GetPoisFromDbAsync()
        {
            using var db = new SqlConnection(_connectionString);
            string sql = @"SELECT Id, Name, Priority, Description,
                       (CAST(Latitude AS FLOAT) / 1000000) as Latitude, 
                       (CAST(Longitude AS FLOAT) / 1000000) as Longitude,
                       50 as Radius
                       FROM Locations";
            return db.Query<POI>(sql).ToList();

        }
    }
}
