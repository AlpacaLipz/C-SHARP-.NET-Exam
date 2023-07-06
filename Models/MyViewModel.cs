#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Failure.Models;

public class MyViewModel
{
  public Post Post {get;set;}
  public List<Post> AllPosts {get;set;}
  public User User {get;set;}
  public List<User> AllUsers {get;set;}

}