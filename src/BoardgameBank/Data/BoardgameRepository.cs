using BoardgameBank.Models;
using System;
using System.Data.Entity;

namespace BoardgameBank.Data
{
    public class BoardgameRepository
    {
        public static void DeleteGame(int id)
        {
            using (var context = new Context())
            {
                Boardgame boardgame = context.Boardgames.Find(id);
                context.Boardgames.Remove(boardgame);
                context.SaveChanges();
            }
        }

        public static void UpdateGame(EditGameViewModel editGameViewModel)
        {
            using (var context = new Context())
            {
                var boardgame = new Boardgame();
                boardgame.PlayTime = editGameViewModel.PlayTime;
                boardgame.Rating = Int32.Parse(editGameViewModel.SelectedRating);

                foreach (var playerCount in editGameViewModel.SelectedPlayerCounts)
                {
                    boardgame.PlayerCounts.Add(new PlayerCount { Count = Int32.Parse(playerCount) });
                }

                foreach (var category in editGameViewModel.AllCategories)
                {
                    boardgame.Categories.Add(new Category { CategoryName = category.ToString() });
                }

                context.Boardgames.Attach(boardgame);
                context.Entry(boardgame).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}