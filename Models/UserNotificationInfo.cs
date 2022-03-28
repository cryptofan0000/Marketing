using System;
using System.ComponentModel.DataAnnotations;

namespace MoonBase.MarketingSiteManager
{
  public class UserNotificationInfo
  {
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address, Please enter a real one.")]
    public string Email { get; set; }
  }
}