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
                boardgame.PlayerCounts = editGameViewModel.PlayerCount;
                boardgame.PlayTime = editGameViewModel.PlayTime;
                boardgame.Categories = editGameViewModel.Categories;
                boardgame.Rating = Int32.Parse(editGameViewModel.SelectedRating);

                context.Boardgames.Attach(boardgame);
                context.Entry(boardgame).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}