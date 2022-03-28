using System.ComponentModel.DataAnnotations;

namespace MoonBase.MarketingSiteManager
{
  public class PayPalPurchase
  {
    [Required(ErrorMessage = "What currency will you be purchasing with, USD, BTC, LTC")]
    [StringLength(3)]
    public string Currency { get; set; }

    [Required(ErrorMessage = "Please include an amount before proceding")]
    public string Amount { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Dude your name is not that long, get out of here with that!")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Dude your name is not that long, get out of here with that!")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Invalid Binance Smart Chain(BSC) Address length please verify and try again.")]
    [MaxLength(60)]
    [MinLength(15)]
    public string WalletAddress { get; set; }
    public string ClientToken { get; set; }
  }
}