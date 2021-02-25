namespace IO.Services.TableServices
{
    using IO.Model.DataBaseSettings;
    using IO.Model.Tables;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;

    public class TableService
    {
        private readonly IMongoCollection<TableEntity> _tables;

        public TableService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tables = database.GetCollection<TableEntity>(settings.TablesCollectionName);
        }

        public List<TableEntity> GetTables()
        {
           return _tables.Find(_ => true).ToList();
        }

        public List<TableEntity> GetTimeStamps(int number, string time)
        {
            try
            {
                long timestamp = Convert.ToInt64(time);
                string wantedID = Convert.ToString(number);
                _tables.Find(table => table.TableID == wantedID);
            }
            catch (Exception e)
            {

            }

            return null;
        }
    }
}
