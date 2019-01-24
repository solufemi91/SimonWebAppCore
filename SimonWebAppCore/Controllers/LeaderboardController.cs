using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimonWebAppCore.Models;

namespace SimonWebAppCore.Controllers
{
    [Route("Simon/[controller]")]
    public class LeaderboardController : Controller
    {
        private readonly PlayerDBContext _dbContext;

        public LeaderboardController(PlayerDBContext dbContext)
        {
            _dbContext = dbContext;

            if(_dbContext.Players.Count() == 0)
            {
                var players = new List<Player>
                {
                    new Player
                    {
                        //Id = 1,
                        Name = "John",
                        Score = 18
                    },

                    new Player
                    {
                        //Id = 2,
                        Name = "Jill",
                        Score = 3
                    },

                    new Player
                    {
                        //Id = 3,
                        Name = "Jeff",
                        Score = 11
                    }

                };

                _dbContext.Players.AddRange(players.AsEnumerable());
                _dbContext.SaveChanges();
            }

          
        }

        [HttpGet]
        // GET: Leaderboard
        public ActionResult Index()
        {
            ViewBag.players = _dbContext.Players.OrderByDescending(p => p.Score);
            return View();
        }


        // POST: Leaderboard/SaveScore
        [HttpPost]
        public ActionResult SaveScore(Player player)
        {
            _dbContext.Players.Add(player);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
   
       
    }
}