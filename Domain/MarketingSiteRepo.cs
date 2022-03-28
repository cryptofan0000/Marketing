using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MoonBase.MarketingSiteManager
{
  public class MarketingSiteRepo : IMarketingSiteRepo
  {
    /// <summary>
    /// Interfaces used in class.
    /// </summary>
    private readonly IMongoCollection<ProPayReciptsCollection> _archiveCollection;
    private readonly IMongoCollection<UserNotificationInfoCollection> _notificationListCollection;
    private readonly IConfiguration _config;
    private readonly string databaseName;
    private readonly string connectionString;


    public MarketingSiteRepo(IConfiguration config)
    {
      databaseName = config["MongoSettings:DatabaseName"];
      connectionString = config["MongoSettings:ConnectionString"];
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(databaseName);

      this._archiveCollection = database.GetCollection<ProPayReciptsCollection>("PreBuyDb");
      this._notificationListCollection = database.GetCollection<UserNotificationInfoCollection>("EmailListDb");

      var archivedCreditIndexDefinition = Builders<ProPayReciptsCollection>.IndexKeys.Combine(
           Builders<ProPayReciptsCollection>.IndexKeys.Ascending(f => f.Id),
           Builders<ProPayReciptsCollection>.IndexKeys.Ascending(f => f.CreationDate),
           Builders<ProPayReciptsCollection>.IndexKeys.Ascending(f => f.Name));

      var notificationDefinition = Builders<UserNotificationInfoCollection>.IndexKeys.Combine(
       Builders<UserNotificationInfoCollection>.IndexKeys.Ascending(f => f.Id),
       Builders<UserNotificationInfoCollection>.IndexKeys.Ascending(f => f.CreationDate),
       Builders<UserNotificationInfoCollection>.IndexKeys.Ascending(f => f.Email));

      var notificationModel = new CreateIndexModel<UserNotificationInfoCollection>(notificationDefinition);
      this._notificationListCollection.Indexes.CreateOne(notificationModel);

      var indexModel = new CreateIndexModel<ProPayReciptsCollection>(archivedCreditIndexDefinition);
      this._archiveCollection.Indexes.CreateOne(indexModel);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="proPayReciptsCollection"></param>
    public void SaveOrder(ProPayReciptsCollection proPayReciptsCollection)
    {
      this._archiveCollection.InsertOne(proPayReciptsCollection);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userEmail"></param>
    public void FutureNotificationsEmailList(UserNotificationInfo userEmail)
    {
      UserNotificationInfoCollection collection = new UserNotificationInfoCollection()
      {
        CreationDate = DateTime.UtcNow,
        Email = userEmail.Email,
      };

      this._notificationListCollection.InsertOne(collection);
    }

    /// <summary>
    /// Gets all of the notification emails
    /// </summary>
    public List<UserNotificationInfoCollection> GetAllNotificationsEmailList()
    {
      var allDemEmails = this._notificationListCollection.Find(_ => true).ToList();
      
      if (allDemEmails.Count > 0)
      {
        return allDemEmails;
      }

      return null;
    }
  }
}
