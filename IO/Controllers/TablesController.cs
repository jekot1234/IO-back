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
        [HttpGet]
        [Route("/tables/{id}")]
        public IEnumerable<Table> GetTablesById(string id)
        {
            return _tableService.GetTablesById(id);
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
        [Route("/tables/{id}")]
        public IActionResult DeleteTable(string id)
        {
            return _tableService.DeleteTable(id);
        }
    }
}
