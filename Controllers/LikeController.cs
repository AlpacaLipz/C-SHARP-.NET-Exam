using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Failure.Models;
using Microsoft.EntityFrameworkCore;

namespace Failure.Controllers;

public class LikeController : Controller
{
    private readonly ILogger<LikeController> _logger;
    private MyContext _context;

public LikeController(ILogger<LikeController> logger, MyContext context)
{
    _logger = logger;
    _context = context;
}

    [HttpGet("/post/like/{PostId}")]
    public IActionResult LikeCreate(Like newLike, int PostId)
    {
        newLike.UserId = (int) HttpContext.Session.GetInt32("UserId");
        _context.Likes.Add(newLike);
        _context.SaveChanges();
        return RedirectToAction("Dashboard", "Home");
    }

    [HttpGet("/post/like/delete/{id}")]
    public IActionResult LikeDelete(int id)
    {

    Like? LikeToDelete = _context.Likes.FirstOrDefault(g => g.UserId == (int)HttpContext.Session.GetInt32("UserId") && g.PostId == id);
    if (LikeToDelete == null)
    {
        return RedirectToAction("Dashboard");
    }
    _context.Likes.Remove(LikeToDelete);
    _context.SaveChanges();
    return RedirectToAction("Dashboard", "Home");
    }
}