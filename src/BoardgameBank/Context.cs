﻿using BoardgameBank.Models;
using System.Data.Entity;

namespace BoardgameBank
{
    public class Context : DbContext
    {
        public Context()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            Database.SetInitializer(new DatabaseInitializer());
        }
        public DbSet<Boardgame> BoardGames { get; set; }
    }
}