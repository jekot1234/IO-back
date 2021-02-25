namespace IO.Model.Tables
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    /// <summary>
    /// Enum which represents physical condition of single table.
    /// </summary>
    public enum PhysicalCondition
    {
        BattleScared = 0,
        WellWorn = 1,
        FieldTested = 2,
        MinimalWear = 3,
        FactoryNew = 4
    }
    /// <summary>
    /// Enum which represents advancement level of single table.
    /// </summary>
    public enum TableAdvancementLevel
    {
        Beginner = 0,
        Intermediate = 1,
        Advanced = 2
    }
    public class TableEntity
    {
        public TableEntity()
        {

        }
        public string TableID { get; set; }

        public PhysicalCondition PhysicalCondition { get; set; }
        public TableAdvancementLevel AdvancementLevel { get; set; }
        public bool IsBusy { get; set; }
        public string Brand { get; set; }
    }
}