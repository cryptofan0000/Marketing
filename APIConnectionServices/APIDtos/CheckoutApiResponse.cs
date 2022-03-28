namespace MoonBase.MarketingSiteManager
{
  public class CheckoutApiResponse
  {
    public int id { get; set; }
    public string status { get; set; }
    public string OrderId { get; set; }
    public string pay_amount { get; set; }
    public string pay_currency { get; set; }
    public string price_currency { get; set; }
    public string price_amount { get; set; }
    public string receive_currency { get; set; }
    public string receive_amount { get; set; }
    public string payment_url { get; set; }
    public string pay_address { get; set; }
    public string expity_at { get; set; }
    public string created_at { get; set; }
    public object token { get; set; }
  }
}
