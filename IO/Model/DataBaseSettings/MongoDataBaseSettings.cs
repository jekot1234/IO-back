using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Model.DataBaseSettings
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDataBaseSettings
    {
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
