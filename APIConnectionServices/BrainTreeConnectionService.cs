using Braintree;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MoonBase.MarketingSiteManager.APIConnectionServices
{
  public class BrainTreeConnectionService : IBrainTreeConnectionService
  {
    private readonly string _apiKey;
    private readonly string _merchantId;
    private readonly string _apiSecret;
    private readonly IMarketingSiteRepo _repo;

    public BrainTreeConnectionService(IConfiguration config, IMarketingSiteRepo repo)
    {
      this._repo = repo;
      this._apiKey = config["BrainKey"];
      this._merchantId = config["MurchantID"];
      this._apiSecret = config["BrainPrivate"];
    }

    public IBraintreeGateway CreateGateway()
    {
      var newGateway = new BraintreeGateway()
      {
        Environment = Braintree.Environment.SANDBOX,
        MerchantId = this._merchantId,
        PublicKey = this._apiKey,
        PrivateKey = this._apiSecret
      };

      return newGateway;
    }

    public void Submit(PayPalPurchaseVM purchase)
    {
       
    }

    public IBraintreeGateway GetGateway()
    {
      return CreateGateway();

    }
  }
}
