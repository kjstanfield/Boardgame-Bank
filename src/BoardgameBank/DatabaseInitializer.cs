using BoardgameBank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BoardgameBank
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
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

            var boardGame1 = new Boardgame()
            {
                GameName = "Dead of Winter",
                PlayerCounts = sixPlayer,

            };


            context.SaveChanges();
        }
    }
}