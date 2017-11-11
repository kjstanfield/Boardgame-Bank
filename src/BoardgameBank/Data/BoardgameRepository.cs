using BoardgameBank.Models;
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

        public static void UpdateGame(Boardgame boardgame)
        {
            using (var context = new Context())
            {
                context.Boardgames.Attach(boardgame);
                context.Entry(boardgame).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}