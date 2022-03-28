using System.Net;

namespace MoonBase.MarketingSiteManager.APIConnectionServices
{
  public class CreateOrderResponse
  {
    public CreateOrderDto createOrderDto { get; set; }
    public string ErrorDiscription { get; set; }
    public HttpStatusCode Error { get; set; }

  }
}