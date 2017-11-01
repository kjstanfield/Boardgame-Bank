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
        }

        public int Id { get; set; }
        [Required, StringLength(50)]
        public string GameName { get; set; }
        public string PlayTime { get; set; }
        public List<string> Categories { get; set; }
        public int? Rating { get; set; }
        public DateTime Added { get; set; }

        public ICollection<PlayerCount> PlayerCounts { get; set; }
    }
}