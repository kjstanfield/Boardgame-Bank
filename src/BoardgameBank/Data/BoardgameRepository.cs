using BoardgameBank.Models;
using System;
using System.Data.Entity;
using System.Linq;

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
                var boardgame = context.Boardgames
                    .Where(bg => bg.Id == editGameViewModel.Id)
                    .Include(bg => bg.PlayerCounts)
                    .Include(bg => bg.Categories)
                    .Single();

                boardgame.PlayTime = editGameViewModel.PlayTime;
                boardgame.Rating = Int32.Parse(editGameViewModel.SelectedRating);

                foreach (var playerCount in editGameViewModel.SelectedPlayerCounts)
                {
                    if (!boardgame.PlayerCounts.Any(pc => pc.Count == Int32.Parse(playerCount)))
                    {
                        var playerCountToAdd = context.PlayerCounts.Single(pc => pc.Count.ToString() == playerCount);
                        boardgame.PlayerCounts.Add(playerCountToAdd);
                    }
                }

                for (var i = 0; i < boardgame.PlayerCounts.Count; i++)
                {
                    if (!editGameViewModel.SelectedPlayerCounts.Any(pc => pc == boardgame.PlayerCounts.ToList()[i].Count.ToString()))
                    {
                        var playerCount = boardgame.PlayerCounts.ToList()[i];
                        boardgame.PlayerCounts.Remove(playerCount);
                    }
                }

                foreach (var category in editGameViewModel.Categories)
                {
                    if (!boardgame.Categories.Any(c => c.Id == category))
                    {
                        var categoryToAdd = context.Categories.Single(c => c.Id == category);
                        boardgame.Categories.Add(categoryToAdd);
                    }
                }

                for (var i = 0; i < boardgame.Categories.Count; i++)
                {
                    if (!editGameViewModel.Categories.Any(c => c == boardgame.Categories.ToList()[i].Id))
                    {
                        var category = boardgame.Categories.ToList()[i];
                        boardgame.Categories.Remove(category);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}