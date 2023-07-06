#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Failure.Models;

public class MyContext : DbContext
{
  public MyContext(DbContextOptions options) : base(options) { }


// for every table you will have another dbset
  public DbSet<User> Users  {get;set;}
  public DbSet<Post> Posts {get;set;}
  public DbSet<Like> Likes {get;set;}
}