using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Failure.Models;
using Microsoft.EntityFrameworkCore;

namespace Failure.Controllers;

public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;
    private MyContext _context;

public PostController(ILogger<PostController> logger, MyContext context)
{
    _logger = logger;
    _context = context;
}

    [HttpPost("/posts/new/{userid}")]
    public IActionResult PostCreate(Post newPost, int userid)
    {
      if (!ModelState.IsValid)
      {
        return View("~/Views/Home/Post.cshtml");
      }

      User? Creator = _context.Users.FirstOrDefault(u => u.UserId == userid);
      newPost.Creator = Creator;
      _context.Posts.Add(newPost);
      _context.SaveChanges();
      HttpContext.Session.SetInt32("PostId", newPost.PostId );
      return RedirectToAction("Display", "Home", new {id = newPost.PostId});
    }
    
    // [HttpPost("/post/like/{PostId}")]
    // public IActionResult LikeCreate(Guest newGuest, int PostId)
    // {
    //   newGuest.UserId = (int) HttpContext.Session.GetInt32("UserId");
    //   _context.Guests.Add(newGuest);
    //   _context.SaveChanges();
    //   return RedirectToAction("Dashboard", "Home");
    // }

    [HttpGet("/post/delete/{id}")]
    public IActionResult PostDelete(int id)
    {
        // first table is the one we do after context
      Post? PostToDelete = _context.Posts.Include(w => w.Creator).SingleOrDefault(u => u.PostId == id);
      if (PostToDelete == null)
      {
        return RedirectToAction("Dashboard", "Home");
      }

      _context.Posts.Remove(PostToDelete);
      _context.SaveChanges();
      return RedirectToAction("Dashboard", "Home");
    }
    // [HttpPost("/post/like/delete/{id}")]
    // public IActionResult LikeDelete(int id)
    // {

    //   Guest? LikeToDelete = _context.Guests.FirstOrDefault(g => g.UserId == (int)HttpContext.Session.GetInt32("UserId") && g.PostId == id);
    //   if (LikeToDelete == null)
    //   {
    //     return RedirectToAction("Dashboard");
    //   }
    //   _context.Guests.Remove(LikeToDelete);
    //   _context.SaveChanges();
    //   return RedirectToAction("Dashboard", "Home");
    // }

    [HttpPost("/posts/update/{id}")]
    public IActionResult PostUpdate(Post newPost, int id)
    {
      System.Console.WriteLine("=============    we made into =======================");
        Post? OldPost = _context.Posts.SingleOrDefault(d => d.PostId == id);
        if (OldPost == null)
        {
            return RedirectToAction("Dashboard" , "Home");
        }
        OldPost.Title = newPost.Title;
        OldPost.Medium = newPost.Medium;
        OldPost.Image = newPost.Image;
        OldPost.ForSale = newPost.ForSale;
        OldPost.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("Display", "Home", new {id = id});
    }
}