using System.Collections.Generic;

namespace MoonBase.MarketingSiteManager
{
  public interface IMarketingSiteRepo
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="proPayReciptsCollection"></param>
    void SaveOrder(ProPayReciptsCollection proPayReciptsCollection);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userEmail"></param>
    void FutureNotificationsEmailList(UserNotificationInfo userEmail);

    /// <summary>
    /// Gets all of the notification emails
    /// </summary>
    List<UserNotificationInfoCollection> GetAllNotificationsEmailList();
  }
}