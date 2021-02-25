namespace IO.Controllers
{
    using IO.Model.Tables;
    using IO.Services.TableServices;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    [Route("/tables")]
    public class TablesController : Controller
    {

        private TableService _tableService { get; set; }

        [HttpGet]
        [Route("/tables/getTimestamps?{number:int}&{time:string}")]
        public IEnumerable<TableEntity> GetTables(int number, string time)
        {
            return _tableService.GetTimeStamps(number, time);
        }
    }
}
