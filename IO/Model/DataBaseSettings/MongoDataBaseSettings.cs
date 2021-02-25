using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Model.DataBaseSettings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string TablesCollectionName { get; set; }
        public string ReservationsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string TablesCollectionName { get; set; }
        string ReservationsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
