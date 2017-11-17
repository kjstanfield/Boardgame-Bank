using BoardgameBank.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BoardgameBank.Data;

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
            model.Categories = model.Categories ?? new int[0];
            using (var context = new Context())
            {
                var boardgames = context.Boardgames.Where(b => model.Categories.All(c => b.Categories.Select(o => o.Id).Contains(c)))
                    .Where(b => b.PlayerCounts.Select(o => o.Count).Contains(model.PlayerCount))
                    .Where(b => b.PlayTime == model.PlayTime)
                    .Select(bg => new BoardgameViewModel
                     {
                         GameName = bg.GameName,
                         PlayTime = bg.PlayTime,
                         Rating = bg.Rating.ToString(),
                         Id = bg.Id,
                         PlayerCounts = bg.PlayerCounts.Select(p => p.Id).ToList(),
                         Categories = bg.Categories.Select(c => c.CategoryName).ToList()
                     }).ToList();

                var gamesList = new ListViewModel { Boardgames = boardgames };
                return View("GamesList", gamesList);
            }
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
                var boardgame = new Boardgame
                {
                    GameName = model.GameName
                };

                var playercounts = context.PlayerCounts.Where(x => model.SelectedPlayerCounts.Contains(x.Count.ToString())).ToList();
                boardgame.PlayerCounts = playercounts;
                boardgame.PlayTime = model.PlayTime;

                var categories = context.Categories.Where(x => model.Categories.ToList().Contains(x.Id)).ToList();
                boardgame.Categories = categories;
                boardgame.Rating = int.Parse(model.SelectedRating);

                context.Boardgames.Add(boardgame);
                context.SaveChanges();
            }
            return Redirect("GamesList");
        }



        //GamesList Page (List All Games)
        public ActionResult GamesList()
        {
            using (var context = new Context())
            {
                var boardgames = context.Boardgames.Select(bg => new BoardgameViewModel
                {
                    GameName = bg.GameName,
                    PlayTime = bg.PlayTime,
                    Rating = bg.Rating.ToString(),
                    Id = bg.Id,
                    PlayerCounts = bg.PlayerCounts.Select(p => p.Id).ToList(),
                    Categories = bg.Categories.Select(c => c.CategoryName).ToList()
                }).ToList();

                var GamesList = new ListViewModel { Boardgames = boardgames };
                return View(GamesList);
            }
        }



        //Selected game info
        public ActionResult GameInfo(int id)
        {
            using (var context = new Context())
            {
                var editGameViewModel = context.Boardgames.Where(b=> b.Id == id).Select(bg => new EditGameViewModel
                {
                    GameName = bg.GameName,
                    PlayTime = bg.PlayTime,
                    SelectedRating = bg.Rating.ToString(),
                    Id = bg.Id,
                    PlayerCount = bg.PlayerCounts.Select(p => p.Id).ToList(),
                    Categories = bg.Categories.Select(c => c.Id).ToList()
                }).Single();

                editGameViewModel.AllCategories = context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.CategoryName }).ToList();
                editGameViewModel.AllPlayerCounts = context.PlayerCounts.Select(x => new SelectListItem { Value = x.Count.ToString() }).ToList();

                foreach (var playercount in editGameViewModel.AllPlayerCounts)
                {
                    playercount.Selected = editGameViewModel.PlayerCount.Contains(int.Parse(playercount.Value));
                }

                return View(editGameViewModel);
            }
        }


        //Edit
        [HttpPost]
        public ActionResult Edit(EditGameViewModel editGameViewModel)
        {
            BoardgameRepository.UpdateGame(editGameViewModel);
            return RedirectToAction("GamesList");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            BoardgameRepository.DeleteGame(id);
            return RedirectToAction("GamesList");
        }
    }
}