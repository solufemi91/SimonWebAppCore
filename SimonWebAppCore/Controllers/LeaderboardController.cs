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
                        Id = 1,
                        Name = "John",
                        Score = 18
                    },

                    new Player
                    {
                        Id = 2,
                        Name = "Jill",
                        Score = 3
                    },

                    new Player
                    {
                        Id = 3,
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
        public void SaveScore(Player test3)
        {
            //var test = name;
            //var test2 = score;
            var tes = test3;
        }

        //// GET: Leaderboard/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Leaderboard/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}



        //// GET: Leaderboard/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Leaderboard/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Leaderboard/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Leaderboard/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}