using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BoardgameBank.Controllers
{
    public class BoardgamesController : Controller
    {
        //Search Page (Searching for games)
        public ActionResult Search()
        {
            using (var context = new Context())
            {
                var SearchModel = new SearchViewModel
                {
                    AllCategories = context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.CategoryName }).ToList(),
                    AllPlayerCounts = context.PlayerCounts.Select(x => new SelectListItem { Value = x.Count.ToString()}).ToList()
                };
                return View(SearchModel);
            }
        }

        [HttpPost]
        public ActionResult ExecuteSearch(SearchViewModel model)
        {
            return View("GamesList");
        }



        //Add Game Page (Add a new Game)
        public ActionResult AddGame()
        {
            using (var context = new Context())
            {
                var AddModel = new AddGameViewModel
                {
                    AllCategories = context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.CategoryName }).ToList(),
                    AllPlayerCounts = context.PlayerCounts.Select(x => new SelectListItem { Value = x.Count.ToString() }).ToList(),
                    SelectedPlayerCounts = new List<string>()
                };
                return View(AddModel);
            }
        }

        [HttpPost]
        public ActionResult AddGame(AddGameViewModel model)
        {
            using (var context = new Context())
            {
                var boardgame = new Models.Boardgame();
                boardgame.GameName = model.GameName;

                var playercounts = context.PlayerCounts.Where(x => model.SelectedPlayerCounts.Contains(x.Count.ToString())).ToList();
                boardgame.PlayerCounts = playercounts;
                boardgame.PlayTime = model.PlayTime;

                var categories = context.Categories.Where(x => model.Categories.ToList().Contains(x.Id)).ToList();
                boardgame.Categories = categories;
                boardgame.Rating = int.Parse(model.SelectedRating);

                context.BoardGames.Add(boardgame);
                context.SaveChanges();
            }
            return View("GamesList");
        }



        //GamesList Page (List All Games)
        public ActionResult GamesList()
        {
            using (var context = new Context())
            {
                var boardgame = new ListViewModel
                {


                };
                return View();
            }
        }



        //GameInfo Page (Edit Game)
        public ActionResult GameInfo()
        {
            return View();
        }
    }
}