using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Data;
using Microsoft.EntityFrameworkCore;
namespace Project.Controllers;

public class HomeController : Controller
{
            private readonly DataContext _context;

        public HomeController(DataContext context){
            _context = context;
        }

  public async Task<IActionResult> Index(){
        return View( await _context.Games.ToListAsync());
        }
    public IActionResult Privacy()
    {
        return View();
    }

}
