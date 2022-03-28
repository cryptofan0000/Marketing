using PayPal.Api;

namespace MoonBase.MarketingSiteManager
{
  public interface IPaypalServices
  {
    Payment ExecutePayment(string paymentId, string payerId);
    Payment CreatePayment(decimal amount, string returnUrl, string cancelUrl, string intent);
  }
}