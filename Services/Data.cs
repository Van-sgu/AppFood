using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using FoodStreet.Services;

namespace FoodStreet.Services
{
    public class Data
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoodStreetDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30;";
        public async Task<List<POI>> GetRestaurantsAsync()
        {
            var poilist = new List<POI>();

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                var sql = "SELECT Name, Latitude, Longitude, ActivationRadius, Priority FROM Restaurants";

                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        poilist.Add(new POI
                        {
                            Name = reader.GetString(0),
                            Latitude = reader.GetDouble(1),
                            Longitude = reader.GetDouble(2),
                            Radius = reader.GetDouble(3),
                            Priority = reader.GetInt32(4)
                        });
                    }
                }
            }
            return poilist;
        }
    }
}
