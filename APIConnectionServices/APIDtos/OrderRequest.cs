namespace MoonBase.MarketingSiteManager.APIConnectionServices
{
  public class OrderRequest
  {
    public string OrderId { get; set; }
    public string Currency { get; set; }
    public string Amount { get; set; }
    public string Receive_currency { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string WalletAddress { get; set; }
  }
}