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
            return View(nameof(GamesList));
        }



        //Add Game Page (Add a new Game)
        public ActionResult AddGame()
        {
            using (var context = new Context())
            {
                var AddModel = new AddGameViewModel
                {
                    AllCategories = context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.CategoryName }).ToList(),
                    AllPlayerCounts = context.PlayerCounts.Select(x => new SelectListItem { Value = x.Count.ToString() }).ToList()
                };
                return View(AddModel);
            }
        }

        [HttpPost]
        public ActionResult AddGamePost(AddGameViewModel model)
        {
            return View(model);
        }



        //GamesList Page (List All Games)
        public ActionResult GamesList()
        {
            using (var context = new Context())
            {
                var Boardgames = context.BoardGames.ToList();
                return View(Boardgames);
            }
        }



        //GameInfo Page (Edit Game)
        public ActionResult GameInfo()
        {
            return View();
        }
    }
}