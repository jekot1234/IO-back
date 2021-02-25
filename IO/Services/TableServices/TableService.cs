namespace IO.Services.TableServices
{
    using IO.Model.DataBaseSettings;
    using IO.Model.Tables;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class TableService : ITableService
    {
        private readonly IMongoCollection<Table> _tables;
        public TableService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tables = database.GetCollection<Table>(settings.TablesCollectionName);
        }
        public List<Table> GetTables()
        {
            return _tables.Find(_ => true).ToList();
        }
        public List<Table> GetTimeStamps(int number, string time)
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
        public void RemoveTable(Table table) =>
            _tables.DeleteOne(t => t.TableID == table.TableID);
        public void RemoveTable(string id) =>
            _tables.DeleteOne(t => t.TableID == id);
        public IActionResult UpdateTable(string id, Table table)
        {
            if(_tables.ReplaceOne(t => t.TableID == id, table) !=  null)
            {
                return new OkResult();
            }
            return new BadRequestResult();
        }
        public IActionResult AddTable(Table table)
        {
            if (tableValidation(table))
            {
                _tables.InsertOne(table);
                return new OkResult();
            }

            return new BadRequestResult();

        }
        private bool tableValidation(Table table)
        {
            return true;
        }
    }
}
