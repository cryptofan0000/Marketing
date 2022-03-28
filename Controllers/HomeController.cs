using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using MoonBase.MarketingSiteManager.APIConnectionServices;
using MoonBase.MarketingSiteManager.Models;
using PayPal.Api;
using PayPal.OpenIdConnect;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MoonBase.MarketingSiteManager.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly ICryptoMerchantConnectionLayer _apiConnection;
    private readonly IBrainTreeConnectionService _braintreeService;
    private readonly IPaypalServices _paypalServices;
    private readonly IMarketingSiteRepo _mongoRepo;

    public HomeController(ILogger<HomeController> logger, IBrainTreeConnectionService brainTreeConnectionService, IPaypalServices paypalServices, IMarketingSiteRepo mongoRepo)
    {
      _logger = logger;
      _braintreeService = brainTreeConnectionService;
      _paypalServices = paypalServices;
      this._mongoRepo = mongoRepo;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [HttpPost("[action]")]
    [Route("/Whitepaper")]
    public IActionResult Whitepaper()
    {
      string embed = "<object id='pdfbox' data=\"{0}\" type=\"application/pdf\" width='100%' style='height: 100vh'>";
      embed += "If you are unable to view the file, <a href=\"/PdfViewer/park_token_whitepaper_v1.0.pdf\" target=_blank>Click me</a>";
      embed += "</object>";
      TempData["Embed"] = string.Format(embed, "/PdfViewer/park_token_whitepaper_v1.0.pdf");

      return View();
    }

    //[HttpPost("[action]")]
    //[Route("/PaymentView")]
    //public IActionResult PaymentView([FromBody] PaymentModel paymentInfo)
    //{
    //  this._apiConnection.CreateCryptoMerchantOrder(new OrderRequest()
    //  {
    //    Amount = paymentInfo.Amount,
    //    Currency = paymentInfo.Currency,
    //    Description = "Prepurchase request",
    //    Email = paymentInfo.Email,
    //    Name = $"{paymentInfo.FirstName} {paymentInfo.LastName}",
    //    WalletAddress = paymentInfo.WalletAddress,
    //  });

    //  return View();
    //}

    //[Route("/CheckOut")]
    //public IActionResult CheckOut()
    //{
    //  //this._apiConnection.CreateCryptoMerchantOrder(new OrderRequest()
    //  //{
    //  //  Amount = paymentInfo.Amount,
    //  //  Currency = paymentInfo.Currency,
    //  //  Description = "Prepurchase request",
    //  //  Email = paymentInfo.Email,
    //  //  Name = paymentInfo.Name,
    //  //  WalletAddress = paymentInfo.WalletAddress,
    //  //});

    //  return View();
    //}

    //Removed /PreOrderCheckoutFinish and /PreOrderCheckout because we were having issues on paypals side 

    [Route("/PreOrderCheckout")]
    public IActionResult PreOrderCheckout()
    {
      return View();
    }

    //[HttpPost("[action]")]
    //[Route("/PreOrderCheckoutFinish")]
    //public IActionResult PreOrderCheckoutFinish(PayPalPurchaseVM purchase)  
    //{
    //  try
    //  {
    //    this._mongoRepo.SaveOrder(new ProPayReciptsCollection()   // Missing fields will be updated manually until callback from PayPal is parsed
    //    {
    //      BSCAddress = purchase.WalletAddress,
    //      CreationDate = DateTime.UtcNow,
    //      Email = purchase.Email,
    //      Name = $"{purchase.FirstName} {purchase.LastName}",
    //      Status = "Order Status Pending"
    //    });
    //  }
    //  catch (Exception e)
    //  {

    //    return View();
    //  }


    //  //ViewBag.Email = purchase.Email;

    //  return View();
    //}

    //[HttpPost("[action]")]
    //[Route("/CompleteCheckOut")]
    //public IActionResult CompleteCheckOut(PaymentModel paymentInfo)
    //{
    //  var orderResponse = this._apiConnection.CreateCryptoMerchantOrder(new OrderRequest()
    //  {
    //    Amount = paymentInfo.Amount,
    //    Currency = paymentInfo.Currency,
    //    Description = "Prepurchase request",
    //    Email = paymentInfo.Email,
    //    Name = $"{paymentInfo.FirstName} {paymentInfo.LastName}",
    //    WalletAddress = paymentInfo.WalletAddress,
    //  });

    //  if (orderResponse.Error == HttpStatusCode.OK)
    //  {
    //    this._apiConnection.Checkout(orderResponse.createOrderDto.response.OrderId, paymentInfo.Currency);
    //  }

    //  return View();
    //}

    [Route("/PreOrderSuccess")]
    public IActionResult PreOrderSuccess()
    {
      return View();
    }

    [Route("/PreOrderCancel")]
    public IActionResult PreOrderCancel()
    {
      return View();
    }


    [HttpPost("[action]")]
    [Route("/airdrop")]
    public IActionResult AirDrop(bool checkResp)
    {
      if (checkResp)
      {
        return View();

      }

      return View("Index");
    }

    [Route("/CountryCheck")]
    public IActionResult CountryCheck()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult CreatePayment()
    {
      var payment = _paypalServices.CreatePayment(100, "https://localhost:44381/Home/ExecutePayment", "https://localhost:44381/Home/PreOrderFailure", "sale");

      return new JsonResult(payment);
    }

    [JSInvokable]
    public IActionResult DonateSelected(string email)
    {
      // var payment = _paypalServices.ExecutePayment(paymentId, PayerID);
      var test = email;
      // Hint: You can save the transaction details to your database using payment/buyer info

      return Ok();
    }

  }
}
