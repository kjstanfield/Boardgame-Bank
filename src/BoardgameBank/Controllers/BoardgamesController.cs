using BoardgameBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardgameBank.Controllers
{
    public class BoardgamesController : Controller
    {
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult AddGame()
        {
            using (var context = new Context())
            {
                context.BoardGames.Add(new Boardgame()
                {
                    GameName = "Dead of Winter",
                    Players = new List<int> { 1, 2, 3, 4, 5, 6 },
                    PlayTime = "Quick",
                    Categories = new List<string> { "Bluffing", "Hidden Roles", "Co-op", "Dice Rolling", "Storytelling" },
                    Rating = 5,
                    Added = DateTime.Now
                });
                context.SaveChanges();
                var boardgame = context.BoardGames.ToList();
            }
            return View();
        }

        public ActionResult GamesList()
        {
            return View();
        }

        public ActionResult GameInfo()
        {
            return View();
        }
    }
}