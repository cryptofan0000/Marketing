namespace MoonBase.MarketingSiteManager.APIConnectionServices
{
  public interface ICryptoMerchantConnectionLayer
  {
    /// <summary>
    /// Create Crypto Merchant Order
    /// </summary>
    /// <param name="orderRequest">the order request from purchaser.</param>
    /// <returns>Information returned from the api.</returns>
    CreateOrderResponse CreateCryptoMerchantOrder(OrderRequest orderRequest);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNumber"></param>
    /// <returns></returns>
    GetOrderResponse GetOrder(int orderNumber);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNumber"></param>
    /// <param name="currency"></param>
    /// <returns></returns>
    CheckoutResponse Checkout(string orderNumber, string currency);
  }
}