using System.Linq;
using System.Web.Mvc;

namespace BoardgameBank.Controllers
{
    public class BoardgamesController : Controller
    {
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

        public ActionResult AddGame()
        {
            return View();
        }

        public ActionResult GamesList()
        {
            using (var context = new Context())
            {
                var Boardgames = context.BoardGames.ToList();
                return View(Boardgames);
            }
        }

        public ActionResult GameInfo()
        {
            return View();
        }
    }
}