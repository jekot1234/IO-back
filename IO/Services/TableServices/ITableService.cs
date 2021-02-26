namespace IO.Services.TableServices
{
    using IO.Model.Tables;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    public interface ITableService
    {
        List<Table> GetTables();
        IActionResult AddTable(Table table);
        void RemoveTable(Table table);
        void RemoveTable(string id);
        IActionResult UpdateTable(string id, Table table);
        IActionResult DeleteTable(string tableId);
    }
}