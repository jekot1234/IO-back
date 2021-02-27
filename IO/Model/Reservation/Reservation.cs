namespace IO.Model.Reservation
{
    using IO.Utils.UnixDateTimeConverter;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Text.Json.Serialization;

    public class Reservation
    {
        /// <summary>
        /// Reservation ID.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReservationID { get; set; }
        /// <summary>
        /// Reserved table ID.
        /// </summary>
        [BsonElement("tableId")]
        public string TableID { get; set; }
        /// <summary>
        /// If the term is expired.
        /// </summary>
        [BsonElement("userId")]
        public string UserId { get; set; }
        [BsonElement("isExpired")]
        public bool IsExpired { get; set; }

        [BsonElement("equiment")]
        public bool IsEquipment { get; set; }
        /// <summary>
        /// Time the booking starts represented in timestamp.
        /// </summary>
        [BsonElement("from")]
        public long From { get; set; }
        /// <summary>
        /// Time the booking ends represented in timestamp.
        /// </summary>
        [BsonElement("to")]
        public long To { get; set; }
    }
}
