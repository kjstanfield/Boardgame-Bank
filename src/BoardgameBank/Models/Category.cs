using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardgameBank.Models
{
    public class Category
    {

        public Category()
        {
            Boardgames = new List<Boardgame>();
        }

        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public ICollection<Boardgame> Boardgames { get; set; }
    }
}