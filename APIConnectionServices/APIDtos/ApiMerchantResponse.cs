namespace MoonBase.MarketingSiteManager.APIConnectionServices
{
  public class ApiMerchantResponse
  {
    public int id { get; set; }
    public string status { get; set; }
    public string OrderId { get; set; }
    public string price_currency { get; set; }
    public string price_amount { get; set; }
    public string receive_currency { get; set; }
    public string created_at { get; set; }
    public string payment_url { get; set; }
    public object token { get; set; }
  }
}