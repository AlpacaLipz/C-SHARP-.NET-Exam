#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Failure.Models;

public class Post
{
  [Key]
  public int PostId {get;set;}
  [Required(ErrorMessage = "Title is required.")]
  public string Title {get;set;}
  [Required(ErrorMessage = "Medium is required.")]
  public string Medium {get;set;}

  [Required(ErrorMessage = "Image is required.")]
  public string Image {get;set;}
  [Required(ErrorMessage = "For sale is required")]
  public bool ForSale {get;set;}
  public int CreatorUserId {get;set;}
  public DateTime CreatedAt {get;set;} = DateTime.Now;
  public DateTime UpdatedAt {get;set;} = DateTime.Now;

  public User? Creator {get;set;}
  public List<Like>? AllLikes { get; set; } = new List<Like>();

}