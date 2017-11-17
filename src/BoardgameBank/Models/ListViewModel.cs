using System.Collections.Generic;

namespace BoardgameBank.Models
{
    public class ListViewModel
    {
        public IEnumerable<BoardgameViewModel> Boardgames { get; set; }
    }
}