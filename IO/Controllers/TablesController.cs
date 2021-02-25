namespace IO.Controllers
{
    using IO.Model.Tables;
    using IO.Services.TableServices;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
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
        [Route("/tables/getTimestamps/{number:int}&{time:string}")]
        public IEnumerable<Table> GetTables(int number, string time)
        {
            return _tableService.GetTimeStamps(number, time);
        }

        [HttpGet]
        [Route("/tables/getTables")]
        public IEnumerable<Table> GetTables()
        {
            return _tableService.GetTables();
        }
    }
}
