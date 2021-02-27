using IO.Model;
using IO.Model.DataBaseSettings;
using IO.Model.Reservation;
using IO.Services.HallService;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Services.HallServices
{
    public class HallService : IHallService
    {

        private readonly IMongoCollection<Hall> _halls;
        public HallService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _halls = database.GetCollection<Hall>(settings.HallsCollectionName);
        }

        public List<Hall> GetHalls()
        {
            return _halls.Find(_ => true).ToList();
        }


    }
}
