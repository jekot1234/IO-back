using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Model.Tables
{
    public class TableAboutEntity
    {
        public TableAboutEntity(string _tableID, TableAdvancementLevel _advancementLevel, PhysicalCondition _physicalCondition, string _brand)
        {
            TableID = _tableID;
            AdvancementLevel = _advancementLevel;
            PhysicalCondition = _physicalCondition;
            Brand = _brand;
        }
        public string TableID { get; set; }
        public TableAdvancementLevel AdvancementLevel { get; set; }
        public PhysicalCondition PhysicalCondition { get; set; }
        public string Brand { get; set; }
    }
}
