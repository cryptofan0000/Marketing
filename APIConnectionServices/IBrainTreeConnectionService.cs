using Braintree;

namespace MoonBase.MarketingSiteManager.APIConnectionServices
{
  public interface IBrainTreeConnectionService
  {
    IBraintreeGateway GetGateway();
    IBraintreeGateway CreateGateway();
  }
}