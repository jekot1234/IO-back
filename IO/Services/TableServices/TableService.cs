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
        public List<Table> GetTablesById(string id)
        {
            return _tables.Find(t => t.TableID == id).ToList();
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
        public IActionResult DeleteTable(string tableId)
        {
            try
            {
                if (!_tables.DeleteOne(t => t.TableID == tableId).IsAcknowledged)
                {
                    return new BadRequestResult();
                }
                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
        private bool tableValidation(Table table)
        {
            return true;
        }
    }
}
