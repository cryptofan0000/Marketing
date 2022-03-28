using System.ComponentModel.DataAnnotations;

namespace MoonBase.MarketingSiteManager.Models
{
  public class PaymentModel
  {
    [Required(ErrorMessage = "What currency will you be purchasing with, USD, BTC, LTC")]
    [StringLength(3)]
    public string Currency { get; set; }

    [Required(ErrorMessage = "Please include an amount before proceeding")]
    public string Amount { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Dude your name is not that long, get out of here with that filth!")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Dude your name is not that long, get out of here with that filth!")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Invalid Binance Smart Chain(BSC) Address length please verify and try again.")]
    [MaxLength(60)]
    [MinLength(15)]
    public string WalletAddress { get; set; }
  }
}
