namespace IO.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    /// <summary>
    /// User's role.
    /// </summary>
    public enum Role
    {
        Client = 0,
        Service = 1,
        Admin = 2
    }
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("passwordHash")]
        public string PasswordHash { get; set; }

        [BsonElement("passwordSalt")]
        public string PasswordSalt { get; set; }

        [BsonElement("role")]
        public Role UserRole { get; set; }
    }
}
