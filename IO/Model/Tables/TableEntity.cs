using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IO.Model.Tables
{
    enum PhysicalCondition
    {

    }
    public class TableEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TableID { get; set; }

        public bool IsBusy { get; set; } //:<

        public string TableBrand { get; set; }
    }
}