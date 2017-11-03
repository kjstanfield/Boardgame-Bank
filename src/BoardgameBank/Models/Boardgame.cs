using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardgameBank.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            PlayerCounts = new List<PlayerCount>();
            Categories = new List<Category>();
            Added = DateTime.UtcNow;
        }

        public int Id { get; set; }
        [Required, StringLength(50)]
        public string GameName { get; set; }
        [Required, StringLength(10)]
        public string PlayTime { get; set; }
        public List<string> CategoryNames { get; set; }
        [Range(1, 5)]
        public int? Rating { get; set; }
        public DateTime Added { get; set; }

        public ICollection<PlayerCount> PlayerCounts { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}