using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardgameBank.Models
{
    public class PlayerCount
    {

        public PlayerCount()
        {
            Boardgames = new List<Boardgame>();
        }

        public int Id { get; set; }
        [Required]
        public int Count { get; set; }

        public ICollection<Boardgame> Boardgames { get; set; }
    }
}