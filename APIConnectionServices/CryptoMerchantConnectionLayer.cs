using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace MoonBase.MarketingSiteManager.APIConnectionServices
{
  public class CryptoMerchantConnectionLayer : ICryptoMerchantConnectionLayer
  {
    private readonly string _apiKey;
    private readonly string _url;
    private readonly IConfiguration _config;
    private readonly IMarketingSiteRepo _repo;
    private readonly ILoggerManager _logger;
    public CryptoMerchantConnectionLayer(IConfiguration config, ILoggerManager logger, IMarketingSiteRepo repo)
    {
      this._config = config;
      this._repo = repo;
      this._apiKey = config.GetConnectionString("ApiKey");
      this._url = config.GetConnectionString("ApiUrl");
      this._logger = logger;
    }

    /// <summary>
    /// Create Crypto Merchant Order
    /// </summary>
    /// <param name="orderRequest">the order request from purchaser.</param>
    /// <returns>Information returned from the api.</returns>
    public CreateOrderResponse CreateCryptoMerchantOrder(OrderRequest orderRequest)
    {
      var response = new CreateOrderResponse();
      var restclient = new RestClient(this._url);
      RestRequest request = new RestRequest("request/oauth") { Method = Method.Post };
      request.AddHeader("Accept", "application/json");
      request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
      request.AddHeader("Authorization", $"Token {this._apiKey}");
      request.AddParameter("OrderId", orderRequest.OrderId);
      request.AddParameter("currency", orderRequest.Currency);
      request.AddParameter("amount", orderRequest.Amount);
      request.AddParameter("receive_currency", "USD");
      request.AddParameter("title", "Pre-Order");
      request.AddParameter("description", "This is a preorder for ");
      request.AddParameter("receive_currency", "client_credentials");
      var tResponse = restclient.ExecutePostAsync<CreateOrderDto>(request);
      
      if (tResponse.Result.IsSuccessful)
      {
        this._repo.SaveOrder(new ProPayReciptsCollection()
        {
          AmountPaid = tResponse.Result.Data.response.price_amount,
          BSCAddress = orderRequest.WalletAddress,
          Email = orderRequest.Email,
          MerchantOrderId = tResponse.Result.Data.response.OrderId,
          Status = tResponse.Result.Data.response.status,
          PaymentUrl = tResponse.Result.Data.response.payment_url,
          PaymentCurrency = tResponse.Result.Data.response.receive_currency,
          RawCreateOrderResponse = tResponse.Result.Content,
        });
        response.createOrderDto = tResponse.Result.Data;
        return response;
      }

      this._logger.LogError(tResponse.Result.ErrorMessage);
      response.ErrorDiscription = tResponse.Result.ErrorMessage;
      response.Error = tResponse.Result.StatusCode;

      return new CreateOrderResponse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNumber"></param>
    /// <param name="currency"></param>
    /// <returns></returns>
    public CheckoutResponse Checkout(string orderNumber, string currency)
    {
      var restclient = new RestClient(this._url);
      RestRequest request = new RestRequest("request/oauth") { Method = Method.Post };
      request.AddHeader("Accept", "application/json");
      request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
      request.AddHeader("Authorization", $"Token {this._apiKey}");
      request.AddParameter("currency", currency);
      var tResponse = restclient.ExecutePostAsync<CheckoutResponse>(request);
      if (tResponse.Result.IsSuccessful)
      {
        return tResponse.Result.Data;
      }

      return new CheckoutResponse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNumber"></param>
    /// <returns></returns>
    public GetOrderResponse GetOrder(int orderNumber)
    {
      var restclient = new RestClient($"{this._url}/{orderNumber}");
      RestRequest request = new RestRequest("request/oauth") { Method = Method.Post };
      request.AddHeader("Accept", "application/json");
      request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
      request.AddHeader("Authorization", $"Token {this._apiKey}");
      var tResponse = restclient.ExecutePostAsync<GetOrderResponse>(request);
      if (tResponse.Result.IsSuccessful)
      {
        return tResponse.Result.Data;
      }

      return new GetOrderResponse();
    }
  }
}
