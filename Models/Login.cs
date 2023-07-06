#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Failure.Models;


public class Login
{

  [Required(ErrorMessage = "Email is required")]
  [EmailAddress]
  public string EmailLogin {get;set;}
  [Required(ErrorMessage = "Password is required")]
  [DataType(DataType.Password)]
  public string PasswordLogin {get;set;}

}