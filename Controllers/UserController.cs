using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Failure.Models;
using Microsoft.EntityFrameworkCore;


namespace Failure.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext _context;

public UserController(ILogger<UserController> logger, MyContext context)
{
    _logger = logger;
    _context = context;
}

    [HttpGet("/user/logout")]
    public IActionResult userLogout()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("Index", "Home");
    }
    [HttpPost("/user/login")]
    public IActionResult UserLogin(Login newUser)
    {
      if(!ModelState.IsValid)
      {
        return View("~/Views/Home/Index.cshtml");
      }

      User? userInDb = _context.Users.SingleOrDefault(u => u.Email == newUser.EmailLogin);

      if (userInDb == null)
      {
        ModelState.AddModelError("EmailLogin", "Invalid Email or Password");
        return View("~/Views/Home/Index.cshtml");
      }

      PasswordHasher<Login> hasher = new PasswordHasher<Login>();
      var result = hasher.VerifyHashedPassword(newUser, userInDb.Password, newUser.PasswordLogin);

      if (result == 0)
      {
        ModelState.AddModelError("EmailLogin", "Invalid Email or Password");
        return View("~/Views/Home/Index.cshtml");
      }
      // This is where session is being made
      if (HttpContext.Session.GetInt32("UserId")== null)
      {
        HttpContext.Session.SetInt32("UserId", userInDb.UserId);
        HttpContext.Session.SetString("FirstName", userInDb.FirstName);
      }
      
      return RedirectToAction("Dashboard", "Home");
    }
    [HttpPost("/user/Create")]
    public IActionResult userCreate(User newUser)
    {
      if (!ModelState.IsValid)
      {
        return View("~/Views/Home/Index.cshtml");
      }
        PasswordHasher<User> hasher = new PasswordHasher<User>();
        newUser.Password = hasher.HashPassword(newUser, newUser.Password);
        _context.Users.Add(newUser);
        _context.SaveChanges();
          // the key has to match everytime i use UserId and this is session being created
        HttpContext.Session.SetInt32("UserId", newUser.UserId );
        HttpContext.Session.SetString("FirstName", newUser.FirstName);
        return RedirectToAction("Dashboard", "Home");

    }
    [HttpGet("/user/Edit/{id}")]
    public IActionResult userEdit(int id)
    {
      // User? currentUser = _context.Users.SingleOrDefault(u => u.UserId == id);
      // if (currentuser == null)
      // {
      //   return RedirectToAction("Index", "Home");
      // }
        return View("UserEdit");
    }
    [HttpPost("/user/Update/{id}")]
    public IActionResult userUpdate(User newuser, int id)
    {
      // if (!ModelState.IsValid)
      // {
      //   return RedirectToAction("Index");
      // }
      // User? currentUser = _context.users.SingleOrDefault(u => u.userId == id);
      // if (currentuser == null)
      // {
      //   return userEdit(id);
      // }
      // User? olduser = _context.users.SingleOrDefault(u => u.userId == id);
      // if (olduser == null)
      // {
      //   return RedirectToAction("Index");
      // }
      // oldUser.UpdatedAt = newuser.UpdatedAt;
      // _context.SaveChanges();

      return RedirectToAction("Index");
    }
    [HttpGet("/user/Delete/{id}")]
    public IActionResult userDelete(int id)
    {
      // User? userToDelete = _context.users.SingleOrDefault(u => u.userId == id);
      // if (userToDelete == null)
      // {
      //   return RedirectToAction("Index");
      // }
      // _context.users.Remove(userToDelete);
      // _context.SaveChanges();
      return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}