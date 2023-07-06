#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Failure.Models;


public class Like
{
  [Key]
  public int LikeId {get;set;}

  public int UserId {get;set;}

  public int PostId {get;set;}

  public User? Creator {get;set;}
  public Post? Post {get;set;}
}