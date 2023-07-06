#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Failure.Models;


public class User
{
  [Key]
  public int UserId {get;set;}
  [Required(ErrorMessage = "First Name is required")]
  public string FirstName {get;set;}
  [Required(ErrorMessage = "Last Name is required")]
  public string LastName {get;set;}
  [Required(ErrorMessage = "Email is required")]
  [EmailAddress]
  [UniqueEmail]
  public string Email {get;set;}
  [Required(ErrorMessage = "Password is required")]
  [DataType(DataType.Password)]
  public string Password {get;set;}
  [Required(ErrorMessage = "Confirm Password is required")]
  [DataType(DataType.Password)]
  [NotMapped]
  [Compare("Password")]
  public string ConfirmPassword {get;set;}
  public DateTime CreatedAt {get;set;} = DateTime.Now;
  public DateTime UpdatedAt {get;set;} = DateTime.Now;

  public List<Post>? AllPostsCreated {get; set;} = new List<Post>();
  public List<Like>? AllLikes {get; set;} = new List<Like>();
  public User? Creator {get;set;}
}

// Create a class that inherits from ValidationAttribute
public class UniqueEmailAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        // We are expecting the value coming in to be a string
        // so we need to do a bit of type casting to our object
        // Strings work similarly to arrays under the hood 
        // so we can grab the first letter using its index   
        // If we discover that the first letter of our string is z...  
        if (value == null)
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Email is required");   
        }
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
          return new ValidationResult("Email must be unique.");
        }
        else {   
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }  
    }
}
