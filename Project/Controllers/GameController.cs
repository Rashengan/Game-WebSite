using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class GameController : Controller
    {
        private readonly DataContext _context;

        public GameController(DataContext context){
            _context = context;
        }
        public async Task<IActionResult> Index(){
            return View( await _context.Games.ToListAsync());
        }
        public IActionResult List(){

            return View();
        }
            public async Task<IActionResult> Detail(int id)
        {
            var games = await _context.Games.FindAsync(id);
            return View(games);
        }
        public async Task<IActionResult> ListGame(){
            return View(await _context.Games.ToListAsync());
        }
        public IActionResult CreateGame(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame(Game model){
            _context.Games.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
         public async Task<IActionResult> EditGame(int? id){
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                var games = await _context.Games.FirstOrDefaultAsync(g => g.GameID == id) ;
                if(games == null){
                   return NotFound(); 
                }
                return View(games);
            }
        }
        [HttpPost]
         public async Task<IActionResult> EditGame(int? id, Game model){
            if(id != model.GameID){
                return NotFound();
            }
            if(ModelState.IsValid){
                try{
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(Exception){
                    if (!_context.Games.Any(g => g.GameID == model.GameID))
                    {
                        return NotFound();
                    }else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Home");
            }
            return View(model);
            
         }
        public async Task<IActionResult> DeleteGame(int? id)
        {
            if(id == null)
            {return NotFound();}

            var games = await _context.Games.FindAsync(id);

            if (games == null)
            {return NotFound();}

            return View(games);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteGame([FromForm]int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game==null)
            {
                return NotFound();
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}