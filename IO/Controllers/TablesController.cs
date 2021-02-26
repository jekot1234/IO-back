namespace IO.Controllers
{
    using IO.Model.Tables;
    using IO.Services.TableServices;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    [ApiController]
    [Route("/tables")]
    public class TablesController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private readonly ITableService _tableService;
        public TablesController(ILogger<UsersController> logger, TableService tableService)
        {
            _logger = logger;
            _tableService = tableService;
        }

        [HttpGet]
        [Route("/tables/{number:int}/{time}")]
        public IEnumerable<Table> GetTables(int number, string time)
        {
            return _tableService.GetTimeStamps(number, time);
        }
        /// <summary>
        /// Get tables method.
        /// </summary>
        /// <returns>Returns all table entities.</returns>
        [HttpGet]
        [Route("/tables")]
        public IEnumerable<Table> GetTables()
        {
            return _tableService.GetTables();
        }

        [HttpPost]
        public IActionResult AddTable(Table table)
        {
            return _tableService.AddTable(table);
        }

        [HttpPut]
        public IActionResult UpdateTable(string id, Table table)
        {
            return _tableService.UpdateTable(id, table);
        }
        [HttpDelete]
        public IActionResult DeleteTable(string tableId)
        {
            return _tableService.DeleteTable(tableId);
        }
    }
}
