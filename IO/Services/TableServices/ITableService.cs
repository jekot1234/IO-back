using IO.Model.Tables;
using System.Collections.Generic;

namespace IO.Services.TableServices
{
    public interface ITableService
    {
        List<Table> GetTables();
        List<Table> GetTimeStamps(int number, string time);
    }
}