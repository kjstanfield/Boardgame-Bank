using BoardgameBank.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace BoardgameBank
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            //Seeding Player Counts
            var onePlayer = new PlayerCount()
            {
                Count = 1
            };

            var twoPlayer = new PlayerCount()
            {
                Count = 2
            };

            var threePlayer = new PlayerCount()
            {
                Count = 3
            };

            var fourPlayer = new PlayerCount()
            {
                Count = 4
            };

            var fivePlayer = new PlayerCount()
            {
                Count = 5
            };

            var sixPlayer = new PlayerCount()
            {
                Count = 6
            };

            context.PlayerCounts.AddOrUpdate(x => x.Count, onePlayer, twoPlayer,
                threePlayer, fourPlayer, fivePlayer, sixPlayer);
            context.SaveChanges();

            //Seeding Categories
            var areaControl = new Category()
            {
                CategoryName = "Area Control"
            };

            var bluffing = new Category()
            {
                CategoryName = "Bluffing"
            };

            var cardGame = new Category()
            {
                CategoryName = "Card Game"
            };

            var deckBuilder = new Category()
            {
                CategoryName = "Deck Builder"
            };

            var diceRolling = new Category()
            {
                CategoryName = "Dice Rolling"
            };

            var elimination = new Category()
            {
                CategoryName = "Elimination"
            };

            var hiddenRoles = new Category()
            {
                CategoryName = "Hidden Roles"
            };

            var deduction = new Category()
            {
                CategoryName = "Deduction"
            };

            context.Categories.AddOrUpdate(x => x.CategoryName, areaControl, bluffing, cardGame,
                deckBuilder, diceRolling, elimination, hiddenRoles, deduction);
            context.SaveChanges();

            //Create Initial Boardgames
            var boardGame1 = new Boardgame()
            {
                GameName = "Dead of Winter",
                PlayerCounts = new List<PlayerCount> { twoPlayer, threePlayer, fourPlayer,
                    fivePlayer, sixPlayer },
                PlayTime = "Long",
                Categories = new List<Category> { bluffing, diceRolling, hiddenRoles },
                Rating = 5
            };

            var boardGame2 = new Boardgame()
            {
                GameName = "Sheriff of Nottingham",
                PlayerCounts = new List<PlayerCount> { threePlayer, fourPlayer, fivePlayer },
                PlayTime = "Medium",
                Categories = new List<Category> { bluffing, cardGame },
                Rating = 4
            };

            var boardGame3 = new Boardgame()
            {
                GameName = "Secret Hitler",
                PlayerCounts = new List<PlayerCount> { sixPlayer },
                PlayTime = "Quick",
                Categories = new List<Category> { bluffing, cardGame, deduction },
                Rating = 4
            };

            context.Boardgames.AddOrUpdate(x => x.GameName, boardGame1, boardGame2, boardGame3);
            context.SaveChanges();
        }
    }
}