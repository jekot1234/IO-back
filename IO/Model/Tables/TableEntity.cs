using Microsoft.AspNetCore.Components;

namespace IO.Model.Tables
{
    public enum PhysicalCondition
    {
        BattleScared = 0,
        WellWorn = 1,
        FieldTested = 2,
        MinimalWear = 3,
        FactoryNew = 4
    }
    public class TableEntity
    {
        public string TableID { get; set; }

        public bool IsBusy { get; set; }

        public PhysicalCondition PhysicalCondition { get; set; }

        public string TableBrand { get; set; }
    }
}