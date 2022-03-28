using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MoonBase.MarketingSiteManager
{
  public class ProPayReciptsCollection
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string MerchantOrderId { get; set; }
    public string AmountPaid { get; set; }
    public DateTime CreationDate { get; set; }
    public string BSCAddress { get; set; }
    public string Status { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string PaymentUrl { get; set; }
    public string PaymentCurrency { get; set; }
    public string RawCreateOrderResponse { get; set; }
    public string RawRecipt { get; set; }
  }
}