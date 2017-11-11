using BoardgameBank.Models;

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
    }
}