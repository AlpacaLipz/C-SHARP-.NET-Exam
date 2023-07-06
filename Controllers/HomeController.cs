using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Failure.Models;

namespace Failure.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

public HomeController(ILogger<HomeController> logger, MyContext context)
{
    _logger = logger;
    _context = context;
}

    [HttpGet("/")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("UserId") != null)
        {
            return RedirectToAction("Index");
        }
        return View("Index");
    }

        [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("Index");
        }

        List<Post> AllPosts = _context.Posts
            .Include(p => p.Creator)
            .Include(l => l.AllLikes)
            .ToList();
        MyViewModel myViewModel = new MyViewModel{AllPosts = AllPosts};
        
        return View("Dashboard", myViewModel);
    }

    [HttpGet("/post")]
    public IActionResult Post()
    {
        return View("Post");
    }
    [HttpGet("/posts/{id}")]
    public IActionResult Display(int id)
    {
        Post? OnePost = _context.Posts.Include(g => g.Creator).SingleOrDefault(p => p.PostId == id);
        MyViewModel myViewModel = new MyViewModel{Post = OnePost};
        return View("Display", OnePost);
    }
    [HttpGet("/posts/edit/{id}")]
    public IActionResult PostEdit(int id)
    {
        Post? OnePost = _context.Posts.Include(c => c.Creator).SingleOrDefault(p => p.PostId == id);
        MyViewModel myViewModel = new MyViewModel{Post = OnePost};
        return View("EditPost", OnePost);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
