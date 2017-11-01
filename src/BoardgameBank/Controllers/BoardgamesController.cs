using BoardgameBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;-
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