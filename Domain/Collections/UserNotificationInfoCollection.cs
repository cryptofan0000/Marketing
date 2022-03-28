using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MoonBase.MarketingSiteManager
{
  public class UserNotificationInfoCollection
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Email { get; set; }
    public DateTime CreationDate { get; set; }
  }
}